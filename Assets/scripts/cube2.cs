using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cube2 : MonoBehaviour
{
    public bool isValid = false;
    public static int validCubeCount = 0;
    public Text scoreText;

    private void Start()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        }
        UpdateScoreUI();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("PurpleCube"))
            {
                validCubeCount++;
                UpdateScoreUI();
                Debug.Log("Purple cube collected! Total valid cubes: " + validCubeCount);
            }
            else if (gameObject.CompareTag("RedCube"))
            {
                ShowErrorMessage();
                Debug.Log("Error: Red cube collided!");
            }
            else
            {
                ShowErrorMessage();
                Debug.Log("Error: Invalid cube collided!");
            }

            Destroy(gameObject);
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + validCubeCount.ToString();
        }
    }

    private void ShowErrorMessage()
    {
        Debug.Log("Error: Invalid cube collided!");
    }
}
