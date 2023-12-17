using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour
{
    MeshFilter meshFilter;
    Vector3[] vertices;

    public Mesh test;

    void Update()
    {
        // 사용자 입력에 따라 Mesh 일부 이동
        float offsetX = Input.GetAxis("Horizontal") * Time.deltaTime;
        float offsetY = Input.GetAxis("Vertical") * Time.deltaTime;

        MoveMesh(offsetX, offsetY);
    }

    void MoveMesh(float offsetX, float offsetY)
    {
        // Mesh의 일부를 이동
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] += new Vector3(offsetX, offsetY, 0f);
        }

        // 변경된 Mesh 데이터를 적용
        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateBounds();
    }

    public void SetMesh(Mesh newMesh)
    {
        // 외부에서 Mesh를 받아와 MeshFilter에 연결
        meshFilter.mesh = test;

        // 초기 상태 저장
        vertices = test.vertices;
    }
}
