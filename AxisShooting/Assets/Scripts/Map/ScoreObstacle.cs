using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObstacle : MonoBehaviour {

    [SerializeField] Material _AfterMat;
    [SerializeField] Material _BeforeMat;
    [SerializeField] int _breakNum = 2;
    [SerializeField] int _score = 1;
    bool _broke = false;
    int _hp;

	// Use this for initialization
	void Start () {
        _hp = _breakNum;
	}
	
	// Update is called once per frame
	void Update () {
       
          
       
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            _hp--;
            if (_hp <= 0)
            {
                if (!_broke)
                {
                    GetComponent<Renderer>().material = _AfterMat;
                    GameObject.FindWithTag("GameController").GetComponent<GameController>()._MasterScore += _score;
                }
                
                _broke = true;
            }
        }
    }
}
