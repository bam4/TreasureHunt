﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClosingTitle : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (0);
		}
	}
}
