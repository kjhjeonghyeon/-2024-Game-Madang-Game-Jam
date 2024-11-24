using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// 0, 3, 4
public abstract class Ability
{
    public static Dictionary<string, Tuple<bool, Ability>> abilityMap = new Dictionary<string, Tuple<bool, Ability>>
    {        
        { "000", new Tuple<bool, Ability>(false, new RecoveryAbility()) }, // 자연 회복 O
        { "001", new Tuple<bool, Ability>(false, new CriticalAbility()) }, // 치명타율 O
        { "002", new Tuple<bool, Ability>(false, new HPAbility()) }, // 최대 채력 O        
        { "003", new Tuple<bool, Ability>(false, new APAbility()) }, // 공격력 증가 O
        { "004", new Tuple<bool, Ability>(false, new GoldAbility()) }, // 초당 재화 O        
        { "005", new Tuple<bool, Ability>(false, new SkillAbility()) }, // 필살기 쿨 감소 O
    };
    public static List<Ability> GetEnableAbilitys()
    {
        return abilityMap.Where(pair => pair.Value.Item1).Select(pair => pair.Value.Item2).ToList();
    }
    public static List<string> GetSelectAbleAbilitys()
    {
        return abilityMap.Where(pair => !pair.Value.Item1).Select(pair => pair.Key).ToList();
    }

    public static void EnableAbility(string code)
    {
        Debug.Log(code);
        abilityMap[code] = new Tuple<bool, Ability>(true, abilityMap[code].Item2);
    }
    public abstract void Enable();
    public abstract void Disable();
}