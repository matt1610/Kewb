using System;
using UnityEngine;
using System.Collections;

namespace Kewb
{
	public interface ICollideable
	{
		void CollidedWithCharacter(GameObject go);
	}
}
