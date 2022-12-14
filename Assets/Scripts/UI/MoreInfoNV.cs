using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoreInfoNV : MonoBehaviour
{
    public TextMeshProUGUI PointServicePlus;
    public TextMeshProUGUI Story;
    public TextMeshProUGUI NameSkin;
    public Image FullSkin;
    public TextMeshProUGUI TxtPrice;
    public List<SlotCoatHub> Coats = new List<SlotCoatHub>();
    [SerializeField] private TextMeshProUGUI Description;
    public TextMeshProUGUI txtLevelPointService;

    [SerializeField] private Transform contentCoat;
    [SerializeField] private SlotCoatHub slotCoat;
    [SerializeField] private Button btnX;
    

    private void Start()
    {
        btnX.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public void Init(NhanVien _nhanVien, UIManager uiManager)
    {
        Coats = new List<SlotCoatHub>();
        
        Story.text = _nhanVien.Story;
        FullSkin.sprite = _nhanVien.Skins[0].FullSkin;
        PointServicePlus.text = _nhanVien.Skins[0].PointSkin.ToString();
        NameSkin.text = _nhanVien.Skins[0].NameSkin;
        TxtPrice.text = _nhanVien.Skins[0].Price.ToString();
        Description.text = _nhanVien.Description;
        
        UpdateContentCoat(contentCoat, _nhanVien.Skins);
    }
    
    void UpdateContentCoat(Transform content, List<Skin> skins)
    {
        DeleteContent(content);
        foreach (var item in skins)
        {
            UpdateContent(content, item);
        }
    }

    void UpdateContent(Transform content, Skin skin)
    {
        var slot = Instantiate(slotCoat,content).GetComponent<SlotCoatHub>();
        //TODO: Data
        slot.Init(this, skin);
        Coats.Add(slot);
    }

    void DeleteContent(Transform content)
    {
        foreach (Transform item in content)
        {
            Destroy(item.gameObject);
        }
    }

    public void ResetColorCoats()
    {
        foreach (var item in Coats)
        {
            item.WhenNotClick();
        }
    }

    //public GameObject ContentCoat => contentCoat;
}
