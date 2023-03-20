using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Important import for using UI elements
using UnityEngine.UI; 

using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static float numEnemies; 
    public Text gameText; 
    public Text scoreText;

    public AudioClip gameOverSFX;
    public AudioClip gameWonSFX;

    public float lerpSpeed = 10f;

    public static bool isGameOver = false;

    public string nextLevel;

    public static float countDown;

    // Start is called before the first frame update
    void Start()
    {
        numEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        numEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        SetScoreText();
        if (!isGameOver) {
            if (numEnemies <= 0) {
                LevelBeat();
            }
        }
        float t = Mathf.Sin(Time.time * lerpSpeed);
        t += 1; 
        t /= 2;
        gameText.color = Color.Lerp(Color.magenta, Color.yellow, t);
    }

    private void OnGUI()
    {
        // GUI.Box(new Rect(10, 10, 50, 30), countDown.ToString("0.00"));
    }

    void SetScoreText()
    {
        scoreText.text = numEnemies.ToString();
    }

    public void LevelLost() 
    {
        isGameOver = true;
        gameText.text = "YOU DIED!";
        gameText.gameObject.SetActive(true);

        Camera.main.GetComponent<AudioSource>().pitch = 1;
        AudioSource.PlayClipAtPoint(gameOverSFX, Camera.main.transform.position);

        Invoke("LoadCurrentLevel", 2);
    }

    public void LevelBeat() 
    {
        isGameOver = true;
        gameText.text = "YOU WIN!";
        
        gameText.gameObject.SetActive(true);

        Camera.main.GetComponent<AudioSource>().pitch = 2;
        AudioSource.PlayClipAtPoint(gameWonSFX, Camera.main.transform.position);

        if (!string.IsNullOrEmpty(nextLevel)) {
            Invoke("LoadNextLevel", 2);
        }
        
    }

    public void LoadNextLevel() 
    {
        SceneManager.LoadScene(nextLevel);
    }

    void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
