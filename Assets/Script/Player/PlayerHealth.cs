using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    private const int HEALTH_MAX = 100;
    public Image healthBar;
    public void TakeDamage(int damge)
    {   
       if(health > 0) {
            health -= damge;
            StartCoroutine(DamageAnimation());
            // healthAmount -= damge ;
            // healthBar.fillAmount = healthAmount / 100f;
        }
        else
        {
            Die();
        }
    }
     public void Heal(int healthAmount)
    {   
       if(health + healthAmount>=  HEALTH_MAX)
            health = HEALTH_MAX;
        else 
            health += healthAmount;
    }
    void Die()
    {
        StartCoroutine(EndGameEffect());
    }
    IEnumerator EndGameEffect()
    {
      Animator playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
      Animator bossAnimator = GameObject.Find("Boss").GetComponent<Animator>();
        NewBehaviourScript script = GameObject.Find("Player").GetComponent<NewBehaviourScript>();
        playerAnimator.SetBool("isHurting", false);
        playerAnimator.SetBool("isDead", true);
        yield return new WaitForSeconds(0.5f);
        playerAnimator.enabled = false;
        script.enabled = false;
    }

    IEnumerator DamageAnimation()
    {
        Animator playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
      playerAnimator.SetBool("isHurting", true);
      yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool("isHurting", false);
    }
    
}
