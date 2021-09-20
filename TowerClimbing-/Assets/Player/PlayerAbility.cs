using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public float blinkForce;
    private float blinkTime;
    public float startBlinkTime;
    public Transform player;
    public PlayerMovement playermovement;

    private void Start() {
        blinkTime = startBlinkTime;
    }
    // Update is called once per frame
    void Update()
    {

            if (Input.GetKeyDown(KeyCode.LeftShift) && playermovement.direction == 1){
                player.position += Vector3.forward * blinkForce;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && playermovement.direction == 2){
                player.position += Vector3.back * blinkForce;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && playermovement.direction == 3){
                player.position += Vector3.left * blinkForce;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && playermovement.direction == 4){
                player.position += Vector3.right * blinkForce;
            }     
        
    }
    
}
