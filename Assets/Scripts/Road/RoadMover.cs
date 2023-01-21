using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoadMover : MonoBehaviour
{
    private RoadGenerator _generator;
    private float _step = 30f;

    public void MoveToZero()
    {
        _generator.Roads.ForEach(road =>
        {
            road.transform.localPosition += Vector3.back * _step;
        });
    }

    public IEnumerator MoveRoads()
    {
        _generator = GetComponent<RoadGenerator>();

        yield return new WaitUntil(() => _generator.IsGenerated);
        yield return new WaitUntil(() => GameController.IsStarted);

        PositionRoads(_generator.Roads);

        while (GameController.IsStarted)
        {
            yield return new WaitForSeconds(3f);

            Vector3 LastPos = _generator.Roads.Last().transform.localPosition;
            Vector3 NextPos = LastPos + (Vector3.forward * _step);
            GameObject road = _generator.Roads[0];
            _generator.Roads.Remove(road);
            _generator.SetRoads(_generator.Roads.Append(road).ToList());
            road.transform.localPosition = NextPos;
            MoveToZero();
        }
    }

    private void PositionRoads(List<GameObject> roads)
    {
        Vector3 Pos = Vector3.zero;

        roads.ForEach(item =>
        {
            item.transform.localPosition = Pos;
            Pos += Vector3.forward * _step;
        });
    }

    void Start()
    {
        StartCoroutine(MoveRoads());
    }

    void Update() { }
}
