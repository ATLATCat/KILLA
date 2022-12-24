using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteClickEventTrigger : MonoBehaviour
{
    public UnityEvent onMouseDown;
    public UnityEvent onMouseUp;


    private void OnMouseDown()
    {
        onMouseDown.Invoke();
    }

    private void OnMouseUp()
    {
        onMouseUp.Invoke();
    }
}
