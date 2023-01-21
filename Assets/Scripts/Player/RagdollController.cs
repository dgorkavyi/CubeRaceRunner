using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField]
    Transform _body;

    public void TurnRagdoll(bool status)
    {
        GetComponentInChildren<Animator>().enabled = !status;
        
        foreach (Rigidbody rb in _body.GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = !status;
            rb.useGravity = status;
        }
    }

    private void Start()
    {
        TurnRagdoll(false);
    }
}
