using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public Item item;
    public Inventory inventory;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
            inventory.AddItem(item); 
    }
}
