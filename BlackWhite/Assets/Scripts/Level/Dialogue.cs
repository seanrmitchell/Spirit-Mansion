using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public Controller skipText;

    public bool finished;

    [SerializeField]
    private TextMeshProUGUI textComp, speaker;

    [SerializeField]
    private string[] lines, speakers;
    //public float textSpeed;

    private int index;
    [SerializeField] Color playerColor = Color.cyan;
    [SerializeField] Color enemyColor = Color.red;
    [SerializeField] Color neutralColor = Color.white;
    private void Awake()
    {
        skipText = new Controller();
    }

    private void OnEnable()
    {
        skipText.Attack.Enable();
    }

    private void OnDisable()
    {
        skipText.Attack.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        textComp.text = string.Empty;
        speaker.text = string.Empty;

        index = 0;
        SpeakerColor();
        speaker.text = speakers[index];
        textComp.text = lines[index];
    }

    // Update is called once per frame
    void Update()
    {
        skipText.Attack.Primary.performed += _ => NextLine();
    }

    void NextLine()
    {
        if (textComp.text == lines[index])
        {
            index++;
            if (index <= lines.Length - 1)
            {
                SpeakerColor();
                speaker.text = speakers[index];
                textComp.text = lines[index];
            }
            else
            {
                finished = true;
            }
        }
    }

    void SpeakerColor()
    {
        if (!(speakers[index].Equals("Ghost")))
            speaker.color = enemyColor;
        else if (speakers[index].Equals("Ghost"))
            speaker.color = playerColor;
        else
            speaker.color = neutralColor;
    }
}
