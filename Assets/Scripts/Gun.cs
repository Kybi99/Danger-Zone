using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] [Range(0.5f, 1.5f)] float fireRate = 1;
    [SerializeField] [Range(1, 10)] private int damage = 1;
    public AudioSource gunFireSource; 
    private float timer;



    private void Start()
    {
        int layer = 1 << LayerMask.NameToLayer("Default");
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun()
    {
        
        gunFireSource.Play();

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);


        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100,1, QueryTriggerInteraction.Ignore))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            Debug.Log(hitInfo.collider);
            
    
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
