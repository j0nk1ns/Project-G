using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggeable : MonoBehaviour
{
    Vector2 difference = Vector2.zero; 

    Rigidbody2D playerRb;
    Vector2 mousePos;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        // playerRb.MovePosition((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference);

        playerRb.velocity = ((Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position) * 10;
    }

    void Update()
    {
        // mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
        
        //transform.position = mousePos;
    }

    void FixedUpdate()
    {
        // playerRb.AddForce(mousePos * 1.0f, ForceMode2D.Force);
    }
}
