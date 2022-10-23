using System.Collections.Generic;

public class Node
{
    public Node Left;
    public Node Right;
    public int Value;

    public Node(Node l, Node r, int v)
    {
        Left = l;
        Right = r;
        Value = v;
    }
}
public class Kata
{
    static int treeHeight(Node root)
    {
        if (root == null)
            return 0;
        else
        {
            int leftHeight = treeHeight(root.Left);
            int rightHeight = treeHeight(root.Right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }

    static void traverseLevel(Node root, int levelNo, List<int> list)
    {
        if (root == null)
            return;
        if (levelNo == 0)
        {
            list.Add(root.Value);
        }
        else
        {
            traverseLevel(root.Left, levelNo - 1, list);
            traverseLevel(root.Right, levelNo - 1, list);
        }

    }


    public static List<int> TreeByLevels(Node node)
    {
        List<int> list = new List<int>();
        if (node == null)
            return list;
        int height = treeHeight(node);
        for (int i = 0; i < height; ++i)
            traverseLevel(node, i, list);
        return list;
    }
}

public class Program
{
    public static void Main()
    {

    }
}