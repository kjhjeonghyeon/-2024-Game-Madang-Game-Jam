using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// HP 증가 특성

public class HPAbility : Ability
{
    public override void Enable()
    {
        Unit.OnSpawned += OnUnitSpawned;
    }
    public override void Disable()
    {
        Unit.OnSpawned -= OnUnitSpawned;
    }

    public void OnUnitSpawned(Unit unit)
    {
        if (unit.Owner == TowerManager.PlayerTower)
        {
            unit.Health += 50;
        }
        Debug.Log("Unit이 Spawn되었습니다.");
    }
}