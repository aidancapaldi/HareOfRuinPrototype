using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTooltipAtDistance : MonoBehaviour
{
    public float toolTipDistance = 10f;
    private GameObject player;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, startPos) > toolTipDistance) {
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
        }
    }
}
