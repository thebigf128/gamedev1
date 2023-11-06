using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    public Transform player;
    public LayerMask solidObjectsLayer;
    [SerializeField] private float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        // if (DidCollideWithPlayer()) {
        //     Destroy(this);
        //     Debug.Log("object destroyed!");
        //     return;
        // }

        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < 5f) {
            Vector3 direction = (player.position - transform.position).normalized;

            for (int i = 0; i < 360; i++) {
                Quaternion rotationQuaternion = Quaternion.AngleAxis(i, Vector3.forward);
                Vector3 rotatedVector = rotationQuaternion * direction;

                Vector3 newPos = transform.position + rotatedVector * moveSpeed * Time.deltaTime;
                if (IsWalkable(newPos)) {
                    transform.position = newPos;
                    break;
                }
            }
        }
    }

    private bool IsWalkable(Vector3 targetPos) {
        return Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectsLayer) == null;
    }
}
