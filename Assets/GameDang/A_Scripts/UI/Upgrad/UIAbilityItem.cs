using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIAbilityItem : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text subjectText;
    [SerializeField] private TMP_Text contentText;
    
    public void SetAbilityItemData(AbilityItemData data)
    {
        iconImage.sprite = data.iconSprite;
        subjectText.text = data.subject;
        contentText.text = data.content;
    }
}
