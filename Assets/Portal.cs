using UnityEngine;
using System.Collections;
using Boo.Lang;

public class Portal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            
        }
    }

}
