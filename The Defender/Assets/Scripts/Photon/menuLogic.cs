using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menuLogic : MonoBehaviour
{

    public photonButtons photonB;

    public GameObject mainPlayer;

    private void Awake()
    {
        DontDestroyOnLoad(this.transform);

        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public void createNewRoom()
    {
        //Parámetros: nombre de la sala, número de jugadores por sala, nulo
        PhotonNetwork.CreateRoom(photonB.createRoomInput.text, new RoomOptions() { MaxPlayers = 2 }, null);
    }

    public void joinOrCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(photonB.joinRoomInput.text, roomOptions, TypedLobby.Default);
    }

    public void moveScene()
    {
        PhotonNetwork.LoadLevel("MainGame");
    }

    //Esta función se llama sola una vez que entras a una sala
    private void OnJoinedRoom()
    {
        moveScene();
        Debug.Log("We are connected to the room!");
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "MainGame")
        {
            spawnPlayer();
        }
    }

    private void spawnPlayer()
    {
        PhotonNetwork.Instantiate(mainPlayer.name, mainPlayer.transform.position, mainPlayer.transform.rotation, 0);
    }
}
