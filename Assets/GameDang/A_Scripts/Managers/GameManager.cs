using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        Unit.OnSpawned += OnUnitSpawned;
    }
    private void OnDisable()
    {
        Unit.OnSpawned -= OnUnitSpawned;
    }    
    private void OnUnitSpawned(Unit unit)
    {
        Debug.Log("Unit 소환 감지...");
    }
}
