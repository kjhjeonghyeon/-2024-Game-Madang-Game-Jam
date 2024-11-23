using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private void OnEnable()
    {
        Tower.OnTowerDied += OnTowerDied;        
    }
    private void OnDisable()
    {
        Tower.OnTowerDied -= OnTowerDied;        
    }

    private void OnTowerDied(Tower tower)
    {
        Debug.Log("타워가 죽음");
    }
}
