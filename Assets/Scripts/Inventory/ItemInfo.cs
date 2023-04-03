using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory Item/Create New Item")]
public class ItemInfo : ScriptableObject
{
  public string id; // i.e. "health pot"
  new public string name;
  public int value;
  public Sprite icon;
  public string description;
}
