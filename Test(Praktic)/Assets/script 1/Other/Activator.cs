using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject[] activeObject;
    public GameObject[] deactiveObject;
    public GameObject Player;
    public Transform[] moveSpots;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.transform.position = moveSpots[0].transform.position;
            if (activeObject[0] != null)
            {
                foreach (GameObject room in activeObject)
                {
                    room.SetActive(true);

                }
            }
            if (deactiveObject[0] != null)
            {
                foreach (GameObject room in deactiveObject)
                {
                    Debug.Log("Work?");
                    room.SetActive(false);
                }

            }
        }
    }
}
