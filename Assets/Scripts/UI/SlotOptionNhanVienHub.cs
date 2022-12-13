using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotOptionNhanVienHub : MonoBehaviour
{
    public NhanVien NVbase;
    public Image imgAvatar;
    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtDescription;
    public TextMeshProUGUI txtPointService;

    public void Init(NhanVien nv)
    {
        NVbase = nv;
        
        imgAvatar.sprite = NVbase.Avatar;
        txtName.text = NVbase.Name;
        txtDescription.text = NVbase.Description;
        txtPointService.text = NVbase.PointService.ToString();
        
        AddEventTrigger(gameObject);
    }

    void AddEventTrigger(GameObject GO)
    {
        if (GO.GetComponent<EventTrigger>() == null)
        {
            GO.AddComponent<EventTrigger>();
        }

        EventTrigger eventTrigger = GO.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((func) => { UIManager.i.OnMoreInfoNV(NVbase); });
        
        eventTrigger.triggers.Add(entry);
    }
    
    
}
