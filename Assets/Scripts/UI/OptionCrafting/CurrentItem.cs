using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CurrentItem : MonoBehaviour
{

    [SerializeField] private Image img;
    private OptionCrafting OC;
    private SlotInCraft slotInCraft;
    private void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
        if (Input.GetMouseButtonUp(0))
        {
            MouseUp();
        }
    }

    public void SetValue(SlotInCraft slotInCraft, OptionCrafting OC)
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
        this.slotInCraft = slotInCraft;
        this.OC = OC;
        img.sprite = slotInCraft.ItemCraftBase.IMG;
    }

    private void MouseUp()
    {
        gameObject.SetActive(false);   
        OC.SetTrans(slotInCraft);
    }

}
