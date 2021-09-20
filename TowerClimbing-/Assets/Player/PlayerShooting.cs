using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawnPoint;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Shoot();
        }
    }
    void Shoot(){
        Instantiate(bullet.transform,bulletSpawnPoint.transform.position,bulletSpawnPoint.transform.rotation);
    }
}
