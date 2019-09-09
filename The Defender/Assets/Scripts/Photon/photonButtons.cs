using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class photonButtons : MonoBehaviour
{
    public menuLogic mLogic;

    public InputField createRoomInput, joinRoomInput;


    public void onClickCreateRoom()
    {
        mLogic.createNewRoom();
    }

    public void onClickJoinRoom()
    {
        mLogic.joinOrCreateRoom();
    }

   
}
