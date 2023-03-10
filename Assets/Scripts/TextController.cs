using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextController : MonoBehaviour
{
    [SerializeField] private MoneyText[] _textsMoney;
    [SerializeField] private TMP_Text m_Text;
    private void OnEnable()
    {
        PlayerController.OnCountChanged += UpdateText;
    }
    private void OnDisable()
    {
        PlayerController.OnCountChanged -= UpdateText;
    }

    private void UpdateText(int count)
    {
        m_Text.text = count.ToString();
        foreach (var text in _textsMoney)
        {
            if (!text.isEnabled)
            {
                text.ShowAnim("+" + (PlayerController.Bonus * PlayerController.Multiplier).ToString());
                return;
            }
        }
    }
}
