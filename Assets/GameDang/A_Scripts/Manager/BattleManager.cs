using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private UIResult uiResult;
    private List<Ability> abilities = new List<Ability>();
    private void Start()
    {
        uiResult.panel.SetActive(false);
        abilities = Ability.GetEnableAbilitys();
    }
    private void OnEnable()
    {
        Tower.OnTowerDied += OnTowerDied;
        foreach (Ability ability in abilities) {
            ability.Enable();
        }
    }
    private void OnDisable()
    {
        Tower.OnTowerDied -= OnTowerDied;        
        foreach (Ability ability in abilities) {
            ability.Disable();
        }
    }

    private void OnTowerDied(Tower tower)
    {
        Time.timeScale = 0;
        uiResult.panel.SetActive(true);
        if (tower == TowerManager.PlayerTower)
            Lose();
        else
            Win();        
    }
    private void Lose()
    {
        uiResult.statusText.text = "패배";
        UnityAction callback = () => { ButtonAction(LoseAction); };
        uiResult.actionButton.onClick.AddListener(callback);
    }
    private void ButtonAction(Action action)
    {
        Time.timeScale = 1;
        action?.Invoke();
    }
    private void LoseAction()
    {
        SceneManager.LoadScene("Title");
    }

    private void Win()
    {
        uiResult.statusText.text = "승리";
        UnityAction callback = () => { ButtonAction(WinAction); };
        uiResult.actionButton.onClick.AddListener(callback);
    }

    private void WinAction()
    {
        SceneManager.LoadScene("Upgrad");
    }
}
[System.Serializable]
public struct UIResult
{

    public GameObject panel;
    public TMP_Text statusText;
    public Button actionButton;
}