using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhanVien : MonoBehaviour
{
    
    [SerializeField] private int level = 0;
    [SerializeField] private int currentSkin = 0;

    public NhanVienBase _nvBase;
    
    public NhanVien (NhanVienBase _base)
    {
        this._nvBase = _base;
    }
    
    public int GetPointService()
    {
        return _nvBase.Skill[level].LevelPointService;
    }

    public bool IsUpLevel()
    {
        if (_nvBase.Skill[level].PriceToNextValue == -1) 
        {
            Debug.Log($"Max Level {level}");
            return false;
        }
        
        level++;
        return true;
    }
    
    public int Level => level;
    public int CurrentSkin => currentSkin;
    
}

