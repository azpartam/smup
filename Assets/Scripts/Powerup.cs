using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update

    //maybe replace direclty with velocity
    public float speed =2;
    public Vector3 dir = -Vector3.forward;
    //maybe not necessary
    public float rotationSpeed = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up,  rotationSpeed * Time.deltaTime, Space.Self);
        transform.Translate(speed * dir * Time.deltaTime);
    }
}
