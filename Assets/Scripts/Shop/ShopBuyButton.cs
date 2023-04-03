using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuyButton : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener
        (
            () => FindObjectOfType<ShopManager>().PurchaseActiveItem()
        );
    }
}
