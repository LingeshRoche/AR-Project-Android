using UnityEngine;

public class PinchToZoom : MonoBehaviour
{
    private float initialDistance;
    private Vector3 initialScale;
    public float zoomSpeed = 0.01f;
    public float minScale = 0.1f;
    public float maxScale = 2.0f;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touch1.position, touch2.position);
                initialScale = transform.localScale;
            }
            else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);
                if (Mathf.Approximately(initialDistance, 0))
                {
                    return;
                }

                float factor = currentDistance / initialDistance;
                Vector3 targetScale = initialScale * factor;
                targetScale.x = Mathf.Clamp(targetScale.x, minScale, maxScale);
                targetScale.y = Mathf.Clamp(targetScale.y, minScale, maxScale);
                targetScale.z = Mathf.Clamp(targetScale.z, minScale, maxScale);

                transform.localScale = targetScale;
            }
        }
    }
}
