using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInCraft : MonoBehaviour
{
    public Image slot;
    public ItemCraftBase ItemCraftBase;

    public void Init(ItemCraftBase ItemCraftBase)
    {
        this.ItemCraftBase = ItemCraftBase;
        slot.gameObject.SetActive(true);
        slot.sprite = this.ItemCraftBase.IMG;
    }

    public void Delete()
    {
        this.ItemCraftBase = null;
        slot.gameObject.SetActive(false);
    }
}
