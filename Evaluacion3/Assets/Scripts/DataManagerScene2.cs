using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataManagerScene2 : MonoBehaviour
{
    public LoginScript loginScript;
    public TMP_InputField ramofield;
    public float decimasUsadas;
    public float decimasDisponibles;
    public TextMeshProUGUI decimasUsadasTxt;
    public TextMeshProUGUI decimasDisponiblesTxt;
    public Cat cat;
    public TextMeshProUGUI decimasObtenidasTxt;
    public float DecimasObtenidas;
    public TMP_InputField usarDecimasfield;
    PlayerDataStruct playerDataStruct;



    private void Update()
    {
        
    }

    public void SaveData2()
    {
        SaveLoad saveLoad = new SaveLoad();
        playerDataStruct = new PlayerDataStruct("", "", "", "",playerDataStruct.decimasDisponibles, playerDataStruct.decimasUsadas);
        saveLoad.SaveData(playerDataStruct, "Decimas");


        loginScript.SaveInfoPlayer("Decimas", saveLoad.data);
    }

    public void CargarData2()
    {
        loginScript.LoadInfoPlayer("Decimas", GetData2);
    }

     void GetData2(string data)
    {
        Debug.Log(data);
        string json = data;
        playerDataStruct = JsonUtility.FromJson<PlayerDataStruct>(json);
        decimasDisponiblesTxt.text = "Decimas Disponibles:" + playerDataStruct.decimasDisponibles.ToString();
        decimasUsadasTxt.text = "Decimas Usadas:" + playerDataStruct.decimasUsadas.ToString();
    }
    public void GastarDecimas()
    {
        Debug.Log(playerDataStruct.decimasDisponibles);
        if(float.TryParse(usarDecimasfield.text, out float decimasAGastar))
        {
            if(decimasAGastar > 0 && decimasAGastar <= playerDataStruct.decimasDisponibles)
            {
              

                    Debug.Log("Decimas:" + playerDataStruct.decimasDisponibles);
                    playerDataStruct.decimasDisponibles -= decimasAGastar;
                    playerDataStruct.decimasUsadas -= decimasAGastar;
                    decimasDisponiblesTxt.text = "Decimas Disponibles: " + playerDataStruct.decimasDisponibles.ToString();
                    decimasUsadasTxt.text = "Decimas Usadas: " + playerDataStruct.decimasUsadas.ToString();
                SaveData2();
                
            }
        }
    }
}
