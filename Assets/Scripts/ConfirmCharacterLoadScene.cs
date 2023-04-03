using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Important import for using UI elements
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class ConfirmCharacterLoadScene : MonoBehaviour
{
    public string beginLevel;
    private GameObject btn; 

     void Start() {
        btn = this.gameObject;
        //btn.onClick.AddListener(NoParamaterOnclick);
    }

    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(beginLevel);
        }
    }

    // public void NoParamaterOnclick()
    //  {
    //     SceneManager.LoadScene(beginLevel);
    //  }
}
