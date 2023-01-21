using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColumn : MonoBehaviour
{
    public int Count => transform.childCount;

    private void Awake() {

        if (TryGetComponent<BoxCollider>(out BoxCollider collider))
        {
            collider.center = new Vector3(0, Count / 2f, 0);
            collider.size = new Vector3(1f, Count, 1f);
        }
    }
}
