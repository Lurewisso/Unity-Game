using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new item", menuName ="Items")]
public class ItemsScript : ScriptableObject
{
    public ItemType itemType;
    public new string name;
    public int value;
    public int cost;
    public Sprite sprite;
    public GameObject itemPrefab;
   
}
