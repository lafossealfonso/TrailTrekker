using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public bool staminaDepleting;
    public Slider slider;
    public float currentStamina;
    [SerializeField] private float staminaBar;
    public float staminaSpeed = 0.02f;


    void Start()
    {
        staminaDepleting = true;
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        currentStamina = slider.value;

        if (staminaDepleting == true)
        {
            slider.value -= staminaSpeed * Time.deltaTime;
        }

        else
        {
            slider.value = currentStamina;
        }


    }
}
