using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenHandler : MonoBehaviour
{

    public GameObject winLeft; // Reference to the winLeft gameObject
    public GameObject winRight; // Reference to the winRight gameObject
    public GameObject Player; // Reference to the Player gameObject
    public bool IsFlipped = false; // Bool to check if the player has been flipped
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        winLeft = GameObject.Find("WinLeft");
        winRight = GameObject.Find("WinRight");
        Animator animator = Player.GetComponent<Animator>();
        animator.SetInteger("TauntNum", Random.Range(0, 0));
        Debug.Log("P1Score: " + GameData.P1Score);
        Debug.Log("P2Score: " + GameData.P2Score);
        Debug.Log("Player: " + Player);
        Debug.Log("TauntNum: " + animator.GetInteger("TauntNum"));

        // Mute music
        GameObject.Find("AudioHandler").transform.Find("Music").GetComponent<AudioSource>().mute = true;
        // Play the victoru sound
        GameObject.Find("AudioHandler").transform.Find("SFX").Find("Victory").GetComponent<AudioSource>().Play();
        GameObject.Find("AudioHandler").transform.Find("SFX").Find("VictoryVoice").GetComponent<AudioSource>().Play();
        Debug.Log("Played shoot sound");
        // Get back to titleScreen
        Invoke("BackToTitleScreen", 12f);
    }
    // Update is called once per frame
    void Update()
    {
        if (GameData.P1Score < GameData.P2Score)
        {
            winLeft.SetActive(false);
            winRight.SetActive(true);
            if (!IsFlipped)
            {
                Flip();
                IsFlipped = true;
            }

        }
        else
        {
            // Set color of player sprite to #FF0000
            Player.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);

            winLeft.SetActive(true);
            winRight.SetActive(false);
        }
    }

    public void Flip()
    {
        Player.transform.Rotate(0, 180, 0);
    }

    void BackToTitleScreen()
    {
        // Unmute music
        GameObject.Find("AudioHandler").transform.Find("Music").GetComponent<AudioSource>().mute = false;
        // Load titleScreen
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScreen");
    }
}
