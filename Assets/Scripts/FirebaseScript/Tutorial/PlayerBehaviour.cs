using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//done
public class PlayerBehaviour : MonoBehaviour
{
    private PlayerData playerData;
    public PlayerData PlayerData => playerData;
    public UnityEvent OnPlayerUpdated = new UnityEvent();
    private void Start()
    {
        playerData = new PlayerData();
        playerData.dDiamond = 1;
        playerData.dMoney = 0;
        playerData.dCoSo = 0;
    }
    

    private void Update()
    {
        Debug.Log($"{playerData.dDiamond} - {playerData.dMoney} - {playerData.dCoSo}");
    }

    public void UpdatePlayer(GameObject obj, PlayerData playerData)
    {
        if (!playerData.Equals(this.playerData))
        {
            this.playerData = playerData;
            OnPlayerUpdated.Invoke();
        }
        
    }

    public void Add_Diamond()
    {
        playerData.dDiamond++;
    }
    public void Add_dMoney()
    {
        playerData.dMoney++;
    }
    public void Add_dCoSo()
    {
        playerData.dCoSo++;
    }
}

[Serializable]
public struct PlayerData
{
    public int dDiamond;
    public int dMoney;
    public int dCoSo;
}
