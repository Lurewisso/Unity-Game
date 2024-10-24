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
            Debug.Log(item.itemName + " �������� � ���������.");
        }
        else
        {
            Debug.Log("��������� �����!");
        }
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log(item.itemName + " ������ �� ���������.");
        }
            else
        {
            Debug.Log("������� �� ������ � ���������.");
        }
    }
}