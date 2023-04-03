using UnityEngine;
using UnityEngine.UI;

public class InventoryCloseButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(CloseInventory);
    }

    void CloseInventory()
    {
        FindObjectOfType<InventoryManager>().HideInventory();
    }
}
