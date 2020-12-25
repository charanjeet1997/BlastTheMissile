using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private void Start() {
        StartCoroutine(DestroyBullet());
    }
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
