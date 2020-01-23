using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//overrride les function de photon de callbacks
public class MainMenu : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update

    [SerializeField] private GameObject findOpponentPanel = null;
    [SerializeField] private GameObject waitingStatusPanel = null;
    [SerializeField] private TextMeshProUGUI waitingStatusText = null;

    private bool isConnecting = false;
    //permet d'etre sur que quand quelqu"un se connecte au jeu il a bien la derniere version du jeu que l'on a en cours
    private const string GameVersion = "0.1";
    private const int MaxPlayersPerRoom = 3;
    private string roomName = "towerDefenseRoom1";

    //nouvelle facon de mettre la methode en anonyme en c#
    private void Awake() => PhotonNetwork.AutomaticallySyncScene = true;
    public void findOpponenent()
    {
        isConnecting = true;
        findOpponentPanel.SetActive(false);
        waitingStatusPanel.SetActive(true);
        waitingStatusText.text = "searching opponent...";
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master ");
        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        //base.OnConnectedToMaster();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        waitingStatusPanel.SetActive(false);
        findOpponentPanel.SetActive(true);
        //nouvelle facon de faire un debug avec le dollar et le message entre {}
        Debug.Log($"disconnected to master: { cause}");

        //base.OnDisconnected(cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"ne client are waiting for ropponent ");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayersPerRoom });


        //base.OnJoinRandomFailed(returnCode, message);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("successfully join the room "+ roomName);
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        //mettre un <= plutot
        if(playerCount != MaxPlayersPerRoom)
        {
            waitingStatusText.text = " Waiting for opponent";
            Debug.Log("cleint is waiting for an opponent ");
        }
        else
        {
            waitingStatusText.text = " Opponent found";
            Debug.Log("Match is ready to begin");
        }
        //base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersPerRoom)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;

            waitingStatusText.text = "Opponent Found";
            Debug.Log("Match is ready to begin");

            PhotonNetwork.LoadLevel("Scene_Main");


        }

        //base.OnPlayerEnteredRoom(newPlayer);

    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
