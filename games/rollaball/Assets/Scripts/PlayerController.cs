using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        winTextObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
        ApplicationConstants.count = 0;
        SetCountText();
    }
    private void FixedUpdate()
    {
        if (!menu.activeSelf)
        {
            //Debug.Log("Hit on continuous interval");
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
        }
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }
    void SetCountText()
    {
        countText.text = "Count: " + ApplicationConstants.count.ToString();
        if (ApplicationConstants.count >= 16)
        {
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!";
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
    private void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            ApplicationConstants.count = ApplicationConstants.count + 1;
            SetCountText();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            //Destroy(gameObject);
            gameObject.SetActive(false);
            // Update the winText to display "You Lose!"
            loseTextObject.gameObject.SetActive(true);
            //winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            menu.SetActive(true);
        }
    }
}
