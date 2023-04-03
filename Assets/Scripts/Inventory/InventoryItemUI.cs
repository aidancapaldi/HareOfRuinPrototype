public class InventoryItemUI : ItemSlotUI
{
  // Use item
  protected override void OnClick()
  {
    try {
      FindObjectOfType<ItemController>().RunAction(item.id);
    } finally {
      Destroy(gameObject);
      FindObjectOfType<Tooltip>().HideTooltip();
    }
  }
}