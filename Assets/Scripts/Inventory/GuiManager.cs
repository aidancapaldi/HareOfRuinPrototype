using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiManager : MonoBehaviour
{
    private int _uisRequiringCursorVisible = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject.FindObjectOfType<InventoryManager>().ToggleInventory();
        }
        // else if (Input.GetKeyDown(KeyCode.T))
        // {
        //     GameObject.FindObjectOfType<ShopManager>().ToggleVisible();
        // }
    }

    // Confusing name but basically its the number of UIs that are open that require the cursor to
    // be visible. I.e. if both the inventory and store are open, that is 2 UIs that require the
    // cursor to be visible. If 0 UIs require the cursor to be visible, then we hide the cursor.
    public int UIsRequiringCursorVisible
    {
        get { return _uisRequiringCursorVisible; }
        set {
            _uisRequiringCursorVisible = value;
            if (_uisRequiringCursorVisible == 0)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
