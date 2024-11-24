using System.Collections.Generic;
using UnityEngine;

public class TowerA : Tower
{
    public override float CoolTime => 5f;
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
