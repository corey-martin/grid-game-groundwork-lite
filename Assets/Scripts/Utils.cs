using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utils
{
	static int maxColliders = 5;

	public static IEnumerator LoadScene(string scene) {
		yield return WaitFor.EndOfFrame;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}

    public static int StringToInt(string intString) {
        int i = 0;
        if (!System.Int32.TryParse(intString, out i)) {
            i = 0;
        }
        return i;
    }

	public static bool Roughly(float one, float two, float tolerance = 0.5f) {
		return Mathf.Abs(one - two) < tolerance;
    }

    public static bool VectorRoughly(Vector3 one, Vector3 two, float t = 0.5f) {
        return Roughly(one.x, two.x, t) && Roughly(one.y, two.y, t) && Roughly(one.z, two.z, t);
    }

	public static bool VectorRoughly2D(Vector3 one, Vector3 two, float t = 0.5f) {
        return Roughly(one.x, two.x, t) && Roughly(one.y, two.y, t);
    }

    public static void RoundPosition(Transform t) {
    	Vector3 p = t.position;
    	t.position = Vec3ToInt(p);
    }

    public static void AvoidIntersect(Transform root) {
		bool intersecting = true;
		while (intersecting) {
			intersecting = false;
			foreach (Transform tile in root) {
				if (tile.gameObject.CompareTag("Tile")) {
					BaseObject obj = ObjectAtPosition(tile.position);
					if (obj != null && obj.transform != root) {
						root.position += Vector3.up;
						intersecting = true;
					}
				}
			}
		}
    }

	public static Vector3 AvoidIntersect(Vector3 v) {
    	bool intersecting = true;
    	while (intersecting) {
    		intersecting = false;

			if (!TileIsEmpty(v)) {
				v += Vector3.up;
				intersecting = true;
			}
    	}
		return v;
	}

	public static Vector3Int Vec3ToInt(Vector3 v) {
		return Vector3Int.RoundToInt(v);
	}

	public static bool TileIsEmpty(Vector3 pos) {
		return TileIsEmpty(Vec3ToInt(pos));
	}

	public static bool TileIsEmpty(Vector3Int pos) {
		return ObjectAtPosition(pos) == null;
	}

	public static BaseObject ObjectAtPosition(Vector3 pos) {
		Collider[] colliders = GetCollidersAt(pos);

        for (int i = 0; i < colliders.Length; i++) {
			BaseObject obj = colliders[i].GetComponentInParent<BaseObject>();
			if (obj != null) { 
				return obj;
			}
        }
		return null;	
	}

	public static Collider[] GetCollidersAt(Vector3 pos) {
		return GetCollidersAt(Vec3ToInt(pos));
	}

	public static Collider[] GetCollidersAt(Vector3Int pos) {
		Collider[] colliders = new Collider[maxColliders];
        int numColliders = Physics.OverlapSphereNonAlloc(pos, 0.4f, colliders);
		System.Array.Resize(ref colliders, numColliders);
		return colliders;
	}
}
