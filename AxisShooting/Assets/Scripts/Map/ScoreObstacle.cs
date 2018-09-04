using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObstacle : MonoBehaviour {

    [SerializeField] GameObject _AfterImage = null;
    [SerializeField] GameObject _BeforeImage=null;
    [SerializeField] int _breakNum = 2;
    [SerializeField] int _score = 1;
    [SerializeField] GameObject _brokeEffect = null;
    [SerializeField] GameObject _powerUpItem = null;
    public bool _broke = false;
    public int _hp;

	// Use this for initialization
	void Start () {
        _hp = _breakNum;
        _AfterImage.SetActive(false);
        _BeforeImage.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
       
          
       
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            _hp--;
            if (_hp <= 0&& !_broke)
            {
                Break();
                PowerUpCheck();
            }
        }
    }
    private void Break()
    {
        _AfterImage.SetActive(true);
        _BeforeImage.SetActive(false);
        GameObject.FindWithTag("GameController").GetComponent<GameController>()._MasterScore += _score;
        Instantiate(_brokeEffect,
            new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
        _broke = true;
    }
    void PowerUpCheck()
    {
        if(_powerUpItem != null)
        {
            Instantiate(_powerUpItem, transform.position, Quaternion.identity);
        }
    }
}
