using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class volumesetting : MonoBehaviour
{
    
    public Slider slider;

    void Start()
    {
        if (PlayerPrefs.HasKey("sldkey"))
            load();
        else
        {
            PlayerPrefs.SetFloat("sldkey", 1);
            load();
        }
    }

    public void change()
    {
       AudioListener.volume = slider.value;
        save();
    }
    public void save()
    {
        PlayerPrefs.SetFloat("sldkey",slider.value);
        load();
    }
    public void load()
    {
        slider.value = PlayerPrefs.GetFloat("sldkey");
    }
}
