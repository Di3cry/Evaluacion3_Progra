using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Authentication;
using UnityEngine;
using UnityEngine.UI;
public class PanelManager : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelInicioSesion;
    public GameObject panelCrearCuenta;
    public GameObject panelDatos;
    public TMP_InputField InputField;



    public void BotonInicioSesion()
    {
        panelInicio.SetActive(false);
        panelInicioSesion.SetActive(true);
    }

    public void BotonDatos()
    {
        panelInicio.SetActive(false);
        panelDatos.SetActive(true);
    }

    public void BotonCrearCuenta()
    {
        panelInicio.SetActive(false );
        panelCrearCuenta.SetActive(true);
    }
    public void BotonVolver()
    {
        panelCrearCuenta.SetActive(false ) ;
        panelInicioSesion.SetActive(false) ;
        panelDatos.SetActive(false);
        panelInicio.SetActive(true) ;
    }


    public void NombreDeUsuario()
    {
        print(InputField.text);
        Debug.Log(AuthenticationService.Instance.PlayerId);
    }

}
