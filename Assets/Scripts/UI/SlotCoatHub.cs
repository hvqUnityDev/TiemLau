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
    public MoreInfoNV MyDad;
    
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
        MyDad = myDad;
        Skin = skin;
        ImgCoat.sprite = Skin.Coat;
    }

    void WhenClick()
    {
        MyDad.ResetColorCoats();
        slotCoat.sprite = imgOn;
        MyDad.FullSkin.sprite = Skin.FullSkin;
        MyDad.PointServicePlus.text = Skin.PointSkin.ToString();
        MyDad.NameSkin.text = Skin.NameSkin;
        MyDad.TxtPrice.text = Skin.Price.ToString();

    }

    public void WhenNotClick()
    {
        slotCoat.sprite = imgOff;
    }

    public Image SlotCoat => slotCoat;
}
