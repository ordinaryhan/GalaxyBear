using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //public Transform player;
    public float movePower = 1f;
    int movementFlag = 0;

    int MoveSpeed = 1;
    int MaxDist = 5;
    int MinDist = 4;
    bool removeFlag = false;

    Vector3 position;


    void Start()
    {
        position = (12) * Random.onUnitSphere;
        //player = GameObject.Find("player2").GetComponent<Transform>();

        StartCoroutine("ChangeMovement");
        //nav = GetComponent<NavMeshAgent>();
    }

    //void Update()
    //{
    //    nav.SetDestination(player.position);
    //}

    void FixedUpdate()
    {
        if (!removeFlag)
            Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        
        if (movementFlag==1)
        {
            moveVelocity = Vector3.left;
            
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementFlag == 2)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementFlag == 3)
        {
            moveVelocity = Vector3.up;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementFlag == 4)
        {
            moveVelocity = Vector3.forward;
        }

        else if(movementFlag == 5)
        {
            moveVelocity = Vector3.one;
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    /*
    void Update()

    {
        //transform.LookAt(position);
    
        //transform.LookAt((11) * Random.onUnitSphere);
        //transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        //transform.position = (11) * Random.onUnitSphere;
        //transform.LookAt(player);

        //if (Vector3.Distance(transform.position, player.position) >= MinDist)

        //{

        //    transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        //    if (Vector3.Distance(transform.position, player.position) <= MaxDist)

        //    {

        //        //Here call any function you want Like Shoot at here or something

        //    }
        //    else

        //    {

        //        transform.position = (11) * Random.onUnitSphere;
        //        Debug.Log("siiiiiiiiibaaaaaaaaaaaa");
        //    }
        }
        */

    IEnumerator ChangeMovement()
    {
        while(true)
        {
            movementFlag = Random.Range(0, 6);
            float time = Random.Range(2f, 5f);
            yield return new WaitForSeconds(time);
        }
    }

    public void setDestroy()
    {
        if (!removeFlag)
        {
            removeFlag = true;
            Animator ani = GetComponent<Animator>();
            ani.SetInteger("animation", 6);
            Destroy(gameObject, 2f);
        }
    }

}
