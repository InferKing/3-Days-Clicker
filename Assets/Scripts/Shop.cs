using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
public class Shop : MonoBehaviour
{
    public static Action<ItemDescr> OnBuyHappened;
    [SerializeField] private ButtonController _buttonController;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _panel;
    [SerializeField] private AudioSource _friendsAudio;
    [SerializeField] private List<ItemDescr> _items;
    private List<int> _list;
    private void Start()
    {
        _list = new List<int>();
    }
    public void ShowMenu()
    {
        _panel.SetActive(!_panel.activeSelf);
    }
    public bool IsMenuActive() => _panel.activeSelf;
    public void BuyItem(ItemDescr item)
    {
        if (_playerController.GetCount() >= item.Price)
        {
            _friendsAudio.Play();
            _buttonController.PlayAnimFriends();
            _buttonController.DisableButton(item);
            _playerController.DecreaseScore(item.Price);
            _list.Add(item.Price);
            _list.Add(item.Bonus);
            SaveData.instance.info.items = _list;
            PlayerController.Bonus += item.Bonus;
            PlayerController.OnCountChanged?.Invoke(_playerController.GetCount());
            OnBuyHappened?.Invoke(item);
            SaveData.instance.Save();
            StartCoroutine(Delay("Play", false, _buttonController.GetAnimatorFriends()));
        }
        else
        {
            _buttonController.PlayAnimScore();
            StartCoroutine(Delay("Play", false, _buttonController.GetAnimatorScore()));
        }
    }
    private IEnumerator Delay(string param, bool b, Animator anim)
    {
        yield return new WaitForSeconds(Time.deltaTime);
        anim.SetBool(param, b);
    }
}
