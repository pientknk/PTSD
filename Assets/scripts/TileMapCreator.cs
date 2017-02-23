using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class TileMapCreator : MonoBehaviour {

	public int size_x = 60;
	public int size_y = 40;
	float tileSize = 1.0f;

	// Use this for initialization
	void Start () {
		BuildMesh ();
	}

	public void BuildMesh(){

		int numTiles = size_x * size_y;
		int numTriangles = numTiles * 2;

		int vertSize_x = size_x + 1;
		int vertSize_y = size_y + 1;
		int numVerts = vertSize_x * vertSize_y;

		//initialize data needed for mesh
		Vector3[] vertices = new Vector3[numVerts];
		Vector3[] normals = new Vector3[numVerts];
		Vector2[] uvs = new Vector2[numVerts];
		int[] triangles = new int[numTriangles * 3];

		// setup vertices needed for rendering. Setup normals and uvs for lighting and materials(background)
		int x, y;
		for (y = 0; y < vertSize_y; y++) {
			for (x = 0; x < vertSize_x; x++) {
				vertices [y * vertSize_x + x] = new Vector3 (x * tileSize, y * tileSize, 0);
				normals [y * vertSize_x + x] = Vector3.up;
				uvs [y * vertSize_x + x] = new Vector2 ((float)x / vertSize_x, (float)y / vertSize_y);
			}
		}
		// setup triangles for mesh
		for (y = 0; y < size_y; y++) {
			for (x = 0; x < size_x; x++) {
				int squareIndex = y * size_x + x;
				int triOffset = squareIndex * 6;
				triangles [triOffset] = y * vertSize_x + x;
				triangles [triOffset + 1] = y * vertSize_x + x + vertSize_x;
				triangles [triOffset + 2] = y * vertSize_x + x + vertSize_x + 1;
				triangles [triOffset + 3] = y * vertSize_x + x;
				triangles [triOffset + 4] = y * vertSize_x + x + vertSize_x + 1;
				triangles [triOffset + 5] = y * vertSize_x + x + 1;
			}
		}

		//create new mesh using the data
		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.normals = normals;
		mesh.uv = uvs;

		//assign mesh to filter/renderer/collider which is required to add this script
		MeshFilter filter = GetComponent<MeshFilter>();
		MeshRenderer renderer = GetComponent<MeshRenderer> ();
		MeshCollider collider = GetComponent<MeshCollider> ();

		filter.mesh = mesh;

	}
}
