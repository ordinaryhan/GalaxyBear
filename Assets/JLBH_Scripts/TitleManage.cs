using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManage : MonoBehaviour
{
    void Update()
    {
        //아무키나 누르면 씬 넘어감
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("MainScene");
        }

    }
}
