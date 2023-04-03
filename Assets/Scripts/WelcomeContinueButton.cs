using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeContinueButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(HideWelcomePanel);
    }

    void HideWelcomePanel()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
