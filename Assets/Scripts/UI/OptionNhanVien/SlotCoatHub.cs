using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SlotCoatHub : MonoBehaviour
{
    [SerializeField] private Image slotBG;
    [SerializeField] private Image imgCoat;
    [SerializeField] private Button btnCoat;
    [SerializeField] private Sprite imgOn;
    [SerializeField] private Sprite imgOff;
    
    private NhanVien _nhanVien;
    private Skin skin;
    private MoreInfoNV moreInfoNV;

    private void Start()
    {
        TurnOffImg();
        btnCoat.onClick.AddListener(WhenClick);
    }

    public void Init(MoreInfoNV myDad, NhanVien nhanVien, Skin skin)
    {
        moreInfoNV = myDad;
        _nhanVien = nhanVien;
        this.skin = skin;
        imgCoat.sprite = skin.Coat;
        
        if(nhanVien.ObjCurrentSkin == skin) WhenClick();
    }

    private void WhenClick()
    {
        moreInfoNV.UpdateInfoSkin(_nhanVien, skin);
        
        TurnOnImg();
    }

    public void TurnOffImg()
    {
        slotBG.sprite = imgOff;
    }

    public void TurnOnImg()
    {
        slotBG.sprite = imgOn;
    }
    
}
