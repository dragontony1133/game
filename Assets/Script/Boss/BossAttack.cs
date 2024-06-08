using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.Timeline;
using Unity.VisualScripting;

public class BossAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public float attackRange = 5f;
    public int i=0;
    public Animator animator;
    //  public Vector3 attackOffset;
    public LayerMask attackMask;
    public bool canAttack = true;

    IEnumerator BossCoolDown()
    { 
        yield return new WaitForSeconds(2f);
        canAttack = true;
    }  
    public void Attack()
    {
        if (canAttack){
            canAttack=false;
            animator.SetTrigger("isAttack");
            Vector3 pos = transform.position;
            //   pos += transform.right * attackOffset.x;
            //  pos += transform.up * attackOffset.y;
            Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
            if (colInfo != null)
            {
                colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
            StartCoroutine(BossCoolDown());
        }


    }

}