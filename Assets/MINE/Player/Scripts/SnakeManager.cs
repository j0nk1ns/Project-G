using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class SnakeManager : MonoBehaviour
{
    
    private float distanceBetween = .2f;
    //float speed = 280;
  //  float turnSpeed = 180;
    public List<GameObject> bodyParts = new List<GameObject>();
    List<GameObject> snakeBody = new List<GameObject>();
    
    float countUp = 0;

    public CinemachineVirtualCamera vcam;

    void Start()
    {
        CreateBodyParts(); 
        
    }

    void FixedUpdate()
    {
        if (bodyParts.Count > 0)
        {
            CreateBodyParts();
        }
  
       // SnakeMovement();

    }

  //void SnakeMovement()
    //{
       // snakeBody[0].GetComponent<Rigidbody2D>().velocity = snakeBody[0].transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        //if (Input.GetAxis("Horizontal") != 0)
       // {
      //      snakeBody[0].transform.Rotate(new Vector3(0, 0, turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal")));
      //  }
        
       // snakeBody[0].GetComponent<Rigidbody2D>().velocity = snakeBody[0].transform.right * speed * Time.deltaTime * Input.GetAxis("Vertical");
       // if (Input.GetAxis("Vertical") != 0)
      //  {
       //     snakeBody[0].transform.Rotate(new Vector3(0, 0, -turnSpeed * Time.deltaTime * Input.GetAxis("Vertical")));
      //  }



       // if(snakeBody.Count > 1)
      //  {   
      //      for (int i = 1; i < snakeBody.Count; i++)
           // {
       //         MarkerManger markM = snakeBody[i - 1].GetComponent<MarkerManger>();
       //         snakeBody[i].transform.position = markM.MarkerList[0].position;
       //         snakeBody[i].transform.rotation = markM.MarkerList[0].rotation;
      //          markM.MarkerList.RemoveAt(0);

           // }
      //  }
        
  //  }
 
    void CreateBodyParts()
    {
        if (snakeBody.Count == 0)
        {
         GameObject temp1 = Instantiate(bodyParts[0], transform.position, transform.rotation, transform);
         StartCoroutine(CameraFollow());
          if (!temp1.GetComponent<MarkerManger>())
          temp1.AddComponent<MarkerManger>();
          if (!temp1.GetComponent<Rigidbody2D>())
          {
            temp1.AddComponent<Rigidbody2D>();
            temp1.GetComponent<Rigidbody2D>().gravityScale = 0;
          }
          snakeBody.Add(temp1);
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
          if (!temp.GetComponent<Rigidbody2D>())
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

    IEnumerator CameraFollow()
    {
        yield return new WaitForSeconds(2);
        if(snakeBody != null) 
        {
            var followSnake = GameObject.FindObjectsOfType<MarkerManger>();
            vcam.Follow = followSnake[0].transform;
        }
        
    }
}

