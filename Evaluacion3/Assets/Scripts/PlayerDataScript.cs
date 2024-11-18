using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataScript
{

    public string playerName;
    public string playerAge;
    public string playerTeam;


    public PlayerDataScript(PlayerDataStruct playerDataStruct)
    {
        playerName = playerDataStruct.playerName;
        playerAge = playerDataStruct.playerAge;
        playerTeam = playerDataStruct.playerTeam;
    }

}


public struct PlayerDataStruct
{
    public string playerName;
    public string playerAge;
    public string playerTeam;

    public PlayerDataStruct(string _PlayerName, string _PlayerAge, string _PlayerTeam)
    {
        playerName = _PlayerName;
        playerAge = _PlayerAge;
        playerTeam = _PlayerTeam;
    }
}
