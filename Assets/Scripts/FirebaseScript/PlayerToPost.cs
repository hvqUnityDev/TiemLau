using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToPost : MonoBehaviour
{
    //[SerializeField] private List<ItemCraftBase> bag;
    [SerializeField] private Dictionary<string, ListNVToPost> groupsNhanVien;
    [SerializeField] private int dDiamond;
    [SerializeField] private int dMoney;
    [SerializeField] private int dCoSo;
    [SerializeField] private int dPhucVu;
    [SerializeField] private int dThucAn;
    [SerializeField] private int dSachDaoTao;
    [SerializeField] private int dTheLuc;
    [SerializeField] private string strName;

    public PlayerToPost()
    {
        groupsNhanVien = new Dictionary<string, ListNVToPost>();
        
        GroupsNhanVienInit(ValueNhanVien.NVPV.ToString(), GameManager.i.Player.NV_PhucVu);
        GroupsNhanVienInit(ValueNhanVien.NVDB.ToString(), GameManager.i.Player.NV_DauBep);
        GroupsNhanVienInit(ValueNhanVien.NVPB.ToString(), GameManager.i.Player.NV_PhuBep);
        GroupsNhanVienInit(ValueNhanVien.NVPG.ToString(), GameManager.i.Player.NV_PG);
        GroupsNhanVienInit(ValueNhanVien.NVTN.ToString(), GameManager.i.Player.NV_ThuNgan);
        
        dDiamond = GameManager.i.Player.DDiamond;
        dMoney = GameManager.i.Player.DMoney;
        dCoSo = GameManager.i.Player.DCoSo;
        dPhucVu = GameManager.i.Player.DPhucVu;
        dThucAn = GameManager.i.Player.DThucAn;
        dSachDaoTao = GameManager.i.Player.DSachDaoTao;
        dTheLuc = GameManager.i.Player.DTheLuc;
        strName = GameManager.i.Player.strName;

    }

    private void GroupsNhanVienInit(string nameBase, List<NhanVien> nhanViens)
    {
        if (nhanViens.Count == 0) return;
        
        ListNVToPost listInfNVToPost = new ListNVToPost();
        listInfNVToPost.NhanVien = new Dictionary<string, InfNVToPost>();
        
        foreach (var nv in nhanViens)
        {
            listInfNVToPost.NhanVien.Add(nv.NVBase.NameNv, GetInf(nv));
        }
        
        groupsNhanVien.Add(nameBase, listInfNVToPost);
    }

    InfNVToPost GetInf(NhanVien nv)
    {
        return new InfNVToPost() { IsUnLock = nv.IsUnLock, Level = nv.Level };
    }
    
    public Dictionary<string, ListNVToPost> GroupsNhanVien => groupsNhanVien;
    
}

[Serializable]
public struct ListNVToPost
{
    public Dictionary<string, InfNVToPost> NhanVien;
}
[Serializable]
public struct InfNVToPost
{
    public bool IsUnLock;
    public int Level;
}


