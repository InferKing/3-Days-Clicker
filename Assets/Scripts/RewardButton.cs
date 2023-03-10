using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RewardButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    private Coroutine _cor;
    public void Clicked()
    {
        if (_cor != null) StopCoroutine(_cor);
        _cor = StartCoroutine(TempReward());
    }
    private IEnumerator TempReward()
    {
        _button.interactable = false;
        PlayerController.Multiplier = 5;
        yield return new WaitForSeconds(45f);
        PlayerController.Multiplier = 1;
        _button.interactable = true;
    }
}
