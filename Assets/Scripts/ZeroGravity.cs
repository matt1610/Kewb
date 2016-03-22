
// ------------------------------------------------------------------------------
//  ZERO GRAVITY ABILITY
// ------------------------------------------------------------------------------

using System;
using UnityEngine;
using System.Collections;

namespace Kewb
{
	public class ZeroGravity : Magic
	{
		public string Name { get; set; }
		public int GemUsage { get; set; }
		public bool Ready = true;
		public string GameName { get; set; }

		public ZeroGravity()
		{
			Name = StringContainer.GetString(2,1);
			GemUsage = 3;
			GameName = "ZeroGravity";
		}

		public void Execute() 
		{
			Debug.Log (Name);
			GameManager.Instance.playerRigidBody.useGravity = !GameManager.Instance.playerRigidBody.useGravity;
		}


	}
}

