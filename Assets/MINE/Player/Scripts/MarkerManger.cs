using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerManger : MonoBehaviour
{
    public class Marker
    {
        public Vector3 position;
        public Quaternion rotation;
    
    
        public Marker(Vector3 pos, Quaternion rot)
        {
            position = pos;
            rotation = rot;
        }
    }

    public List<Marker> MarkerList = new List<Marker>();

    void Start()
    {

    }
    
    void FixedUpdate()
    {
        UpdateMarkerList();
    }
    
    public void UpdateMarkerList()
    {
        MarkerList.Add(new Marker(transform.position, transform.rotation));
    }

    public void ClearMarkerList()
    {
        MarkerList.Clear();
        MarkerList.Add(new Marker(transform.position, transform.rotation));
    }

}
