using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{

    public Slider volumeSlider;
    public AudioSource audioSource;
    
    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        volumeSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
         audioSource.volume = volumeSlider.value;
        Debug.Log(volumeSlider.value);
    }
}
