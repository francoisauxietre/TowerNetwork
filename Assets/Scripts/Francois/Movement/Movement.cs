using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviourPun
    {
        private CharacterController myCharacterController = null;
        [SerializeField] private float movementSpeed = 0f;

        // Start is called before the first frame update
        void Start()
        {
        myCharacterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                TakeInput();
            }
        }

        private void TakeInput()
        {
            var movemnent = new Vector3
            {
                x = Input.GetAxisRaw("Horizontal"),
                y = 0f,
                z = Input.GetAxisRaw("Vertical")

            }.normalized;
        //throw new NotImplementedException();
        myCharacterController.SimpleMove(movemnent * movementSpeed);
        }
    }


