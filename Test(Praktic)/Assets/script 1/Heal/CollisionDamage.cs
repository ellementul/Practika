using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int collisionDamage = 10;
    public string collisionTag;
    public float cd = 2f;
    public bool isCD;


    public void OnCollisionEnter2D(Collision2D coll)
    {
       //Если тег объекта коллайдер которого столкнулся с коллайдером нашего объекта - Player
       if (coll.gameObject.tag == collisionTag)
       {
            if (!isCD)
            {
                isCD = true;
                StartCoroutine("CoolDown");
                //Берём у этого объекта компонент Health (Скрипт который на нём висит)
                Health health = coll.gameObject.GetComponent<Health>();
                //И вызываем функцию получения урона, в агрументе переменная урона
                health.TakeHit(collisionDamage);
            }
       }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            if (!isCD)
            {
                isCD = true;
                StartCoroutine("CoolDown");
                //Берём у этого объекта компонент Health (Скрипт который на нём висит)
                other.gameObject.GetComponent<Health>().TakeHit(collisionDamage);
            }
            //И вызываем функцию получения урона, в агрументе переменная урона
            //  health.TakeHit(damager);
        }

    }
    IEnumerator CoolDown()
    {
        isCD = true;
        yield return new WaitForSeconds(cd);
        isCD = false;
    }
}
