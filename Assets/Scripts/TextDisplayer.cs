using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TextDisplayer : MonoBehaviour
{
    protected Text text;
    protected virtual void Start()
    {
        text = GetComponent<Text>();
    }
}
