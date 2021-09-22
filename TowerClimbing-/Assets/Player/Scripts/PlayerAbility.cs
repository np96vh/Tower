using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public float blinkForce;
    private float blinkTime;
    public float startBlinkTime;
    private int direction;
    public float timeCanDodge;
    public bool canDash = false;
    public Rigidbody _rb;

    private void Start() {
        blinkTime = startBlinkTime;
        _rb = GetComponent<Rigidbody>();
        canDash = false;

    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            canDash = true;
        }
        if (direction == 0)
        {
            if (canDash && Input.GetKeyDown(KeyCode.A) )
            {
                direction = 1; 
            } else if ( canDash && Input.GetKeyDown(KeyCode.D) )
            {
                direction = 2;
            } else if (canDash && Input.GetKeyDown(KeyCode.W) )
            {
                direction = 3;
            } else if (canDash && Input.GetKeyDown(KeyCode.S) )
            {
                direction = 4;
            } 
        }
        else 
        {   
            if (blinkTime <= 0)
            {
                direction = 0;
                blinkTime = startBlinkTime;
                _rb.velocity = Vector3.zero;
            }
            else 
            {
                blinkTime -= Time.deltaTime;
                
                if (direction == 1)
                {
                    _rb.velocity = Vector3.left * blinkForce;
                    canDash = false;
                }
                else if (direction == 2)
                {
                    _rb.velocity = Vector3.right * blinkForce;
                    canDash = false;
                }
                else if (direction == 3)
                {
                    _rb.velocity = Vector3.forward * blinkForce;
                    canDash = false;
                }
                else if (direction == 4)
                {
                    _rb.velocity = Vector3.back * blinkForce;
                    canDash = false;
                }              
            }
        }

       
       
    }
    
}
