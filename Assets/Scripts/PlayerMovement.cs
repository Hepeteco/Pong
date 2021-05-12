using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Racket
{
    private bool move;
    
     void FixedUpdate()
    {
        if (move)
        {
            if (Input.GetAxis("Vertical") > 0)
                rb.velocity = new Vector2(0, this.speed);
            else
                rb.velocity = new Vector2(0, -this.speed);
        }
        else
            rb.velocity = Vector2.zero;
    }
    protected override void Update()
    {
        base.Update();
        if (Input.GetButton("Vertical"))
            move = true;
        else
            move = false;
    }
}
