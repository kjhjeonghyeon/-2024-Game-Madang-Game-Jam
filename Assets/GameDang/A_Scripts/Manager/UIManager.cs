using UnityEngine;

public class UIManager : MonoBehaviour
{
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


    /// <summary>
    /// 플레이어가 데미지 입었을때
    /// </summary>
    private void PlayerHit(Tower tower, int damage)
    {
        Debug.Log("플레이어 데미지 입음 : " + damage + "\n 남은 채력" + tower.Helath);
    }

    /// <summary>
    /// 상대방이 데미지 입었을때
    /// </summary>    
    private void EnemeyHit(Tower tower, int damage)
    {
        Debug.Log("상대방 데미지 입음 : " + damage + "\n 남은 채력" + tower.Helath);
    }

    private void OnTowerHited(Tower tower, int damage)
    {
        if (TowerManager.PlayerTower == tower) {
            PlayerHit(tower, damage);
        } else {
            EnemeyHit(tower, damage);
        }
    }

    private void OnGoldChange(int gold)
    {
        // Debug.Log("골드 변경 됨 현재 골드 : " + gold);
    }
}
