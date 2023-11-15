using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject playerPrefab;
    private GameObject RespawnPoint;
    private GameObject Player;

    public void Start(){
        Player = GameObject.Find("Player(Clone)");
        RespawnPoint = GameObject.Find("Respawn");
    }

    public void FixedUpdate(){
        if(Player == null){
            Debug.Log("Respawn");
            Instantiate(playerPrefab, RespawnPoint.transform.position + Vector3.down *0.5f , Quaternion.identity);
        }
        Player = GameObject.Find("Player(Clone)");
    }
}
