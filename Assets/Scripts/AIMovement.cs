using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : Racket
{
    protected override void Update()
    {
        base.Update();
        if (transform.position.y + 1f < GameManager.Instance.GLOBAL_BALLPOS.y)
            rb.velocity = new Vector2(0, this.speed);
        else if (transform.position.y - 1f > GameManager.Instance.GLOBAL_BALLPOS.y)
            rb.velocity = new Vector2(0, -this.speed);
        else
            rb.velocity = Vector2.zero;   
    }
}
