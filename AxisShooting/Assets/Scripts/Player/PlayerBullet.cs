using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    [SerializeField]float _speed = 20;
    float _fieldAreaX;
    float _fieldAreaY;

    // Use this for initialization
    void Start () {
        _fieldAreaX = GameObject.FindWithTag("GameController").GetComponent<GameController>()._fieldAreaX;
        _fieldAreaY = GameObject.FindWithTag("GameController").GetComponent<GameController>()._fieldAreaY;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, _speed*Time.deltaTime, 0);
        if((transform.position.x<-_fieldAreaX||_fieldAreaX < transform.position.x)
            ||( transform.position.y < -_fieldAreaY+1 || _fieldAreaY < transform.position.y-1.5f))
        {
            
            Destroy(gameObject);
        }
	}
}
