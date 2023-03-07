using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Penalty : MonoBehaviour
{
    public Slider slider;
    public float penaltyValue = 0.1f;

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("INDIRT");
        if(other.tag == "Player")
        {
            slider.value -= penaltyValue;
        }
    }
}
