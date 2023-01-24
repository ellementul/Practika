using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Значение здоровья
    public int health;
    public static int healthT = 100;
    //Максимальное значение здоровья
    public int maxHealth;
    public GameObject Player;

    //Функция получения урона
    public void TakeHit(int damage)
    {
        health -= damage;

        if (gameObject.tag == "Player")
        {
            healthT = health;
        }
        //Если здоровье меньше 0 - уничтожить объект на котором весит этот скрипт
        if (health <= 0)
        {
            Destroy(gameObject);
        }
            
    }

    //Функция прибавления здоровья
    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;
        
        if (gameObject.tag == "Player")
        {
            healthT = health;
        }

        //Если здоровье, после пополнения, больше максимального значения - здоровье будет равно максимальному значению.
        if (health > maxHealth)
        {
            health = maxHealth;
        }            
    }
}