using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class BossRun : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 5f;
    Transform player;
    Rigidbody2D rb;
    Boss boss;
    PlayerHealth playerHealth;
    public int i;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateIno, int layerIndex)
    {
  
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    override  public  void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2  newPos = Vector2.MoveTowards(rb .position ,target ,speed * Time.fixedDeltaTime );
        if (Vector2.Distance(player.position, rb.position) <= attackRange )
        {
            // animator.SetTrigger("isAttack");
            BossAttack bossAttack = boss.GetComponent<BossAttack>();
            bossAttack.Attack();
        }
        if (playerHealth.health>0 && Vector2.Distance(player.position, rb.position) <=20)
        {
            rb.MovePosition(newPos);
        }
  
   
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            animator.ResetTrigger("isAttack");
    }

}
 
