using System;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    //Follow the Active Car
    [SerializeField] CarType selectedCar = CarType.RANGEROVER;

    [SerializeField] Transform tesla, mobilio, rangeRover;

    private void Start()
    {
        CarSelection.ESelectionMade += CarSelected;
    }

    private void OnDisable()
    {
        CarSelection.ESelectionMade -= CarSelected;
    }

    private void CarSelected(CarType current)
    {
        selectedCar = current;
    }

    private void LateUpdate()
    {
        Vector2 targetPosition = transform.position;

        if (selectedCar == CarType.TESLA)
        {
            targetPosition = tesla.position;
        }
        else if (selectedCar == CarType.MOBILIO)
        {
            targetPosition = mobilio.position;
        }
        else
        {
            targetPosition = rangeRover.position;
        }

        transform.position = new Vector3(transform.position.x, targetPosition.y, -10);
    }
}
