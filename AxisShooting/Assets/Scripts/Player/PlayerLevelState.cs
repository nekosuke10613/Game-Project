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
    }
       
    
}
