using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerJoin : MonoBehaviour
{
    private PlayerInputManager manager;
    [SerializeField] List<GameObject> players = new List<GameObject>();
    private int currentPlayer = 0;
    void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        manager.playerPrefab = players[currentPlayer];
    }
    
    public void OnPlayerJoin()
    {
        currentPlayer++;
        manager.playerPrefab = players[currentPlayer];
    }
}
