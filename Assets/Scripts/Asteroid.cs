using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : EnemyBase
{
    [SerializeField]
    float m_rotationSpeed = 0.3f;

    protected override void UpdateTransform()
    {
        transform.Rotate(new Vector3(0, 0, 1) * m_rotationSpeed * Time.deltaTime, Space.Self);
        transform.Translate(m_speed * m_direction * Time.deltaTime, Space.World);
    }
}
