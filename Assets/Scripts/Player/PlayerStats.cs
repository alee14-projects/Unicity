/*******************************************************************************
*
*    Project SimLife: A Sims clone written in Unity C#
*    Copyright (C) 2019 AleeCorp + Software Elevated
*
*    This program is free software: you can redistribute it and/or modify
*    it under the terms of the GNU General Public License as published by
*    the Free Software Foundation, either version 3 of the License, or
*    (at your option) any later version.
*
*    This program is distributed in the hope that it will be useful,
*    but WITHOUT ANY WARRANTY; without even the implied warranty of
*    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
*    GNU General Public License for more details.
*
*    You should have received a copy of the GNU General Public License
*    along with this program.  If not, see <https://www.gnu.org/licenses/>.
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
