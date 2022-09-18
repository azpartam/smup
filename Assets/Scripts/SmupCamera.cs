using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmupCamera : MonoBehaviour
{
    float m_speed;
    // Start is called before the first frame update
    void Start()
    {
        m_speed = FindObjectOfType<SpaceshipMovementController>().idleSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * m_speed * Time.deltaTime, Space.World);
    }

 
}

 