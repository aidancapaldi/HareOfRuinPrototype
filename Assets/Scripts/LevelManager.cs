using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Important import for using UI elements
using UnityEngine.UI; 

using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public Sprite[] lostImages;
    public Image lostImage;
    public Canvas canvasObject;
    public Sprite[] wonImages;
    public Image wonImage;
    public Canvas canvasObjectWon;
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
        canvasObject.gameObject.SetActive(false);
        canvasObjectWon.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

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
        // gameText.color = Color.Lerp(Color.magenta, Color.yellow, t);

        
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
        if (!isGameOver)
        {
            isGameOver = true;
            //gameText.text = "YOU DIED!";
            //gameText.gameObject.SetActive(true);
            //Time.timeScale = 0f;

            foreach (AudioSource source in FindObjectsOfType<AudioSource>())
            {
                source.Stop();
            }
            Camera.main.GetComponent<AudioSource>().pitch = 1;
            AudioSource.PlayClipAtPoint(gameOverSFX, Camera.main.transform.position);
            chooseLostImage();

            Invoke("LoadCurrentLevel", 5);
            Invoke("HideLostImage", 3);
        }
    }

    public void LevelBeat() 
    {
        if (!isGameOver)
        {
            isGameOver = true;
            //gameText.text = "YOU WIN!";
            
            //gameText.gameObject.SetActive(true);

        
            Camera.main.GetComponent<AudioSource>().pitch = 2;
            foreach (AudioSource source in FindObjectsOfType<AudioSource>())
            {
                source.Stop();
            }
            AudioSource.PlayClipAtPoint(gameWonSFX, Camera.main.transform.position);

            chooseWonImage();
            

            if (!string.IsNullOrEmpty(nextLevel)) {
                Invoke("LoadNextLevel", 5);
                Invoke("HideWonImage", 3);
            }
        }
        
    }

    private void HideWonImage()
    {
        canvasObjectWon.gameObject.SetActive(false);
    }

    private void HideLostImage()
    {
        canvasObject.gameObject.SetActive(true);
    }

    public void LoadNextLevel() 
    {
        SceneManager.LoadScene(nextLevel);
    }

    void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void chooseLostImage()
    {
        lostImage.sprite = lostImages[Random.Range(0, lostImages.Length)];
        canvasObject.gameObject.SetActive(true);
    }

    public void chooseWonImage()
    {
        wonImage.sprite = wonImages[Random.Range(0, wonImages.Length)];
        canvasObjectWon.gameObject.SetActive(true);
    }



}
