using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletTowardsEnemy : MonoBehaviour
{
    public float overlappingRadius;
    public Collider2D enemyCollider;
    public GameObject target;
    public float rotationSpeed = 0.1f;
    private void Update() {
        GetTarget();
        MoveTowardsTarget();
    }

    private void GetTarget()
    {
        if(target == null)
        {
            enemyCollider = Physics2D.OverlapCircle(transform.position,overlappingRadius,9);
            if(enemyCollider!=null)
            {
                if(enemyCollider.tag == "Enemy")
                    target = enemyCollider.transform.gameObject;
            }
        }
    }

    private float GetAngleTowardsTarget()
    {
        Vector3 directionTowardsEnemy = target.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up,directionTowardsEnemy,transform.forward);
        return angle;
    }
    private void RotateTowardsTarget()
    {
        transform.Rotate(0,0,GetAngleTowardsTarget() * rotationSpeed);
    }

    private void MoveTowardsTarget()
    {
        if(target!=null)
        {
            RotateTowardsTarget();
        }
    }

    private void OnDrawGizmos() {
        //Gizmos.DrawWireSphere(transform.position,overlappingRadius);
    }



}
