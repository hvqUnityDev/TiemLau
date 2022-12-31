using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncPlayerToSave : MonoBehaviour
{
    [SerializeField] private PlayerSaveManager _playerSaveManager;
    [SerializeField] private PlayerBehaviour _player;

    private void Reset()
    {
        
        _playerSaveManager = FindObjectOfType<PlayerSaveManager>();
    }

    private IEnumerator Start()
    {
        var playerDataTask = _playerSaveManager.LoadPlayer();
        yield return new WaitUntil(() => playerDataTask.IsCompleted);
        var playerData = playerDataTask.Result;
        
        _player.OnPlayerUpdated.AddListener(HandlePlayerUpdate);
        
        if (playerData.HasValue)
        {
            _player.UpdatePlayer(gameObject, playerData.Value);
        }
        
        _playerSaveManager.OnPlayerUpdate.AddListener(()=> HandlePlayerSaveUpdate(_player.PlayerData));
        //_player.UpdatePlayer(gameObject, _playerSaveManager.LastPlayerData);
    }

    private void HandlePlayerSaveUpdate(PlayerData playerData)
    {
        _player.UpdatePlayer(gameObject, playerData);
    }

    private void HandlePlayerUpdate()
    {
        _playerSaveManager.SavePlayer(_player.PlayerData);
    }
    
    
}
