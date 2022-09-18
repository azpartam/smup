using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 2.5f;
    public Vector3 direction = Vector3.forward;
    public float damage = 5;
    [SerializeField]
    float lifeTime = 5;

    public enum BulletType
    { 
        player, enemy
    } 
    [SerializeField]
    BulletType m_bulletType;
    public BulletType bulletType { get => m_bulletType; }

    bool m_markedForDestroy = false;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        m_markedForDestroy |= SmupUtils.IsGameObjectOnScreen(Vector3.zero, Vector3.one);
    }

    private void LateUpdate()
    {
        if (m_markedForDestroy)
            Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if ((bulletType == BulletType.enemy && other.CompareTag("Player")) || (bulletType == BulletType.player && other.CompareTag("Enemy")))
    //    {
    //        m_markedForDestroy = true;
    //    }
    //}
}
