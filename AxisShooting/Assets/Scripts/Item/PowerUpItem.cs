using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour {
    enum MoveState {
        Right,
        Left,
    }

    MoveState _state = MoveState.Right;
    private float startPosX;
    private float endPosX;
    private float startTime;

    float _fieldAreaX;
    float _fieldAreaY;
    float _scrollSpeed;
    

    float  time = 1;

    private void Awake()
    {
        _fieldAreaX = GameObject.FindWithTag("GameController").GetComponent<GameController>()._fieldAreaX;
        _fieldAreaY = GameObject.FindWithTag("GameController").GetComponent<GameController>()._fieldAreaY;
    }
    // Use this for initialization
    void Start () {
        _scrollSpeed = GameObject.FindWithTag("GameController").GetComponent<GameController>()._scrollSpeed;
        
        startPosX = transform.position.x;
        endPosX = 10;
        startTime = Time.timeSinceLevelLoad;

    }
	
	// Update is called once per frame
	void Update () {
       
        if(_state == MoveState.Right)
        {
            var diff = Time.timeSinceLevelLoad - startTime;

            //超えたら
            if (diff> 10)
            {
                _state = MoveState.Left;
            }
            
            var rate = diff / time*0.002f;
            print(diff + "," + rate);
            float translateX = Mathf.Lerp(transform.position.x, _fieldAreaX, rate);
            float translateY = transform.position.y - _scrollSpeed * Time.deltaTime;
            transform.position = new Vector3(translateX, translateY, 0);
        }
        else
        {

        }



       // print(translateX);
        
	}
}
