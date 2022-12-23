using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NhanVien : MonoBehaviour
{
    
    [SerializeField] private int level;
    [SerializeField] private Skin objCurrentSkin;

    [SerializeField] private Dictionary<Skin, bool> _conditionSkins;
    private NhanVienBase _nvBase;
    
    public NhanVien(NhanVienBase _nvBase)
    {
        this._nvBase = _nvBase;
        
        _conditionSkins = new Dictionary<Skin, bool>();
        foreach (var skin in _nvBase.Skins)
        {
            if (skin.CondtionSkin == CondtionSkin.Default)
            {
                _conditionSkins.Add(skin, true);
                objCurrentSkin = skin;
            }
            else 
                _conditionSkins.Add(skin, false);
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

    public void UnLockSkin(Skin skin)
    {
        _conditionSkins[skin] = true;
        
    }

    public bool SetCurrentSkin(Skin skin)
    {
        if (_conditionSkins[skin])
        {
            objCurrentSkin = skin;
            return true;
        }

        return false;
    }

    public int Level => level;
    public Skin ObjCurrentSkin => objCurrentSkin;
    public NhanVienBase NVBase => _nvBase;
    public Dictionary<Skin, bool> ConditionSkins => _conditionSkins;
    
}

