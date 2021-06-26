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

    //Save those inputs

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
        tesla.acceleration = Convert.ToSingle(teslaAcceleration.text);
        tesla.velocity = Convert.ToSingle(teslaVelocity.text);

        mobilio.acceleration = Convert.ToSingle(mobilioAcceleration.text);
        mobilio.velocity = Convert.ToSingle(mobilioVelocity.text);

        rangeRover.acceleration = Convert.ToSingle(rangeRoverAcceleration.text);
        rangeRover.velocity = Convert.ToSingle(rangeRoverVelocity.text);
    }
}
