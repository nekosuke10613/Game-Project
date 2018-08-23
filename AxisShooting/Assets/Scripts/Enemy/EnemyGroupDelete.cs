using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupDelete : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.childCount == 0)
        {
            var g = gameObject;
            Destroy(g);
            g = null;
           
            //gameObject.SetActive(false);
        }
	}
}
