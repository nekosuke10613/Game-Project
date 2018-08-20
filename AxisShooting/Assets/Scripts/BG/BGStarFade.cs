using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGStarFade : MonoBehaviour {

    int _timer;
    int _lightTime;
    
	// Use this for initialization
	void Start () {
        _timer = Random.Range(0, 60);
        _lightTime = Random.Range(40, 50);
	}
	
	// Update is called once per frame
	void Update () {
       
        //時間経過でα値を0or1に切り替える
        if (_timer == 30)
        {
            GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
        }
        else if (_timer == _lightTime)
        {
            GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        }
        else if(_timer>60)
        {
            _timer = 0;
        }
        _timer++;
    }
}
