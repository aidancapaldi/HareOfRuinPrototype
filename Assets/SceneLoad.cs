using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Loading from intermediate");
        SceneManager.LoadScene(nextLevel);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
