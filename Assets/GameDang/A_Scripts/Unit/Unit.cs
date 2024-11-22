using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IHit
{
    [SerializeField] protected float speed;
    [SerializeField] protected float range;
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
    private bool isTarget = false;
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
    [SerializeField] private AttackSystem attackSystem;

    public void Init(Tower onwer)
    {
        Owner = onwer;
        direction = TowerManager.PlayerTower == onwer ? 1 : -1;
        OnSpawned?.Invoke(this);
        attackSystem.SetUnit(this);
    }
    private void Update()
    {
        isTarget = attackSystem.targets.Count > 0;
    }
    private void FixedUpdate()
    {
        if (!isTarget) {
            transform.position += (Vector3) Vector2.right  * direction * Time.deltaTime * speed;  // 5 이부분 speed 들어가야함 하드코딩임
        }
    }

    public void Hit(int damage)
    {
        throw new NotImplementedException();
    }


    #region 이벤트
    public static event Action<Unit> OnSpawned;
    # endregion
}
