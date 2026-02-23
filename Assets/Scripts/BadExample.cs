using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    private int NumberPlacesArray;
    private Transform[] arrayPlaces;
    private float _speed;
    private Transform AllPlacesPoint;

    private void Start()
    {
        arrayPlaces = new Transform[AllPlacesPoint.childCount];

        for (int i = 0; i < AllPlacesPoint.childCount; i++)
            arrayPlaces[i] = AllPlacesPoint.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        var _pointByNumberInArray = arrayPlaces[NumberPlacesArray];
        transform.position = Vector3.MoveTowards(transform.position, _pointByNumberInArray.position, _speed * Time.deltaTime);

        if (transform.position == _pointByNumberInArray.position) NextPlaceTakerLogic();
    }

    public Vector3 NextPlaceTakerLogic()
    {
        NumberPlacesArray++;

        if (NumberPlacesArray == arrayPlaces.Length)
            NumberPlacesArray = 0;

        var thisPointVector = arrayPlaces[NumberPlacesArray].transform.position;
        transform.forward = thisPointVector - transform.position;

        return thisPointVector;
    }
}