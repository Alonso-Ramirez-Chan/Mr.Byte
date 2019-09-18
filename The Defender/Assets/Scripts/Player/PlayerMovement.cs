using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Photon.MonoBehaviour
public class PlayerMovement : MonoBehaviour
{
    //#####################  Movimiento  #####################//
    public CharacterController2D controller;

    private float runSpeed = 40f;
    private float horizontalMove = 0f;
    private bool jump;
    //#######################################################//

    //#####################  HTTPRequest  #####################//
    public Text score;
    private int puntaje = 0;
    private HttpRequests requests;
    //########################################################//

    private void Start()
    {
        requests = new HttpRequests();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
        }

        //Enviar Datos al server
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(HttpRequests.PostScore("http://127.0.0.1:5000/HighScore"+"?score="+score.text+"&player=unity"));
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Puntaje")
        {
            puntaje++;
            score.text = puntaje.ToString();
        }
    }




    /*public bool devTesting = false; //Se usa cuando se testea

    public PhotonView photonView;

    public Text plNameText;

    public GameObject plCam;

    public float moveSpeed = 100f;

    public float jumpForce = 800f;

    private Vector3 selfPosition;

    private GameObject sceneCam;

    private void Awake()
    {
        if(!devTesting && photonView.isMine)
        {
            sceneCam = GameObject.Find("Main Camera");
            sceneCam.SetActive(false);
            plCam.SetActive(true);
        }
    }

    private void Update()
    {
        if (!devTesting)
        { 
            //Verifica si es tu jugador, si es que no tenemos 
            //esta comparación lo que va a suceder es que vas a 
            //manejar todos los jugadores que se encuentran en pantalla.
            if (photonView.isMine)
            {
                checkInput();
            }
            else
            {
                //Es recomendable hacer este método pues si el jugador tiene lag
                //los movimientos de otros jugadores se va a ver brusco, en cambio,
                //este método va a suavizar dichos movimientos.
                smoothNetMovement();
            }
        }
        else
        {
            checkInput();
        }
    }

    private void checkInput()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    private void smoothNetMovement()
    {
        //Se puede usar 10 en vez de 8, es una constante.
        transform.position = Vector3.Lerp(transform.position, selfPosition, Time.deltaTime * 8); 
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //Básicamente lo que hace es verificar si el jugador es nuestro
        //va a enviar los datos.
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
        }
        else
        {
            //si no es nuestro player, recibe data, o sea está leyendo(stream.isReading)
            selfPosition = (Vector3)stream.ReceiveNext();
        }
    }*/
}
