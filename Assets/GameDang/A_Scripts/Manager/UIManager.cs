using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;
    
    private void OnEnable()
    {
        Player.OnGoldChange += OnGoldChange;
    }
    private void OnDisable()
    {
        Player.OnGoldChange -= OnGoldChange;
    }
    private void OnGoldChange(int gold)
    {
        goldText.text = gold.ToString() + " G";
    }

    public void OnSkillButtonClick()
    {
        TowerManager.PlayerTower.Skill();
    }
}
