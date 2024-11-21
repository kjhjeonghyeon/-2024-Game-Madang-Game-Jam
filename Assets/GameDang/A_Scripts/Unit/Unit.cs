using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public static event Action<Unit> OnSpawned;

    /// <summary>
    /// 스폰 시킨 타워
    /// </summary>
    public Tower Country { get; private set; }

    public void Init(Tower country)
    {
        Country = country;
        OnSpawned?.Invoke(this);
    }
    private void Update()
    {
        
    }
}
