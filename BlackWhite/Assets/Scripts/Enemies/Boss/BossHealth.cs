using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BossHealth : MonoBehaviour
{
    public bool destroyed = false;

    [SerializeReference]
    private float health = 0f;

    [SerializeField]
    private float maxHealth = 10f;

    [SerializeField]
    private GameObject healthbarUI;

    [SerializeField]
    private Slider slider;

    [SerializeReference]
    private MeshRenderer material;

    [SerializeField]
    private Color color, damaged;

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
        health -= mod;
        slider.value = CalculateHealth();

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            Debug.Log("Boss is Defeated!");
            healthbarUI.SetActive(false);
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
