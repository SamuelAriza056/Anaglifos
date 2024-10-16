using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrellaScript : MonoBehaviour
{
    public int pointSum;

    Audio_Manager audiomanager;
    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audiomanager.PlaySFX(audiomanager.PickUp);
            GameManager.Instance.PointsUp(pointSum);
            gameObject.SetActive(false);
        }
    }
    
}
