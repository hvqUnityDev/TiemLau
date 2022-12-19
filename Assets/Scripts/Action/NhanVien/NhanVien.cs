using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhanVien : MonoBehaviour
{
    
    [SerializeField] private int level = 0;
    [SerializeField] private int currentSkin = 0;

    private NhanVienBase _nvBase;
    
    public NhanVien(NhanVienBase _nvBase)
    {
        this._nvBase = _nvBase;
    }
    
    public int GetPointService()
    {
        return NVBase.Skill[level].LevelPointService;
    }

    public bool IsUpLevel()
    {
        if (NVBase.Skill[level].PriceToNextValue == -1) 
        {
            Debug.Log($"Max Level {level}");
            return false;
        }
        
        level++;
        return true;
    }
    
    public int Level => level;
    public int CurrentSkin => currentSkin;
    public NhanVienBase NVBase => _nvBase;
    
}

