using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ability
{
    // 공용 8 개
    // 유닛 32 개    
    // 000 001 002 003 004 005 006 007 008 // 공용
    // 100 101 110 111 120 121 130 131 // 
    // 200 201 210 211 220 221 230 231
    // 300 301 310 311 320 321 330 331
    // 400 401 410 411 420 421 430 431
    public static Dictionary<string, bool> abilityMap = new Dictionary<string, bool>
    {
        // 공용 8 개
        { "000", false },
        { "001", false },
        { "002", false },
        { "003", false },
        { "004", false },
        { "005", false },
        { "006", false },
        { "007", false },
        { "008", false },

        // 유닛 32 개
        { "100", false }, { "101", false },
        { "110", false }, { "111", false },
        { "120", false }, { "121", false },
        { "130", false }, { "131", false },
        
        { "200", false }, { "201", false },
        { "210", false }, { "211", false },
        { "220", false }, { "221", false },
        { "230", false }, { "231", false },

        { "300", false }, { "301", false },
        { "310", false }, { "311", false },
        { "320", false }, { "321", false },
        { "330", false }, { "331", false },

        { "400", false }, { "401", false },
        { "410", false }, { "411", false },
        { "420", false }, { "421", false },
        { "430", false }, { "431", false }
    };
    public static List<string> GetSelectAbleAblilityKeys()
    {
        string code = TowerManager.PlayerSelectTowerIndex + 1.ToString();
        return abilityMap.Where(pair => pair.Key.StartsWith(code) || pair.Key.StartsWith("0") || !pair.Value )
            .Select(pair => pair.Key)
            .ToList();
    }
}
