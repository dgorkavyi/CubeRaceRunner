using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject StartBtn;
    [SerializeField] private GameObject RestartBtn;
    [SerializeField] private GameObject MoveBtn;
    
    public static PlayerInput input;
    public static bool IsStarted { get; private set; }

    public IEnumerator ListenStart()
    {
        yield return new WaitUntil(() => input.actions["Start"].ReadValue<float>() > 0);
        IsStarted = true;
        StartBtn.SetActive(false);
        yield return null;
    }
    
    public IEnumerator ListenRestart()
    {
        yield return new WaitUntil(() => input.actions["Restart"].ReadValue<float>() > 0);
        IsStarted = true;
        RestartBtn.SetActive(false);
        yield return null;
    }
    
    public IEnumerator ListenGame()
    {
        yield return new WaitUntil(() => IsStarted);
        MoveBtn.SetActive(true);
        yield return null;
    }

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        RestartBtn.SetActive(false);
        MoveBtn.SetActive(false);
        StartCoroutine(ListenStart());
        StartCoroutine(ListenRestart());
        StartCoroutine(ListenGame());
    }
}
