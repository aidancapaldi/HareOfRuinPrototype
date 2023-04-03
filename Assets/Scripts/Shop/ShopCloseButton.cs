using UnityEngine;
using UnityEngine.UI;

public class ShopCloseButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(CloseShop);
    }

    void CloseShop()
    {
        FindObjectOfType<ShopManager>().HideShop();
    }
}
