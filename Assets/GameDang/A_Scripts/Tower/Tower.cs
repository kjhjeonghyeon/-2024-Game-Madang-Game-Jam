using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Tower : MonoBehaviour, IUnitSpawner, IHit
{
    /*- Spawn 관련 -*/
    public List<Unit> ActiveUnits => _activeUnits;
    protected List<Unit> _activeUnits = new List<Unit>();
    [SerializeField] protected Transform spawnLocation;

    /*- Unit 관련 -*/
    [SerializeField] protected TowerData towerData;
    public int Helath { get; private set; }
    private void Awake()
    {
        Helath = towerData.health;
    }
    public Unit SpawnUnit(GameObject prefab)
    {
        GameObject created = Instantiate(prefab);
        Unit unit = created.GetComponent<Unit>();
        if (!unit) {
            throw new System.Exception("Unit Component가 없습니다.");
        }
        unit.name = "Unit_" + _activeUnits.Count;
        unit.Init(this);
        unit.transform.position = spawnLocation.position;
        _activeUnits.Add(unit);
        return unit;
    }

    public UnitInformation GetUnitInformation(int index) => towerData.list[index];

    public void Hit(int damage)
    {
        Debug.Log(gameObject.name + " : " + damage + " 피해 !");
        Helath -= damage;
        if (Helath <= 0) {
            Died();
        }
    }
    private void Died()
    {
        OnTowerDied?.Invoke(this);
    }

    public Tower GetTower()
    {
        return this;
    }

    #region Event
    public static event Action<Tower> OnTowerDied;
    #endregion
}
