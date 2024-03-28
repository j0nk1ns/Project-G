using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    
    private float _maxHealth = 100;
    private float _currentHealth;
    [SerializeField] private Image _healthBarFill;
    private Vector3 snakePos;

    // Quaternion spawnRot = Quaternion.Euler(0f, 0f, 0f;);

    void Awake()
    {
        _currentHealth = _maxHealth;
       
       

    }

    void Update()
    {
       
    }

    public void UpdateHealth(float amount)
    {
        _currentHealth += amount;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
   
    {
        float targetFillAmount = _currentHealth / _maxHealth;
        _healthBarFill.fillAmount = targetFillAmount;
    }

    // Void LateUpdate()
    // {
    //   Transform.rotaion = spawnRot;
    // }
    



}
