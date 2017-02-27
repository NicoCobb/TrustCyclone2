using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRoutine : RaycastController {

    public GameObject text;
    public LayerMask winMask;
    public float winCircleSize = 2f;


    private void Update()
    {
        UpdateRaycastOrigins();
        CheckWinCondition();   
    }

    void CheckWinCondition()
    {
        Vector2 rayOrigin = raycastOrigins.center;
        Collider2D collider = Physics2D.OverlapCircle(rayOrigin, winCircleSize, winMask);

        if(collider)
        {
            text.GetComponent<VictoryText>().Appear();
            StartCoroutine("SwitchScene");
        }
    }

    void OnDrawGizmos()
    {
        Vector2 rayOrigin = raycastOrigins.center;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rayOrigin, winCircleSize);
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(2f);

        int thisIndex = this.gameObject.scene.buildIndex;
        SceneManager.LoadScene(thisIndex + 1);
    }
}
