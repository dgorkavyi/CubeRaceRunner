using UnityEngine;

public class PlayerColisions : MonoBehaviour
{
    private CubeContainer _container;
    private bool _doNotCollide;

    private void CubeCollision(Pickupable cube)
    {
        _container.Add(cube);
    }

    private void WallCollision(WallColumn wall)
    {
        if (_doNotCollide)
            return;

        _doNotCollide = true;
        
        if (_container.Count >= wall.Count)
        {
            _container.Remove(wall.Count);
        }
        else
        {
            GameController.Defeat();
        }
    }

    private void Start()
    {
        _doNotCollide = false;
        _container = GetComponentInChildren<CubeContainer>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Pickupable>(out Pickupable cube))
        {
            CubeCollision(cube);
        }
        else if (other.gameObject.TryGetComponent<WallColumn>(out WallColumn wall))
        {
            WallCollision(wall);
        }
    }
}
