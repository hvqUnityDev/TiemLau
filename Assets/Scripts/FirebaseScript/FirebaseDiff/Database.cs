// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Firebase;
// using Firebase.Database;
// using Firebase.Extensions;
// using Proyecto26;
// using UnityEngine;
// using UnityEngine.UI;
// //https://tiemlau-cntt9-default-rtdb.asia-southeast1.firebasedatabase.app
// public class Database : MonoBehaviour
// {
//     DatabaseReference reference;
//     public string database_url;
//     [SerializeField] private InputField userName;
//     [SerializeField] private InputField email;
//     [SerializeField] private InputField nameNeed;
//     //[SerializeField] Text data;
//
//     void Start()
//     {
//         FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
//         {
//             reference = FirebaseDatabase.DefaultInstance.RootReference;
//             reference = FirebaseDatabase.DefaultInstance.GetReference(database_url);
//         });
//     }
//     
//     public void savedata()
//     {
//         User user = new User();
//         user.UserName = userName.text;
//         user.Email = email.text;
//         
//     }
//
//     public void Read_Data()
//     {
//         reference.Child("User").Child(nameNeed.text).GetValueAsync().ContinueWith(task =>
//         {
//             if (task.IsCompleted)
//             {
//                 
//                 Debug.Log("successfull");
//                 DataSnapshot snapshot = task.Result;
//                 Debug.Log( snapshot.Child("UserName").Value.ToString());
//                 Debug.Log(snapshot.Child("Email").Value.ToString());
//     
//             }
//             else
//             {
//                 Debug.Log("not successfull");
//             }
//         });
//     }
//
// }
