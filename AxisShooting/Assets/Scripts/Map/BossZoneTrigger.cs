﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZoneTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(17, 1, 1));
    }
}
