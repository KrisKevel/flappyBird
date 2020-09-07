using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

    public static Game Instance;

    public GameObject TreePrefab;
    public GameObject Crystal;
    public float TreeDistance = 1f;
    public float Speed = 1f;
	
    private List<GameObject> _trees;
    private List<GameObject> _crystals;

    private bool _stop;

	void Start () {

        _stop = false;
        Instance = this;
        _trees = new List<GameObject>();
        _crystals = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject tree = GameObject.Instantiate(TreePrefab);
            GameObject crys = GameObject.Instantiate(Crystal);
            _trees.Add(tree);
            _crystals.Add(crys);
            float ran = Random.Range(-2f, 2f);
            tree.transform.position = new Vector3(TreeDistance * i, ran, 0f);
            crys.transform.position = new Vector3(TreeDistance * i + 0.3f, ran, 0f);
        }
    }
	
	void Update () {
        if (!_stop)
        {
            UpdateObject(_trees);
            UpdateObject(_crystals);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void UpdateObject(List<GameObject> _objects)
    {
        foreach (GameObject obj in _objects)
        {
            obj.transform.position -= new Vector3(Time.deltaTime * Speed, 0f, 0f);
            if (obj.transform.position.x < -TreeDistance * (_objects.Count / 2f))
            {
                if (obj.name.Equals("Cristal(Clone)"))
                    obj.GetComponent<Renderer>().enabled = true;

                obj.transform.position += new Vector3(TreeDistance * _objects.Count, 0f, 0f);
            }
        }
    }

    public void Restart()
    {
        foreach (GameObject tree in _trees)
        {
            GameObject.Destroy(tree);
        }

        foreach (GameObject crys in _crystals)
        {
            GameObject.Destroy(crys);
        }

        Start();
    }

    public void StopGame()
    {
        _stop = true;
    }

}
