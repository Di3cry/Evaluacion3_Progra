using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.UI;

public class LoginButtons : MonoBehaviour
{
    public LoginScript loginScript;
    public SaveLoad saveLoad;
    PlayerDataScript playerDataScript;
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public TMP_InputField equipoField;
    public TMP_InputField nameField;
    public TMP_InputField edadField;
    public TextMeshProUGUI mensaje;

    private void Update()
    {
        Debug.Log(AuthenticationService.Instance.PlayerId);
        Debug.Log(AuthenticationService.Instance.PlayerName);
    }
    public void ConexionAnonima()
    {
        loginScript.ConnectAnonymous();
    }

    public void RegistrarUsuario()
    {
        string username = usernameField.text;
        string password = passwordField.text;

        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            loginScript.Register(username, password);
            mensaje.text = $"Registrado Como {username}";
        }
        else
        {
            mensaje.text = "Introduzca Nombre De Usuario y Contraseña";
        }


    }

    public void CerrarSesion()
    {

        loginScript.ClearID();

        mensaje.text = "Saliste De Tu Sesion";
    }



    public void LoginButton()
    {
        string username = usernameField.text;
        string password = passwordField.text;

        loginScript.LoginWithUsernamePassword(username, password, mensaje);
        //if(AuthenticationService.Instance.IsSignedIn)
        //{

        //    mensaje.text = "Logeado como:" + username;
        //}
        //if (!AuthenticationService.Instance.IsSignedIn)
        //{
        //    mensaje.text = "Error Al Iniciar Sesion";
        //}
    }

    public void SaveData()
    {
        SaveLoad saveLoad = new SaveLoad();
        PlayerDataStruct playerData = new PlayerDataStruct(nameField.text, edadField.text, equipoField.text, "", 0, 0);
        saveLoad.SaveData(playerData, "Data");










        loginScript.SaveInfoPlayer("Data", saveLoad.data);


    }

    public void CargarData()
    {
        string keyEquipo = equipoField.name;
        string keyName = nameField.name;
        string keyEdad = edadField.name;

        loginScript.LoadInfoPlayer("Data", GetData);

    }

    void GetData(string data)
    {
        Debug.Log(data);
        string json = data;
        PlayerDataStruct playerDataStruct = JsonUtility.FromJson<PlayerDataStruct>(data);
        equipoField.text = playerDataStruct.playerTeam;
        nameField.text = playerDataStruct.playerName;
        edadField.text = playerDataStruct.playerAge;
    }

}
