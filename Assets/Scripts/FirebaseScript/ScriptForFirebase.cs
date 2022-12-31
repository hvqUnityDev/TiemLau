using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Firebase.Database;
using Newtonsoft.Json;
using Proyecto26;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Object = System.Object;
using Random = UnityEngine.Random;

public enum ConstValue
{
    GROUP_NHAN_VIEN
}

public class ScriptForFirebase : MonoBehaviour
{
    
    public UnityEvent OnFirebaseUpdate = new UnityEvent();
    //public Text txtScore;
    //public InputField inputUserName;
    //public InputField inName;
    //public InputField inEmail;
    //public InputField inPass;

    [SerializeField] private Player Player;
    
    public static int dDiamond;
    public static int dMoney;
    public static int dCoSo;
    public static int dPhucVu;
    public static int dThucAn;
    public static int dSachDaoTao;
    public static int dTheLuc;
    public static string strName;
    
    
    public static string email = "EMAIL"; //co @ thi ko put len firebase duoc
    
    private string url = "https://tiemlau-cntt9-default-rtdb.asia-southeast1.firebasedatabase.app/";
    private string authKey = "AIzaSyAefYIP32m2SC9qyMdIqHGeTRxUBFppI2w";
    
    private DatabaseReference reference;

    private PlayerToPost currentPlayerToPost;
    
    //public static string localID;
    //private string idToken;
    
    private void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        
        //OnFirebaseUpdate.AddListener(HandleFirebaseUpdate);
        //OnFirebaseUpdate.Invoke();
    }

    void HandleFirebaseUpdate()
    {
        Player.GetPlayerFromFirebase();
    }

    private void OnDestroy()
    {
        //OnFirebaseUpdate.RemoveListener(HandleFirebaseUpdate);
    }

    public void OnSubmit()
    {
        PostToDatabase();
    }

    public void OnGetData()
    {
        StartCoroutine(RetrieveFromDatabase());
        //Player.OnSetDataFromDB?.Invoke();
    }
    
    private void PostToDatabase(bool full = false)
    {
        PlayerToPost playerToPost = new PlayerToPost();
        string json = JsonUtility.ToJson(playerToPost);
        json = EditJsonToAddMore(json, playerToPost);
        Debug.Log(json);
        
        reference.Child("Players").Child(email).SetRawJsonValueAsync(json).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("successfully added data to firebase");
            }
            else
            {
                Debug.Log("not successfull");
            }
        });
    }

    private string EditJsonToAddMore(string json, PlayerToPost playerToPost)
    {
        string s = Json_AddGroupNhanVien(playerToPost);
        string floor_0 = $", \"{ConstValue.GROUP_NHAN_VIEN}\":{{" + s + "}";
        return json.Insert(json.Length - 1, floor_0);
    }

    private string Json_AddGroupNhanVien(PlayerToPost playerToPost)
    {
        string result = "";
        foreach (var kvp in playerToPost.GroupsNhanVien)
        {
            // ten group
            string floor_2 = "";
            foreach (var item in kvp.Value.NhanVien)
            {
                string floor_3_0 = $"\"IsUnlock\":{item.Value.IsUnLock.ToString().ToLower()}";  
                string float_3_1 = floor_3_0 + $",\"Level\":{item.Value.Level.ToString()}";
                //TODO: AddMoreInfo

                floor_2 += "\"" + item.Key + "\":{" + float_3_1 +"},";  
            }

            //floor_2.Remove(floor_2.Length - 2, 2);
            string floor_1 = " \"" + kvp.Key + "\": {"  +  floor_2  + "},";

            result += floor_1;
        }
        
        //result.Remove(result.Length - 2, 1);
        return result;
    }

    private string AddOneValue_WithString(string key, string str)
    {
        return $"\"{key}\":\"{str}\"," ;
    }

    private IEnumerator PostToDatabase(string nameNV)
    {
        var DBTask = reference.Child("Players").Child(email).Child("NV").SetValueAsync(nameNV);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database username is now updated
        }
    }

    private IEnumerator RetrieveFromDatabase()
    {
        var DBTask = reference.Child("Players").Child(email).GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else if (DBTask.Result.Value == null)
        {
            //No data exists yet
            Debug.Log("Default data");
            strName = "Player 1";
            dDiamond = 0;
            dMoney = 0;
            dCoSo = 0;
            dPhucVu = 0;
            dThucAn = 0;
            dSachDaoTao = 0;
            dTheLuc = 0;
        }
        else
        {
            DataSnapshot snapshot = DBTask.Result;
            
            bool isTry = int.TryParse(snapshot.Child("dDiamond").Value.ToString(), out dDiamond);
            bool isTry1 = int.TryParse(snapshot.Child("dMoney").Value.ToString(), out dMoney);
            bool isTry2 = int.TryParse(snapshot.Child("dCoSo").Value.ToString(), out dCoSo);
            bool isTry3 = int.TryParse(snapshot.Child("dPhucVu").Value.ToString(), out dPhucVu);
            bool isTry4 = int.TryParse(snapshot.Child("dThucAn").Value.ToString(), out dThucAn);
            bool isTry5 = int.TryParse(snapshot.Child("dSachDaoTao").Value.ToString(), out dSachDaoTao);
            bool isTry6 = int.TryParse(snapshot.Child("dTheLuc").Value.ToString(), out dTheLuc);

            StartCoroutine(GetData_GROUP_NHAN_VIEN(snapshot));
            
            
            //TODO: GetMoreData
            strName = snapshot.Child("strName").Value.ToString();
                
            if (!isTry || !isTry1 || !isTry2 || !isTry3 || !isTry4 || !isTry5 || !isTry6 || strName == "")
            {
                Debug.Log("convert not success");
                //Debug.Log($"{isTry}{isTry1}{isTry2}{isTry3}{isTry4}{isTry5}{isTry6} - {strName}");
            }
            else
            {
                Debug.Log("convert success");
                Player.OnSetDataFromDB?.Invoke();
            }
        }
        
    }
    public static Dictionary<string, ListNVToPost>  GroupsNhanVien { get; private set; }

    private IEnumerator GetData_GROUP_NHAN_VIEN(DataSnapshot snapshot)
    {
        GroupsNhanVien = new Dictionary<string, ListNVToPost>();
        string n = snapshot.Child(ConstValue.GROUP_NHAN_VIEN.ToString()).GetRawJsonValue();
        var dictionary = JsonConvert.DeserializeObject<Dictionary<string, ListNVToPost>>(n);

        foreach (var kvp in dictionary)
        {
            ListNVToPost list = new ListNVToPost();
            list.NhanVien = new Dictionary<string, InfNVToPost>();
            string n1 = snapshot.Child(ConstValue.GROUP_NHAN_VIEN.ToString()).Child(kvp.Key).GetRawJsonValue();
            var dictionary1 = JsonConvert.DeserializeObject<Dictionary<string, InfNVToPost>>(n1);
            
            foreach (var v in dictionary1)
            {
                //Debug.Log($"v:{v.Key} : {v.Value.IsUnLock} - {v.Value.Level}");
                InfNVToPost inf = new InfNVToPost();
                inf.Level = v.Value.Level;
                inf.IsUnLock = v.Value.IsUnLock;
                list.NhanVien.Add(v.Key, inf);
            }
            
            GroupsNhanVien.Add(kvp.Key, list);
        }

        yield return null;
    }

    /*
     *private int dDiamond;
    private int dMoney;
    private int dCoSo;
    private int dPhucVu;
    private int dThucAn;
    private int dSachDaoTao;
    private int dTheLuc;
    private string strName;
     * 
     */


    #region Sign in and Sign up

    // public void OnSignUp()
    // {
    //     SignUpUser(inName.ToString(), inEmail.ToString(), inPass.ToString());
    // }
    //
    // public void OnSignIn()
    // {
    //     SignInUser(inEmail.ToString(), inPass.ToString());
    // }
    
    // private void SignUpUser(string name,string email, string password)
    // {
    //     string userData = "{\"email\":\""+email+ "\", \"password\":"+password+"\",\"returnSecureToken\":true}";
    //     
    //     RestClient.Post<SignResponse>("https://www.googleapis.com/identitytoolkit/v3/relyingparty/signupNewUser?key="+authKey, userData)
    //     .Then(
    //         respone =>
    //         {
    //             localID = respone.localID;
    //             idToken = respone.IDToken;
    //             playerName = name;
    //             PostToDatabase(true);
    //
    //         }).Catch(error =>
    //     {
    //         Debug.Log(error);
    //     });
    // }
    //
    // private void SignInUser(string email, string password)
    // {
    //     string userData = "{\"email\":\""+email+ "\", \"password\":"+password+"\",\"returnSecureToken\":true}";
    //     
    //     RestClient.Post<SignResponse>("https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key="+authKey, userData)
    //         .Then(
    //             respone =>
    //             {
    //                 localID = respone.localID;
    //                 idToken = respone.IDToken;
    //             }).Catch(error =>
    //         {
    //             Debug.Log(error);
    //         });
    // }
    
    #endregion
}
