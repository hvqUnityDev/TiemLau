using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCraftDB
{
    public static void Init()
    {
        foreach (var kvp in ItemsCraft)
        {
            var itemsCraftID = kvp.Key;
            var itemsCraftValue = kvp.Value;
            itemsCraftID = itemsCraftValue.ID;
        }
    }
    
    public static Dictionary<ItemCraftID, IItemCraft> ItemsCraft { get; set; } 
        = new Dictionary<ItemCraftID, IItemCraft>()
        {
            {
                ItemCraftID.NguViChua,
                new IItemCraft()
                {
                    Name = "NguVi-Chua"
                }
            },
            {
                ItemCraftID.NguViNgot,
                new IItemCraft()
                {
                    Name = "NguVi-Ngot"
                }
            },
            {
                ItemCraftID.NguViDang,
                new IItemCraft()
                {
                    Name = "NguVi-Dang"
                }
            },
            {
                ItemCraftID.NguViCay,
                new IItemCraft()
                {
                    Name = "NguVi-Cay"
                }
            },
            {
                ItemCraftID.NguVuMan,
                new IItemCraft()
                {
                    Name = "NguVi-Man"
                }
            }
        };
}


