using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class SizeButtonsHandler : MonoBehaviour
{
    public ARSessionOrigin aRSessionOrigin;
    private TapToPlaceObject tapToPlaceObject;

    public Button upButton;
    public Button downButton;

    public float addSize = (float)0.05;

    void Awake()
    {
        tapToPlaceObject = aRSessionOrigin.GetComponent<TapToPlaceObject>();
    }
    void Start()
    {
        upButton.onClick.AddListener(AddToAxis);
        downButton.onClick.AddListener(SubstractToAxis);
    }

    void AddToAxis(float addSize)
    {
        if (tapToPlaceObject.spawnedFurniture != null)
        {
            tapToPlaceObject.spawnedFurniture.transform.localScale += new Vector3(addSize, addSize, addSize);
        }
    }

    void AddToAxis()
    {
        AddToAxis(addSize);
    }

    void SubstractToAxis()
    {
        AddToAxis(-addSize);
    }

}
