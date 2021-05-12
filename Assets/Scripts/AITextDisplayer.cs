using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITextDisplayer : TextDisplayer
{
    private void Update()
    {
        this.text.text = "" + GameManager.Instance.GLOBAL_AIPOINTS;
    }
}
