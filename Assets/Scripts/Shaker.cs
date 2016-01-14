using UnityEngine;
using System.Collections;

public class Shaker : MonoBehaviour
{
    public float amplitudeX = 1;
    public float amplitudeY = 0;
    public float amplitudeZ = 1;
    public float shakesPerSecX = 15;
    public float shakesPerSecY = 0;
    public float shakesPerSecZ = 15;
	public float durationInSec = 0.8f;
    public float randomFactorMin = 0.5f;
    public float randomFactorMax = 2.2f;
    private float animSecondsLeft = 0.0f;

    private Vector3 shakeVectorSum = new Vector3();
    private bool requiredCorrectionWasApplied = false;
    private bool animationIsActive = false;

    public Shaker()
    {    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rand = Random.insideUnitSphere;

        animationIsActive = animSecondsLeft > 0;

        if (animationIsActive)
        {
			float timeSpentInSecs = durationInSec - animSecondsLeft;
            // get
            float sinX, sinY, sinZ;

            if (shakesPerSecX > 0)
            {
				sinX = Random.Range(randomFactorMin, randomFactorMax) * Mathf.Sin(2 * Mathf.PI * shakesPerSecX * timeSpentInSecs);
            }
            else
            {
                sinX = 0;
            }

            if (shakesPerSecY > 0)
            {
				sinY = Random.Range(randomFactorMin, randomFactorMax) *  Mathf.Sin(2 * Mathf.PI * shakesPerSecY * timeSpentInSecs);
            }
            else
            {
                sinY = 0;
            }

            if (shakesPerSecZ > 0)
            {
				sinZ = Random.Range(randomFactorMin, randomFactorMax) *  Mathf.Sin(2 * Mathf.PI * shakesPerSecZ * timeSpentInSecs);
            }
            else
            {
                sinZ = 0;
            }
            // scale shake vector down over time
            float scaleFactor = animSecondsLeft / durationInSec;
            // translation vector
            Vector3 translate = new Vector3(sinX * amplitudeX, sinY * amplitudeY, sinZ * amplitudeZ);
			Debug.Log ("Translation: " + translate);
            translate *= scaleFactor;
            shakeVectorSum += translate;
            transform.position += translate;
            animSecondsLeft -= Time.deltaTime;
        }

        if (!requiredCorrectionWasApplied)
        {
            transform.position -= shakeVectorSum;
            requiredCorrectionWasApplied = true;
        }
    }

    public void doShake()
    {
		if (!animationIsActive) {
			animSecondsLeft = Mathf.Abs (durationInSec);
			requiredCorrectionWasApplied = false;
			animationIsActive = true;
			shakeVectorSum = new Vector3 ();
		} else {
			durationInSec += animSecondsLeft;
			animSecondsLeft *= 2;
		}
    }
}
