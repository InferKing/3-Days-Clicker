using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
public class PlayerController : MonoBehaviour
{
    public static Action<int> OnCountChanged;
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioSource _music;
    [SerializeField] private Animator _animator;
    [SerializeField] private Shop _shop;
    [SerializeField] private ParticleSystem _particleSystem;
    private int _count, _leg = 0;
    public static int Bonus { get; set; }
    public static int Multiplier { get; set; }
    private void Start()
    {
        _count = SaveData.instance.info.coins;
        _music.Play();
        Multiplier = 1;
        Bonus = 1 * Multiplier;
        for (int i = 1; i < SaveData.instance.info.items.Count; i += 2)
        {
            Bonus += SaveData.instance.info.items[i];
        }
        OnCountChanged?.Invoke(_count);
    }
    private void OnMouseDown()
    {
        if (_shop.IsMenuActive()) return;
        _leg += 1;
        _particleSystem.Play();
        m_AudioSource.Play();
        _animator.SetBool("Play", true);
        _count += Bonus * Multiplier;
        SaveData.instance.info.coins = _count;
        OnCountChanged?.Invoke(_count);
        SaveData.instance.Save();
    }
    private void OnMouseUp()
    {
        if (_shop.IsMenuActive()) return;
        _animator.SetBool("Play", false);
    }
    private void OnApplicationQuit()
    {
        SaveData.instance.Save();
    }
    public int GetCount() => _count; 
    public void DecreaseScore(int x)
    {
        _count -= x;
    }
}
