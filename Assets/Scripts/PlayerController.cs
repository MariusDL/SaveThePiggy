using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;

    float xInput;

    Vector2 newPosition;

    public float moveSpeed;

    public float xPositionLimit;

    Vector3 mousePos;

    float touchInput;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    private void FixedUpdate()
    {
        //MovePlayer();
        MovePlayerTouch();
    }


    void MovePlayer()
    {

        xInput = Input.GetAxis("Horizontal");

        
        newPosition = transform.position;

 

        newPosition.x += xInput*moveSpeed;

        newPosition.x = Mathf.Clamp(newPosition.x, -xPositionLimit, +xPositionLimit);

        rb.MovePosition(newPosition);

    }

    void MovePlayerTouch()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }

        newPosition = transform.position;


        newPosition.x += touchInput * moveSpeed;

        newPosition.x = Mathf.Clamp(newPosition.x, -xPositionLimit, +xPositionLimit);

        // rb.MovePosition(newPosition);
        rb.MovePosition(new Vector2(Mathf.Clamp(mousePos.x, -xPositionLimit, +xPositionLimit), transform.position.y));
    }



}
