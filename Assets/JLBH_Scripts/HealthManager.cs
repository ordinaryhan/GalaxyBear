using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Heart = new GameObject[3];
    private int hitCount;
    private bool hitFlag = false;

    public PauseMenu SceneManager;
    public Transform player;
    
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
        if (hitCount < 3 && !hitFlag)
        {
            hitFlag = true;
            Heart[hitCount].SetActive(false);
            hitCount++;
            if (hitCount >= 3)
                SceneManager.moveMain();
            StartCoroutine("HitAnime");
        }
    }

    IEnumerator HitAnime()
    {
        print("HitAnime");
        Vector3 playerSize = new Vector3(1, 1, 1);
        for (int k = 0; k < 3; k++)
        {
            // 작아지기
            for (int i = 0; i < 8; i++)
            {
                playerSize.x -= 0.01f;
                playerSize.y -= 0.01f;
                playerSize.z -= 0.01f;
                player.localScale = playerSize;
                if (i == 7)
                    player.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.002f);
                player.gameObject.SetActive(true);
            }
            // 커지기
            for (int i = 0; i < 8; i++)
            {
                playerSize.x += 0.01f;
                playerSize.y += 0.01f;
                playerSize.z += 0.01f;
                player.localScale = playerSize;
                if (i == 7)
                    player.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.002f);
                player.gameObject.SetActive(true);
            }
        }
        hitFlag = false;
    }

}
