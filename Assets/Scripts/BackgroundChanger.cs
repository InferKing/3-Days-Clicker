using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private SpriteRenderer _foreground;

    private void OnEnable()
    {
        Shop.OnBuyHappened += ChangeBackground;
    }
    private void OnDisable()
    {
        Shop.OnBuyHappened -= ChangeBackground;
    }
    private void ChangeBackground(ItemDescr item)
    {
        _background.color = item.Color;
        _foreground.sprite = item.Sprite;
    }
}
