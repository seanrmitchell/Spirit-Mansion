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

    [SerializeReference]
    private MeshRenderer material;

    private Color color;
    private Color damaged;

    private void Awake()
    {
        material = gameObject.GetComponentInChildren<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();

        color = material.material.color;
        damaged = new Color(5f, 0.6f, 0.6f, 1f);
    }



    public void UpdateHealth(float mod)
    {
        StartCoroutine(Hit());
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

    IEnumerator Hit()
    {
        material.material.SetColor("_Color", damaged);
        yield return new WaitForSeconds(0.25f);
        material.material.SetColor("_Color", color);

    }
}
