using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    [SerializeField]
    private string scenetoload="rempli";

    public void ChangeScene() {
     Time.timeScale=1f;  // si on change depuis une pause 
     SceneManager.LoadScene(scenetoload);
   }

   public void Quit(){
    Application.Quit(); //marche pas directement dans unity
    Debug.Log("On quitte le jeu");
   }
}
