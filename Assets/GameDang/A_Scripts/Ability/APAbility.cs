using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// HP 증가 특성

public class APAbility : Ability
{
    private static readonly int VALUE = 50;
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
            unit.Health += VALUE;
        }        
    }
}