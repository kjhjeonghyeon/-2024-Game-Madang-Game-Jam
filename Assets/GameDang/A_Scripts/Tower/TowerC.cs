using System.Collections;
using UnityEngine;

public class TowerC : Tower
{
    public override float CoolTime => 5f;
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
