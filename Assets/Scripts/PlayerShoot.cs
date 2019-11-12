using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bullet1;
    public GameObject bullet2;
    public Transform bulletPos;
    public static int count;
    private int a = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bullett());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            a++;
        }
    }

    IEnumerator bullett()
    {
        yield return new WaitForSeconds(0.2f);
        while (true)
        {
            if (a % 2 == 0)
                Instantiate(bullet1, bulletPos.transform.position, bulletPos.transform.rotation);
            else
                Instantiate(bullet2, bulletPos.transform.position, bulletPos.transform.rotation);
            yield return new WaitForSeconds(0.2f);
        }

    }





}
