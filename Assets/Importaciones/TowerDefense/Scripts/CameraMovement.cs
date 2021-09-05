using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize;

    [SerializeField]
    private SpriteRenderer mapRendered;

    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    private Vector3 dragOrigin;

    private void Awake()
    {
        mapMinX = mapRendered.transform.position.x - mapRendered.bounds.size.x / 2f;
        mapMaxX = mapRendered.transform.position.x + mapRendered.bounds.size.x / 2f;

        mapMinY = mapRendered.transform.position.y - mapRendered.bounds.size.y / 2f;
        mapMaxY = mapRendered.transform.position.y + mapRendered.bounds.size.y / 2f;
    }
    
    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;

        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }

    public void ZoomOut()
    {
        float newSize = cam.orthographicSize + zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        cam.transform.position = ClampCamera(cam.transform.position);
    }

    public void ZoomIn()
    {
        float newSize = cam.orthographicSize - zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        cam.transform.position = ClampCamera(cam.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PanCamera();
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            print("origin " + dragOrigin + " newPosition " + cam.ScreenToWorldPoint(Input.mousePosition) + " = difference " + difference);

            cam.transform.position = ClampCamera(cam.transform.position + difference);
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - difference * 0.01f, minCamSize, maxCamSize);
        }
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - Input.GetAxis("Mouse ScrollWheel"), minCamSize, maxCamSize);
    }
}
