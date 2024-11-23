using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public abstract class Tower : MonoBehaviour, IUnitSpawner, IHit
{
    # region Spawn 관련
    public List<Unit> ActiveUnits => _activeUnits;
    protected List<Unit> _activeUnits = new List<Unit>();
    [SerializeField] protected Transform spawnLocation;
    # endregion

    /*- Unit 관련 -*/
    [SerializeField] protected TowerData towerData;
    public int Helath { get; private set; }
    private void Awake()
    {
        Helath = towerData.health;
    }
    public Unit SpawnUnit(Unit prefab)
    {
        Unit unit = Instantiate(prefab);
        unit.name = "Unit_" + _activeUnits.Count;
        unit.Init(this);
        unit.transform.position = spawnLocation.position;
        _activeUnits.Add(unit);
        return unit;
    }

    public UnitInformation GetUnitInformation(int index) => towerData.list[index];
    public void Hit(int damage)
    {
        Helath -= damage;
        OnTowerHited?.Invoke(this, damage);
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
    public abstract void Skill();

    #region Event
    public static event Action<Tower> OnTowerDied;
    public static event Action<Tower, int> OnTowerHited;
    #endregion
}
