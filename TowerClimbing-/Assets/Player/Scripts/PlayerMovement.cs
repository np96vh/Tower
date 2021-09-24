using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float speed;

    public static float hAxis;
    public static float vAxis;
    public GameObject playerObj;
    private Camera mainCamera;
    private Vector3 mousePos;
    public Rigidbody _rb;
    public Animator animator;
    private void Start() {
        _rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        mainCamera = FindObjectOfType<Camera>();
    }
    //Methods
    void Update() {
        //Player facing mouse
       Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
       Plane groundPlane = new Plane(Vector3.up,Vector3.zero);
       float rayLength;

       if (groundPlane.Raycast(cameraRay,out rayLength)){
           Vector3 pointtoLook = cameraRay.GetPoint(rayLength);

           transform.LookAt(new Vector3(pointtoLook.x,transform.position.y,pointtoLook.z));
       }
        //Player Movement
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(hAxis,0f,vAxis);
        _rb.MovePosition(_rb.position + movement * speed * Time.fixedDeltaTime);
       Animation();
    }

   
    private void Animation(){
        if (hAxis != 0 || vAxis != 0)
            animator.SetBool("Run",true);
        else if (vAxis == 0 || hAxis == 0)
        {
            animator.SetBool("Run",false);
        }
    }
}
