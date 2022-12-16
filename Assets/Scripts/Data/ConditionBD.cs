using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionBD
{
    public static void Init()
    {
        foreach (var kvp in Conditions)
        {
            var conditionID = kvp.Key;
            var conditionValue = kvp.Value;
            conditionID = conditionValue.ID;
        }
    }
    
    public static Dictionary<ConditionID, Condition> Conditions { get; set; } 
        = new Dictionary<ConditionID, Condition>()
    {
        {
            ConditionID.speed,
            new Condition()
            {
                Name = "speed",
                Description = "Đẩy mạnh tốc độ di chuyển "
            }
        },
        {
            ConditionID.speedClear,
            new Condition()
            {
                Name = "speedClear",
                Description = "Đẩy mạnh tốc độ vệ sinh "
            }
        }
        
        
    };
}

