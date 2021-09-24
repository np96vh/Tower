using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawnPoint;
    public GameObject pistol;
    public float waitToDisablePistol;
    // Update is called once per frame
    private void Start() {
        pistol.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            pistol.SetActive(true);
            GetComponent<PlayerMovement>().animator.SetTrigger("Shoot");
            GetComponent<PlayerMovement>().animator.SetBool("Run",false);
            GetComponent<PlayerMovement>().enabled = false;
            StartCoroutine(DisablePistol());
            Shoot();
        }
    }
    void Shoot(){
        Instantiate(bullet.transform,bulletSpawnPoint.transform.position,bulletSpawnPoint.transform.rotation);
    }
    IEnumerator DisablePistol(){
        yield return new WaitForSeconds(waitToDisablePistol);
        GetComponent<PlayerMovement>().enabled = true;
        pistol.SetActive(false);
    }
}
