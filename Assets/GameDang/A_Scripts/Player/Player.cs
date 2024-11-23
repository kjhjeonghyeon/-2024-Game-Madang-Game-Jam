using System;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    #region  Gold 관련
    public int gold;
    private float goldInterval = 1f;
    private int goldIntervalValue = 50;
    private float goldIntervalDelay = 0;
    #endregion
    protected virtual void Update()
    {
        UpdateGold();
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
    #region  Event
    public static event Action<int> OnGoldChange;
    #endregion
}