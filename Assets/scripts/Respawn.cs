using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
	
	public int xLimit = 5;
	public int yLimit = 5;
	Vector2 home = new Vector2(0,0);
	private Rigidbody2D rb2d;
	//rb2d = GetComponent<Rigidbody2D>();

	// Use this for initialization
	void Awake () 
	{
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(CheckLimits()) 
		{
			transform.position = home;
			rb2d.velocity = home;
		}		

	}

	bool CheckLimits() 
	{

		if(transform.position.x<(xLimit*-1)||transform.position.x>xLimit)
		{
			return true;
		}
		if(transform.position.y<(yLimit*-1)||transform.position.y>yLimit)
		{
			return true;
		}

		return false;
	}
}
