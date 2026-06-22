using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
	public class Mount
	{
		private class MountData
		{
			public Texture2D backTexture;

			public Texture2D backTextureExtra;

			public Texture2D frontTexture;

			public Texture2D frontTextureExtra;

			public int textureWidth;

			public int textureHeight;

			public int xOffset;

			public int yOffset;

			public int[] playerYOffsets;

			public int bodyFrame;

			public int playerHeadOffset;

			public int heightBoost;

			public int buff;

			public int extraBuff;

			public int flightTimeMax;

			public float runSpeed;

			public float dashSpeed;

			public float swimSpeed;

			public float acceleration;

			public float jumpSpeed;

			public int jumpHeight;

			public float fallDamage;

			public int fatigueMax;

			public bool constantJump;

			public bool blockExtraJumps;

			public int spawnDust;

			public int totalFrames;

			public int standingFrameStart;

			public int standingFrameCount;

			public int standingFrameDelay;

			public int runningFrameStart;

			public int runningFrameCount;

			public int runningFrameDelay;

			public int flyingFrameStart;

			public int flyingFrameCount;

			public int flyingFrameDelay;

			public int inAirFrameStart;

			public int inAirFrameCount;

			public int inAirFrameDelay;

			public int idleFrameStart;

			public int idleFrameCount;

			public int idleFrameDelay;

			public bool idleFrameLoop;

			public int swimFrameStart;

			public int swimFrameCount;

			public int swimFrameDelay;
		}

		public const int None = -1;

		public const int Rudolph = 0;

		public const int Bunny = 1;

		public const int Pigron = 2;

		public const int Slime = 3;

		public const int Turtle = 4;

		public const int Bee = 5;

		public const int Minecart = 6;

		public const int maxMounts = 7;

		public const int FrameStanding = 0;

		public const int FrameRunning = 1;

		public const int FrameInAir = 2;

		public const int FrameFlying = 3;

		public const int FrameSwimming = 4;

		private static MountData[] mounts;

		private MountData _data;

		private int _type;

		private bool _flipDraw;

		private int _frame;

		private float _frameCounter;

		private int _frameExtra;

		private float _frameExtraCounter;

		private int _frameState;

		private int _flyTime;

		private int _idleTime;

		private int _idleTimeNext;

		private float _fatigue;

		private float _fatigueMax;

		private bool _active;

		public bool Active => _active;

		public int Type => _type;

		public int FlyTime => _flyTime;

		public int BuffType => _data.buff;

		public bool FlipDraw => _flipDraw;

		public int BodyFrame => _data.bodyFrame;

		public int XOffset => _data.xOffset;

		public int YOffset => _data.yOffset;

		public int PlayerOffset
		{
			get
			{
				if (!_active)
				{
					return 0;
				}
				return _data.playerYOffsets[_frame];
			}
		}

		public int PlayerHeadOffset
		{
			get
			{
				if (!_active)
				{
					return 0;
				}
				return _data.playerHeadOffset;
			}
		}

		public int HeightBoost => _data.heightBoost;

		public Texture2D FrontTexture
		{
			get
			{
				if (_type == 0 && _idleTime >= _idleTimeNext)
				{
					return null;
				}
				return _data.frontTexture;
			}
		}

		public Texture2D BackTexture => _data.backTexture;

		public Texture2D FrontTextureExtra => _data.frontTextureExtra;

		public Texture2D BackTextureExtra => _data.backTextureExtra;

		public float RunSpeed
		{
			get
			{
				if (_type == 4 && _frameState == 4)
				{
					return _data.swimSpeed;
				}
				if (_type == 5 && _frameState == 2)
				{
					float num = _fatigue / _fatigueMax;
					return _data.runSpeed + 4f * (1f - num);
				}
				return _data.runSpeed;
			}
		}

		public float DashSpeed => _data.dashSpeed;

		public float Acceleration => _data.acceleration;

		public float FallDamage => _data.fallDamage;

		public bool AutoJump => _data.constantJump;

		public bool BlockExtraJumps => _data.blockExtraJumps;

		public Rectangle FrameRect
		{
			get
			{
				int num = _data.textureHeight / _data.totalFrames;
				return new Rectangle(0, num * _frame, _data.textureWidth, num);
			}
		}

		public Rectangle FrameRectExtra
		{
			get
			{
				int num = _data.textureHeight / _data.totalFrames;
				if (_type == 5)
				{
					return new Rectangle(0, num * _frameExtra, _data.textureWidth, num);
				}
				return new Rectangle(0, num * _frame, _data.textureWidth, num);
			}
		}

		public Vector2 Origin => new Vector2((float)_data.textureWidth / 2f, (float)_data.textureHeight / (2f * (float)_data.totalFrames));

		public bool CanFly
		{
			get
			{
				if (!_active || _data.flightTimeMax == 0)
				{
					return false;
				}
				return true;
			}
		}

		public Mount()
		{
			Reset();
		}

		public void Reset()
		{
			_active = false;
			_type = -1;
			_frame = 0;
			_frameCounter = 0f;
			_frameExtra = 0;
			_frameExtraCounter = 0f;
			_frameState = 0;
			_flyTime = 0;
			_idleTime = 0;
			_idleTimeNext = -1;
			_fatigueMax = 0f;
		}

		public static void Initialize()
		{
			mounts = new MountData[7];
			MountData mountData = new MountData();
			mounts[0] = mountData;
			mountData.spawnDust = 57;
			mountData.buff = 90;
			mountData.heightBoost = 20;
			mountData.flightTimeMax = 160;
			mountData.runSpeed = 5.5f;
			mountData.dashSpeed = 12f;
			mountData.acceleration = 0.09f;
			mountData.jumpHeight = 17;
			mountData.jumpSpeed = 5.31f;
			if (Main.netMode != 2)
			{
				mountData.backTexture = Main.rudolphMountTexture[0];
				mountData.backTextureExtra = null;
				mountData.frontTexture = Main.rudolphMountTexture[1];
				mountData.frontTextureExtra = Main.rudolphMountTexture[2];
				mountData.textureWidth = mountData.backTexture.Width;
				mountData.textureHeight = mountData.backTexture.Height;
				mountData.totalFrames = 12;
				int[] array = new int[mountData.totalFrames];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = 30;
				}
				array[1] += 2;
				array[11] += 2;
				mountData.playerYOffsets = array;
				mountData.xOffset = 13;
				mountData.bodyFrame = 3;
				mountData.yOffset = -7;
				mountData.playerHeadOffset = 22;
				mountData.standingFrameCount = 1;
				mountData.standingFrameDelay = 12;
				mountData.standingFrameStart = 0;
				mountData.runningFrameCount = 6;
				mountData.runningFrameDelay = 12;
				mountData.runningFrameStart = 6;
				mountData.flyingFrameCount = 6;
				mountData.flyingFrameDelay = 6;
				mountData.flyingFrameStart = 6;
				mountData.inAirFrameCount = 1;
				mountData.inAirFrameDelay = 12;
				mountData.inAirFrameStart = 1;
				mountData.idleFrameCount = 4;
				mountData.idleFrameDelay = 30;
				mountData.idleFrameStart = 2;
				mountData.idleFrameLoop = true;
			}
			mountData = new MountData();
			mounts[2] = mountData;
			mountData.spawnDust = 58;
			mountData.buff = 129;
			mountData.heightBoost = 20;
			mountData.flightTimeMax = 160;
			mountData.runSpeed = 5f;
			mountData.dashSpeed = 9f;
			mountData.acceleration = 0.08f;
			mountData.jumpHeight = 10;
			mountData.jumpSpeed = 6.01f;
			if (Main.netMode != 2)
			{
				mountData.backTexture = Main.pigronMountTexture;
				mountData.backTextureExtra = null;
				mountData.frontTexture = null;
				mountData.frontTextureExtra = null;
				mountData.textureWidth = mountData.backTexture.Width;
				mountData.textureHeight = mountData.backTexture.Height;
				mountData.totalFrames = 16;
				int[] array = new int[mountData.totalFrames];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = 22;
				}
				array[12] += 2;
				array[13] += 4;
				array[14] += 2;
				mountData.playerYOffsets = array;
				mountData.xOffset = 1;
				mountData.bodyFrame = 3;
				mountData.yOffset = 8;
				mountData.playerHeadOffset = 22;
				mountData.standingFrameCount = 1;
				mountData.standingFrameDelay = 12;
				mountData.standingFrameStart = 7;
				mountData.runningFrameCount = 5;
				mountData.runningFrameDelay = 12;
				mountData.runningFrameStart = 11;
				mountData.flyingFrameCount = 6;
				mountData.flyingFrameDelay = 6;
				mountData.flyingFrameStart = 1;
				mountData.inAirFrameCount = 1;
				mountData.inAirFrameDelay = 12;
				mountData.inAirFrameStart = 0;
				mountData.idleFrameCount = 3;
				mountData.idleFrameDelay = 30;
				mountData.idleFrameStart = 8;
				mountData.idleFrameLoop = false;
			}
			mountData = new MountData();
			mounts[1] = mountData;
			mountData.spawnDust = 15;
			mountData.buff = 128;
			mountData.heightBoost = 20;
			mountData.flightTimeMax = 0;
			mountData.fallDamage = 0.8f;
			mountData.runSpeed = 4f;
			mountData.dashSpeed = 7.5f;
			mountData.acceleration = 0.13f;
			mountData.jumpHeight = 15;
			mountData.jumpSpeed = 5.01f;
			if (Main.netMode != 2)
			{
				mountData.backTexture = Main.bunnyMountTexture;
				mountData.backTextureExtra = null;
				mountData.frontTexture = null;
				mountData.frontTextureExtra = null;
				mountData.textureWidth = mountData.backTexture.Width;
				mountData.textureHeight = mountData.backTexture.Height;
				mountData.totalFrames = 7;
				int[] array = new int[mountData.totalFrames];
				for (int k = 0; k < array.Length; k++)
				{
					array[k] = 14;
				}
				array[2] += 2;
				array[3] += 4;
				array[4] += 8;
				array[5] += 8;
				mountData.playerYOffsets = array;
				mountData.xOffset = 1;
				mountData.bodyFrame = 3;
				mountData.yOffset = 4;
				mountData.playerHeadOffset = 22;
				mountData.standingFrameCount = 1;
				mountData.standingFrameDelay = 12;
				mountData.standingFrameStart = 0;
				mountData.runningFrameCount = 7;
				mountData.runningFrameDelay = 12;
				mountData.runningFrameStart = 0;
				mountData.flyingFrameCount = 6;
				mountData.flyingFrameDelay = 6;
				mountData.flyingFrameStart = 1;
				mountData.inAirFrameCount = 1;
				mountData.inAirFrameDelay = 12;
				mountData.inAirFrameStart = 5;
				mountData.idleFrameCount = 0;
				mountData.idleFrameDelay = 0;
				mountData.idleFrameStart = 0;
				mountData.idleFrameLoop = false;
			}
			mountData = new MountData();
			mounts[3] = mountData;
			mountData.spawnDust = 56;
			mountData.buff = 130;
			mountData.heightBoost = 20;
			mountData.flightTimeMax = 0;
			mountData.fallDamage = 0.5f;
			mountData.runSpeed = 4f;
			mountData.dashSpeed = 4f;
			mountData.acceleration = 0.08f;
			mountData.jumpHeight = 22;
			mountData.jumpSpeed = 7.25f;
			mountData.constantJump = true;
			if (Main.netMode != 2)
			{
				mountData.backTexture = Main.slimeMountTexture;
				mountData.backTextureExtra = null;
				mountData.frontTexture = null;
				mountData.frontTextureExtra = null;
				mountData.textureWidth = mountData.backTexture.Width;
				mountData.textureHeight = mountData.backTexture.Height;
				mountData.totalFrames = 4;
				int[] array = new int[mountData.totalFrames];
				for (int l = 0; l < array.Length; l++)
				{
					array[l] = 20;
				}
				array[1] += 2;
				array[3] -= 2;
				mountData.playerYOffsets = array;
				mountData.xOffset = 1;
				mountData.bodyFrame = 3;
				mountData.yOffset = 10;
				mountData.playerHeadOffset = 22;
				mountData.standingFrameCount = 1;
				mountData.standingFrameDelay = 12;
				mountData.standingFrameStart = 0;
				mountData.runningFrameCount = 4;
				mountData.runningFrameDelay = 12;
				mountData.runningFrameStart = 0;
				mountData.flyingFrameCount = 0;
				mountData.flyingFrameDelay = 0;
				mountData.flyingFrameStart = 0;
				mountData.inAirFrameCount = 1;
				mountData.inAirFrameDelay = 12;
				mountData.inAirFrameStart = 1;
				mountData.idleFrameCount = 0;
				mountData.idleFrameDelay = 0;
				mountData.idleFrameStart = 0;
				mountData.idleFrameLoop = false;
			}
			mountData = new MountData();
			mounts[6] = mountData;
			mountData.spawnDust = 213;
			mountData.buff = 118;
			mountData.extraBuff = 138;
			mountData.heightBoost = 10;
			mountData.flightTimeMax = 0;
			mountData.fallDamage = 1f;
			mountData.runSpeed = 13f;
			mountData.dashSpeed = 13f;
			mountData.acceleration = 0.04f;
			mountData.jumpHeight = 15;
			mountData.jumpSpeed = 5.15f;
			mountData.blockExtraJumps = true;
			if (Main.netMode != 2)
			{
				mountData.backTexture = null;
				mountData.backTextureExtra = null;
				mountData.frontTexture = Main.minecartMountTexture;
				mountData.frontTextureExtra = null;
				mountData.textureWidth = mountData.frontTexture.Width;
				mountData.textureHeight = mountData.frontTexture.Height;
				mountData.totalFrames = 3;
				int[] array = new int[mountData.totalFrames];
				for (int m = 0; m < array.Length; m++)
				{
					array[m] = 8;
				}
				mountData.playerYOffsets = array;
				mountData.xOffset = 1;
				mountData.bodyFrame = 3;
				mountData.yOffset = 13;
				mountData.playerHeadOffset = 14;
				mountData.standingFrameCount = 1;
				mountData.standingFrameDelay = 12;
				mountData.standingFrameStart = 0;
				mountData.runningFrameCount = 3;
				mountData.runningFrameDelay = 12;
				mountData.runningFrameStart = 0;
				mountData.flyingFrameCount = 0;
				mountData.flyingFrameDelay = 0;
				mountData.flyingFrameStart = 0;
				mountData.inAirFrameCount = 0;
				mountData.inAirFrameDelay = 0;
				mountData.inAirFrameStart = 0;
				mountData.idleFrameCount = 0;
				mountData.idleFrameDelay = 0;
				mountData.idleFrameStart = 0;
				mountData.idleFrameLoop = false;
			}
			mountData = new MountData();
			mounts[4] = mountData;
			mountData.spawnDust = 56;
			mountData.buff = 131;
			mountData.heightBoost = 26;
			mountData.flightTimeMax = 0;
			mountData.fallDamage = 1f;
			mountData.runSpeed = 2f;
			mountData.dashSpeed = 2f;
			mountData.swimSpeed = 6f;
			mountData.acceleration = 0.08f;
			mountData.jumpHeight = 10;
			mountData.jumpSpeed = 3.15f;
			if (Main.netMode != 2)
			{
				mountData.backTexture = Main.turtleMountTexture;
				mountData.backTextureExtra = null;
				mountData.frontTexture = null;
				mountData.frontTextureExtra = null;
				mountData.textureWidth = mountData.backTexture.Width;
				mountData.textureHeight = mountData.backTexture.Height;
				mountData.totalFrames = 12;
				int[] array = new int[mountData.totalFrames];
				for (int n = 0; n < array.Length; n++)
				{
					array[n] = 26;
				}
				mountData.playerYOffsets = array;
				mountData.xOffset = 1;
				mountData.bodyFrame = 3;
				mountData.yOffset = 13;
				mountData.playerHeadOffset = 30;
				mountData.standingFrameCount = 1;
				mountData.standingFrameDelay = 12;
				mountData.standingFrameStart = 0;
				mountData.runningFrameCount = 6;
				mountData.runningFrameDelay = 12;
				mountData.runningFrameStart = 0;
				mountData.flyingFrameCount = 0;
				mountData.flyingFrameDelay = 0;
				mountData.flyingFrameStart = 0;
				mountData.inAirFrameCount = 1;
				mountData.inAirFrameDelay = 12;
				mountData.inAirFrameStart = 3;
				mountData.idleFrameCount = 0;
				mountData.idleFrameDelay = 0;
				mountData.idleFrameStart = 0;
				mountData.idleFrameLoop = false;
				mountData.swimFrameCount = 6;
				mountData.swimFrameDelay = 12;
				mountData.swimFrameStart = 6;
			}
			mountData = new MountData();
			mounts[5] = mountData;
			mountData.spawnDust = 152;
			mountData.buff = 132;
			mountData.heightBoost = 16;
			mountData.flightTimeMax = 320;
			mountData.fatigueMax = 320;
			mountData.fallDamage = 0f;
			mountData.runSpeed = 2f;
			mountData.dashSpeed = 2f;
			mountData.acceleration = 0.16f;
			mountData.jumpHeight = 10;
			mountData.jumpSpeed = 4f;
			mountData.blockExtraJumps = true;
			if (Main.netMode != 2)
			{
				mountData.backTexture = Main.beeMountTexture[0];
				mountData.backTextureExtra = Main.beeMountTexture[1];
				mountData.frontTexture = null;
				mountData.frontTextureExtra = null;
				mountData.textureWidth = mountData.backTexture.Width;
				mountData.textureHeight = mountData.backTexture.Height;
				mountData.totalFrames = 12;
				int[] array = new int[mountData.totalFrames];
				for (int num = 0; num < array.Length; num++)
				{
					array[num] = 16;
				}
				array[8] = 18;
				mountData.playerYOffsets = array;
				mountData.xOffset = 1;
				mountData.bodyFrame = 3;
				mountData.yOffset = 4;
				mountData.playerHeadOffset = 18;
				mountData.standingFrameCount = 1;
				mountData.standingFrameDelay = 12;
				mountData.standingFrameStart = 0;
				mountData.runningFrameCount = 5;
				mountData.runningFrameDelay = 12;
				mountData.runningFrameStart = 0;
				mountData.flyingFrameCount = 3;
				mountData.flyingFrameDelay = 12;
				mountData.flyingFrameStart = 5;
				mountData.inAirFrameCount = 3;
				mountData.inAirFrameDelay = 12;
				mountData.inAirFrameStart = 5;
				mountData.idleFrameCount = 4;
				mountData.idleFrameDelay = 12;
				mountData.idleFrameStart = 8;
				mountData.idleFrameLoop = true;
				mountData.swimFrameCount = 0;
				mountData.swimFrameDelay = 12;
				mountData.swimFrameStart = 0;
			}
		}

		public static int GetHeightBoost(int MountType)
		{
			if (MountType <= -1 || MountType >= 7)
			{
				return 0;
			}
			return mounts[MountType].heightBoost;
		}

		public int JumpHeight(float xVelocity)
		{
			int num = _data.jumpHeight;
			switch (_type)
			{
			case 0:
				num += (int)(Math.Abs(xVelocity) / 4f);
				break;
			case 1:
				num += (int)(Math.Abs(xVelocity) / 2.5f);
				break;
			case 4:
				if (_frameState == 4)
				{
					num += 5;
				}
				break;
			}
			return num;
		}

		public float JumpSpeed(float xVelocity)
		{
			float num = _data.jumpSpeed;
			switch (_type)
			{
			case 0:
			case 1:
				num += Math.Abs(xVelocity) / 7f;
				break;
			case 4:
				if (_frameState == 4)
				{
					num += 2.5f;
				}
				break;
			}
			return num;
		}

		public bool CheckBuff(int buffID)
		{
			if (_data.buff != buffID)
			{
				return _data.extraBuff == buffID;
			}
			return true;
		}

		public void FatigueRecovery()
		{
			if (_fatigue > 2f)
			{
				_fatigue -= 2f;
			}
			else
			{
				_fatigue = 0f;
			}
		}

		public bool Flight()
		{
			if (_flyTime <= 0)
			{
				return false;
			}
			_flyTime--;
			return true;
		}

		public bool Hover(Player mountedPlayer)
		{
			if (_frameState == 2)
			{
				bool flag = true;
				float num = mountedPlayer.gravity / Player.defaultGravity;
				if (mountedPlayer.slowFall)
				{
					num /= 3f;
				}
				if (num < 0.25f)
				{
					num = 0.25f;
				}
				if (_flyTime > 0)
				{
					_flyTime--;
				}
				else if (_fatigue < _fatigueMax)
				{
					_fatigue += num;
				}
				else
				{
					flag = false;
				}
				float num2 = _fatigue / _fatigueMax;
				float num3 = 4f * num2;
				float num4 = 4f * num2;
				if (num3 == 0f)
				{
					num3 = 0.001f;
				}
				if (num4 == 0f)
				{
					num4 = 0.001f;
				}
				float num5 = mountedPlayer.velocity.Y;
				if ((mountedPlayer.controlUp || mountedPlayer.controlJump) && flag)
				{
					num3 = -2f - 6f * (1f - num2);
					num5 -= _data.acceleration;
				}
				else if (mountedPlayer.controlDown)
				{
					num5 += _data.acceleration;
					num4 = 8f;
				}
				else
				{
					int jump = mountedPlayer.jump;
				}
				if (num5 < num3)
				{
					num5 = ((!(num3 - num5 < _data.acceleration)) ? (num5 + _data.acceleration) : num3);
				}
				else if (num5 > num4)
				{
					num5 = ((!(num5 - num4 < _data.acceleration)) ? (num5 - _data.acceleration) : num4);
				}
				mountedPlayer.velocity.Y = num5;
			}
			else
			{
				mountedPlayer.velocity.Y += mountedPlayer.gravity * mountedPlayer.gravDir;
			}
			return true;
		}

		public void UpdateFrame(int state, Vector2 velocity)
		{
			if (_frameState != state)
			{
				_frameState = state;
				_frameCounter = 0f;
			}
			if (state != 0)
			{
				_idleTime = 0;
			}
			if (_type == 5 && state != 2)
			{
				_frameExtra = 0;
				_frameExtraCounter = 0f;
			}
			switch (state)
			{
			case 0:
				if (_data.idleFrameCount != 0)
				{
					if (_type == 5)
					{
						if (_fatigue != 0f)
						{
							if (_idleTime == 0)
							{
								_idleTimeNext = _idleTime + 1;
							}
						}
						else
						{
							_idleTime = 0;
							_idleTimeNext = 2;
						}
					}
					else if (_idleTime == 0)
					{
						_idleTimeNext = Main.rand.Next(900, 1500);
					}
					_idleTime++;
				}
				_frameCounter += 1f;
				if (_data.idleFrameCount != 0 && _idleTime >= _idleTimeNext)
				{
					float num = _data.idleFrameDelay;
					if (_type == 5)
					{
						num *= 2f - 1f * _fatigue / _fatigueMax;
					}
					int num2 = (int)((float)(_idleTime - _idleTimeNext) / num);
					if (num2 >= _data.idleFrameCount)
					{
						if (_data.idleFrameLoop)
						{
							_idleTime = _idleTimeNext;
							_frame = _data.idleFrameStart;
						}
						else
						{
							_frameCounter = 0f;
							_frame = _data.standingFrameStart;
							_idleTime = 0;
						}
					}
					else
					{
						_frame = _data.idleFrameStart + num2;
					}
					if (_type == 5)
					{
						_frameExtra = _frame;
					}
				}
				else
				{
					if (_frameCounter > (float)_data.standingFrameDelay)
					{
						_frameCounter -= _data.standingFrameDelay;
						_frame++;
					}
					if (_frame < _data.standingFrameStart || _frame >= _data.standingFrameStart + _data.standingFrameCount)
					{
						_frame = _data.standingFrameStart;
					}
				}
				break;
			case 1:
			{
				float num4 = ((_type != 6) ? Math.Abs(velocity.X) : (_flipDraw ? velocity.X : (0f - velocity.X)));
				_frameCounter += num4;
				if (num4 >= 0f)
				{
					if (_frameCounter > (float)_data.runningFrameDelay)
					{
						_frameCounter -= _data.runningFrameDelay;
						_frame++;
					}
					if (_frame < _data.runningFrameStart || _frame >= _data.runningFrameStart + _data.runningFrameCount)
					{
						_frame = _data.runningFrameStart;
					}
				}
				else
				{
					if (_frameCounter < 0f)
					{
						_frameCounter += _data.runningFrameDelay;
						_frame--;
					}
					if (_frame < _data.runningFrameStart || _frame >= _data.runningFrameStart + _data.runningFrameCount)
					{
						_frame = _data.runningFrameStart + _data.runningFrameCount - 1;
					}
				}
				break;
			}
			case 3:
				_frameCounter += 1f;
				if (_frameCounter > (float)_data.flyingFrameDelay)
				{
					_frameCounter -= _data.flyingFrameDelay;
					_frame++;
				}
				if (_frame < _data.flyingFrameStart || _frame >= _data.flyingFrameStart + _data.flyingFrameCount)
				{
					_frame = _data.flyingFrameStart;
				}
				break;
			case 2:
				_frameCounter += 1f;
				if (_frameCounter > (float)_data.inAirFrameDelay)
				{
					_frameCounter -= _data.inAirFrameDelay;
					_frame++;
				}
				if (_frame < _data.inAirFrameStart || _frame >= _data.inAirFrameStart + _data.inAirFrameCount)
				{
					_frame = _data.inAirFrameStart;
				}
				if (_type == 4)
				{
					if (velocity.Y < 0f)
					{
						_frame = 3;
					}
					else
					{
						_frame = 6 + Main.debugToggle % 6;
					}
				}
				else if (_type == 5)
				{
					float num3 = _fatigue / _fatigueMax;
					_frameExtraCounter += 6f - 4f * num3;
					if (_frameExtraCounter > (float)_data.flyingFrameDelay)
					{
						_frameExtra++;
						_frameExtraCounter -= _data.flyingFrameDelay;
					}
					if (_frameExtra < _data.flyingFrameStart || _frameExtra >= _data.flyingFrameStart + _data.flyingFrameCount)
					{
						_frameExtra = _data.flyingFrameStart;
					}
				}
				break;
			case 4:
				_frameCounter += (int)((Math.Abs(velocity.X) + Math.Abs(velocity.Y)) / 2f);
				if (_frameCounter > (float)_data.swimFrameDelay)
				{
					_frameCounter -= _data.swimFrameDelay;
					_frame++;
				}
				if (_frame < _data.swimFrameStart || _frame >= _data.swimFrameStart + _data.swimFrameCount)
				{
					_frame = _data.swimFrameStart;
				}
				break;
			}
		}

		public void ResetFlightTime(float xVelocity)
		{
			_flyTime = (_active ? _data.flightTimeMax : 0);
			if (_type == 0)
			{
				_flyTime += (int)(Math.Abs(xVelocity) * 20f);
			}
		}

		public void CheckMountBuff(Player mountedPlayer)
		{
			if (_type == -1)
			{
				return;
			}
			for (int i = 0; i < 22; i++)
			{
				if (mountedPlayer.buffType[i] == _data.buff || (_type == 6 && mountedPlayer.buffType[i] == _data.extraBuff))
				{
					return;
				}
			}
			Dismount(mountedPlayer);
		}

		public void Dismount(Player mountedPlayer)
		{
			if (!_active)
			{
				return;
			}
			_active = false;
			mountedPlayer.ClearBuff(_data.buff);
			if (_type == 6)
			{
				mountedPlayer.ClearBuff(_data.extraBuff);
				mountedPlayer.cartFlip = false;
				mountedPlayer.fullRotation = 0f;
				mountedPlayer.fullRotationOrigin = Vector2.Zero;
				mountedPlayer.lastBoost = Vector2.Zero;
			}
			if (Main.netMode != 2)
			{
				for (int i = 0; i < 100; i++)
				{
					if (_type == 6)
					{
						if (i % 10 == 0)
						{
							int type = Main.rand.Next(61, 64);
							int num = Gore.NewGore(new Vector2(mountedPlayer.position.X - 20f, mountedPlayer.position.Y), Vector2.Zero, type);
							Main.gore[num].alpha = 100;
							Main.gore[num].velocity = Vector2.Transform(new Vector2(1f, 0f), Matrix.CreateRotationZ((float)(Main.rand.NextDouble() * 6.2831854820251465)));
						}
						continue;
					}
					int num2 = Dust.NewDust(new Vector2(mountedPlayer.position.X - 20f, mountedPlayer.position.Y), mountedPlayer.width + 40, mountedPlayer.height, _data.spawnDust);
					Main.dust[num2].scale += (float)Main.rand.Next(-10, 21) * 0.01f;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num2].scale *= 1.3f;
						Main.dust[num2].noGravity = true;
					}
					else
					{
						Main.dust[num2].velocity *= 0.5f;
					}
					Main.dust[num2].velocity += mountedPlayer.velocity * 0.8f;
				}
			}
			Reset();
			mountedPlayer.position.Y += mountedPlayer.height;
			mountedPlayer.height = 42;
			mountedPlayer.position.Y -= mountedPlayer.height;
			if (mountedPlayer.whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(13, -1, -1, "", mountedPlayer.whoAmi);
			}
		}

		public void SetMount(int m, Player mountedPlayer, bool faceLeft = false)
		{
			if (_type == m)
			{
				return;
			}
			switch (m)
			{
			default:
				return;
			case 5:
				if (mountedPlayer.wet)
				{
					return;
				}
				break;
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 6:
				break;
			}
			if (_active)
			{
				mountedPlayer.ClearBuff(_data.buff);
				if (_type == 6)
				{
					mountedPlayer.ClearBuff(_data.extraBuff);
					mountedPlayer.cartFlip = false;
					mountedPlayer.fullRotation = 0f;
					mountedPlayer.fullRotationOrigin = Vector2.Zero;
					mountedPlayer.lastBoost = Vector2.Zero;
				}
			}
			else
			{
				_active = true;
			}
			_flyTime = 0;
			_type = m;
			_data = mounts[m];
			_fatigueMax = _data.fatigueMax;
			if (_type == 6 && !faceLeft)
			{
				mountedPlayer.AddBuff(_data.extraBuff, 3600);
				_flipDraw = true;
			}
			else
			{
				mountedPlayer.AddBuff(_data.buff, 3600);
				_flipDraw = false;
			}
			mountedPlayer.position.Y += mountedPlayer.height;
			mountedPlayer.height = 42 + _data.heightBoost;
			mountedPlayer.position.Y -= mountedPlayer.height;
			if (Main.netMode != 2)
			{
				for (int i = 0; i < 100; i++)
				{
					if (_type == 6)
					{
						if (i % 10 == 0)
						{
							int type = Main.rand.Next(61, 64);
							int num = Gore.NewGore(new Vector2(mountedPlayer.position.X - 20f, mountedPlayer.position.Y), Vector2.Zero, type);
							Main.gore[num].alpha = 100;
							Main.gore[num].velocity = Vector2.Transform(new Vector2(1f, 0f), Matrix.CreateRotationZ((float)(Main.rand.NextDouble() * 6.2831854820251465)));
						}
						continue;
					}
					int num2 = Dust.NewDust(new Vector2(mountedPlayer.position.X - 20f, mountedPlayer.position.Y), mountedPlayer.width + 40, mountedPlayer.height, _data.spawnDust);
					Main.dust[num2].scale += (float)Main.rand.Next(-10, 21) * 0.01f;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num2].scale *= 1.3f;
						Main.dust[num2].noGravity = true;
					}
					else
					{
						Main.dust[num2].velocity *= 0.5f;
					}
					Main.dust[num2].velocity += mountedPlayer.velocity * 0.8f;
				}
			}
			if (mountedPlayer.whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(13, -1, -1, "", mountedPlayer.whoAmi);
			}
		}
	}
}
