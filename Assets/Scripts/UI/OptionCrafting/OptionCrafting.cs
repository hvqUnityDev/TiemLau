using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionCrafting : MonoBehaviour
{
    private Action<SlotInCraft> ClickSlot;
    private Action Click_BtnX;
    

    [Header("Header")] 
    [SerializeField] private Button btnX;
    [SerializeField] private TextMeshProUGUI txtTheLuc;
    [SerializeField] private TextMeshProUGUI txtDiamond;
    [SerializeField] private TextMeshProUGUI txtMoney;
    
    [Header("Plant")]
    [SerializeField] private Button sourPlant;
    [SerializeField] private Button sweetPlant;
    [SerializeField] private Button bitterPlant;
    [SerializeField] private Button spicyPlant;
    [SerializeField] private Button saltyPlant;
    
    [Header("Body")]
    [SerializeField] private List<SlotInCraft> slotInBody;
    [SerializeField] private CurrentItem currentItem;
    [SerializeField] private float min = 2;
    
    private Transform currentPos;

    private void Start()
    {
        // currentItem.gameObject.SetActive(false);
        // ClickSlot += SetValue_OfCurrentItem;
        // sourPlant.onClick.AddListener((() =>
        // {
        //     GameManager.i.Call_AddFromOptionCraft(ItemCraftID.NguViChua, LevelOfItem.One);
        //     UpdateSlot(GameManager.i.Bag);
        // }));
        //
        // sweetPlant.onClick.AddListener((() =>
        // {
        //     GameManager.i.Call_AddFromOptionCraft(ItemCraftID.NguViNgot, LevelOfItem.One);
        //     UpdateSlot(GameManager.i.Bag);
        // }));
        //
        // bitterPlant.onClick.AddListener((() =>
        // {
        //     GameManager.i.Call_AddFromOptionCraft(ItemCraftID.NguViDang, LevelOfItem.One);
        //     UpdateSlot(GameManager.i.Bag);
        // }));
        //
        // spicyPlant.onClick.AddListener((() =>
        // {
        //     GameManager.i.Call_AddFromOptionCraft(ItemCraftID.NguViCay, LevelOfItem.One);
        //     UpdateSlot(GameManager.i.Bag);
        // }));
        //
        // saltyPlant.onClick.AddListener((() =>
        // {
        //     GameManager.i.Call_AddFromOptionCraft(ItemCraftID.NguVuMan, LevelOfItem.One);
        //     UpdateSlot(GameManager.i.Bag);
        // }));
        
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
        UpdateHeader();
        for (int i = 0; i < list.Count; i++)
        {
            slotInBody[i].Init(list[i], i, ClickSlot, this);
            if (list[i].ID == ItemCraftID.none)
            {
                slotInBody[i].TurnOff();
            }
        }
    }

    public void SetValue_OfCurrentItem(SlotInCraft slotInCraft)
    {
        currentItem.gameObject.SetActive(true);
        currentItem.SetValue(slotInCraft, this);
    }

    private void UpdateHeader()
    {
        txtTheLuc.text = GameManager.i.DTheLuc.ToString();
        txtDiamond.text = GameManager.i.DDiamond.ToString();
        txtMoney.text = GameManager.i.DMoney.ToString();
    }

    public void SetTrans(SlotInCraft slotInCraft)
    {
        int pos = -1;
        float minTemp = min;
        Debug.Log("TODO: Set trans");
        for(int i = 0; i < slotInBody.Count ; i++)
        {
            Debug.Log("TODO: distance");
            if (Vector3.Distance(slotInCraft.gameObject.transform.position, slotInBody[i].transform.position) < minTemp)
            {
                Debug.Log($"{slotInCraft.IndexInBag} - {slotInBody[i].IndexInBag}");
                pos = i;
                minTemp = Vector3.Distance(slotInCraft.gameObject.transform.position, slotInBody[i].transform.position);
            }
        }

        //GameManager.i.ChangeInBag(slotInCraft.IndexInBag, pos);
    }

    public int CountSlotInBody => slotInBody.Count;

}
