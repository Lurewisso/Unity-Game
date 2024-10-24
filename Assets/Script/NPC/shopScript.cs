using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using static UnityEditor.Progress;
using UnityEngine.TextCore.Text;
using Unity.VisualScripting.Antlr3.Runtime.Misc;


public class shopScript : MonoBehaviour
{
    //----------------------------------------------------

    public GameObject shopObj;
    bool inShop = false;
    public List<ItemsScript> items;
    public GameObject button;
    CharacterStats stats;
    public Transform parentBtn;
    CharacterAttack character;
    ItemControlScript itemControlscript;

  

    //----------------------------------------------------

    void Start()
    {
        character = FindObjectOfType<CharacterAttack>();
        stats = FindObjectOfType<CharacterStats>();
        itemControlscript = FindObjectOfType<ItemControlScript>();

    }

    void Update()
    {
        OpenShop();
      
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" )
        {
            inShop = true;
            
            Debug.Log("press e to pay ");
        }
        

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        
            inShop = false;
            shopObj.SetActive(false);
        
        ClearItems();

        
    }



    void OpenShop()
    {
        if (Input.GetKeyDown(KeyCode.E) && inShop)
        {
            shopObj.SetActive(true);
            GenerateItems();
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && inShop)
        {
            {
                shopObj.SetActive(false);
                ClearItems();
            }
        }
        
    }
    private void OnButtonClick(int index)
    {
       
        if (stats.Money >= items[index].cost)
        {
            switch (items[index].itemType)
            {
                case ItemType.ARMOR:
                    itemControlscript.CheckMaxStat(ref stats.Armor, stats.MaxArmor, items[index].value);

                    break;
                case ItemType.MEDICINE:
                    itemControlscript.CheckMaxStat(ref stats.Hp, stats.MaxHp, items[index].value);
                    break;


                case ItemType.BULLETS:
                    var gun = itemControlscript.FindGun(character.WeaponList, ItemType.BULLETS);
                    itemControlscript.CheckMaxStat(ref gun.MaxAmmo, gun.LimitAmmo, items[index].value);


                    break;
                case ItemType.ARROWS:
                    gun = itemControlscript.FindGun(character.WeaponList, ItemType.ARROWS);
                    itemControlscript.CheckMaxStat(ref gun.MaxAmmo, gun.LimitAmmo, items[index].value);

                    break;

            }
            stats.Money -= items[index].cost;


        }
    }

    void GenerateItems()
    {
        var index = items.Count;
        for (int i = 0; i< index; i++)
        {
            var a = Instantiate(button, parentBtn);

            a.GetComponentInChildren<TMP_Text>().text = items[i].cost.ToString();
            a.GetComponentInChildren<Image>().sprite = items[i].sprite;
            int bntIndex = i;

            a.GetComponent<Button>().onClick.AddListener(() => { OnButtonClick(bntIndex); });
        }
        
        
            

        
    }

    public void ClearItems()
    {
        int a = parentBtn.childCount;
        while(a > 0)
        {
            Destroy(parentBtn.GetChild(a - 1).gameObject);
            a--;
        }
    }
}
