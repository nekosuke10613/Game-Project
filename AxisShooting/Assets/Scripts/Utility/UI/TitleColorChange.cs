using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleColorChange : MonoBehaviour {

    [SerializeField] Text _titleText;
    [SerializeField] Color _color1;
    [SerializeField] Color _color2;
    [SerializeField] Color _color3;
    [SerializeField]float _count;
    public bool flg;
    // Use this for initialization
    void Start () {
        _titleText.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        _count++;
        if (_count == 30)
        {
            _titleText.color = _color1;
        }
        else if (_count == 60)
        {
            _titleText.color = _color2;
        }
        else if (_count == 90)
        {
            _titleText.color = _color3;
        }
        else if (_count == 120)
        {
            _titleText.color = _color2;
        }
        else if (_count > 120)
        {
            _count = 0;
        }
    }
}
