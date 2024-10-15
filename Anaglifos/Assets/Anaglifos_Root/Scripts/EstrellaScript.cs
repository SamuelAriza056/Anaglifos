using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrellaScript : MonoBehaviour
{
    public int pointSum;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PointsUp(pointSum);
            gameObject.SetActive(false);
        }
    }
}
