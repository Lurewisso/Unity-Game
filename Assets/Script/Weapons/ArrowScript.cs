using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowScript : MonoBehaviour
{
    CharacterMove characterMove;
    Vector3 shootingDirection;
    CharacterAttack characterAttack;

    void Start()
    {
        characterAttack = FindObjectOfType<CharacterAttack>();

        characterMove = FindObjectOfType<CharacterMove>();

        shootingDirection = characterMove.GetShootingDirection();

        float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;

        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        gameObject.GetComponent<Rigidbody2D>().velocity = shootingDirection * characterAttack.HandleChangeGun().AttackSpeed;

        Destroy(gameObject, 4f);
    }
}