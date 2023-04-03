using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
  public static InventoryManager Instance;
  public List<ItemInfo> Items = new List<ItemInfo>();
  public Transform ItemContent; // the GameObject that holds the item slots (in the Canvas)
  public GameObject InventoryItem;
  public GameObject InventoryUI;
  private GuiManager guiManager;
  private int _coins = 100;

  public int coins {
    get { return _coins; }
    set {
      _coins = value;
      GameObject.FindGameObjectWithTag("CoinText").GetComponent<TextMeshProUGUI>().text = 
        FindObjectOfType<InventoryManager>().coins.ToString();
    }
  }

  private void Awake()
  {
    Instance = this;
  }

  private void Start()
  {
    RerenderInventoryItems();
    guiManager = GameObject.FindObjectOfType<GuiManager>();
  }

  public void Add(ItemInfo item)
  {
    Items.Add(item);
    RerenderInventoryItems();
  }

  public void Remove(ItemInfo item)
  {
    Items.Remove(item);
    RerenderInventoryItems();
  }

  public void RerenderInventoryItems()
  {
    // Clean out inventory previously rendered
    foreach (Transform item in ItemContent)
    {
      Destroy(item.gameObject);
    }

    // Render inventory
    foreach (var item in Items)
    {
      GameObject obj = Instantiate(InventoryItem, ItemContent);
      ItemSlotUI itemSlotBehavior = obj.GetComponent<ItemSlotUI>();
      itemSlotBehavior.SetInventoryItem(item);
    }
  }

  public void ToggleInventory()
  {
    var currentlyActive = InventoryUI.activeSelf;
    if (currentlyActive)
    {
      HideInventory();
    }
    else
    {
      ShowInventory();
    }
  }

  public void ShowInventory()
  {
    InventoryUI.SetActive(true);
    guiManager.UIsRequiringCursorVisible += 1;
    RerenderInventoryItems();
  }

  public void HideInventory()
  {
    InventoryUI.SetActive(false);
    guiManager.UIsRequiringCursorVisible -= 1;
    
    // Make sure that if the tooltip is open when menu is closing, close the tooltip
    GameObject.FindObjectOfType<Tooltip>().HideTooltip(); 
  }
}
