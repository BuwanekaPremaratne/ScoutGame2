using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Singelton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T instance
    {
        get{
            return _instance;
        }
    }

    public virtual void Awake() 
    {
        _instance=(T)(object)this;
        
        
    }
}
