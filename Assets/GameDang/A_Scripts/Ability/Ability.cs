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
        { "000", new Tuple<bool, Ability>(true, new HPAbility()) },
        { "001", new Tuple<bool, Ability>(false, new HPAbility()) },
        { "002", new Tuple<bool, Ability>(false, new HPAbility()) },
        { "003", new Tuple<bool, Ability>(false, new HPAbility()) },
        { "004", new Tuple<bool, Ability>(false, new HPAbility()) },
        { "005", new Tuple<bool, Ability>(false, new HPAbility()) },
        { "006", new Tuple<bool, Ability>(false, new HPAbility()) },
        { "007", new Tuple<bool, Ability>(false, new HPAbility()) },
    };
    public static List<Ability> GetEnableAbilitys()
    {
        return abilityMap.Where(pair => pair.Value.Item1).Select(pair => pair.Value.Item2).ToList();
    }
    public abstract void Enable();
    public abstract void Disable();
}