//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using static UnityEngine.Random;
//using Random = UnityEngine.Random;

//public class EnemyScript : MonoBehaviour
//{
//    //----------------------------------------------------
//    public int EnemyMaxHp { get; set; }
//    public int EnemyHp { get; set; }
//    public int EnemyDamage { get; set; }
//    public int EnemySpeed { get; set; }
//    //----------------------------------------------------

//    float distanceToPlayer;

//    public GameObject player;
//    //----------------------------------------------------

//    float chaseDistatnce = 5f;

//    float attackDistatnce = 0.7f;

//    float roamingDistance = 10f;

//    float roamRadius = 10;


//    //----------------------------------------------------

//    ZombieState currentState = ZombieState.Roaming;

//    //----------------------------------------------------

//    Vector2 roamPoint;
//    Vector2 vector;
//    //----------------------------------------------------
//    Animator animator;
//    Animator animatorEnemy;

//    //----------------------------------------------------





//    public enum ZombieState
//    {
//        Roaming,
//        Chasing,
//        Attacking
//    }
    

//    void Start()
//    {
//        EnemyHp = EnemyMaxHp;
//        EnemyDamage = 25;
//        EnemySpeed = 1;
//        player = GameObject.FindGameObjectWithTag("Player");
//        roamPoint = transform.position;
//        animator = GetComponent<Animator>();
//    }

    
//    void Update()
//    {
        
//        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

//        SwitchState(distanceToPlayer);

//        switch (currentState)
//        {
 
//            case ZombieState.Roaming:
//                ZombieRoaming();

//                break;

//            case ZombieState.Chasing:
//                ZombieChasing();

//                break;

//            case ZombieState.Attacking:
//                ZombieAttacking();

//                break;


//        }

//    }

//    void SwitchState(float distanceToPlayer)
//    {
//        if(distanceToPlayer < attackDistatnce)
//        {
//            currentState = ZombieState.Attacking;

//        }
//        else if (distanceToPlayer <chaseDistatnce)
//        {
//            currentState = ZombieState.Chasing;
//        }
//        else

//            currentState = ZombieState.Roaming;
        
//    }

//    void ZombieChasing()
//    {
//        animator.SetBool("isAttacking", false);
//        vector = player.transform.position - gameObject.transform.position;

//        AnimatorSetData(vector);
//        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, EnemySpeed * Time.deltaTime);


//    }
    
//    void ZombieRoaming()
//    {

//        transform.position = Vector2.MoveTowards(transform.position, roamPoint, EnemySpeed * Time.deltaTime);
//        vector = (Vector3)roamPoint - gameObject.transform.position;
//        AnimatorSetData(vector);
//        if (Vector2.Distance(transform.position,roamPoint)< 0.1f)
//        {
//            roamPoint = GetRandomPoint();
//        }

//    }
    
//    void ZombieAttacking()
//    {
       
//        animator.SetBool("isAttacking", false);


//    }


//    Vector2 GetRandomPoint()
//    {
//        return (Vector2)transform.position + Random.insideUnitCircle * roamRadius;

//    }

//    void AnimatorSetData(Vector3 vector)
//    {
        

//        animator.SetFloat("eX",vector.x);
//        animator.SetFloat("eY",vector.y);
//    }
//    void Roam()
//    {

//    }
//}






using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    public int EnemyMaxHp { get; set; } = 100;
    public int EnemyHp { get; set; }
    public int EnemyDamage { get; set; }
    public int EnemySpeed { get; set; }
    float distanceToPlayer;
    GameObject player;

    public List<GameObject> items;

    float chaseDistance = 5f;
    float attackDistance = 1.5f;
    //float roamingDistance = 10f;
    float roamRadius = 10;

    Vector2 roamPoint;
    ZombieState currentState = ZombieState.Roaming;

    Animator animator;
    Vector2 vector;
    CharacterStats characterStats;  
    public enum ZombieState
    {
        Roaming,
        Chasing,
        Attacking
    }


    void Start()
    {
        EnemyHp = EnemyMaxHp;
        EnemyDamage = 5;
        EnemySpeed = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        roamPoint = transform.position;
        animator = GetComponent<Animator>();
        characterStats = FindObjectOfType<CharacterStats>();
       
    }

    void Update()
    {
        
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        SwitchState(distanceToPlayer);
        //AnimatorSetData();

        switch (currentState)
        {

            case ZombieState.Roaming:
                ZombieRoaming();
                break;
            case ZombieState.Chasing:
                ZombieChasing();
                break;
            case ZombieState.Attacking:
                ZombieAttacking();
                break;

        }

    }

    void SwitchState(float distanceToPlayer)
    {
        if (distanceToPlayer < attackDistance)
            currentState = ZombieState.Attacking;
        else if (distanceToPlayer < chaseDistance)
            currentState = ZombieState.Chasing;
        else
            currentState = ZombieState.Roaming;

    }

    private void ZombieAttacking()
    {
        animator.SetBool("isAttacking", true);
    }

    private void ZombieChasing()
    {
        animator.SetBool("isAttacking", false);

        vector = player.transform.position - gameObject.transform.position;
        AnimatorSetData(vector);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, EnemySpeed * Time.deltaTime);
    }

    private void ZombieRoaming()
    {
        transform.position = Vector2.MoveTowards(transform.position, roamPoint, EnemySpeed * Time.deltaTime);
        vector = (Vector3)roamPoint - gameObject.transform.position;
        AnimatorSetData(vector);

        if (Vector2.Distance(transform.position, roamPoint) < 0.1f)
            roamPoint = GetRandomPoint();
    }

    Vector2 GetRandomPoint()
    {
        return (Vector2)transform.position + Random.insideUnitCircle * roamRadius;
    }

    void AnimatorSetData(Vector3 vector)
    {

        //animator.SetFloat("eY", vector.y);
        //animator.SetFloat("eX", vector.x);


        double yy = vector.y;
        double xx = vector.x;
        xx = xx > 0 ? Math.Ceiling(xx) : Math.Floor(xx);
        xx = yy > 0 ? Math.Ceiling(yy) : Math.Floor(yy);
        animator.SetFloat("eY", (float)yy);
        animator.SetFloat("eX", (float)xx);


    }

    public void Attack()
    {

        if (distanceToPlayer < attackDistance) {
            Debug.Log(characterStats.Hp + " __________________________");
            if (characterStats.Armor >= EnemyDamage)
                characterStats.Armor -= EnemyDamage;

            else { 
                characterStats.Hp -= Math.Abs(characterStats.Armor - EnemyDamage) ;
                characterStats.Armor = 0;
            }
        }


        if (characterStats.Hp <= 0)
            SceneManager.LoadScene(1);


        //if (distanceToPlayer < attackDistance)
        //{
        //    characterStats.Hp -= EnemyDamage;
        //}
        //else
        //    characterStats.Hp -= EnemyDamage;
        //if (characterStats.Hp < 0)
        //    SceneManager.LoadScene(1);
    }

    public void DropGoods()
    {
        
        var randomCount = Random. Range(1, 4);

        for (int i = 0; i < randomCount; i++)
        {
            var randomItem = Random.Range(0, items.Count);
            Instantiate(items[randomItem], GetRandomInradius(transform.position,2),Quaternion.identity);
        }
        
    }
    public Vector2 GetRandomInradius(Vector3 centerPoint, float radius)
    {
        return centerPoint + (Random.insideUnitSphere * radius);
    }
}