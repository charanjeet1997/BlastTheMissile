using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public int bulletPower;

    private void Start() {
        bulletPower = Random.Range(2,5);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy")
        {
            EventManager.Instance.OnEnemyHitBulletInvoke(bulletPower,other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
