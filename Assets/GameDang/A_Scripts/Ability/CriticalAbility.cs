using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// HP 증가 특성

public class CriticalAbility : Ability
{
    public static int Value = 0;
    public override void Enable()
    {
        Debug.Log("크리티컬 증가");
        Value = 25;
    }
    public override void Disable()
    {
        Value = 0;
    }
}