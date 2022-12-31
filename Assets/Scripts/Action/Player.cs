using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    public UnityEvent OnSetDataFromDB = new UnityEvent();
    
    [SerializeField] private List<ItemCraftBase> bag;

    [SerializeField] private List<NhanVien> nhanViens_PhucVu = new List<NhanVien>();
    [SerializeField] private List<NhanVien> nhanViens_ThuNgan = new List<NhanVien>();
    [SerializeField] private List<NhanVien> nhanViens_PhuBep = new List<NhanVien>();
    [SerializeField] private List<NhanVien> nhanViens_DauBep = new List<NhanVien>();
    [SerializeField] private List<NhanVien> nhanViens_PG = new List<NhanVien>();
    
    [SerializeField] private int dDiamond = 0;
    [SerializeField] private int dMoney = 0;
    [SerializeField] private int dCoSo = 0;
    [SerializeField] private int dPhucVu = 0;
    [SerializeField] private int dThucAn = 0;
    [SerializeField] private int dSachDaoTao = 0;
    [SerializeField] private int dTheLuc = 0; 
    

    public string strName;

    public void GetPlayerFromFirebase()
    {
        strName = ScriptForFirebase.strName == "" ? "QuanHehe" : ScriptForFirebase.strName;
        dDiamond = ScriptForFirebase.dDiamond;
        dMoney = ScriptForFirebase.dMoney;
        dCoSo = ScriptForFirebase.dCoSo;
        dPhucVu = ScriptForFirebase.dPhucVu;
        dThucAn = ScriptForFirebase.dThucAn;
        dSachDaoTao = ScriptForFirebase.dSachDaoTao;
        dTheLuc = ScriptForFirebase.dTheLuc;
        GameManager.i.UpdateD?.Invoke();
    }
    
    public Player(string strName, int dDiamond, int dMoney, int dCoSo, int dPhucVu, int dThucAn, int dSachDaoTao, int dTheLuc)
    {
        this.strName = strName;
        this.dDiamond = dDiamond;
        this.dMoney = dMoney;
        this.dCoSo = dCoSo;
        this.dPhucVu = dPhucVu;
        this.dThucAn = dThucAn;
        this.dSachDaoTao = dSachDaoTao;
        this.dTheLuc = dTheLuc;
    }
    
    private IEnumerator Start()
    {

        bag = new List<ItemCraftBase>();

        yield return new WaitWhile(() => GameManager.i == null);
        
        InitNhanVien(GameManager.i.ObjectNhanVienBases.PhucVuBases, nhanViens_PhucVu);
        InitNhanVien(GameManager.i.ObjectNhanVienBases.ThuNganBases, nhanViens_ThuNgan);
        InitNhanVien(GameManager.i.ObjectNhanVienBases.PhuBepBases, nhanViens_PhuBep);
        InitNhanVien(GameManager.i.ObjectNhanVienBases.DauBepBases, nhanViens_DauBep);
        InitNhanVien(GameManager.i.ObjectNhanVienBases.PGBases, nhanViens_PG);
        
        OnSetDataFromDB.AddListener(SetDataFromDB);
        //OnSetDataFromDB.Invoke();
    }

    private void OnDestroy()
    {
        OnSetDataFromDB.RemoveListener(SetDataFromDB);
    }

    private void SetDataFromDB()
    {
        strName = ScriptForFirebase.strName;
        dDiamond = ScriptForFirebase.dDiamond;
        dMoney = ScriptForFirebase.dMoney;
        dCoSo = ScriptForFirebase.dCoSo;
        dPhucVu = ScriptForFirebase.dPhucVu;
        dThucAn = ScriptForFirebase.dThucAn;
        dSachDaoTao = ScriptForFirebase.dSachDaoTao;
        dTheLuc = ScriptForFirebase.dTheLuc;
        
        
        
        GameManager.i.UpdateD?.Invoke();
    }
    
    
    void InitNhanVien(List<NhanVienBase> list, List<NhanVien> nvs)
    {
        foreach (var item in list)
        {
            NhanVien i = new NhanVien(item);
            nvs.Add(i);
        }
    }



    ItemCraftBase SearchInBag(ItemCraftID id, LevelOfItem lvl)
    {
        foreach (var i in bag)
        {
            if (i.ID == id && i.Level == lvl)
            {
                return i;
            }
        }

        Debug.Log("Not in bag!");
        return null;
    }
    
    public void Call_TryBuyTheSkin(NhanVien nhanVien, Skin skin)
    {
        if (dDiamond < skin.Price)
        {
            Debug.Log("TODO: not enough diamond");
            return;
        }

        nhanVien.UnLockSkin(skin);
    }
    
    public bool Call_UpLevelNV(NhanVien nhanVien)
    {
        if (nhanVien.IsUpLevel())
        {
            dSachDaoTao -= nhanVien.NVBase.Skill[nhanVien.Level - 1].PriceToNextValue;
            return true;
        }

        return false;
    }
    
    
    
    
    public List<NhanVien> NV_PhucVu => nhanViens_PhucVu;
    public List<NhanVien> NV_ThuNgan => nhanViens_ThuNgan;
    public List<NhanVien> NV_PhuBep => nhanViens_PhuBep;
    public List<NhanVien> NV_DauBep => nhanViens_DauBep;
    public List<NhanVien> NV_PG => nhanViens_PG;
    public List<ItemCraftBase> Bag => bag;
    
    public int DDiamond => dDiamond;
    public int DMoney => dMoney;
    public int DCoSo => dCoSo;
    public int DPhucVu => dPhucVu;
    public int DThucAn => dThucAn;
    public int DSachDaoTao => dSachDaoTao;
    public int DTheLuc => dTheLuc;
}
