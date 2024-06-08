using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 15;
    public float attackRange = 5f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        Debug.Log(colInfo);
        if (colInfo != null)
        {
            colInfo.GetComponent<BossHealth>().TakeDamage(attackDamage);
        }

    }
}
