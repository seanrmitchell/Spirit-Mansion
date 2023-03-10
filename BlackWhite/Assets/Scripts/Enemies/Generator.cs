using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    public bool destroyed = false;

    public AudioSource sound;
    public AudioSource death;

    [SerializeField] private MeshFilter current;
    [SerializeField] private Mesh desired;
    [SerializeReference] private MeshRenderer material;

    [SerializeReference]
    private float health = 0f;

    [SerializeField]
    private float maxHealth = 3f;

    [SerializeField]
    private GameObject healthbarUI;

    [SerializeField]
    private Light pointLight;

    [SerializeField]
    private Slider slider;

    private Color color;
    private Color damaged;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player Attack" && !destroyed)
        {
            UpdateHealth(other.GetComponent<BoltFunction>().damage);
        }
    }

    private void Awake()
    {
        material = gameObject.GetComponentInChildren<MeshRenderer>();
    }

    private void Start()
    {

        // Sets health
        health = maxHealth;
        slider.value = CalculateHealth();

        // Sets colors
        color = material.material.color;
        damaged = new Color(3.5f, 0.6f, 0.6f, 1f);
    }

    public void UpdateHealth(float mod)
    {
        if (!destroyed)
        {
            // Starts a hit effect changing color
            StartCoroutine(Hit());
            healthbarUI.SetActive(true);

            // Health subtracted by damage taken
            health -= mod;

            // Changes slider to current health
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
                pointLight.intensity = 0.5f;
            }
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
