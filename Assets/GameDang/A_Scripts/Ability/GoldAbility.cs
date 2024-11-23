using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// HP 증가 특성

public class GoldAbility : Ability
{
    public static int BounsGold { get; private set;}
    private static readonly int VALUE = 10;
    public override void Enable()
    {
        BounsGold = VALUE;
    }
    public override void Disable()
    {
        BounsGold = 0;
    }
}