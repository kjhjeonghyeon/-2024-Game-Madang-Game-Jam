using System.Collections;
using UnityEngine;

public class TowerD : Tower
{
    private float coolTime = 10f;
    public override float CoolTime 
    {
        get => coolTime;
        set => coolTime= value;
    }
    public static float SpeedUpValue = 1f;
    [SerializeField] private float Time;
    [Tooltip("배속 임.. 2배속 이런식으로")]
    [SerializeField] private float Value;
    public override void Skill()
    {   
        foreach (Unit unit in TowerManager.PlayerTower.ActiveUnits)
        {
            GameObject obj = Instantiate(EffectManager.Instance.GetEffect(EffectType.Move));
            obj.transform.position = unit.transform.position;            
        }
        StartCoroutine(Run());
    }
    private IEnumerator Run()
    {
        SpeedUpValue = Value;
        yield return new WaitForSeconds(Time);
        SpeedUpValue = 1f;
    }
}

