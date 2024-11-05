using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private Rigidbody2D rigidbody;
    public void MoveBullet(Vector3 direction)
    {
        rigidbody.AddForce(direction * moveSpeed);
    }
}
