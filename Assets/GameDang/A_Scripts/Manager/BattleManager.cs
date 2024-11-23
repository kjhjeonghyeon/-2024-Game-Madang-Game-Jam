using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private UIResult uiResult;
    private void Start()
    {
        uiResult.panel.SetActive(false);
    }
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