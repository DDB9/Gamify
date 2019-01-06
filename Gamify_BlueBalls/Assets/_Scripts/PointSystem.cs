using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour 
{
    void OnCollisionEnter(Collision other)
    {
        if (this.name == "Schijf_Standaard(Clone)") ShootyScript.score += 3;
        else if (this.name == "Schijf_ExtraPunten(Clone)") ShootyScript.score += 10;
        else if (this.name == "Schijf_Minpunten(Clone)") ShootyScript.score -= 5;

        Destroy(other.gameObject, 0.3f);
        this.gameObject.SetActive(false);
    }
}
