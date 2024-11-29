using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DecimasData
{
    public string ramo;
    public float decimasDisponibles;
    public float decimasUsadas;

    public DecimasData(DecimasStruct decimasStruct)
    {
        ramo = decimasStruct.ramo;
        decimasUsadas = decimasStruct.decimasUsadas;
        decimasDisponibles = decimasStruct.decimasDisponibles;
    }

}

public struct DecimasStruct
{
    public string ramo;
    public float decimasDisponibles;
    public float decimasUsadas;

    public DecimasStruct(string _ramo, float _decimasDisp, float _decimasUsadas)
    {
        ramo = _ramo;
        decimasDisponibles = _decimasDisp;
        decimasUsadas = _decimasUsadas;
    }
}