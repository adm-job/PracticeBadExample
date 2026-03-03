using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private int _maxIndexArray;
    [SerializeField] private Transform[] _arrayPlaces;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _allPlacesPoint;

    private void Start()
    {
        _arrayPlaces = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
        {
            _arrayPlaces[i] = _allPlacesPoint.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        Transform _pointByNumberInArray = _arrayPlaces[_maxIndexArray - 1];
        
        transform.position = Vector3.MoveTowards(transform.position, _pointByNumberInArray.position, _speed * Time.deltaTime);

        if (transform.position == _pointByNumberInArray.position) NextPlaceTakerLogic();
    }

    public Vector3 NextPlaceTakerLogic()
    {
        _maxIndexArray++;

        if (_maxIndexArray == _arrayPlaces.Length)
        {
            _maxIndexArray = 0;
        }

        var thisPointVector = _arrayPlaces[_maxIndexArray].transform.position;
        
        transform.forward = thisPointVector - transform.position;

        return thisPointVector;
    }
}