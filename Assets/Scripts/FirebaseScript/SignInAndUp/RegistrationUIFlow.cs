using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RegistrationUIFlow : MonoBehaviour
{
    [SerializeField] private TMP_InputField _emailField;
    [SerializeField] private TMP_InputField _passField;
    [SerializeField] private TMP_InputField _verifyPassField;
    
    public State CurrentState { get; private set; }
    public StateChangedEvent OnStateChanged = new StateChangedEvent();

    public string Email => _emailField.text;
    public string Password => _passField.text;

    private void Start()
    {
        _emailField.onValueChanged.AddListener(HandleValueChanged);
        _passField.onValueChanged.AddListener(HandleValueChanged);
        _verifyPassField.onValueChanged.AddListener(HandleValueChanged);
        ComputeState();
        
        OnStateChanged.AddListener(VoidStateChanged);
    }

    private void Update()
    {
        Debug.LogError($"the current State: {CurrentState}");
    }

    private void HandleValueChanged(string _)
    {
        ComputeState();
    }

    private void ComputeState()
    {
        if (string.IsNullOrEmpty(_emailField.text))
        {
            SetState(State.EnterEmail);
        }
        else if (string.IsNullOrEmpty(_passField.text))
        {
            SetState(State.EnterPassword);
        }
        else if (_passField.text != _verifyPassField.text)
        {
            SetState(State.PasswordsDontMatch);
        }
        else
        {
            SetState(State.Ok);
        }
    }

    private void SetState(State state)
    {
        this.CurrentState = state;
        OnStateChanged?.Invoke(state);
    }
    
    void VoidStateChanged(State state)
    {
        Debug.Log($"CurrentState = {state}");
    }
    
    public class StateChangedEvent : UnityEvent<State>
    {
        
    }
    
    
}

public enum State
{
    EnterEmail,
    EnterPassword,
    PasswordsDontMatch,
    Ok
}


