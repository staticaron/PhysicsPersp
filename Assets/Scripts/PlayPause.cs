using UnityEngine;

public enum PlayState
{
    PLAY,
    PAUSE
}

public class PlayPause : MonoBehaviour
{
    //Singleton
    public static PlayPause instance;

    private PlayState currentPlayState;
    public PlayState CurrentPlayState
    {
        get { return currentPlayState; }
        set
        {
            if (value == currentPlayState) return;

            currentPlayState = value;

            if (EPlayStateChanged != null) EPlayStateChanged(CurrentPlayState);

            UpdateButtonUI();
        }
    }

    //Delegates and Events
    public delegate void Restarted();
    public static Restarted ERestart;

    public delegate void PlayStateChanged(PlayState current);
    public static PlayStateChanged EPlayStateChanged;

    [SerializeField] GameObject playIcon, pauseIcon;

    private void Awake()
    {
        #region Maintain Single Instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }

    private void Start()
    {
        UpdateButtonUI();
    }

    //On Click toggle the state
    public void Click()
    {
        //Change the State
        if (CurrentPlayState == PlayState.PLAY) CurrentPlayState = PlayState.PAUSE;
        else if (CurrentPlayState == PlayState.PAUSE) CurrentPlayState = PlayState.PLAY;
    }

    private void UpdateButtonUI()
    {
        if (CurrentPlayState == PlayState.PAUSE) { pauseIcon.SetActive(false); playIcon.SetActive(true); }
        else if (CurrentPlayState == PlayState.PLAY) { pauseIcon.SetActive(true); playIcon.SetActive(false); }
    }

    public void Restart()
    {
        //Reset the Position
        if (ERestart != null) ERestart();

        //Pause
        CurrentPlayState = PlayState.PAUSE;
    }
}
