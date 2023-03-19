using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// Class which carries logic for spell slot navigation. 
// Pressing keys 1-n changes the Canvas element's icon highlight, and sets the player's spell appropriately.
public class UISpellSlotNavigation : MonoBehaviour
{
    public int HotBarSize => gameObject.transform.childCount;
    private GameObject[] hotBarSlots;
    private Color selectedColor;

    KeyCode[] hotBarKeys;

    // Start is called before the first frame update
    void Start()
    {
        hotBarSlots = GameObject.FindGameObjectsWithTag("HotBarSlot");
        hotBarKeys = new KeyCode[] {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4};
        selectedColor = new Color(1f, 0f, .7f, .6f);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hotBarKeys.Length; i++) {
            if (Input.GetKeyDown(hotBarKeys[i])) {
                UnselectSlots();
                SelectSlot(i);
                return;
            }
        }
    }

    // Unhighlight the spells slots.
    void UnselectSlots() {
        for (int i = 0; i < hotBarKeys.Length; i++) {
            hotBarSlots[i].GetComponent<Image>().color = Color.white;
        }
    }

    // Highlight the given slot.
    void SelectSlot(int whichSlot) {
        hotBarSlots[whichSlot].GetComponent<Image>().color = selectedColor;
    }
}
