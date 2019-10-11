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
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	bool doMenuRotate;
	int _SceneIndex;
	GameObject MainPanel;

	public void MainMenuPlayButton(int SceneIndex) {
		doMenuRotate = true;
		_SceneIndex = SceneIndex;
	}

	public void SceneLoader(int SceneIndex) {
		SceneManager.LoadScene(SceneIndex);
	}

	public void Start() {
		doMenuRotate = false;
		MainPanel = GameObject.Find("MainPanel");
	}

	public void Update() {
		if (doMenuRotate) {
			if (MainPanel.transform.eulerAngles.z < 90) {
				MainPanel.transform.Rotate(0, 0, MainPanel.transform.rotation.eulerAngles.z + 0.01f);
			} else {
				doMenuRotate = false;
			}
		}

		if (MainPanel.transform.eulerAngles.z > 90) {
			SceneLoader(_SceneIndex);
		}
	}
}
