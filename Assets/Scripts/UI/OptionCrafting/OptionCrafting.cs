using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionCrafting : MonoBehaviour
{
    [SerializeField] private Button btnX;
    [SerializeField] private List<SlotInCraft> slotInBody;

    [SerializeField] private Button sourPlant;
    [SerializeField] private Button sweetPlant;
    [SerializeField] private Button bitterPlant;
    [SerializeField] private Button spicyPlant;
    [SerializeField] private Button saltyPlant;

    private Action Click_BtnX;

    private void Start()
    {
        sourPlant.onClick.AddListener((() =>
        {
            GameManager.i.Call_AddFromOptionCraft(ItemCraftID.NguViChua, LevelOfItem.One);
            UpdateSlot(GameManager.i.Bag);
        }));
        
        sweetPlant.onClick.AddListener((() =>
        {
            GameManager.i.Call_AddFromOptionCraft(ItemCraftID.NguViNgot, LevelOfItem.One);
            UpdateSlot(GameManager.i.Bag);
        }));
        
        bitterPlant.onClick.AddListener((() =>
        {
            GameManager.i.Call_AddFromOptionCraft(ItemCraftID.NguViDang, LevelOfItem.One);
            UpdateSlot(GameManager.i.Bag);
        }));
        
        spicyPlant.onClick.AddListener((() =>
        {
            GameManager.i.Call_AddFromOptionCraft(ItemCraftID.NguViCay, LevelOfItem.One);
            UpdateSlot(GameManager.i.Bag);
        }));
        
        saltyPlant.onClick.AddListener((() =>
        {
            GameManager.i.Call_AddFromOptionCraft(ItemCraftID.NguVuMan, LevelOfItem.One);
            UpdateSlot(GameManager.i.Bag);
        }));
        
    }

    public void Init(UIManager uiManager)
    {
        Click_BtnX += uiManager.TurnOffOption;
        Click_BtnX += () => { gameObject.SetActive(false); };
        btnX.onClick.AddListener(Click_BtnX.Invoke);
        gameObject.SetActive(false);
    }

    public void UpdateSlot(List<ItemCraftBase> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].ID == ItemCraftID.none)
            {
                slotInBody[i].Delete();
            }
            else
            {
                slotInBody[i].Init(list[i]);
            }
        }
    }
    
    public int CountSlotInBody => slotInBody.Count;
}
