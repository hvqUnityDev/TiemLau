using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.Events;

public class FirebaseManager2 : MonoBehaviour
{
    private static FirebaseManager2 i;

    public static FirebaseManager2 I => i;


    private FirebaseAuth _auth;

    public FirebaseAuth Auth
    {
        get
        {
            if (_auth == null)
            {
                //_auth = FirebaseAuth.GetAuth(App);
                _auth = FirebaseAuth.DefaultInstance;
            }

            return _auth;
        }
    }


    private FirebaseApp _app;

    public FirebaseApp App
    {
        get
        {
            if (_app == null)
            {
                //_app = GetAppSynchronous();
                _app = FirebaseApp.DefaultInstance;
            }

            return _app;
        }
    }

    public UnityEvent OnFirebaseInitialized = new UnityEvent();

    private async void Awake()
    {
        if (i == null)
        {
            DontDestroyOnLoad(gameObject);
            i = this;

            var dependencyResult = await FirebaseApp.CheckAndFixDependenciesAsync();
            if (dependencyResult == DependencyStatus.Available)
            {
                _app = FirebaseApp.DefaultInstance;
                OnFirebaseInitialized?.Invoke();
            }
            else
            {
                Debug.Log($"Fail to initialize Firebase with {dependencyResult}");
            }
            

        }
    }

    private void OnDestroy()
    {
        _app = null;
        _auth = null;
        if (i == this)
        {
            i = null;
        }
    }
}
