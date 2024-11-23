using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// 0, 3, 4
public abstract class Ability
{
    public static Dictionary<string, Tuple<bool, Ability>> abilityMap = new Dictionary<string, Tuple<bool, Ability>>
    {
        // 공용 8 개
        { "000", new Tuple<bool, Ability>(false, new RecoveryAbility()) }, // 자연 회복
        { "001", new Tuple<bool, Ability>(false, new CriticalAbility()) }, // 치명타율
        { "002", new Tuple<bool, Ability>(false, new HPAbility()) }, // 최대 채력 O
        { "003", new Tuple<bool, Ability>(false, new HPAbility()) }, // 넉백
        { "004", new Tuple<bool, Ability>(false, new APAbility()) }, // 공격력 증가 O
        { "005", new Tuple<bool, Ability>(false, new GoldAbility()) }, // 초당 재화 O
        { "006", new Tuple<bool, Ability>(false, new HPAbility()) }, // 생산 쿨 감소
        { "007", new Tuple<bool, Ability>(false, new HPAbility()) }, // 필살기 쿨 감소
    };
    public static List<Ability> GetEnableAbilitys()
    {
        return abilityMap.Where(pair => pair.Value.Item1).Select(pair => pair.Value.Item2).ToList();
    }
    public static List<Ability> GetSelectAbleAbilitys()
    {
        return abilityMap.Where(pair => !pair.Value.Item1).Select(pair => pair.Value.Item2).ToList();
    }
    public abstract void Enable();
    public abstract void Disable();
}