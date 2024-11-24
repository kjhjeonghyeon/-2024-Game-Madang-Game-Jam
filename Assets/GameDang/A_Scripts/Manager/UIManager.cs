using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private Image timeImage;
    [SerializeField] private Button timeActionButton;
    [SerializeField] private Sprite startSprite;
    [SerializeField] private Sprite puaseSprite;

    private float time;
    private bool IsPlaying;
    private void Start()
    {
        timeImage.sprite = puaseSprite;
        IsPlaying = true;
    }
    public static string FormatTime(float time)
    {
        int totalSeconds = Mathf.FloorToInt(time);
        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;

        return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }
    private void OnEnable()
    {
        Player.OnGoldChange += OnGoldChange;
        timeActionButton.onClick.AddListener(TimeAction);
    }
    private void TimeAction()
    {
        if (IsPlaying) {
            timeImage.sprite = startSprite;
            Time.timeScale = 0;
        } else {
            timeImage.sprite = puaseSprite;
            Time.timeScale = 1;
        }
        IsPlaying = !IsPlaying;
    }
    private void OnDisable()
    {
        Player.OnGoldChange -= OnGoldChange;
        timeActionButton.onClick.RemoveAllListeners();
    }
    private void OnGoldChange(int gold)
    {
        goldText.text = gold.ToString() + " G";
    }
    private void Update()
    {
        time += UnityEngine.Time.deltaTime;
        timeText.text = FormatTime(time);
    }

    public void OnSkillButtonClick(Image bw)
    {
        if (!TowerManager.PlayerTower.IsSkillUseAble) return;
        TowerManager.PlayerTower.Skill();        
        RunSkillCoolTime(bw, TowerManager.PlayerTower.CoolTime);
    }
    private void RunSkillCoolTime(Image bw, float time)
    {
        bw.fillAmount = 1;
        StartCoroutine(SkillCoolTimeCoroutine(bw, time));
    }
    private IEnumerator<WaitForFixedUpdate> SkillCoolTimeCoroutine(Image bw, float time)
    {
        float delay = time;
        TowerManager.PlayerTower.IsSkillUseAble = false;
        while (delay >= 0) {
            delay -= Time.fixedDeltaTime;
            bw.fillAmount = delay / time;
            yield return new WaitForFixedUpdate();
        }
        TowerManager.PlayerTower.IsSkillUseAble = true;
        yield break;
    }
}
