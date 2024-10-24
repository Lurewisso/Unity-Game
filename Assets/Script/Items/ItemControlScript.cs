using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemControlScript : MonoBehaviour
{
    CharacterStats playerStats;
    public ItemsScript item;
    CharacterAttack character;
    UIScript UI;
    void Start()
    {
        playerStats = FindObjectOfType<CharacterStats>();
        character = FindObjectOfType<CharacterAttack>();
        UI = FindObjectOfType<UIScript>();
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("CONNECT ACTION");
        if (collision.tag == "Player")
        {
            switch (item.itemType)
            {
                case ItemType.ARMOR:
                    CheckMaxStat(ref playerStats.Armor, playerStats.MaxArmor, item.value);

                    break;
                case ItemType.MEDICINE:
                    CheckMaxStat(ref playerStats.Hp, playerStats.MaxHp, item.value);


                    break;
                case ItemType.MONEY:
                    CheckMaxStat(ref playerStats.Money, 999999999, item.value);


                    break;
                case ItemType.BULLETS:
                    var gun = FindGun(character.WeaponList, ItemType.BULLETS);
                    CheckMaxStat(ref gun.MaxAmmo, gun.LimitAmmo, item.value);

                    break;
                case ItemType.ARROWS:
                    gun = FindGun(character.WeaponList, ItemType.ARROWS);
                    CheckMaxStat(ref gun.MaxAmmo, gun.LimitAmmo, item.value);


                    break;
                case ItemType.EXPITEM:
                    LevelUp(item.value);
                    break;
            }


            Debug.Log("Твоё здоровье =" + playerStats.Hp);
        }
    }
    public WeaponScript FindGun(List<WeaponScript> weapons,ItemType itemType)
    {
        foreach (var weapon in weapons)
        {
            if (weapon.bulletType == itemType)
            {
                return weapon;
            }
        }
        return weapons[0];
    }



    public void CheckMaxStat( ref int stat , int MaxStat, int value)
    {
        if (stat >= MaxStat || stat + value >= MaxStat)
        {
            stat = MaxStat;
        }
        else
            stat += value;
            Destroy(gameObject);
        Debug.Log($"{stat} - {MaxStat}");
    }



   
    
        public void LevelUp(int value)

        {
        if (playerStats.Experience >= playerStats.MaxExperience || playerStats.Experience + value >= playerStats.MaxExperience)
        {
            playerStats.Experience += value;
            playerStats.Level++;
            playerStats.Experience -= playerStats.MaxExperience;
            playerStats.MaxExperience = (int)(playerStats.Level * 0.5f * (playerStats.Experience + (playerStats.MaxExperience * 0.1f)));

        }
        else
        {
            playerStats.Experience += value;
            Destroy(gameObject);
        }
            

        UI.ChangeMaxStats(playerStats.MaxExperience);

        }
    
    void UpgradeStats()
    {

        var multiplier = Mathf.Pow(playerStats.Level, 0.3f) * playerStats.MaxHp;
        var multiplierArmor = Mathf.Pow(playerStats.Level, 0.3f) * playerStats.MaxArmor;


        playerStats.MaxHp = (int)multiplier;
        playerStats.MaxArmor = (int)multiplier;

    }
}
