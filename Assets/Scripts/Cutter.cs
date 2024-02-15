using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    public float moveValue = 5f;
    public float drop = 3.0f;
    Vector3 randomAngle;
    public GameObject knife;
    Rigidbody rb;
    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            rb.isKinematic = false;
            rb.AddForce(drop, 0f, 0f);
            //rb.AddTorque(-Vector3.up * 12000f, ForceMode.Impulse);
            //randomAngle = new Vector3(Random.Range(-0.8f, -2f), Random.Range(0.2f,0.3f), Random.Range(-2f, 2f));
            //rb.AddForce(randomAngle * Random.Range(650,1500), ForceMode.Impulse);
        }
    }
    
}
