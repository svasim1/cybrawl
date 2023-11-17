using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialDoor : MonoBehaviour
{
    public string nextSceneName; // The name of the scene to load when the player enters the trigger
    private GameObject Enemies;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        if (other.CompareTag("Player") && canProceed())
        {
            Debug.Log("Loading next scene");
            SceneManager.LoadScene(nextSceneName);
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
}
