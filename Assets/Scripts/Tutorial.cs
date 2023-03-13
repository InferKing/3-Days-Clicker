using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private GameObject _arrow;
    private List<string> _ruText = new List<string>()
    {
        "Привет!",
        "Нажми на кнопку позади меня!",
        "Видишь? Ты получил монеты!",
        "Сейчас нажми на меню и посмотри улучшения!",
        "Заработай как можно больше монет. Удачи!"
    };
    private List<string> _enText = new List<string>()
    { 
        "Hi!",
        "Press the coin behind me!",
        "See? You got added points!",
        "Now click on the menu and check out the improvements!",
        "Earn as many coins as possible. Good luck!"
    };

    private bool _invoked = false;

    private void OnEnable()
    {
        PlayerController.OnCountChanged += IsInvoked;
    }
    private void OnDisable()
    {
        PlayerController.OnCountChanged -= IsInvoked;
    }
    private void Start()
    {
        _gameObject.SetActive(false);
        if (SaveData.instance.info.items.Count == 0 && SaveData.instance.info.coins == 0) 
            StartCoroutine(StartTutorial());
    }
    private void IsInvoked(int x)
    {
        _invoked = true;
    }
    private IEnumerator StartTutorial()
    {
        _gameObject.SetActive(true);
        _text.text = Language.instance.currentLanguage == "ru" ? _ruText[0] : _enText[0];
        yield return new WaitForSeconds(2f);
        _invoked = false;
        yield return StartCoroutine(TypeMessage(Language.instance.currentLanguage == "ru" ? _ruText[1] : _enText[1]));
        yield return new WaitUntil(() => _invoked);
        _arrow.SetActive(true);
        yield return StartCoroutine(TypeMessage(Language.instance.currentLanguage == "ru" ? _ruText[2] : _enText[2]));
        yield return new WaitForSeconds(2f);
        _arrow.transform.Rotate(0, 0, 90);
        _arrow.transform.position = new Vector3(-0.5f, 1.4f, _arrow.transform.position.z);
        yield return StartCoroutine(TypeMessage(Language.instance.currentLanguage == "ru" ? _ruText[3] : _enText[3]));
        yield return new WaitUntil(() => _shop.IsMenuActive());
        _arrow.SetActive(false);
        _gameObject.SetActive(false);
        yield return new WaitUntil(() => !_shop.IsMenuActive());
        _gameObject.SetActive(true);
        yield return StartCoroutine(TypeMessage(Language.instance.currentLanguage == "ru" ? _ruText[4] : _enText[4]));
        yield return new WaitForSeconds(2f);
        _gameObject.SetActive(false);
    }
    private IEnumerator TypeMessage(string s)
    {
        _text.text = "";
        for (int i = 0; i < s.Length; i++)
        {
            _text.text += s[i];
            yield return new WaitForSeconds(0.04f);
        }
    }
}
