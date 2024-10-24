using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterAnimator : MonoBehaviour
{
    Animator animator;
    CharacterAttack characterAttack;
    CharacterMove CharacterMove;
    float idleMoveX;
    float idleMoveY;


    


    void Start()
    {
        animator = GetComponent<Animator>();
        characterAttack = GetComponent<CharacterAttack>();
        CharacterMove = GetComponent<CharacterMove>();
       
    }

    void Update()
    {
        HandleAnimation();
        HandleAttack();

    }

    void Animate(float moveX, float moveY, int layer)
    {
        switch (layer)
        {
            case 0:
                animator.SetLayerWeight(0, 1);
                animator.SetLayerWeight(1, 0);
                break;

            case 1:
                animator.SetLayerWeight(1, 1);
                animator.SetLayerWeight(0, 0);
                break;
        }
        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);

    }
    void HandleAnimation()
    {
        if (CharacterMove.moveDirection != Vector2.zero)
        {
            Animate(CharacterMove.moveX, CharacterMove.moveY, 1);
            idleMoveX = CharacterMove.moveX;
            idleMoveY = CharacterMove.moveY;
        }
        else
        {
            Animate(idleMoveX, idleMoveY, 0);
        }
    }
    void HandleAttack()
    {

        if (Input.GetMouseButtonDown(0) && characterAttack.canShoot && characterAttack.gunType == GunType.Pistol && characterAttack.HandleChangeGun().Ammo > 0 && !characterAttack.isReloading)
        {
            animator.SetFloat("ShootX", CharacterMove.GetShootingDirection().x);
            animator.SetFloat("ShootY", CharacterMove.GetShootingDirection().y);
            animator.SetBool("IsAttack", true);
            
        }
        else if (Input.GetMouseButtonDown(0) && characterAttack.canShoot && characterAttack.gunType == GunType.Knife)
        {
            animator.SetFloat("ShootX", CharacterMove.GetShootingDirection().x);
            animator.SetFloat("ShootY", CharacterMove.GetShootingDirection().y);
            animator.SetTrigger("Melee");
            characterAttack.MeleeAttack();
        }
        //else if (Input.GetMouseButtonDown(0) && characterAttack.canShoot && characterAttack.gunType == GunType.Crossbow)
        //{
        //    animator.SetFloat("ShootX", CharacterMove.GetShootingDirection().x);
        //    animator.SetFloat("ShootY", CharacterMove.GetShootingDirection().y);
        //    //animator.SetBool("IsAttackCrossBow", true);
        //    animator.SetBool("IsAttack", true);

        //}
        else if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("IsAttack", false);
            characterAttack.canShoot = true;
        }

    }

}
