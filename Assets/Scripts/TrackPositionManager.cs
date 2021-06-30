using UnityEngine;

public class ScreenBoundData
{
    public Vector2 LowerLeftPoint;
    public Vector2 UpperRightPoint;
}

public class TrackPositionManager : MonoBehaviour
{
    private Camera cam;

    [SerializeField] Transform track;

    private void Awake()
    {
        //References
        cam = Camera.main;
        ScreenBoundData screenBoundData = GetScreenBounds();
        track.position = new Vector2(screenBoundData.LowerLeftPoint.x, track.position.y);
    }

    private ScreenBoundData GetScreenBounds()
    {
        ScreenBoundData screenBoundData = new ScreenBoundData();

        screenBoundData.UpperRightPoint = cam.ScreenToWorldPoint(new Vector2(cam.pixelWidth, cam.pixelHeight));
        screenBoundData.LowerLeftPoint = -cam.ScreenToWorldPoint(new Vector2(cam.pixelWidth, cam.pixelHeight));

        return screenBoundData;
    }
}
