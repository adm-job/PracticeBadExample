using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] private Transform[] _pointArray;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _pointParent;

    private int _index = 0;
    
    private void Start()
    {
        _pointArray = new Transform[_pointParent.childCount];

        for (int i = 0; i < _pointParent.childCount; i++)
        {
            _pointArray[i] = _pointParent.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        float distance = 0.1f;
        Transform _pointRoute = _pointArray[_index];

        transform.position = Vector3.MoveTowards(transform.position, _pointRoute.position, _speed * Time.deltaTime);

        if  ((_pointRoute.position - transform.position).sqrMagnitude < distance * distance)
        {
            NextPoint();
        }
    }

    private Vector3 NextPoint()
    {
        _index++;

        if (_index == _pointArray.Length)
        {
            _index = 0;
        }

        Vector3 currentVector = _pointArray[_index].transform.position;

        transform.forward = currentVector - transform.position;

        return currentVector;
    }
}