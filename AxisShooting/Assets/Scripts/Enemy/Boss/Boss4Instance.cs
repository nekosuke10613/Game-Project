using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4Instance : MonoBehaviour {

    [SerializeField] GameObject _insBoss = null;

	// Use this for initialization
	void Start () {
        Instantiate(_insBoss, transform.position,Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
