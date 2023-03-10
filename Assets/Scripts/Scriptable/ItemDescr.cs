using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item Data", order = 51)]
public class ItemDescr : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private Color color;
    [SerializeField] private int price;
    [SerializeField] private int bonus;
    
    public Color Color
    {
        get 
        { 
            return color; 
        }
    }
    public int Bonus
    {
        get 
        { 
            return bonus; 
        }
    }
    public int Price
    {
        get
        {
            return price;
        }
    }
    public Sprite Sprite
    {
        get 
        { 
            return sprite; 
        }
    }
}
