using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private Tower playerTower;
    [SerializeField] private Tower enemyTower;

    private void Update()
    {
        ButtonControl();
    }

    private void ButtonControl()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SpawnByButton(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SpawnByButton(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SpawnByButton(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            SpawnByButton(3);
    }

    private void SpawnByButton(int index)
    {
        UnitInformation unitInfo = playerTower.GetUnitInformation(index);
        playerTower.SpawnUnit(unitInfo.prefab);        
    }

    #region 소환 TEST 코드
    [SerializeField] private GameObject debug_unitPrefab;

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
    #endregion
}
