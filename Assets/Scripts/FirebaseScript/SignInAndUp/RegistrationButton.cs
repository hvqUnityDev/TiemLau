using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RegistrationButton : MonoBehaviour
{
    [SerializeField] private RegistrationUIFlow _registrationUIFlow;
    [SerializeField] private Button _registrationButton;

    private Coroutine _registrationCoroutine;
    public UserRegisteredEvent OnUserRegistered = new UserRegisteredEvent();
    //public UserRegistrationFailedEvent OnUserRegistrationFailed = new UserRegistrationFailedEvent();

    private void Reset()
    {
        _registrationUIFlow = FindObjectOfType<RegistrationUIFlow>();
        _registrationButton = FindObjectOfType<Button>();
    }

    private void Start()
    {
        _registrationUIFlow.OnStateChanged.AddListener((state) => HandleRegistrationStateChanged(_registrationUIFlow.CurrentState));
        _registrationButton.onClick.AddListener(HandleRegistrationButtonClicked);

        UpdateInteractable();
    }

    private void OnDestroy()
    {
        _registrationUIFlow.OnStateChanged.RemoveListener((state) => HandleRegistrationStateChanged(_registrationUIFlow.CurrentState));
        _registrationButton.onClick.RemoveListener(HandleRegistrationButtonClicked);
    }

    private void UpdateInteractable()
    {
        _registrationButton.interactable =
            _registrationUIFlow.CurrentState == State.Ok && _registrationCoroutine == null;
    }

    private void HandleRegistrationStateChanged(State registrationState)
    {
        UpdateInteractable();
    }

    private void HandleRegistrationButtonClicked()
    {
        _registrationCoroutine = StartCoroutine(RegisterUser(_registrationUIFlow.Email, _registrationUIFlow.Password));
        UpdateInteractable();
    }

    private IEnumerator RegisterUser(string email, string password)
    {
        var _auth = FirebaseAuth.DefaultInstance;
        var registerTask = _auth.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => registerTask.IsCompleted);

        if (registerTask.Exception != null)
        {
            Debug.LogWarning($"Fail to register task with {registerTask.Exception}");
        }
        else
        {
            Debug.Log($"Successfully registered user {registerTask.Result.Email}");
            OnUserRegistered.Invoke(registerTask.Result);
        }
        
        
        _registrationCoroutine = null;
        UpdateInteractable();
    }

    [Serializable]
    public class UserRegisteredEvent : UnityEvent<FirebaseUser>
    {
        
    }
    
}
