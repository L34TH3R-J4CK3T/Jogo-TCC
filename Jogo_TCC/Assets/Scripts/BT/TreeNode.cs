using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TreeNode
{
    public abstract void Init(Hashtable data);
    public abstract NodeStatus Tick();
}

public enum NodeStatus
{
    SUCCESS,
    FAILURE,
    RUNNING
}
