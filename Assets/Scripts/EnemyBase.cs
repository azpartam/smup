using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
    protected float m_health = 0;
    [SerializeField]
    protected Vector3 m_direction = -Vector3.forward;
    [SerializeField]
    protected float m_speed = 3;
    
    public float damage = 10;
    public int valueInPoints = 10;

    protected bool m_markedForDestroy = false;
    

    virtual protected void Update()
    {
      
        UpdateTransform();
        //check if still alive
        if (m_health < 0)
            m_markedForDestroy = true;
    }

    protected virtual void UpdateTransform()
    {
        transform.Translate(m_speed * m_direction * Time.deltaTime, Space.World);
    }

    private void LateUpdate()
    {
        if (m_markedForDestroy)
        {
            Destroy(gameObject);
            GameMananger.Instance.IncreaseScore(valueInPoints);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LevelEdge"))
        {
            m_markedForDestroy = true;
        }
        if (other.CompareTag("SpaceshipBullet"))
        {
            Debug.Log("enemy hit");
            Bullet bullet = other.GetComponent<Bullet>();
            m_health -= bullet.damage;
            Destroy(bullet.gameObject);
        }
    }

}
