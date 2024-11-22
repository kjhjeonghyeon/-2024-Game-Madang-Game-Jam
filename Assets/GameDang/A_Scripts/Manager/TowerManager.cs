using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private static int playerSelectTowerIndex = 0;
    public static int PlayerSelectTowerIndex
    {
        get { return playerSelectTowerIndex; }
        set { playerSelectTowerIndex = value; }
    }    
    [SerializeField] private List<GameObject> towerPrefabs;
    [SerializeField] private Transform playerTowerPosition;
    [SerializeField] private Transform enemyTowerPosition;
    private HashSet<int> activeKeys = new HashSet<int>(){0,1,2,3};
    public static Tower PlayerTower { get; private set; }
    public static Tower EnemyTower { get; private set; }

    private void Awake()
    {
        InitTowers();
    }

    private Tower SpawnTower(GameObject prefab, Transform location)
    {
        GameObject created = Instantiate(prefab);
        Tower tower = created.GetComponent<Tower>();
        if (!tower)
            throw new System.Exception("["+prefab.name+"] Tower Component가 없습니다.");
        tower.transform.position = location.position;
        return tower;
    }

    private int GetRandomEnemeyTowerIndex()
    {
        List<int> list = activeKeys.ToList();
        return list[Random.Range(0, list.Count)];
    }

    // Tower 를 생성하고 배치하는것
    private void InitTowers()
    {
        PlayerTower = SpawnTower(towerPrefabs[playerSelectTowerIndex], playerTowerPosition);
        activeKeys.Remove(playerSelectTowerIndex);
        int enemyTowerIndex = GetRandomEnemeyTowerIndex();
        EnemyTower = SpawnTower(towerPrefabs[enemyTowerIndex], enemyTowerPosition);
        activeKeys.Remove(enemyTowerIndex);
    }
}
