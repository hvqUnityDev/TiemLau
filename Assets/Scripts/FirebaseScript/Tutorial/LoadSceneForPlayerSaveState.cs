using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneForPlayerSaveState : MonoBehaviour
{
    [SerializeField] private PlayerSaveManager _playerSaveManager;
    [SerializeField] private Text _sceneForSaveExits;
    [SerializeField] private Text _sceneForNoSave;

    private Coroutine _coroutine;
    
    public void Trigger()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(LoadSceneCoroutine());
        }
    }

    private IEnumerator LoadSceneCoroutine()
    {
        var saveExistsTask = _playerSaveManager.SaveExists();
        yield return new WaitUntil((() => saveExistsTask.IsCompleted));

        if (saveExistsTask.Result)
        {
            _sceneForSaveExits.gameObject.SetActive(true);
        }
        else
        {
            _sceneForNoSave.gameObject.SetActive(true);
        }

        _coroutine = null;
    }
}
