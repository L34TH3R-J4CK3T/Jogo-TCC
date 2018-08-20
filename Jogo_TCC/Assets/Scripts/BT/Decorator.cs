using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Decorator : TreeNode
{
    public TreeNode child;

    public override void Init(Hashtable data)
    {
        child.Init(data);
    }
}
