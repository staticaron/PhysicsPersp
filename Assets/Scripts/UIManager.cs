using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text selectedCarText;

    private const string teslaName = "Tesla Roadster";
    private const string mobilioName = "Honda Mobilio";
    private const string rangeRoverName = "Range Rover";

    private void Start()
    {
        CarSelection.ESelectionMade += UpdateSelectedGui;
    }

    private void OnDisable()
    {
        CarSelection.ESelectionMade -= UpdateSelectedGui;
    }

    private void UpdateSelectedGui(CarType current)
    {
        if (current == CarType.TESLA)
        {
            selectedCarText.text = teslaName;
        }
        else if (current == CarType.MOBILIO)
        {
            selectedCarText.text = mobilioName;
        }
        else if (current == CarType.RANGEROVER)
        {
            selectedCarText.text = rangeRoverName;
        }
    }
}
