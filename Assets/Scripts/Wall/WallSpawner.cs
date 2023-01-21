using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> _items;

    private GameObject WallInstance;
    private Vector3 Pos;

    public void Init()
    {
        GameObject Preset = GetComponentInChildren<Wall>().gameObject;
        Pos = Preset.transform.localPosition;
        Destroy(Preset);
        WallInstance = Instantiate(_items[Random.Range(0, _items.Count)]);
        WallInstance.transform.parent = transform;
        WallInstance.transform.localPosition = Pos;
    }

    public void Start()
    {
        Init();
    }
}
