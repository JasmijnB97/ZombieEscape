using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public GameObject pickupObject;

    private bool pickedUp = false;

    void Update()
    {
        if (pickedUp)
        {
            pickupObject.transform.position = transform.position + transform.forward * 0.6f + transform.up * 0.2f + transform.right * 0.4f;
            pickupObject.transform.rotation = transform.rotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(pickupObject))
            pickedUp = true;
    }
}
