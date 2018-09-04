using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    First,
    Second,
    Third,
    Fore,
    Five,
}

public class PlayerLevelState : MonoBehaviour {

    [SerializeField] GameObject FirstBullet = null;
    [SerializeField] GameObject SecondBullet = null;
    [SerializeField] GameObject FinalBullet = null;
    [SerializeField] GameObject _deadEffect = null;
    public PlayerState _state;
   

    // Use this for initialization
    void Start () {
        _state = PlayerState.First;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUpItem"))
        {
            if (_state < PlayerState.Five)
            {
                _state = _state + 1;
            }
            if ((int)_state == 0)
            {
                gameObject.GetComponent<PlayerController>()._playerBullet = FirstBullet;
            }
            if ((int)_state == 1|| (int)_state == 4)
            {
                gameObject.GetComponent<PlayerController>()._playerBullet = SecondBullet;
            }
            if((int)_state == 2|| (int)_state == 3)
            {
                gameObject.GetComponent<PlayerController>()._playerBullet = FinalBullet;
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy")|| other.gameObject.CompareTag("EnemyBullet"))
        {
            //1，2，は普通に死亡
            if (_state <= PlayerState.Second)
            {//無敵時間とダメージ
                Instantiate(_deadEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                
            }
            //3 で被弾したらバリア-1、4状態に
            else if(_state == PlayerState.Third)
            {

            }
            
        }
        
    }
       
    
}
