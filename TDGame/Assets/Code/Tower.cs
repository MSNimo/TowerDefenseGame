using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    private Vector3 _pos;
    private Quaternion _rot;
    private float TOWER_RANGE;
    private Gun _gun;

    // Use this for initialization
    void Start() {

        //_pos = transform.position;
        //_rot = transform.rotation;
        //TOWER_RANGE = 30;
        //_gun = gameObject.GetComponent<Gun>();
    }

    public void Initialize(Cell cell) {

        _pos = cell.transform.position;
        _pos.y = 2.5f;
        transform.position = _pos;
        _rot = new Quaternion(0.7f, 0, 0, 0.7f);
        _rot *= Quaternion.Euler(-90, 0, 0);
        transform.rotation = _rot;

        TOWER_RANGE = 30;
        _gun = gameObject.GetComponent<Gun>();
    }

    public void Sell() {
        Destroy (gameObject);
    }

	// Update is called once per frame
	void Update () {

        Collider[] hitColliders = Physics.OverlapSphere(_pos, TOWER_RANGE);
        var dist = float.MaxValue;
        Vector3 direction = new Vector3(0,0,0);
        bool changedirection = false;

        int i = 0;
        while (i < hitColliders.Length) {
            if (hitColliders[i].gameObject.tag.Equals("Enemy")) {
                Vector3 targetpos = hitColliders[i].transform.position;
                var tempdist = Vector3.Distance(_pos, targetpos);

                if (tempdist < dist) {
                    dist = tempdist;
                    direction = targetpos - _pos;
                    changedirection = true;
                }
            }
            i++;
        }

        if (changedirection) {

            Vector3 tempdirection = direction;
            tempdirection.y = 0;
            _rot = Quaternion.LookRotation(tempdirection);
            _rot *= Quaternion.Euler(0, -92, 0);
            _gun.Fire(tempdirection);
        }

        transform.rotation = _rot; 
    }
}
