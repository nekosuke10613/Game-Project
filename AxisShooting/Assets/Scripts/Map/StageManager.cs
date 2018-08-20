using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageState
{
    Start,
    Move,
    Boss,
    Clear,
}
public class StageManager : MonoBehaviour {

    
    public StageState _stageState;
    public bool _bossDead;
    float _scrollSpeed;
    Vector3 _pos;
    float _timer;

	// Use this for initialization
	void Start () {
        _stageState = StageState.Start;
        _scrollSpeed = GameObject.FindWithTag("GameController").GetComponent<GameController>()._scrollSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        if(_stageState == StageState.Start)
        {
            StartUpdate();
        }
        else if (_stageState == StageState.Move)
        {
            MoveUpdate();
        }
        else if(_stageState == StageState.Boss)
        {
            BossUpdate();
        }
        else if(_stageState == StageState.Clear)
        {
            ClearUpdate();
        }
        
	}
    void StartUpdate()
    {
        _timer = _timer + Time.deltaTime;
        if (_timer > 2)
        {
            _stageState = StageState.Move;
        }
    }
    void MoveUpdate()
    {
        _pos.y = transform.position.y - _scrollSpeed * Time.deltaTime;
        transform.position = _pos;
    }
    void BossUpdate()
    {

    }
    void ClearUpdate()
    {

    }
}
