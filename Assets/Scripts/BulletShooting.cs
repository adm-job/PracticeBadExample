using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletShooting : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _objectTarget;
    [SerializeField] private float _timeWaitShooting = 2;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds _delay = new WaitForSeconds(_timeWaitShooting);

        while (enabled)
        {
            Vector3 direction = (_objectTarget.position - transform.position).normalized;
            Bullet Bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            Bullet.transform.rotation = Quaternion.LookRotation(direction);
            Bullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return _delay;
        }
    }
}