using UnityEngine;
using UnityEngine.SceneManagement;

public class PomodoroTimer : MonoBehaviour
{
    public static PomodoroTimer Instance { get; private set; }
    
    private int _workChunkCount = 0;
    private float _timer = 0f;
    [SerializeField] private float workChunkDuration = 1500f;
    [SerializeField] private float breakChunkDuration = 300f;
    [SerializeField] private float longBreakChunkDuration = 900f;
    [SerializeField] private bool debugMode = false;
    private PomodoroTimerState _state = PomodoroTimerState.NotStarted;
    
    public float CurrentTime
    {
        get => _timer;
    }

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        if (debugMode)
        {
            workChunkDuration = 11f;
            breakChunkDuration = 31f;
            longBreakChunkDuration = 46f;
        }
    }

    public void StartTimer()
    {
        BeginWork();
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            ChangeState();
        }
    }

    private void ChangeState()
    {
        switch (_state)
        {
            case PomodoroTimerState.Work:
                BeginBreak();
                break;
            case PomodoroTimerState.Break:
                if (_workChunkCount % 4f == 0f)
                {
                    BeginLongBreak();
                }
                else
                {
                    BeginWork();
                }
                break;
            case PomodoroTimerState.LongBreak:
                BeginWork();
                break;
        }
    }

    private void BeginWork()
    {
        _state = PomodoroTimerState.Work;
        _workChunkCount++;
        _timer = workChunkDuration;
        SceneManager.LoadScene("WorkScene");
    }

    private void BeginBreak()
    {
        _state = PomodoroTimerState.Break;
        _timer = breakChunkDuration;
        ResourceManager.Instance.CalculateRewards();
        SceneManager.LoadScene("BreakScene");
    }

    private void BeginLongBreak()
    {
        _state = PomodoroTimerState.LongBreak;
        _timer = longBreakChunkDuration;
        FindObjectOfType<BreakManager>().StartLongBreak();
    }
}