using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCondition : MonoBehaviour
{
    [SerializeReference]
    private float health = 0f;
    [SerializeField]
    private float maxHealth = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void UpdateHealth(float mod)
    {
        health -= mod;

        if(health > maxHealth)
        {
            health = maxHealth;
        } else if (health <= 0)
        {
            health = 0f;
        }
    }
}
