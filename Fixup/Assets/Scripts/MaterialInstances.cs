using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialInstances : MonoBehaviour
{
    public GameObject gameObj;
    public Color albedoColor;
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        gameObj = this.gameObject;
        material = gameObj.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.color = albedoColor;
    }
}
