using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private void Start()
    {
        List<Ability> abilities = Ability.GetSelectAbleAbilitys();
        Debug.Log(abilities.Count);
    }
}