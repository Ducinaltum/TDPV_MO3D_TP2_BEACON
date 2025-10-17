using UnityEngine;

public class CreateArray : MonoBehaviour
{
    [SerializeField] private GameObject m_prefab;
    [SerializeField] private int m_wallWidth;
    [SerializeField] private int m_wallHeight;
    
    void Start()
    {
        Bounds bounds = default;
        for (int x = 0; x < m_wallWidth; x++)
        {
            for (int y = 0; y < m_wallHeight; y++)
            {
                var obj = Instantiate(m_prefab);
                if (bounds == default)
                {
                    Renderer[] renderers = m_prefab.GetComponentsInChildren<Renderer>();
                    foreach (Renderer item in renderers)
                    {
                        bounds.Encapsulate(item.bounds);
                    }
                }
                obj.transform.position = new(x * bounds.size.x, y * bounds.size.y, 0);
            }            
        }
    }
}
