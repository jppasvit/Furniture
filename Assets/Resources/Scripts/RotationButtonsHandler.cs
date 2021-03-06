using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class RotationButtonsHandler : MonoBehaviour
{
    public ARSessionOrigin aRSessionOrigin;
    private TapToPlaceObject tapToPlaceObject;

    public Button xButton;
    private Color xButtonStartColor;
    public Button yButton;
    private Color yButtonStartColor;
    public Button zButton;
    private Color zButtonStartColor;

    public Button arrowUpButton;
    public Button arrowDownButton;

    public float addToAxis = 45;
    /*
     * x = 0
     * y = 1
     * z = 2
     */
    private int axisSelected = 0;

    void Awake()
    {
        xButtonStartColor = xButton.GetComponent<Image>().color;
        yButtonStartColor = yButton.GetComponent<Image>().color;
        zButtonStartColor = zButton.GetComponent<Image>().color;
        tapToPlaceObject = aRSessionOrigin.GetComponent<TapToPlaceObject>();
    }
    void Start()
    {
        if (axisSelected == 0)
        {
            SelectAxisX();
        }
        else if (axisSelected == 1 )
        {
            SelectAxisY();
        }
        else if (axisSelected == 2)
        {
            SelectAxisZ();
        }
        xButton.onClick.AddListener(SelectAxisX);
        yButton.onClick.AddListener(SelectAxisY);
        zButton.onClick.AddListener(SelectAxisZ);
        arrowUpButton.onClick.AddListener(AddToAxis);
        arrowDownButton.onClick.AddListener(SubstractToAxis);
    }

    void SelectAxisX()
    {
        axisSelected = 0;
        xButton.GetComponent<Image>().color = Color.red;
        yButton.GetComponent<Image>().color = yButtonStartColor;
        zButton.GetComponent<Image>().color = zButtonStartColor;
    }

    void SelectAxisY()
    {
        axisSelected = 1;
        xButton.GetComponent<Image>().color = xButtonStartColor;
        yButton.GetComponent<Image>().color = Color.red;
        zButton.GetComponent<Image>().color = zButtonStartColor;
    }

    void SelectAxisZ()
    {
        axisSelected = 2;
        xButton.GetComponent<Image>().color = xButtonStartColor;
        yButton.GetComponent<Image>().color = yButtonStartColor;
        zButton.GetComponent<Image>().color = Color.red;
    }

    void AddToAxis( float addToAxis)
    {
        if ( tapToPlaceObject.spawnedFurniture != null )
        {
            if (axisSelected == 0)
            {
                tapToPlaceObject.spawnedFurniture.transform.Rotate(addToAxis, 0, 0);
            }
            else if (axisSelected == 1)
            {
                tapToPlaceObject.spawnedFurniture.transform.Rotate(0, addToAxis, 0);
            }
            else if (axisSelected == 2)
            {
                tapToPlaceObject.spawnedFurniture.transform.Rotate(0,0, addToAxis);
            }
        }
    }

    void AddToAxis()
    {
        AddToAxis(addToAxis);
    }

    void SubstractToAxis()
    {
        AddToAxis(-addToAxis);
    }

}
