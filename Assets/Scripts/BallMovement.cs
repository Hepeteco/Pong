using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private float initialSpeed;
    public float ballSpeed;
    public int ballAcceleration;
    private Rigidbody2D rb;
    private int hit = 0;

    IEnumerator DelayLaunch()
    {
        Vector2 direction = (Random.value < 0.5f) ? Vector2.right : Vector2.left;
        yield return new WaitForSeconds(2f);
        rb.velocity = direction * initialSpeed;

    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        initialSpeed = ballSpeed;
    }

    private void Update()
    {
        if (!GameManager.Instance.GLOBAL_STARTED)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                GameStart();
        }

        GameManager.Instance.GLOBAL_BALLPOS = transform.position;

        if (GameManager.Instance.GLOBAL_GOAL)
        {
            ballSpeed = 0;
            hit = 0;
            rb.velocity = Vector2.zero;
        }
        else
            ballSpeed = initialSpeed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "LeftRacket":
                RacketSpeedSet(col, 1);
                break;

            case "RightRacket":
                RacketSpeedSet(col, -1);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "PlayerGoal":
                GameManager.Instance.GLOBAL_AIPOINTS++;
                GameManager.Instance.GLOBAL_GOAL = true;
                break;

            case "AIGoal":
                GameManager.Instance.GLOBAL_PLAYERPOINTS++;
                GameManager.Instance.GLOBAL_GOAL = true;
                break;
        }
    }

    private void GameStart()
    {        
        GameManager.Instance.GLOBAL_STARTED = true;
        Vector2 direction = (Random.value < 0.5f) ? Vector2.right : Vector2.left;
        rb.velocity = direction * initialSpeed;

    }

    public void LaunchBallWithDelay(Vector2 pos)
    {
        transform.position = pos;
        StartCoroutine(DelayLaunch());
    }

    private float HitDirection(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    private void RacketSpeedSet(Collision2D col, int ballDirectionX)
    {
        hit++;
        float ballY = HitDirection(transform.position, col.transform.position, col.collider.bounds.size.y);
        Vector2 dir = new Vector2(ballDirectionX, ballY).normalized;
        rb.velocity = dir * (ballSpeed + (hit * ballAcceleration));
    }
}
