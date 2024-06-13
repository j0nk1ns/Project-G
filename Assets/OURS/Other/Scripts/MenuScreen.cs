using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
   [SerializeField] GameObject pauseButton;
   [SerializeField] GameObject pauseScreen;
   [SerializeField] GameObject volumeScreen;
   [SerializeField] GameObject titleScreen;
   [SerializeField] GameObject controlsScreen;


   public void PlayButton()
   {
      Time.timeScale = 1;

    SceneManager.LoadScene("Game");
   }

   public void ResumeGame()
   {
       pauseScreen.SetActive(!pauseScreen.activeSelf);
       pauseButton.SetActive(true);
      
      Time.timeScale = 1;
   }

   public void OptionsButton()

   {
      if(pauseScreen != null)
      {
         pauseScreen.SetActive(!pauseScreen.activeSelf);
      }
      if(titleScreen != null)
      {
         titleScreen.SetActive(!titleScreen.activeSelf);
      }
      
      volumeScreen.SetActive(!volumeScreen.activeSelf);
   }

   public void Exit()

   {
      if(titleScreen == null)
      {
         SceneManager.LoadScene("MenuScreen");
      }

      Application.Quit();
   
   }

   public void ControlsButton()
   {
      volumeScreen.SetActive(!volumeScreen.activeSelf);

      controlsScreen.SetActive(!controlsScreen.activeSelf);
   
      if(pauseScreen == null)
      {
         volumeScreen.SetActive(!volumeScreen.activeSelf);
         controlsScreen.SetActive(true);
         Time.timeScale = 1;
      }
       if(titleScreen != null)
      {
         volumeScreen.SetActive(!volumeScreen.activeSelf);
         controlsScreen.SetActive(true);
         Time.timeScale = 1;
      }
     
      
   }

   public void ExitButton()

   {

      volumeScreen.SetActive(!volumeScreen.activeSelf);
      if(pauseScreen != null)
      {
         pauseScreen.SetActive(true);
      }
      if(titleScreen != null)
      {
         titleScreen.SetActive(!titleScreen.activeSelf);
      }
      controlsScreen.SetActive(!controlsScreen.activeSelf);
       if(pauseScreen != null)
      {
         pauseScreen.SetActive(true);
      }
      
      Time.timeScale = 1;
   }

   public void ExitControls()

   {

       volumeScreen.SetActive(!volumeScreen.activeSelf);
   }

   public void PauseButton()
   {
      pauseButton.SetActive(!pauseButton.activeSelf);
      pauseScreen.SetActive(!pauseScreen.activeSelf);
      Time.timeScale = 0;
   }



}
