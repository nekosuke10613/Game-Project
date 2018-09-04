using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/*--  マルチシーン仕様のシーンマネージャ　ロードアンロード中にロード画面を出せる  --*/
/////////////フェードアウト以外にも増やしたかったらコルーチンを入れ替える///////////
public class GameSceneManager : MonoBehaviour {

    AsyncOperation async;

    public GameScene _currentScene = GameScene.Title;
    string _deadSceneName;

    [SerializeField] GameObject _loadUI　= null;
    [SerializeField] Image _fadeBG = null;

    bool _firstLoadFinished = false;

    private void Awake()
    {//シーンの初期化
        SceneManager.LoadSceneAsync("Title",LoadSceneMode.Additive);
        _deadSceneName = "Title";
        string s = SceneManager.GetActiveScene().name;
        _firstLoadFinished = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<StageManager>() !=null
            &&FindObjectOfType<StageManager>()._stageState == StageState.Over)
        {
            if(FindObjectOfType<StageManager>()._overTimer <= 0)
            {
                Scene s = SceneManager.GetSceneByName("Title");
                if (!_firstLoadFinished) {
                    NextScene("Title", GameScene.Title);
                    _firstLoadFinished = true;
                }
                
            }
            if (Input.GetButtonDown("Jump"))
            {
                //次のステージ
                NextScene("Stage1", GameScene.Stage1);
            }
        }
        
        //DebugCheckScene();
    }
    private void LateUpdate()
    {
        MainSceneActiveChecker();
    }
    public void  NextScene(string nextSceneName,GameScene sceneState)
    {
        StartCoroutine(LoadData(nextSceneName,sceneState));
    }
    IEnumerator LoadData(string nextSceneName, GameScene sceneState)
    {
        /*---------------------フェードインスタート---------------------*/
        StartCoroutine(FadeInAnim());
        
        yield return new WaitForSeconds(1);
        /*---------------------ロード中---------------------------------*/
        _loadUI.SetActive(true);
        
        //シーンのロード
        async = SceneManager.LoadSceneAsync(nextSceneName,LoadSceneMode.Additive);
        //アクティブシーンを今のシーンに
        ////// ・これでも同じシーンを読み込むとアクティブがMasterに行くので
        ////// 　MainSceneActiveChecker関数で対処
        Scene sActive = SceneManager.GetSceneByName(nextSceneName);
        while (!sActive.isLoaded)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(sActive);
        //シーンのアンロード
        if (_deadSceneName != null)
            SceneManager.UnloadSceneAsync(_deadSceneName);
        ////デバッグ用
        yield return new WaitForSeconds(0.2f);
        
        _currentScene = sceneState;

        /*---------------------フェードアウトスタート---------------------*/
        _deadSceneName = nextSceneName;
        _loadUI.SetActive(false);
        StartCoroutine(FadeAnim());
        _firstLoadFinished = false;
    }
    //マスターシーンがアクティブになってしまった時の対処
    void MainSceneActiveChecker()
    {
        Scene s2 = SceneManager.GetSceneByName(_deadSceneName);
        if (SceneManager.GetActiveScene().name == "MasterScene"
            && s2.isLoaded)
        {
            SceneManager.SetActiveScene(s2);
        }
    }
    ////////////////////////////　　以下ロード中エフェクト　　///////////////////////////////
    public IEnumerator FadeInAnim()
    {
        float t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime;
            _fadeBG.color = new Color(0, 0, 0, t);
            yield return null;
        }
        _fadeBG.color = new Color(0, 0, 0, 1.0f);
    }
    public IEnumerator FadeAnim()
    {
        float t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime;
            _fadeBG.color = new Color(0, 0, 0, 1 - t);
            yield return null;
        }

        _fadeBG.color = new Color(0, 0, 0, 0.0f);
    }
    

    ///////////////////////////////  以下不要になった関数  //////////////////////////////

    void TagObjectDeleter()
    {
        //マスターシーンに残ってるオブジェクトを削除する用
        //タグ指定して全消しシーンのアクティブ切り替えられたから不要になった
        var enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemys)
        {
            Destroy(enemy);
        }
    }
    void DebugCheckScene()
    {
        //デバッグ用
        if (Input.GetKeyDown(KeyCode.Alpha1)&&Input.GetKeyDown(KeyCode.G))
        {
            NextScene("Title", GameScene.Title);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && Input.GetKeyDown(KeyCode.G))
        {
            NextScene("Stage1", GameScene.Stage1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && Input.GetKeyDown(KeyCode.G))
        {
            NextScene("GameOver", GameScene.GameOver);
        }
    }
}
