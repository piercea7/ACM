using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour {

	public Text healthText;
	public BaseFighter player1, player2;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void checkHealth()
	{
		healthText.text = "Player 1:" + (int)player1.Health + "\n" + "Player 2:" + (int)player2.Health;
	}
	
	public static void UpdateHealth()
	{
		HealthSystem sys = (HealthSystem)GameObject.FindGameObjectWithTag("HealthBars").GetComponent(typeof(HealthSystem));
		sys.checkHealth();
	}
}
