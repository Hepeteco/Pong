using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTextDisplayer : TextDisplayer
{
    private void Update()
    {
        this.text.text = "" + GameManager.Instance.GLOBAL_PLAYERPOINTS;
    }
}
