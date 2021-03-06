using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARPlaneManager))]
[RequireComponent(typeof(PlaneClassificationManager))]
public class TapToPlaceObject : MonoBehaviour
{
    public GameObject furnitureToInstantiate;
    public bool enablePlaneClassification = true;
    public GameObject spawnedFurniture { get; set; }
    private Vector2 touchPosition;
    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    private PlaneClassificationManager planeClassificationManager;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
        planeClassificationManager = GetComponent<PlaneClassificationManager>();
    }

    void Update()
    {
        if ( !TryGetTouchPosition(out touchPosition) )
        {
            return;
        }

        SelectSpawn(touchPosition);

        if ( raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon) )
        {
            var hitPose = hits[0].pose;

            if (enablePlaneClassification)
            {
                ARPlane plane = planeManager.GetPlane(hits[0].trackableId);

                Furniture.FurnitureEnum spawnFurnitureType = Furniture.FurnitureEnum.None;
                if ( spawnedFurniture != null )
                {
                    spawnFurnitureType = spawnedFurniture.GetComponent<Furniture>().type;
                }
                Furniture.FurnitureEnum furnitureToInstantiateType = furnitureToInstantiate.GetComponent<Furniture>().type;
                
                // It could be in an enormous if sentence, but this way is more readable
                if ( planeClassificationManager.IsFloor(plane) && ( spawnFurnitureType == Furniture.FurnitureEnum.Table || ( spawnedFurniture == null && furnitureToInstantiateType == Furniture.FurnitureEnum.Table ) ) )
                {
                    SpawnOrLocateFurniture(furnitureToInstantiate, hitPose.position, hitPose.rotation);
                }
                else if ( planeClassificationManager.IsTable(plane) && ( spawnFurnitureType == Furniture.FurnitureEnum.Lamp || ( spawnedFurniture == null && furnitureToInstantiateType == Furniture.FurnitureEnum.Lamp  ) ) )
                {
                    SpawnOrLocateFurniture(furnitureToInstantiate, hitPose.position, hitPose.rotation);
                }
                else if ( planeClassificationManager.IsVertical(plane) && ( spawnFurnitureType == Furniture.FurnitureEnum.Shelf || ( spawnedFurniture == null && furnitureToInstantiateType == Furniture.FurnitureEnum.Shelf ) ) )
                {
                    SpawnOrLocateFurniture(furnitureToInstantiate, hitPose.position, hitPose.rotation);
                }
                else if ( spawnFurnitureType == Furniture.FurnitureEnum.All || furnitureToInstantiateType == Furniture.FurnitureEnum.All)
                {
                    SpawnOrLocateFurniture(furnitureToInstantiate, hitPose.position, hitPose.rotation);
                }
            }
            else 
            {
                SpawnOrLocateFurniture(furnitureToInstantiate, hitPose.position, hitPose.rotation);
            }
        }
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void SpawnOrLocateFurniture(GameObject furnitureToInstantiate, Vector3 position, Quaternion rotation)
    {
        if (spawnedFurniture == null)
        {
            spawnedFurniture = Instantiate(furnitureToInstantiate, position, rotation);
        }
        else
        {
            spawnedFurniture.transform.position = position;
        }
    }

    void SelectSpawn (Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                RaycastHit hitObject;

                if (Physics.SphereCast(ray, (float)0.1, out hitObject))
                {
                    var furniture = hitObject.transform.GetComponent<Furniture>();

                    if (furniture != null)
                    {
                        spawnedFurniture = hitObject.transform.gameObject;
                    }
                }
            }
        }
    }
}
