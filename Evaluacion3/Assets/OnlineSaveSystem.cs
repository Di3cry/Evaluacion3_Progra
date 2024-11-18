using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.Core;
using UnityEngine;

public class OnlineSaveSystem : MonoBehaviour
{
    public static OnlineSaveSystem Instance;

    private void Awake()
    {
        if( Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void StartService()
    {
        await UnityServices.InitializeAsync();
    }

    public async void ConnectAnonymous()
    {
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        Debug.Log(AuthenticationService.Instance.PlayerId);
    }

    public async void ClearPlayerID()
    {
     
        AuthenticationService.Instance.ClearSessionToken();
        AuthenticationService.Instance.SignOut();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
 
    }

    public string GetPlayerID()
    {
        return AuthenticationService.Instance.PlayerId;
    }

    public string GetUserNameID()
    {
        return AuthenticationService.Instance.PlayerName;
    }

    public bool IsLoged()
    {
        return AuthenticationService.Instance.IsSignedIn;
    }

    public void LogOut()
    {
        AuthenticationService.Instance.SignOut();
    }

    public async void AddUserNamePass(string userName, string password)
    {
        await AddUserNamePassAsync(userName, password);
        await AuthenticationService.Instance.UpdatePlayerNameAsync(userName);
    }

    public async Task<string> AddUserNamePassAsync(string userName, string password)
    {
        try
        {
            await AuthenticationService.Instance.AddUsernamePasswordAsync(userName, password);
            Debug.Log("SignUp is successful.");
            return "SignUp is Succesful";
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
            return ex.ToString();
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
            return ex.ToString();
        }
    }

    public async void SaveData(string _data, string _dataKey)
    {
        var data = new Dictionary<string, object> { { _dataKey, _data } };
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);
    }

    public async void LoadDataAsync(Action<string> OnLoaded, string _dataKey)
    {
        string data = await LoadDataTask(_dataKey);
        OnLoaded?.Invoke(data);
    }

    async Task<string> LoadDataTask(string _dataKey)
    {
        var playerData = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> { "keyName" });
        if (playerData.TryGetValue("keyName", out var keyName))
        {
            return keyName.Value.GetAs<string>();
        }
        return "NULL";
    }


}
