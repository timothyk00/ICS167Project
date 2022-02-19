using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Timothy Kwon
public sealed class GameManager
{
    private static readonly GameManager _gm = new GameManager();
    private static GameObject[] _players;
    private static bool _singlePlayer = true;

    static GameManager()
    {
        
    }

    private GameManager() { }

    public static GameManager GManager
    {
        get { return _gm; }
    }

    public GameObject[] GetPlayers()
    {
        _players = GameObject.FindGameObjectsWithTag("Player");
        return _players;
    }

    public bool IsSinglePlayer()
    {
        return _singlePlayer;
    }

    public void SwapToMulti()
    {
        _singlePlayer = false;
    }

}
