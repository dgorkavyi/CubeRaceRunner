using UnityEngine;

public class PlayerDefeat : MonoBehaviour
{
    public static PlayerDefeat Instance;
    private CubeContainer _container;
    private RagdollController _ragdoll;

    public void Defeat() {
        _container.DettachAllInContainer();
        _ragdoll.TurnRagdoll(true);
        _ragdoll.transform.parent = null;
    }

    private void Awake()
    {
        _container = GetComponentInChildren<CubeContainer>();
        _ragdoll = GetComponentInChildren<RagdollController>();
        Instance = this;
    }
}
