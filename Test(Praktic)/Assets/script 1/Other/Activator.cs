using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject[] activeObject;
    public GameObject[] deactiveObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
        if (activeObject[0] != null)
        { 
           foreach(GameObject room in activeObject)
             {
            room.SetActive(true);
             }
        }
        if (deactiveObject[0] != null)
        {
            foreach (GameObject room in deactiveObject)
            {
                room.SetActive(false);
            }
           }
        }
    }
}
