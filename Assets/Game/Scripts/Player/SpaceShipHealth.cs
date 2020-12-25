using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShipHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public Image healthFillAmount;

    private void Start() {
        currentHealth = maxHealth;
    }
    private void OnCollisionEnter2D(Collision2D other) {
       // Debug.Log(other.gameObject.name);
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log(currentHealth/maxHealth);
            currentHealth -= 20;
            healthFillAmount.fillAmount = currentHealth/maxHealth;
            Destroy(other.gameObject); 
            if(currentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnDestroy() {
        StartMenu.instance.OnPlayerDestroy();
    }

}
