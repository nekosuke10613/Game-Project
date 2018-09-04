using System.Collections;
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
    int _stageNum;
    GameScene _scene;
    int _prevScore;
    bool _setActive = false;

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
        //デバッグモードじゃなかったら現在のシーンを検索
        if (!_debagMode)
        {
            _scene = GetComponent<GameSceneManager>()._currentScene;
        }
        else
        {
            _scene = GameScene.Stage1;
        }
            
        //ゲーム中UIの表示　タイトルは表示しない
        if (_scene == GameScene.Title)
        {
            if (_UICanvas!=null)
            _UICanvas.SetActive(false);
            _setActive = false;
        }
        else
        {
            if (!_setActive)
            {
                if(_UICanvas !=null)
                _UICanvas.SetActive(true);
                _setActive = true;
            }
            UpdateUI();
        }
	}
    void UpdateUI()
    {
        if(_stageUIText !=null)
        //ステージ数
        _stageUIText.GetComponent<Text>().text = GetComponent<StageNumManager>()._StageNum.ToString();
        
        //スコア
        if (_MasterScore != _prevScore)
        {
            if(_stageUIText !=null)
            _scoreUIText.GetComponent<ScoreUIText>()._score = _MasterScore;
        }
        _prevScore = _MasterScore;
    }
}
