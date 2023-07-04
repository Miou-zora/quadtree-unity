using System.Collections.Generic;
using UnityEngine;

public class QuadTree
{

    private Bounds _area = new Bounds(new Vector3(0, 0, 0), new Vector3(0, 0, 0));
    private int _capacity = 0;
    private List<GameObject> _entities = new List<GameObject>();

    private QuadTree _northWest = null;
    private QuadTree _northEast = null;
    private QuadTree _southWest = null;
    private QuadTree _southEast = null;
    private bool _divided = false;
    private int _numberOfIterations = 0;
    public QuadTree(Bounds area, int capacity)
    {
        _area = area;
        _capacity = capacity;
    }

    private void subdivide()
    {
        float w = _area.size.x;
        float h = _area.size.y;
        Bounds ne = new Bounds(new Vector3(_area.center.x + w / 4, _area.center.y + h / 4, 0), new Vector3(w / 2, h / 2, 0));
        _northEast = new QuadTree(ne, _capacity);
        Bounds nw = new Bounds(new Vector3(_area.center.x - w / 4, _area.center.y + h / 4, 0), new Vector3(w / 2, h / 2, 0));
        _northWest = new QuadTree(nw, _capacity);
        Bounds se = new Bounds(new Vector3(_area.center.x + w / 4, _area.center.y - h / 4, 0), new Vector3(w / 2, h / 2, 0));
        _southEast = new QuadTree(se, _capacity);
        Bounds sw = new Bounds(new Vector3(_area.center.x - w / 4, _area.center.y - h / 4, 0), new Vector3(w / 2, h / 2, 0));
        _southWest = new QuadTree(sw, _capacity);

        foreach (GameObject entity in _entities)
        {
            if (_northEast.insert(entity)) continue;
            if (_northWest.insert(entity)) continue;
            if (_southEast.insert(entity)) continue;
            if (_southWest.insert(entity)) continue;
        }

        _divided = true;
        _entities.Clear();
    }

    public bool insert(GameObject entity)
    {
        if (!_area.Contains(entity.GetComponent<BoxCollider2D>().bounds.center))
            return false;
        if (_entities.Count < _capacity && !_divided) {
            _entities.Add(entity);
            return true;
        }
        if (!_divided) {
            subdivide();
            _divided = true;
        }
        if (_northEast.insert(entity)) return true;
        if (_northWest.insert(entity)) return true;
        if (_southEast.insert(entity)) return true;
        if (_southWest.insert(entity)) return true;
        return false;
    }

    public void draw()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_area.center, _area.size);
        for (int i = 0; i < _entities.Count; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(_entities[i].GetComponent<BoxCollider2D>().bounds.center, 0.025f);
        }
        if (_divided)
        {
            _northEast.draw();
            _northWest.draw();
            _southEast.draw();
            _southWest.draw();
        }
    }

    public void clear()
    {
        _entities.Clear();
        if (_divided)
        {
            _northEast.clear();
            _northWest.clear();
            _southEast.clear();
            _southWest.clear();
            _northEast = null;
            _northWest = null;
            _southEast = null;
            _southWest = null;
            _divided = false;
        }
    }

    public List<GameObject> query(Bounds area)
    {
        List<GameObject> entities = new List<GameObject>();
        if (!_area.Intersects(area))
            return entities;
        foreach (GameObject entity in _entities)
        {
            if (area.Contains(entity.GetComponent<BoxCollider2D>().bounds.center))
                entities.Add(entity);
        }
        if (_divided)
        {
            entities.AddRange(_northEast.query(area));
            entities.AddRange(_northWest.query(area));
            entities.AddRange(_southEast.query(area));
            entities.AddRange(_southWest.query(area));
        }
        return entities;
    }

    public int GetNumberOfIterations()
    {
        return _numberOfIterations;
    }
}
