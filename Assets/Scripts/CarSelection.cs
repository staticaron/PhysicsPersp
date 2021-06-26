using UnityEngine;

public enum CarType
{
    TESLA,
    MOBILIO,
    RANGEROVER
}

public class CarSelection : MonoBehaviour
{
    //Singleton
    public static CarSelection instance;

    public CarType selectedCar;
    [SerializeField] LayerMask carLayer;

    private Camera cam;

    private void Awake()
    {
        #region Maintain Single Instance
        if (instance == null) instance = this;
        else Destroy(gameObject);
        #endregion

        cam = Camera.main;

        selectedCar = CarType.RANGEROVER;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    //Init car selection
    public void Click()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        float rayLength = 100;

        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit2D hitData = Physics2D.Raycast(mousePos, Vector3.forward, rayLength, carLayer);
        bool carFound = Physics2D.Raycast(mousePos, Vector3.forward, rayLength, carLayer);

        if (carFound)
        {
            GameObject carObject = hitData.collider.gameObject;

            selectedCar = carObject.GetComponent<Car>().carType;
            Debug.Log(selectedCar);
        }

        Debug.Log(carFound);
    }
}
