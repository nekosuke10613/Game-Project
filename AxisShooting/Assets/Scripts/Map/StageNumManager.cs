using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageNumManager : MonoBehaviour {

    public int _StageNum {get; private set; }
    GameScene _scene;

    public bool debagMode = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!debagMode)
            _scene = GetComponent<GameSceneManager>()._currentScene;
        else
            _scene = GameScene.Stage1;

       if(_scene == GameScene.Title)
        {
            _StageNum = 0;
        }
        else if (_scene == GameScene.Stage1)
        {
            _StageNum = 1;
        }
    }
}
