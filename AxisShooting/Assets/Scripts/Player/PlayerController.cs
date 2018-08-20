using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] public GameObject _playerBullet = null;
    [SerializeField] float _moveSpeed = 0.5f;
    [SerializeField] float _intervalScds = 0.1f;
    
    float _fieldAreaX;
    float _fieldAreaY;
    float _timer;

    private void Awake()
    {
        _fieldAreaX = GameObject.FindWithTag("GameController").GetComponent<GameController>()._fieldAreaX;
        _fieldAreaY = GameObject.FindWithTag("GameController").GetComponent<GameController>()._fieldAreaY;
    }
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
        AttackPlayer();
	}
    void MovePlayer()
    {
        float dx = Input.GetAxisRaw("Horizontal")*Time.deltaTime;
        float dy = Input.GetAxisRaw("Vertical")*Time.deltaTime;
        transform.position =new Vector3(
            Mathf.Clamp(transform.position.x + dx * _moveSpeed,-_fieldAreaX,_fieldAreaX),
            Mathf.Clamp(transform.position.y + dy * _moveSpeed,-_fieldAreaY+1,_fieldAreaY), 
            0);
        
    }
    void AttackPlayer()
    {
        if (Input.GetButton("Jump"))
        {
            if (_timer <= 0)
            {
                Instantiate(_playerBullet, transform.position, Quaternion.identity);
                _timer = _intervalScds;
            }
            _timer = _timer - Time.deltaTime;
            
        }
    }
}
