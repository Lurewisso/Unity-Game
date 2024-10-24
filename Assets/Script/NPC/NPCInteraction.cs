using TMPro;
using UnityEngine;
using UnityEngine.UI; 


public class NPCInteraction : MonoBehaviour
{
    public TextMeshProUGUI interactionText; 
    private bool playerInRange;

    private void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            playerInRange = true;
            interactionText.gameObject.SetActive(true); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            interactionText.gameObject.SetActive(false); 
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E)) 
        {
            
            Debug.Log("Взаимодействие с NPC!");
        }
    }
}

