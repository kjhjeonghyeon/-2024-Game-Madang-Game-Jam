using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        Debug.Log("Unit이 Spawn되었습니다.");
    }
}