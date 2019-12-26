using UnityEngine;
using System.Collections;

public class GizmosObject : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}


