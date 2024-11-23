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
    public int AttackPower
    {
        get { return attackPower; }
        set { attackPower = value; }
    }
    #endregion
    
    #region  제어용 Property
    private bool isTarget = false;
    private IHit attackTarget = null;
    private float delay = 0;
    private bool isAttack = false;

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
    [SerializeField] private DetectSystem detectSystem;

    public void Init(Tower onwer)
    {
        Owner = onwer;
        direction = TowerManager.PlayerTower == onwer ? 1 : -1;
        OnSpawned?.Invoke(this);
        detectSystem.SetUnit(this);
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
            transform.position += (Vector3) Vector2.right  * direction * Time.deltaTime * speed;  // 5 이부분 speed 들어가야함 하드코딩임
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
        attackTarget.Hit(calculatePower);
    }

    public void Hit(int damage)
    {
        Debug.Log(gameObject.name + " : " + damage + " 피해 !");
        health -= damage;
        if (health <= 0) {
            Dead();
        }
    }
    private void Dead()
    {
        Owner.ActiveUnits.Remove(this);
        gameObject.SetActive(false);
        OnDied?.Invoke(this);
    }


    #region 이벤트
    public static event Action<Unit> OnSpawned;
    public static event Action<Unit> OnDied;
    # endregion
}
