using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            FindObjectOfType<GameSceneManager>().NextScene("Stage1", GameScene.Stage1);
            string n = GameObject.FindWithTag("SoundManager").gameObject.GetComponent<BGMNameRefalence>()._playBGM;
            SoundManager.Instance.PlayBGM(n,0.5f);
            
        }
	}
}
