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
    public float cd = 2f;
    public bool isCD;
    public GameObject[] hil;


    void Start()
    {
        // ������ �� ������ � ����� ����� 
        target = 
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Normalspeed = speed;


    }

    // Update is called once per frame
    void Update()
    {
        // ��������� ������� ����� ������������� �� ������
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position =
                Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
    /*public void OnCollisionEnter2D(Collision2D coll)
    {
        //���� ��� ������� ��������� �������� ���������� � ����������� ������ ������� - Player
        if (coll.gameObject.tag == ("Player"))
        {
                //���� � ����� ������� ��������� Health (������ ������� �� �� �����)
                Health health = coll.gameObject.GetComponent<Health>();
                //� �������� ������� ��������� �����, � ��������� ���������� �����
                health.TakeHit(damager);
        }
    }*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            if (!isCD)
            {
                isCD = true;
                StartCoroutine("CoolDown");
                //���� � ����� ������� ��������� Health (������ ������� �� �� �����)
                other.gameObject.GetComponent<Health>().TakeHit(damager);
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
            //���� � ����� ������� ��������� Health (������ ������� �� �� �����)
                other.gameObject.GetComponent<Health>().TakeHit(damager);
            }
            //� �������� ������� ��������� �����, � ��������� ���������� �����
            //  health.TakeHit(damager);
        }

    }

    IEnumerator CoolDown()
    {
        isCD = true;
        yield return new WaitForSeconds(cd);
        isCD = false;
    }

    public void SpawnHil()
    {
        Debug.Log("HilSpawn");
        Instantiate(hil[0], transform.position , Quaternion.identity);
    }
}
