using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotOptionNhanVienHub : MonoBehaviour
{
    private NhanVien nhanVien;
    public Image imgAvatar;
    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtDescription;
    public TextMeshProUGUI txtPointService;

    public void Init(NhanVien nv, UIManager uiManager)
    {
        nhanVien = nv;
        
        imgAvatar.sprite = nhanVien.NVBase.Avatar;
        txtName.text = nhanVien.NVBase.Name;
        txtDescription.text = nhanVien.NVBase.Description;
        txtPointService.text = nhanVien.GetPointService().ToString();
        
        gameObject.GetComponent<Button>().onClick.AddListener(()=>uiManager.OnMoreInfoNV(nhanVien));
    }
}
