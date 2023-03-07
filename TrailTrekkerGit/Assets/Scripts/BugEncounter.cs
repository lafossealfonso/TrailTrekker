using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BugEncounter : MonoBehaviour
{
    [SerializeField] private GameObject bugText;

    public GameObject thisBug;
    public bool yesButton;
    public Stamina Stamina;
    public bool noButton;
    public float netPenalty;
    public float catchProbability;
    public float minProbability;
    public float netNumber;
    public int randomNumber;

    [SerializeField] private GameObject bugCaughtWindow;
    [SerializeField] private GameObject bugFailedWindow;
    public TextMeshProUGUI bugCaughtText;
    public int bugCount;

    public UpgradeShop UpgradeShop;

    


    private void Start()
    {
        bugCount = 0;
        netNumber = 3;
        minProbability = 1;
        catchProbability = 3;
        netPenalty = 0.1f;
        bugText.SetActive(false);
        bugCaughtWindow.SetActive(false);
        bugFailedWindow.SetActive(false);
        Stamina = FindObjectOfType<Stamina>();
        UpgradeShop = FindObjectOfType<UpgradeShop>();
    }


    private void OnTriggerEnter(Collider other) //will activate the pop up window
    {
        if(other.tag == "Player")
        {
            bugText.SetActive(true);
            thisBug.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void Update()
    {
        if (bugText.activeInHierarchy || bugCaughtWindow.activeInHierarchy || bugFailedWindow.activeInHierarchy || UpgradeShop.ShopUIWindow.activeInHierarchy)
        {
            Stamina.staminaDepleting = false;
            Time.timeScale = 0;
        }

        else
        {
            Time.timeScale = 1;
        }

        Debug.Log(bugCount);

        

    }

    public void NoButton()
    {
        bugText.SetActive(false);
        bugCaughtWindow.SetActive(false);
        bugFailedWindow.SetActive(false);
        Stamina.staminaDepleting=true;
        
        Time.timeScale = 1;

     
    }

    public void YesButton()
    {
        randomNumber = (int)Random.Range(minProbability, 4);
        if (randomNumber == netNumber)
        {
            Debug.Log(randomNumber);
            bugText.SetActive(false);
            bugCount += 1;
            bugCaughtText.text = "Bug Caught. Current Bug Count = "+ bugCount +".";
            bugCaughtWindow.SetActive(true);
            Stamina.currentStamina =- netPenalty;


            

        }

        else if(randomNumber != netNumber)
        {
            bugText.SetActive(false);
            bugFailedWindow.SetActive(true);
            Stamina.currentStamina = -netPenalty;


            //     Destroy(thisBug);
          
        }
    }
}
