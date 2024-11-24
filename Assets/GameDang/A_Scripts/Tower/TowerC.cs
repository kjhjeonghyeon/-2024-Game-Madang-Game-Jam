using System.Collections;
using UnityEngine;

public class TowerC : Tower
{
    private float coolTime = 15f;
    public override float CoolTime 
    {
        get => coolTime;
        set => coolTime= value;
    }
    public static bool IsInvincibility = false;
    [SerializeField] private float Time;
    public override void Skill()
    {
        foreach (Unit unit in TowerManager.PlayerTower.ActiveUnits)
        {
            GameObject obj = Instantiate(EffectManager.Instance.GetEffect(EffectType.FireWindow));
            obj.transform.position = unit.transform.position;            
        }
        StartCoroutine(Run());
    }

    private IEnumerator Run() {
        IsInvincibility = true;
        yield return new WaitForSeconds(Time);
        IsInvincibility = false;
    }
    
}
