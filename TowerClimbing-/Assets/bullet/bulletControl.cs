using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;
    private GameObject triggeringEnemy;
    // Start is called before the first frame update
    private void Update(){
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        Destroy(this.gameObject,5);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "enemy")
        {
            //triggeringEnemy = other.gameObject;
            //triggeringEnemy.GetComponent<EnermyController>().currentEHp -= bulletDamage;
            Debug.Log("hit");
        }
    }


}
