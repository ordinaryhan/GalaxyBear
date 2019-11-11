using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public Transform player;
    int MoveSpeed = 2;
    float MaxDist = 11.5f;
    float MinDist = 1.2f;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        transform.LookAt(player);
        if (distance >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }
}
