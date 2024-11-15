using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelInicioSesion;
    public GameObject panelCrearCuenta;
    public TMP_InputField InputField;



    public void BotonInicioSesion()
    {
        panelInicio.SetActive(false);
        panelInicioSesion.SetActive(true);
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
        panelInicio.SetActive(true) ;
    }


    public void NombreDeUsuario()
    {
        print(InputField.text);
    }

}
