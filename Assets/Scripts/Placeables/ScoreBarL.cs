using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBarL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
    }
    // Update is called once per frame
    void FixedUpdate(){
        float Score = 12 - GameData.P1Score; 
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("Score", Score);
    }
}
