using System.Collections.Generic;
using UnityEngine;

public class TowerB : Tower
{
    public override float CoolTime => 5f;
    [SerializeField] private int count;
    Unit spawnedUnit;
    public override void Skill()
    {
        for (int i=0; i<count; i++)
        {
            List<Unit> units = TowerManager.EnemyTower.ActiveUnits;
            if (units.Count == 0) return;
            TakeUnit(units[Random.Range(0, units.Count)]);
            
        }
          
      
    }
    private void TakeUnit(Unit unit)
    {
        Unit spawnedUnit = SpawnUnit(unit);
        spawnedUnit.transform.position -= new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0);
        GameObject obj = Instantiate(EffectManager.Instance.GetEffect(EffectType.Sunshin), spawnedUnit.transform.position, Quaternion.identity);
        TowerManager.EnemyTower.ActiveUnits.Remove(unit);
        unit.gameObject.SetActive(false);        
        Destroy(unit.gameObject);
    }
}
