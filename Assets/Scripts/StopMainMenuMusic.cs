﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMainMenuMusic : MonoBehaviour {

	void Awake()
	{
		GameObject A = GameObject.FindGameObjectWithTag("music");
		Destroy(A);
	}﻿
}
