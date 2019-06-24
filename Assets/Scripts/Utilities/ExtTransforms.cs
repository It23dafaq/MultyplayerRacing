using UnityEngine;
public static class Transforms
{
    public static void DestroyChildren(this Transform child, bool DestroyImidietly = false)
    {
        foreach (Transform transform in child)
        {
            if (DestroyImidietly)
            {
                MonoBehaviour.DestroyImmediate(child.gameObject);
            }
            else
            {
                MonoBehaviour.Destroy(child.gameObject);
            }
        }
    }

}