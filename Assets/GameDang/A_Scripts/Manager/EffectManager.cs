using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    Fire = 0,
    Sunshin = 1,
    FireWindow = 2,
    Move=3,
}
public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance
    {
        get => instance;
        set => instance = value;
    }
    private static EffectManager instance;

    [SerializeField] private List<GameObject> effects;
    private void Awake()
    {
        instance = this;
    }
    public GameObject GetEffect(EffectType type)
    {
        return effects[(int)type];
    }
}
