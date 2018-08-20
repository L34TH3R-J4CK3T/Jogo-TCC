using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Compositor : TreeNode
{
    public TreeNode[] children;

    public override void Init(Hashtable data)
    {
        foreach (TreeNode child in children)
        {
            child.Init(data);
        }
    }
}