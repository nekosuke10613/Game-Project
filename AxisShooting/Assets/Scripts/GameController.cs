using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] public  float _fieldAreaX = 10;
    [SerializeField] public  float _fieldAreaY = 10;
    [SerializeField] public float _scrollSpeed = 0.5f;
    [SerializeField] GameObject _scoreUIText = null;
    public int _MasterScore { get; set; }
    int _prevScore;

    void Awake()
    {
        _MasterScore = 0;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(_MasterScore != _prevScore)
        {
            _scoreUIText.GetComponent<ScoreUIText>()._score = _MasterScore;
            
        }
        _prevScore = _MasterScore;
	}
}
