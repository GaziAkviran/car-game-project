using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWheelShape : MonoBehaviour
{
	[Tooltip("If you need the visual wheels to be attached automatically, drag the wheel shape here.")]
	public GameObject wheelShape;

	private WheelCollider[] m_Wheels;

	// Find all the WheelColliders down in the hierarchy.
	void Start()
	{
		m_Wheels = GetComponentsInChildren<WheelCollider>();

		for (int i = 0; i < m_Wheels.Length; ++i)
		{
			var wheel = m_Wheels[i];

			// Create wheel shapes only when needed.
			if (wheelShape != null)
			{
				var ws = Instantiate(wheelShape);
				ws.transform.parent = wheel.transform;
			}
		}
	}

    private void Update()
    {
		foreach (WheelCollider wheel in m_Wheels)
		{
			

			// Update visual wheels if any.
			if (wheelShape)
			{
				Quaternion q;
				Vector3 p;
				wheel.GetWorldPose(out p, out q);

				// Assume that the only child of the wheelcollider is the wheel shape.
				Transform shapeTransform = wheel.transform.GetChild(0);

				if (wheel.name == "a0l" || wheel.name == "a1l" || wheel.name == "a2l")
				{
					shapeTransform.rotation = q * Quaternion.Euler(0, 180, 0);
					shapeTransform.position = p;
				}
				else
				{
					shapeTransform.position = p;
					shapeTransform.rotation = q;
				}
			}
		}
	}
}
