using UnityEngine;
using System.Collections;

public class PlayerColisions : MonoBehaviour
{
    [SerializeField] private ParticleSystem StackEffect;
    private CubeContainer _container;
    private bool _doNotCollide;

    private void CubeCollision(Pickupable cube)
    {
        if (_doNotCollide)
            return;
        _container.Add(cube);
        GetComponentInChildren<Animator>().Play("Jumping");
        StackEffect.Play();
    }
// 7.4 14.22 38.73
// -10.45 15.45 -3.7

// 3.5 7.5 -14.73
// 13 -13.7 -7.6
    private void WallCollision(WallColumn wall)
    {
        if (_doNotCollide)
            return;

        _doNotCollide = true;
        StartCoroutine(EnableColisions());

        if (_container.Count >= wall.Count)
        {
            _container.Remove(wall.Count);
        }
        else
        {
            GameController.Defeat();
        }
    }

    public IEnumerator EnableColisions()
    {
        yield return new WaitForSeconds(1f);
        _doNotCollide = false;
    }

    private void Start()
    {
        _doNotCollide = false;
        _container = GetComponentInChildren<CubeContainer>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!GameController.IsStarted)
            return;
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
