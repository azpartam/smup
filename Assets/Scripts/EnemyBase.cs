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
    public int valueInPoints = 20;
    public int valuePerHit = 5;
    public GameObject explosionPrefab;

    protected bool m_markedForDestroy = false;
    protected Spaceship m_playerRef;

    //use this to make sure enemies don't start moving until they are on screen
    protected bool m_becameVisible = false;
    Collider m_collider;

    private void Start()
    {
        m_collider = GetComponent<Collider>();
        m_collider.isTrigger = false;
        m_direction = m_direction.normalized;
        m_playerRef = FindObjectOfType<Spaceship>();
    }

    virtual protected void Update()
    {
        if (!m_becameVisible)
        {
            m_becameVisible =! SmupUtils.IsGameObjectOffScreen(m_collider.bounds.extents, transform.position);
            //activate collision when on screen
            if (m_becameVisible)
                m_collider.isTrigger = true;
            else
            {
                Debug.Log($"{gameObject.name} not on screen");
                return;
            }
        }
        UpdateTransform();
        //check if still alive
        if (m_health < 0)
            m_markedForDestroy = true;
    }

    protected virtual void UpdateTransform()
    {
        //this would be taken out and swapped for a movement component
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
            Bullet bullet = other.GetComponent<Bullet>();
            m_health -= bullet.damage;
            Destroy(bullet.gameObject);

            if (explosionPrefab is not null)
                Instantiate(explosionPrefab, bullet.transform.position, Quaternion.identity);
            GameMananger.Instance.IncreaseScore(valuePerHit);
        }
    }

}
