using System.Collections.Generic;
using UnityEngine;

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
    public GameObject GetEffect(int index)
    {
        return effects[index];
    }
}
