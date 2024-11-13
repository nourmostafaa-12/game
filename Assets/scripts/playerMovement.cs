using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forceAmount = 3; // Adjust the force amount as needed

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from keyboard (WASD or arrow keys)
        float moveHorizontal = Input.GetAxis("Horizontal"); // Left/Right movement
        float moveVertical = Input.GetAxis("Vertical"); // Forward/Backward movement

        // Create a movement direction vector based on input
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Apply force in the direction of movement
        rb.AddForce(movement * forceAmount);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is tagged as "Collectible"
        if (other.CompareTag("Collectible"))
        {
            // Increase score and destroy the collectible
            ScoreManager.instance.AddPoint();
            Destroy(other.gameObject);
        }
    }


    // This method can be called to disable movement (from the g script)
    public void DisableMovement()
    {
        this.enabled = false;  // Disable the PlayerMovement script to stop player movement
    }
}
