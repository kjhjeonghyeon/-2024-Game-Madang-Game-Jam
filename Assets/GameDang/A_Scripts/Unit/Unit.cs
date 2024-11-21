using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public static event Action<Unit> OnSpawned;

    public void Init()
    {
        OnSpawned?.Invoke(this);
    }
}
