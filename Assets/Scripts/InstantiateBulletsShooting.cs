using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] public float number;
    [SerializeField] Bullet _prefab;
    [SerializeField] public Transform ObjectToShoot;
    [SerializeField] float _timeWaitShooting;

    private void Start()
    {
        StartCoroutine(_shootingWorker());
    }

    IEnumerator _shootingWorker()
    {
        bool isWork = enabled;

        while (isWork)
        {
            var _vector3direction = (ObjectToShoot.position - transform.position).normalized;
            var NewBullet = Instantiate(_prefab, transform.position + _vector3direction, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = _vector3direction;
            NewBullet.GetComponent<Rigidbody>().velocity = _vector3direction * number;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}