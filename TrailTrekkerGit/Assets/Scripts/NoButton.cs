using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoButton : MonoBehaviour
{
    public BugEncounter bugEncounter;

    public void Start()
    {
        bugEncounter = FindObjectOfType<BugEncounter>();
    }
    public void OnButtonClick()
    {
        Debug.Log("ButtonisClicked");
        bugEncounter.NoButton();
    }
}
