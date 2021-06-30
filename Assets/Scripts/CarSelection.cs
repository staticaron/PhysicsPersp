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

    //Delegates and Events
    public delegate void SelectionMade(CarType current);
    public static SelectionMade ESelectionMade;

    public CarType selectedCar;
    [SerializeField] LayerMask carLayer;

    private Camera cam;

    private bool isMobile = false;

    private void Awake()
    {
        #region Maintain Single Instance
        if (instance == null) instance = this;
        else Destroy(gameObject);
        #endregion

        //Get the platform data
        #if UNITY_STANDALONE
            isMobile = false; 
        #endif

        #if UNITY_ANDROID
            isMobile = true;
        #endif


        cam = Camera.main;

        selectedCar = CarType.RANGEROVER;
    }

    private void Update()
    {
        if(isMobile == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Clicked();
            }
       }
       else
       {
            if (Input.touchCount > 0)
            {     
                //ScreenTouched 
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Touched(touch);
                }
            }
        }
    }

    //Init car selection based on click
    public void Clicked()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        float rayLength = Mathf.Infinity;

        RaycastHit2D hitData = Physics2D.Raycast(mousePos, Vector3.forward, rayLength, carLayer);
        bool carFound = Physics2D.Raycast(mousePos, Vector3.forward, rayLength, carLayer);

        if (carFound)
        {
            GameObject carObject = hitData.collider.gameObject;

            selectedCar = carObject.GetComponent<Car>().carType;

            //Raise event
            if (ESelectionMade != null) ESelectionMade(selectedCar);

            Debug.Log("Click Selection Made");
        }
    }

    //Init car selection based on touch
    public void Touched(Touch touch)
    {
        Vector2 touchPos = cam.ScreenToWorldPoint(touch.position);
        float rayLength = Mathf.Infinity;

        RaycastHit2D hitData = Physics2D.Raycast(touchPos, Vector3.forward, rayLength, carLayer);
        bool carFound = Physics2D.Raycast(touchPos, Vector3.forward, rayLength, carLayer);

        if (carFound)
        {
            GameObject carObject = hitData.collider.gameObject;

            selectedCar = carObject.GetComponent<Car>().carType;

            //Rasie Event
            if (ESelectionMade != null) ESelectionMade(selectedCar);

            Debug.Log("Touch Selection Made");
        }
    }
}
