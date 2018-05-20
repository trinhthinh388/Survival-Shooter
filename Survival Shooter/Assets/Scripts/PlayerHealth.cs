using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public Image healthIMG;
    public Text healthText;
    public float healthDefault = 100f;

    Animator anim;
    public float currentHealth;
    bool isDead;
    PlayerMovement playerMovement;
	// Use this for initialization
	void Start () {
        currentHealth = healthDefault;
        healthIMG.fillAmount = currentHealth / 100;
        //healthText.text = currentHealth.ToString();
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
            return;
        healthText.text = currentHealth.ToString();
        healthIMG.fillAmount = currentHealth / 100;
        if(currentHealth <= 0)
        {
            Dead();
        }
	}

    public void TakeDamage(float amount)
    {
        if (isDead)
            return;
        currentHealth -= amount;
    }

    void Dead()
    {
        isDead = true;
        anim.SetTrigger("Dead");
        playerMovement.enabled = false;
    }
}
