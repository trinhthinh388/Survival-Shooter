using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour {

    public float healthStart = 100f;
    public Image healthIMG;
    public ParticleSystem shotPar;
    public float currentHealth;
    Animator anim;
    bool isDead;
	// Use this for initialization
	void Start () {
        currentHealth = healthStart;
        healthIMG.fillAmount = currentHealth / 100;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
            return;
        healthIMG.fillAmount = currentHealth / 100;
	}

    public void TakeDamage(float amount, Vector3 point)
    {
        if (isDead)
            return;
        currentHealth -= amount;
        shotPar.transform.position = point;
        shotPar.Stop();
        shotPar.Play();
        if (currentHealth <= 0)
            Dead();
        
    }

    void Dead()
    {
        isDead = false;
        anim.SetTrigger("Dead");
        Destroy(gameObject, 2f);
    }
}
