using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShuttleShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletInstantiatePoint;
    public float bulletInstantiateIntervalTime;

    private void Start() {
        StartCoroutine(BulletInstantiate());
    }

    IEnumerator BulletInstantiate()
    {
        yield return new WaitForSeconds(bulletInstantiateIntervalTime);
        GameObject bullet = Instantiate(bulletPrefab,bulletInstantiatePoint.transform.position,bulletInstantiatePoint.transform.rotation);
        StartCoroutine(BulletInstantiate());
    }

}
