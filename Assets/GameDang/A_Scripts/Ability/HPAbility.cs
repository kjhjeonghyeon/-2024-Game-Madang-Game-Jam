using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// HP 증가 특성

public class HPAbility : Ability
{
    private static readonly int VALUE = 50;
    public override void Enable()
    {
        Debug.Log("Enable");
        Unit.OnSpawned += OnUnitSpawned;
    }
    public override void Disable()
    {
        Unit.OnSpawned -= OnUnitSpawned;
    }

    public void OnUnitSpawned(Unit unit)
    {
        Debug.Log("Unit이 Spawn되었습니다.");
        if (unit.Owner == TowerManager.PlayerTower)
        {
            unit.Health += VALUE;
        }        
    }
}