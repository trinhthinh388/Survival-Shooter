using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public float health = 100;
	public Image healthIMG;
	public bool isDead;
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		healthIMG.fillAmount = health / 100;
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
		{
			StartCoroutine(Dead());
		}
		healthIMG.fillAmount = health / 100;
	}

    public void takeDamage(float amount)
	{
		if (isDead)
			return;
		
		health -= amount;
	}

    IEnumerator Dead()
	{
		isDead = true;
		animator.SetTrigger("PlayerDead");
		yield return new WaitForSeconds(1);
		Destroy(gameObject);
	}
}
