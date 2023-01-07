using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BossHealth : MonoBehaviour
{
    public GameObject cutScene;

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

    private Color color;
    private Color damaged;

    private GameObject player;

    private void Awake()
    {
        material = gameObject.GetComponentInChildren<MeshRenderer>();
        player = GameObject.Find("Player");
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
            gameObject.GetComponent<AtticBoss>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            healthbarUI.SetActive(false);

            player.GetComponent<PlayerAttack>().enabled = false;
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<PlayerMove>().enabled = false;
            cutScene.SetActive(true);
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
