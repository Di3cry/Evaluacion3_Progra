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
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
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

        if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password ))
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

       loginScript.LoginWithUsernamePassword(username, password);
    }

    //public void SaveData()
    //{
    //    string key = "player_info";
    //    string value = "Data";
    //}
}
