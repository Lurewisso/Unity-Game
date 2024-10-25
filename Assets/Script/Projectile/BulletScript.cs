using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var eminem = collision.gameObject.GetComponent<EnemyScript>();
        if (collision.tag == "Enemy")
        {
            eminem.EnemyHp -= 30;
            
            Debug.Log(collision.gameObject.GetComponent <EnemyScript>().EnemyHp);
            if(eminem.EnemyHp <= 0)
            {
                var anim = collision.gameObject.GetComponent<Animator>();
                
                anim.SetTrigger("DeathTrigger");
                eminem.EnemySpeed = 0;
                Destroy(collision.gameObject,2);
                eminem.DropGoods();


                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                EnemySpawner.CountOfZombi += 1;



            }
        }
        Destroy(gameObject);
    }
}