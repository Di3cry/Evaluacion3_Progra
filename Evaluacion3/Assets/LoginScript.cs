using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.Core;

public class LoginScript : MonoBehaviour
{
    private void Awake()
    {
        StartService();
    }

    private void Start()
    {
        Debug.Log(AuthenticationService.Instance.PlayerId);
    }

    public async void StartService()
    {
        try
        {
            await UnityServices.InitializeAsync();
            Debug.Log("Conectado A Unity");
        }
        catch
        {
            Debug.LogError("No Se Pudo Conectar a Unity");
        }

    }


    public async void ConnectAnonymous()
    {
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        Debug.Log(AuthenticationService.Instance.PlayerId);
    }

    public async void Register(string _username, string _password)
    {
        try
        {
            await AddUserNamePassAsync(_username, _password);
            await AuthenticationService.Instance.UpdatePlayerNameAsync(_username);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error al registrar: {ex}");
        }
    }

    public void LogOut()
    {
        OnlineSaveSystem.Instance.LogOut();
        Debug.Log("Saliste De La Sesion");
    }

    public void SaveInfoPlayer(string key, string value)
    {
        OnlineSaveSystem.Instance.SaveData(value, key);
    }

    public void LoadInfoPlayer(string key, Action<string> OnDataLoaded)
    {
        OnlineSaveSystem.Instance.LoadDataAsync(OnDataLoaded, key);
    }

    public void ClearID()
    {
        OnlineSaveSystem.Instance.ClearPlayerID();
    }

    public string GetInfo()
    {
        if (OnlineSaveSystem.Instance.IsLoged())
        {
            string playerId = OnlineSaveSystem.Instance.GetPlayerID();
            string playerName = OnlineSaveSystem.Instance.GetUserNameID();
            return $"Player ID: {playerId}, PlayerName: {playerName}";
        }
        return "No Hay Usuario";
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

    public async void LoginWithUsernamePassword(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
            Debug.Log($"Logged in successfully as {username}. Player ID: {AuthenticationService.Instance.PlayerId}");
        }
        catch (AuthenticationException ex)
        {
            Debug.LogError($"Authentication error: {ex}");
        }
        catch (RequestFailedException ex)
        {
            Debug.LogError($"Request failed: {ex}");
        }
    }


}
