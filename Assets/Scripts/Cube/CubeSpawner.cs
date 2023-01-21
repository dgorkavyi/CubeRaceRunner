using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject CubePrefab;

    [SerializeField]
    private float Distance = 0.09f;

    private int Count = 4;
    private List<GameObject> _items = new List<GameObject>();

    public void Init()
    {
        if (_items.Count != 0)
        {
            _items.ForEach(item => Destroy(item));
            _items = new List<GameObject>();
        }

        float XMaxPos = 0.4f;
        float XMinPos = -0.4f;
        Vector3 Pos = Vector3.zero;

        for (int i = 0; i < Count; i++)
        {
            if (i > 0)
            {
                float Y = _items[i - 1].transform.localPosition.y;
                float Z = _items[i - 1].transform.localPosition.z;
                Pos = new Vector3(0, Y, Z + Distance);
            }

            Pos.x += Random.Range(XMinPos, XMaxPos);

            GameObject cube = Instantiate(CubePrefab);
            cube.transform.parent = transform;
            cube.transform.localPosition = Pos;
            _items.Add(cube);
        }
    }

    private void Start()
    {
        Init();
    }

    public void RemoveFromList(GameObject item)
    {
        _items.Remove(item);
    }
}
