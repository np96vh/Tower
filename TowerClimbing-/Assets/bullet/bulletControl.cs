using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    public float bulletSpeed;
    // Start is called before the first frame update
    private void Update(){
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        Destroy(this.gameObject,5);
    }
    


}
