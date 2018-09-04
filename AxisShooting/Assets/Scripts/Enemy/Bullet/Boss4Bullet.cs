using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4Bullet : MonoBehaviour {

    [SerializeField] float _speed = 1;
    Vector3 _playerPos;
    Vector3 _playerDis;

	// Use this for initialization
	void Start () {
        if(GameObject.FindWithTag("Player")!=null)
        _playerPos=GameObject.FindWithTag("Player").transform.position;
        _playerDis = Vector3.Normalize(_playerPos - transform.position);
        Invoke("BulletDestroy", 5);
    }
	
	// Update is called once per frame
	void Update () {
        
        transform.position += _playerDis * _speed * Time.deltaTime;
    }
    private void BulletDestroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
