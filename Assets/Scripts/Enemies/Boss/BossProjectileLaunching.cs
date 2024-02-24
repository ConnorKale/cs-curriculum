using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileLaunching : MonoBehaviour
{
	public GameObject projectile;

	private float timer;
	private float originalTimer;
	// Start is called before the first frame update
    void Start()
	{
		// Hi

		originalTimer = 1;
		timer = originalTimer;
	}

	// Update is called once per frame
    void Update()
	{
		timer -= Time.deltaTime;

		if (timer < 0)
		{
			timer = originalTimer;
			Instantiate(projectile, transform.position, transform.rotation);

		}
	}
}
