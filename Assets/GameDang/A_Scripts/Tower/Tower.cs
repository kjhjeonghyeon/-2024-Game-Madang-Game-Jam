using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Tower : MonoBehaviour, IUnitSpawner
{
    /*- Spawn 관련 -*/
    public List<Unit> ActiveUnits => _activeUnits;
    protected List<Unit> _activeUnits = new List<Unit>();
    [SerializeField] protected Transform spawnLocation;

    /*- Unit 관련 -*/
    [SerializeField] protected TowerData towerData;
    public Unit SpawnUnit(GameObject prefab)
    {
        GameObject created = Instantiate(prefab, transform);
        Unit unit = created.GetComponent<Unit>();
        if (!unit) {
            throw new System.Exception("Unit Component가 없습니다.");
        }
        unit.Init(this);
        unit.transform.position = spawnLocation.position;
        _activeUnits.Add(unit);
        return unit;
    }

    public UnitInformation GetUnitInformation(int index) => towerData.list[index];
}
