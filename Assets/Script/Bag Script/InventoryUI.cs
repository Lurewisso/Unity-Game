using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory; 
    public GameObject inventoryPanel;
    public GameObject itemSlotPrefab;
    public Transform itemsParent; 

    private bool isInventoryOpen = false; 

    void Start()
    {
        inventoryPanel.SetActive(false);
        UpdateInventoryUI(); 
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleInventory();
        }
    }


    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen; 
        inventoryPanel.SetActive(isInventoryOpen); 

        if (isInventoryOpen)
        {
            UpdateInventoryUI(); 
        }

    }
    public void UpdateInventoryUI()
    {
     
        foreach (Transform child in itemsParent)
        {
            Destroy(child.gameObject);
        }

        
        foreach (Item item in inventory.items)
        {
            GameObject newSlot = Instantiate(itemSlotPrefab, itemsParent);
            newSlot.GetComponent<Image>().sprite = item.itemIcon;
            newSlot.transform.GetChild(0).GetComponent<Text>().text = item.itemName;
        }
    }
}