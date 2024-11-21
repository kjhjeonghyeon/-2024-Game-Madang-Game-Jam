using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 게임 시작 시간 (인 게임 진입 시점 부터 계산)
    /// </summary>
    public static float PlayTime = 0f;
    private void Update()
    {
        PlayTime += Time.deltaTime;
    }
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
