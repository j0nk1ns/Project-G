using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
   public void PlayButton()

   {

    SceneManager.LoadScene("Game");
   }

   public void OptionsButton()

   {

      SceneManager.LoadScene("Options Menu");
   }

   public void Exit()

   {

      Application.Quit();
   
   }

   public void ControlsButton()
   {

      SceneManager.LoadScene("Options Menu 1");
   }

   public void ExitButton()

   {

      SceneManager.LoadScene("MenuScreen");
   }

   public void ExitControls()

   {

       SceneManager.LoadScene("Options Menu");
   }
}
