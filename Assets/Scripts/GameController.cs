using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject StartBtn;
    [SerializeField] private GameObject RestartBtn;
    
    public static PlayerInput input;
    public static bool IsStarted { get; private set; }

    public IEnumerator ListenStart()
    {
        yield return new WaitUntil(() => input.actions["Start"].ReadValue<float>() > 0);
        IsStarted = true;
        yield return null;
    }
    
    public IEnumerator ListenRestart()
    {
        yield return new WaitUntil(() => input.actions["Restart"].ReadValue<float>() > 0);
        IsStarted = true;
        RestartBtn.SetActive(false);
        yield return null;
    }

    private void Awake()
    {
        RestartBtn.SetActive(false);
        StartCoroutine(ListenStart());
        StartCoroutine(ListenRestart());
    }
}
