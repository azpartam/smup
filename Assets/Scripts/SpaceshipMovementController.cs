using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SpaceshipMovementController : MonoBehaviour
{
    private Collider m_collider;

    public float inputSpeed=5.0f;
    public float idleSpeed = 0.3f;

    private void Awake()
    {
        m_collider = gameObject.GetComponent<Collider>();
    }

    void Update()
    {
        Vector3 dir = Vector3.zero;

        dir.z = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        
        Vector3 velocity =  dir *inputSpeed + idleSpeed * transform.forward;
        transform.Translate(velocity *  Time.deltaTime, Space.World);
        KeepShipOnScreen();
    }

    void KeepShipOnScreen()
    {
        Vector3 shipExtents = m_collider.bounds.extents;

        Vector3 screenUpperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.x));
        Vector3 screenLowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0,0, Camera.main.transform.position.x));
        if (transform.position.z + shipExtents.z > screenUpperRight.z )            
        {
           // Debug.Log($"out of bonds fwd, bounds{screenUpperRight} original{screenLowerLeft} position {transform.position} ");
            transform.position= new Vector3(transform.position.x, transform.position.y, screenUpperRight.z - shipExtents.z);
        }
        if (transform.position.z - shipExtents.z < screenLowerLeft.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, screenLowerLeft.z + shipExtents.z);
        }
        if (transform.position.y + shipExtents.y > screenUpperRight.y )       
        {
            transform.position = new Vector3(transform.position.x, screenUpperRight.y -shipExtents.y, transform.position.z);
        }
        if (transform.position.y - shipExtents.y < screenLowerLeft.y)
        {
            transform.position = new Vector3(transform.position.x, screenLowerLeft.y + shipExtents.y, transform.position.z);
        }
    }
}
