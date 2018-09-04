using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehaviour<SoundManager> {

    //ボリューム保存用のkeyとデフォルト値
    private const string BGM_VOLUME_KEY = "_bgm_volume_key";
    private const string SE_VOLUME_KEY = "SE_VOLUME_KEY";
    [SerializeField]private  float BGM_VOLUME_DEFULT = 1.0f;
    [SerializeField]private  float SE_VOLUME_DEFULT = 1.0f;

    //BGMがフェードするのにかかる時間
    public const float BGM_FADE_SPEED_RATE_HIGH = 0.9f;
    public const float BGM_FADE_SPEED_RATE_LOW = 0.3f;
    private float _bgmFadeSpeedRate = BGM_FADE_SPEED_RATE_HIGH;

    //次流すBGM名、SE名
    private string _nextBGMName;
    private string _nextSEName;

    //BGMをフェードアウト中か
    private bool _isFadeOut = false;

    //BGM用、SE用に分けてオーディオソースを持つ
    public AudioSource AttachBGMSource, AttachSESource;

    //全Audioを保持
    private Dictionary<string, AudioClip> _bgmDic, _seDic;


    private void Awake()
    {
     if(this != Instance)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        //リソースフォルダから全SE&BGMのファイルを読み込みセット
        _bgmDic = new Dictionary<string,AudioClip>();
        _seDic = new Dictionary<string, AudioClip>();

        object[] bgmList = Resources.LoadAll("Audio/BGM");
        object[] seList = Resources.LoadAll("Audio/SE");

        foreach(AudioClip bgm in bgmList)
        {
            _bgmDic[bgm.name] = bgm;
        }
        foreach(AudioClip se in seList)
        {
            _seDic[se.name] = se;
        }
    }
    // Use this for initialization
    void Start () {

        AttachBGMSource.volume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, BGM_VOLUME_DEFULT);
        AttachSESource.volume = PlayerPrefs.GetFloat(SE_VOLUME_KEY, SE_VOLUME_DEFULT);
        
	}
    //---------------------------SE-------------------------------//
    /// <summary>
    /// 指定したファイル名のSEを流す。
    /// 第二引数のdelayに指定した分だけ再生までの間隔をあける
    /// </summary>
    /// <param name="seName"></param>
    /// <param name="delay"></param>
    public void PlaySE(string seName, float delay = 0.0f)
    {
        if (!_seDic.ContainsKey(seName))
        {
            Debug.Log(seName + "という名前のSEがありません");
            return;
        }
        _nextSEName = seName;
        Invoke("DelayPlaySE", delay);
    }
    private void DelayPlaySE()
    {
        AttachSESource.PlayOneShot(_seDic[_nextSEName] as AudioClip);
    }
    //---------------------------BGM-------------------------------//
    /// <summary>
    /// 指定したファイルの名のBGMを流す
    /// ただし、すでに流れている場合は前の曲をフェードアウトさせてから
    /// 第二引数のfadeSpeedRateに指定した割合でフェードアウトするスピードが変わる
    /// </summary>
    public void PlayBGM(string bgmName, float fadeSpeedRate = BGM_FADE_SPEED_RATE_HIGH)
    {
        if (!_bgmDic.ContainsKey(bgmName))
        {
            Debug.Log(bgmName + "という名前のBGMがありません");
            return;
        }
        //現在BGMが流れていない時はそのまま流す
        if (!AttachBGMSource.isPlaying)
        {
            _nextBGMName = "";
            AttachBGMSource.clip = _bgmDic[bgmName] as AudioClip;
            AttachBGMSource.Play();
        }
        //違うBGMが空流れているときは、流れているBGMをフェードアウトさせてから次を流す
        //同じBGMが流れているときはスルー
        else if(AttachBGMSource.clip.name != bgmName)
        {
            _nextBGMName = bgmName;
            FadeOutBGM(fadeSpeedRate);
        }
    }

    /// <summary>
    /// 現在流れている曲をフェードアウトさせる
    /// fadeSpeedRateに指定した割合でフェードアウトするスピードが変わる
    /// </summary>
    public void FadeOutBGM(float fadeSpeedRate = BGM_FADE_SPEED_RATE_LOW)
    {
        _bgmFadeSpeedRate = fadeSpeedRate;_isFadeOut = true;
    }
        // Update is called once per frame
    void Update () {
        //タイトル、ゲームシーンでBGM切り替え　
        //プレイヤーの状態3以上でBGM切り替え
        if (!_isFadeOut)
        {
            return;
        }
        //徐々にボリュームを下げていき、ボリュームが0になったら戻し次の曲を流す
        AttachBGMSource.volume -= Time.deltaTime * _bgmFadeSpeedRate;
        if(AttachBGMSource.volume <= 0)
        {
            AttachBGMSource.Stop();
            AttachBGMSource.volume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, BGM_VOLUME_DEFULT);
            _isFadeOut = false;
            if (!string.IsNullOrEmpty(_nextBGMName))
            {
                PlayBGM(_nextBGMName);
            }
        }
	}
    //------------------------音量変更-------------------------//
    public void ChangeVolume(float BGMVolume,float SEVolume)
    {
        AttachBGMSource.volume = BGMVolume;
        AttachSESource.volume = SEVolume;

        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, BGMVolume);
        PlayerPrefs.SetFloat(SE_VOLUME_KEY, SEVolume);
    }

}
