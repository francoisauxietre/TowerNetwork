using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{

    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private Button continueButton = null;

    private const string playerPrefsNameKey = "playerName";


    // Start is called before the first frame update
    void Start()
    {
        setUpInputField();
    }

    private void setUpInputField()
    {
        if (!PlayerPrefs.HasKey(playerPrefsNameKey)) { return; }
        string defaultName = PlayerPrefs.GetString(playerPrefsNameKey);
        nameInputField.text = defaultName;
        setPlayerName(defaultName);
       // throw new NotImplementedException();
    }

    public void setPlayerName(string defaultName)
    {
        continueButton.interactable = !string.IsNullOrEmpty(defaultName);
        //throw new NotImplementedException();
        Debug.Log("bouton");
    }

    public void savePlayerName()
    {
        string playerName = nameInputField.text;
        //enregistrement chez photon
        Debug.Log("saveplayer");
        PhotonNetwork.NickName = playerName;

        //ajout aplayerprefs pour ne pas a avoir a le refaire a achaque fois
        PlayerPrefs.SetString(playerPrefsNameKey, playerName);

    }

  
}
