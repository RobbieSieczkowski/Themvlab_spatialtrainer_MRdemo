using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatically alters size of the three platonic solids relative to the mocap skeleton's currently-selected data recording's max wingspan
// Frankly, will only be of use for dance data from bigger individuals, as the default shapes are sized for the lab's original mocap dance data performers (Sarah Marks Mininsohn and Kayt MacMaster)

public class AutoSizeSolids : MonoBehaviour
{
    private TextAsset mocapData;
    private string[] data;
    private string[] row;

    private Vector3 spineMidPos;
    private Vector3 handTipRightPos;
    private Vector3 handTipLeftPos;

    private float proximityToSpineMid;
    private float maxDistance;

    public GameObject cube;
    public GameObject octahedron;
    public GameObject icosahedron;

    // Start is called before the first frame update
    void Start()
    {
 //       AutoSizer();
    }

    // Update is called once per frame
    void Update()
    {
 /*       // Check to see if csvData has changed
        if (mocapData.name == null || !mocapData.name.Equals(GetComponent<MocapPlayer>().csvData.name))
        {
            AutoSizer();
        }
 */   }

    // Gets the csv data file that is the current input of the MocapPlayer and then increases proportions of the three Laban shapes according to the furthest wingspan of the movement data
 /*   void AutoSizer()
    {
        // Reset maxDistance
        maxDistance = 0f;

        // Get csv data
        mocapData = GetComponent<MocapPlayer>().csvData;

        // Divide .csv document into an array, where each item in the array is a new line within the document
        data = mocapData.text.Split(new char[] { '\n' });

        // Run through each line of the .csv document, further dividing them up into an array of all the values of the current line
        // Run through data to see furthest distance from either handpoint to spinemid
        for (int i = 0; i < data.Length; i++)
        {
            row = data[i].Split(new char[] { ',' });

            if (!mocapData.name.Equals("dimscale_lateral_center_data"))
            {
                if (row[2].Equals("/body/1"))
                {
                    // Find spineMid, handTipRight, and handTipLeft positions
                    spineMidPos = new Vector3(float.Parse(row[6]), float.Parse(row[7]), float.Parse(row[8]));
                    handTipRightPos = new Vector3(float.Parse(row[72]), float.Parse(row[73]), float.Parse(row[74]));
                    handTipLeftPos = new Vector3(float.Parse(row[66]), float.Parse(row[67]), float.Parse(row[68]));

                    // Find distance from each handtip to spinemid
                    // If distance is new max, change float max value
                    proximityToSpineMid = Vector3.Distance(spineMidPos, handTipRightPos);
                    if (proximityToSpineMid > maxDistance)
                    {
                        maxDistance = proximityToSpineMid;
                    }
                    proximityToSpineMid = Vector3.Distance(spineMidPos, handTipLeftPos);
                    if (proximityToSpineMid > maxDistance)
                    {
                        maxDistance = proximityToSpineMid;
                    }
                }
            }
            else
            {
                if (!row[0].Equals("time"))
                {
                    // Find spineMid, handTipRight, and handTipLeft positions
                    spineMidPos = new Vector3(float.Parse(row[4]), float.Parse(row[5]), float.Parse(row[6]));
                    handTipRightPos = new Vector3(float.Parse(row[70]), float.Parse(row[71]), float.Parse(row[72]));
                    handTipLeftPos = new Vector3(float.Parse(row[64]), float.Parse(row[65]), float.Parse(row[66]));

                    // Find distance from each handtip to spinemid
                    // If distance is new max, change float max value
                    proximityToSpineMid = Vector3.Distance(spineMidPos, handTipRightPos);
                    if (proximityToSpineMid > maxDistance)
                    {
                        maxDistance = proximityToSpineMid;
                    }
                    proximityToSpineMid = Vector3.Distance(spineMidPos, handTipLeftPos);
                    if (proximityToSpineMid > maxDistance)
                    {
                        maxDistance = proximityToSpineMid;
                    }
                }
            }
        }

        // Increase scale of all three shapes proportionally
        if (maxDistance > 0.9f)
        {
            cube.transform.localScale = new Vector3(15f + (maxDistance - 0.9f) * 7.5f, 15 + (maxDistance - 0.9f) * 7.5f, 15 + (maxDistance - 0.9f) * 7.5f);
            octahedron.transform.localScale = new Vector3(10 + (maxDistance - 0.9f) * 5.5f, 10 + (maxDistance - 0.9f) * 5.5f, 10 + (maxDistance - 0.9f) * 5.5f);
            icosahedron.transform.localScale = new Vector3(11 + (maxDistance - 0.9f) * 5.5f, 11 + (maxDistance - 0.9f) * 5.5f, 11 + (maxDistance - 0.9f) * 5.5f);
        }
    }
 */
}
