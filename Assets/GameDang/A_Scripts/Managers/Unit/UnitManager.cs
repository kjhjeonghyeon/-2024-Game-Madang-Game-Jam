using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private GameObject debug_unitPrefab;
    [SerializeField] private Tower playerTower;

    [ContextMenu("Player Tower Unit Spawn")]
    public void Debug_SpawnUnit()
    {
        playerTower.SpawnUnit(debug_unitPrefab);
    }
}
