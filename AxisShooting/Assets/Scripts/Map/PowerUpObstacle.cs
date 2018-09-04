using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObstacle : ScoreObstacle {

    [SerializeField] GameObject _PowerUpItem = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            if (!_broke && _hp <=0)
            {
                Instantiate(_PowerUpItem, transform.position, Quaternion.identity);
            }
        }
    }
}
