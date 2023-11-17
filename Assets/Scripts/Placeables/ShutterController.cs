using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShutterController : MonoBehaviour
{

    private GameObject ShutterO;
    private GameObject ShutterU;
    public bool NextLevelBool = false;
    public bool ShutterOpened = false;
    public bool HasOpened = false;
    private int j = 0;
    private int p = 0;


    void Start()
    {
        ShutterU = GameObject.Find("ClosingUNDER");
        ShutterO = GameObject.Find("ClosingOVER");

    }

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
    }

    private void FixedUpdate()
    {   
        NextLevelBool = GameObject.Find("PlayerHandler").GetComponent<PlayerHandler>().NextLevelBool;
        
        if(HasOpened == false && p < 60){
            p++;
            ShutterOpen();
        }

        if(NextLevelBool == true && j < 20){
            j++;
            ShutterClose();
        }
    }

    void ShutterOpen(){

        ShutterU.transform.position += new Vector3(0, -0.3f, 0);
        ShutterO.transform.position += new Vector3(0, 0.3f, 0);


    }

    void ShutterClose(){
        
        ShutterU.transform.position += new Vector3(0, 0.9f, 0);
        ShutterO.transform.position += new Vector3(0, -0.9f, 0);

    }
}