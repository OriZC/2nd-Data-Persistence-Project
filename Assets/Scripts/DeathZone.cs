using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public MainManager mainManager;
 
    public void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        mainManager.GameOver();
    }
}
