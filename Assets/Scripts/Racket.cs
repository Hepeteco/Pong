using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Racket : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField]
    protected float speed;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        float y = Mathf.Clamp(transform.position.y, -3.5f, 3.5f);
        transform.position = new Vector2(transform.position.x, y);
    }
}
