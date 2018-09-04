using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss4Move : MonoBehaviour {

    [SerializeField] GameObject _bossController = null;
    [SerializeField] bool _up;
    [SerializeField] bool _left;
    [SerializeField] float _speed = 1;
    [SerializeField] float _waitInterval = 0.5f;
    
    

	// Use this for initialization
	void Start () {

        _bossController.GetComponent<Boss4Controller>()._state = Boss4State.PreFirst;
        if (_up)
        {
            StartCoroutine(MoveNextPoint(new Vector3(transform.position.x, transform.position.y + 4, transform.position.z),
                        _speed,Boss4State.PreSecond));
        }
        else
        {
            StartCoroutine(MoveNextPoint(new Vector3(transform.position.x, transform.position.y - 4, transform.position.z),
                        _speed,Boss4State.PreSecond));
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    
   
    IEnumerator MoveNextPoint(Vector3 targetPos,float speed,Boss4State nextState)
    {
        
        Vector3 defaultPos = transform.position;
        for (float a = 0; a < 1; a += Time.fixedDeltaTime * speed)
        {
            transform.position = Vector3.Lerp(defaultPos, targetPos, a);
            yield return null;
        }
        if (nextState == Boss4State.Move)
        {
            StartCoroutine(MoveState(new Vector3(transform.position.x - 2, transform.position.y, transform.position.z),
                        _speed,true));
            _bossController.GetComponent<Boss4Controller>()._state = Boss4State.Move;
            yield break;
        }
        
        
        yield return  new WaitForSeconds(_waitInterval);
        OnReachPoint(nextState);
        
    }
    void OnReachPoint(Boss4State state)
    {
        if (state == Boss4State.PreSecond)
        {
            if (_left)
            {
                StartCoroutine(MoveNextPoint(new Vector3(transform.position.x - 5.5f, transform.position.y, transform.position.z),
                        _speed, Boss4State.PreFinal));
            }
            else
            {
                StartCoroutine(MoveNextPoint(new Vector3(transform.position.x + 5.5f, transform.position.y, transform.position.z),
                        _speed, Boss4State.PreFinal));
            }
        }
        else if(state == Boss4State.PreFinal)
        {
            if (_up)
            {
                StartCoroutine(MoveNextPoint(new Vector3(transform.position.x, transform.position.y+5.5f, transform.position.z),
                        _speed, Boss4State.Move));
            }
            else
            {
                StartCoroutine(MoveNextPoint(new Vector3(transform.position.x, transform.position.y-5.5f, transform.position.z),
                        _speed, Boss4State.Move));
            }
        }
        
    }
    IEnumerator MoveState(Vector3 targetPos, float speed,bool right)
    {
        if (_bossController.GetComponent<Boss4Controller>()._state == Boss4State.TimeOver)
        {
            yield break;
        }
        Vector3 defaultPos = transform.position;
        for (float a = 0; a < 1; a += Time.fixedDeltaTime * speed)
        {
            transform.position = Vector3.Lerp(defaultPos, targetPos, a);
            yield return null;
        }
        if (right)
        {
            StartCoroutine(MoveState(new Vector3(transform.position.x + 4, transform.position.y, transform.position.z),
                        _speed, false));
        }
        else
        {
            StartCoroutine(MoveState(new Vector3(transform.position.x - 4, transform.position.y, transform.position.z),
                       _speed, true));
        }
    }
    
}
