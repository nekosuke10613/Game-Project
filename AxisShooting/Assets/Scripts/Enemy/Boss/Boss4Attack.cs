using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4Attack : MonoBehaviour {

    
    [SerializeField] GameObject _enemyBullet = null;
    [SerializeField] float _intervalFirst = 1;
    bool _move = false;

	// Use this for initialization
	void Start () {
        
	}
    private void Update()
    {
        if(!_move&&GetComponent<Boss4Controller>()._state == Boss4State.Move)
        {
            Invoke("BulletInstance", _intervalFirst);
            _move = true;
        }
    }

    void BulletInstance()
    {
       var offset = transform.position + new Vector3(0.5f, 0, -1);
        Instantiate(_enemyBullet, offset, Quaternion.identity);
        Invoke("BulletInstance", Random.Range(0.5f, 1.5f));
    }
}
