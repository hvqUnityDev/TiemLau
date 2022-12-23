using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoreInfoNV : MonoBehaviour
{
    [SerializeField] private Button btnX;
    
    [Header("Part01")]
    [SerializeField] private TextMeshProUGUI PointServicePlus;
    [SerializeField] private TextMeshProUGUI Story;
    [SerializeField] private TextMeshProUGUI NameSkin;
    [SerializeField] private Image imgFullSkin;
    [SerializeField] private Button btnChange;
    [SerializeField] private Button btnBuy;
    [SerializeField] private TextMeshProUGUI txtPrice;
    [SerializeField] private TextMeshProUGUI txtConditionSkin;

    [Header("Part02")]
    [SerializeField] private List<SlotCoatHub> Coats = new List<SlotCoatHub>();
    [SerializeField] private Transform contentCoat;
    [SerializeField] private SlotCoatHub slotCoat;
    
    [Header("Part03")]
    [SerializeField] private TextMeshProUGUI Description;
    
    [Header("Part04")]
    [SerializeField] private TextMeshProUGUI txtCurrentPointService;
    [SerializeField] private GameObject imgND_txtNextPointService;
    [SerializeField] private TextMeshProUGUI txtNextPointService;
    [SerializeField] private Sprite imgStarOff;
    [SerializeField] private Sprite imgStarOn;
    [SerializeField] private List<Image> stars;

    [Header("Part05")]
    [SerializeField] private TextMeshProUGUI txtDesMove1;
    [SerializeField] private GameObject objDesSpecialMove;
    [SerializeField] private TextMeshProUGUI txtDesSpecialMove;
    [SerializeField] private GameObject objDesMove2;
    [SerializeField] private TextMeshProUGUI txtDesMove2;

    [Header("Part06")]
    [SerializeField] private TextMeshProUGUI txtDaoTao;
    
    [Header("Part06")]
    [SerializeField] private TextMeshProUGUI txtPriceNextLevel;
    [SerializeField] private Button btnUpLevel;

    private NhanVien _nhanVien;
    private void Start()
    {
        btnUpLevel.onClick.AddListener(UpLevelNV);
    }

    public void Init(NhanVien nhanVien, UIManager uiManager)
    {
        btnX.onClick.RemoveAllListeners();
        btnX.onClick.AddListener(() =>
        {
            if (nhanVien.NVBase.Group == ValueNhanVien.NVPV)
            {
                uiManager.ReLoadContentNhanVien(ValueNhanVien.NVPV);
            }
            else if (nhanVien.NVBase.Group == ValueNhanVien.NVDB)
            {
                uiManager.ReLoadContentNhanVien(ValueNhanVien.NVDB);
            }
            else if (nhanVien.NVBase.Group == ValueNhanVien.NVPB)
            {
                uiManager.ReLoadContentNhanVien(ValueNhanVien.NVPB);
            } 
            else if (nhanVien.NVBase.Group == ValueNhanVien.NVTN)
            {
                uiManager.ReLoadContentNhanVien(ValueNhanVien.NVTN);
            }
            else if (nhanVien.NVBase.Group == ValueNhanVien.NVPG)
            {
                uiManager.ReLoadContentNhanVien(ValueNhanVien.NVPG);
            }
            
            foreach (var item in GameManager.i.NV_PG)
            {
                if (item == nhanVien)
                {
                    uiManager.ReLoadContentNhanVien(ValueNhanVien.NVPG);
                }
            }
            
            
            gameObject.SetActive(false);
        });
        
        Coats = new List<SlotCoatHub>();
        this._nhanVien = nhanVien;
        Story.text = nhanVien.NVBase.Story;
        Description.text = nhanVien.NVBase.Description;
        
        UpdateInfoSkin(nhanVien.NVBase.Skins[nhanVien.CurrentSkin]);
        UpdateContentCoat(contentCoat, nhanVien.NVBase.Skins);
        UpdateStars(nhanVien.Level);
        UpdateInfoCondition(nhanVien);
    }

    void UpdateStars(int n)
    {
        DeleteColorStar();
        
        for (int i = 0; i < n; i++)
        {
            stars[i].sprite = imgStarOn;
        }
    }

    void DeleteColorStar()
    {
        foreach (var star in stars)
        {
            star.sprite = imgStarOff;
        }
    }

    public void UpdateInfoSkin(Skin skin)
    {
        ResetColorCoats();
        imgFullSkin.sprite = skin.FullSkin;
        PointServicePlus.text = skin.PointSkin.ToString();
        NameSkin.text = skin.NameSkin;
        txtPrice.text = skin.Price.ToString();
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
    
    void UpdateInfoCondition(NhanVien nhanVien)
    {
        txtCurrentPointService.text = nhanVien.NVBase.Skill[nhanVien.Level].LevelPointService.ToString();
        
        if (nhanVien.Level + 1 < nhanVien.NVBase.Skill.Count)
        {
            imgND_txtNextPointService.gameObject.SetActive(true);
            txtNextPointService.text = nhanVien.NVBase.Skill[nhanVien.Level + 1].LevelPointService.ToString();
        }
        else
        {
            imgND_txtNextPointService.gameObject.SetActive(false);
        }

        UpdateDescriptionMove();

    }

    void UpdateDescriptionMove()
    {
        //=============Description of Move=================
        txtDaoTao.text = $"Hien tai so huu: {GameManager.i.DSachDaoTao}";
        int priceNextLevel = _nhanVien.NVBase.Skill[_nhanVien.Level].PriceToNextValue;
        txtPriceNextLevel.text = $" x {priceNextLevel.ToString()}";

        if (GameManager.i.DSachDaoTao >= priceNextLevel)
        {
            txtPriceNextLevel.color = Color.white;
        }
        else
        {
            txtPriceNextLevel.color = Color.red;
        }
        
        ConditionID id = _nhanVien.NVBase.Skill[_nhanVien.Level].LevelNormalMoves1.ConditionID;
        string description = ConditionBD.Conditions[id].Description;
        txtDesMove1.text = description + $" {_nhanVien.NVBase.Skill[_nhanVien.Level].LevelNormalMoves1.Percent}%";
        
        description = "";
        id = ConditionID.none;
        id = _nhanVien.NVBase.Skill[_nhanVien.Level].LevelSpecialMoves.ConditionID;
        
        if (id != ConditionID.none)
        {
            objDesSpecialMove.gameObject.SetActive(true);
            description 
                = $"{_nhanVien.NVBase.Skill[_nhanVien.Level].LevelSpecialMoves.PAbility}% khả năng kích hoạt " +
                  $"{ConditionBD.Conditions[id].Description } "
                  + $"{_nhanVien.NVBase.Skill[_nhanVien.Level].LevelNormalMoves1.Percent}% "
                  + $"trong {_nhanVien.NVBase.Skill[_nhanVien.Level].LevelSpecialMoves.TimeDuring} giây";
            txtDesSpecialMove.text = description;
        }
        else
        {
            objDesSpecialMove.gameObject.SetActive(false);
        }
        
        description = "";
        id = ConditionID.none;
        id = _nhanVien.NVBase.Skill[_nhanVien.Level].LevelNormalMoves2.ConditionID;
        
        if (id != ConditionID.none)
        {
            objDesMove2.gameObject.SetActive(true);
            description = ConditionBD.Conditions[id].Description;
            txtDesMove2.text = description + $" {_nhanVien.NVBase.Skill[_nhanVien.Level].LevelNormalMoves2.Percent}%";
        }
        else
        {
            objDesMove2.gameObject.SetActive(false);
        }
        
        //==========End===================
    }

    void UpLevelNV()
    {
        if (_nhanVien.NVBase.Skill[_nhanVien.Level].PriceToNextValue > GameManager.i.DSachDaoTao)
        {
            Debug.Log($"Not enough pSachDaoTao - { GameManager.i.DSachDaoTao}");
            return;
        }
        else if(GameManager.i.Call_UpLevelNV(_nhanVien))
        {
            UpdateInfoCondition(_nhanVien);
            UpdateStars(_nhanVien.Level);
        }
    }

}
