using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustomLogic : MonoBehaviour
{
    public UnityEvent OnGroundTouch;

    void Awake()
    {
        OnGroundTouch = new UnityEvent();
    }
}
