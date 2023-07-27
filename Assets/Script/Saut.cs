using UnityEngine;

public class Saut : MonoBehaviour
{
        public bool réponse;
    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Sol"){
            //Debug.Log("Saut");
            réponse=true;
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.tag=="Sol"){
            réponse=false;
        }
    }
}
