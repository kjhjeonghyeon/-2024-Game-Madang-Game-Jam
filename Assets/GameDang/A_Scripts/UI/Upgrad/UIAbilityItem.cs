using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIAbilityItem : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text subjectText;
    [SerializeField] private TMP_Text contentText;
    [SerializeField] private Button button;
    private string code;
    
    public void SetAbilityItemData(AbilityItemData data, string code)
    {
        iconImage.sprite = data.iconSprite;
        subjectText.text = data.subject;
        contentText.text = data.content;
        this.code = code;
        button.onClick.AddListener(ClickAction);
    }
    private void ClickAction()
    {
        Debug.Log(code);
    }
}
