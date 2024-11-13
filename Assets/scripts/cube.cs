using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool isPurple = false;
    public bool isRed = false;
    private AudioManager audioManager;

    private void Awake()
    {
        // Find the AudioManager using its tag, and get the AudioManager component
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        // Set color and tags based on the cube's color
        if (GetComponent<Renderer>().material.color == Color.magenta)  // Purple cube
        {
            isPurple = true;
        }
        else if (GetComponent<Renderer>().material.color == Color.red)  // Red cube
        {
            isRed = true;
        }
    }

    private void OnCollisionEnter(Collision other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        if (isPurple)
        {
            g.instance.AddScore(1);
            audioManager.PlaySFX(audioManager.right);
            Debug.Log("Purple cube collected, score increased.");
        }
        else if (isRed)
        {
            g.instance.AddScore(-1);
            audioManager.PlaySFX(audioManager.wrong);
            Debug.Log("Red cube collided, score decreased.");
            ShowErrorMessage();
        }

        Destroy(gameObject);  // Destroy the cube after handling collision
    }
}


    private void ShowErrorMessage()
    {
        Debug.Log("Error: Red cube collided!");
        // Optionally, show an error message UI if desired
    }
}
