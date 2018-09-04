using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4Collide : MonoBehaviour {

    [SerializeField] GameObject _boss4contrl = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            var hp = _boss4contrl.GetComponent<Boss4Controller>().BossHP;
            hp = hp - 1;
            _boss4contrl.GetComponent<Boss4Controller>().BossHP=hp;
        }
    }
}
