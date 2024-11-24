using System.Collections.Generic;
using UnityEngine;

public class TowerA : Tower
{
    private float coolTime = 5f;
    public override float CoolTime 
    {
        get => coolTime;
        set => coolTime= value;
    }
    [SerializeField] private int skillDamage;
    // 전체 대미지
    public override void Skill()
    {
        List<Unit> units = new List<Unit>(TowerManager.EnemyTower.ActiveUnits);
        foreach (Unit unit in units) {
            GameObject obj = Instantiate(EffectManager.Instance.GetEffect(EffectType.Fire));
            obj.transform.position = unit.transform.position;
            unit.Hit(skillDamage);
        }
    }
}
