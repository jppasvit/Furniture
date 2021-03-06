using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ButtonFurnitureHandler : MonoBehaviour
{
    public GameObject furniture;
    public ARSessionOrigin aRSessionOrigin;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(SelectFurniture);
    }
    void SelectFurniture()
    {
        var tapToPlaceObject = aRSessionOrigin.GetComponent<TapToPlaceObject>();
        if ( tapToPlaceObject != null )
        {
            tapToPlaceObject.furnitureToInstantiate = furniture;
            tapToPlaceObject.spawnedFurniture = null;
        }
    }
}
