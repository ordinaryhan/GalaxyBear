using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRock : MonoBehaviour
{
    public rockManager RMG;
    public int rockSpeed = 5;
    Transform rockTrans;
    Vector3 endPoint;
    Vector3 rayDir;
    int groundedMask;

    // Start is called before the first frame update
    void Start()
    {
        endPoint = RMG.getEndV();
        rockTrans = GetComponent<Transform>();
        groundedMask = 1 << LayerMask.NameToLayer("Ground");
        rayDir = - rockTrans.right;
    }

    void Update()
    {
        float step = rockSpeed * Time.deltaTime;
        rockTrans.position = Vector3.MoveTowards(rockTrans.position, endPoint, step);
        // Grounded check
        Ray ray = new Ray(rockTrans.position, rayDir);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 0.3f, groundedMask))
        {
            RMG.onExplo();
            gameObject.SetActive(false);
        }
    }

 }
