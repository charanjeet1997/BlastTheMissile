using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Joystick movementJoystick;
    public SpaceShuttleMovement playerPrefab;
    [HideInInspector]public GameObject player;
    public Camera mainCamera;

    private void Awake() {
        instance = this;
    }
    
    public void StartGame()
    {
        if(player == null)
        {
            playerPrefab.movementJoystick = movementJoystick;
            player = Instantiate(playerPrefab.gameObject,transform.position,Quaternion.identity);
        }
    }
}
