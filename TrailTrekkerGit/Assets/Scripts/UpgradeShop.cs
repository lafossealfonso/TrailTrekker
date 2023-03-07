using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour
{
    public int upgradeBoot;
    public int upgradeStamina;
    public int upgradeNet;

    public Stamina stamina;
    public BugEncounter bugEncounter;
    public Penalty penalty;

    public GameObject ShopUIWindow;
    [SerializeField] private GameObject ShopObject;

    [SerializeField] private TextMeshProUGUI notifications;
    [SerializeField] private TextMeshProUGUI bugCount;

    public void Start()
    {
        upgradeBoot = 1;
        upgradeStamina = 1;
        upgradeNet = 1;

        notifications.text = ("");

        stamina = FindObjectOfType<Stamina>();
       
        penalty = FindObjectOfType<Penalty>();

        ShopUIWindow.SetActive(false);
    }

    public void Update()
    {
        bugCount.text = ("Bug Count = " + bugEncounter.bugCount);

    }

    private void OnTriggerEnter(Collider other) //will activate the pop up window
    {
        if (other.tag == "Player")
        {
            ShopUIWindow.SetActive(true);
            ShopObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void BootButton()
    {
        if(penalty.penaltyValue > 0.04 && bugEncounter.bugCount >= upgradeBoot)
        {
            penalty.penaltyValue -= 0.02f;
            bugEncounter.bugCount -= upgradeBoot;
            upgradeBoot += 1;
        }

        else if (penalty.penaltyValue == 0.04f)
        {
            notifications.text = ("Reached Upgrade Limit");
        }

        else
        {
            notifications.text = ("Not Enough Bugs!!");
        }
    }
    
    public void StaminaButton()
    {
        if(stamina.staminaSpeed > 0.005f && bugEncounter.bugCount >= upgradeStamina)
        {
            stamina.staminaSpeed -= 0.005f;
            bugEncounter.bugCount -= upgradeStamina;
            upgradeStamina += 1;
        }

        else if (stamina.staminaSpeed == 0.005f)
        {
            notifications.text = ("Reached Upgrade Limit");
        }

        else
        {
            notifications.text = ("Not Enough Bugs!!");
        }
    }

    public void NetButton()
    {
        if(bugEncounter.minProbability < 4 && bugEncounter.bugCount >= upgradeBoot)
        {
            bugEncounter.minProbability += 1;
            bugEncounter.bugCount -= upgradeBoot;
            upgradeBoot += 1;
        }

        else if(bugEncounter.minProbability == 3)
        {
            notifications.text = ("Reached Upgrade Limit");
        }

        else{
            notifications.text = ("Not Enough Bugs!!");
        }
        
    }

    public void LeaveButton()
    {
        ShopUIWindow.SetActive(false);
        notifications.text = ("");
        stamina.currentStamina = 1;
    }
}
