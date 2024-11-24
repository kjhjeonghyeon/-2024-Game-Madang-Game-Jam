using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// HP 증가 특성

public class SkillAbility : Ability
{
    public override void Enable()
    {
        TowerManager.PlayerTower.CoolTime -= 5;
    }
    public override void Disable()
    {
        TowerManager.PlayerTower.CoolTime += 5;
    }

}