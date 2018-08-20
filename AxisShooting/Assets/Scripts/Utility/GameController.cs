﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    
    [SerializeField] public  float _fieldAreaX = 10;
    [SerializeField] public  float _fieldAreaY = 10;
    [SerializeField] public float _scrollSpeed = 0.5f;
    [SerializeField] GameObject _UICanvas = null;
    [SerializeField] GameObject _scoreUIText = null;
    [SerializeField] Text _stageUIText = null;
    public int _MasterScore { get; set; }
    int stageNum;
    GameScene _scene;
    int _prevScore;
    bool setActive = false;

    public bool _debagMode = false;

    void Awake()
    {
        _MasterScore = 0;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!_debagMode)
        {
            _scene = GetComponent<GameSceneManager>()._currentScene;
        }
        else
        {
            _scene = GameScene.Stage1;
        }
            

        if (_scene == GameScene.Title)
        {
            _UICanvas.SetActive(false);
            setActive = false;
        }
        else
        {
            if (!setActive)
            {
                _UICanvas.SetActive(true);
                setActive = true;
            }
            UpdateUI();
           
        }
        
	}
    void UpdateUI()
    {
        //ステージ数
        _stageUIText.GetComponent<Text>().text = GetComponent<StageNumManager>()._StageNum.ToString();
        
        //スコア
        if (_MasterScore != _prevScore)
        {
            _scoreUIText.GetComponent<ScoreUIText>()._score = _MasterScore;

        }
        _prevScore = _MasterScore;
    }
}