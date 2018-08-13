using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameScene {
    Title,
    Stage1,
    GameOver,
}

public class GameSceneManager : MonoBehaviour {

    AsyncOperation async;

    public GameScene _currentScene = GameScene.Title;
    string _deadSceneName;

    [SerializeField] GameObject _loadUI;
    [SerializeField] Image _fadeBG;
    [SerializeField] float _slider;

    private void Awake()
    {//シーンの初期化
        SceneManager.LoadSceneAsync("Title",LoadSceneMode.Additive);
        _deadSceneName = "Title";
    }
    // Update is called once per frame
    void Update()
    {
        DebugCheckScene();
    }
    public void  NextScene(string nextSceneName,GameScene sceneState)
    {
        _currentScene = sceneState;
        StartCoroutine(LoadData(nextSceneName));
    }
    IEnumerator LoadData(string nextSceneName)
    {
        /*--フェードインスタート--*/
        StartCoroutine(FadeInAnim());
        yield return new WaitForSeconds(1);

        /*--ロード中--*/
        _loadUI.SetActive(true);
        //シーンのロード
        async = SceneManager.LoadSceneAsync(nextSceneName,LoadSceneMode.Additive);
        //デバッグ用
        yield return new WaitForSeconds(1);
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            _slider = progressVal;
            yield return null;
        }
        //シーンのアンロード
        if (_deadSceneName != null)
            SceneManager.UnloadSceneAsync(_deadSceneName);

        /*--フェードアウトスタート--*/
        _deadSceneName = nextSceneName;
        _loadUI.SetActive(false);
        _slider = 0;
        StartCoroutine(FadeAnim());
    }
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
    void DebugCheckScene()
    {
        //デバッグ用
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            NextScene("Title", GameScene.Title);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            NextScene("Stage1", GameScene.Stage1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            NextScene("GameOver", GameScene.GameOver);
        }
    }
}
