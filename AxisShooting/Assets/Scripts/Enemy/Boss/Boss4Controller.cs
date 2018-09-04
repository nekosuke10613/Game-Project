using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Boss4State
{
    PreFirst,
    PreSecond,
    PreFinal,
    Move,
    TimeOver,
}
public class Boss4Controller : MonoBehaviour {

    public int BossHP { get; set; }
    public bool BossDead { get; private set; }

    [SerializeField] int _score = 1000;
    [SerializeField] int _bossHp = 16;
    [SerializeField] float _finishedTime = 30;
    [SerializeField] float _finishSpeed = 3;
    [SerializeField] GameObject _effect = null;
    
    GameObject c1,c2,c3;
    public Boss4State _state;

    // Use this for initialization
    void Start () {
        BossHP = _bossHp;
        BossDead = false;
        Invoke("TimeOver", _finishedTime);
        c1 = GameObject.Find("BossUpRight(Clone)");
        c2 = GameObject.Find("BossDownRight(Clone)");
        c3 = GameObject.Find("BossUpLeft(Clone)");
        
    }
	
	// Update is called once per frame
	void Update () {                    
        if (BossHP<=0)
        {
            BossDead = true;
            //スコア加算
            GameObject.FindWithTag("GameController").GetComponent<GameController>()._MasterScore += _score;
        }
        
        if (BossDead)
        {
            
            c1.transform.parent = transform;
            c2.transform.parent = transform;
            c3.transform.parent = transform;
            Instantiate(_effect, transform.position, Quaternion.identity);
            BossDeadDestroy();
           
        }
        if(_state == Boss4State.TimeOver)
        {
            Vector3 t = transform.position;
            t.y += _finishSpeed  * Time.deltaTime;
            transform.position = t;
            Invoke("BossDeadDestroy", 5);
        }
	}
    
    void TimeOver()
    {
        _state = Boss4State.TimeOver;
        //コルーチン止めるために無理やり非アクティブにしてる
        c1.SetActive(false);
        c2.SetActive(false);
        c3.SetActive(false);
        c1.SetActive(true);
        c2.SetActive(true);
        c3.SetActive(true);
        c1.transform.parent = transform;
        c2.transform.parent = transform;
        c3.transform.parent = transform;
    }
    void BossDeadDestroy()
    {
        GameObject g = GameObject.Find("Boss4Instance(Clone)");
        Destroy(g,2);
        Destroy(gameObject);
    }
}
