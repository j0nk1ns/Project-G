using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{

    private Slider volumeSlider;
    private AudioSource audioSource;
    
     void Awake()
    {
        volumeSlider = GameObject.Find("Slider").GetComponent<Slider>();
        volumeSlider.value = 1;
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
       
        //Adds a listener to the main slider and invokes a method when the value changes.
        volumeSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
     public void ValueChangeCheck()
    {
         if(audioSource != null)
        {
            audioSource.volume = volumeSlider.value;
            Debug.Log("Audio Source Not Found");
        }
         
        Debug.Log(volumeSlider.value);
    }
}
