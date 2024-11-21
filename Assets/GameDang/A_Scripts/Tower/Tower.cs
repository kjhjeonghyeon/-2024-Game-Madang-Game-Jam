using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour, IUnitSpawner
{
    // 외부 공개용
    public List<Unit> ActiveUnits => _activeUnits;
    protected List<Unit> _activeUnits = new List<Unit>();
    [SerializeField] protected Transform spawnLocation;
    public Unit SpawnUnit(GameObject prefab)
    {
        GameObject created = Instantiate(prefab, transform);
        Unit unit = created.GetComponent<Unit>();
        if (!unit) {
            throw new System.Exception("Unit Component가 없습니다.");
        }
        unit.transform.position = spawnLocation.position;
        return unit;
    }
}
