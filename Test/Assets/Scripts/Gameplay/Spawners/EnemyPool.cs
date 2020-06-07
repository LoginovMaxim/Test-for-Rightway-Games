using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPool : MonoBehaviour
{
    public event UnityAction EnemyDead;     // событие вызываемое при уничтожении вражеского корабля

    public void OnEnemyDead()
    {
        EnemyDead?.Invoke();
    }
}
