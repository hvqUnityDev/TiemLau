using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Google.MiniJSON;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

//done
public class PlayerSaveManager : MonoBehaviour
{
    private const string PLAYER_KEY = "PLAYER_KEY";
    private FirebaseDatabase _database;
    [SerializeField]
    public PlayerData LastPlayerData { get; private set; }
    public PlayerUpdateEvent OnPlayerUpdate = new PlayerUpdateEvent();
    private DatabaseReference _ref;

    private void Start()
    {
        _database = FirebaseDatabase.DefaultInstance;
        _ref = _database.GetReference(PLAYER_KEY);
        _ref.ValueChanged += HandleValueChange;
    }

    private void OnDestroy()
    {
        _ref.ValueChanged -= HandleValueChange;
        _ref = null;
        _database = null;
    }

    private void HandleValueChange(object sender, ValueChangedEventArgs e)
    {
        var json = e.Snapshot.GetRawJsonValue();
        if (!string.IsNullOrEmpty(json))
        {
            var playerData = JsonUtility.FromJson<PlayerData>(json);
            LastPlayerData = playerData;
            OnPlayerUpdate.Invoke(); 
        }
    }

    public void SavePlayer(PlayerData player)
    {
        if (player.Equals(LastPlayerData))
        {
            _database.GetReference(PLAYER_KEY).SetRawJsonValueAsync(JsonUtility.ToJson(player));
        }
    }
 
    public async Task<PlayerData?> LoadPlayer()
    {
        var dataSnapshot = await _database.GetReference(PLAYER_KEY).GetValueAsync();
        if (!dataSnapshot.Exists)
        {
            return null;
        }

        return JsonUtility.FromJson<PlayerData>(dataSnapshot.GetRawJsonValue());
    }

    public async Task<bool> SaveExists()
    {
        var dataSnapshot = await _database.GetReference(PLAYER_KEY).GetValueAsync();
        return dataSnapshot.Exists;
    }

    public void EraseSave()
    {
        _database.GetReference(PLAYER_KEY).RemoveValueAsync();
    }
}

public class PlayerUpdateEvent : UnityEvent
{
    
    
}

