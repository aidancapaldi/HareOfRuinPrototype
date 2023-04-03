using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerOnSpawn : MonoBehaviour
{
    // On spawn, move player to this position
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").gameObject.transform.position = transform.position;
    }
}
