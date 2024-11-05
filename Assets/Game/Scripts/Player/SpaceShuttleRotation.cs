using UnityEngine;

public class SpaceShuttleRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 0.5f;
    private Vector2 lastMousePosition;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2.5f)
            {
                HandleTouchRotation(touch);
            }
        }
#endif

#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(1))
        {
            Vector2 currentMousePosition = Input.mousePosition;
            Vector2 mouseDelta = currentMousePosition - lastMousePosition;

            // Get the direction from object to mouse in screen space
            Vector2 objectScreenPos = mainCamera.WorldToScreenPoint(transform.position);
            Vector2 mouseDir = currentMousePosition - objectScreenPos;

            // Determine rotation direction based on cross product
            float rotationDirection = Vector3.Cross(mouseDir, mouseDelta).z;
            
            // Apply rotation based on mouse movement magnitude
            float rotationAmount = mouseDelta.magnitude * Mathf.Sign(rotationDirection) * rotationSpeed;
            transform.Rotate(0, 0, rotationAmount);

            lastMousePosition = currentMousePosition;
        }
#endif
    }

    private void HandleTouchRotation(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                lastMousePosition = touch.position;
                break;

            case TouchPhase.Moved:
                Vector2 touchDelta = touch.position - lastMousePosition;
                
                // Get the direction from object to touch in screen space
                Vector2 objectScreenPos = mainCamera.WorldToScreenPoint(transform.position);
                Vector2 touchDir = touch.position - objectScreenPos;

                // Determine rotation direction based on cross product
                float rotationDirection = Vector3.Cross(touchDir, touchDelta).z;
                
                // Apply rotation based on touch movement magnitude
                float rotationAmount = touchDelta.magnitude * Mathf.Sign(rotationDirection) * rotationSpeed;
                transform.Rotate(0, 0, rotationAmount);

                lastMousePosition = touch.position;
                break;
        }
    }
}   