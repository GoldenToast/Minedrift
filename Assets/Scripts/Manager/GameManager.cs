using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
       
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

	private EnemyCounter enemyCounter;

    private void Start()
    {
        enemyCounter = GetComponent<EnemyCounter>();
        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

		SpawnAllPlayers();
        SetCameraTargets();

        StartCoroutine(GameLoop());
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private IEnumerator RoundStarting()
    {
		ResetAllPlayers ();
		DisablePlayerControl ();
		m_CameraControl.SetStartPositionAndSize ();
		m_RoundNumber++;
		m_MessageText.text = "Minedrift";
        yield return m_StartWait;
    }


    private IEnumerator RoundPlaying()
    {
		EnablePlayerControl ();
		m_MessageText.text = "";       
        while (!nonLeft() && !allPlayerDead()) {
			yield return null;
		}
    }

    private bool allPlayerDead() {
        bool playersDead = true;
        for (int i = 0; i < m_Players.Length; i++)
        {
            if (!m_Players[i].isDead())
            {
                playersDead = false;
            }
        }
        return playersDead;
    }

    private IEnumerator RoundEnding()
    {
		DisablePlayerControl ();
		string endmessage = EndMessage ();
		m_MessageText.text = endmessage;
        yield return m_EndWait;
    }


    private bool nonLeft()
    {
        return enemyCounter.counter <= 0;
    }


    private string EndMessage()
    {
        string message = "You Win";
        if (!nonLeft())
        {
            message = "Game Over";
        }       

        return message;
    }


    private void ResetAllPlayers()
    {
        for (int i = 0; i < m_Players.Length; i++)
        {
            m_Players[i].Reset();
        }
    }


    private void EnablePlayerControl()
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