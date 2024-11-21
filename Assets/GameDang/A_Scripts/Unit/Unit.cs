using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public static event Action<Unit> OnSpawned;

    /// <summary>
    /// 스폰 시킨 타워
    /// </summary>
    public Tower Country { get; private set; }

    /// <summary>
    /// Player 가 스폰 시킨 Unit 인지.
    /// </summary>
    private bool _isPlayer;

    public void Init(Tower country, bool isPlayer)
    {
        Country = country;
        _isPlayer = isPlayer;
        OnSpawned?.Invoke(this);
    }
    private void FixedUpdate()
    {
        Vector2 direction = _isPlayer ? Vector2.right : Vector2.left;        
        transform.position += (Vector3) direction * Time.deltaTime * 5; // 5 이부분 speed 들어가야함 하드코딩임
    }
}
