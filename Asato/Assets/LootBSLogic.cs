﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBSLogic : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
    }


}
