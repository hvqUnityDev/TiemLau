using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FirebaseManager : MonoBehaviour
{
    [Header("Firebase")] 
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser user;
    public DatabaseReference DataReference;


    [Header("Login")] 
    public TMP_InputField emailLoginField;    
    public TMP_InputField passLoginField;
    public TMP_Text warmingLoginText;
    public TMP_Text confirmLoginText;

    [Header("Register")]
    
    public TMP_InputField usernameRegisterField;    
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField verifyPasswordRegisterField;
    public TMP_Text warmingRegisterText;

    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.Log($"Fail to initialize Firebase with {dependencyStatus}");
            }
            
        });
    }

    private void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
        DataReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void LoginButton()
    {
        StartCoroutine(Login(emailLoginField.ToString(), passLoginField.ToString()));
    }

    public void RegisterButton()
    {
        StartCoroutine(Register(usernameRegisterField.ToString(), emailRegisterField.ToString(),
            passwordRegisterField.ToString()));
    }

    private IEnumerator Register(string userName, string email, string pass)
    {
        if (userName == "")
        {
            warmingRegisterText.text = "Missing UserName";
        }
        else if(passwordRegisterField.text != verifyPasswordRegisterField.text)
        {
            warmingRegisterText.text = "Missing UserName";
        }
        
        yield break;
    }

    private IEnumerator Login(string email, string pass)
    {
        var loginTask = auth.SignInWithEmailAndPasswordAsync(email, pass);

        yield return new WaitUntil(() => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            Debug.LogWarning(message: $"Fail to register task with {loginTask.Exception}");
            FirebaseException firebaseException = loginTask.Exception.GetBaseException() as FirebaseException;
            AuthError error = (AuthError)firebaseException.ErrorCode;

            string message = "Login Failed";

            switch (error)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "User Not Found";
                    break;
            }

            warmingLoginText.text = message;

        }
        else
        {
            user = loginTask.Result;
            Debug.LogFormat($"User signed in successfully: {user.DisplayName} {user.Email}");
            warmingLoginText.text = "";
            confirmLoginText.text = "Logged in";


            yield return new WaitForSeconds(2);
            Debug.Log("TODO: print data");
        }
    }
}
