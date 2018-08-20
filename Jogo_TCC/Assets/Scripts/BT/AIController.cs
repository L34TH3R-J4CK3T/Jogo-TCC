using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public TreeNode root;

    void Update()
    {
        root.Tick();

    }
}
