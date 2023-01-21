using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    public static PlayerSpawner Instance;
    public static GameObject CurrentPlayer;
    private Vector3 _pos;

    public void Spawn() {
        CurrentPlayer = Instantiate(_prefab);
        CurrentPlayer.transform.parent = transform;
        CurrentPlayer.transform.localPosition = _pos;
    }

    public void DeletePlayer() {
        Destroy(CurrentPlayer);
    }

    private void Start()
    {
        GameObject Preset = GetComponentInChildren<PlayerMove>().gameObject;
        _pos = Preset.transform.localPosition;
        Destroy(Preset);
        Instance = this;
        Spawn();
    }
}
