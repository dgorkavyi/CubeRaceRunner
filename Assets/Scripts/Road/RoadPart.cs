using UnityEngine;

public class RoadPart : MonoBehaviour {
    public CubeSpawner Cubes;
    public WallSpawner Walls;
    
    private void Awake() {
        Cubes = GetComponentInChildren<CubeSpawner>();
        Walls = GetComponentInChildren<WallSpawner>();
    }
}
