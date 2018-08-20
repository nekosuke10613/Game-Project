using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {

    [SerializeField] float _changeBfrHeight = -15;
    [SerializeField] float _changeAftHeight = 15;
    [SerializeField] float _scrlSpeed = 2;
    [SerializeField] GameObject _stageManager;
    StageState _stageState;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        
        if(transform.position.y < _changeBfrHeight)
        {
            pos.y = _changeAftHeight;
            transform.position = pos;
        }
        //スタートなら速度を倍にする
        _stageState = _stageManager.GetComponent<StageManager>()._stageState;
        pos.y = transform.position.y - _scrlSpeed *((_stageState ==StageState.Start)?5:1)* Time.deltaTime;
        transform.position = pos;
       
    }
}
