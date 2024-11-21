using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private GameObject debug_unitPrefab;
    [SerializeField] private Tower playerTower;
    [SerializeField] private Tower enemyTower;

    [ContextMenu("Player Tower Unit Spawn")]
    public void Debug_SpawnUnit()
    {
        playerTower.SpawnUnit(debug_unitPrefab);
    }

    [ContextMenu("Enemy Unit Spawn")]
    public void Debug_SpawnEnemy()
    {
        enemyTower.SpawnUnit(debug_unitPrefab);
    }
}
