using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UnitManager : MonoBehaviour
{

    [SerializeField]

    private void Update()
    {
        ButtonControl();
    }

    // 디버깅용 의미 없는 함수 GUI 대신에 키패드를 누르개 만들었을 뿐임
    private void ButtonControl()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            SpawnEnemyByIndex(0);
        if (Input.GetKeyDown(KeyCode.W))
            SpawnEnemyByIndex(1);
        if (Input.GetKeyDown(KeyCode.E))
            SpawnEnemyByIndex(2);
        if (Input.GetKeyDown(KeyCode.R))
            SpawnEnemyByIndex(3);
    }

    // 이 함수 호출하면 Unit 이 소환됨 index 는 현재 0 ~ 3 구간임 벗어나면 오류
    // 이 함수를 GUI랑 잘연결하면됨.
    public void SpawnByIndex(int index, Image bw)
    {
        Tower playerTower = TowerManager.PlayerTower;
        UnitInformation unitInfo = playerTower.GetUnitInformation(index);
        if (unitIsSpawn[index] && Player.gold - unitInfo.cost >= 0) {
            Player.SetGold(Player.gold - unitInfo.cost);
            playerTower.SpawnUnit(unitInfo.prefab);
            StartCoroutine(RunUnitCoolTime(unitInfo.spawnDealy, bw, index));
        }        
    }
    private IEnumerator RunUnitCoolTime(float time, Image bw, int index)
    {
        bw.fillAmount = 1;
        float delay = time;
        unitIsSpawn[index] = false;
        while (delay > 0) {
            delay -= Time.fixedDeltaTime;
            bw.fillAmount = (delay / time);
            yield return new WaitForFixedUpdate();
        }
        unitIsSpawn[index] = true;
        yield break;
    }

    public void SpawnEnemyByIndex(int index)
    {
        Tower tower = TowerManager.EnemyTower;
        UnitInformation unitInfo = tower.GetUnitInformation(index);
        tower.SpawnUnit(unitInfo.prefab);
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


    private bool[] unitIsSpawn = {true, true, true, true};
    private void SpawnService(Image bw, int index)
    {
        SpawnByIndex(index, bw);
    }
    public void Unit_1(Image bw)
    {
        SpawnService(bw, 0);
    }
    public void Unit_2(Image bw)
    {
        SpawnService(bw, 1);
    }
    public void Unit_3(Image bw)
    {
        SpawnService(bw, 2);
    }
    public void Unit_4(Image bw)
    {
        SpawnService(bw, 3);
    }


}
