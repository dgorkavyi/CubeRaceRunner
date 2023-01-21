using UnityEngine;
using System.Collections;

public class PlayerColisions : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem StackEffect;
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
