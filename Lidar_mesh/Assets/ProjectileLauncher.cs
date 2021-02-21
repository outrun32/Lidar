using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField]
    Rigidbody m_proj_Prefab;

    public Rigidbody projectilePrefab { get => m_proj_Prefab; set => m_proj_Prefab = value; }

    public float projectileSpeed = 10f;
    void Update()
    {
        if(m_proj_Prefab == null)
        {
            return;
        }
        if (Input.touchCount == 0)
        {
            return;
        }


        var touch = Input.touches[0];
        if(touch.phase == TouchPhase.Began)
        {
            var ray = GetComponent<Camera>().ScreenPointToRay(touch.position);
            var projectile = Instantiate(m_proj_Prefab, ray.origin, Quaternion.identity);
            var rigidbody = projectile.GetComponent<Rigidbody>();
            rigidbody.velocity = ray.direction * projectileSpeed;
        }
    }
}
