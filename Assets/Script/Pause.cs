using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    public GameObject pauseMenu;
    // Update is called once per  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            
            if (paused){
                Debug.Log("Pause!!");
                Utile.Unpause();
                //enlever la pause
                retour();
            }
            else{
                //mettre la pause
                Debug.Log("Pause!! mise");
                pauseMenu.SetActive(true);
                Time.timeScale=0f;
                 Cursor.lockState=CursorLockMode.Confined;
                paused=true;
            }

        }
        
    }
    public void retour(){
        pauseMenu.SetActive(false);
        Utile.Unpause();
        Time.timeScale=1f;
        paused=false;
    }
}
