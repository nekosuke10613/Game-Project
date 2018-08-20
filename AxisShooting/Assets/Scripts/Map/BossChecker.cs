using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChecker : MonoBehaviour {

    [SerializeField] GameObject _stageManager = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossTrigger"))
        {
            _stageManager.GetComponent<StageManager>()._stageState = StageState.Boss;
        }
    }
    
}
