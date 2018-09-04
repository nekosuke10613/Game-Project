using UnityEngine;

public class EnemyMelse : EnemyParent {
    
    enum MelseState {
        RightMirror = 0,
        LeftMove = 1,
        LeftMirror = 2,
        RightMove = 3,
    }
    MelseState _melseState = MelseState.RightMirror;

    [SerializeField]float _moveSpeed = 4;
    [SerializeField] float _mirrorSpeed = 3;

    float _fieldAreaX = 0;
    float _fieldAreaY = 0;
    // Use this for initialization
    void Start () {
        _fieldAreaX = GameObject.FindWithTag("GameController").GetComponent<GameController>()._fieldAreaX;
        _fieldAreaY = GameObject.FindWithTag("GameController").GetComponent<GameController>()._fieldAreaY;
    }
	// Update is called once per frame
	
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        EnemyFunction();
    }
    public override void EnemyFunction()
    {
        if(_melseState == MelseState.RightMirror)
        {
            transform.position = transform.position + new Vector3(-_mirrorSpeed,-_mirrorSpeed,0)* Time.fixedDeltaTime;
            
           Invoke("DelayRight", 0.5f);
            
        }
        else if(_melseState == MelseState.LeftMove)
        {
            transform.position = transform.position + new Vector3(-_moveSpeed, 0, 0) * Time.fixedDeltaTime;
            if(transform.position.x <= -_fieldAreaX)
            {
                ChangeState(2);
            }
        }
        else if (_melseState == MelseState.LeftMirror)
        {
            transform.position = transform.position + new Vector3(_mirrorSpeed, -_mirrorSpeed, 0) * Time.fixedDeltaTime;
            Invoke("DelayLeft", 0.5f);
           
        }
        else if (_melseState == MelseState.RightMove)
        {
            transform.position = transform.position + new Vector3(_moveSpeed, 0, 0) * Time.fixedDeltaTime;
            if (transform.position.x >= _fieldAreaX)
            {
                ChangeState(0);
            }
        }
    }
    void DelayRight()
    {
        ChangeState(1);
    }
    void DelayLeft()
    {
        ChangeState(3);
    }
    void ChangeState(int state)
    {
        _melseState = (MelseState)state;
    }
    
}
