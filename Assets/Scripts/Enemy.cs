using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{
    //shooting
    public GameObject bulletPrefab;
    public GameObject targetingBulletPrefab;
    public float reloadTime = 1;
    public float currentReloadTime = 0;

    public enum ShootingPattern { Linear, Radial, Missile };
    public ShootingPattern currentShootingPattern = ShootingPattern.Linear;

    protected override void Update()
    {
        base.Update();
        if (m_becameVisible)
            Shoot();
    }

    void Shoot()
    {
        //ideally this would have been a pattern of shooting types
        currentReloadTime -= Time.deltaTime;
        if (currentReloadTime <= 0)
        {
            if (currentShootingPattern == ShootingPattern.Linear)
                ShootLinear();
            else if (currentShootingPattern == ShootingPattern.Radial)
                ShootRadial(5);
            else if (currentShootingPattern == ShootingPattern.Missile)
                ShootTargetingBullet();
            currentReloadTime = reloadTime;
        }
        
    }

    void ShootLinear()
    {
        CreateBullet(transform.position + transform.forward, transform.rotation);
    }

    void ShootRadial(int bulletCount)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            Quaternion bulletRotation = Quaternion.AngleAxis(360 * i / bulletCount, Vector3.right);
            CreateBullet(transform.position, bulletRotation * transform.rotation);
        }
    }

    void ShootTargetingBullet()
    {
        CreateTargetingBullet(transform.position + transform.forward, transform.rotation);
    }

    void CreateBullet(Vector3 position, Quaternion rotation)
    {
        GameObject bullet = Instantiate(bulletPrefab, position, rotation);
        bullet.name = $"EnemyBullet";
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.direction = bullet.transform.forward;
    }

    void CreateTargetingBullet(Vector3 position, Quaternion rotation)
    {
        GameObject bullet = Instantiate(targetingBulletPrefab, position, rotation);
        bullet.name = $"EnemyBullet";
        Bullet bulletComponent = bullet.GetComponent<Bullet>();      
        //target player's current position
        Vector3 newDir = (m_playerRef.transform.position - position).normalized;
        bulletComponent.direction = newDir;
    }


}
