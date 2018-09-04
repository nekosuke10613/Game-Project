using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// よく使うサウンドリソースの参照用クラス
/// </summary>
public class BGMNameRefalence : MonoBehaviour {

    [SerializeField,Header("BGMName string型")]
    public string _titleBGM = "BGM_Title";
    [SerializeField]
    public string _playBGM = "BGM_Play";
    [SerializeField]
    public string _levelUpBGM = "BGM_LevelUp";
    [SerializeField]
    public string _bossBGM = "BGM_Boss";

    [SerializeField, Header("SEName string型")]
    public string _se = null;
    
	// Use this for initialization
	void Start () {
        SoundManager.Instance.PlayBGM(_titleBGM, 0.5f);
	}
	
}
