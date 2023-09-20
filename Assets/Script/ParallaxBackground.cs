using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
	[SerializeField]
	private	Transform		cameraTransform;		// ī�޶��� Transform ������Ʈ
	
	private	Vector3			cameraStartPosition;	// ������ �������� �� ī�޶��� ���� ��ġ
	private	float			distance;				// cameraStartPosition���� ���� ���� ī�޶������ x �̵��Ÿ�

	private	Material[]		materials;				// ��� ��ũ���� ���� Material �迭 ����
	private	float[]			layerMoveSpeed;			// z ���� �ٸ� ��� ���̾� �� �̵� �ӵ�

	[SerializeField][Range(0.01f, 1.0f)]
	private	float			parallaxSpeed;			// layerMoveSpeed�� ���ؼ� ����ϴ� ��� ��ũ�� �̵� �ӵ�

	private void Awake()
	{
		// ������ ������ �� ī�޶��� ��ġ ���� (�̵� �Ÿ� ����)
		cameraStartPosition = cameraTransform.position;

		// ����� ������ ���ϰ�, ��� ������ ������ GameObject �迭 ����
		int			 backgroundCount = transform.childCount;
		GameObject[] backgrounds	 = new GameObject[backgroundCount];

		// �� ����� material�� �̵� �ӵ��� ������ �迭 ����
		materials		= new Material[backgroundCount];
		layerMoveSpeed	= new float[backgroundCount];

		// GetChild() �޼ҵ带 ȣ���� �ڽ����� �ִ� ��� �������� �ҷ��´�
		for ( int i = 0; i < backgroundCount; ++ i )
		{
			backgrounds[i] = transform.GetChild(i).gameObject;
			materials[i] = backgrounds[i].GetComponent<Renderer>().material;
		}

		// ���̾�(ī�޶���� z �Ÿ� ����)���� �̵� �ӵ� ����
		CalculateMoveSpeedByLayer(backgrounds, backgroundCount);
	}

	private void CalculateMoveSpeedByLayer(GameObject[] backgrounds, int count)
	{
		float farthestBackDistance = 0;
		// ī�޶�κ��� ���� �ָ� ������ ��� ���̾���� z �Ÿ� ���
		for ( int i = 0; i < count; ++ i )
		{
			if ( (backgrounds[i].transform.position.z - cameraTransform.position.z ) > farthestBackDistance )
			{
				farthestBackDistance = backgrounds[i].transform.position.z - cameraTransform.position.z;
			}
		}

		// ī�޶���� z ��ġ �Ÿ��� �ٸ� ��� ���̾�� �̵� �ӵ� ����
		for ( int i = 0; i < count; ++ i )
		{
			// ���� �ָ� ������ ��� ���̾��� �̵� �ӵ� = 0
			layerMoveSpeed[i] = 1 - (backgrounds[i].transform.position.z - cameraTransform.position.z) / farthestBackDistance;
			// �̵��ӵ� Ȯ�ο� (�׽�Ʈ �� ����)
			Debug.Log($"{layerMoveSpeed[i]}, ���� �̵��ӵ� = {layerMoveSpeed[i] * parallaxSpeed}");
		}
	}

	private void LateUpdate()
	{
		// ī�޶� �̵��� �Ÿ� = ī�޶��� ���� ��ġ - ���� ��ġ
		distance = cameraTransform.position.x - cameraStartPosition.x;
		// ����� x ��ġ�� ���� ī�޶��� x ��ġ�� ����
		transform.position = new Vector3(cameraTransform.position.x, transform.position.y, 0);

		// ���̾�� ���� ����� ��µǴ� offset ����
		for ( int i = 0; i < materials.Length; ++ i )
		{
			float speed = layerMoveSpeed[i] * parallaxSpeed;
			materials[i].SetTextureOffset("_MainTex", new Vector2(distance, 0)*0.02f);
		}
	}
}

