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
    [SerializeField, Range(0, 30)] private int dTheLuc = 30; 
    
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
            ItemCraftBase item = SearchInDictionary(ItemCraftID.none);
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

    public void Call_ChangeSkinAfterBuy(NhanVien nhanVien, Skin skin)
    {
        nhanVien.SetCurrentSkin(skin);
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

    public void Call_AddFromOptionCraft(ItemCraftID id, LevelOfItem lvl)
    {
        for (int i = 0; i < bag.Count; i++)
        {
            if (bag[i].ID == ItemCraftID.none)
            {
                if (Dec_DTheLuc())
                {
                    bag[i] = SearchInDictionary(id, lvl);
                    return;
                }
                else
                {
                    Debug.Log("TODO: not enough dTheLuc");
                    return;
                }
                
            }
        }
        
        Debug.Log("full in bag");
    }

    public void ChangeInBag(int indexDrag, int index)
    {
        if (indexDrag == index)
        {
            Debug.Log("bang nhau");
            return;
        }
        if (bag[indexDrag] == bag[index])
        {
            Debug.Log("change");
            bag[index] = SearchInDictionary(bag[index].ID, bag[index].NextLevel);
        }
    }
    
    

    bool Dec_DTheLuc()
    {
        if (dTheLuc >= 1)
        {
            dTheLuc--;
            return true;
        }

        return false;
    }

    bool Inc_DTheLuc()
    {
        if (dTheLuc < 30)
        {
            dTheLuc++;
            return true;
        }

        return false;
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

    public ItemCraftBase SearchInDictionary(ItemCraftID id, LevelOfItem lvl = LevelOfItem.none)
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

     
    public int DDiamond => dDiamond;
    public int DMoney => dMoney;
    public int DCoSo => dCoSo;
    public int DPhucVu => dPhucVu;
    public int DThucAn => dThucAn;
    public int DSachDaoTao => dSachDaoTao;

    public int DTheLuc => dTheLuc;

    public List<NhanVien> NV_PhucVu => nhanViens_PhucVu;
    public List<NhanVien> NV_ThuNgan => nhanViens_ThuNgan;
    public List<NhanVien> NV_PhuBep => nhanViens_PhuBep;
    public List<NhanVien> NV_DauBep => nhanViens_DauBep;
    public List<NhanVien> NV_PG => nhanViens_PG;
    public List<ItemCraftBase> Bag => bag;
    public List<ItemCraftBase> ListItemCraftBases => ListItemCraftBases;
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
