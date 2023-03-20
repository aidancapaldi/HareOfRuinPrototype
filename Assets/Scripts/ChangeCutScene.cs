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




    public int imgNumberCount;


    public void changeImages() // make sure to attach this to event trigger
    {
        switch (imgNumberCount)
        {

         
            case 0:
                GetComponent<Image>().sprite = cutScene2;
                imgNumberCount++;
                break;
            case 1:
                GetComponent<Image>().sprite = cutScene3;
                imgNumberCount++;
                break;
            case 2:
                GetComponent<Image>().sprite = cutScene4;
                imgNumberCount++;
                break;
            case 3:
                GetComponent<Image>().sprite = cutScene5;
                imgNumberCount++;
                break;
            case 4:
                GetComponent<Image>().sprite = cutScene6;
                imgNumberCount++;
                break;
            case 5:
                GetComponent<Image>().sprite = cutScene7;
                imgNumberCount++;
                break;
            case 6:
                GetComponent<Image>().sprite = cutScene8;
                imgNumberCount++;
                break;
            case 7:
                GetComponent<Image>().sprite = cutScene9;
                imgNumberCount++;
                imgNumberCount = 0; //Reset it to 0
                FindObjectOfType<LevelManager>().LoadNextLevel(); 
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }
}
