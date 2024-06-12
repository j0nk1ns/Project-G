using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    
   void Update()
   {
	 transform.Translate(transform.forward * Time.deltaTime * 2f);
   }

    
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "CreditScene" )

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

}
