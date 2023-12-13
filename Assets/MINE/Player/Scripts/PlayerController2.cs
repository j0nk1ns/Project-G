using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed;
	public bool rushing = false;
	private float speedMod = 0;

	float timeLeft = 2f;

	private Rigidbody2D rigidbody2d;
    private Rigidbody2D myRigidbody;

	public GameObject bubbles;

    float horizontal; 
    float vertical;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");


            Debug.Log (transform.childCount);

        resetBoostTime ();
		controllerManager (); 
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + moveSpeed * horizontal * Time.deltaTime;
        position.y = position.y + moveSpeed * vertical * Time.deltaTime;


        rigidbody2d.MovePosition(position);
    }


   void controllerManager ()
    {
	
		if(Input.GetButtonDown("Jump") && !rushing )
        {
			rushing = true;
			speedMod = 2;
			Instantiate (bubbles, gameObject.transform.position, gameObject.transform.rotation);
			movePlayer ();
		}	
	}

	void movePlayer()
	{
		if (transform.localScale.x == 1)  
        {
			myRigidbody.velocity = new Vector3 (moveSpeed + speedMod, myRigidbody.velocity.y, 0f);	
		} 

        else 
		{
			myRigidbody.velocity = new Vector3 (- (moveSpeed + speedMod), myRigidbody.velocity.y, 0f);
		}	
	}

	void resetBoostTime()
	{
		if (timeLeft <= 0) 
        {
			timeLeft = 10f;
			rushing = false;
			speedMod = 0;
		}

       else if(rushing) 
        {
	       timeLeft -= Time.deltaTime;
        }
    }

    public void hurt()
    {
		if(!rushing)
        {
			gameObject.GetComponent<Animator> ().Play ("PlayerHurt");		
		}

	}

}			
	

