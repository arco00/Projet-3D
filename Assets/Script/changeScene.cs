using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    [SerializeField]
    private string scenetoload="rempli";

    public void ChangeScene() {
     Time.timeScale=1f;  // si on change depuis une pause 
     SceneManager.LoadScene(scenetoload);
     Utile.LancerSon("Bouton",Saver.instance.listSon);
   }

   public void Quit(){
    Application.Quit(); //marche pas directement dans unity
    Debug.Log("On quitte le jeu");
    Utile.LancerSon("Bouton",Saver.instance.listSon);
   }
}
