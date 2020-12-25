using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEdgeBordersConstraints : MonoBehaviour
{
    public Camera mainCamera;
    GameObject player;
    float xposition, yposition;
    private void Start()
    {
        mainCamera = Camera.main;
        player = this.transform.gameObject;
        Debug.Log(mainCamera.orthographicSize * Screen.width / Screen.height);
    }
    private void Update()
    {
        if (player != null)
        {
            xposition = Mathf.Clamp(player.transform.position.x, mainCamera.orthographicSize * Screen.width / Screen.height * -1, mainCamera.orthographicSize * Screen.width / Screen.height);
            yposition = Mathf.Clamp(player.transform.position.y, mainCamera.orthographicSize * -1, mainCamera.orthographicSize);
            player.transform.position = new Vector3(xposition, yposition, 0);
        }

    }
}
