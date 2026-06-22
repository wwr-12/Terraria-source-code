using System;
using Microsoft.Xna.Framework;

namespace Terraria
{
	public static class Minecart
	{
		private enum TrackState
		{
			NoTrack = -1,
			AboveTrack,
			OnTrack,
			BelowTrack,
			AboveFront,
			AboveBack,
			OnFront,
			OnBack
		}

		private const int totalFrames = 36;

		public const int leftDownDecoration = 36;

		public const int rightDownDecoration = 37;

		public const int bouncyBumperDecoration = 38;

		public const int regularBumperDecoration = 39;

		public const int Flag_OnTrack = 0;

		public const int Flag_BouncyBumper = 1;

		public const int Flag_UsedRamp = 2;

		public const int Flag_HitSwitch = 3;

		public const int Flag_BoostLeft = 4;

		public const int Flag_BoostRight = 5;

		public const int NoTrack = 0;

		public const int TopTrack = 1;

		public const int BottomTrack = 2;

		private const int NoConnection = -1;

		private const int TopConnection = 0;

		private const int MiddleConnection = 1;

		private const int BottomConnection = 2;

		private const int bumperEnd = -1;

		private const int bouncyEnd = -2;

		private const int rampEnd = -3;

		private const int openEnd = -4;

		public const float boosterSpeed = 4f;

		private const int Type_Normal = 0;

		private const int Type_Pressure = 1;

		private const int Type_Booster = 2;

		private static Vector2 trackMagnetOffset = new Vector2(25f, 26f);

		private static float minecartTextureWidth = 50f;

		private static int[] leftSideConnection;

		private static int[] rightSideConnection;

		private static int[] trackType;

		private static bool[] boostLeft;

		private static Vector2[] texturePosition;

		private static short firstPressureFrame;

		private static short firstLeftBoostFrame;

		private static short firstRightBoostFrame;

		public static int[][] trackSwitchOptions;

		public static int[][] tileHeight;

		public static void Initialize()
		{
			if ((float)Main.minecartMountTexture.Width != minecartTextureWidth)
			{
				throw new Exception("Be sure to update Minecart.textureWidth to match the actual texture size of " + Main.minecartMountTexture.Width + ".");
			}
			rightSideConnection = new int[36];
			leftSideConnection = new int[36];
			trackType = new int[36];
			boostLeft = new bool[36];
			texturePosition = new Vector2[40];
			tileHeight = new int[36][];
			for (int i = 0; i < 36; i++)
			{
				int[] array = new int[8];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = 5;
				}
				tileHeight[i] = array;
			}
			int num = 0;
			leftSideConnection[num] = -1;
			rightSideConnection[num] = -1;
			tileHeight[num][0] = -4;
			tileHeight[num][7] = -4;
			texturePosition[num] = new Vector2(0f, 0f);
			num++;
			leftSideConnection[num] = 1;
			rightSideConnection[num] = 1;
			texturePosition[num] = new Vector2(1f, 0f);
			num++;
			leftSideConnection[num] = -1;
			rightSideConnection[num] = 1;
			for (int k = 0; k < 4; k++)
			{
				tileHeight[num][k] = -1;
			}
			texturePosition[num] = new Vector2(2f, 1f);
			num++;
			leftSideConnection[num] = 1;
			rightSideConnection[num] = -1;
			for (int l = 4; l < 8; l++)
			{
				tileHeight[num][l] = -1;
			}
			texturePosition[num] = new Vector2(3f, 1f);
			num++;
			leftSideConnection[num] = 2;
			rightSideConnection[num] = 1;
			tileHeight[num][0] = 1;
			tileHeight[num][1] = 2;
			tileHeight[num][2] = 3;
			tileHeight[num][3] = 3;
			tileHeight[num][4] = 4;
			tileHeight[num][5] = 4;
			texturePosition[num] = new Vector2(0f, 2f);
			num++;
			leftSideConnection[num] = 1;
			rightSideConnection[num] = 2;
			tileHeight[num][2] = 4;
			tileHeight[num][3] = 4;
			tileHeight[num][4] = 3;
			tileHeight[num][5] = 3;
			tileHeight[num][6] = 2;
			tileHeight[num][7] = 1;
			texturePosition[num] = new Vector2(1f, 2f);
			num++;
			leftSideConnection[num] = 1;
			rightSideConnection[num] = 0;
			tileHeight[num][4] = 6;
			tileHeight[num][5] = 6;
			tileHeight[num][6] = 7;
			tileHeight[num][7] = 8;
			texturePosition[num] = new Vector2(0f, 1f);
			num++;
			leftSideConnection[num] = 0;
			rightSideConnection[num] = 1;
			tileHeight[num][0] = 8;
			tileHeight[num][1] = 7;
			tileHeight[num][2] = 6;
			tileHeight[num][3] = 6;
			texturePosition[num] = new Vector2(1f, 1f);
			num++;
			leftSideConnection[num] = 0;
			rightSideConnection[num] = 2;
			for (int m = 0; m < 8; m++)
			{
				tileHeight[num][m] = 8 - m;
			}
			texturePosition[num] = new Vector2(0f, 3f);
			num++;
			leftSideConnection[num] = 2;
			rightSideConnection[num] = 0;
			for (int n = 0; n < 8; n++)
			{
				tileHeight[num][n] = n + 1;
			}
			texturePosition[num] = new Vector2(1f, 3f);
			num++;
			leftSideConnection[num] = 2;
			rightSideConnection[num] = -1;
			tileHeight[num][0] = 1;
			tileHeight[num][1] = 2;
			for (int num2 = 2; num2 < 8; num2++)
			{
				tileHeight[num][num2] = -1;
			}
			texturePosition[num] = new Vector2(4f, 1f);
			num++;
			leftSideConnection[num] = -1;
			rightSideConnection[num] = 2;
			tileHeight[num][6] = 2;
			tileHeight[num][7] = 1;
			for (int num3 = 0; num3 < 6; num3++)
			{
				tileHeight[num][num3] = -1;
			}
			texturePosition[num] = new Vector2(5f, 1f);
			num++;
			leftSideConnection[num] = 0;
			rightSideConnection[num] = -1;
			tileHeight[num][0] = 8;
			tileHeight[num][1] = 7;
			tileHeight[num][2] = 6;
			for (int num4 = 3; num4 < 8; num4++)
			{
				tileHeight[num][num4] = -1;
			}
			texturePosition[num] = new Vector2(6f, 1f);
			num++;
			leftSideConnection[num] = -1;
			rightSideConnection[num] = 0;
			tileHeight[num][5] = 6;
			tileHeight[num][6] = 7;
			tileHeight[num][7] = 8;
			for (int num5 = 0; num5 < 5; num5++)
			{
				tileHeight[num][num5] = -1;
			}
			texturePosition[num] = new Vector2(7f, 1f);
			num++;
			leftSideConnection[num] = -1;
			rightSideConnection[num] = 1;
			tileHeight[num][0] = -4;
			texturePosition[num] = new Vector2(2f, 0f);
			num++;
			leftSideConnection[num] = 1;
			rightSideConnection[num] = -1;
			tileHeight[num][7] = -4;
			texturePosition[num] = new Vector2(3f, 0f);
			num++;
			leftSideConnection[num] = 2;
			rightSideConnection[num] = -1;
			for (int num6 = 0; num6 < 6; num6++)
			{
				tileHeight[num][num6] = num6 + 1;
			}
			tileHeight[num][6] = -3;
			tileHeight[num][7] = -3;
			texturePosition[num] = new Vector2(4f, 0f);
			num++;
			leftSideConnection[num] = -1;
			rightSideConnection[num] = 2;
			tileHeight[num][0] = -3;
			tileHeight[num][1] = -3;
			for (int num7 = 2; num7 < 8; num7++)
			{
				tileHeight[num][num7] = 8 - num7;
			}
			texturePosition[num] = new Vector2(5f, 0f);
			num++;
			leftSideConnection[num] = 0;
			rightSideConnection[num] = -1;
			for (int num8 = 0; num8 < 6; num8++)
			{
				tileHeight[num][num8] = 8 - num8;
			}
			tileHeight[num][6] = -3;
			tileHeight[num][7] = -3;
			texturePosition[num] = new Vector2(6f, 0f);
			num++;
			leftSideConnection[num] = -1;
			rightSideConnection[num] = 0;
			tileHeight[num][0] = -3;
			tileHeight[num][1] = -3;
			for (int num9 = 2; num9 < 8; num9++)
			{
				tileHeight[num][num9] = num9 + 1;
			}
			texturePosition[num] = new Vector2(7f, 0f);
			num++;
			leftSideConnection[num] = -1;
			rightSideConnection[num] = -1;
			tileHeight[num][0] = -4;
			tileHeight[num][7] = -4;
			trackType[num] = 1;
			texturePosition[num] = new Vector2(0f, 4f);
			num++;
			leftSideConnection[num] = 1;
			rightSideConnection[num] = 1;
			trackType[num] = 1;
			texturePosition[num] = new Vector2(1f, 4f);
			num++;
			leftSideConnection[num] = -1;
			rightSideConnection[num] = 1;
			tileHeight[num][0] = -4;
			trackType[num] = 1;
			texturePosition[num] = new Vector2(0f, 5f);
			num++;
			leftSideConnection[num] = 1;
			rightSideConnection[num] = -1;
			tileHeight[num][7] = -4;
			trackType[num] = 1;
			texturePosition[num] = new Vector2(1f, 5f);
			num++;
			leftSideConnection[num] = -1;
			rightSideConnection[num] = 1;
			for (int num10 = 0; num10 < 6; num10++)
			{
				tileHeight[num][num10] = -2;
			}
			texturePosition[num] = new Vector2(2f, 2f);
			num++;
			leftSideConnection[num] = 1;
			rightSideConnection[num] = -1;
			for (int num11 = 2; num11 < 8; num11++)
			{
				tileHeight[num][num11] = -2;
			}
			texturePosition[num] = new Vector2(3f, 2f);
			num++;
			leftSideConnection[num] = 2;
			rightSideConnection[num] = -1;
			tileHeight[num][0] = 1;
			tileHeight[num][1] = 2;
			for (int num12 = 2; num12 < 8; num12++)
			{
				tileHeight[num][num12] = -2;
			}
			texturePosition[num] = new Vector2(4f, 2f);
			num++;
			leftSideConnection[num] = -1;
			rightSideConnection[num] = 2;
			tileHeight[num][6] = 2;
			tileHeight[num][7] = 1;
			for (int num13 = 0; num13 < 6; num13++)
			{
				tileHeight[num][num13] = -2;
			}
			texturePosition[num] = new Vector2(5f, 2f);
			num++;
			leftSideConnection[num] = 0;
			rightSideConnection[num] = -1;
			tileHeight[num][0] = 8;
			tileHeight[num][1] = 7;
			tileHeight[num][2] = 6;
			for (int num14 = 3; num14 < 8; num14++)
			{
				tileHeight[num][num14] = -2;
			}
			texturePosition[num] = new Vector2(6f, 2f);
			num++;
			leftSideConnection[num] = -1;
			rightSideConnection[num] = 0;
			tileHeight[num][5] = 6;
			tileHeight[num][6] = 7;
			tileHeight[num][7] = 8;
			for (int num15 = 0; num15 < 5; num15++)
			{
				tileHeight[num][num15] = -2;
			}
			texturePosition[num] = new Vector2(7f, 2f);
			num++;
			leftSideConnection[num] = 1;
			rightSideConnection[num] = 1;
			trackType[num] = 2;
			boostLeft[num] = false;
			texturePosition[num] = new Vector2(2f, 3f);
			num++;
			leftSideConnection[num] = 1;
			rightSideConnection[num] = 1;
			trackType[num] = 2;
			boostLeft[num] = true;
			texturePosition[num] = new Vector2(3f, 3f);
			num++;
			leftSideConnection[num] = 0;
			rightSideConnection[num] = 2;
			for (int num16 = 0; num16 < 8; num16++)
			{
				tileHeight[num][num16] = 8 - num16;
			}
			trackType[num] = 2;
			boostLeft[num] = false;
			texturePosition[num] = new Vector2(4f, 3f);
			num++;
			leftSideConnection[num] = 2;
			rightSideConnection[num] = 0;
			for (int num17 = 0; num17 < 8; num17++)
			{
				tileHeight[num][num17] = num17 + 1;
			}
			trackType[num] = 2;
			boostLeft[num] = true;
			texturePosition[num] = new Vector2(5f, 3f);
			num++;
			leftSideConnection[num] = 0;
			rightSideConnection[num] = 2;
			for (int num18 = 0; num18 < 8; num18++)
			{
				tileHeight[num][num18] = 8 - num18;
			}
			trackType[num] = 2;
			boostLeft[num] = true;
			texturePosition[num] = new Vector2(6f, 3f);
			num++;
			leftSideConnection[num] = 2;
			rightSideConnection[num] = 0;
			for (int num19 = 0; num19 < 8; num19++)
			{
				tileHeight[num][num19] = num19 + 1;
			}
			trackType[num] = 2;
			boostLeft[num] = false;
			texturePosition[num] = new Vector2(7f, 3f);
			num++;
			texturePosition[36] = new Vector2(0f, 6f);
			texturePosition[37] = new Vector2(1f, 6f);
			texturePosition[39] = new Vector2(0f, 7f);
			texturePosition[38] = new Vector2(1f, 7f);
			for (int num20 = 0; num20 < texturePosition.Length; num20++)
			{
				texturePosition[num20] *= 18f;
			}
			for (int num21 = 0; num21 < tileHeight.Length; num21++)
			{
				int[] array2 = tileHeight[num21];
				for (int num22 = 0; num22 < array2.Length; num22++)
				{
					if (array2[num22] >= 0)
					{
						array2[num22] = (8 - array2[num22]) * 2;
					}
				}
			}
			int num23 = 64;
			int[] array3 = new int[36];
			trackSwitchOptions = new int[num23][];
			for (int num24 = 0; num24 < num23; num24++)
			{
				int num25 = 0;
				for (int num26 = 1; num26 < 256; num26 <<= 1)
				{
					if ((num24 & num26) == num26)
					{
						num25++;
					}
				}
				int num27 = 0;
				for (int num28 = 0; num28 < 36; num28++)
				{
					array3[num28] = -1;
					int num29 = 0;
					switch (leftSideConnection[num28])
					{
					case 0:
						num29 |= 1;
						break;
					case 1:
						num29 |= 2;
						break;
					case 2:
						num29 |= 4;
						break;
					}
					switch (rightSideConnection[num28])
					{
					case 0:
						num29 |= 8;
						break;
					case 1:
						num29 |= 0x10;
						break;
					case 2:
						num29 |= 0x20;
						break;
					}
					if (num25 < 2)
					{
						if (num24 != num29)
						{
							continue;
						}
					}
					else if (num29 == 0 || (num24 & num29) != num29)
					{
						continue;
					}
					array3[num28] = num28;
					num27++;
				}
				if (num27 == 0)
				{
					continue;
				}
				int[] array4 = new int[num27];
				int num30 = 0;
				for (int num31 = 0; num31 < 36; num31++)
				{
					if (array3[num31] != -1)
					{
						array4[num30] = array3[num31];
						num30++;
					}
				}
				trackSwitchOptions[num24] = array4;
			}
			firstPressureFrame = -1;
			firstLeftBoostFrame = -1;
			firstRightBoostFrame = -1;
			for (int num32 = 0; num32 < trackType.Length; num32++)
			{
				switch (trackType[num32])
				{
				case 1:
					if (firstPressureFrame == -1)
					{
						firstPressureFrame = (short)num32;
					}
					break;
				case 2:
					if (boostLeft[num32])
					{
						if (firstLeftBoostFrame == -1)
						{
							firstLeftBoostFrame = (short)num32;
						}
					}
					else if (firstRightBoostFrame == -1)
					{
						firstRightBoostFrame = (short)num32;
					}
					break;
				}
			}
		}

		public static BitsByte TrackCollision(ref Vector2 Position, ref Vector2 Velocity, ref Vector2 lastBoost, int Width, int Height, bool followDown, bool followUp, int fallStart, bool trackOnly)
		{
			if (followDown && followUp)
			{
				followDown = false;
				followUp = false;
			}
			Vector2 vector = new Vector2((float)(Width / 2) - minecartTextureWidth / 2f, Height / 2);
			Vector2 vector2 = Position + new Vector2((float)(Width / 2) - minecartTextureWidth / 2f, Height / 2);
			Vector2 vector3 = vector2 + trackMagnetOffset;
			Vector2 vector4 = Velocity;
			float num = vector4.Length();
			vector4.Normalize();
			Vector2 vector5 = vector3;
			Vector2 vector8 = Position + Velocity;
			Tile tile = null;
			bool flag = false;
			bool flag2 = true;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			TrackState trackState = TrackState.NoTrack;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			Vector2 vector6 = Vector2.Zero;
			Vector2 vector7 = Vector2.Zero;
			BitsByte result = default(BitsByte);
			Vector2 zero = Vector2.Zero;
			float num5 = 0f;
			while (true)
			{
				int num6 = (int)(vector5.X / 16f);
				int num7 = (int)(vector5.Y / 16f);
				int num8 = (int)vector5.X % 16 / 2;
				if (flag2)
				{
					num4 = num8;
				}
				bool flag7 = ((num8 != num4) ? true : false);
				if ((trackState == TrackState.OnBack || trackState == TrackState.OnTrack || trackState == TrackState.OnFront) && num6 != num2)
				{
					int num9 = ((trackState != TrackState.OnBack) ? tile.FrontTrack() : tile.BackTrack());
					switch ((!(vector4.X < 0f)) ? rightSideConnection[num9] : leftSideConnection[num9])
					{
					case 0:
						num7--;
						vector5.Y -= 2f;
						break;
					case 2:
						num7++;
						vector5.Y += 2f;
						break;
					}
				}
				TrackState trackState2 = TrackState.NoTrack;
				bool flag8 = false;
				if (num6 != num2 || num7 != num3)
				{
					if (flag2)
					{
						flag2 = false;
					}
					else
					{
						flag8 = true;
					}
					tile = Main.tile[num6, num7];
					if (tile == null)
					{
						tile = new Tile();
						Main.tile[num6, num7] = tile;
					}
					flag = ((tile.nactive() && tile.type == 314) ? true : false);
				}
				if (flag)
				{
					TrackState trackState3 = TrackState.NoTrack;
					int num10 = tile.FrontTrack();
					int num11 = tile.BackTrack();
					int num12 = tileHeight[num10][num8];
					switch (num12)
					{
					case -4:
						if (trackState == TrackState.OnFront)
						{
							if (trackOnly)
							{
								vector5 -= vector7;
								num = 0f;
								trackState2 = TrackState.OnFront;
								trackState3 = TrackState.NoTrack;
								flag6 = true;
							}
							else
							{
								trackState2 = TrackState.NoTrack;
								trackState3 = TrackState.NoTrack;
								flag5 = true;
							}
						}
						break;
					case -1:
						if (trackState == TrackState.OnFront)
						{
							vector5 -= vector7;
							num = 0f;
							trackState2 = TrackState.OnFront;
							trackState3 = TrackState.NoTrack;
							flag6 = true;
						}
						else
						{
							TrackState trackState4 = TrackState.NoTrack;
							trackState3 = TrackState.NoTrack;
						}
						break;
					case -2:
						if (trackState == TrackState.OnFront)
						{
							if (trackOnly)
							{
								vector5 -= vector7;
								num = 0f;
								trackState2 = TrackState.OnFront;
								trackState3 = TrackState.NoTrack;
								flag6 = true;
								break;
							}
							if (vector4.X < 0f)
							{
								float num15 = (float)(num6 * 16 + (num8 + 1) * 2) - vector5.X;
								vector5.X += num15;
								num += num15 / vector4.X;
							}
							vector4.X = 0f - vector4.X;
							result[1] = true;
							trackState2 = TrackState.OnFront;
							trackState3 = TrackState.NoTrack;
						}
						else
						{
							TrackState trackState4 = TrackState.NoTrack;
							trackState3 = TrackState.NoTrack;
						}
						break;
					case -3:
					{
						TrackState trackState4 = TrackState.NoTrack;
						trackState3 = TrackState.NoTrack;
						if (trackState == TrackState.OnFront)
						{
							trackState = TrackState.NoTrack;
							vector6 = Vector2.Transform(matrix: (Velocity.X > 0f) ? ((leftSideConnection[num10] != 2) ? Matrix.CreateRotationZ((float)Math.PI / 4f) : Matrix.CreateRotationZ(-(float)Math.PI / 4f)) : ((rightSideConnection[num10] != 2) ? Matrix.CreateRotationZ(-(float)Math.PI / 4f) : Matrix.CreateRotationZ((float)Math.PI / 4f)), position: new Vector2(Velocity.X, 0f));
							vector6.X = Velocity.X;
							flag4 = true;
							num = 0f;
						}
						break;
					}
					default:
					{
						float num13 = num7 * 16 + num12;
						if (num6 != num2 && trackState == TrackState.NoTrack && vector5.Y > num13 && vector5.Y - num13 < 2f)
						{
							flag8 = false;
							trackState = TrackState.AboveFront;
						}
						TrackState trackState4 = ((!(vector5.Y < num13)) ? ((!(vector5.Y > num13)) ? TrackState.OnTrack : TrackState.BelowTrack) : TrackState.AboveTrack);
						if (num11 != -1)
						{
							float num14 = num7 * 16 + tileHeight[num11][num8];
							trackState3 = ((!(vector5.Y < num14)) ? ((!(vector5.Y > num14)) ? TrackState.OnTrack : TrackState.BelowTrack) : TrackState.AboveTrack);
						}
						switch (trackState4)
						{
						case TrackState.OnTrack:
							trackState2 = ((trackState3 == TrackState.OnTrack) ? TrackState.OnTrack : TrackState.OnFront);
							break;
						case TrackState.AboveTrack:
							switch (trackState3)
							{
							case TrackState.OnTrack:
								trackState2 = TrackState.OnBack;
								break;
							case TrackState.BelowTrack:
								trackState2 = TrackState.AboveFront;
								break;
							case TrackState.AboveTrack:
								trackState2 = TrackState.AboveTrack;
								break;
							default:
								trackState2 = TrackState.AboveFront;
								break;
							}
							break;
						case TrackState.BelowTrack:
							switch (trackState3)
							{
							case TrackState.OnTrack:
								trackState2 = TrackState.OnBack;
								break;
							case TrackState.AboveTrack:
								trackState2 = TrackState.AboveBack;
								break;
							case TrackState.BelowTrack:
								trackState2 = TrackState.BelowTrack;
								break;
							default:
								trackState2 = TrackState.BelowTrack;
								break;
							}
							break;
						}
						break;
					}
					}
				}
				if (!flag8)
				{
					if (trackState != trackState2)
					{
						bool flag9 = false;
						if (flag7 || vector4.Y > 0f)
						{
							switch (trackState)
							{
							case TrackState.AboveTrack:
								switch (trackState2)
								{
								case TrackState.AboveFront:
									trackState2 = TrackState.OnBack;
									break;
								case TrackState.AboveBack:
									trackState2 = TrackState.OnFront;
									break;
								case TrackState.AboveTrack:
									trackState2 = TrackState.OnTrack;
									break;
								}
								break;
							case TrackState.AboveFront:
							{
								TrackState trackState5 = trackState2;
								if (trackState5 == TrackState.BelowTrack)
								{
									trackState2 = TrackState.OnFront;
								}
								break;
							}
							case TrackState.AboveBack:
							{
								TrackState trackState6 = trackState2;
								if (trackState6 == TrackState.BelowTrack)
								{
									trackState2 = TrackState.OnBack;
								}
								break;
							}
							case TrackState.OnFront:
								trackState2 = TrackState.OnFront;
								flag9 = true;
								break;
							case TrackState.OnBack:
								trackState2 = TrackState.OnBack;
								flag9 = true;
								break;
							case TrackState.OnTrack:
							{
								int num16 = tileHeight[tile.FrontTrack()][num8];
								int num17 = tileHeight[tile.BackTrack()][num8];
								trackState2 = (followDown ? ((num16 >= num17) ? TrackState.OnFront : TrackState.OnBack) : ((!followUp) ? TrackState.OnFront : ((num16 >= num17) ? TrackState.OnBack : TrackState.OnFront)));
								flag9 = true;
								break;
							}
							}
							int num18 = -1;
							switch (trackState2)
							{
							case TrackState.OnTrack:
							case TrackState.OnFront:
								num18 = tile.FrontTrack();
								break;
							case TrackState.OnBack:
								num18 = tile.BackTrack();
								break;
							}
							if (num18 != -1)
							{
								if (!flag9 && Velocity.Y > Player.defaultGravity)
								{
									int num19 = (int)(Position.Y / 16f);
									if (fallStart < num19 - 1)
									{
										Main.PlaySound(2, (int)Position.X + Width / 2, (int)Position.Y + Height / 2, 53);
										WheelSparks(Position, Width, Height, 10);
									}
								}
								if (trackState == TrackState.AboveFront && trackType[num18] == 1)
								{
									flag3 = true;
								}
								vector4.Y = 0f;
								vector5.Y = num7 * 16 + tileHeight[num18][num8];
							}
						}
					}
				}
				else if (trackState2 == TrackState.OnFront || trackState2 == TrackState.OnBack || trackState2 == TrackState.OnTrack)
				{
					if (flag && trackType[tile.FrontTrack()] == 1)
					{
						flag3 = true;
					}
					vector4.Y = 0f;
				}
				if (trackState2 == TrackState.OnFront)
				{
					int num20 = tile.FrontTrack();
					if (trackType[num20] == 2 && lastBoost.X == 0f && lastBoost.Y == 0f)
					{
						lastBoost = new Vector2(num6, num7);
						if (boostLeft[num20])
						{
							result[4] = true;
						}
						else
						{
							result[5] = true;
						}
					}
				}
				num4 = num8;
				trackState = trackState2;
				num2 = num6;
				num3 = num7;
				if (num > 0f)
				{
					float num21 = vector5.X % 2f;
					float num22 = vector5.Y % 2f;
					float num23 = 3f;
					float num24 = 3f;
					if (vector4.X < 0f)
					{
						num23 = num21 + 0.125f;
					}
					else if (vector4.X > 0f)
					{
						num23 = 2f - num21;
					}
					if (vector4.Y < 0f)
					{
						num24 = num22 + 0.125f;
					}
					else if (vector4.Y > 0f)
					{
						num24 = 2f - num22;
					}
					if (num23 == 3f && num24 == 3f)
					{
						break;
					}
					float num25 = Math.Abs(num23 / vector4.X);
					float num26 = Math.Abs(num24 / vector4.Y);
					num5 = ((!(num25 < num26)) ? num26 : num25);
					if (num5 > num)
					{
						vector7 = vector4 * num;
						num = 0f;
					}
					else
					{
						vector7 = vector4 * num5;
						num -= num5;
					}
					vector5 += vector7;
					continue;
				}
				if (lastBoost.X != (float)num2 || lastBoost.Y != (float)num3)
				{
					lastBoost = Vector2.Zero;
				}
				break;
			}
			if (flag3)
			{
				result[3] = true;
			}
			if (flag5)
			{
				Velocity.X = vector5.X - vector3.X;
				Velocity.Y = Player.defaultGravity;
			}
			else if (flag4)
			{
				result[2] = true;
				Velocity = vector6;
			}
			else if (result[1])
			{
				Velocity.X = 0f - Velocity.X;
				Position.X = vector5.X - trackMagnetOffset.X - vector.X - Velocity.X;
				if (vector4.Y == 0f)
				{
					Velocity.Y = 0f;
				}
			}
			else
			{
				if (flag6)
				{
					Velocity.X = vector5.X - vector3.X;
				}
				if (vector4.Y == 0f)
				{
					Velocity.Y = 0f;
				}
			}
			Position.Y += vector5.Y - vector3.Y - Velocity.Y;
			Position.Y = (float)Math.Round(Position.Y, 2);
			switch (trackState)
			{
			case TrackState.OnTrack:
			case TrackState.OnFront:
			case TrackState.OnBack:
				result[0] = true;
				break;
			}
			return result;
		}

		public static bool FrameTrack(int i, int j, bool pound, bool mute = false)
		{
			int num = 0;
			Tile tile = Main.tile[i, j];
			if (tile == null)
			{
				tile = new Tile();
				Main.tile[i, j] = tile;
			}
			if (mute && tile.type != 314)
			{
				return false;
			}
			if (Main.tile[i - 1, j - 1] != null && Main.tile[i - 1, j - 1].type == 314)
			{
				num++;
			}
			if (Main.tile[i - 1, j] != null && Main.tile[i - 1, j].type == 314)
			{
				num += 2;
			}
			if (Main.tile[i - 1, j + 1] != null && Main.tile[i - 1, j + 1].type == 314)
			{
				num += 4;
			}
			if (Main.tile[i + 1, j - 1] != null && Main.tile[i + 1, j - 1].type == 314)
			{
				num += 8;
			}
			if (Main.tile[i + 1, j] != null && Main.tile[i + 1, j].type == 314)
			{
				num += 16;
			}
			if (Main.tile[i + 1, j + 1] != null && Main.tile[i + 1, j + 1].type == 314)
			{
				num += 32;
			}
			int num2 = tile.FrontTrack();
			int num3 = tile.BackTrack();
			if (trackType == null)
			{
				return false;
			}
			int num4 = ((num2 >= 0 && num2 < trackType.Length) ? trackType[num2] : 0);
			int num5 = -1;
			int num6 = -1;
			int[] array = trackSwitchOptions[num];
			if (array == null)
			{
				if (pound)
				{
					return false;
				}
				tile.FrontTrack(0);
				tile.BackTrack(-1);
				return false;
			}
			if (!pound)
			{
				int num7 = -1;
				int num8 = -1;
				bool flag = false;
				for (int k = 0; k < array.Length; k++)
				{
					int num9 = array[k];
					if (num3 == array[k])
					{
						num6 = k;
					}
					if (trackType[num9] != num4)
					{
						continue;
					}
					if (leftSideConnection[num9] == -1 || rightSideConnection[num9] == -1)
					{
						if (num2 == array[k])
						{
							num5 = k;
							flag = true;
						}
						if (num7 == -1)
						{
							num7 = k;
						}
					}
					else
					{
						if (num2 == array[k])
						{
							num5 = k;
							flag = false;
						}
						if (num8 == -1)
						{
							num8 = k;
						}
					}
				}
				if (num8 != -1)
				{
					if (num5 == -1 || flag)
					{
						num5 = num8;
					}
				}
				else
				{
					if (num5 == -1)
					{
						switch (num4)
						{
						case 2:
							return false;
						case 1:
							return false;
						}
						num5 = num7;
					}
					num6 = -1;
				}
			}
			else
			{
				for (int l = 0; l < array.Length; l++)
				{
					if (num2 == array[l])
					{
						num5 = l;
					}
					if (num3 == array[l])
					{
						num6 = l;
					}
				}
				int num10 = 0;
				int num11 = 0;
				for (int m = 0; m < array.Length; m++)
				{
					if (trackType[array[m]] == num4)
					{
						if (leftSideConnection[array[m]] == -1 || rightSideConnection[array[m]] == -1)
						{
							num11++;
						}
						else
						{
							num10++;
						}
					}
				}
				if (num10 < 2 && num11 < 2)
				{
					return false;
				}
				bool flag2 = false;
				if (num10 == 0)
				{
					flag2 = true;
				}
				bool flag3 = false;
				if (!flag2)
				{
					while (!flag3)
					{
						num6++;
						if (num6 >= array.Length)
						{
							num6 = -1;
							break;
						}
						if ((leftSideConnection[array[num6]] != leftSideConnection[array[num5]] || rightSideConnection[array[num6]] != rightSideConnection[array[num5]]) && trackType[array[num6]] == num4 && leftSideConnection[array[num6]] != -1 && rightSideConnection[array[num6]] != -1)
						{
							flag3 = true;
						}
					}
				}
				while (!flag3)
				{
					num5++;
					if (num5 >= array.Length)
					{
						num5 = -1;
						do
						{
							num5++;
						}
						while (trackType[array[num5]] != num4 || (leftSideConnection[array[num5]] == -1 || rightSideConnection[array[num5]] == -1) != flag2);
						break;
					}
					if (trackType[array[num5]] == num4 && (leftSideConnection[array[num5]] == -1 || rightSideConnection[array[num5]] == -1) == flag2)
					{
						flag3 = true;
						break;
					}
				}
			}
			bool flag4 = false;
			switch (num5)
			{
			case -2:
				if (tile.FrontTrack() != firstPressureFrame)
				{
					flag4 = true;
				}
				break;
			case -1:
				if (tile.FrontTrack() != 0)
				{
					flag4 = true;
				}
				break;
			default:
				if (tile.FrontTrack() != array[num5])
				{
					flag4 = true;
				}
				break;
			}
			if (num6 == -1)
			{
				if (tile.BackTrack() != -1)
				{
					flag4 = true;
				}
			}
			else if (tile.BackTrack() != array[num6])
			{
				flag4 = true;
			}
			switch (num5)
			{
			case -2:
				tile.FrontTrack(firstPressureFrame);
				break;
			case -1:
				tile.FrontTrack(0);
				break;
			default:
				tile.FrontTrack((short)array[num5]);
				break;
			}
			if (num6 == -1)
			{
				tile.BackTrack(-1);
			}
			else
			{
				tile.BackTrack((short)array[num6]);
			}
			if (pound && flag4 && !mute)
			{
				WorldGen.KillTile(i, j, true);
			}
			return true;
		}

		public static bool GetOnTrack(int tileX, int tileY, ref Vector2 Position, int Width, int Height)
		{
			Tile tile = Main.tile[tileX, tileY];
			if (tile.type != 314)
			{
				return false;
			}
			Vector2 vector = new Vector2((float)(Width / 2) - minecartTextureWidth / 2f, Height / 2);
			Vector2 vector2 = Position + vector;
			Vector2 vector3 = vector2 + trackMagnetOffset;
			int num = (int)vector3.X % 16 / 2;
			int num2 = -1;
			int num3 = 0;
			for (int i = num; i < 8; i++)
			{
				num3 = tileHeight[tile.frameX][i];
				if (num3 >= 0)
				{
					num2 = i;
					break;
				}
			}
			if (num2 == -1)
			{
				for (int j = num - 1; j >= 0; j++)
				{
					num3 = tileHeight[tile.frameX][j];
					if (num3 >= 0)
					{
						num2 = j;
						break;
					}
				}
			}
			if (num2 == -1)
			{
				return false;
			}
			vector3.X = tileX * 16 + num2 * 2;
			vector3.Y = tileY * 16 + num3;
			vector3 -= trackMagnetOffset;
			vector3 -= vector;
			Position = vector3;
			return true;
		}

		public static bool OnTrack(Vector2 Position, int Width, int Height)
		{
			Vector2 vector = Position + new Vector2((float)(Width / 2) - minecartTextureWidth / 2f, Height / 2);
			Vector2 vector2 = vector + trackMagnetOffset;
			int num = (int)(vector2.X / 16f);
			int num2 = (int)(vector2.Y / 16f);
			return Main.tile[num, num2].type == 314;
		}

		public static float TrackRotation(ref float rotation, Vector2 Position, int Width, int Height, bool followDown, bool followUp)
		{
			Vector2 Position2 = Position;
			Vector2 Position3 = Position;
			Vector2 lastBoost = Vector2.Zero;
			Vector2 Velocity = new Vector2(-12f, 0f);
			TrackCollision(ref Position2, ref Velocity, ref lastBoost, Width, Height, followDown, followUp, 0, true);
			Position2 += Velocity;
			Velocity = new Vector2(12f, 0f);
			TrackCollision(ref Position3, ref Velocity, ref lastBoost, Width, Height, followDown, followUp, 0, true);
			Position3 += Velocity;
			float num = Position3.Y - Position2.Y;
			float num2 = Position3.X - Position2.X;
			float num3 = num / num2;
			float num4 = Position2.Y + (Position.X - Position2.X) * num3;
			float num5 = (Position.X - (float)(int)Position.X) * num3;
			rotation = (float)Math.Atan2(num, num2);
			return num4 - Position.Y + num5;
		}

		public static void HitTrackSwitch(Vector2 Position, int Width, int Height)
		{
			new Vector2((float)(Width / 2) - minecartTextureWidth / 2f, Height / 2);
			Vector2 vector = Position + new Vector2((float)(Width / 2) - minecartTextureWidth / 2f, Height / 2);
			Vector2 vector2 = vector + trackMagnetOffset;
			int num = (int)(vector2.X / 16f);
			int num2 = (int)(vector2.Y / 16f);
			Wiring.hitSwitch(num, num2);
			NetMessage.SendData(59, -1, -1, "", num, num2);
		}

		public static void FlipSwitchTrack(int i, int j)
		{
			Tile tileTrack = Main.tile[i, j];
			short num = tileTrack.FrontTrack();
			if (num == -1)
			{
				return;
			}
			switch (trackType[num])
			{
			case 0:
				if (tileTrack.BackTrack() != -1)
				{
					tileTrack.FrontTrack(tileTrack.BackTrack());
					tileTrack.BackTrack(num);
					NetMessage.SendTileSquare(-1, i, j, 1);
				}
				break;
			case 2:
				FrameTrack(i, j, true, true);
				break;
			case 1:
				break;
			}
		}

		public static void TrackColors(int i, int j, Tile trackTile, out int frontColor, out int backColor)
		{
			if (trackTile.type == 314)
			{
				frontColor = trackTile.color();
				backColor = frontColor;
				if (trackTile.frameY == -1)
				{
					return;
				}
				int num = leftSideConnection[trackTile.frameX];
				int num2 = rightSideConnection[trackTile.frameX];
				int num3 = leftSideConnection[trackTile.frameY];
				int num4 = rightSideConnection[trackTile.frameY];
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				for (int k = 0; k < 4; k++)
				{
					int num9;
					switch (k)
					{
					default:
						num9 = num;
						break;
					case 1:
						num9 = num2;
						break;
					case 2:
						num9 = num3;
						break;
					case 3:
						num9 = num4;
						break;
					}
					int num10;
					switch (num9)
					{
					case 0:
						num10 = -1;
						break;
					case 1:
						num10 = 0;
						break;
					case 2:
						num10 = 1;
						break;
					default:
						num10 = 0;
						break;
					}
					Tile tile = ((k % 2 != 0) ? Main.tile[i + 1, j + num10] : Main.tile[i - 1, j + num10]);
					int num11 = ((tile != null && tile.active() && tile.type == 314) ? tile.color() : 0);
					switch (k)
					{
					default:
						num5 = num11;
						break;
					case 1:
						num6 = num11;
						break;
					case 2:
						num7 = num11;
						break;
					case 3:
						num8 = num11;
						break;
					}
				}
				if (num == num3)
				{
					if (num6 != 0)
					{
						frontColor = num6;
					}
					else if (num5 != 0)
					{
						frontColor = num5;
					}
					if (num8 != 0)
					{
						backColor = num8;
					}
					else if (num7 != 0)
					{
						backColor = num7;
					}
					return;
				}
				if (num2 == num4)
				{
					if (num5 != 0)
					{
						frontColor = num5;
					}
					else if (num6 != 0)
					{
						frontColor = num6;
					}
					if (num7 != 0)
					{
						backColor = num7;
					}
					else if (num8 != 0)
					{
						backColor = num8;
					}
					return;
				}
				if (num6 == 0)
				{
					if (num5 != 0)
					{
						frontColor = num5;
					}
				}
				else if (num5 != 0)
				{
					if (num2 <= num)
					{
						frontColor = num6;
					}
					else
					{
						frontColor = num5;
					}
				}
				if (num8 == 0)
				{
					if (num7 != 0)
					{
						backColor = num7;
					}
				}
				else if (num7 != 0)
				{
					if (num4 <= num3)
					{
						backColor = num8;
					}
					else
					{
						backColor = num7;
					}
				}
			}
			else
			{
				frontColor = 0;
				backColor = 0;
			}
		}

		public static bool DrawLeftDecoration(int frameID)
		{
			if (frameID < 0 || frameID >= 36)
			{
				return false;
			}
			return leftSideConnection[frameID] == 2;
		}

		public static bool DrawRightDecoration(int frameID)
		{
			if (frameID < 0 || frameID >= 36)
			{
				return false;
			}
			return rightSideConnection[frameID] == 2;
		}

		public static bool DrawBumper(int frameID)
		{
			if (frameID < 0 || frameID >= 36)
			{
				return false;
			}
			if (tileHeight[frameID][0] != -1)
			{
				return tileHeight[frameID][7] == -1;
			}
			return true;
		}

		public static bool DrawBouncyBumper(int frameID)
		{
			if (frameID < 0 || frameID >= 36)
			{
				return false;
			}
			if (tileHeight[frameID][0] != -2)
			{
				return tileHeight[frameID][7] == -2;
			}
			return true;
		}

		public static void PlaceTrack(Tile trackCache, int style)
		{
			trackCache.active(true);
			trackCache.type = 314;
			trackCache.frameY = -1;
			switch (style)
			{
			case 0:
				trackCache.frameX = -1;
				break;
			case 1:
				trackCache.frameX = firstPressureFrame;
				break;
			case 2:
				trackCache.frameX = firstLeftBoostFrame;
				break;
			case 3:
				trackCache.frameX = firstRightBoostFrame;
				break;
			}
		}

		public static int GetTrackItem(Tile trackCache)
		{
			switch (trackType[trackCache.frameX])
			{
			case 0:
				return 2340;
			case 1:
				return 2492;
			case 2:
				return 2739;
			default:
				return 0;
			}
		}

		public static Rectangle GetSourceRect(int frameID, int animationFrame = 0)
		{
			if (frameID < 0 || frameID >= 40)
			{
				return new Rectangle(0, 0, 0, 0);
			}
			Vector2 vector = texturePosition[frameID];
			Rectangle result = new Rectangle((int)vector.X, (int)vector.Y, 16, 16);
			if (frameID < 36 && trackType[frameID] == 2)
			{
				result.Y += 18 * animationFrame;
			}
			return result;
		}

		public static void WheelSparks(Vector2 Position, int Width, int Height, int sparkCount)
		{
			Vector2 vector = new Vector2((float)(Width / 2) - minecartTextureWidth / 2f, Height / 2);
			Vector2 vector2 = Position + vector;
			Vector2 vector3 = vector2 + trackMagnetOffset;
			for (int i = 0; i < sparkCount; i++)
			{
				Vector2 position = new Vector2(vector3.X, vector3.Y);
				if (Main.rand.Next(2) == 0)
				{
					position.X += 13f;
				}
				else
				{
					position.X -= 13f;
				}
				int num = Dust.NewDust(position, 1, 1, 213, Main.rand.Next(-2, 3), Main.rand.Next(-2, 3));
				Main.dust[num].noGravity = true;
				Main.dust[num].fadeIn = Main.dust[num].scale + 1f + 0.01f * (float)Main.rand.Next(0, 51);
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity *= (float)Main.rand.Next(15, 51) * 0.01f;
				Main.dust[num].velocity.X *= (float)Main.rand.Next(25, 101) * 0.01f;
				Main.dust[num].velocity.Y -= (float)Main.rand.Next(15, 31) * 0.1f;
				Main.dust[num].position.Y -= 4f;
				if (Main.rand.Next(3) != 0)
				{
					Main.dust[num].noGravity = false;
				}
				else
				{
					Main.dust[num].scale *= 0.6f;
				}
			}
		}

		public static short FrontTrack(this Tile tileTrack)
		{
			return tileTrack.frameX;
		}

		public static void FrontTrack(this Tile tileTrack, short trackID)
		{
			tileTrack.frameX = trackID;
		}

		public static short BackTrack(this Tile tileTrack)
		{
			return tileTrack.frameY;
		}

		public static void BackTrack(this Tile tileTrack, short trackID)
		{
			tileTrack.frameY = trackID;
		}
	}
}
