using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CubeContainer : MonoBehaviour
{
    private List<Pickupable> _cubes = new List<Pickupable>();

    public int Count => _cubes.Count;

    private void Attach(Pickupable cube)
    {
        cube.enabled = false;
        cube.transform.parent = transform;
        cube.transform.localPosition = Vector3.down * (Count + 1);
        cube.transform.localRotation = Quaternion.Euler(Vector3.zero);
        cube.GetComponent<BoxCollider>().enabled = false;
    }

    public void DettachAllInContainer()
    {
        foreach (Pickupable item in GetComponentsInChildren<Pickupable>())
        {
            Dettach(item);
        }
    }

    private void Dettach(Pickupable cube)
    {
        cube.transform.parent = null;
        var rb = cube.gameObject.AddComponent<Rigidbody>();
        rb.mass = 10;
    }

    public void Add(Pickupable cube)
    {
        _cubes = _cubes.Append(cube).ToList();
        Attach(cube);
    }

    public IEnumerator DestroyDettached(List<Pickupable> cubes)
    {
        yield return new WaitForSeconds(2f);
        cubes.ForEach(item => Destroy(item.gameObject));
    }

    public void Remove(int value)
    {
        _cubes.Reverse();
        List<Pickupable> cubesToRemove = _cubes.Take(value).ToList();
        _cubes = _cubes.Skip(value).ToList();
        _cubes.Reverse();

        cubesToRemove.ForEach(cube =>
        {
            Dettach(cube);
        });

        StartCoroutine("DestroyDettached", cubesToRemove);
    }
}
