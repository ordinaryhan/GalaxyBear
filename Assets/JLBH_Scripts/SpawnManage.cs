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
    void Update()
    {
        
    }


    IEnumerator Spawn()
    {
        while (true)
        {
            if (CurrentEnemy < 20)
            {
                int ran = Random.Range(0, 3);
                Debug.Log("Spawn from " + (ran+1));
                Transform obj = GameObject.Instantiate(EnemyPrefab, Spawners[ran].transform.position, Quaternion.identity);
                //obj.localScale = new Vector3(0.04f, 0.04f, 0.04f);
                //obj.parent = Parent.transform;
                obj.transform.SetParent(Parent.transform, true);

                //obj.localScale = new Vector3(0.04f, 0.04f, 0.04f);

                Debug.Log(obj.localScale);




                CurrentEnemy++;
                yield return new WaitForSeconds(5f);
            }
        }
    }
}
