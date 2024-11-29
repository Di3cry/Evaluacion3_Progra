using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManagerScene2 : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelInfoRamo;
    public GameObject panelContrasenaProfesor;
    string clave = "CR7";
    public TMP_InputField InputField;
    public GameObject Ui;
    public DataManagerScene2 dataManagerScene2;


    public void InfoRamo()
    {
        panelInicio.SetActive(false);
        panelInfoRamo.SetActive(true);
    }

    public void Clave()
    {
        panelInfoRamo.SetActive(false);
        panelContrasenaProfesor.SetActive(true);
    }

    public void Volver()
    {
        panelInfoRamo.SetActive(false);
        panelContrasenaProfesor.SetActive(false);
        panelInicio.SetActive(true);
    }

    public void Jugar()
    {
        if (InputField.text == clave)
        {
            SceneManager.LoadScene("RaspeGenerator");
            //panelContrasenaProfesor.SetActive(false) ;
            //Ui.SetActive(true);
            //dataManagerScene2.DecimasObtenidas = .5f;
            //dataManagerScene2.decimasObtenidasTxt.text = dataManagerScene2.decimasObtenidasTxt.text + dataManagerScene2.DecimasObtenidas;

        }
    }
    public void Volver2()
    {
        SceneManager.LoadScene("Ramos");
    }

    

}
