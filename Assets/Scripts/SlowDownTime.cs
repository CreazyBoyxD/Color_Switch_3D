using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTime : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            GameManager.instance.SetSlowTimeScale();
        }
    }
}
