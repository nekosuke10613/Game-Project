using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormal : EnemyParent {
    float _speed;

	// Use this for initialization
	void Start () {
   
    }
    private void OnEnable()
    {
        _speed = GameObject.FindWithTag("GameController").GetComponent<GameController>()._scrollSpeed;

    }
    // Update is called once per frame
    void Update () {
        //ただ下に移動するだけのエネミー
        var pos = transform.position;
        pos.y = transform.position.y - _speed * Time.deltaTime; ;
        transform.position = pos;
	}
}
