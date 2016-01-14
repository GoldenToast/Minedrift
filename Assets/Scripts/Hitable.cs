using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hitable : MonoBehaviour {

    public Slider slider;
    public Image sliderFillImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;

    public GameObject explosionPrefab;
    public GameObject enemySpawn;
    public int health = 100;
    public int currentHealth;

    private float SecondsUntilDestroy = 5;
    private Vector3 spawnPosition;
    private bool spawned;

    void Start() {
        spawnPosition = transform.position;
        currentHealth = health;
        spawned = false;
    }

    private void setUIHealth() {
        if (slider == null) {
            return;
        }
        slider.value = currentHealth;
        sliderFillImage.color = Color.Lerp(fullHealthColor,zeroHealthColor, currentHealth/health);
    }

	public void takeDamage(int damage){
        Shaker shaker = this.GetComponent<Shaker>();

        if(shaker != null)
        {
            shaker.doShake();
        }

        currentHealth -= damage;
        setUIHealth();
		if (currentHealth <= 0) {
            DoExplosion(transform.position, transform.rotation);
            SpawnEnemy(transform.position, transform.rotation);

			Destroy (this.gameObject, .3f);
            //Respawn();
        }

    }

    private void SpawnEnemy(Vector3 pos, Quaternion rotation)
    {
        if (enemySpawn != null && !spawned) {
            var go = Instantiate(enemySpawn, pos, rotation);
        }
    }

    void Respawn(){
		transform.position = spawnPosition;
	}
	
	void DoExplosion(Vector3 pos, Quaternion rotation){
        Debug.Log("Explode");
        var go = Instantiate(explosionPrefab, pos, rotation);
        Destroy(go, 5.0f);
	}
}
