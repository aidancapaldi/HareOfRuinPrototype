using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
  public ItemInfo item;
  void Pickup()
  {
    InventoryManager.Instance.Add(item);
    Destroy(gameObject);
  }

  // Uncomment for testing
  // private void OnMouseDown()
  // {
  //   Pickup();
  // }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      Pickup();
    }
  }
}
