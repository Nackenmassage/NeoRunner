using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Transform Platform;

    private void OnTriggerEnter(Collider plyr)
    {
        if (plyr.CompareTag("Player"))
        {
            Player.position = Platform.position;
        }
    }
}
