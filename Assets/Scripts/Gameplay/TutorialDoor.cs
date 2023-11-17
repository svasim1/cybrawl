using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialDoor : MonoBehaviour
{
    public string nextSceneName; // The name of the scene to load when the player enters the trigger
    private GameObject Enemies;
    public GameObject FinishPopup;
    public Boolean lastDoor = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        if (other.CompareTag("Player") && canProceed())
        {
            // If the player enters the trigger, load the next scene unless it's the last door
            if(!lastDoor)
            {
                Debug.Log("Loading next scene");
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Finish();
            }
            
        }
    }

    public bool canProceed(){
        Enemies = GameObject.Find("Enemies");
        if(Enemies.transform.childCount == 0){
            Debug.Log("Can Proceed");
            return true;
        }
        else{
            Debug.Log("Can't Proceed");
            return false;
        }
    }

    public void Finish()
    {
        FinishPopup.SetActive(true);

        // Play the victory sound
        GameObject.Find("AudioHandler").transform.Find("SFX").Find("Victory").GetComponent<AudioSource>().Play();
    }

    public void Continue()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}