using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : Singelton<ObjectPool>
{
    //list of objects to be pooled
    public List<GameObject> PrefabsForPool;

  

    //pooled objects 
    private List<GameObject> _pooledObjects = new List<GameObject>();

    

    public GameObject GetObjectFromPool(string objectName)
    {
        var Instance=_pooledObjects.FirstOrDefault(obj=>obj.name==objectName);

        //If there is a pooled instance 
        if(instance!=null)
        {
            _pooledObjects.Remove(Instance);
            Instance.SetActive(true);
            return Instance;

        }

        //if no pooled prefab
        var prefab=PrefabsForPool.FirstOrDefault(obj=>obj.name==objectName);
        if(prefab!=null)
        {
            //create new instance
            var newInsatance=Instantiate(prefab,Vector3.zero,Quaternion.identity,transform);
            newInsatance.name=objectName;
            return newInsatance;
        }

        Debug.LogWarning("Object pool does not have prefab with the name"+objectName);
        return null;


    }

    public void PoolObject(GameObject obj)
    {
        obj.SetActive(false);
        _pooledObjects.Add(obj);

    }
}
