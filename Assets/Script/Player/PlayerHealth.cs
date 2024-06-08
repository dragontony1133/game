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
    public Image healthBar;
    public float healthAmount = 100f;

    public void TakeDamage(int damge)
    {
       if(health > 0) {
            health -= damge;
            StartCoroutine(DamageAnimation());
            healthAmount -= damge ;
            healthBar.fillAmount = healthAmount / 100f;
        }
        else
        {
            Die();
        }
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
        Debug.Log("Animation damage ne");
        Animator playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
      playerAnimator.SetBool("isHurting", true);
      yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool("isHurting", false);
    
    }
}
