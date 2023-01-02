using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerCondition : MonoBehaviour
{
    public GameOver gameOver;

    [SerializeReference]
    private float health = 0f;
    [SerializeField]
    private float maxHealth = 3f;

    [SerializeField]
    private GameObject healthbarUI;

    [SerializeField]
    private Slider slider;

    private bool meleeCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }



    public void UpdateHealth(float mod)
    {
        health -= mod;
        slider.value = CalculateHealth();

        if (health > maxHealth)
        {
            health = maxHealth;

        } else if (health <= 0)
        {
            health = 0f;
            gameOver.DetermineGameOver();
        }
    }

    private float CalculateHealth()
    {
        return health / maxHealth;
    }
}
