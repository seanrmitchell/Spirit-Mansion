using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeReference]
    private MeshRenderer material;

    [SerializeReference]
    private float health = 0f;

    [SerializeField]
    private float maxHealth = 3f;

    [SerializeField]
    private GameObject healthbarUI;

    [SerializeField]
    private Slider slider;

    private Color color;
    private Color damaged;

    private void Awake()
    {
        material = gameObject.GetComponentInChildren<MeshRenderer>();
    }

    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();

        color = material.material.color;
        damaged = new Color(3.5f, 0.6f, 0.6f, 1f);
    }

    public void UpdateHealth(float mod)
    {
        StartCoroutine(Hit());
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

    IEnumerator Hit()
    {
        material.material.SetColor("_Color", damaged);
        yield return new WaitForSeconds(0.25f);
        material.material.SetColor("_Color", color);

    }
}
