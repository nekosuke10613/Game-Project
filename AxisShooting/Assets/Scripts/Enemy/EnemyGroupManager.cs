using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupManager : MonoBehaviour {
    //グループリスト
    [SerializeField,Header("")]
    List<GameObject> _enemyGroups = new List<GameObject>();

    int _currentNum;
    GameObject _currentGroup;
    bool _finished;

	// Use this for initialization
	void Start () {
        _currentNum = 0;
        _finished = false;
	}
    private void OnEnable()
    {
        Instantiate(_enemyGroups[_currentNum]);
        _currentGroup = _enemyGroups[_currentNum];
        _currentGroup.SetActive(true);
    }
    // Update is called once per frame
    void Update () {
        //生成終了したらリターン
        if (_finished) return;
        //生成したグループの子が全部しんでなかったら志ターン
        if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0) return;
        //ボスモードだったらリターン
        //次のグループ生成
        AddEnemys();

    }
    void AddEnemys()
    {
 
        //リストのカウントを超えたら
        if(_currentNum == _enemyGroups.Count-1)
        {
            _finished = true;
            return;
        }
        
        else if (_currentNum != _enemyGroups.Count - 1)
        {
            _currentNum++;
            //Destroy(_currentGroup.gameObject);
            Instantiate(_enemyGroups[_currentNum]);
            _currentGroup = _enemyGroups[_currentNum];
            _currentGroup.SetActive(true);
        }
        

        if (_currentNum != _enemyGroups.Count - 1)
        {//カウントがリストの数と同じじゃなかったら
           
            
        }
        
       
    }
}
