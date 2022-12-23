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
    public List<Image> stars;

    [SerializeField] private Sprite imgStarTurnOn;
    public void Init(NhanVien nv, UIManager uiManager)
    {
        nhanVien = nv;

        Debug.Log("TODO: add current Skin");
        imgAvatar.sprite = nhanVien.NVBase.Avatar;
        txtName.text = nhanVien.NVBase.Name;
        txtDescription.text = nhanVien.NVBase.Description;
        txtPointService.text = nhanVien.GetPointService().ToString();
        
        for (int i = 0; i < nhanVien.Level ; i++)
        {
            stars[i].sprite = imgStarTurnOn;
        }
        gameObject.GetComponent<Button>().onClick.AddListener(()=>uiManager.OnMoreInfoNV(nhanVien));
    }
}
