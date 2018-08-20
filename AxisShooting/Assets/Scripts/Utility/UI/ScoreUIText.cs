using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIText : MonoBehaviour {

   [SerializeField] Text _scoreText;
    public int _score;

	// Use this for initialization
	void Start () {
        _scoreText.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        _scoreText.text = _score.ToString();
    }
}
