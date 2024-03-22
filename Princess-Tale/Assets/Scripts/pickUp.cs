using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class pickUp : MonoBehaviour
{
  public int count;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(0, 90 * Time.deltaTime, 0);
  }

}
