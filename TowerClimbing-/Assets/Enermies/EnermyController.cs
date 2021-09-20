using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyController : MonoBehaviour
{
    public int currentEHp;
    private int fullEHp = 100;
    // Start is called before the first frame update
    void Start()
    {
        currentEHp = fullEHp;
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "bullet")
        {
            Debug.Log("hit by bullet");
        }
    }
    
}
