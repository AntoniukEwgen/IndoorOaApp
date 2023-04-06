using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObjects : MonoBehaviour
{
    public GameObject objectToHide;
    public GameObject objectToShow;
    public Camera cam;
    public RenderTexture renderTexture;
    private float initialCamSize = 1;

    public void ShowObject()
    {
        objectToHide.SetActive(false);
        objectToShow.SetActive(true);
        cam.targetTexture = null; 
    }

    public void HideObject()
    {
        objectToShow.SetActive(false);
        objectToHide.SetActive(true);
        SetCameraPosition();
        ResetZoom();
        cam.targetTexture = renderTexture; 
    }

    private void SetCameraPosition()
    {
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

    public void ResetZoom()
    {
        cam.orthographicSize = initialCamSize;
    }
}

