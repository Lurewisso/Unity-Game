using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>(); 
    public int maxItems = 20; 


    public void AddItem(Item item)
    {
        if (items.Count < maxItems)
        {
            items.Add(item);
            Debug.Log(item.itemName + " добавлен в инвентарь.");
        }
        else
        {
            Debug.Log("Инвентарь полон!");
        }
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log(item.itemName + " удален из инвентаря.");
        }
            else
        {
            Debug.Log("Предмет не найден в инвентаре.");
        }
    }
}