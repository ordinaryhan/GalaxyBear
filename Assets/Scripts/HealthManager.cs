using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Heart = new GameObject[3];
    private int hitCount;
    
    void Start()
    {
        hitCount = 0;
        for(int i=0; i<3; i++)
        {
            Heart[i].SetActive(true);
        }
    }

    public void Hit()
    {
        Heart[hitCount].SetActive(false);
        hitCount++;
    }

}
