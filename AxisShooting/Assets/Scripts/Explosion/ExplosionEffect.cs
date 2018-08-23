using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] float finishedTime = 0.5f;
    // Use this for initialization
    void Start()
    {
        Invoke("DeleteEffect", finishedTime);
    }
   void  DeleteEffect(){
        Destroy(gameObject);
    }
}
