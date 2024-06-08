using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 350;

    public void TakeDamage(int damge)
    {

        health -= damge;

 
        if (health <= 0)
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
        BossAttack bossScript = GameObject.Find("Boss").GetComponent<BossAttack>();
        NewBehaviourScript playerScript = GameObject.Find("Player").GetComponent<NewBehaviourScript>();
        bossAnimator.SetBool("isDead", true);
        yield return new WaitForSeconds(0.5f);
        playerAnimator.enabled = false;
        bossScript.enabled = false;
        playerScript.enabled = false;
    }

}
