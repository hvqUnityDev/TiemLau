using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i { get; private set; }

    [SerializeField] private int dDiamond = 9999;
    [SerializeField] private int dMoney = 9999;
    [SerializeField] private int dCoSo = 9999;
    [SerializeField] private int dPhucVu = 9999;
    [SerializeField] private int dThucAn = 9999;
    

    [SerializeField] private UIManager _uiManager;


    //Nha Hang 
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
    }

     
    public int d_Diamond => dDiamond;
    public int d_Money => dMoney;
    public int d_CoSo => dCoSo;
    public int d_PhucVu => dPhucVu;
    public int d_ThucAn => dThucAn;
    public List<NhanVien> NV_PhucVu => nhanViens_PhucVu;
    public List<NhanVien> NV_ThuNgan => nhanViens_ThuNgan;
    public List<NhanVien> NV_PhuBep => nhanViens_PhuBep;
    public List<NhanVien> NV_DauBep => nhanViens_DauBep;
    public List<NhanVien> NV_PG => nhanViens_PG;
}
