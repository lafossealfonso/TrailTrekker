using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class YesButton : MonoBehaviour
{
    public BugEncounter bugEncounter;

    public void OnButtonClick()
    {
        bugEncounter.yesButton = true;
    }
}
