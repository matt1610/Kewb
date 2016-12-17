using System;
using UnityEngine;
using System.Collections;

namespace Kewb
{
	public interface IEnemy
	{
		void TakeHit(float damage);
	}
}