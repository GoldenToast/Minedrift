using System;
using UnityEngine;

[Serializable]
public class PlayerManager
{
	public GameObject m_PlayerPrefab;        
    public Transform m_SpawnPoint;        
    [HideInInspector] public int m_PlayerNumber;             
    [HideInInspector] public string m_ColoredPlayerText;
    [HideInInspector] public GameObject m_Instance;          
    [HideInInspector] public int m_Wins;                     


    private PlayerShipMovement m_Movement;       
    private PlayerWeaponControl m_Shooting;
    private GameObject m_CanvasGameObject;


    public void Setup()
    {
		m_Movement = m_Instance.GetComponent<PlayerShipMovement>();
		m_Shooting = m_Instance.GetComponent<PlayerWeaponControl>();
       // m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

        m_Movement.PlayerNumber = m_PlayerNumber;
		m_Shooting.PlayerNumber = m_PlayerNumber;

    }


    public void DisableControl()
    {
        m_Movement.enabled = false;
        m_Shooting.enabled = false;

       // m_CanvasGameObject.SetActive(false);
    }


    public void EnableControl()
    {
        m_Movement.enabled = true;
        m_Shooting.enabled = true;

       // m_CanvasGameObject.SetActive(true);
    }


    public void Reset()
    {
        m_Instance.transform.position = m_SpawnPoint.position;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}
