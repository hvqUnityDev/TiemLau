using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhanVien : MonoBehaviour
{
    
    [SerializeField] private int level;
    [SerializeField] private int currentSkin = 0;

    [SerializeField] private Dictionary<Skin, bool> skinAvailable;
    private NhanVienBase _nvBase;

    public NhanVien(NhanVienBase _nvBase)
    {
        this._nvBase = _nvBase;
        skinAvailable = new Dictionary<Skin, bool>();
        int i = 0;
        foreach (var kvp in skinAvailable)
        {
            //kvp.Key = _nvBase.Skins[i];
        }
        level = 0;
    }
    
    public int GetPointService()
    {
        if (NVBase.Skill.Count < 1)
        {
            Debug.Log("Chua co level Skill");
        }
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

