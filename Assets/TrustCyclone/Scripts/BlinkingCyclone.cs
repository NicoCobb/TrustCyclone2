using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * MAKE SURE THAT THERE IS AN EMPTY GAMEOBJECT IN THE SCENE
 * WITH THIS SCRIPT ATTACHED TO IT. DO NOT PUT THIS SCRIPT
 * ON THE CYCLONES THEMSELVES. THERE IS A PREFAB CALLED
 * MANAGER IN THE PROJECT. JUST DRAG IT INTO TO EVERY SCENE
 * WHERE BLINKING CYCLONES SHOW UP.
*/

public class BlinkingCyclone : MonoBehaviour {

    GameObject[] blinkingCyclones;    

    void Start()
    {
        //Store any blinking cyclone's collider in an array of type GameObject
        blinkingCyclones = GameObject.FindGameObjectsWithTag("BlinkingCyclone");
        StartCoroutine("SwitchCyclone");
    }

    IEnumerator SwitchCyclone()
    {
        //Coroutine begins after 3 seconds, and then calls itself again every 3 seconds
        yield return new WaitForSeconds(3f);
        //Every collider and the parent particle system will be set active or inactive
        //every time the coroutine restarts itself.
        foreach(GameObject go in blinkingCyclones)
        {
            if(go.activeInHierarchy)
            {
                go.SetActive(false);
                go.transform.parent.gameObject.SetActive(false);
            }
            else if(!go.activeInHierarchy)
            {
                go.SetActive(true);
                go.transform.parent.gameObject.SetActive(true);
            }
        }
        //Restart the coroutine after 3 seconds
        StartCoroutine("SwitchCyclone");
    }
}
