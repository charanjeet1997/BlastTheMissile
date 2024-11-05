using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShuttleMovement : MonoBehaviour
{
    public Joystick movementJoystick;
    public float movementSpeed;
    Vector2 movementVector;

    private void Update() {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        // if(Mathf.Abs(movementJoystick.Horizontal) > 0.2f || Mathf.Abs(movementJoystick.Vertical) > 0.2f)
        // {
        //     movementVector = new Vector2(movementSpeed * movementJoystick.Horizontal,movementSpeed * movementJoystick.Vertical);
        //     transform.Translate(movementVector * Time.deltaTime,Space.World);
        // }
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementVector = new Vector2(movementSpeed * horizontal,movementSpeed * vertical);
        transform.Translate(movementVector * Time.deltaTime,Space.World);
    }

    
}
