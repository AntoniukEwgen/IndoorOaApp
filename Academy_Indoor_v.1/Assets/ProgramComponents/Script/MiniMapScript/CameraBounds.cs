using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Vector2 xBounds, zBounds;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(xBounds.x, 0, zBounds.x), new Vector3(xBounds.y, 0, zBounds.x));
        Gizmos.DrawLine(new Vector3(xBounds.x, 0, zBounds.y), new Vector3(xBounds.y, 0, zBounds.y));
        Gizmos.DrawLine(new Vector3(xBounds.x, 0, zBounds.x), new Vector3(xBounds.x, 0, zBounds.y));
        Gizmos.DrawLine(new Vector3(xBounds.y, 0, zBounds.x), new Vector3(xBounds.y, 0, zBounds.y));
    }

    private void LateUpdate()
    {
        Vector3 clampedPosition = cam.transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, xBounds.x, xBounds.y);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, zBounds.x, zBounds.y);
        cam.transform.position = clampedPosition;
    }
}