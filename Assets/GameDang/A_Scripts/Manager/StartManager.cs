using System;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    private void OnEnable()
    {
        TowerManager.activeKeys = new HashSet<int>(){0,1,2,3};
        Ability.abilityMap = new Dictionary<string, Tuple<bool, Ability>>
        {        
            { "000", new Tuple<bool, Ability>(false, new RecoveryAbility()) }, // 자연 회복 O
            { "001", new Tuple<bool, Ability>(false, new CriticalAbility()) }, // 치명타율 O
            { "002", new Tuple<bool, Ability>(false, new HPAbility()) }, // 최대 채력 O        
            { "003", new Tuple<bool, Ability>(false, new APAbility()) }, // 공격력 증가 O
            { "004", new Tuple<bool, Ability>(false, new GoldAbility()) }, // 초당 재화 O        
            { "005", new Tuple<bool, Ability>(false, new SkillAbility()) }, // 필살기 쿨 감소 O
        };
    }
}
