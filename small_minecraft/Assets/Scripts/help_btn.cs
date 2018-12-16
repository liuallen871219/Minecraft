using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class help_btn : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData e)
    {
        //Debug.Log(SceneManager.get)
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(3);

    }
}