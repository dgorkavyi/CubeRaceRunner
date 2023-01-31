using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private Pickupable CubePrefab;

    [SerializeField]
    private float Distance = 0.09f;

    private bool _canInit = true;
    private int Count = 4;
    private List<Pickupable> _items = new List<Pickupable>();

    public void Init()
    {
        if (!_canInit) return;
        _canInit = false;
        if (_items.Count != 0)
        {
            _items.ForEach(item => {
                if (!item.isTaken) Destroy(item.gameObject);
            });
            _items = new List<Pickupable>();
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

            Pickupable cube = Instantiate(CubePrefab);
            cube.transform.parent = transform;
            cube.transform.localPosition = Pos;
            _items.Add(cube);

            StartCoroutine(Cooldown());
        }
    }

    public IEnumerator Cooldown() {
        yield return new WaitForSeconds(1);
        _canInit = true;
    }

    private void Start()
    {
        Init();
    }
}
