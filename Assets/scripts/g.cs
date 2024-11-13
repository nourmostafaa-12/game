using UnityEngine;
using TMPro;

public class g : MonoBehaviour
{
    private playerMovement playermovement;
    public GameObject gameOver;
    public static g instance;
    public TMP_Text scoreText;
    public TMP_Text timeText;
    public TMP_Text endMessageText;
    public TMP_Text targetColorText; // Reference for target color text
    public GameObject player;

    private AudioManager audioManager;
    private int purpleCubeCount = 0;
    public float timeLeft = 10f;
    private bool timeIsUp = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioManager = AudioManager.instance;
    }

    void Start()
    {
        gameOver.SetActive(false);
        timeText.text = "Time: " + timeLeft.ToString("F2");
        endMessageText.text = "";
        targetColorText.text = "Target Color: purple";
        playermovement = FindObjectOfType<playerMovement>();
    }

    void Update()
    {
        if (timeIsUp) return;

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                
                timeLeft = 0f;
                if (playermovement != null)
                {
                    playermovement.forceAmount = 0f; // Stop player movement
                    Debug.Log("Player speed has been set to 0.");
                }
                gameOver.SetActive(true);
                EndGame(); // Trigger the game end
            }

            timeText.text = "Time: " + timeLeft.ToString("F2");
        }
    }

    // Method to handle end-of-game logic
void EndGame()
{
    timeIsUp = true;
    timeText.text = ""; // Hide the time text once the game is over

    // Display win or lose message based on score
    if (purpleCubeCount >= 3)
    {
        endMessageText.text = "You Won! Final Score: " + purpleCubeCount;
        audioManager.PlaySFX(audioManager.right); // Play win sound
    }
    else
    {
        endMessageText.text = "You Lost! Final Score: " + purpleCubeCount;
        audioManager.PlaySFX(audioManager.wrong); // Play lose sound
    }

    audioManager.StopMusic(); // Stop background music
    FreezePlayer(); // Freeze player movement
}



    public void AddScore(int points)
    {
        purpleCubeCount += points;
        scoreText.text = "Score: " + purpleCubeCount.ToString();
    }

    private void FreezePlayer()
{
    if (player != null)
    {
        // Disable the player movement script to prevent further player input
        var playerMovement = player.GetComponent<playerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        // Get the Rigidbody component and apply all necessary constraints
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Stop all ongoing motion and disable gravity as a backup
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
            
            // Freeze position and rotation to keep it stationary
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
    }
}


}
