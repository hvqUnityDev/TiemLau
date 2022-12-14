using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotOptionNhanVienHub : MonoBehaviour
{
    private NhanVien NVbase;
    public Image imgAvatar;
    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtDescription;
    public TextMeshProUGUI txtPointService;

    public void Init(NhanVien nv, UIManager uiManager)
    {
        NVbase = nv;
        
        imgAvatar.sprite = NVbase.Avatar;
        txtName.text = NVbase.Name;
        txtDescription.text = NVbase.Description;
        txtPointService.text = NVbase.PointService.ToString();
        
        gameObject.GetComponent<Button>().onClick.AddListener(()=>uiManager.OnMoreInfoNV(NVbase));
    }
}
