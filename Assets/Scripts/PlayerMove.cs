using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    [SerializeField]
    private int playerSpeed = 20;
    [SerializeField]
    private float jumpForce = 50;
    [SerializeField]
    bool grounded = true;

    public Transform mainCam;
    Rigidbody rigid;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 20;
        jumpForce = 50;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");
        Vector3 moveDir = new Vector3(inputX, 0, inputY);
        if (moveDir != Vector3.zero)
        {
            // 카메라 방향을 기준으로 moveDir 조정
            Vector3 camDir = mainCam.forward;
            camDir.y = 0;
            camDir = camDir.normalized;
            moveDir = Quaternion.FromToRotation(Vector3.forward, camDir) * moveDir;
            //print(moveDir);
            gameObject.transform.Translate(moveDir * 0.1f * playerSpeed * Time.deltaTime);
        }

        //Jump
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.Space)) //Y
        {
            if (grounded)
            {
                rigid.AddForce(transform.up * jumpForce);
            }
        }
#else
        if (Input.GetKey(KeyCode.JoystickButton3)) //Y
        {
            if (grounded)
            {
                rigid.AddForce(transform.up * jumpForce);
            }
        }
#endif

        // Grounded check
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        int groundedMask = 1 << LayerMask.NameToLayer("Ground");
        if (Physics.Raycast(ray, out hit, 0.7f, groundedMask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

}
