using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ProjectileLauncher : MonoBehaviour, IInputClickHandler
{

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    void Start()
    {
        InputManager.Instance.PushModalInputHandler(this.gameObject);
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        GameObject projectile = Instantiate(prefab1) as GameObject;
        projectile.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.05f;
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = Camera.main.transform.forward * 10;
    }

}