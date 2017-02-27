using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRoutine : MonoBehaviour {

    public GameObject text;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            text.GetComponent<VictoryText>().Appear();
            StartCoroutine("SwitchScene");
        }
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
