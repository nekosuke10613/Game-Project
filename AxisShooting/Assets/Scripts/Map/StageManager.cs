using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StageState
{
    Start,
    Move,
    Boss,
    Clear,
    Over,
}
public class StageManager : MonoBehaviour {

    [SerializeField] GameObject _startUI=null;
    [SerializeField] GameObject _clearUI = null;
    [SerializeField] GameObject _overUI = null;
    [SerializeField] GameObject _timerUI = null;
    [SerializeField] GameObject _enemyGroup=null;
    [SerializeField] GameObject _bossObject = null;
    [SerializeField] bool _DebugMode = false;
    public StageState _stageState;
    public bool _bossDead;
    public float _overTimer = 5;
    bool _bossStart = false;

    float _scrollSpeed;
    float _timer;
   
    Vector3 _pos;
    GameObject _player;
    

    // Use this for initialization
    void Start () {
        _stageState = StageState.Start;
        _scrollSpeed = GameObject.FindWithTag("GameController").GetComponent<GameController>()._scrollSpeed;
        _player=GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        
        if(_stageState == StageState.Start)
        {
            StartUpdate();
        }
        else if (_stageState == StageState.Move)
        {
            if (!_enemyGroup.activeInHierarchy)
            {
                _enemyGroup.SetActive(true);
            }
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
        else if(_stageState == StageState.Over)
        {
            OverUpdate();
        }
        
	}
    void StartUpdate()
    {
        if(!_startUI.activeSelf && _startUI !=null)
            _startUI.SetActive(true);

        _timer = _timer + Time.deltaTime;
        if (_timer > 2)
        {
            _stageState = StageState.Move;
        }
    }
    void MoveUpdate()
    {
        if(_startUI.activeSelf && _startUI != null)
            _startUI.SetActive(false);
        if (_player == null)
        {
            _stageState = StageState.Over;
        }
        _pos.y = transform.position.y - _scrollSpeed * Time.deltaTime;
        transform.position = _pos;

    }
    void BossUpdate()
    {
        if (!_bossStart)
        {
            _bossObject=Instantiate(_bossObject);
            _bossStart = true;
        }
        if (_bossObject ==null)
        {
            _bossDead = true;
            _stageState = StageState.Clear;
        }
        if (_player == null)
        {
            _stageState = StageState.Over;
        }
    }
    void ClearUpdate()
    {
        if (!_clearUI.activeSelf&&_clearUI!=null )
        {
            _clearUI.SetActive(true);
        }
    }
    void OverUpdate()
    {
        if (!_overUI.activeSelf && _overUI != null)
        {
            _overUI.SetActive(true);
            _timerUI.SetActive(true);
            _overTimer = 5;
        }
        if (_overTimer <= 0)
        {
            
        }
        else
        {
            _overTimer -= Time.deltaTime;
            _timerUI.GetComponent<Text>().text = _overTimer.ToString("F0");
        }
        
    }
}
