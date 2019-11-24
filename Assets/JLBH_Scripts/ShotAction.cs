using UnityEngine;
using System.Collections;

public class ShotAction : MonoBehaviour {
    
    public GameObject explosion;
    float distance;
    Animator ani;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(destroyBullet());
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
            other.gameObject.GetComponent<MoveEnemy>().SMG.scoreUP();
            ani = other.gameObject.GetComponent<Animator>();
            ani.SetInteger("animation", 6);
            Instantiate(explosion, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<MoveEnemy>().setDestroy();
            //Destroy(other.gameObject, 2.5f);
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
