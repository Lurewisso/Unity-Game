using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public bool canShoot = true;

    public GunType gunType = GunType.Pistol;

    public List<WeaponScript> WeaponList;

    [Header("Melee Attack")]
    [SerializeField] Transform meleeAttackPoint;
    [SerializeField] float meleeAttackRange = 1f;

    [Header("References")]
    [SerializeField] GameObject bulletPref;
    [SerializeField] GameObject ArrowPref;

    CharacterMove playerMove;
    CharacterStats stats;
    UIScript UiScript;
    public bool isReloading = false;
    void Start()
    {
        playerMove = GetComponent<CharacterMove>();
        stats = GetComponent<CharacterStats>();
        UiScript = GetComponent<UIScript>();

        //HandleChangeGun().UpdateAmmo();
        //HandleChangeGun().UpdateArrow();
        


    }
    private void Update()
    {
        HandleChangeGun();
        Reload();
    }
    public void Bullet()
    {
        if (canShoot)
        {
            Instantiate(HandleChangeGun().ProjectilePrefab, transform.position + playerMove.GetShootingDirection(), Quaternion.identity);
            canShoot = false;
            HandleChangeGun().Ammo -= 1;
            
        }
    }
    private void OnDestroy()
    {
        WeaponList.ForEach(weapon => weapon.ResetValues());
    }

   
    //public void Arrow()
    //{
    //    if (canShoot)
    //    {
    //        Instantiate(HandleChangeGun().ProjectilePrefab, transform.position + playerMove.GetShootingDirection(), Quaternion.identity);
    //        canShoot = false;
    //        HandleChangeGun().Arrow -= 1;

    //    }
    //}

    public void Reload()
    {
        
        if (Input.GetKeyDown(KeyCode.R) && HandleChangeGun().Ammo < HandleChangeGun().Magazine)
        {

            StartCoroutine(ReloadCoroutine());
            
        }
        
    }
    IEnumerator ReloadCoroutine()
    {
         if (!isReloading)
        {
            isReloading = true;
            var weapon = HandleChangeGun();
            int difference = weapon.Magazine - weapon.Ammo;
            if (weapon.MaxAmmo > difference)
            {
                weapon.MaxAmmo -= difference;
                weapon.Ammo += difference;
            }
            else
            {
                weapon.Ammo += weapon.MaxAmmo;
                weapon.MaxAmmo = 0;
            }
            yield return new WaitForSeconds(weapon.ReloadSpeed);
            isReloading = false;
        }
    }

    public WeaponScript HandleChangeGun()
    {
        WeaponScript weapon1 = null;
         
        if (Input.GetKeyDown(KeyCode.Alpha1))
            gunType = GunType.Pistol;
            

        

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gunType = GunType.Knife;

        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gunType = GunType.Crossbow;

        }
        foreach (var weapon in WeaponList)
        {
            if (weapon.GunType == gunType)
            {
                weapon1 = weapon;
            }
            
        }
        Debug.Log(gunType);
        return weapon1;
    }


    public void MeleeAttack()
    {
        Collider2D enemy = Physics2D.OverlapCircle(meleeAttackPoint.position, meleeAttackRange);

        if (enemy != null)
            Debug.Log(enemy.name);
        else
            Debug.Log("YA UDARIL");

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(meleeAttackPoint.position, meleeAttackRange);
    }
}









