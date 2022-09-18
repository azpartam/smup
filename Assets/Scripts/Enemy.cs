using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{     
    //shooting
    public GameObject bulletPrefab;
    public float reloadTime = 1;
    public float currentReloadTime=0;

    protected override void Update()
    {
        ShootRadial(5);
        base.Update();
    }
    void ShootLinear()
    {
        currentReloadTime -= Time.deltaTime;
        if (currentReloadTime <= 0)
        { 
            GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
            bullet.name = "EnemyBullet";
            Bullet bulletComponent = bullet.GetComponent<Bullet>();
            bulletComponent.direction = -transform.forward;
         


            currentReloadTime = reloadTime;
        }
    }

    void ShootRadial(int bulletCount)
    {
        currentReloadTime -= Time.deltaTime;
        if (currentReloadTime <= 0)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                Quaternion bulletRotation = Quaternion.AngleAxis(360*i / bulletCount , Vector3.right);

                

                GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletRotation * transform.rotation);
                              
                bullet.name = $"EnemyBullet{i}";
                Bullet bulletComponent = bullet.GetComponent<Bullet>();
                bulletComponent.direction = bullet.transform.forward;
                
            }

            currentReloadTime = reloadTime;
        }

    }


}
