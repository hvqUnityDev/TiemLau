using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.Events;

//done
public class FirebaseInit : MonoBehaviour
{
    public UnityEvent OnFirebaseInit = new UnityEvent();
    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });
        
        
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {

            if (task.Exception != null)
            {
                Debug.Log($"Failed to init Firebase with {task.Exception}");
                return;
            }
            
            OnFirebaseInit.Invoke();
        });
    }
}
