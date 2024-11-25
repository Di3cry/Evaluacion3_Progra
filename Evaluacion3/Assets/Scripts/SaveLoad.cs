using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public const string PlayerDataKey = "PlayerDataKey";
    public string data;
    public string dataCargada;
    private void Update()
    {
        Debug.Log(data);

    }
    public void Save()
    {
        
    }
    public void SaveData(PlayerDataStruct playerDataStruct, string _id)
    {

        PlayerDataScript playerDataScript = new PlayerDataScript(playerDataStruct);
        data = JsonUtility.ToJson(playerDataScript);
    }



    //public PlayerDataScript(string _id)
    //{
    //    dataCargada = ;
    //}
}
