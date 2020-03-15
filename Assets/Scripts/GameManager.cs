using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Mutation Rate
    [SerializeField] private Slider slider1;
    [SerializeField] private Text   slidertext1;
    //Min Size
    [SerializeField] private Slider slider2;
    [SerializeField] private Text   slidertext2;
    //Max Size
    [SerializeField] private Slider slider3;
    [SerializeField] private Text   slidertext3;
    //Tree Rate
    [SerializeField] private Slider slider4;
    [SerializeField] private Text   slidertext4;
    //Ptero Rate
    [SerializeField] private Slider slider5;
    [SerializeField] private Text   slidertext5;
    //Min Vision
    [SerializeField] private Slider slider6;
    [SerializeField] private Text   slidertext6;
    //Max Vision
    [SerializeField] private Slider slider7;
    [SerializeField] private Text   slidertext7;
    //Population
    [SerializeField] private Slider slider8;
    [SerializeField] private Text slidertext8;
    //Survive
    [SerializeField] private Slider slider9;
    [SerializeField] private Text slidertext9;
    //GenerationCountDown
    [SerializeField] private Slider slider10;
    [SerializeField] private Text slidertext10;
    
    float mutationRate;
    float minSize;
    float maxSize;
    float treeRate;
    float pteroRate;
    float minVision;
    float maxVision;
    float population;
    bool  mustSurvive;
    int genCD;

    void Start()
    {
        mutationRate = 5;
        minSize = 1;
        maxSize = 2;
        treeRate = 2;
        pteroRate = 12;
        minVision = 1;
        maxVision = 3;
        population = 20;
        mustSurvive = true;
        genCD = 10;
    }
    
    #region ScreenController

    //Change Mutation Rate
    public void ChangeMutationRate()
    {
        slidertext1.text = slider1.value.ToString();

        mutationRate = slider1.value;
    }

    //Change Min Size
    public void ChangeMinSize()
    {
        slidertext2.text = Math.Round((double)slider2.value, 1).ToString();

        if (slider2.value > slider3.value)
        {
            slider3.value = slider2.value;
        }

        minSize = slider2.value;
    }

    //Change Max Size
    public void ChangeMaxSize()
    {
        slidertext3.text = Math.Round((double)slider3.value, 1).ToString();

        if (slider3.value < slider2.value)
        {
            slider2.value = slider3.value;
        }

        maxSize = slider3.value;
    }

    //Change Tree Rate
    public void ChangeTreeRate()
    {
        slidertext4.text = slider4.value.ToString();

        treeRate = slider4.value;
    }

    //Change Ptero Rate
    public void ChangePteroRate()
    {
        slidertext5.text = slider5.value.ToString();

        pteroRate = slider5.value;
    }

    //Change Min Vision
    public void ChangeMinVision()
    {
        slidertext6.text = Math.Round((double)slider6.value, 1).ToString();

        if (slider6.value > slider7.value)
        {
            slider7.value = slider6.value;
        }

        minVision = slider6.value;
    }

    //Change Max Vision
    public void ChangeMaxVision()
    {
        slidertext7.text = Math.Round((double)slider7.value, 1).ToString();

        if (slider7.value < slider6.value)
        {
            slider6.value = slider7.value;
        }

        maxVision = slider7.value;
    }

    //Population
    public void ChangePopulation()
    {
        slidertext8.text = slider8.value.ToString();
        population = slider8.value;
    }

    //Survive
    public void ChangeSurvive()
    {
        mustSurvive = (slider9.value == 1) ? true : false;
        slidertext9.text = mustSurvive.ToString();
    }
    
    //Generation
    public void ChangeGenerationCountDown()
    {
        slidertext10.text = slider10.value.ToString();
        genCD = (int) slider10.value;
    }

    #endregion

    #region Getters

    public float GetMutationRate()
    {
        return mutationRate;
    }

    public float GetMinSize()
    {
        return minSize;
    }

    public float GetMaxSize()
    {
        return maxSize;
    }

    public float GetMinVision()
    {
        return minVision;
    }

    public float GetMaxVision()
    {
        return maxVision;
    }

    public float GetPopulation()
    {
        return population;
    }

    public bool GetSurviving()
    {
        return mustSurvive;
    }

    public float GetTreeRate()
    {
        return treeRate;
    }
    public float GetPteroRate()
    {
        return pteroRate;
    }

    public float GetGenCD()
    {
        return genCD;
    }

    #endregion

    public void UnableSliders()
    {
        slider8.enabled = false;
        slider9.enabled = false;
        slider10.enabled = false;
    }

    public void AbleSliders()
    {
        slider8.enabled = true;
        slider9.enabled = true;
        slider10.enabled = true;
    }
}