using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private float maxHealth = 100;
    private float currentHealth;
    [SerializeField] private Image healthBarFill;
    //[SerializeField] private GameController gameController;
    [SerializeField] private float damageAmount,  healthAmount;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            TakeDamage(damageAmount);
        }
        else if (collision.CompareTag("Health"))
        {
            Heal(healthAmount);
            collision.gameObject.SetActive(false);
        }
    }

    private void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth=Mathf.Clamp(currentHealth, 0, maxHealth);
        
        if (currentHealth == 0 ) 
        {
          //gameController.Die();
        }
        UpdateHealthBar();
    }

    private void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf. Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }


    public void UpdateHealthBar()
    {       
        healthBarFill.fillAmount = currentHealth / maxHealth;
    }


}

