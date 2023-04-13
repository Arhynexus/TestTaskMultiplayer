using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float m_PLayerSpeed;
    [SerializeField] private float m_PlayerRotationSpeed;

    private PhotonView m_PlayerView;
    private void Start()
    {
        m_PlayerView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PlayerView.IsMine)
        {
            float moveInputhorizontal = Input.GetAxisRaw("Horizontal");
            float moveInputvertictal = Input.GetAxisRaw("Vertical");
            transform.Rotate(-Vector3.forward * moveInputhorizontal * m_PlayerRotationSpeed * Time.deltaTime);
            transform.Translate(Vector2.up * moveInputvertictal * m_PLayerSpeed * Time.deltaTime);
        }
    }
}
