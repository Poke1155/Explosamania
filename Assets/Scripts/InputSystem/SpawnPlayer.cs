using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public void Spawn(GameObject player)
    {
        Vector3 spawnPos = new Vector3(0, 0, 0);
        Instantiate(player, spawnPos, Quaternion.identity);
        
    }
}
