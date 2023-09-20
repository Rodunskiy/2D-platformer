using UnityEngine;

public class CreateCoin : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private Transform[] _poinst;

    private void Start()
    {
        for (int i = 0; i < _poinst.Length; i++)
        {
            Instantiate(_coin, _poinst[i].transform.position, Quaternion.identity);
        }
    }
}
