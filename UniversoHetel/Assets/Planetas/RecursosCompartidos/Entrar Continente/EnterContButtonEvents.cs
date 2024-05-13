using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterContButtonEvents : MonoBehaviour
{

    public static event Action<bool> AcceptEnter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void YesEnter()
    {
        AcceptEnter?.Invoke(true);
    }

    public void NoEnter()
    {
        AcceptEnter?.Invoke(false);
    }

}
