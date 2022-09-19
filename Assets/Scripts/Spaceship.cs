using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    //weapons
    [SerializeField]
    float m_reloadTime = 0.2f;
    float m_currentReloadTime;
    public List<GameObject> m_weapons;
    GameObject m_bulletPrefab;

    //health
    [SerializeField]
    HealthBar m_healthBar;
    [SerializeField]
    float m_maxHealth;
    float m_health;


    // Start is called before the first frame update
    void Start()
    {
        m_currentReloadTime = 0;
        //to be replaced with different kind of bullets , which can come from pickups or chosen
        m_bulletPrefab = m_weapons[0];
        m_health = m_maxHealth;
        if (m_healthBar is null)
        {
            m_healthBar = FindObjectOfType<HealthBar>();
        }
        m_healthBar.SetMaxValue(m_maxHealth);
        m_healthBar.SetValue(m_health);

    }

    // Update is called once per frame
    void Update()
    {
        m_currentReloadTime -= Time.deltaTime;
        if (Input.GetButton("Fire1") && m_currentReloadTime < 0)
        {
            GameObject bullet = Instantiate(m_bulletPrefab, transform.position + transform.forward * 2, transform.rotation);
            bullet.name = "PlayerBullet";
            m_currentReloadTime = m_reloadTime;
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            //instantly die on contact with enemies
            GameMananger.Instance.PlayerDied();
        }

        if (other.CompareTag("EnemyBullet"))
        {
            Bullet bullet = other.gameObject.GetComponentInChildren<Bullet>();
            TakeDamage(bullet.damage);
            Destroy(bullet.gameObject);
        }
        if (other.CompareTag("EndOfLevel"))
        {
            GameMananger.Instance.EndOfLevel();
        }
    }

    private void TakeDamage(float _damage)
    {
        m_health -= _damage;
        m_healthBar.SetValue(m_health);
        //add flashing 
        // TODO: handle dying print score
        if (m_health < 0)
        {
            GameMananger.Instance.PlayerDied();

        }
    }


}
