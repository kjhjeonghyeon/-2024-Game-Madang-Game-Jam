using System.Collections;
using UnityEngine;

public class TowerC : Tower
{
    private float coolTime = 5f;
    public override float CoolTime 
    {
        get => coolTime;
        set => coolTime= value;
    }
    public static bool IsInvincibility = false;
    [SerializeField] private float Time;
    public override void Skill()
    {
        StartCoroutine(Run());
    }

    private IEnumerator Run() {
        IsInvincibility = true;
        yield return new WaitForSeconds(Time);
        IsInvincibility = false;
    }
    
}
