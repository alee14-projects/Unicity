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

public class ExitApplication : MonoBehaviour {
    public void ExitGame() {
        Debug.Log("Game has closed.");
        Application.Quit();
    }
}
