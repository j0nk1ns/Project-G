using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    
    float distanceBetween = .2f;
    float speed = 280;
    float turnSpeed = 180;
    public List<GameObject> bodyParts = new List<GameObject>();
    List<GameObject> snakeBody = new List<GameObject>();
    
    float countUp = 0;
    bool count = false;

    void Start()
    {
        countUp = distanceBetween;
        CreateBodyParts();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ManageSnakeBody();
        SnakeMovement();
    }

    void ManageSnakeBody()
    {
        if (bodyParts.Count > 0)
        {
            CreateBodyParts();
        }
       
        for (int i = 0; i < snakeBody.Count; i++)
        {
            if (snakeBody[i] == null)
            {
                snakeBody.RemoveAt(i);
                i = i - 1;
            }
        }
        if (snakeBody.Count == 0)
        Destroy(this);
    }

  void SnakeMovement()
    {
        snakeBody[0].GetComponent<Rigidbody2D>().velocity = snakeBody[0].transform.right * speed * Time.deltaTime;
        if (Input.GetAxis("Horizontal") != 0)
        {
            snakeBody[0].transform.Rotate(new Vector3(0, 0, -turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal")));
        }
        
    }
 
    void CreateBodyParts()
    {
        if (snakeBody.Count == 0)
        {
         GameObject temp = Instantiate(bodyParts[0], transform.position, transform.rotation, transform);
          if (!temp.GetComponent<MarkerManger>())
          temp.AddComponent<MarkerManger>();
          if (temp.GetComponent<Rigidbody2D>())
          {
            temp.AddComponent<Rigidbody2D>();
            temp.GetComponent<Rigidbody2D>().gravityScale = 0;
          }
          snakeBody.Add(temp);
          bodyParts.RemoveAt(0);
        }
        MarkerManger marM = snakeBody[snakeBody.Count - 1].GetComponent<MarkerManger>();
        if (countUp == 0)
        {
            marM.ClearMarkerList();
        }

        countUp += Time.deltaTime;
        if (countUp >= distanceBetween)
        {
          GameObject temp = Instantiate(bodyParts[0], marM.MarkerList[0].position, marM.MarkerList[0].rotation, transform);
          if (!temp.GetComponent<MarkerManger>())
          temp.AddComponent<MarkerManger>();
          if (temp.GetComponent<Rigidbody2D>())
          {
            temp.AddComponent<Rigidbody2D>();
            temp.GetComponent<Rigidbody2D>().gravityScale = 0;
          }
          snakeBody.Add(temp);
          bodyParts.RemoveAt(0);
          temp.GetComponent<MarkerManger>().ClearMarkerList();
          countUp = 0;

        }
    }

}
