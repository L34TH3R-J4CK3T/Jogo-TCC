using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFunctions : MonoBehaviour
{
    abstract public void Movement();

    abstract public void Attack();

    abstract public void Attack(int alfa);

}
