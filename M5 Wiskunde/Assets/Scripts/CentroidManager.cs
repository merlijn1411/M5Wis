using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class CentroidManager : MonoBehaviour
{
    public DragablePoint A;
    public DragablePoint B;
    public DragablePoint C;

    public GameObject AB;
    public GameObject AC;
    public GameObject BC;

    private LineRenderer lRAB;
    private LineRenderer lRAC;
    private LineRenderer lRBC;

    private LinearFunction fab = new LinearFunction(1, 1);
    private LinearFunction fac = new LinearFunction(1, 1);
    private LinearFunction fbc = new LinearFunction(1, 1);

    public GameObject hAB;
    public GameObject hAC;

    private LinearFunction CHAB = new LinearFunction(1, 1);
    public GameObject chab;
    private LineRenderer lchaB;

    private LinearFunction BHAC = new LinearFunction(1, 1);
    public GameObject bhac;
    private LineRenderer lbhaC;
    public GameObject centoid;

    void Start()
    {
        lRAB = AB.GetComponent<LineRenderer>();
        lRAC = AC.GetComponent<LineRenderer>();
        lRBC = BC.GetComponent<LineRenderer>();
        lchaB = chab.GetComponent<LineRenderer>();
        lbhaC = bhac.GetComponent<LineRenderer>();



    }

    void Update()
    {
        hAB.transform.position = new Vector3((A.transform.position.x + B.transform.position.x) / 2.0f, (A.transform.position.y + B.transform.position.y) / 2.0f, 0);
        hAC.transform.position = new Vector3((A.transform.position.x + C.transform.position.x) / 2.0f, (A.transform.position.y + C.transform.position.y) / 2.0f, 0);

        fab.LineTroughTwoPoint(A.transform.position, B.transform.position);
        lRAB.SetPosition(0, new Vector3(-10, fab.GetY(-10), 0));
        lRAB.SetPosition(1, new Vector3(10, fab.GetY(10), 0));

        fac.LineTroughTwoPoint(A.transform.position, C.transform.position);
        lRAC.SetPosition(0, new Vector3(-10, fac.GetY(-10), 0));
        lRAC.SetPosition(1, new Vector3(10, fac.GetY(10), 0));

        fbc.LineTroughTwoPoint(B.transform.position, C.transform.position);
        lRBC.SetPosition(0, new Vector3(-10, fbc.GetY(-10), 0));
        lRBC.SetPosition(1, new Vector3(10, fbc.GetY(10), 0));

        // function line C and half AB
        CHAB.LineTroughTwoPoint(C.transform.position, hAB.transform.position);
        lchaB.SetPosition(0, new Vector3(-10, CHAB.GetY(-10), 0));
        lchaB.SetPosition(1, new Vector3(10, CHAB.GetY(10), 0));

        // function line B and half AC
        BHAC.LineTroughTwoPoint(B.transform.position, hAC.transform.position);
        lbhaC.SetPosition(0, new Vector3(-10, BHAC.GetY(-10), 0));
        lbhaC.SetPosition(1, new Vector3(10, BHAC.GetY(10), 0));

        centoid.transform.position = CHAB.intesection(BHAC);
    }
}
