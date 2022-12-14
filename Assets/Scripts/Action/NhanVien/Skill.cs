using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    [Header("Normal Move")] [SerializeField]
    private List<Move> levelNormalMoves;
    
    [Header("Special Move")] [SerializeField]
    private List<SpecialMove> levelSpecialMoves;
    
}

public class Move
{
    
}

public class SpecialMove
{
    
}



public enum effect
{
    speed,
    
}
