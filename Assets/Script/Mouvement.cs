using UnityEngine;


public class Mouvement : MonoBehaviour
{
    public GameObject objet ;
    public GameObject rota;
    
    private float rVitesse;
    public Animator animator;
    private CharacterController controller;
    private Vector3 desiredVelocity = new Vector3(0,0,0);
    public Configuration configSon;
    public Configuration config;
    public GameObject son;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked; 
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {  
        if (Time.timeScale==0f)
        return;

        if(Input.GetKey(KeyCode.A)){
            rVitesse=2*config.vitesse;
            animator.SetBool("IsRunning",true);
        }
        else{
            rVitesse=config.vitesse;
            animator.SetBool("IsRunning",false);
        }


        desiredVelocity.y-=20*Time.deltaTime;
        if (controller.isGrounded){
            desiredVelocity=new Vector3 (Input.GetAxis("Horizontal")*rVitesse,0,Input.GetAxis("Vertical")*rVitesse);
            desiredVelocity=transform.TransformDirection(desiredVelocity);
        }

        

        // animation de marche 
        Vector2 vecteur = new Vector2(desiredVelocity.x,desiredVelocity.z);
        animator.SetBool("IsWalking",vecteur.magnitude>=0.1);
        
        //saut
        if(Input.GetKeyDown(KeyCode.Space)&&controller.isGrounded){
            desiredVelocity.y=config.puissanceSaut;
            Utile.LancerSon("Jump",Saver.instance.listSon);
        }

        controller.Move(desiredVelocity*Time.deltaTime);
        
        if(desiredVelocity.y>=0.1){
            animator.SetTrigger("IsJumping");
        }

        //mouvement souris
        objet.transform.eulerAngles+= new Vector3(0,Input.GetAxis("Mouse X"),0);
        rota.transform.position+= new Vector3(Input.GetAxis("Mouse Y"),0,0);

          
    }
}
   

    

