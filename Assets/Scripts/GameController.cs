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

    public static GameController _instance;
    public static PlayerInput input;
    public static bool IsStarted { get; private set; } = false;

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
        _restartBtn.SetActive(false);
        RestartLevel();
        yield return null;
    }

    public IEnumerator ListenGame()
    {
        yield return new WaitUntil(() => IsStarted);
        _moveBtn.SetActive(true);
        yield return null;
    }

    private void RestartLevel() {
        // move all on start position and wait for 3 sec before start again
        IsStarted = true;
    }

    public static void Defeat() {
        IsStarted = false;
        _instance._moveBtn.SetActive(false);

        // ruin box container, add them rigidbody and turnRagdoll ON
        _instance._restartBtn.SetActive(true);
    }

    private void Awake()
    {
        _instance = this;
        input = GetComponent<PlayerInput>();
        _restartBtn.SetActive(false);
        _moveBtn.SetActive(false);
        StartCoroutine(ListenStart());
        StartCoroutine(ListenRestart());
        StartCoroutine(ListenGame());
    }
}
