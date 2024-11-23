using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public static Dictionary<string, Tuple<bool, Ability>> abilityMap = new Dictionary<string, Tuple<bool, Ability>>
    {
        // 공용 8 개
        { "000", new Tuple<bool, Ability>(true, new Ability()) },
        { "001", new Tuple<bool, Ability>(false, new Ability()) },
        { "002", new Tuple<bool, Ability>(false, new Ability()) },
        { "003", new Tuple<bool, Ability>(false, new Ability()) },
        { "004", new Tuple<bool, Ability>(false, new Ability()) },
        { "005", new Tuple<bool, Ability>(false, new Ability()) },
        { "006", new Tuple<bool, Ability>(false, new Ability()) },
        { "007", new Tuple<bool, Ability>(false, new Ability()) }
    };
    public static List<Ability> GetEnableAbilitys()
    {
        return abilityMap.Where(pair => pair.Value.Item1).Select(pair => pair.Value.Item2).ToList();
    }
}
