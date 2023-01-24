using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttac : MonoBehaviour
{
    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damaget = 10;
    public string collisionTag;
    private Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>(); 
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetBool("attac", true);
        }
        else
        {
            anim.SetBool("attac", false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    void AttacFlip()
    {
        Collider2D[] enemis =
                Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemis.Length; i++)
        {
            enemis[i].GetComponent<Health>().TakeHit(damaget);
        }
        
    }
}

