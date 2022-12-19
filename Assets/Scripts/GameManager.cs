using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i { get; private set; }
    
    [SerializeField] UIManager uiManager;
    
    [SerializeField] private int dDiamond = 9999;
    [SerializeField] private int dMoney = 9999;
    [SerializeField] private int dCoSo = 9999;
    [SerializeField] private int dPhucVu = 9999;
    [SerializeField] private int dThucAn = 9999;
    [SerializeField] private int dSachDaoTao = 9999;

    [SerializeField] private ObjectNhanVienBase _objectNhanVienBases;
    [SerializeField] private List<ItemCraftBase> listItemCraftBases;

    [Header("There is checking, not change anything....")] 
    [SerializeField] private List<ItemCraftBase> bag;

    [SerializeField] private List<NhanVien> nhanViens_PhucVu;
    [SerializeField] private List<NhanVien> nhanViens_ThuNgan;
    [SerializeField] private List<NhanVien> nhanViens_PhuBep;
    [SerializeField] private List<NhanVien> nhanViens_DauBep;
    [SerializeField] private List<NhanVien> nhanViens_PG;
    
    private void Start()
    {
        if (i == null)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SettingFirst();


    }

    void SettingFirst()
    {
        ConditionBD.Init();
        ItemCraftDB.Init();

        InitNhanVien(_objectNhanVienBases.PhucVuBases, nhanViens_PhucVu);
        InitNhanVien(_objectNhanVienBases.ThuNganBases, nhanViens_ThuNgan);
        InitNhanVien(_objectNhanVienBases.PhuBepBases, nhanViens_PhuBep);
        InitNhanVien(_objectNhanVienBases.DauBepBases, nhanViens_DauBep);
        InitNhanVien(_objectNhanVienBases.PGBases, nhanViens_PG);

        bag = new List<ItemCraftBase>();
        
        for (int i = 0; i < uiManager.OptionCrafting.CountSlotInBody; i++)
        {
            ItemCraftBase item = new ItemCraftBase(ItemCraftID.none, LevelOfItem.One);
            Bag.Add(item);
        }
    }


    void InitNhanVien(List<NhanVienBase> list, List<NhanVien> nvs)
    {
        foreach (var item in list)
        {
            NhanVien i = new NhanVien(item);
            nvs.Add(i);
        }
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

    public void Call_AddFromOptionCraft(ItemCraftID id, LevelOfItem lvl)
    {
        for (int i = 0; i < bag.Count; i++)
        {
            if (bag[i].ID == ItemCraftID.none)
            {
                bag[i] = SearchInBag(id, lvl);
                Debug.Log("TODO: Dec dTheLuc");
                return;
            }
            else
            {
                Debug.Log("full in bag");
            }
        }
    }

    ItemCraftBase SearchInBag(ItemCraftID id, LevelOfItem lvl)
    {
        foreach (var i in listItemCraftBases)
        {
            if (i.ID == id && i.Level == lvl)
            {
                return i;
            }
        }

        Debug.Log("Not in dictionary!");
        return null;
    }

     
    public int d_Diamond => dDiamond;
    public int d_Money => dMoney;
    public int d_CoSo => dCoSo;
    public int d_PhucVu => dPhucVu;
    public int d_ThucAn => dThucAn;
    public int DSachDaoTao => dSachDaoTao;
    
    public List<NhanVien> NV_PhucVu => nhanViens_PhucVu;
    public List<NhanVien> NV_ThuNgan => nhanViens_ThuNgan;
    public List<NhanVien> NV_PhuBep => nhanViens_PhuBep;
    public List<NhanVien> NV_DauBep => nhanViens_DauBep;
    public List<NhanVien> NV_PG => nhanViens_PG;
    public List<ItemCraftBase> Bag => bag;
}

[Serializable]
struct ObjectNhanVienBase
{
    [SerializeField] private List<NhanVienBase> nhanViensBase_PhucVu;
    [SerializeField] private List<NhanVienBase> nhanViensBase_ThuNgan;
    [SerializeField] private List<NhanVienBase> nhanViensBase_PhuBep;
    [SerializeField] private List<NhanVienBase> nhanViensBase_DauBep;
    [SerializeField] private List<NhanVienBase> nhanViensBase_PG;
    
    public List<NhanVienBase> PhucVuBases => nhanViensBase_PhucVu;
    public List<NhanVienBase> ThuNganBases => nhanViensBase_ThuNgan;
    public List<NhanVienBase> PhuBepBases => nhanViensBase_PhuBep;
    public List<NhanVienBase> DauBepBases => nhanViensBase_DauBep;
    public List<NhanVienBase> PGBases => nhanViensBase_PG;
}
