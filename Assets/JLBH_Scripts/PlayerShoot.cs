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
#if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.A))
        {
            a++;
        }
#else
        if (Input.GetKeyUp(KeyCode.JoystickButton0)) //A
        {
            a++;
        }
#endif
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
