using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Skill
{
    [Header("Point Service")]
    [SerializeField] private int levelPointService;
    
    [Header("Price To Next Level")]
    [SerializeField] private int priceToNextValue;

    [Header("Normal Move")]
    [SerializeField] private Move levelNormalMove1;
    
    [Header("Special Move")] 
    [SerializeField] private SpecialMove levelSpecialMoves;
    
    [Header("Normal Move")] 
    [SerializeField] private Move levelNormalMove2;
    
    public int LevelPointService => levelPointService;
    public Move LevelNormalMoves1 => levelNormalMove1;
    public Move LevelNormalMoves2 => levelNormalMove2;
    public SpecialMove LevelSpecialMoves => levelSpecialMoves;
    public int PriceToNextValue => priceToNextValue;
}

[Serializable]
public class Move
{
    [SerializeField] private ConditionID conditionID;
    [SerializeField] private int percent;
    
    public ConditionID ConditionID => conditionID;
    public int Percent => percent;
}

[Serializable]
public class SpecialMove
{
    [SerializeField] private int percentAbility;
    [SerializeField] private ConditionID conditionID;
    [SerializeField] private int percent;
    [SerializeField] private int timeDuring;
    public int Percent => percent;
    public int PAbility => percentAbility;
    public ConditionID ConditionID => conditionID;
    public int TimeDuring => timeDuring;
}

[Serializable]
public enum ConditionID
{
    none,
    speed,
    speedClear

}
