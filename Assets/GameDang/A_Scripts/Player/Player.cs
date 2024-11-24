using System;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    #region  Gold 관련
    public static int gold;
    [Header("수급 주기")]
    [SerializeField] private float goldInterval = 1f;
    [Header("수급 량")]
    [SerializeField]  private int goldIntervalValue = 50;
    private float goldIntervalDelay = 0;
    #endregion
    protected virtual void Update()
    {
        UpdateGold();
    }
    private void OnEnable()
    {
        Unit.OnDied += OnUnitDied;
    }
    private void OnDisable()
    {
        gold = 0;
        Unit.OnDied -= OnUnitDied;
    }
    private void OnUnitDied(Unit unit)
    {
        if (!unit.IsMine)
        {
            Debug.Log("재화 수급 : " + unit.GiftGold);
            SetGold(gold + unit.GiftGold);
        }
    }
    private void UpdateGold()
    {
        if (goldIntervalDelay <= 0) {
            MakeGold();            
            goldIntervalDelay = goldInterval;
        }
        goldIntervalDelay -= Time.deltaTime;
    }
    private void MakeGold()
    {
        gold += goldIntervalValue + GoldAbility.BounsGold;
        OnGoldChange?.Invoke(gold);
    }
    public static void SetGold(int gold)
    {
        Player.gold = gold;
        OnGoldChange?.Invoke(gold);        
    }
    #region  Event
    public static event Action<int> OnGoldChange;
    #endregion
}