public class ShopItemUI : ItemSlotUI
{
  protected override void OnClick()
  {
    ShopManager.Instance.ActiveItem = item;
  }
}

