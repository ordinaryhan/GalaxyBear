using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManage : MonoBehaviour
{
    int storyCnt = 0;
    int storyNum = 3;
    public GameObject[] story = new GameObject[3];

    private IEnumerator coroutine;
    
    void Start()
    {
        story[1].SetActive(false);
        story[2].SetActive(false);
        coroutine = showStory();
        StartCoroutine(coroutine);
    }

    IEnumerator showStory()
    {
        while (true)
        {
            storyCnt++;
            if (storyCnt >= storyNum)
                break;
           
            yield return new WaitForSeconds(5);

            story[storyCnt].SetActive(true);
            for(int i=0; i<storyNum; i++)
            {
                if (i != storyCnt)
                    story[i].SetActive(false);
            }
        
        }
    }
}
