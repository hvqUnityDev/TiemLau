using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI txt_dDiamon;
    [SerializeField] private TextMeshProUGUI txt_dMoney;
    [SerializeField] private TextMeshProUGUI txt_dCoSo;
    [SerializeField] private TextMeshProUGUI txt_dPhucVu;
    [SerializeField] private TextMeshProUGUI txt_dThucAn;

    [SerializeField] private Button btnCuaTiem;
    [SerializeField] private Button btnGhep;
    [SerializeField] private Button btnThucDon;
    [SerializeField] private Button btnNhanVien;
    [SerializeField] private Button btnSangTao;
    [SerializeField] private Button btnCuaHang;

    [SerializeField] private GameObject option;
    [SerializeField] private GameObject optionCuaTiem;
    [SerializeField] private GameObject optionGhep;
    [SerializeField] private GameObject optionThucAn;
    [SerializeField] private GameObject optionNhanVien;
    [SerializeField] private Transform contentNhanVien;
    [SerializeField] private GameObject slotOptionNhanVien;
    [SerializeField] private GameObject optionSangTao;
    [SerializeField] private GameObject optionCuaHang;

    [SerializeField] private Button btnXCuaTiem;
    [SerializeField] private Button btnXGhep;
    [SerializeField] private Button btnXThucDon;
    [SerializeField] private Button btnXNhanVien;
    [SerializeField] private Button btnXSangTao;
    [SerializeField] private Button btnXCuaHang;

    private Color colorOnClick = Color.yellow;
    private Color colorOffClick = Color.white;
    [SerializeField] private Button btn_NVPV;
    [SerializeField] private Button btn_NVTN;
    [SerializeField] private Button btn_NVPB;
    [SerializeField] private Button btn_NVDB;
    [SerializeField] private Button btn_NVPG;

    private void Start()
    {
        btnCuaTiem.onClick.AddListener(Click_CuaTiem);
        btnGhep.onClick.AddListener(Click_Ghep);
        btnThucDon.onClick.AddListener(Click_ThucDon);
        btnNhanVien.onClick.AddListener(Click_NhanVien);
        btnSangTao.onClick.AddListener(Click_SangTao);
        btnCuaHang.onClick.AddListener(Click_CuaHang);
        
        
        btnXNhanVien.onClick.AddListener(Click_XNhanVien);
        
        btn_NVPV.onClick.AddListener(onClick_btn_NVPV);
        btn_NVTN.onClick.AddListener(onClick_btn_NVTN);
        btn_NVPB.onClick.AddListener(onClick_btn_NVPB);
        btn_NVDB.onClick.AddListener(onClick_btn_NVDB);
        btn_NVPG.onClick.AddListener(onClick_btn_NVPG);

        DeleteColorButton();
        
        
        option.gameObject.SetActive(false);
        optionNhanVien.gameObject.SetActive(false);

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
    
    #endregion
    
    #region Void Of Slot 02

    void Click_CuaTiem()
    {
        Debug.Log("TODO: Click_CuaTiem");
    }
    void Click_Ghep()
    {
        Debug.Log("TODO: Click_Ghep");
    }
    void Click_ThucDon()
    {
        Debug.Log("TODO: Click_ThucDon");
    }
    void Click_NhanVien()
    {
        option.gameObject.SetActive(true);
        optionNhanVien.gameObject.SetActive(true);
        onClick_btn_NVPV();
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
    public void Click_XGhep()
    {
        Debug.Log("TODO: Click_XGhep");
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

    void onClick_btn_NVPV()
    {
        UpdateContentNhanVien(contentNhanVien, GameManager.i.NV_PhucVu);
        DeleteColorButton();
        btn_NVPV.GetComponent<Image>().color = colorOnClick;
    }
    
    void onClick_btn_NVTN()
    {
        UpdateContentNhanVien(contentNhanVien, GameManager.i.NV_ThuNgan);
        DeleteColorButton();
        btn_NVTN.GetComponent<Image>().color = colorOnClick;
    }
    
    void onClick_btn_NVPB()
    {
        UpdateContentNhanVien(contentNhanVien, GameManager.i.NV_PhuBep);
        DeleteColorButton();
        btn_NVPB.GetComponent<Image>().color = colorOnClick;
    }
    
    void onClick_btn_NVDB()
    {
        UpdateContentNhanVien(contentNhanVien, GameManager.i.NV_DauBep);
        DeleteColorButton();
        btn_NVDB.GetComponent<Image>().color = colorOnClick;
    }
    
    void onClick_btn_NVPG()
    {
        UpdateContentNhanVien(contentNhanVien, GameManager.i.NV_PG);
        DeleteColorButton();
        btn_NVPG.GetComponent<Image>().color = colorOnClick;
    }
    
    

    void UpdateContentNhanVien(Transform content, List<NhanVien> nhanViens)
    {
        DeleteContent(content);
        foreach (var item in nhanViens)
        {
            UpdateContent(content, item.Avatar, item.Name, item.Description, item.PointService);
        }
    }

    void UpdateContent(Transform content, Sprite avatar, string name, string description, int point)
    {
        var item = Instantiate(slotOptionNhanVien,content).GetComponent<SlotOptionNhanVienHub>();
        item.imgAvatar.sprite = avatar;
        item.txtName.text = name;
        item.txtDescription.text = description;
        item.txtPointService.text = point.ToString();
    }

    void DeleteContent(Transform content)
    {
        foreach (Transform item in content)
        {
            Destroy(item.gameObject);
        }
    }
    

    #endregion
    
}
