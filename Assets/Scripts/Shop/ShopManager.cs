using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;
    public GameObject ShopUI;
    public GameObject ShopItemPrefab; // This component needs to have an ItemSlotUI script
    public List<ItemInfo> ShopItems;

    private ItemInfo activeItem;
    private GuiManager guiManager;

    public ItemInfo ActiveItem { 
        get { return activeItem; }
        set {
            this.activeItem = value;
            RerenderMainItemDisplay(this.activeItem);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        guiManager = GameObject.FindObjectOfType<GuiManager>();
    }

    public void HideShop()
    {
        ShopUI.SetActive(false);
        guiManager.UIsRequiringCursorVisible = Mathf.Clamp(guiManager.UIsRequiringCursorVisible - 1, 0, 2);

        // Make sure that if the tooltip is open when menu is closing, close the tooltip
        GameObject.FindObjectOfType<Tooltip>().HideTooltip(); 
    }

    public void ShowShop()
    {
        guiManager.UIsRequiringCursorVisible = Mathf.Clamp(guiManager.UIsRequiringCursorVisible + 1, 0, 2);
        ShopUI.SetActive(true);
        UpdateCoinText();
        RenderShopItems();
    }

    private void UpdateCoinText()
    {
        var CoinText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<TextMeshProUGUI>().text;
        if (CoinText != null)
        {
            CoinText = FindObjectOfType<InventoryManager>().coins.ToString();
        }
    }

    private void RenderShopItems()
    {
        // Parent of all items (ItemSlotUI's) displayed in the shop
        Transform shopItemsContainer = GameObject.FindGameObjectWithTag("ShopItemsContainer").transform;

        if (shopItemsContainer != null)
        {
            // Destroy all old items before rerender (prevents stale data)
            foreach (Transform child in shopItemsContainer.transform)
            {
                Destroy(child.gameObject);
            }

            // Add all the items specified under the ShopManager game object in the Unity editor
            foreach (ItemInfo item in ShopItems)
            {
                GameObject healthPot = Instantiate(ShopItemPrefab, shopItemsContainer);
                healthPot.GetComponent<ItemSlotUI>().SetInventoryItem(item);
            }
        }
    }

    private void RerenderMainItemDisplay(ItemInfo item)
    {
        // Parent of the selected item that is being displayed in the main panel
        GameObject shopMainItemDisplay = GameObject.FindGameObjectWithTag("ShopMainItemDisplay");
        
        Image displayIcon = 
            shopMainItemDisplay.transform.Find("Row/Item Icon").gameObject.GetComponent<Image>();
        TextMeshProUGUI itemName =
            shopMainItemDisplay.transform.Find("Row/Column/Item Name").gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI itemCost =
            shopMainItemDisplay.transform.Find("Row/Column/Item Cost").gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI itemDescription =
            shopMainItemDisplay.transform.Find("Row/Column/Item Description").gameObject.GetComponent<TextMeshProUGUI>();

        displayIcon.sprite = item?.icon;
        itemName.text = item?.name;
        itemCost.text = item?.value.ToString();
        itemDescription.text = item?.description;
    }

    public void PurchaseActiveItem()
    {
        if (ActiveItem != null)
        {
            if (FindObjectOfType<InventoryManager>().coins >= ActiveItem.value)
            {
                FindObjectOfType<InventoryManager>().coins -= ActiveItem.value;

                ShopItems.Remove(ActiveItem);

                FindObjectOfType<InventoryManager>().Add(ActiveItem);
        
                ActiveItem = null;

                RerenderMainItemDisplay(ActiveItem);
                RenderShopItems();
            }
        }
    }
}
