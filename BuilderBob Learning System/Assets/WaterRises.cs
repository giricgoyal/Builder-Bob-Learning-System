using UnityEngine;
using System.Collections;

public class WaterRises : MonoBehaviour {
	float dz = (40.0f / 2000.0f) * 1681.849f;
	float dx = (40.0f/2000.0f) * 441.7586f;
	float factor = (40.0f/2000.0f);
	float px = 0;
	float pz = 0;
	GameObject [] dams;
	GameObject [] levees;
	GameObject [] sandbags;
	public static bool start = false;

	// Use this for initialization
	void Start () {

		dams = GameObject.FindGameObjectsWithTag ("Finish");
		levees = GameObject.FindGameObjectsWithTag ("levee");
		sandbags = GameObject.FindGameObjectsWithTag ("sandbag");

//		print (dams.Length);
//		print(GameObject.FindGameObjectWithTag ("Finish").transform.right);

	}
	
	// Update is called once per frame
	void Update () {
		if (start) {
						foreach (GameObject dam in dams) {
								dz = (40.0f / 2000.0f) * dam.transform.position.z;
								dx = (40.0f / 2000.0f) * dam.transform.position.x;
								px = dam.transform.position.x;
								pz = dam.transform.position.y;
								Col colll = (Col)dam.GetComponent ("Col");
                                if (!colll.overlook || 1==1)
                                {
                                    if (!colll.coll)
                                    {
                                        //print("nocol");
                                        if ((px > (1150f - 100f) && px < (1150f + 100f)) || (px > (350f - 250f) && px < (350f + 250f)))
                                        {
                                            if ((transform.position.x * factor < (dx + 4f)) && (transform.position.z * factor >= dz) || (transform.position.x * factor < (dx - 4f)))
                                            {
                                                transform.Translate(Vector3.up * Time.deltaTime * 1);
                                            }
                                            else
                                            {
                                                transform.Translate(Vector3.up * Time.deltaTime * 0.25f);
                                            }
                                        }
                                        else if ((px > (850f - 200f) && px < (850f + 200f)) || (px > (1500f - 100f) && px < (1500f + 100f)))
                                        {
                                            if ((transform.position.x * factor < (dx + 4f)) && (transform.position.z * factor <= dz) || (transform.position.x * factor < (dx - 4f)))
                                            {
                                                transform.Translate(Vector3.up * Time.deltaTime * 1);
                                            }
                                            else
                                            {
                                                transform.Translate(Vector3.up * Time.deltaTime * 0.25f);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //print("yescol");
                                        if (transform.position.x < px)
                                        {
                                            transform.Translate(Vector3.up * Time.deltaTime * 1);
                                        }
                                        else
                                        {
                                            transform.Translate(Vector3.up * Time.deltaTime * 0.25f);
                                        }
                                    }
                                }
                                else {
                                    transform.Translate(Vector3.up * Time.deltaTime * 4);
                                }
						}

						foreach (GameObject levee in levees) {
								dz = (40.0f / 2000.0f) * levee.transform.position.z;
								dx = (40.0f / 2000.0f) * levee.transform.position.x;
								px = transform.position.x;
								pz = transform.position.z;

								LeveeCol colll = (LeveeCol)levee.GetComponent ("LeveeCol");
								if (colll.collisionRegion == 4) {
										if (px * factor > dx && px * factor < (dx + 10f) && pz * factor < (dz + 4f) && pz * factor > (dz - 4f)) {
												transform.Translate (Vector3.up * Time.deltaTime * 0.5f);	
										} else {
                                            transform.Translate(Vector3.up * Time.deltaTime * 1);	
										}
								} else if (colll.collisionRegion == 3) {
										if (px * factor < dx && px * factor > (dx - 10f) && pz * factor < (dz + 4f) && pz * factor > (dz - 4f)) {
												transform.Translate (Vector3.up * Time.deltaTime * 0.25f);	
										} else {
                                            transform.Translate(Vector3.up * Time.deltaTime * 1);	
										}
								} else if (colll.collisionRegion == 1) {
										if (pz * factor < dz && pz * factor > (dz - 10f) && px * factor < (dx + 4f) && px * factor > (dx - 4f)) {
                                            transform.Translate(Vector3.up * Time.deltaTime * 0.25f);	
										} else {
                                            transform.Translate(Vector3.up * Time.deltaTime * 1);	
										}
								} else if (colll.collisionRegion == 2) {
										if (pz * factor > dz && pz * factor < (dz + 10f) && px * factor < (dx + 4f) && px * factor > (dx - 4f)) {
                                            transform.Translate(Vector3.up * Time.deltaTime * 0.25f);	
										} else {
                                            transform.Translate(Vector3.up * Time.deltaTime * 1);	
										}
								}

						}
                        foreach (GameObject sandbag in sandbags)
                        {
                            dz = (40.0f / 2000.0f) * sandbag.transform.position.z;
                            dx = (40.0f / 2000.0f) * sandbag.transform.position.x;
                            px = transform.position.x;
                            pz = transform.position.z;

                            SandColl colll = (SandColl)sandbag.GetComponent("SandColl");
                            if (colll.collisionRegion == 4)
                            {
                                if (px * factor > dx && px * factor < (dx + 10f) && pz * factor < (dz + 4f) && pz * factor > (dz - 4f))
                                {
                                    transform.Translate(Vector3.up * Time.deltaTime * 0.25f);
                                }
                                else
                                {
                                    transform.Translate(Vector3.up * Time.deltaTime * 1);
                                }
                            }
                            else if (colll.collisionRegion == 3)
                            {
                                if (px * factor < dx && px * factor > (dx - 10f) && pz * factor < (dz + 4f) && pz * factor > (dz - 4f))
                                {
                                    transform.Translate(Vector3.up * Time.deltaTime * 0.25f);
                                }
                                else
                                {
                                    transform.Translate(Vector3.up * Time.deltaTime * 1);
                                }
                            }
                            else if (colll.collisionRegion == 1)
                            {
                                if (pz * factor < dz && pz * factor > (dz - 10f) && px * factor < (dx + 4f) && px * factor > (dx - 4f))
                                {
                                    transform.Translate(Vector3.up * Time.deltaTime * 0.25f);
                                }
                                else
                                {
                                    transform.Translate(Vector3.up * Time.deltaTime * 1);
                                }
                            }
                            else if (colll.collisionRegion == 2)
                            {
                                if (pz * factor > dz && pz * factor < (dz + 10f) && px * factor < (dx + 4f) && px * factor > (dx - 4f))
                                {
                                    transform.Translate(Vector3.up * Time.deltaTime * 0.25f);
                                }
                                else
                                {
                                    transform.Translate(Vector3.up * Time.deltaTime * 1);
                                }
                            }

                        }
				}
	}
}