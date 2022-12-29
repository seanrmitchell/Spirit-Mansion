using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeReference]
    private float health = 0f;

    [SerializeField]
    private float maxHealth = 3f;

    [SerializeField]
    private GameObject healthbarUI;

    [SerializeField]
    private Slider slider;

    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    public void UpdateHealth(float mod)
    {
        healthbarUI.SetActive(true);
        health -= mod;
        slider.value = CalculateHealth();

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public float CalculateHealth()
    {
        return health / maxHealth;
    }
}
