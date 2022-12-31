using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //public static UIManager i;

    [SerializeField] private TextMeshProUGUI txt_dDiamon;
    [SerializeField] private TextMeshProUGUI txt_dMoney;
    [SerializeField] private TextMeshProUGUI txt_dCoSo;
    [SerializeField] private TextMeshProUGUI txt_dPhucVu;
    [SerializeField] private TextMeshProUGUI txt_dThucAn;
    [SerializeField] private TMP_Text txtName;

    [Header("btn Option")]
    [SerializeField] private Button btnCuaTiem;
    [SerializeField] private Button btnGhep;
    [SerializeField] private Button btnThucDon;
    [SerializeField] private Button btnNhanVien;
    [SerializeField] private Button btnSangTao;
    [SerializeField] private Button btnCuaHang;

    [Header("Option")]
    [SerializeField] private GameObject option;

    public Action TurnOffOption;

    [Header("Craft")]
    [SerializeField] private OptionCrafting _optionCrafting;

    [Header("NhanVien")]
    [SerializeField] private Button btnXNhanVien;
    [SerializeField] private GameObject optionNhanVien;
    [SerializeField] private Transform contentNhanVien;
    [SerializeField] private SlotOptionNhanVienHub slotOptionNhanVien;
    [SerializeField] private MoreInfoNV moreInfoNV;
    private Color colorOnClick = Color.yellow;
    private Color colorOffClick = Color.white;
    [SerializeField] private Button btn_NVPV;
    [SerializeField] private Button btn_NVTN;
    [SerializeField] private Button btn_NVPB;
    [SerializeField] private Button btn_NVDB;
    [SerializeField] private Button btn_NVPG;
    
    [SerializeField] private GameObject optionCuaTiem;
    [SerializeField] private GameObject optionThucAn;
    [SerializeField] private GameObject optionSangTao;
    [SerializeField] private GameObject optionCuaHang;

    [Header("btn X")]
    [SerializeField] private Button btnXCuaTiem;
    [SerializeField] private Button btnXThucDon;
    [SerializeField] private Button btnXSangTao;
    [SerializeField] private Button btnXCuaHang;

    private void Start()
    {
        
        btnCuaTiem.onClick.AddListener(Click_CuaTiem);
        btnGhep.onClick.AddListener(Click_Ghep);
        btnThucDon.onClick.AddListener(Click_ThucDon);
        btnNhanVien.onClick.AddListener(Click_NhanVien);
        btnSangTao.onClick.AddListener(Click_SangTao);
        btnCuaHang.onClick.AddListener(Click_CuaHang);
        
        btnXNhanVien.onClick.AddListener(Click_XNhanVien);
        
        btn_NVPV.onClick.AddListener(OnClick_btn_NVPV);
        btn_NVTN.onClick.AddListener(OnClick_btn_NVTN);
        btn_NVPB.onClick.AddListener(OnClick_btn_NVPB);
        btn_NVDB.onClick.AddListener(OnClick_btn_NVDB);
        btn_NVPG.onClick.AddListener(OnClick_btn_NVPG);

        DeleteColorButton();
        
        option.SetActive(false);
        optionNhanVien.gameObject.SetActive(false);
        moreInfoNV.gameObject.SetActive(false);

        TurnOffOption += () => {option.SetActive(false);};
        _optionCrafting.Init(this);
    }


    #region Void Update Value Of Slot 01
    
    public void UpdateValueDiamond(int value)
    {
        txt_dDiamon.text = value.ToString();
    }
    public void UpdateValueMoney(int value)
    {
        txt_dMoney.text = value.ToString();
    }
    public void UpdateValueCoSo(int value)
    {
        txt_dCoSo.text = value.ToString();
    }
    public void UpdateValuePhucVu(int value)
    {
        txt_dPhucVu.text = value.ToString();
    }
    public void UpdateValueThucAn(int value)
    {
        txt_dThucAn.text = value.ToString();
    }

    public void UpdateValueName(string name)
    {
        txtName.text = name;
        Debug.Log("name : " + name);
    }
    
    #endregion
    
    #region Void Of Slot 02

    void Click_CuaTiem()
    {
        Debug.Log("TODO: Click_CuaTiem");
    }
    void Click_Ghep()
    {
        option.gameObject.SetActive(true);
        _optionCrafting.gameObject.SetActive(true);
        //_optionCrafting.UpdateSlot(GameManager.i.Bag);
    }
    void Click_ThucDon()
    {
        Debug.Log("TODO: Click_ThucDon");
    }
    void Click_NhanVien()
    {
        option.gameObject.SetActive(true);
        optionNhanVien.gameObject.SetActive(true);
        OnClick_btn_NVPV();
    }
    void Click_SangTao()
    {
        Debug.Log("TODO: Click_SangTao");
    }
    void Click_CuaHang()
    {
        Debug.Log("TODO: Click_CuaHang");
    }
    
    #endregion

    #region Void X Of Option

    public void Click_XCuaTiem()
    {
        Debug.Log("TODO: Click_XCuaTiem");
    }
    
    public void Click_XThucDon()
    {
        Debug.Log("TODO: Click_XThucDon");
    }
    public void Click_XNhanVien()
    {
        optionNhanVien.gameObject.SetActive(false);
        option.gameObject.SetActive(false);
    }
    public void Click_XSangTao()
    {
        Debug.Log("TODO: Click_XSangTao");
    }
    public void Click_XCuaHang()
    {
        Debug.Log("TODO: Click_XCuaHang");
    }

    #endregion

    #region Void Option NhanVien

    void DeleteColorButton()
    {
        btn_NVPV.GetComponent<Image>().color = colorOffClick;
        btn_NVTN.GetComponent<Image>().color = colorOffClick;
        btn_NVPB.GetComponent<Image>().color = colorOffClick;
        btn_NVDB.GetComponent<Image>().color = colorOffClick;
        btn_NVPG.GetComponent<Image>().color = colorOffClick;
    }

    void OnClick_btn_NVPV()
    {
        UpdateContentNhanVien(contentNhanVien, GameManager.i.Player.NV_PhucVu);
        DeleteColorButton();
        btn_NVPV.GetComponent<Image>().color = colorOnClick;
    }
    
    void OnClick_btn_NVTN()
    {
        UpdateContentNhanVien(contentNhanVien, GameManager.i.Player.NV_ThuNgan);
        DeleteColorButton();
        btn_NVTN.GetComponent<Image>().color = colorOnClick;
    }
    
    void OnClick_btn_NVPB()
    {
        UpdateContentNhanVien(contentNhanVien, GameManager.i.Player.NV_PhuBep);
        DeleteColorButton();
        btn_NVPB.GetComponent<Image>().color = colorOnClick;
    }
    
    void OnClick_btn_NVDB()
    {
        UpdateContentNhanVien(contentNhanVien, GameManager.i.Player.NV_DauBep);
        DeleteColorButton();
        btn_NVDB.GetComponent<Image>().color = colorOnClick;
    }
    
    void OnClick_btn_NVPG()
    {
        UpdateContentNhanVien(contentNhanVien, GameManager.i.Player.NV_PG);
        DeleteColorButton();
        btn_NVPG.GetComponent<Image>().color = colorOnClick;
    }
    
    void UpdateContentNhanVien(Transform content, List<NhanVien> nhanViens)
    {
        DeleteContent(content);
        foreach (var item in nhanViens)
        {
            Instantiate(slotOptionNhanVien, content).GetComponent<SlotOptionNhanVienHub>().Init(item, this);
        }
    }

    public void ReLoadContentNhanVien(ValueNhanVien value)
    {
        if (value == ValueNhanVien.NVPV)
        {
            OnClick_btn_NVPV();
        }else if (value == ValueNhanVien.NVTN)
        {
            OnClick_btn_NVTN();
        }else if (value == ValueNhanVien.NVPB)
        {
            OnClick_btn_NVPB();
        }else if (value == ValueNhanVien.NVDB)
        {
            OnClick_btn_NVDB();
        }else if (value == ValueNhanVien.NVPG)
        {
            OnClick_btn_NVPG();
        }
        else
        {
            Debug.Log("Not in enum ValueNhanVien???");
        }
    }

    void DeleteContent(Transform content)
    {
        foreach (Transform item in content)
        {
            Destroy(item.gameObject);
        }
    }
    
    //TODO: change [0]
    public void OnMoreInfoNV(NhanVien nv)
    {
        moreInfoNV.gameObject.SetActive(true);
        moreInfoNV.Init(nv, this);
    }
    
    #endregion
    public OptionCrafting OptionCrafting => _optionCrafting;
    
}

public enum ValueNhanVien
{
    none,
    NVPV,
    NVTN,
    NVPB,
    NVDB,
    NVPG
}
