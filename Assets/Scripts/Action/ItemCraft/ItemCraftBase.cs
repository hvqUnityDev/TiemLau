using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_", menuName = "Item/Create New Item Of Craft")]
public class ItemCraftBase : ScriptableObject
{
    [SerializeField] private ItemCraftID id;
    [SerializeField] private Sprite img;
    [SerializeField] private LevelOfItem level;
    [SerializeField] private string description;
    [SerializeField] private int priceToSell;

    
    public ItemCraftID ID => id;
    public Sprite IMG => img;
    public LevelOfItem Level => level;
    public string Description => description;
    public int PriceToSell => priceToSell;

    public LevelOfItem NextLevel =>
        level == LevelOfItem.One ? LevelOfItem.Two
        : level == LevelOfItem.Two ? LevelOfItem.Three
        : level == LevelOfItem.Three ? LevelOfItem.Four
        : level == LevelOfItem.Four ? LevelOfItem.Five
        : level == LevelOfItem.Five ? LevelOfItem.Six : LevelOfItem.none;
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
    none,
    One,
    Two,
    Three,
    Four,
    Five,
    Six
}
