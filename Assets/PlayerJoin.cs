using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerJoin : MonoBehaviour
{
    private PlayerInputManager manager;
    [SerializeField] List<GameObject> players = new List<GameObject>();
    private int currentPlayer = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        manager.playerPrefab = players[currentPlayer];
    }

    // Update is called once per frame
    public void OnPlayerJoin()
    {
        currentPlayer++;
        manager.playerPrefab = players[currentPlayer];
    }
}
