using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    /// <summary>
    /// 소유 타워
    /// </summary>
    public Tower Owner { get; private set; }

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
    private void FixedUpdate()
    {
        transform.position += (Vector3) Vector2.right  * direction * Time.deltaTime; // 5 이부분 speed 들어가야함 하드코딩임
    }

    # region 이벤트
    public static event Action<Unit> OnSpawned;
    # endregion
}
