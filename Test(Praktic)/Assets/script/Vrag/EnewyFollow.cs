using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnewyFollow : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    private Transform target;

    public int damager;
    private float stopTime;
    public float startStopTime;
    public float Normalspeed;

    private float timeBtwAttack;
    public float startTimeBtwAttack;


    void Start()
    {
        // тригер на игрока с тегом плеер 
        target = 
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Normalspeed = speed;


    }

    // Update is called once per frame
    void Update()
    {
        // Растояние которое будет подерживаться от игрока
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position =
                Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
    public void OnCollisionEnter2D(Collision2D coll)
    {
        //Если тег объекта коллайдер которого столкнулся с коллайдером нашего объекта - Player
        if (coll.gameObject.tag == ("Player"))
        {
                //Берём у этого объекта компонент Health (Скрипт который на нём висит)
                Health health = coll.gameObject.GetComponent<Health>();
                //И вызываем функцию получения урона, в агрументе переменная урона
                health.TakeHit(damager);
        }
    }
}
