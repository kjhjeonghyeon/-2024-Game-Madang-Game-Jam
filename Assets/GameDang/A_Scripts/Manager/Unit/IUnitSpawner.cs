using System.Collections.Generic;
using UnityEngine;

public interface IUnitSpawner
{
    /// <summary>
    ///  활성화 되어 있는 Unit List
    /// </summary>
    public List<Unit> ActiveUnits { get; }

    /// <summary>
    /// Unit Spawn 시키는 함수
    /// </summary>
    /// <param name="prefab">Spawn 시킬 Unit </param>
    /// <returns> Spawn 된 Unit </returns>
    public Unit SpawnUnit(GameObject prefab);
    public Unit SpawnUnit(GameObject prefab, bool isPlayer);
}