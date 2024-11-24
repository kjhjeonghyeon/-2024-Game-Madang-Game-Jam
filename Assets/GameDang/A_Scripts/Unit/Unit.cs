using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IHit
{
    #region Unit 정보 propertys
    [SerializeField] protected float speed;
    [SerializeField] protected float range;
    [SerializeField] protected float attackDelay;
    [SerializeField] protected int health;
    [SerializeField] protected int attackPower;
    [SerializeField] protected int giftGold;

    public float Range
    {
        get { return range; }
        set { range = value; }
    }
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public float AttackDelay
    {
        get { return attackDelay; }
        set { attackDelay = value; }
    }
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    private int MaxHealth;
    public int AttackPower
    {
        get { return attackPower; }
        set { attackPower = value; }
    }
    public int GiftGold
    {
        get { return giftGold; }
        set { giftGold = value; }
    }
    #endregion
    
    #region  제어용 Property
    private bool isTarget = false;
    private IHit attackTarget = null;
    private float delay = 0;
    private bool isAttack = false;

    [SerializeField] Animator animator;

    #endregion
    /// <summary>
    /// 소유 타워
    /// </summary>
    public Tower Owner { get; private set; }
    public Tower GetTower()
    {
        return Owner;
    }
    /// <summary>
    /// 이동 방향 1 이면 오른쪽 -1 이면 왼쪽
    /// </summary>
    private int direction = 1;
    public bool IsMine { get; set; }
    [SerializeField] private DetectSystem detectSystem;

    public void Init(Tower onwer)
    {
        Owner = onwer;
        direction = TowerManager.PlayerTower == onwer ? -1 : 1;
        IsMine = TowerManager.PlayerTower == onwer;
        OnSpawned?.Invoke(this);
        detectSystem.SetUnit(this);
        if (TowerManager.PlayerTower == onwer) {
            if (RecoveryAbility.Flag) {
                StartCoroutine(RecoveryCoroutine());
            }
        }
        if (!IsMine)
        {
            transform.Rotate(new Vector3(0, -180, 0));
        }
    }
    private IEnumerator<WaitForSeconds> RecoveryCoroutine()
    {
        while (gameObject.activeSelf) {
            if (Health < MaxHealth) {
                Health += RecoveryAbility.Value;
                Health = Mathf.Min(Health, MaxHealth);
            }
            yield return new WaitForSeconds(RecoveryAbility.Delay);
        }
        yield break;
    }
    private void Awake()
    {
        MaxHealth = Health;
    }
    private void Update()
    {
        isTarget = detectSystem.targets.Count > 0;
        if (isTarget) TargetTing();
        isAttack = attackTarget != null;
        if (isAttack) Attacking();
    }
    private void FixedUpdate()
    {
        if (!isTarget) {
            Vector3 calculate = (Vector3) Vector2.right  * direction * Time.deltaTime * speed;
            if (IsMine)
                calculate *= TowerD.SpeedUpValue;
            transform.position += calculate;
        }
    }

    private void TargetTing()
    {
        attackTarget = detectSystem.targets.ToList()[0];
    }

    private void Attacking()
    {
        if (delay <= 0) {
            Attack();
            delay = attackDelay;
        }
        delay -= Time.deltaTime;
    }

    protected virtual void Attack()
    {
        int calculatePower = attackPower; // 추가 데미지 필요할경우 해당 변수 조정
        if (TowerManager.PlayerTower == Owner && Util.Dice(CriticalAbility.Value)) {
            Debug.Log("크리티컬!");
            calculatePower *= 2;
        }
        attackTarget.Hit(calculatePower);
    }
    private bool isDead = false;

    public void Hit(int damage)
    {
        // Debug.Log(gameObject.name + " : " + damage + " 피해 !");
        health -= damage;
        if (health <= 0) {
            if (IsMine && TowerC.IsInvincibility) {
                health = 1;
                return;                
            }
            if (!isDead)
                Dead();
        }
    }
    public static bool HasParameter(string paramName, Animator animator)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName)
                return true;
        }
        return false;
    }
    private void Dead()
    {
        isDead = true;
        if (animator != null && HasParameter("Die", animator))
        {
            animator.SetTrigger("Die");
        }
        StartCoroutine(RunDie());        
    }
    private IEnumerator<WaitForSeconds> RunDie()
    {
        OnDied?.Invoke(this);
        if (Owner.ActiveUnits != null && Owner.ActiveUnits.Contains(this))
        {
            Owner.ActiveUnits.Remove(this);
        }
        yield return new WaitForSeconds(1.5f);        
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        OnDied += OnUnitDied;
    }

    private void OnDisable()
    {
        OnDied -= OnUnitDied;
    }
    private void OnUnitDied(Unit unit)
    {
        if ((IHit) unit == attackTarget) {
            attackTarget = null;
        }
    }


    #region 이벤트
    public static event Action<Unit> OnSpawned;
    public static event Action<Unit> OnDied;
    # endregion
}
