using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTestScript : MonoBehaviour
{

    public GameObject laserPrefab;
    Vector3 startPos;
    //public Transform player;
    float laserCountDown;
    float laserTimes;
    public float laserTimesValue = 3;
    public float laserCountValue = 20;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4) && laserTimes > 0)
        {
            laserTimes -= 1;
            DropLaserCarrot();

        }

        //player = GameObject.FindGameObjectWithTag("Player").transform;
        if (laserTimes <= 0)
        {
            laserCountDown -= Time.deltaTime;
        }
        if(laserCountDown <= 0)
        {
            laserTimes = laserTimesValue;
            laserCountDown = laserCountValue;
        }
       
    }

    public void DropLaserCarrot()
    {
        startPos = transform.position;
        Vector3 newPos = transform.position;
        newPos.x = startPos.x - 2;
        Instantiate(laserPrefab, newPos, transform.rotation);

    }
}
