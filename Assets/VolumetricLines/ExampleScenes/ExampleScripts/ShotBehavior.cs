using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

    public GameObject explosion;
    float distance;

    // Use this for initialization

    
    void Start()
    {
        StartCoroutine("destroyBullet");
    }
    // Update is called once per frame
    void Update () {
		transform.position += transform.forward * Time.deltaTime * 10f;
	
	}


    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
           // Destroy(other.gameObject);
            Destroy(this.gameObject);

        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
