using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameStart : MonoBehaviour
{
    public Button startGameButton;
    // Start is called before the first frame update
    void Start()
    {
        startGameButton.onClick.AddListener(StartGame);
    }
   public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
