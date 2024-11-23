using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{

    [SerializeField] Slider[] hP;
    [SerializeField] Slider[] hPEnumy;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnEnable()
    {
        Tower.OnTowerHited += OnTowerHited;
        Player.OnGoldChange += OnGoldChange;
    }
    private void OnDisable()
    {
        Tower.OnTowerHited -= OnTowerHited;
        Player.OnGoldChange -= OnGoldChange;
    }


  
    private void PlayerHit(Tower tower, int damage)
    {
        hP[TowerManager.PlayerSelectTowerIndex].value = tower.Helath;
        Debug.Log("플레이어 데미지 입음 : " + damage + "\n 남은 채력" + tower.Helath);
    }

    private void EnemeyHit(Tower tower, int damage)
    {
        hPEnumy[TowerManager.EnumySelectTowerIndex].value = tower.Helath;
        Debug.Log("상대방 데미지 입음 : " + damage + "\n 남은 채력" + tower.Helath);
    }

    private void OnTowerHited(Tower tower, int damage)
    {
        if (TowerManager.PlayerTower == tower)
        {
            PlayerHit(tower, damage);
        }
        else
        {
            EnemeyHit(tower, damage);
        }
    }

    private void OnGoldChange(int gold)
    {
        // Debug.Log("골드 변경 됨 현재 골드 : " + gold);
    }

}
