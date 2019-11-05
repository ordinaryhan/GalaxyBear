using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int playerSpeed;
    bool grounded;
    Rigidbody rigid;
    public float jumpForce;
    public LayerMask groundedMask;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 6;
        jumpForce = 20;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");
        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * playerSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        //Jump
        if (Input.GetKey(KeyCode.JoystickButton3)) //Y
        {
            if (grounded)
            {
                rigid.AddForce(transform.up * jumpForce);
            }
        }

        // Grounded check
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
    void FixedUpdate()
    {
        // Apply movement to rigidbody
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + localMove);
    }

}
