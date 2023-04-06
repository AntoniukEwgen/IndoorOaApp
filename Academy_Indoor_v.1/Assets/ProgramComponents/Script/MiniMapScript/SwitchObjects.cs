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
            // Встановити координати камери відносно об'єкта "Camni"
            cam.transform.position = new Vector3(camniObject.transform.position.x, cam.transform.position.y, camniObject.transform.position.z);
            Debug.Log("Координати камери встановлено на " + cam.transform.position.ToString() + " відносно об'єкта з тегом 'Arrow'");
        }
        else
        {
            Debug.LogWarning("Об'єкт з тегом 'Camni' не знайдено!");
        }
    }

    public void ResetZoom()
    {
        cam.orthographicSize = initialCamSize;
    }
}

