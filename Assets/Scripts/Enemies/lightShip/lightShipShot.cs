using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightShipShot : MonoBehaviour {

    public float liveTimer;

    private void Update()
    {
        if (liveTimer <= 0)
        {
            Destroy(gameObject);
        }
        liveTimer -= Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        coll.otherCollider.SendMessage("playerGetHit", SendMessageOptions.DontRequireReceiver);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        coll.SendMessage("playerGetHit", SendMessageOptions.DontRequireReceiver);
    }
}
