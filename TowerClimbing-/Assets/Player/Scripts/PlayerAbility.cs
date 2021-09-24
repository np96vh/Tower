using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public float dodgeForce;
    private int direction;
    public float timewaitToShoot;
    public Transform player;
    private void Start() {
    }
    private void Update() {
        if (PlayerMovement.vAxis > 0)
            direction = 1;
        else if (PlayerMovement.vAxis < 0)
            direction = 2;
        else if (PlayerMovement.hAxis > 0)
            direction = 3;
        else if (PlayerMovement.hAxis < 0)
            direction = 4;

        if (Input.GetKeyDown(KeyCode.LeftShift)){
            GetComponent<PlayerMovement>().animator.SetTrigger("DodgeRoll");
            DodgeRoll();
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerShooting>().enabled = false;
        }
    } 
    private void DodgeRoll(){
        if (direction == 1)
            GetComponent<Rigidbody>().AddForce(new Vector3(0,0,1) * dodgeForce,ForceMode.Impulse);
        else if (direction == 2)
            GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-1) * dodgeForce,ForceMode.Impulse);
        else if (direction == 3)
            GetComponent<Rigidbody>().AddForce(new Vector3(1,0,0) * dodgeForce,ForceMode.Impulse);
        else if (direction == 4)
            GetComponent<Rigidbody>().AddForce(new Vector3(-1,0,0) * dodgeForce,ForceMode.Impulse);
        StartCoroutine(Dodge());
        
        
        
    }
    IEnumerator Dodge(){
        yield return new WaitForSeconds(timewaitToShoot);
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<PlayerShooting>().enabled = true;
    }
}
