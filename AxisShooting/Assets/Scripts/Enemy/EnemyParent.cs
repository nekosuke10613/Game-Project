using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour {
    
    [SerializeField] GameObject _fireEffect = null;
    [SerializeField] int _score = 1;
    [SerializeField] int _hp = 1;
    
	// Use this for initialization
	void Start () {
         ;
    }
	
	// Update is called once per frame
	void Update () {

        
	}
    
    public virtual void EnemyFunction()
    {
        //継承元
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet")|| other.CompareTag("Player"))
        {
            _hp--;
            if (_hp <= 0)
            {
                Instantiate(_fireEffect, transform.position, Quaternion.identity);
                //スコア加算
                GameObject.FindWithTag("GameController").GetComponent<GameController>()._MasterScore += _score;
                Destroy(gameObject);
            }
        }
       
    }
}
