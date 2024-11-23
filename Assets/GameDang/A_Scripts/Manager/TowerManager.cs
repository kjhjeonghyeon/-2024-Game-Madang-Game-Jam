using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private static int playerSelectTowerIndex = 3;
    public static int PlayerSelectTowerIndex
    {
        get { return playerSelectTowerIndex; }
        set { playerSelectTowerIndex = value; }
    }
    private static int enumyrSelectTowerIndex = -1;
    public static int EnumySelectTowerIndex
    {
        get { return enumyrSelectTowerIndex; }
        set { enumyrSelectTowerIndex = value; }
    }
    [SerializeField] private List<GameObject> towerPrefabs;
    [SerializeField] private Transform playerTowerPosition;
    [SerializeField] private Transform enemyTowerPosition;
    [SerializeField] private GameObject[] uIPlayer;
    [SerializeField] private GameObject[] uIEnumy;
    [SerializeField] private GameObject[] uIBackGround;
    private static HashSet<int> activeKeys = new HashSet<int>(){0,1,2,3};

    public static Tower PlayerTower { get; private set; }
    public static Tower EnemyTower { get; private set; }
    [SerializeField] private Player player;

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
        uIPlayer[playerSelectTowerIndex].SetActive(true);
        int enemyTowerIndex = GetRandomEnemeyTowerIndex();
        EnemyTower = SpawnTower(towerPrefabs[enemyTowerIndex], enemyTowerPosition);
        activeKeys.Remove(enemyTowerIndex);
        EnemyTower.GetComponentInChildren<SpriteRenderer>().flipX = true;
        uIBackGround[enemyTowerIndex].SetActive(true);
        uIEnumy[enemyTowerIndex].SetActive(true);
        enumyrSelectTowerIndex = enemyTowerIndex;
    }
}
