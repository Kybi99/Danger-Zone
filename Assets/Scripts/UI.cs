using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private int health = 10;
    public Text healthText;
    public Health Hscript;
   


    public void Start()
    {
        healthText.text = "Health : " + health;
        //    GameObject myObject = new GameObject();
    }
    // myObject = GetComponent<Health.cs>();
    // Update is called once per frame
    void Update()
    {

        healthText.text = "Health : " + Hscript.currentHealth;
    }
}
