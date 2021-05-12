using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected GameManager() { }

    public Vector2 GLOBAL_BALLPOS;
    public int GLOBAL_PLAYERPOINTS;
    public int GLOBAL_AIPOINTS;
    public bool GLOBAL_STARTED;

    public bool GLOBAL_GOAL;
    private Vector2 ballPos;
    public GameObject ballObject;
    public BallMovement ballReference;

    public GameObject initialText;
    IEnumerator ExecuteLaunchAfterTime()
    {
        GLOBAL_GOAL = false;
        ballObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        ballObject.SetActive(true);
        ballReference.LaunchBallWithDelay(ballPos);
    }

    IEnumerator PhaseInitialText()
    {
        while(!GLOBAL_STARTED)
        {
            initialText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            initialText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            
        }
        
    }

    private void Awake()
    {
        if (!GLOBAL_STARTED)
            StartCoroutine(PhaseInitialText());
        initialText.SetActive(true);
        ballPos = ballObject.transform.position;
        ballReference = ballObject.GetComponent<BallMovement>();
    }
    private void FixedUpdate()
    {
        if(GLOBAL_STARTED)
        {
            StopCoroutine(PhaseInitialText());
            initialText.SetActive(false);
        }

        if (GLOBAL_GOAL)
            StartCoroutine(ExecuteLaunchAfterTime());
        else
            StopCoroutine(ExecuteLaunchAfterTime());
    }
}
