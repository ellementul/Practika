using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shet : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Update()
    {
        Heal();
    }
    void Heal()
    {
        text.text = "Рассудок " + Health.healthT + "%";
        if (Health.healthT == 0)
        {
            return;
        }
    }
}
