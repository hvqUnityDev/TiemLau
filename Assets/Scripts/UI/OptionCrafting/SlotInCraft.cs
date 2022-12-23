using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotInCraft : MonoBehaviour
{
    private Action<SlotInCraft> WhenClick;
    
    [SerializeField] private Image slot;
    private ItemCraftBase itemCraftBase;
    [SerializeField] private int indexInBag;
    private OptionCrafting OC;

    public void Init(ItemCraftBase itemCraftBase, int index, Action<SlotInCraft> whenClick, OptionCrafting OC)
    {
        gameObject.SetActive(true);
        AddAction(whenClick);
        this.OC = OC;
        this.itemCraftBase = itemCraftBase;
        indexInBag = index;
        slot.gameObject.SetActive(true);
        slot.sprite = this.itemCraftBase.IMG;

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((sprite) => WhenClick?.Invoke(this));
        
        gameObject.GetComponent<EventTrigger>().triggers.Add(entry); 
    }

    void AddAction(Action<SlotInCraft> whenClick)
    {
        WhenClick += whenClick;
        WhenClick += (SlotInCraft) =>
        {
            slot.gameObject.SetActive(false);
        };
    }

    public void TurnOff()
    {
        slot.gameObject.SetActive(false);
    }
    
    public ItemCraftBase ItemCraftBase => itemCraftBase;
    public int IndexInBag => indexInBag;
}
