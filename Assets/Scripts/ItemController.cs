using System;
using System.Collections.Generic;
using UnityEngine;

class ItemController : MonoBehaviour
{
  Dictionary<string, Action> itemActions = new Dictionary<string, Action>();
  private static ItemController _instance;

  // Definitions for all item actions
  public ItemController()
  {
    RegisterItemAction("Health Potion", HealPlayer);
  }

  // Make the given action (void function) run after the item with the given ID is clicked
  public void RegisterItemAction(string id, Action action)
  {
    itemActions.Add(id, action);
  }

  public void RunAction(string id)
  {
    // Look up and run action
    itemActions[id]();
  }

  private void HealPlayer()
  {
    FindObjectOfType<BunnyHealthNew>().Heal(50);
  }
}