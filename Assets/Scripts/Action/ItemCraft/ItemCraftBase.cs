using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_", menuName = "Item/Create New Item Of Craft")]
public class ItemCraftBase : ScriptableObject
{
    [SerializeField] private ItemCraftID id;
    [SerializeField] private Sprite img;
    [SerializeField] private LevelOfItem level;
    [SerializeField] private string description;
    [SerializeField] private int priceToSell;

    public ItemCraftBase(ItemCraftID id, LevelOfItem level)
    {
        this.id = id;
        this.level = level;
    }
    
    public ItemCraftID ID => id;
    public Sprite IMG => img;
    public LevelOfItem Level => level;
    public string Description => description;
    public int PriceToSell => priceToSell;
}

public enum ItemCraftID
{
    none,
    NguViChua,
    NguViNgot,
    NguViDang,
    NguViCay,
    NguVuMan
}

public enum LevelOfItem
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six
}
