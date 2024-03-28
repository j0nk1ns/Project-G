using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _currentHealth;
    [SerializeField] private Image _healthBarFill;
    //[SerializeField] private GameController gameController;
    [SerializeField] private float _damageAmount,  _healthAmount;


    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            TakeDamage(_damageAmount);
        }
        else if (collision.CompareTag("Health"))
        {
            Heal(_healthAmount);
            collision.gameObject.SetActive(false);
        }
    }

    private void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        _currentHealth=Mathf.Clamp(_currentHealth, 0, _maxHealth);
        
        if (_currentHealth == 0 ) 
        {
           // _gameController.Die();
        }
        UpdateHealthBar();
    }

    private void Heal(float amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf. Clamp(_currentHealth, 0, _maxHealth);
        UpdateHealthBar();
    }


    public void UpdateHealthBar()
    {       
        _healthBarFill.fillAmount = _currentHealth / _maxHealth;
    }


}

