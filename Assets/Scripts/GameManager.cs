using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager i { get; private set; }
    public Action UpdateD;

    [SerializeField] private ScriptForFirebase _scriptForFirebase;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Player player;
    
    [SerializeField] private ObjectNhanVienBase _objectNhanVienBases;
    [SerializeField] private List<ItemCraftBase> listItemCraftBases;
    
    
    private void Start()
    {
        UpdateD += UpdateUSlot ;
        ConditionBD.Init();
        ItemCraftDB.Init();

        
        if (i == null)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        UpdateD -= UpdateUSlot;
    }

    private void UpdateUSlot()
    {
        UpdateUISlot1_D(player);
    }
        

    private void UpdateUISlot1_D(Player player)
    {
        uiManager.UpdateValueDiamond(player.DDiamond);
        uiManager.UpdateValueMoney(player.DMoney);
        uiManager.UpdateValueCoSo(player.DCoSo);
        uiManager.UpdateValuePhucVu(player.DPhucVu);
        uiManager.UpdateValueThucAn(player.DThucAn);
        uiManager.UpdateValueName(player.strName);
        
        _scriptForFirebase.OnFirebaseUpdate?.Invoke();
    }


    public void Call_ChangeSkinAfterBuy(NhanVien nhanVien, Skin skin)
    {
        nhanVien.SetCurrentSkin(skin);
    }


    // public void Call_AddFromOptionCraft(ItemCraftID id, LevelOfItem lvl)
    // {
    //     for (int i = 0; i < bag.Count; i++)
    //     {
    //         if (bag[i].ID == ItemCraftID.none)
    //         {
    //             if (Dec_DTheLuc())
    //             {
    //                 bag[i] = SearchInDictionary(id, lvl);
    //                 return;
    //             }
    //             else
    //             {
    //                 Debug.Log("TODO: not enough dTheLuc");
    //                 return;
    //             }
    //             
    //         }
    //     }
    //     
    //     Debug.Log("full in bag");
    // }
    //
    // public void ChangeInBag(int indexDrag, int index)
    // {
    //     if (indexDrag == index)
    //     {
    //         Debug.Log("bang nhau");
    //         return;
    //     }
    //     if (bag[indexDrag] == bag[index])
    //     {
    //         Debug.Log("change");
    //         bag[index] = SearchInDictionary(bag[index].ID, bag[index].NextLevel);
    //     }
    // }
    
    

    // bool Dec_DTheLuc()
    // {
    //     if (dTheLuc >= 1)
    //     {
    //         dTheLuc--;
    //         return true;
    //     }
    //
    //     return false;
    // }
    //
    // bool Inc_DTheLuc()
    // {
    //     if (dTheLuc < 30)
    //     {
    //         dTheLuc++;
    //         return true;
    //     }
    //
    //     return false;
    // }
    

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

     
    public int DDiamond => player.DDiamond;
    public int DMoney => player.DMoney;
    public int DCoSo => player.DCoSo;
    public int DPhucVu => player.DPhucVu;
    public int DThucAn => player.DThucAn;
    public int DSachDaoTao => player.DSachDaoTao;
    public int DTheLuc => player.DTheLuc;

    public Player Player => player;
    
    //public List<ItemCraftBase> ListItemCraftBases => ListItemCraftBases;
    public ObjectNhanVienBase ObjectNhanVienBases => _objectNhanVienBases;
}

[Serializable]
public struct ObjectNhanVienBase
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
