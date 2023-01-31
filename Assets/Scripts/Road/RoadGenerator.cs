using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoadGenerator : MonoBehaviour
{
    public int Count = 7;
    public RoadPart Road;
    private List<RoadPart> _roads;
    public List<RoadPart> Roads => _roads;
    public void SetRoads(List<RoadPart> list) => _roads = list;
    public bool IsGenerated = false;

    void Start()
    {
        _roads = GetComponentsInChildren<RoadPart>().ToList();

        Generate(Count);
    }

    private void Generate(int value)
    {
        for (int i = 0; i < value; i++)
        {
            RoadPart road = Instantiate(Road);
            
            road.transform.parent = transform;
            _roads.Add(road);
        }

        IsGenerated = true;
    }
}
