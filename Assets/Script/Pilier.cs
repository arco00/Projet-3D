using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilier : MonoBehaviour
{
    private float timer; public float timeMax;
    public float stop;
    public Vector3 direction;

    void Update()
    {
        if (Time.timeScale==0f)
        return;
        timer+=Time.deltaTime;
        Mouvement();
    }
    void Mouvement(){
        if (timer>timeMax){
            timer=-stop;
            direction=-direction;
        }
        else if (timer>=0){
            gameObject.transform.position+=direction; 
        }
        
    }
}
