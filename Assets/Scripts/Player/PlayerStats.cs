/*******************************************************************************
*
*    Unicity (Project SimLife): A Sims clone written in Unity C#
*    Copyright (C) 2019 Unicity Development Team
*
*    This software is protected by the copyright and licensing rights held
*    by the Unicity Development Team. (2019)
*
*********************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float Hunger;
    public float hungerOverTime;
    public float Bladder;
    public float bladderOverTime;
    public float Hygiene;
    public float Energy;

    public Slider HungerBar;
    public Slider BladderBar;

    public Material SimDeadMaterial;

    private void Start()
    {
        HungerBar.maxValue = Hunger;
        BladderBar.maxValue = Bladder;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("You have given yourself 10% Hunger and Bladder");
            Hunger += 10;
            Bladder += 10;
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("You have given yourself -10% Hunger and Bladder");
            Hunger -= 10;
            Bladder -= 10;
        }

        CalculcateValue();
    }

    private void CalculcateValue()
    {
        Hunger -= hungerOverTime * Time.deltaTime;
        Bladder -= bladderOverTime * Time.deltaTime;

        if (Hunger <= 0)
        {
            gameObject.GetComponent<MeshRenderer>().material = SimDeadMaterial;

            Debug.Log("You have starved to death!");
            Hunger += 100;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        Hunger = Mathf.Clamp(Hunger, 0, 100f);
        Bladder = Mathf.Clamp(Bladder, 0, 100f);

        HungerBar.value = Hunger;
        BladderBar.value = Bladder;

    }
}
