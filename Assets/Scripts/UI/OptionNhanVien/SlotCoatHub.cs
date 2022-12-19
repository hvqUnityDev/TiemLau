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
        moreInfoNV.UpdateInfoSkin(Skin);
        slotCoat.sprite = imgOn;
    }

    public void WhenNotClick()
    {
        slotCoat.sprite = imgOff;
    }

    public Image SlotCoat => slotCoat;
}
