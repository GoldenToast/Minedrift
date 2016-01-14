using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hitable : MonoBehaviour {

    public Slider slider;
    public Image sliderFillImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;


    public GameObject explosionPrefab;
	public int health = 100;
    public int currentHealth;

    private float SecondsUntilDestroy = 5;
    private Vector3 spawnPosition;

    void Start() {
        spawnPosition = transform.position;
        currentHealth = health;
    }

    private void setUIHealth() {
        if (slider == null) {
            return;
        }
        slider.value = currentHealth;
        sliderFillImage.color = Color.Lerp(fullHealthColor,zeroHealthColor, currentHealth/health);
    }

	public void takeDamage(int damage){
        currentHealth -= damage;
        setUIHealth();
		if (currentHealth <= 0) {
            DoExplosion(transform.position, transform.rotation);
			Destroy (this.gameObject);
            //Respawn();
        }

    }

    void Respawn(){
		transform.position = spawnPosition;
	}
	
	void DoExplosion(Vector3 pos, Quaternion rotation){
        Debug.Log("Explode");
        GetComponent<AudioSource>().Play(0);
	}
}
