using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// HP 증가 특성

public class GoldAbility : Ability
{
    private static readonly int VALUE = 10;
    public override void Enable()
    {
        TowerManager.PlayerTower.interestValue += VALUE;
    }
    public override void Disable()
    {
        TowerManager.PlayerTower.interestValue -= VALUE;
    }
}