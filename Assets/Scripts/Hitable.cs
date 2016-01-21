using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hitable : MonoBehaviour {

    public Slider slider;
    public Image sliderFillImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;

    public float health = 100;
	public float currentHealth;

	private Spawner[] spawners;
	private Shaker shaker;

    private Vector3 spawnPosition;

    void Start() {
		spawners = GetComponents<Spawner> ();
		shaker = this.GetComponent<Shaker>();

        spawnPosition = transform.position;
        currentHealth = health;
    }

 

	public void takeDamage(int damage){

        if(shaker != null)
        {
            shaker.doShake();
        }

        currentHealth -= damage;
        setUIHealth();
		if (currentHealth <= 0) {
			foreach(Spawner spawner in spawners){
				spawner.Spawn(this.transform.position, this.transform.rotation);	
			}
			Destroy(this.gameObject);
        }
    }

	private void setUIHealth() {
		if (slider == null) {
			return;
		}
		slider.value = currentHealth;
		sliderFillImage.color = Color.Lerp(zeroHealthColor,fullHealthColor, currentHealth/health);
	}
		
    void Respawn(){
		transform.position = spawnPosition;
	}

}
