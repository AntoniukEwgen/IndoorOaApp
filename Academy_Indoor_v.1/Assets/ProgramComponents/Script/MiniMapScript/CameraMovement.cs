using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize;
    private Vector3 dragOrigin;



    private void Update()
    {
        PanCamera();
    }


    private void PanCamera()
    {
        // ��������, �� targetTexture �� �����������
        if (cam.targetTexture == null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                // ������ ��'��� � ����� "Camni"
                GameObject camniObject = GameObject.FindWithTag("Arrow");

                if (camniObject != null)
                {
                    // ���������� ���������� ������ ������� ��'���� "Camni"
                    cam.transform.position = new Vector3(camniObject.transform.position.x, cam.transform.position.y, camniObject.transform.position.z);
                    Debug.Log("���������� ������ ����������� �� " + cam.transform.position.ToString() + " ������� ��'���� � ����� 'Arrow'");
                }
                else
                {
                    Debug.LogWarning("��'��� � ����� 'Camni' �� ��������!");
                }
            }


            if (Input.GetMouseButtonDown(0))
                dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButton(0))
            {
                Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
                print("origin" + dragOrigin + "newPosition" + cam.ScreenToWorldPoint(Input.mousePosition) + "difference" + difference);
                cam.transform.position += difference;
            }
        }
    }


    public void ZoomIn()
    {
        float newSize = cam.orthographicSize - zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }

    public void ZoomOut()
    {
        float newSize = cam.orthographicSize + zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }
}