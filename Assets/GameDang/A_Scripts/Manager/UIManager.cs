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
