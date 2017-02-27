using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCheck : MonoBehaviour {

    static public bool isOpen = false;
    Animator anim;
    
	// Use this for initialization
	void Start () {
        anim = transform.parent.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isOpen)
        {
            anim.SetBool("openDoor", true);
        }

        if(!isOpen)
        {
            anim.SetBool("openDoor", false);
        }
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player" && isOpen)
        {
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.buildIndex + 1);
        }
    }
}
