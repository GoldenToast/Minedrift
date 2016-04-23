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
       
	public PlayerManager m_Player;          
    
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


    private void SpawnAllPlayers(){
		m_Player.m_Instance = Instantiate(m_Player.m_PlayerPrefab, m_Player.m_SpawnPoint.position, m_Player.m_SpawnPoint.rotation) as GameObject;
        m_Player.m_PlayerNumber = 1;
        m_Player.Setup();
    }


    private void SetCameraTargets(){
		m_CameraControl.m_Target = m_Player.m_Instance.transform;
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
		return m_Player.isDead();
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
    
        m_Player.Reset();
    }


    private void EnablePlayerControl()
    {
		m_Player.EnableControl();
    }


    private void DisablePlayerControl()
    {
		m_Player.DisableControl();
    }
}