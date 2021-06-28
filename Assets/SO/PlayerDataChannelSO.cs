using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataChannelSO", menuName = "SO/PlayerDataChannelSO", order = 0)]
public class PlayerDataChannelSO : ScriptableObject
{
    public delegate void PlayerData(Car tesla, Car mobilio, Car rangeRover);
    public static PlayerData playerDataEvent;

    public void RaiseEvent(Car tesla, Car mobilio, Car rangeRover)
    {
        if (playerDataEvent != null)
        {
            playerDataEvent(tesla, mobilio, rangeRover);
        }
        else
        {
            Debug.LogWarning("Player Data request was raised but no was taking that data");
        }
    }
}