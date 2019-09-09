using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photonConnect : MonoBehaviour
{
    public string versionName = "0.1";

    public GameObject sectionView1, sectionView2, sectionView3;


    //Enlazado al boton connect to photon
    private void Awake()
    {
        //Verifica que los ejecutables que tengan cada host tengan la misma
        //versión para que se puedan conectar
        PhotonNetwork.ConnectUsingSettings(versionName);

        Debug.Log("Connecting to photon...");
    }

    //Función que llama a otras funciones una vez que se logra 
    //conectar al servidor de photon
    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);

        Debug.Log("We are connected to master");
    }

    //Función que toma los datos de otros objetos en el servidor de photon
    private void OnJoinedLobby()
    {
        sectionView1.SetActive(false);
        sectionView2.SetActive(true);
        Debug.Log("On Joined lobby");
    }

    //Lo que pasa cuando un jugador se desconecta
    private void OnDisconnectedFromPhoton()
    {
        if (sectionView1.activeSelf)
            sectionView1.SetActive(false);

        if (sectionView2.activeSelf)
            sectionView2.SetActive(false);

        sectionView3.SetActive(true);
        
        Debug.Log("Disconnected from photon services");
    }
    
}
