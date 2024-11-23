using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Scriptable Objects/TowerData")]
public class TowerData : ScriptableObject
{
    /// <summary>
    /// 세계관 이름
    /// </summary>
    public string towerName;
    /// <summary>
    /// 타워 채력
    /// </summary>
    public int health;
    /// <summary>
    /// 세계관이 소환 가능한 Unit List
    /// </summary>
    public List<UnitInformation> list;


    
}

