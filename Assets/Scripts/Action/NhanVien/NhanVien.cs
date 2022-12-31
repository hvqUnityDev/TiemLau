using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NhanVien : MonoBehaviour
{
    public Action<int> ConvertActionWithData;
    
    [SerializeField] private int level;
    [SerializeField] private Skin objCurrentSkin;
    [SerializeField] private bool isUnLock;
    [SerializeField] private Dictionary<Skin, bool> _conditionSkins;
    private NhanVienBase _nvBase;


    private void FixDataWithDatabase(int level)
    {
        this.level = level;
    }

    public NhanVien(NhanVienBase _nvBase)
    {
        ConvertActionWithData += FixDataWithDatabase;
        
        this._nvBase = _nvBase;
        this.isUnLock = false;
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

    public void UnLock()
    {
        isUnLock = true;
    }

    public int Level => level;
    public Skin ObjCurrentSkin => objCurrentSkin;
    public NhanVienBase NVBase => _nvBase;
    public Dictionary<Skin, bool> ConditionSkins => _conditionSkins;

    public bool IsUnLock => isUnLock;

}

