﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int m_NumRoundsToWin = 5;        
    public float m_StartDelay = 3f;         
    public float m_EndDelay = 3f;           
    public CameraControl m_CameraControl;   
    public Text m_MessageText;              
       
    public PlayerManager[] m_Players;           
    
    private int m_RoundNumber;              
    private WaitForSeconds m_StartWait;     
    private WaitForSeconds m_EndWait;       
	private PlayerManager m_RoundWinner;
	private PlayerManager m_GameWinner;       


    private void Start()
    {
        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

		SpawnAllPlayers();
        SetCameraTargets();

        //StartCoroutine(GameLoop());
    }


    private void SpawnAllPlayers()
    {
        for (int i = 0; i < m_Players.Length; i++)
        {
            m_Players[i].m_Instance =
				Instantiate(m_Players[i].m_PlayerPrefab, m_Players[i].m_SpawnPoint.position, m_Players[i].m_SpawnPoint.rotation) as GameObject;
            m_Players[i].m_PlayerNumber = i + 1;
            m_Players[i].Setup();
        }
    }


    private void SetCameraTargets()
    {
        Transform[] targets = new Transform[m_Players.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = m_Players[i].m_Instance.transform;
        }

        m_CameraControl.m_Targets = targets;
    }


    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());

       if (m_GameWinner != null)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {
            StartCoroutine(GameLoop());
        }
    }


    private IEnumerator RoundStarting()
    {
		ResetAllPlayers ();
		DisablePlayerControl ();
		m_CameraControl.SetStartPositionAndSize ();
		m_RoundNumber++;
		m_MessageText.text = "Round " + m_RoundNumber;
        yield return m_StartWait;
    }


    private IEnumerator RoundPlaying()
    {
		EnableTankControl ();
		m_MessageText.text = "";
		while (!OneTankLeft()) {
			yield return null;
		}
    }


    private IEnumerator RoundEnding()
    {
		DisablePlayerControl ();
		m_RoundWinner = null;
		m_RoundWinner = GetRoundWinner();
		if (m_RoundWinner != null) {
			m_RoundWinner.m_Wins++;
		}
		m_GameWinner = GetGameWinner ();
		string endmessage = EndMessage ();
		m_MessageText.text = endmessage;
        yield return m_EndWait;
    }


    private bool OneTankLeft()
    {
        int numTanksLeft = 0;

        for (int i = 0; i < m_Players.Length; i++)
        {
            if (m_Players[i].m_Instance.activeSelf)
                numTanksLeft++;
        }

        return numTanksLeft <= 1;
    }


    private PlayerManager GetRoundWinner()
    {
        for (int i = 0; i < m_Players.Length; i++)
        {
            if (m_Players[i].m_Instance.activeSelf)
                return m_Players[i];
        }

        return null;
    }


	private PlayerManager GetGameWinner()
    {
        for (int i = 0; i < m_Players.Length; i++)
        {
            if (m_Players[i].m_Wins == m_NumRoundsToWin)
                return m_Players[i];
        }

        return null;
    }


    private string EndMessage()
    {
        string message = "DRAW!";

        if (m_RoundWinner != null)
            message = m_RoundWinner.m_ColoredPlayerText + " WINS THE ROUND!";

        message += "\n\n\n\n";

        for (int i = 0; i < m_Players.Length; i++)
        {
            message += m_Players[i].m_ColoredPlayerText + ": " + m_Players[i].m_Wins + " WINS\n";
        }

        if (m_GameWinner != null)
            message = m_GameWinner.m_ColoredPlayerText + " WINS THE GAME!";

        return message;
    }


    private void ResetAllPlayers()
    {
        for (int i = 0; i < m_Players.Length; i++)
        {
            m_Players[i].Reset();
        }
    }


    private void EnableTankControl()
    {
        for (int i = 0; i < m_Players.Length; i++)
        {
            m_Players[i].EnableControl();
        }
    }


    private void DisablePlayerControl()
    {
        for (int i = 0; i < m_Players.Length; i++)
        {
            m_Players[i].DisableControl();
        }
    }
}