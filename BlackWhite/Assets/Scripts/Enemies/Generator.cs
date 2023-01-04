using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    public bool destroyed;

    public AudioSource sound;
    public AudioSource death;

    [SerializeField] private MeshFilter current;
    [SerializeField] private Mesh desired;

    [SerializeReference]
    private float health = 0f;

    [SerializeField]
    private float maxHealth = 3f;

    [SerializeField]
    private GameObject healthbarUI;

    [SerializeField]
    private Slider slider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player Attack" && !destroyed)
        {
            UpdateHealth(other.GetComponent<BoltFunction>().damage);
            
        }
    }

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
            current.mesh = desired;

            sound.Stop();
            death.Play();

            healthbarUI.SetActive(false);
        }
    }

    public float CalculateHealth()
    {
        return health / maxHealth;
    }
}
