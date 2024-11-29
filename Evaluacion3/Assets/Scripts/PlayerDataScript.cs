using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataScript
{

    public string playerName;
    public string playerAge;
    public string playerTeam;
    public string ramo;
    public float decimasDisponibles;
    public float decimasUsadas;


    public PlayerDataScript(PlayerDataStruct playerDataStruct)
    {
        playerName = playerDataStruct.playerName;
        playerAge = playerDataStruct.playerAge;
        playerTeam = playerDataStruct.playerTeam;
        ramo = playerDataStruct.ramo;
        decimasUsadas = playerDataStruct.decimasUsadas;
        decimasDisponibles = playerDataStruct.decimasDisponibles;
    }

}


public struct PlayerDataStruct
{
    public string playerName;
    public string playerAge;
    public string playerTeam;
    public string ramo;
    public float decimasDisponibles;
    public float decimasUsadas;

    public PlayerDataStruct(string _PlayerName, string _PlayerAge, string _PlayerTeam, string _ramo, float _decimasDisp, float _decimasUsadas)
    {
        playerName = _PlayerName;
        playerAge = _PlayerAge;
        playerTeam = _PlayerTeam;
        ramo = _ramo;
        decimasDisponibles = _decimasDisp;
        decimasUsadas = _decimasUsadas;
    }
}
