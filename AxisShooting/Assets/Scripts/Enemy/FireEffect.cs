using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("EffectDestroy", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void EffectDestroy()
    {
        Destroy(gameObject);
    }
    
}
