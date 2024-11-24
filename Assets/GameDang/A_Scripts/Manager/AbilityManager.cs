using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AbilityItem = System.Tuple<string, Ability>;

public class AbilityManager : MonoBehaviour
{
    #region  UI
    [SerializeField] private UIAbility uiAbility;
    #endregion
    [SerializeField] private int count;
    private List<AbilityItem> abilityItems;
    private void Awake()
    {
        abilityItems = new List<AbilityItem>();        
    }
    private void OnEnable()
    {
        List<string> keys = new List<string>(Ability.GetSelectAbleAbilitys());
        for (int i=0; i<count; i++) 
        {
            if (keys.Count > 0)
            {
                string key = keys[UnityEngine.Random.Range(0, keys.Count)];
                Tuple<bool, Ability> item = Ability.abilityMap[key];
                abilityItems.Add(Tuple.Create<string, Ability>(key, item.Item2));
                keys.Remove(key);
            }
        }
    }

    private void Start()
    {
        foreach (AbilityItem item in abilityItems)
        {
            GameObject created = Instantiate(uiAbility.Prefab, uiAbility.AbilityGroup.transform);
        }
    }
}

[System.Serializable]
public struct UIAbility
{
    [SerializeField] private GameObject abilityGroup;
    [SerializeField] private GameObject prefab;
    public GameObject AbilityGroup { get { return abilityGroup; } }
    public GameObject Prefab { get { return prefab; } }

}