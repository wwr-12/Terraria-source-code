using System;

namespace Steamworks
{
	public delegate void APIDispatchDelegate<T>(T param, bool bIOFailure);
	public delegate void DispatchDelegate<T>(T param);
}
