using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManage : MonoBehaviour
{

    private int MaxEnemy;
    public int CurrentEnemy;
    public GameObject Parent;
    public GameObject[] Spawners = new GameObject[3];
    public Transform EnemyPrefab;
    public Transform EnemyPrefab2;
    Vector3 originscale;

    // Start is called before the first frame update
    void Start()
    {
        MaxEnemy = 20;
        CurrentEnemy = 1;
        StartCoroutine(Spawn());
        //originscale = EnemyPrefab.transform.localScale;
        Debug.Log(originscale);
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/


    IEnumerator Spawn()
    {
        while (true)
        {
            if (CurrentEnemy < 20)
            {
                int ran = Random.Range(0, 3);
                int enemyType = Random.Range(0, 2);
                Debug.Log("Spawn from " + (ran+1));
                Transform obj;
                if(enemyType == 0)
                    obj = GameObject.Instantiate(EnemyPrefab, Spawners[ran].transform.position, Quaternion.identity);
                else
                    obj = GameObject.Instantiate(EnemyPrefab2, Spawners[ran].transform.position, Quaternion.identity);
                
                //obj.parent = Parent.transform;
                obj.transform.SetParent(Parent.transform, true);
                Debug.Log(obj.localScale);




                CurrentEnemy++;
                yield return new WaitForSeconds(5f);
            }
        }
    }
}
