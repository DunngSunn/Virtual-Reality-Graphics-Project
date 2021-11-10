using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void LateUpdate ()
    {
        var newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
