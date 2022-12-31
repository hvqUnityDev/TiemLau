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
    [SerializeField] private Image imgAvatar;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtDescription;
    [SerializeField] private TextMeshProUGUI txtPointService;
    [SerializeField] private List<Image> stars;

    [SerializeField] private Sprite imgStarTurnOn;
    public void Init(NhanVien nv, UIManager uiManager)
    {
        nhanVien = nv;

        Debug.Log("TODO: add current Skin");
        imgAvatar.sprite = nhanVien.ObjCurrentSkin.Avatar;
        txtName.text = nhanVien.NVBase.NameNv;
        txtDescription.text = nhanVien.NVBase.Description;
        txtPointService.text = nhanVien.GetPointService().ToString();
        
        for (int i = 0; i < nhanVien.Level ; i++)
        {
            stars[i].sprite = imgStarTurnOn;
        }
        gameObject.GetComponent<Button>().onClick.AddListener(()=>uiManager.OnMoreInfoNV(nhanVien));
    }
}
