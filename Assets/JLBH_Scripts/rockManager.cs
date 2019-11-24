using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockManager : MonoBehaviour
{
    public Transform startTrans;
    public Transform explosionTrans;
    public Transform rockTrans;
    public GameObject rockObj;
    public GameObject explosion;
    Transform exploTrans;
    Vector3 startV;
    Vector3 exploV;

    // Start is called before the first frame update
    void Start()
    {
        exploTrans = explosion.GetComponent<Transform>();
        startV = startTrans.position;
        exploV = explosionTrans.position;
        StartCoroutine("setRock");
    }

    public Vector3 getEndV()
    {
        return exploV;
    }

    public void onExplo()
    {
        StartCoroutine("setExplo");
    }

    IEnumerator setExplo()
    {
        yield return new WaitForSeconds(0.1f);
        explosion.SetActive(true);
        yield return new WaitForSeconds(6f);
        explosion.SetActive(false);
    }

    IEnumerator setRock()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            rockTrans.position = startV;
            rockObj.SetActive(true);
            yield return new WaitForSeconds(4f);
        }
    }
}
