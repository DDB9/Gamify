using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour 
{

    public GameObject basicTarget, badTarget, extraTarget;
    public Transform targetImagePos;

    // Target positions as integers.
    public int basicTargetPos, extraTargetPos, badTargetPos;

    // Variables that make sure targets are not place over eachother.
    [System.NonSerialized]
    public bool basicPosLeft, basicPosRight;
    [System.NonSerialized]
    public bool badPosLeft, badPosRight;
    [System.NonSerialized]
    public bool extraPosLeft, extraPosRight;

	// Decides what targets are to be placed on the target image.
	void Start ()
    {
        // More probability for the basic target to be spawned.
        // Probability is as follows: 
        // Basic Target: 50%, Bad Target: 30%, Extra Target: 20%
        int defineFirstTarget = Random.Range(1, 10);
        Debug.Log("First target: " + defineFirstTarget);
        if (defineFirstTarget >= 1 && defineFirstTarget <= 5) PositionBasicTarget();
        if (defineFirstTarget > 5 && defineFirstTarget <= 7) PositionExtraTarget();
        if (defineFirstTarget > 7 && defineFirstTarget <= 10) PositionBadTarget();

        int defineSecondTarget = Random.Range(1, 10);
        Debug.Log("Second target: " + defineSecondTarget);
        if (defineSecondTarget >= 1 && defineSecondTarget <= 5) PositionBasicTarget();
        if (defineSecondTarget > 5 && defineSecondTarget <= 7) PositionExtraTarget();
        if (defineFirstTarget > 7 && defineFirstTarget <= 10) PositionBadTarget();
    }
	
	void PositionBasicTarget()
    {
        basicTargetPos = Random.Range(1, 3);

        if (basicTargetPos == 1)
        {
            if (basicPosLeft == true) basicTargetPos = 2;
            else
            {
                basicTarget.transform.position = targetImagePos.position + new Vector3(-0.75f, 0, 0);
                GameObject target = Instantiate(basicTarget.gameObject, basicTarget.transform.position, this.transform.rotation);
                target.transform.SetParent(this.transform);
                basicPosLeft = true;
            }
        }
        if (basicTargetPos == 2)
        {
            if (basicPosRight == true) basicTargetPos = 1;
            else
            {
                basicTarget.transform.position = targetImagePos.position + new Vector3(0.75f, 0, 0);
                GameObject target = Instantiate(basicTarget.gameObject, basicTarget.transform.position, this.transform.rotation);
                target.transform.SetParent(this.transform);
                basicPosRight = true;
            }
        }
    }

    void PositionBadTarget()
    {
        badTargetPos = Random.Range(1, 3);

        if (badTargetPos == 1)
        {
            if (basicPosLeft == true || badPosLeft == true) badTargetPos = 2;
            else
            {
                badTarget.transform.position = targetImagePos.position + new Vector3(-0.75f, 0, 0);
                GameObject target = Instantiate(badTarget.gameObject, badTarget.transform.position, this.transform.rotation);
                target.transform.SetParent(this.transform);
                badPosLeft = true;
            }
        }
        if (badTargetPos == 2)
        {
            if (basicPosRight == true || badPosRight == true) badTargetPos = 1;
            else
            {
                badTarget.transform.position = targetImagePos.position + new Vector3(0.75f, 0, 0);
                GameObject target = Instantiate(badTarget.gameObject, badTarget.transform.position, this.transform.rotation);
                target.transform.SetParent(this.transform);
                badPosRight = true;
            }
        }
    }

    void PositionExtraTarget()
    {
        extraTargetPos = Random.Range(1, 3);
        
        if (extraTargetPos == 1)
        {
            if (basicPosLeft == true || badPosLeft == true || extraPosLeft == true) extraTargetPos = 2;
            else
            {
                extraTarget.transform.position = targetImagePos.position + new Vector3(-0.75f, 0, 0);
                GameObject target = Instantiate(extraTarget, extraTarget.transform.position, this.transform.rotation);
                target.transform.SetParent(this.transform);
                extraPosLeft = true;
            }
        }
        if (extraTargetPos == 2)
        {
            if (basicPosRight == true || badPosRight == true || extraPosRight == true) extraTargetPos = 1;
            else
            {
                extraTarget.transform.position = targetImagePos.position + new Vector3(0.75f, 0, 0);
                GameObject target = Instantiate(extraTarget, extraTarget.transform.position, this.transform.rotation);
                target.transform.SetParent(this.transform);
                extraPosRight = true;
            }
        }
    }
}
