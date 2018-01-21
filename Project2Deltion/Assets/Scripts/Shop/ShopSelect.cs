using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSelect : MonoBehaviour
{
    [SerializeField] private RaycastHit hit;
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private float raycastLength;
    [SerializeField] private Text itemInfo;
    public List<string> type = new List<string>();
    [SerializeField] GameObject[] gun;
    [SerializeField] private GameObject eShop;
    [SerializeField] private GameObject crossHair;
    private Transform score;

    void Start ()
    {
        crossHair.SetActive(true);
        score = GameObject.FindGameObjectWithTag("ScoreManager").transform;
        
    }

	void Update ()
    {
        Shop();
    }

    void Shop ()
    {
        if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out hit, raycastLength))
        {
            if (hit.transform.tag == "Shop")
            {
                string typeOf = hit.transform.GetComponent<Shop>().type;
                string typeInfo = hit.transform.GetComponent<Shop>().info;
                itemInfo.text = (typeOf + "/" + typeInfo);
                crossHair.SetActive(false);
                eShop.SetActive(true);
                if (Input.GetButtonDown("E"))
                {
                    int currentpoints = score.GetComponent<ScoreManager>().currentPoints;
                    string info = hit.transform.GetComponent<Shop>().info;
                    if (typeOf == type[0])
                    {
                        if (info == "Musket")
                        {
                            if (currentpoints > 0)
                            {
                                int upAmmo = hit.transform.GetComponent<Shop>().amount;
                                gun[0].GetComponent<MainWeapons>().AddAmmo(upAmmo);
                            }
                            int downPoints = hit.transform.GetComponent<Shop>().points;
                            score.GetComponent<ScoreManager>().Points(0, downPoints);
                            gun[0].GetComponent<MainWeapons>().mayFire = true;
                        }
                        if (info == "Shotgun")
                        {
                            if (currentpoints > 0)
                            {
                                int upAmmo = hit.transform.GetComponent<Shop>().amount;
                                gun[1].GetComponent<MainWeapons>().AddAmmo(upAmmo);
                            }
                            int downPoints = hit.transform.GetComponent<Shop>().points;
                            score.GetComponent<ScoreManager>().Points(0, downPoints);
                            gun[1].GetComponent<MainWeapons>().mayFire = true;
                        }
                    }
                    if (typeOf == type[1])
                    {

                    }
                    if (typeOf == type[2])
                    {
                        if (info == "Experimental")
                        {
                            if (currentpoints > 0)
                            {
                                int upAmmo = hit.transform.GetComponent<Shop>().amount;
                                gun[2].GetComponent<MainWeapons>().AddAmmo(upAmmo);
                            }
                            int downPoints = hit.transform.GetComponent<Shop>().points;
                            score.GetComponent<ScoreManager>().Points(0, downPoints);
                            gun[2].GetComponent<MainWeapons>().mayFire = true;
                        }
                    }
                }
            }
        }
        else
        {
            eShop.SetActive(false);
            crossHair.SetActive(true);
        }
        Debug.DrawRay(cameraPosition.position, cameraPosition.forward * 2, Color.blue);
    }
}
