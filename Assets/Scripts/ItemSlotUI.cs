using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ItemSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
  protected ItemInfo item;
  protected Tooltip tooltip;

  void Start()
  {
    // Populate info for the item slot
    TextMeshProUGUI itemName = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    Image itemIcon = transform.GetChild(1).GetComponent<Image>();
    itemName.text = item.name;
    itemIcon.sprite = item.icon;

    // Defines behavior for when user clicks on an item
    gameObject.GetComponent<Button>().onClick.AddListener(OnClick);

    tooltip = GameObject.FindObjectOfType<Tooltip>();
  }

  protected abstract void OnClick();

  public void OnPointerEnter(PointerEventData eventData)
  {
    tooltip.ShowTooltip(item);
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    tooltip.HideTooltip();
  }

  public void SetInventoryItem(ItemInfo item)
  {
    this.item = item;
  }
}

