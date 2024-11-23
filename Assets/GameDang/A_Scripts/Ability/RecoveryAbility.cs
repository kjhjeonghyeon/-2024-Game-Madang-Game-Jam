using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// HP 증가 특성

public class RecoveryAbility : Ability
{
    public static int Value = 5;
    public static float Delay = 1f;
    public static bool Flag = false;
    public override void Enable()
    {
        Flag = true;
    }
    public override void Disable()
    {
        Flag = false;
    }
}