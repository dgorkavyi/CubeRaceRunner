using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoadGenerator : MonoBehaviour
{
    public int Count = 7;
    public GameObject Road;
    private List<GameObject> _roads;
    public List<GameObject> Roads => _roads;
    public void SetRoads(List<GameObject> list) => _roads = list;
    public bool IsGenerated = false;

    void Start()
    {
        _roads = GetComponentsInChildren<RoadPart>()
            .ToList<RoadPart>()
            .Select<RoadPart, GameObject>(item => item.gameObject)
            .ToList<GameObject>();

        Generate(Count);
    }

    private void Generate(int value)
    {
        for (int i = 0; i < value; i++)
        {
            GameObject road = Instantiate(Road);
            
            road.transform.parent = transform;
            _roads.Add(road);
        }

        IsGenerated = true;
    }
}
