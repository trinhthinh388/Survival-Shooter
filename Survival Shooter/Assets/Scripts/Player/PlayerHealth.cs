using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float health = 100;
    public Image healthIMG;
	Animator animator;
    // Use this for initialization
    void Start()
    {
		animator = GetComponent<Animator>();
		healthIMG.fillAmount = health/100;
    }

    // Update is called once per frame
    void Update()
    {
        healthIMG.fillAmount = health/100;
		if (health <= 0)
			Dead();
    }

    public void takeDamage(float amount)
	{
		if(health > 0)
		{
			health -= amount;
		}
	}

	void Dead()
	{
		animator.SetTrigger("Dead");
	}
}
