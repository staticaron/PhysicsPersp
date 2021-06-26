using UnityEngine;
using UnityEngine.UI;

public enum PlayState
{
    PLAY,
    PAUSE
}

public class PlayPause : MonoBehaviour
{
    [SerializeField] PlayState currentPlayState;

    [SerializeField] GameObject playIcon, pauseIcon;

    private void Start()
    {
        UpdateButtonUI();
    }

    //On Click toggle the state
    public void Click()
    {
        //Change the State
        if (currentPlayState == PlayState.PLAY) currentPlayState = PlayState.PAUSE;
        else if (currentPlayState == PlayState.PAUSE) currentPlayState = PlayState.PLAY;

        //Change the ui
        UpdateButtonUI();
    }

    private void UpdateButtonUI()
    {
        if (currentPlayState == PlayState.PAUSE) { pauseIcon.SetActive(false); playIcon.SetActive(true); }
        else if (currentPlayState == PlayState.PLAY) { pauseIcon.SetActive(true); playIcon.SetActive(false); }
    }
}
