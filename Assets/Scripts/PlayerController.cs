using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    private int numPickups = 4;
    private int count;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;

    public TextMeshProUGUI posText;

    public TextMeshProUGUI velText;

    void Start()
    {
        count = 0;
        winText.text = "";
        SetCountText();
    }

    void OnMove(InputValue value)
    {
        System.Console.WriteLine(value);
        moveValue = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        var rb = GetComponent<Rigidbody>();
        rb.AddForce(movement * speed * Time.fixedDeltaTime);

        Vector3 playerPosition = rb.position;
        posText.text = "Position: " + playerPosition.ToString();

        // Log and display the player's velocity
        Vector3 playerVelocity = rb.velocity;
        velText.text = "Velocity: " + playerVelocity.ToString();

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString();
        if(count >= numPickups)
        {
            winText.text = "You win!";
        }
    }
}
