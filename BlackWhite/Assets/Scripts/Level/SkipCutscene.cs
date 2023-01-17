using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class SkipCutscene : MonoBehaviour
{ 
    public Controller playerInput;

    private PlayableDirector currentDirector;

    private float newSkipTime;

    private bool sceneSkipped;

    private void Awake()
    {
        playerInput = new Controller();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public void Update()
    {
        if(!sceneSkipped)
            playerInput.CutsceneSkip.Skip.performed += _ => Skip();
    }

    private void Skip()
    {
        Debug.Log("Skipped!");
        currentDirector.time = newSkipTime;
        sceneSkipped = true;
    }

    public void GetDirector(PlayableDirector director)
    {
        sceneSkipped = false;
        currentDirector = director;
    }

    public void GetSkipTime(float skipTime)
    {
        newSkipTime = skipTime;
    }
}
