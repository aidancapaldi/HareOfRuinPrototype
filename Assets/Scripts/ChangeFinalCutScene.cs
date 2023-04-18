using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;


public class ChangeFinalCutScene : MonoBehaviour
{

    public Sprite cutscenenew00;
    public Sprite cutscenenew1;
    public Sprite cutscenenew;




    public static bool isCutSceneOver = false;

    public int i = 0;
    public void Start()
    {
        isCutSceneOver = false;
        i = 0;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Invoke("changeImages", 0.1f);
        }
    }

    public void changeImages() // make sure to attach this to event trigger
    {
        //int i = imgNumberCount;
        switch (i)
        {
            case 0:
                GetComponent<Image>().sprite = cutscenenew00;
                i++;
                break;
            case 1:
                GetComponent<Image>().sprite = cutscenenew1;
                i++;
                break;
            case 2:
                GetComponent<Image>().sprite = cutscenenew;
                i++;
                isCutSceneOver = true;
                Invoke("CutSceneOver", 3);
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    public void CutSceneOver()
    {
        FindObjectOfType<CutSceneLevelManager>().LoadNextLevel();

    }
}

