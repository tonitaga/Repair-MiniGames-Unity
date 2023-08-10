using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PipeContainer : MonoBehaviour
{
    public static PipeContainer Instance;

    private List<List<GameObject>> _pipes;
    private int _pipes_count = 0;

    void Start()
    {
        List<GameObject> rows = new List<GameObject>();
        _pipes = new List<List<GameObject>>();
        foreach (Transform t in transform.GetComponent<Transform>())
            rows.Add(t.gameObject);

        foreach (GameObject row in rows)
        {
            List<GameObject> current_row = new List<GameObject>();
            foreach (Transform t in row.GetComponent<Transform>())
            {
                current_row.Add(t.gameObject);
                ++_pipes_count;
            }
            current_row = current_row.OrderBy(x => x.transform.position.x).ToList();
            _pipes.Add(current_row);
        }

        Instance = this;
    }

    public List<List<GameObject>> GetPipes() { return _pipes; }
    public int GetRowsCount() { return _pipes.Count; }
    public int GetItemsCount() { return _pipes_count; }
}
