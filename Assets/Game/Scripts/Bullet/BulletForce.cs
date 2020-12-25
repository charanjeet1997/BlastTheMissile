using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForce : MonoBehaviour
{
    public float bulletTravelSpeed;
   
    private void Update() {
        if(GameManager.instance.player != null)
        {
            transform.Translate(transform.up * Time.deltaTime * bulletTravelSpeed,Space.World);     
        }
        else{
            Destroy(this.gameObject);
        }
    }
}
