using UnityEngine;
using UnityEngine.Assertions;

public class UnitManager : MonoBehaviour
{
    private void Update()
    {
        ButtonControl();
    }
    
    // 디버깅용 의미 없는 함수 GUI 대신에 키패드를 누르개 만들었을 뿐임
    private void ButtonControl()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SpawnByIndex(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SpawnByIndex(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SpawnByIndex(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            SpawnByIndex(3);
        if (Input.GetKeyDown(KeyCode.Space))
            Debug_SpawnEnemy();
    }

    // 이 함수 호출하면 Unit 이 소환됨 index 는 현재 0 ~ 3 구간임 벗어나면 오류
    // 이 함수를 GUI랑 잘연결하면됨.
    public void SpawnByIndex(int index)
    {
        Tower playerTower = TowerManager.PlayerTower;
        UnitInformation unitInfo = playerTower.GetUnitInformation(index);
        playerTower.SpawnUnit(unitInfo.prefab);
    }

    #region 소환 TEST 코드
    [SerializeField] private Unit debug_unitPrefab;

    [ContextMenu("Player Tower Unit Spawn")]
    public void Debug_SpawnUnit()
    {
        TowerManager.PlayerTower.SpawnUnit(debug_unitPrefab);
    }

    [ContextMenu("Enemy Unit Spawn")]
    public void Debug_SpawnEnemy()
    {
        Assert.IsNotNull(debug_unitPrefab);
        TowerManager.EnemyTower.SpawnUnit(debug_unitPrefab);
    }
    #endregion
}
