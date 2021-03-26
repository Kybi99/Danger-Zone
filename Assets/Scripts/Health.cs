using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    public GameObject go;
    [SerializeField] private int startingHealth = 5;
    public int currentHealth;
    private UI ui;



    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        //currentHealth.GetComponent<UI>().Register();
        if (currentHealth <= 0)
        {
            //go.GetComponent<Animator>().Play("Rifle Death");

            //if (this.go.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Rifle Death"))
            //{
            Die();
           // }
            
        }
    }
    private void Die()
    {
        gameObject.SetActive(false);
    }

    /*private void Update()
    {
        
    }
    private void Start()
    {
        ui.Register(currentHealth);
    }*/
}
