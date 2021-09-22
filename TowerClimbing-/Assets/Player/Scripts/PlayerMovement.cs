using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    protected float speed;
    public float normalSpeed;
    public GameObject playerObj;
    public GameObject camera;

    public Rigidbody _rb;
    public float waitTime;
    private void Start() {
        speed = normalSpeed;
        _rb = GetComponent<Rigidbody>();
    }
    //Methods
    void Update() {
        //Player facing mouse
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);    
        float hitDist = 0.0f;

        if (playerPlane.Raycast(ray,out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation,targetRotation, 7f * Time.deltaTime);
        }

        //Player Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            
      
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
          
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        
    }
}
