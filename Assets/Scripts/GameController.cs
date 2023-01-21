using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _startBtn;

    [SerializeField]
    private GameObject _restartBtn;

    [SerializeField]
    private GameObject _moveBtn;

    [SerializeField]
    private RoadMover _roadMover;

    public static PlayerInput input;
    public static bool IsStarted { get; private set; }

    public IEnumerator ListenStart()
    {
        yield return new WaitUntil(() => input.actions["Start"].ReadValue<float>() > 0);
        IsStarted = true;
        _startBtn.SetActive(false);
        yield return null;
    }

    public IEnumerator ListenRestart()
    {
        yield return new WaitUntil(() => input.actions["Restart"].ReadValue<float>() > 0);
        IsStarted = true;
        _restartBtn.SetActive(false);
        yield return null;
    }

    public IEnumerator ListenGame()
    {
        yield return new WaitUntil(() => IsStarted);
        _moveBtn.SetActive(true);
        yield return null;
    }

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        _restartBtn.SetActive(false);
        _moveBtn.SetActive(false);
        StartCoroutine(ListenStart());
        StartCoroutine(ListenRestart());
        StartCoroutine(ListenGame());
    }
}
