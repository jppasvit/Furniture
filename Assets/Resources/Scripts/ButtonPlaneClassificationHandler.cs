using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ButtonPlaneClassificationHandler : MonoBehaviour
{
    public TapToPlaceObject tapToPlaceObject;
    private bool enable;
    private Button button;

    private void Awake()
    {
        enable = tapToPlaceObject.enablePlaneClassification;
        button = gameObject.GetComponent<Button>();
    }
    void Start()
    {
        if (enable)
        {
            button.GetComponentInChildren<Text>().text = "Disable Plane Classification";
        }
        else
        {
            button.GetComponentInChildren<Text>().text = "Enable Plane Classification";
        }
        button.onClick.AddListener(TurnOnAndOff);
    }

    void TurnOnAndOff()
    {
        if (enable)
        {
            enable = false;
            tapToPlaceObject.enablePlaneClassification = false;
            button.GetComponentInChildren<Text>().text = "Enable Plane Classification";
        }
        else
        {
            enable = true;
            tapToPlaceObject.enablePlaneClassification = true;
            button.GetComponentInChildren<Text>().text = "Disable Plane Classification";
        }
    }
}
