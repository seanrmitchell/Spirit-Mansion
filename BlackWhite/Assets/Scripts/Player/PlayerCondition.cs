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
    private float damageCooldown;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack" )
        {
            UpdateHealth(other.gameObject.GetComponent<BoltFunction>().damage);
        }
        else if (other.gameObject.tag == "Enemy" && !meleeCooldown)
        {
            Debug.Log("Melee Damage Cooldown!");
            UpdateHealth(1);
            meleeCooldown = true;
            StartCoroutine(Cooldown(damageCooldown));
        }
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

    private IEnumerator Cooldown(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            meleeCooldown = false;
        }
    }
}
