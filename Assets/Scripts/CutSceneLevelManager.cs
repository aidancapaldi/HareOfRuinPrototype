using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CutSceneLevelManager : MonoBehaviour
{
    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        ChangeCutScene.isCutSceneOver = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
