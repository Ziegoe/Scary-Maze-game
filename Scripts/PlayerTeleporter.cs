using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTeleporter : MonoBehaviour
{
    private GameObject teleporter;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(teleporter != null)
            {
                transform.position = teleporter.GetComponent < Teleporter>().GetDestination().position;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            teleporter = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if(collision.gameObject == teleporter)
            {
                teleporter = null;
            }
        } 
    }
}
