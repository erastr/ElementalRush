using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class RoadCreator : MonoBehaviour
{
    [SerializeField] private GameObject roadPrefab;
    [SerializeField] private GameObject road2Prefab;
    [SerializeField] private GameObject finishRoadPrefab;
    [SerializeField] private Transform roadParent;

    [SerializeField] private float distance;

    [SerializeField] private int roadCount;

    [SerializeField] private List<GameObject> roadList = new List<GameObject>();

    //Path generating method
#if UNITY_EDITOR
    [Button]
    public void CreateRoad()
    {
        float posZ = 0;

        GameObject road;

        for (int i = 0; i < roadCount; i++)
        {

            if (i % 2 == 0)
                road = Instantiate(roadPrefab, new Vector3(0, 0, posZ), Quaternion.identity, roadParent);
            else
                road = Instantiate(road2Prefab, new Vector3(0, 0, posZ), Quaternion.identity, roadParent);

            posZ += distance;
            roadList.Add(road);

        }

        road = Instantiate(finishRoadPrefab, new Vector3(0, 0, posZ), Quaternion.identity, roadParent);

        posZ += distance;
        roadList.Add(road);
    }
#endif

//The method that deletes the last path
#if UNITY_EDITOR
    [Button]
    public void RemoveLastRoad()
    {
        if (roadList.Count <= 0) 
            return;

        DestroyImmediate(roadList[roadList.Count - 1]);

        roadList.RemoveAt(roadList.Count - 1);
    }
#endif

//Method that deletes all paths
#if UNITY_EDITOR
    [Button]
    public void DestroyAllRoad()
    {
        if (roadList.Count <= 0)
            return;

        for (int i = 0; i < roadList.Count; i++)
        {
            DestroyImmediate(roadList[i]);
        }

        roadList.Clear();
    }

#endif

}
