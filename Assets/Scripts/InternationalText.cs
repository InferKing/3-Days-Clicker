using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InternationalText : MonoBehaviour
{
    [SerializeField] private string _ru;
    [SerializeField] private string _en;
    private TMP_Text _text;
    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }
    private void Start()
    {
        switch (Language.instance.currentLanguage)
        {
            case "en":
                _text.text = _en;
                break;
            case "ru":
                _text.text = _ru;
                break;
            default:
                _text.text = _en;
                break;
        }
    }
}
