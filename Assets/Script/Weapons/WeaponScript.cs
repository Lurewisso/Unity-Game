using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName ="NewWeapon", menuName ="Weapons")]



public class WeaponScript : ScriptableObject
{
    

    
    public int Ammo;
    public int MaxAmmo;
    public int Arrow;
    public int MaxArrow;
    public int LimitAmmo;
    public int Magazine;
    public int Damage;
    public float AttackSpeed;
    public float ReloadSpeed;
    public GunType GunType;
    public GameObject ProjectilePrefab;
    public Sprite sprite;
    public ItemType bulletType;

    private int initialAmmo;
    private int initialMaxAmmo;
    private int initialArrow;
    private int initialMaxArrow;
    private int initialLimitAmmo;
    private int initialMagazine;
    private int initialDamage;
    private float initialAttackSpeed;
    private float initialReloadSpeed;


    protected void SaveInitialValues()
    {
        initialAmmo = Ammo;
        initialMaxAmmo = MaxAmmo;
        initialArrow = Arrow;
        initialMaxArrow = MaxArrow;
        initialMagazine = Magazine;
        initialLimitAmmo = LimitAmmo;
        initialDamage = Damage;
        initialAttackSpeed = AttackSpeed;
        initialReloadSpeed = ReloadSpeed;



    }

    public void ResetValues()
    {
        Ammo = initialAmmo;
        MaxAmmo = initialMaxAmmo;
        Arrow = initialArrow;
        MaxArrow = initialMaxArrow;
        LimitAmmo = initialLimitAmmo;
        Magazine = initialMagazine;
        Damage = initialDamage;
        AttackSpeed = initialAttackSpeed;
        ReloadSpeed = initialReloadSpeed;

    }

    private void OnEnable()
    {
        SaveInitialValues();
    }

    //public void UpdateAmmo()
    //{
       
    //    Ammo = 30;
    //    MaxAmmo = 30;
    //    LimitAmmo = 60;

       
    //}
    //public void UpdateArrow()
    //{
    //    Arrow = 20;
    //    MaxArrow = 60;
    //}
}
