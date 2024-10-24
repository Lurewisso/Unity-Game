using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    CharacterStats stats;
    CharacterAttack characterAttack;
   
    [Header("Bars")]
    [SerializeField] Slider hpBar;
    [SerializeField] Slider armorBar;
    [SerializeField] Slider expBar;

    [Header("Stats")]
    [SerializeField] TMP_Text lvlText;
    [SerializeField] TMP_Text ammoText;


    [SerializeField] TMP_Text arrowText;


    //[SerializeField] TMP_Text maxAmmoText;
    [SerializeField] TMP_Text moneyText;

    
    
    // Start is called before the first frame update
    void Start()
    {
        stats = FindObjectOfType<CharacterStats>();
        characterAttack = FindObjectOfType<CharacterAttack>();
    }

    // выполняется каждый кадр и он лучше чем фиксед апдейт
    void Update()
    {
        InitializeStats();
    }
   void InitializeStats()
    {
       

        hpBar.value = stats.Hp;
        armorBar.value = stats.Armor;
        expBar.value = stats.Experience;
        lvlText.text = stats.Level.ToString();
        //lvlText.text = " " + stats.Level;
        ammoText.text = characterAttack.HandleChangeGun().Ammo + "/" + characterAttack.HandleChangeGun().MaxAmmo;

        if (characterAttack.HandleChangeGun().Magazine == 0)
            ammoText.text = "";
        else
            ammoText.text = characterAttack.HandleChangeGun().Ammo + "/" + characterAttack.HandleChangeGun().MaxAmmo;


        //arrowText.text = characterAttack.HandleChangeGun().Arrow + "/" + characterAttack.HandleChangeGun().MaxArrow;

        moneyText.text = "$ " + stats.Money;

    }
    public void ChangeMaxStats(int value)
    {
        expBar.maxValue = value;
        hpBar.maxValue = stats.MaxHp;
        armorBar.maxValue = stats.MaxArmor;
    }
}
