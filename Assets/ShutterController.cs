using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShutterController : MonoBehaviour
{

    private GameObject ShutterO;
    private GameObject ShutterU;
    public bool dead = false;
    public bool ShutterOpened = false;
    public bool HasOpened = false;

    void Start()
    {
        ShutterU = GameObject.Find("ShutterU");
        ShutterO = GameObject.Find("ShutterO");
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
        if(ShutterU.transform.position.y < -20 && HasOpened == false){
            ShutterOpened = true;
            HasOpened = true;
        }
        if(ShutterOpened != true){
            ShutterOpen();
        }
        if(dead){
            ShutterClose();
        }
    }

    void ShutterOpen(){
        // if(ShutterU.transform.position.y == 0 || ShutterO.transform.position.y == 0){
        //     return;
        // }
        ShutterU.transform.position += new Vector3(0, -0.3f, 0);
        ShutterO.transform.position += new Vector3(0, 0.3f, 0);
    }

    void ShutterClose(){
        if(ShutterU.transform.position.y < -1.5 || ShutterO.transform.position.y > 1){
            ShutterU.transform.position += new Vector3(0, 0.3f, 0);
            ShutterO.transform.position += new Vector3(0, -0.3f, 0);
        }
    }
}
