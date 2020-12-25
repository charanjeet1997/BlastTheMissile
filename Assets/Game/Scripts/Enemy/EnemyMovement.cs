using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed = 0.02f;
    public float movementSpeed = 2;
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update() {
        if(player!=null)
        {
            EnemyMovementTowardsPlayer();
        }
        else{
            Destroy(this.gameObject);
        }
    }

    private float CalculateRotationAngle()
    {
        Vector3 difference = (player.transform.position - transform.position);
        float angle = Vector3.SignedAngle(transform.up,difference,transform.forward);
        return angle;
    }

    private void RotateTowardsPlayer()
    {
        transform.Rotate(0,0,CalculateRotationAngle() * rotationSpeed);
    }

    private void EnemyMovementTowardsPlayer()
    {
        RotateTowardsPlayer();
        transform.Translate(transform.up * movementSpeed * Time.deltaTime,Space.World);
    }
}
