using UnityEngine;

public class CarData : MonoBehaviour
{
    [SerializeField] Car tesla, mobilio, rangeRover;

    [SerializeField] PlayerDataChannelSO playerDataChannelSO;

    private void Start()
    {
        //Send the data to all the listeners
        playerDataChannelSO.RaiseEvent(tesla, mobilio, rangeRover);
    }
}