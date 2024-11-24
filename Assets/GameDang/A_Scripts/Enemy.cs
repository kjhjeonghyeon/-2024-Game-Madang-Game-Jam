using UnityEngine;

public class Enemy
{
    private Tower tower;
    private float minSpawnDelay;
    private float maxSpawnDelay;
    private float delay;
    public Enemy(Tower tower, EnemyOption option)
    {
        this.tower = tower;
        minSpawnDelay = option.minSpawnDelay;
        maxSpawnDelay = option.maxSpawnDelay;
        delay = 0;
    }
    public void Update()
    {
        if (delay <= 0) {
            Spawn();
            
            delay = Random.Range(minSpawnDelay, maxSpawnDelay);
        }
        delay -= Time.deltaTime;             
    }
    private void Spawn()
    {
        UnitInformation unit = tower.GetUnitInformation(Random.Range(0, 4));
        tower.SpawnUnit(unit.prefab);


    }
}
