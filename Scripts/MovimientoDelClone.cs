using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDelClone : MonoBehaviour
{
    // Referencia al objeto A
    public Transform objectA;

    // Referencia al objeto padre de B que define la orientación del mundo de B
    public Transform parentB;

    // Referencia al objeto B que debe seguir a A
    public Transform objectB;

    void Update()
    {
        // Asegurarse de que las referencias no sean nulas
        if (objectA != null && parentB != null && objectB != null)
        {
            // Calcula la posición relativa de A respecto a B's padre
            Vector3 localPosition = parentB.InverseTransformPoint(objectA.position);

            // Establece la posición de B en el sistema de coordenadas del padre
            objectB.localPosition = localPosition;

            // Calcula la rotación relativa de A respecto a B's padre
            Quaternion localRotation = Quaternion.Inverse(parentB.rotation) * objectA.rotation;

            // Establece la rotación de B en el sistema de coordenadas del padre
            objectB.localRotation = localRotation;
        }
    }

}
