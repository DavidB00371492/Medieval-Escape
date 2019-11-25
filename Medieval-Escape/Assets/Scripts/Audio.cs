using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private void Awake()
    {
        //Doesn't destory the object when a new scene is loaded
        DontDestroyOnLoad(transform.gameObject);
    }
}
