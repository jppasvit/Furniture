using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ButtonPlaneClassificationHandler : MonoBehaviour
{
    public ARSessionOrigin aRSessionOrigin;
    private TapToPlaceObject tapToPlaceObject;
    private bool enable;
    private Button button;

    private void Awake()
    {
        tapToPlaceObject = aRSessionOrigin.GetComponent<TapToPlaceObject>();
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

    void Update()
    {
        // enable is putting here instead of in TurnOnAndOff because enable can be modified on another script or place
        enable = tapToPlaceObject.enablePlaneClassification;
    }

    void TurnOnAndOff()
    {
        if (enable)
        {
            tapToPlaceObject.enablePlaneClassification = false;
            button.GetComponentInChildren<Text>().text = "Enable Plane Classification";
        }
        else
        {
            tapToPlaceObject.enablePlaneClassification = true;
            button.GetComponentInChildren<Text>().text = "Disable Plane Classification";
        }
    }
}
