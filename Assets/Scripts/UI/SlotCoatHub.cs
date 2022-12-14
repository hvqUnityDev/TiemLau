using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SlotCoatHub : MonoBehaviour
{
    public Image ImgCoat;
    public Skin Skin;
    private MoreInfoNV moreInfoNV;
    
    [SerializeField] private Image slotCoat;
    [SerializeField] private Button btnCoat;
    [SerializeField] private Sprite imgOn;
    [SerializeField] private Sprite imgOff;

    private void Start()
    {
        WhenNotClick();
        btnCoat.onClick.AddListener(WhenClick);
    }

    public void Init(MoreInfoNV myDad, Skin skin)
    {
        moreInfoNV = myDad;
        Skin = skin;
        ImgCoat.sprite = Skin.Coat;
    }

    public void WhenClick()
    {
        slotCoat.sprite = imgOn;
        
        moreInfoNV.ResetColorCoats();
        moreInfoNV.FullSkin.sprite = Skin.FullSkin;
        moreInfoNV.PointServicePlus.text = Skin.PointSkin.ToString();
        moreInfoNV.NameSkin.text = Skin.NameSkin;
        moreInfoNV.TxtPrice.text = Skin.Price.ToString();
        
        
    }

    public void WhenNotClick()
    {
        slotCoat.sprite = imgOff;
    }

    public Image SlotCoat => slotCoat;
}
