using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UnitInformation
{
    public GameObject prefab;
    /// <summary>
    /// 비용
    /// </summary>
    public int cost;

    /// <summary>
    /// 쿨타임
    /// </summary>
    public float spawnDealy;
}