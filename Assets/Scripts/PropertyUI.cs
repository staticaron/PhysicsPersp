using UnityEngine;
using UnityEngine.UI;
using System;

public class PropertyUI : MonoBehaviour
{
    //GEt all the property inputs
    [SerializeField] InputField teslaAcceleration;
    [SerializeField] InputField teslaVelocity;

    [SerializeField] InputField mobilioAcceleration;
    [SerializeField] InputField mobilioVelocity;

    [SerializeField] InputField rangeRoverAcceleration;
    [SerializeField] InputField rangeRoverVelocity;

    [SerializeField] Car tesla, mobilio, rangeRover;

    [SerializeField] PlayerDataChannelSO playerDataChannelSO;

    private void Awake()
    {
        PlayerDataChannelSO.playerDataEvent += InitData;
    }

    private void OnDisable()
    {
        PlayerDataChannelSO.playerDataEvent -= InitData;
    }

    //Get the data from the Data Channel and apply it to the panel
    private void InitData(Car tesla, Car mobilio, Car rangeRover)
    {
        teslaAcceleration.text = tesla.acceleration.ToString();
        teslaVelocity.text = tesla.velocity.ToString();

        mobilioAcceleration.text = mobilio.acceleration.ToString();
        mobilioVelocity.text = mobilio.velocity.ToString();

        rangeRoverAcceleration.text = rangeRover.acceleration.ToString();
        rangeRoverVelocity.text = rangeRover.velocity.ToString();
    }

    //Check if data entered lies in the correct range
    public void CheckData(InputField inputField)
    {
        string input = inputField.text;
        float value = Convert.ToSingle(input);

        if (value < 0)
        {
            value = 0;
        }

        inputField.text = value.ToString();
    }

    public void SaveData()
    {
        float value;
        float.TryParse(teslaAcceleration.text, out value);
        Debug.Log(value);
        // tesla.acceleration = Convert.ToSingle(teslaAcceleration.text);
        // tesla.velocity = Convert.ToSingle(teslaVelocity.text);

        // mobilio.acceleration = Convert.ToSingle(mobilioAcceleration.text);
        // mobilio.velocity = Convert.ToSingle(mobilioVelocity.text);

        // rangeRover.acceleration = Convert.ToSingle(rangeRoverAcceleration.text);
        // rangeRover.velocity = Convert.ToSingle(rangeRoverVelocity.text);
    }
}
