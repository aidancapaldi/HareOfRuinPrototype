using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollScript : MonoBehaviour
{

    private bool isScrolling; // We'll use this for debugging
    private float rotation;   // Default 55deg, but read in from canvas

    // Start the scrolling effect on load
    void Start()
    {
        Setup();
    }
    // Set up the initial variables
    void Setup()
    {
        isScrolling = true;
        rotation = gameObject.GetComponentInParent<Transform>().eulerAngles.x;
        Debug.Log("Parent rotation: " + rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for starting or stopping
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    isScrolling = !isScrolling;
        //    Debug.Log("Is Scrolling: " + isScrolling);
        //}
        //// Check if the user wants to quit the application
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Application.Quit();
        //}
        // If we are scrolling, perform update action
        if (isScrolling)
        {
            // Get the current transform position of the panel
            Vector3 _currentUIPosition = gameObject.transform.position;
            //Debug.Log("Current Positon: " + _currentUIPosition);
            // Increment the Y value of the panel 
            Vector3 _incrementYPosition =
             new Vector3(_currentUIPosition.x,
                         _currentUIPosition.y + 0.4f,
                         _currentUIPosition.z);
            // Change the transform position to the new one
            //Debug.Log("New Position: " + _incrementYPosition);
            gameObject.transform.position = _incrementYPosition;
        }

        Invoke("EndCredits", 30);
    }

    public void EndCredits()
    {
        SceneManager.LoadScene("MainMenu");

    }
}

