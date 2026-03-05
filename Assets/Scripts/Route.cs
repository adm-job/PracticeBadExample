using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _way;

    private Transform[] _pointArray;
    private int _index = 0;

    #if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void Start()
    {
        _pointArray = new Transform[_way.childCount];

        for (int i = 0; i < _way.childCount; i++)
        {
            _pointArray[i] = _way.GetChild(i);
        }
    }
    #endif

    private void Update()
    {
        float distance = 0.1f;
        Transform _pointRoute = _pointArray[_index];

        transform.position = Vector3.MoveTowards(transform.position, _pointRoute.position, _speed * Time.deltaTime);

        if ((_pointRoute.position - transform.position).sqrMagnitude < distance * distance)
        {
            NextPoint();
        }
    }

    private void NextPoint()
    {
        _index = ++_index % _pointArray.Length;

        Vector3 currentVector = _pointArray[_index].transform.position;

        transform.forward = currentVector - transform.position;
    }
}