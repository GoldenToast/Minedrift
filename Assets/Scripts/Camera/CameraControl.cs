using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float m_DampTime = 0.2f;                 
	public float m_ScreenEdgeBufferFar = 20f;           
    public float m_MinSizeFar = 20f;
	public float m_ScreenEdgeBufferClose = 4f;           
	public float m_MinSizeClose = 2f;    
    public Transform m_Target; 

    private Camera m_Camera;                        
    private float m_ZoomSpeed;                      
    private Vector3 m_MoveVelocity;       

	private GameObject player;
	private GameObject playerShip;
 
    private void Awake(){
        m_Camera = GetComponentInChildren<Camera>();
    }

	private void Update(){
		player = GameObject.FindGameObjectWithTag (Tags.PLAYER);
		playerShip = GameObject.FindGameObjectWithTag (Tags.PLAYER_SHIP);
		if (player) {
			m_Target = player.transform;
		} else if (playerShip) {
			m_Target = playerShip.transform;
		} else {
			m_Target = null;
		}
	}

    private void FixedUpdate(){
		if (!m_Target) {
			return;
		} 
        Move();
		Rotate ();
        Zoom();
    }

    private void Move(){	
    	Vector3 desiredPos = m_Target.position;
		desiredPos.y = transform.position.y;
		transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref m_MoveVelocity, m_DampTime);
    }
		
	private void Rotate(){
		if (m_Target.CompareTag (Tags.PLAYER)) {
			transform.rotation = Quaternion.Euler (new Vector3 (90, m_Target.rotation.eulerAngles.y, 0));
		} else if (m_Target.CompareTag (Tags.PLAYER_SHIP)) {
			transform.rotation = Quaternion.Euler (new Vector3 (90, 0, 0));
		}
	}
		
    private void Zoom(){
        float requiredSize = FindRequiredSize();
        m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
    }
		
    private float FindRequiredSize(){
        float size = 0f;
		Vector3 targetLocalPos = transform.InverseTransformPoint( m_Target.position);
		size = Mathf.Max (size, Mathf.Abs (targetLocalPos.y));
		size = Mathf.Max (size, Mathf.Abs (targetLocalPos.x) / m_Camera.aspect);

		if (m_Target.CompareTag (Tags.PLAYER_SHIP)) {
			size += m_ScreenEdgeBufferFar;
			size = Mathf.Max (size, m_MinSizeFar);
		} else {
			size += m_ScreenEdgeBufferClose;
			size = Mathf.Max (size, m_MinSizeClose);
		}

        return size;
    }
		
    public void SetStartPositionAndSize(){
       
		transform.position = m_Target.position;
        m_Camera.orthographicSize = FindRequiredSize();
    }
}