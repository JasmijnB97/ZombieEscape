using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpController : MonoBehaviour
{
    public GameObject pickupObject;
    public float startYPositionPickupObject;
    public Text DeathText;
    public Text SaveText;

    private bool pickedUp = false;
    private Vector3 respawnPosition;
    private Quaternion respawnRotation;
    private int saveCount = 0;

    void Start()
    {
        respawnPosition = transform.position;
        respawnRotation = transform.rotation;
        DeathText.text = "Death";
        DeathText.gameObject.SetActive(false);
        SaveText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (pickedUp)
        {
            pickupObject.transform.position = transform.position + transform.forward * 0.8f + transform.up * 0.2f + transform.right * 0.4f;
            pickupObject.transform.rotation = transform.rotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(pickupObject))
            pickedUp = true;

        if (collision.transform.CompareTag("Zombie"))
        {
            StartCoroutine(HitByZombie());
        }

        if (collision.transform.CompareTag("Student") && pickedUp)
        {
            collision.gameObject.SetActive(false);
            StartCoroutine(SaveStudentText());
        }
    }

    IEnumerator HitByZombie()
    {
        DeathText.gameObject.SetActive(true);
        DropItem();
        Respawn();
        yield return new WaitForSeconds(2.5f);
        DeathText.gameObject.SetActive(false);
    }

    IEnumerator SaveStudentText()
    {
        saveCount++;
        SaveText.text = saveCount + "/3 students saved";
        SaveText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SaveText.gameObject.SetActive(false);
    }

    private void DropItem()
    {
        if (pickedUp)
        {
            pickedUp = false;
            pickupObject.transform.position = new Vector3(pickupObject.transform.position.x, startYPositionPickupObject, pickupObject.transform.position.z);
        }
    }


    private void Respawn()
    {
        transform.position = respawnPosition;
        transform.rotation = respawnRotation;
    }
}
