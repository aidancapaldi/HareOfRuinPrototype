using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
 
public class ChangeCutScene : MonoBehaviour
{

    public Sprite cutScene2;
    public Sprite cutScene3;
    public Sprite cutScene4;
    public Sprite cutScene5;
    public Sprite cutScene6;
    public Sprite cutScene7;
    public Sprite cutScene8;
    public Sprite cutScene9;
    public Sprite cutscenenew00;
    public Sprite cutscenenew1;
    public Sprite cutscenenew;




    public static bool isCutSceneOver = false;

    public int i = 0;

    public void Start() {
        isCutSceneOver = false;
        i = 0;
    }

    public void Update() {
        //Debug.Log("Running");
        if (Input.GetButtonDown("Fire1")) {
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
                break;
            case 3:
                GetComponent<Image>().sprite = cutScene2;
                i++;
                break;
            case 4:
                GetComponent<Image>().sprite = cutScene3;
                i++;
                break;
            case 5:
                print("cutscene3");
                GetComponent<Image>().sprite = cutScene4;
                i++;
                break;
            case 6:
                GetComponent<Image>().sprite = cutScene5;
                i++;
                break;
            case 7:
                GetComponent<Image>().sprite = cutScene6;
                i++;
                break;
            case 8:
                GetComponent<Image>().sprite = cutScene7;
                i++;
                break;
            case 9:
                GetComponent<Image>().sprite = cutScene8;
                i++;
                break;
            case 10:
                GetComponent<Image>().sprite = cutScene9;
                i++;
                isCutSceneOver = true;
                Invoke("CutSceneOver", 3);

                //i = 0; //Reset it to 0
                break;
            default:
                break;
        }
    }

public void CutSceneOver()
    {
        FindObjectOfType<CutSceneLevelManager>().LoadNextLevel();

    }
}
