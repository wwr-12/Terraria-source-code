using System;
using Microsoft.Xna.Framework;

namespace Terraria
{
	public class Projectile
	{
		public int numHits;

		public bool bobber;

		public bool netImportant;

		public bool noDropItem;

		public bool wet;

		public bool honeyWet;

		public byte wetCount;

		public bool lavaWet;

		public int whoAmI;

		public static int maxAI = 2;

		public Vector2 position;

		public Vector2 lastPosition;

		public Vector2 velocity;

		public Vector2 lastVelocity;

		public int width;

		public int height;

		public float scale = 1f;

		public float rotation;

		public int type;

		public int alpha;

		public int owner = 255;

		public bool active;

		public string name = "";

		public float[] ai = new float[maxAI];

		public float[] localAI = new float[maxAI];

		public float gfxOffY;

		public float stepSpeed = 1f;

		public int aiStyle;

		public int timeLeft;

		public int soundDelay;

		public int damage;

		public int direction;

		public int spriteDirection = 1;

		public bool hostile;

		public float knockBack;

		public bool friendly;

		public int penetrate = 1;

		public int maxPenetrate = 1;

		public int identity;

		public float light;

		public bool netUpdate;

		public bool netUpdate2;

		public int netSpam;

		public Vector2[] oldPos = new Vector2[10];

		public bool minion;

		public float minionSlots;

		public int minionPos;

		public int restrikeDelay;

		public bool tileCollide;

		public int maxUpdates;

		public int numUpdates;

		public bool ignoreWater;

		public bool hide;

		public bool ownerHitCheck;

		public int[] playerImmune = new int[255];

		public string miscText = "";

		public bool melee;

		public bool ranged;

		public bool magic;

		public bool coldDamage;

		public bool noEnchantments;

		public int frameCounter;

		public int frame;

		public void SetDefaults(int Type)
		{
			bobber = false;
			numHits = 0;
			netImportant = false;
			for (int i = 0; i < oldPos.Length; i++)
			{
				oldPos[i].X = 0f;
				oldPos[i].Y = 0f;
			}
			for (int j = 0; j < maxAI; j++)
			{
				ai[j] = 0f;
				localAI[j] = 0f;
			}
			for (int k = 0; k < 255; k++)
			{
				playerImmune[k] = 0;
			}
			noDropItem = false;
			minion = false;
			minionSlots = 0f;
			soundDelay = 0;
			spriteDirection = 1;
			melee = false;
			ranged = false;
			magic = false;
			ownerHitCheck = false;
			hide = false;
			lavaWet = false;
			wetCount = 0;
			wet = false;
			ignoreWater = false;
			hostile = false;
			netUpdate = false;
			netUpdate2 = false;
			netSpam = 0;
			numUpdates = 0;
			maxUpdates = 0;
			identity = 0;
			restrikeDelay = 0;
			light = 0f;
			penetrate = 1;
			tileCollide = true;
			position = Vector2.Zero;
			velocity = Vector2.Zero;
			aiStyle = 0;
			alpha = 0;
			type = Type;
			active = true;
			rotation = 0f;
			scale = 1f;
			owner = 255;
			timeLeft = 3600;
			name = "";
			friendly = false;
			damage = 0;
			knockBack = 0f;
			miscText = "";
			coldDamage = false;
			noEnchantments = false;
			if (type == 1)
			{
				name = "Wooden Arrow";
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				ranged = true;
			}
			else if (type == 2)
			{
				name = "Fire Arrow";
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				light = 1f;
				ranged = true;
			}
			else if (type == 3)
			{
				name = "Shuriken";
				width = 22;
				height = 22;
				aiStyle = 2;
				friendly = true;
				penetrate = 4;
				ranged = true;
			}
			else if (type == 4)
			{
				name = "Unholy Arrow";
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				light = 0.35f;
				penetrate = 5;
				ranged = true;
			}
			else if (type == 5)
			{
				name = "Jester's Arrow";
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				light = 0.4f;
				penetrate = -1;
				timeLeft = 120;
				alpha = 100;
				ignoreWater = true;
				ranged = true;
				maxUpdates = 1;
			}
			else if (type == 6)
			{
				name = "Enchanted Boomerang";
				width = 22;
				height = 22;
				aiStyle = 3;
				friendly = true;
				penetrate = -1;
				melee = true;
				light = 0.4f;
			}
			else if (type == 7 || type == 8)
			{
				name = "Vilethorn";
				width = 28;
				height = 28;
				aiStyle = 4;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				alpha = 255;
				ignoreWater = true;
				magic = true;
			}
			else if (type == 9)
			{
				name = "Starfury";
				width = 24;
				height = 24;
				aiStyle = 5;
				friendly = true;
				penetrate = 2;
				alpha = 50;
				scale = 0.8f;
				tileCollide = false;
				melee = true;
			}
			else if (type == 10)
			{
				name = "Purification Powder";
				width = 64;
				height = 64;
				aiStyle = 6;
				friendly = true;
				tileCollide = false;
				penetrate = -1;
				alpha = 255;
				ignoreWater = true;
			}
			else if (type == 11)
			{
				name = "Vile Powder";
				width = 48;
				height = 48;
				aiStyle = 6;
				friendly = true;
				tileCollide = false;
				penetrate = -1;
				alpha = 255;
				ignoreWater = true;
			}
			else if (type == 12)
			{
				name = "Falling Star";
				width = 16;
				height = 16;
				aiStyle = 5;
				friendly = true;
				penetrate = -1;
				alpha = 50;
				light = 1f;
			}
			else if (type == 13)
			{
				netImportant = true;
				name = "Hook";
				width = 18;
				height = 18;
				aiStyle = 7;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				timeLeft *= 10;
			}
			else if (type == 14)
			{
				name = "Bullet";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 1;
				light = 0.5f;
				alpha = 255;
				maxUpdates = 1;
				scale = 1.2f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 15)
			{
				name = "Ball of Fire";
				width = 16;
				height = 16;
				aiStyle = 8;
				friendly = true;
				light = 0.8f;
				alpha = 100;
				magic = true;
			}
			else if (type == 16)
			{
				name = "Magic Missile";
				width = 10;
				height = 10;
				aiStyle = 9;
				friendly = true;
				light = 0.8f;
				alpha = 100;
				magic = true;
			}
			else if (type == 17)
			{
				name = "Dirt Ball";
				width = 10;
				height = 10;
				aiStyle = 10;
				friendly = true;
				ignoreWater = true;
			}
			else if (type == 18)
			{
				netImportant = true;
				name = "Shadow Orb";
				width = 32;
				height = 32;
				aiStyle = 11;
				friendly = true;
				light = 0.9f;
				alpha = 150;
				tileCollide = false;
				penetrate = -1;
				timeLeft *= 5;
				ignoreWater = true;
				scale = 0.8f;
			}
			else if (type == 19)
			{
				name = "Flamarang";
				width = 22;
				height = 22;
				aiStyle = 3;
				friendly = true;
				penetrate = -1;
				light = 1f;
				melee = true;
			}
			else if (type == 20)
			{
				name = "Green Laser";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 3;
				light = 0.75f;
				alpha = 255;
				maxUpdates = 2;
				scale = 1.4f;
				timeLeft = 600;
				magic = true;
			}
			else if (type == 21)
			{
				name = "Bone";
				width = 16;
				height = 16;
				aiStyle = 2;
				scale = 1.2f;
				friendly = true;
				ranged = true;
			}
			else if (type == 22)
			{
				name = "Water Stream";
				width = 18;
				height = 18;
				aiStyle = 12;
				friendly = true;
				alpha = 255;
				penetrate = -1;
				maxUpdates = 2;
				ignoreWater = true;
				magic = true;
			}
			else if (type == 23)
			{
				name = "Harpoon";
				width = 4;
				height = 4;
				aiStyle = 13;
				friendly = true;
				penetrate = -1;
				alpha = 255;
				ranged = true;
			}
			else if (type == 24)
			{
				name = "Spiky Ball";
				width = 14;
				height = 14;
				aiStyle = 14;
				friendly = true;
				penetrate = 6;
				ranged = true;
			}
			else if (type == 25)
			{
				name = "Ball 'O Hurt";
				width = 22;
				height = 22;
				aiStyle = 15;
				friendly = true;
				penetrate = -1;
				melee = true;
				scale = 0.8f;
			}
			else if (type == 26)
			{
				name = "Blue Moon";
				width = 22;
				height = 22;
				aiStyle = 15;
				friendly = true;
				penetrate = -1;
				melee = true;
				scale = 0.8f;
			}
			else if (type == 27)
			{
				name = "Water Bolt";
				width = 16;
				height = 16;
				aiStyle = 8;
				friendly = true;
				alpha = 255;
				timeLeft /= 2;
				penetrate = 10;
				magic = true;
			}
			else if (type == 28)
			{
				name = "Bomb";
				width = 22;
				height = 22;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
			}
			else if (type == 29)
			{
				name = "Dynamite";
				width = 10;
				height = 10;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
			}
			else if (type == 30)
			{
				name = "Grenade";
				width = 14;
				height = 14;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 31)
			{
				name = "Sand Ball";
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				friendly = true;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 32)
			{
				name = "Ivy Whip";
				width = 18;
				height = 18;
				aiStyle = 7;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				timeLeft *= 10;
			}
			else if (type == 33)
			{
				name = "Thorn Chakram";
				width = 38;
				height = 38;
				aiStyle = 3;
				friendly = true;
				scale = 0.9f;
				penetrate = -1;
				melee = true;
			}
			else if (type == 34)
			{
				name = "Flamelash";
				width = 14;
				height = 14;
				aiStyle = 9;
				friendly = true;
				light = 0.8f;
				alpha = 100;
				penetrate = 1;
				magic = true;
			}
			else if (type == 35)
			{
				name = "Sunfury";
				width = 22;
				height = 22;
				aiStyle = 15;
				friendly = true;
				penetrate = -1;
				melee = true;
				scale = 0.8f;
			}
			else if (type == 36)
			{
				name = "Meteor Shot";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 2;
				light = 0.6f;
				alpha = 255;
				maxUpdates = 1;
				scale = 1.4f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 37)
			{
				name = "Sticky Bomb";
				width = 22;
				height = 22;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
			}
			else if (type == 38)
			{
				name = "Harpy Feather";
				width = 14;
				height = 14;
				aiStyle = 0;
				hostile = true;
				penetrate = -1;
				aiStyle = 1;
				tileCollide = true;
			}
			else if (type == 39)
			{
				name = "Mud Ball";
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				friendly = true;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 40)
			{
				name = "Ash Ball";
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				friendly = true;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 41)
			{
				name = "Hellfire Arrow";
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				penetrate = -1;
				ranged = true;
				light = 0.3f;
			}
			else if (type == 42)
			{
				name = "Sand Ball";
				knockBack = 8f;
				width = 10;
				height = 10;
				aiStyle = 10;
				friendly = true;
				maxUpdates = 1;
			}
			else if (type == 43)
			{
				name = "Tombstone";
				knockBack = 12f;
				width = 24;
				height = 24;
				aiStyle = 17;
				penetrate = -1;
			}
			else if (type == 44)
			{
				name = "Demon Sickle";
				width = 48;
				height = 48;
				alpha = 100;
				light = 0.2f;
				aiStyle = 18;
				hostile = true;
				penetrate = -1;
				tileCollide = true;
				scale = 0.9f;
			}
			else if (type == 45)
			{
				name = "Demon Scythe";
				width = 48;
				height = 48;
				alpha = 100;
				light = 0.2f;
				aiStyle = 18;
				friendly = true;
				penetrate = 5;
				tileCollide = true;
				scale = 0.9f;
				magic = true;
			}
			else if (type == 46)
			{
				name = "Dark Lance";
				width = 20;
				height = 20;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				scale = 1.1f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 47)
			{
				name = "Trident";
				width = 18;
				height = 18;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				scale = 1.1f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 48)
			{
				name = "Throwing Knife";
				width = 12;
				height = 12;
				aiStyle = 2;
				friendly = true;
				penetrate = 2;
				ranged = true;
			}
			else if (type == 49)
			{
				name = "Spear";
				width = 18;
				height = 18;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				scale = 1.2f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 50)
			{
				netImportant = true;
				name = "Glowstick";
				width = 6;
				height = 6;
				aiStyle = 14;
				penetrate = -1;
				alpha = 75;
				light = 1f;
				timeLeft *= 5;
			}
			else if (type == 51)
			{
				name = "Seed";
				width = 8;
				height = 8;
				aiStyle = 1;
				friendly = true;
			}
			else if (type == 52)
			{
				name = "Wooden Boomerang";
				width = 22;
				height = 22;
				aiStyle = 3;
				friendly = true;
				penetrate = -1;
				melee = true;
			}
			else if (type == 53)
			{
				netImportant = true;
				name = "Sticky Glowstick";
				width = 6;
				height = 6;
				aiStyle = 14;
				penetrate = -1;
				alpha = 75;
				light = 1f;
				timeLeft *= 5;
				tileCollide = false;
			}
			else if (type == 54)
			{
				name = "Poisoned Knife";
				width = 12;
				height = 12;
				aiStyle = 2;
				friendly = true;
				penetrate = 2;
				ranged = true;
			}
			else if (type == 55)
			{
				name = "Stinger";
				width = 10;
				height = 10;
				aiStyle = 0;
				hostile = true;
				penetrate = -1;
				aiStyle = 1;
				tileCollide = true;
			}
			else if (type == 56)
			{
				name = "Ebonsand Ball";
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				friendly = true;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 57)
			{
				name = "Cobalt Chainsaw";
				width = 18;
				height = 18;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 58)
			{
				name = "Mythril Chainsaw";
				width = 18;
				height = 18;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 1.08f;
			}
			else if (type == 59)
			{
				name = "Cobalt Drill";
				width = 22;
				height = 22;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 0.9f;
			}
			else if (type == 60)
			{
				name = "Mythril Drill";
				width = 22;
				height = 22;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 0.9f;
			}
			else if (type == 61)
			{
				name = "Adamantite Chainsaw";
				width = 18;
				height = 18;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 1.16f;
			}
			else if (type == 62)
			{
				name = "Adamantite Drill";
				width = 22;
				height = 22;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 0.9f;
			}
			else if (type == 63)
			{
				name = "The Dao of Pow";
				width = 22;
				height = 22;
				aiStyle = 15;
				friendly = true;
				penetrate = -1;
				melee = true;
			}
			else if (type == 64)
			{
				name = "Mythril Halberd";
				width = 18;
				height = 18;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				scale = 1.25f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 65)
			{
				name = "Ebonsand Ball";
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				friendly = true;
				penetrate = -1;
				maxUpdates = 1;
			}
			else if (type == 66)
			{
				name = "Adamantite Glaive";
				width = 18;
				height = 18;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				scale = 1.27f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 67)
			{
				name = "Pearl Sand Ball";
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				friendly = true;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 68)
			{
				name = "Pearl Sand Ball";
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				friendly = true;
				penetrate = -1;
				maxUpdates = 1;
			}
			else if (type == 69)
			{
				name = "Holy Water";
				width = 14;
				height = 14;
				aiStyle = 2;
				friendly = true;
				penetrate = 1;
			}
			else if (type == 70)
			{
				name = "Unholy Water";
				width = 14;
				height = 14;
				aiStyle = 2;
				friendly = true;
				penetrate = 1;
			}
			else if (type == 71)
			{
				name = "Silt Ball";
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				friendly = true;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 72)
			{
				netImportant = true;
				name = "Blue Fairy";
				width = 18;
				height = 18;
				aiStyle = 11;
				friendly = true;
				light = 0.9f;
				tileCollide = false;
				penetrate = -1;
				timeLeft *= 5;
				ignoreWater = true;
				scale = 0.8f;
			}
			else if (type == 73 || type == 74)
			{
				netImportant = true;
				name = "Hook";
				width = 18;
				height = 18;
				aiStyle = 7;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				timeLeft *= 10;
				light = 0.4f;
			}
			else if (type == 75)
			{
				name = "Happy Bomb";
				width = 22;
				height = 22;
				aiStyle = 16;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 76 || type == 77 || type == 78)
			{
				if (type == 76)
				{
					width = 10;
					height = 22;
				}
				else if (type == 77)
				{
					width = 18;
					height = 24;
				}
				else
				{
					width = 22;
					height = 24;
				}
				name = "Note";
				aiStyle = 21;
				friendly = true;
				ranged = true;
				alpha = 100;
				light = 0.3f;
				penetrate = -1;
				timeLeft = 180;
				magic = true;
			}
			else if (type == 79)
			{
				name = "Rainbow";
				width = 10;
				height = 10;
				aiStyle = 9;
				friendly = true;
				light = 0.8f;
				alpha = 255;
				magic = true;
			}
			else if (type == 80)
			{
				name = "Ice Block";
				width = 16;
				height = 16;
				aiStyle = 22;
				friendly = true;
				magic = true;
				tileCollide = false;
				light = 0.5f;
				coldDamage = true;
			}
			else if (type == 81)
			{
				name = "Wooden Arrow";
				width = 10;
				height = 10;
				aiStyle = 1;
				hostile = true;
				ranged = true;
			}
			else if (type == 82)
			{
				name = "Flaming Arrow";
				width = 10;
				height = 10;
				aiStyle = 1;
				hostile = true;
				ranged = true;
			}
			else if (type == 83)
			{
				name = "Eye Laser";
				width = 4;
				height = 4;
				aiStyle = 1;
				hostile = true;
				penetrate = 3;
				light = 0.75f;
				alpha = 255;
				maxUpdates = 2;
				scale = 1.7f;
				timeLeft = 600;
				magic = true;
			}
			else if (type == 84)
			{
				name = "Pink Laser";
				width = 4;
				height = 4;
				aiStyle = 1;
				hostile = true;
				penetrate = 3;
				light = 0.75f;
				alpha = 255;
				maxUpdates = 2;
				scale = 1.2f;
				timeLeft = 600;
				magic = true;
			}
			else if (type == 85)
			{
				name = "Flames";
				width = 6;
				height = 6;
				aiStyle = 23;
				friendly = true;
				alpha = 255;
				penetrate = 3;
				maxUpdates = 2;
				ranged = true;
			}
			else if (type == 86)
			{
				netImportant = true;
				name = "Pink Fairy";
				width = 18;
				height = 18;
				aiStyle = 11;
				friendly = true;
				light = 0.9f;
				tileCollide = false;
				penetrate = -1;
				timeLeft *= 5;
				ignoreWater = true;
				scale = 0.8f;
			}
			else if (type == 87)
			{
				netImportant = true;
				name = "Pink Fairy";
				width = 18;
				height = 18;
				aiStyle = 11;
				friendly = true;
				light = 0.9f;
				tileCollide = false;
				penetrate = -1;
				timeLeft *= 5;
				ignoreWater = true;
				scale = 0.8f;
			}
			else if (type == 88)
			{
				name = "Purple Laser";
				width = 6;
				height = 6;
				aiStyle = 1;
				friendly = true;
				penetrate = 3;
				light = 0.75f;
				alpha = 255;
				maxUpdates = 4;
				scale = 1.4f;
				timeLeft = 600;
				magic = true;
			}
			else if (type == 89)
			{
				name = "Crystal Bullet";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 1;
				light = 0.5f;
				alpha = 255;
				maxUpdates = 1;
				scale = 1.2f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 90)
			{
				name = "Crystal Shard";
				width = 6;
				height = 6;
				aiStyle = 24;
				friendly = true;
				penetrate = 1;
				light = 0.5f;
				alpha = 50;
				scale = 1.2f;
				timeLeft = 600;
				ranged = true;
				tileCollide = false;
			}
			else if (type == 91)
			{
				name = "Holy Arrow";
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				ranged = true;
			}
			else if (type == 92)
			{
				name = "Hallow Star";
				width = 24;
				height = 24;
				aiStyle = 5;
				friendly = true;
				penetrate = 2;
				alpha = 50;
				scale = 0.8f;
				tileCollide = false;
				magic = true;
			}
			else if (type == 93)
			{
				light = 0.15f;
				name = "Magic Dagger";
				width = 12;
				height = 12;
				aiStyle = 2;
				friendly = true;
				penetrate = 2;
				magic = true;
			}
			else if (type == 94)
			{
				ignoreWater = true;
				name = "Crystal Storm";
				width = 8;
				height = 8;
				aiStyle = 24;
				friendly = true;
				light = 0.5f;
				alpha = 50;
				scale = 1.2f;
				timeLeft = 600;
				magic = true;
				tileCollide = true;
				penetrate = 1;
			}
			else if (type == 95)
			{
				name = "Cursed Flame";
				width = 16;
				height = 16;
				aiStyle = 8;
				friendly = true;
				light = 0.8f;
				alpha = 100;
				magic = true;
				penetrate = 2;
			}
			else if (type == 96)
			{
				name = "Cursed Flame";
				width = 16;
				height = 16;
				aiStyle = 8;
				hostile = true;
				light = 0.8f;
				alpha = 100;
				magic = true;
				penetrate = -1;
				scale = 0.9f;
				scale = 1.3f;
			}
			else if (type == 97)
			{
				name = "Cobalt Naginata";
				width = 18;
				height = 18;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				scale = 1.1f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 98)
			{
				name = "Poison Dart";
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				hostile = true;
				ranged = true;
				penetrate = -1;
			}
			else if (type == 99)
			{
				name = "Boulder";
				width = 31;
				height = 31;
				aiStyle = 25;
				friendly = true;
				hostile = true;
				ranged = true;
				penetrate = -1;
			}
			else if (type == 100)
			{
				name = "Death Laser";
				width = 4;
				height = 4;
				aiStyle = 1;
				hostile = true;
				penetrate = 3;
				light = 0.75f;
				alpha = 255;
				maxUpdates = 2;
				scale = 1.8f;
				timeLeft = 1200;
				magic = true;
			}
			else if (type == 101)
			{
				name = "Eye Fire";
				width = 6;
				height = 6;
				aiStyle = 23;
				hostile = true;
				alpha = 255;
				penetrate = -1;
				maxUpdates = 3;
				magic = true;
			}
			else if (type == 102)
			{
				name = "Bomb";
				width = 22;
				height = 22;
				aiStyle = 16;
				hostile = true;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 103)
			{
				name = "Cursed Arrow";
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				light = 1f;
				ranged = true;
			}
			else if (type == 104)
			{
				name = "Cursed Bullet";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 1;
				light = 0.5f;
				alpha = 255;
				maxUpdates = 1;
				scale = 1.2f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 105)
			{
				name = "Gungnir";
				width = 18;
				height = 18;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				scale = 1.3f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 106)
			{
				name = "Light Disc";
				width = 32;
				height = 32;
				aiStyle = 3;
				friendly = true;
				penetrate = -1;
				melee = true;
				light = 0.4f;
			}
			else if (type == 107)
			{
				name = "Hamdrax";
				width = 22;
				height = 22;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 1.1f;
			}
			else if (type == 108)
			{
				name = "Explosives";
				width = 260;
				height = 260;
				aiStyle = 16;
				friendly = true;
				hostile = true;
				penetrate = -1;
				tileCollide = false;
				alpha = 255;
				timeLeft = 2;
			}
			else if (type == 109)
			{
				name = "Snow Ball";
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				hostile = true;
				scale = 0.9f;
				penetrate = -1;
				coldDamage = true;
			}
			else if (type == 110)
			{
				name = "Bullet";
				width = 4;
				height = 4;
				aiStyle = 1;
				hostile = true;
				penetrate = -1;
				light = 0.5f;
				alpha = 255;
				maxUpdates = 1;
				scale = 1.2f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 111)
			{
				netImportant = true;
				name = "Bunny";
				width = 18;
				height = 18;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 112)
			{
				netImportant = true;
				name = "Penguin";
				width = 18;
				height = 18;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 113)
			{
				name = "Ice Boomerang";
				width = 22;
				height = 22;
				aiStyle = 3;
				friendly = true;
				penetrate = -1;
				melee = true;
				light = 0.4f;
				coldDamage = true;
			}
			else if (type == 114)
			{
				name = "Unholy Trident";
				width = 16;
				height = 16;
				aiStyle = 27;
				magic = true;
				penetrate = 3;
				light = 0.5f;
				alpha = 255;
				friendly = true;
			}
			else if (type == 115)
			{
				name = "Unholy Trident";
				width = 16;
				height = 16;
				aiStyle = 27;
				hostile = true;
				magic = true;
				penetrate = -1;
				light = 0.5f;
				alpha = 255;
			}
			else if (type == 116)
			{
				name = "Sword Beam";
				width = 16;
				height = 16;
				aiStyle = 27;
				melee = true;
				penetrate = 1;
				light = 0.5f;
				alpha = 255;
				friendly = true;
			}
			else if (type == 117)
			{
				name = "Bone Arrow";
				maxUpdates = 2;
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				ranged = true;
			}
			else if (type == 118)
			{
				name = "Ice Bolt";
				width = 10;
				height = 10;
				aiStyle = 28;
				alpha = 255;
				melee = true;
				penetrate = 1;
				friendly = true;
				coldDamage = true;
			}
			else if (type == 119)
			{
				name = "Frost Bolt";
				width = 14;
				height = 14;
				aiStyle = 28;
				alpha = 255;
				melee = true;
				penetrate = 2;
				friendly = true;
			}
			else if (type == 120)
			{
				name = "Frost Arrow";
				maxUpdates = 1;
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				ranged = true;
				coldDamage = true;
			}
			else if (type == 121)
			{
				name = "Amethyst Bolt";
				width = 10;
				height = 10;
				aiStyle = 29;
				alpha = 255;
				magic = true;
				penetrate = 1;
				friendly = true;
			}
			else if (type == 122)
			{
				name = "Topaz Bolt";
				width = 10;
				height = 10;
				aiStyle = 29;
				alpha = 255;
				magic = true;
				penetrate = 1;
				friendly = true;
			}
			else if (type == 123)
			{
				name = "Sapphire Bolt";
				width = 10;
				height = 10;
				aiStyle = 29;
				alpha = 255;
				magic = true;
				penetrate = 1;
				friendly = true;
			}
			else if (type == 124)
			{
				name = "Emerald Bolt";
				width = 10;
				height = 10;
				aiStyle = 29;
				alpha = 255;
				magic = true;
				penetrate = 2;
				friendly = true;
			}
			else if (type == 125)
			{
				name = "Ruby Bolt";
				width = 10;
				height = 10;
				aiStyle = 29;
				alpha = 255;
				magic = true;
				penetrate = 2;
				friendly = true;
			}
			else if (type == 126)
			{
				name = "Diamond Bolt";
				width = 10;
				height = 10;
				aiStyle = 29;
				alpha = 255;
				magic = true;
				penetrate = 2;
				friendly = true;
			}
			else if (type == 127)
			{
				netImportant = true;
				name = "Turtle";
				width = 22;
				height = 22;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 128)
			{
				name = "Frost Blast";
				width = 14;
				height = 14;
				aiStyle = 28;
				alpha = 255;
				penetrate = -1;
				friendly = false;
				hostile = true;
				coldDamage = true;
			}
			else if (type == 129)
			{
				name = "Rune Blast";
				width = 14;
				height = 14;
				aiStyle = 28;
				alpha = 255;
				penetrate = -1;
				friendly = false;
				hostile = true;
				tileCollide = false;
			}
			else if (type == 130)
			{
				name = "Mushroom Spear";
				width = 22;
				height = 22;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				scale = 1.2f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 131)
			{
				name = "Mushroom";
				width = 22;
				height = 22;
				aiStyle = 30;
				friendly = true;
				penetrate = 1;
				tileCollide = false;
				melee = true;
				light = 0.5f;
			}
			else if (type == 132)
			{
				name = "Terra Beam";
				width = 16;
				height = 16;
				aiStyle = 27;
				melee = true;
				penetrate = 3;
				light = 0.5f;
				alpha = 255;
				friendly = true;
			}
			else if (type == 133)
			{
				name = "Grenade";
				width = 14;
				height = 14;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 134)
			{
				name = "Rocket";
				width = 14;
				height = 14;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 135)
			{
				name = "Proximity Mine";
				width = 14;
				height = 14;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 136)
			{
				name = "Grenade";
				width = 14;
				height = 14;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 137)
			{
				name = "Rocket";
				width = 14;
				height = 14;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 138)
			{
				name = "Proximity Mine";
				width = 14;
				height = 14;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 139)
			{
				name = "Grenade";
				width = 14;
				height = 14;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 140)
			{
				name = "Rocket";
				width = 14;
				height = 14;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 141)
			{
				name = "Proximity Mine";
				width = 14;
				height = 14;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 142)
			{
				name = "Grenade";
				width = 14;
				height = 14;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 143)
			{
				name = "Rocket";
				width = 14;
				height = 14;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 144)
			{
				name = "Proximity Mine";
				width = 14;
				height = 14;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 145)
			{
				name = "Pure Spray";
				width = 6;
				height = 6;
				aiStyle = 31;
				friendly = true;
				alpha = 255;
				penetrate = -1;
				maxUpdates = 2;
				tileCollide = false;
				ignoreWater = true;
			}
			else if (type == 146)
			{
				name = "Hallow Spray";
				width = 6;
				height = 6;
				aiStyle = 31;
				friendly = true;
				alpha = 255;
				penetrate = -1;
				maxUpdates = 2;
				tileCollide = false;
				ignoreWater = true;
			}
			else if (type == 147)
			{
				name = "Corrupt Spray";
				width = 6;
				height = 6;
				aiStyle = 31;
				friendly = true;
				alpha = 255;
				penetrate = -1;
				maxUpdates = 2;
				tileCollide = false;
				ignoreWater = true;
			}
			else if (type == 148)
			{
				name = "Mushroom Spray";
				width = 6;
				height = 6;
				aiStyle = 31;
				friendly = true;
				alpha = 255;
				penetrate = -1;
				maxUpdates = 2;
				tileCollide = false;
				ignoreWater = true;
			}
			else if (type == 149)
			{
				name = "Crimson Spray";
				width = 6;
				height = 6;
				aiStyle = 31;
				friendly = true;
				alpha = 255;
				penetrate = -1;
				maxUpdates = 2;
				tileCollide = false;
				ignoreWater = true;
			}
			else if (type == 150 || type == 151 || type == 152)
			{
				name = "Nettle Burst";
				width = 28;
				height = 28;
				aiStyle = 4;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				alpha = 255;
				ignoreWater = true;
				magic = true;
			}
			else if (type == 153)
			{
				name = "The Rotted Fork";
				width = 18;
				height = 18;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				scale = 1.1f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 154)
			{
				name = "The Meatball";
				width = 22;
				height = 22;
				aiStyle = 15;
				friendly = true;
				penetrate = -1;
				melee = true;
				scale = 0.8f;
			}
			else if (type == 155)
			{
				netImportant = true;
				name = "Beach Ball";
				width = 44;
				height = 44;
				aiStyle = 32;
				friendly = true;
			}
			else if (type == 156)
			{
				name = "Light Beam";
				width = 16;
				height = 16;
				aiStyle = 27;
				melee = true;
				light = 0.5f;
				alpha = 255;
				friendly = true;
			}
			else if (type == 157)
			{
				name = "Night Beam";
				width = 32;
				height = 32;
				aiStyle = 27;
				melee = true;
				light = 0.5f;
				alpha = 255;
				friendly = true;
				scale = 1.2f;
			}
			else if (type == 158)
			{
				name = "Copper Coin";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 1;
				alpha = 255;
				maxUpdates = 1;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 159)
			{
				name = "Silver Coin";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 1;
				alpha = 255;
				maxUpdates = 1;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 160)
			{
				name = "Gold Coin";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 1;
				alpha = 255;
				maxUpdates = 1;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 161)
			{
				name = "Platinum Coin";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 1;
				alpha = 255;
				maxUpdates = 1;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 162)
			{
				name = "Cannonball";
				width = 16;
				height = 16;
				aiStyle = 2;
				friendly = true;
				penetrate = 4;
				alpha = 255;
			}
			else if (type == 163)
			{
				netImportant = true;
				name = "Flare";
				width = 6;
				height = 6;
				aiStyle = 33;
				friendly = true;
				penetrate = -1;
				alpha = 255;
				timeLeft = 36000;
			}
			else if (type == 164)
			{
				name = "Landmine";
				width = 128;
				height = 128;
				aiStyle = 16;
				friendly = true;
				hostile = true;
				penetrate = -1;
				tileCollide = false;
				alpha = 255;
				timeLeft = 2;
			}
			else if (type == 165)
			{
				netImportant = true;
				name = "Web";
				width = 12;
				height = 12;
				aiStyle = 7;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				timeLeft *= 10;
			}
			else if (type == 166)
			{
				name = "Snow Ball";
				width = 14;
				height = 14;
				aiStyle = 2;
				friendly = true;
				ranged = true;
				coldDamage = true;
			}
			else if (type == 167 || type == 168 || type == 169 || type == 170)
			{
				name = "Rocket";
				width = 14;
				height = 14;
				aiStyle = 34;
				friendly = true;
				ranged = true;
				timeLeft = 45;
			}
			else if (type == 171)
			{
				name = "Rope Coil";
				width = 14;
				height = 14;
				aiStyle = 35;
				penetrate = -1;
				tileCollide = false;
				timeLeft = 400;
			}
			else if (type == 172)
			{
				name = "Frostburn Arrow";
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				light = 1f;
				ranged = true;
				coldDamage = true;
			}
			else if (type == 173)
			{
				name = "Enchanted Beam";
				width = 16;
				height = 16;
				aiStyle = 27;
				melee = true;
				penetrate = 1;
				light = 0.2f;
				alpha = 255;
				friendly = true;
			}
			else if (type == 174)
			{
				name = "Ice Spike";
				alpha = 255;
				width = 6;
				height = 6;
				aiStyle = 1;
				hostile = true;
				penetrate = -1;
				coldDamage = true;
			}
			else if (type == 175)
			{
				name = "Baby Eater";
				width = 34;
				height = 34;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 176)
			{
				name = "Jungle Spike";
				alpha = 255;
				width = 6;
				height = 6;
				aiStyle = 1;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 177)
			{
				name = "Icewater Spit";
				width = 10;
				height = 10;
				aiStyle = 28;
				alpha = 255;
				penetrate = -1;
				friendly = false;
				hostile = true;
				coldDamage = true;
			}
			else if (type == 178)
			{
				name = "Confetti";
				width = 10;
				height = 10;
				aiStyle = 1;
				alpha = 255;
				penetrate = -1;
				timeLeft = 2;
			}
			else if (type == 179)
			{
				name = "Slush Ball";
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				friendly = true;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 180)
			{
				name = "Bullet";
				width = 4;
				height = 4;
				aiStyle = 1;
				hostile = true;
				penetrate = -1;
				light = 0.5f;
				alpha = 255;
				maxUpdates = 1;
				scale = 1.2f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 181)
			{
				name = "Bee";
				width = 8;
				height = 8;
				aiStyle = 36;
				friendly = true;
				penetrate = 3;
				alpha = 255;
				timeLeft = 600;
				magic = true;
				maxUpdates = 3;
			}
			else if (type == 182)
			{
				light = 0.15f;
				name = "Possessed Hatchet";
				width = 30;
				height = 30;
				aiStyle = 3;
				friendly = true;
				penetrate = 10;
				melee = true;
				maxUpdates = 1;
			}
			else if (type == 183)
			{
				name = "Beenade";
				width = 14;
				height = 22;
				aiStyle = 14;
				penetrate = 1;
				ranged = true;
				timeLeft = 180;
				friendly = true;
			}
			else if (type == 184)
			{
				name = "Poison Dart";
				width = 6;
				height = 6;
				aiStyle = 1;
				friendly = true;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 185)
			{
				name = "Spiky Ball";
				width = 14;
				height = 14;
				aiStyle = 14;
				friendly = true;
				hostile = true;
				penetrate = -1;
				timeLeft = 900;
			}
			else if (type == 186)
			{
				name = "Spear";
				width = 10;
				height = 14;
				aiStyle = 37;
				friendly = true;
				tileCollide = false;
				ignoreWater = true;
				hostile = true;
				penetrate = -1;
				ranged = true;
				timeLeft = 300;
			}
			else if (type == 187)
			{
				name = "Flamethrower";
				width = 6;
				height = 6;
				aiStyle = 38;
				alpha = 255;
				tileCollide = false;
				ignoreWater = true;
				timeLeft = 60;
			}
			else if (type == 188)
			{
				name = "Flames";
				width = 6;
				height = 6;
				aiStyle = 23;
				friendly = true;
				hostile = true;
				alpha = 255;
				penetrate = -1;
				maxUpdates = 2;
			}
			else if (type == 189)
			{
				name = "Wasp";
				width = 8;
				height = 8;
				aiStyle = 36;
				friendly = true;
				penetrate = 4;
				alpha = 255;
				timeLeft = 600;
				magic = true;
				maxUpdates = 3;
			}
			else if (type == 190)
			{
				name = "Mechanical Piranha";
				width = 22;
				height = 22;
				aiStyle = 39;
				friendly = true;
				penetrate = -1;
				alpha = 255;
				ranged = true;
			}
			else if (type >= 191 && type <= 194)
			{
				netImportant = true;
				name = "Pygmy";
				width = 18;
				height = 18;
				aiStyle = 26;
				penetrate = -1;
				timeLeft *= 5;
				minion = true;
				minionSlots = 1f;
				if (type == 192)
				{
					scale = 1.025f;
				}
				if (type == 193)
				{
					scale = 1.05f;
				}
				if (type == 194)
				{
					scale = 1.075f;
				}
			}
			else if (type == 195)
			{
				name = "Pygmy";
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
			}
			else if (type == 196)
			{
				name = "Smoke Bomb";
				width = 16;
				height = 16;
				aiStyle = 14;
				penetrate = -1;
				scale = 0.8f;
			}
			else if (type == 197)
			{
				netImportant = true;
				name = "Baby Skeletron Head";
				width = 42;
				height = 42;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 198)
			{
				netImportant = true;
				name = "Baby Hornet";
				width = 26;
				height = 26;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 199)
			{
				netImportant = true;
				name = "Tiki Spirit";
				width = 28;
				height = 28;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 200)
			{
				netImportant = true;
				name = "Pet Lizard";
				width = 28;
				height = 28;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 201)
			{
				name = "Tombstone";
				knockBack = 12f;
				width = 24;
				height = 24;
				aiStyle = 17;
				penetrate = -1;
			}
			else if (type == 202)
			{
				name = "Tombstone";
				knockBack = 12f;
				width = 24;
				height = 24;
				aiStyle = 17;
				penetrate = -1;
			}
			else if (type == 203)
			{
				name = "Tombstone";
				knockBack = 12f;
				width = 24;
				height = 24;
				aiStyle = 17;
				penetrate = -1;
			}
			else if (type == 204)
			{
				name = "Tombstone";
				knockBack = 12f;
				width = 24;
				height = 24;
				aiStyle = 17;
				penetrate = -1;
			}
			else if (type == 205)
			{
				name = "Tombstone";
				knockBack = 12f;
				width = 24;
				height = 24;
				aiStyle = 17;
				penetrate = -1;
			}
			else if (type == 206)
			{
				name = "Leaf";
				width = 14;
				height = 14;
				aiStyle = 40;
				friendly = true;
				penetrate = 1;
				alpha = 255;
				timeLeft = 600;
				magic = true;
			}
			else if (type == 207)
			{
				name = "Bullet";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 1;
				light = 0.5f;
				alpha = 255;
				maxUpdates = 2;
				scale = 1.2f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 208)
			{
				netImportant = true;
				name = "Parrot";
				width = 18;
				height = 36;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 209)
			{
				name = "Truffle";
				width = 12;
				height = 32;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
				light = 0.5f;
			}
			else if (type == 210)
			{
				netImportant = true;
				name = "Sapling";
				width = 14;
				height = 30;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 211)
			{
				netImportant = true;
				name = "Wisp";
				width = 24;
				height = 24;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
				light = 1f;
				ignoreWater = true;
			}
			else if (type == 212)
			{
				name = "Palladium Pike";
				width = 18;
				height = 18;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				scale = 1.12f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 213)
			{
				name = "Palladium Drill";
				width = 22;
				height = 22;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 0.92f;
			}
			else if (type == 214)
			{
				name = "Palladium Chainsaw";
				width = 18;
				height = 18;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 215)
			{
				name = "Orichalcum Halberd";
				width = 18;
				height = 18;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				scale = 1.27f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 216)
			{
				name = "Orichalcum Drill";
				width = 22;
				height = 22;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 0.93f;
			}
			else if (type == 217)
			{
				name = "Orichalcum Chainsaw";
				width = 18;
				height = 18;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 1.12f;
			}
			else if (type == 218)
			{
				name = "Titanium Trident";
				width = 18;
				height = 18;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				scale = 1.28f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 219)
			{
				name = "Titanium Drill";
				width = 22;
				height = 22;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 0.95f;
			}
			else if (type == 220)
			{
				name = "Titanium Chainsaw";
				width = 18;
				height = 18;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 1.2f;
			}
			else if (type == 221)
			{
				name = "Flower Petal";
				width = 20;
				height = 20;
				aiStyle = 41;
				friendly = true;
				tileCollide = false;
				ignoreWater = true;
				timeLeft = 120;
				penetrate = -1;
				scale = 1f + (float)Main.rand.Next(30) * 0.01f;
				maxUpdates = 2;
			}
			else if (type == 222)
			{
				name = "Chlorophyte Partisan";
				width = 18;
				height = 18;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				scale = 1.3f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 223)
			{
				name = "Chlorophyte Drill";
				width = 22;
				height = 22;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 1f;
			}
			else if (type == 224)
			{
				name = "Chlorophyte Chainsaw";
				width = 18;
				height = 18;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 1.1f;
			}
			else if (type == 225)
			{
				penetrate = 2;
				name = "Chlorophyte Arrow";
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				ranged = true;
			}
			else if (type == 226)
			{
				netImportant = true;
				name = "Crystal Leaf";
				width = 22;
				height = 42;
				aiStyle = 42;
				friendly = true;
				tileCollide = false;
				penetrate = -1;
				timeLeft *= 5;
				light = 0.4f;
				ignoreWater = true;
			}
			else if (type == 227)
			{
				netImportant = true;
				tileCollide = false;
				light = 0.1f;
				name = "Crystal Leaf";
				width = 14;
				height = 14;
				aiStyle = 43;
				friendly = true;
				penetrate = 1;
				timeLeft = 180;
			}
			else if (type == 228)
			{
				tileCollide = false;
				name = "Spore Cloud";
				width = 30;
				height = 30;
				aiStyle = 44;
				friendly = true;
				scale = 1.1f;
				penetrate = -1;
			}
			else if (type == 229)
			{
				name = "Chlorophyte Orb";
				width = 30;
				height = 30;
				aiStyle = 44;
				friendly = true;
				penetrate = -1;
				light = 0.2f;
			}
			else if (type >= 230 && type <= 235)
			{
				netImportant = true;
				name = "Gem Hook";
				width = 18;
				height = 18;
				aiStyle = 7;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				timeLeft *= 10;
			}
			else if (type == 236)
			{
				netImportant = true;
				name = "Baby Dino";
				width = 34;
				height = 34;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 237)
			{
				netImportant = true;
				name = "Rain Cloud";
				width = 28;
				height = 28;
				aiStyle = 45;
				penetrate = -1;
			}
			else if (type == 238)
			{
				tileCollide = false;
				ignoreWater = true;
				name = "Rain Cloud";
				width = 54;
				height = 28;
				aiStyle = 45;
				penetrate = -1;
			}
			else if (type == 239)
			{
				ignoreWater = true;
				name = "Rain";
				width = 4;
				height = 40;
				aiStyle = 45;
				friendly = true;
				penetrate = -1;
				maxUpdates = 1;
				timeLeft = 300;
				scale = 1.1f;
				magic = true;
			}
			else if (type == 240)
			{
				name = "Cannonball";
				width = 16;
				height = 16;
				aiStyle = 2;
				hostile = true;
				penetrate = -1;
				alpha = 255;
			}
			else if (type == 241)
			{
				name = "Crimsand Ball";
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				friendly = true;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 242)
			{
				name = "Bullet";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 1;
				light = 0.5f;
				alpha = 255;
				maxUpdates = 7;
				scale = 1.18f;
				timeLeft = 600;
				ranged = true;
				ignoreWater = true;
			}
			else if (type == 243)
			{
				name = "Blood Cloud";
				width = 28;
				height = 28;
				aiStyle = 45;
				penetrate = -1;
			}
			else if (type == 244)
			{
				tileCollide = false;
				ignoreWater = true;
				name = "Blood Cloud";
				width = 54;
				height = 28;
				aiStyle = 45;
				penetrate = -1;
			}
			else if (type == 245)
			{
				ignoreWater = true;
				name = "Blood Rain";
				width = 4;
				height = 40;
				aiStyle = 45;
				friendly = true;
				penetrate = 2;
				maxUpdates = 1;
				timeLeft = 300;
				scale = 1.1f;
				magic = true;
			}
			else if (type == 246)
			{
				name = "Stynger";
				maxUpdates = 1;
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				ranged = true;
				alpha = 255;
			}
			else if (type == 247)
			{
				name = "Flower Pow";
				width = 34;
				height = 34;
				aiStyle = 15;
				friendly = true;
				penetrate = -1;
				melee = true;
			}
			else if (type == 248)
			{
				name = "Flower Pow";
				width = 18;
				height = 18;
				aiStyle = 1;
				friendly = true;
				ranged = true;
			}
			else if (type == 249)
			{
				name = "Stynger";
				width = 12;
				height = 12;
				aiStyle = 2;
				friendly = true;
				ranged = true;
			}
			else if (type == 250)
			{
				name = "Rainbow";
				width = 12;
				height = 12;
				aiStyle = 46;
				penetrate = -1;
				magic = true;
				alpha = 255;
				ignoreWater = true;
				scale = 1.25f;
			}
			else if (type == 251)
			{
				name = "Rainbow";
				width = 14;
				height = 14;
				aiStyle = 46;
				friendly = true;
				penetrate = -1;
				magic = true;
				alpha = 255;
				light = 0.3f;
				tileCollide = false;
				ignoreWater = true;
				scale = 1.25f;
			}
			else if (type == 252)
			{
				name = "Chlorophyte Jackhammer";
				width = 18;
				height = 18;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				scale = 1.1f;
			}
			else if (type == 253)
			{
				name = "Ball of Frost";
				width = 16;
				height = 16;
				aiStyle = 8;
				friendly = true;
				light = 0.8f;
				alpha = 100;
				magic = true;
			}
			else if (type == 254)
			{
				name = "Magnet Sphere";
				width = 38;
				height = 38;
				aiStyle = 47;
				magic = true;
				timeLeft = 420;
				light = 0.5f;
			}
			else if (type == 255)
			{
				name = "Magnet Sphere";
				width = 8;
				height = 8;
				aiStyle = 48;
				friendly = true;
				magic = true;
				maxUpdates = 100;
				timeLeft = 100;
			}
			else if (type == 256)
			{
				netImportant = true;
				tileCollide = false;
				name = "Skeletron Hand";
				width = 6;
				height = 6;
				aiStyle = 7;
				friendly = true;
				penetrate = -1;
				scale = 1f;
				timeLeft *= 10;
			}
			else if (type == 257)
			{
				name = "Frost Beam";
				ignoreWater = true;
				width = 4;
				height = 4;
				aiStyle = 1;
				hostile = true;
				penetrate = -1;
				light = 0.75f;
				alpha = 255;
				maxUpdates = 1;
				scale = 1.2f;
				timeLeft = 600;
				magic = true;
				coldDamage = true;
			}
			else if (type == 258)
			{
				name = "Fireball";
				width = 16;
				height = 16;
				aiStyle = 8;
				hostile = true;
				penetrate = -1;
				alpha = 100;
				timeLeft = 300;
			}
			else if (type == 259)
			{
				name = "Eye Beam";
				ignoreWater = true;
				tileCollide = false;
				width = 8;
				height = 8;
				aiStyle = 1;
				hostile = true;
				penetrate = -1;
				light = 0.3f;
				scale = 1.1f;
				magic = true;
				maxUpdates = 1;
			}
			else if (type == 260)
			{
				name = "Heat Ray";
				width = 8;
				height = 8;
				aiStyle = 48;
				friendly = true;
				magic = true;
				maxUpdates = 100;
				timeLeft = 200;
				penetrate = -1;
			}
			else if (type == 261)
			{
				name = "Boulder";
				width = 32;
				height = 34;
				aiStyle = 14;
				friendly = true;
				penetrate = 6;
				magic = true;
				ignoreWater = true;
			}
			else if (type == 262)
			{
				name = "Golem Fist";
				width = 30;
				height = 30;
				aiStyle = 13;
				friendly = true;
				penetrate = -1;
				alpha = 255;
				melee = true;
				maxUpdates = 1;
			}
			else if (type == 263)
			{
				name = "Ice Sickle";
				width = 34;
				height = 34;
				alpha = 100;
				light = 0.5f;
				aiStyle = 18;
				friendly = true;
				penetrate = 5;
				tileCollide = true;
				scale = 1f;
				melee = true;
				timeLeft = 180;
				coldDamage = true;
			}
			else if (type == 264)
			{
				ignoreWater = true;
				name = "Rain";
				width = 4;
				height = 40;
				aiStyle = 45;
				hostile = true;
				penetrate = -1;
				maxUpdates = 1;
				timeLeft = 120;
				scale = 1.1f;
			}
			else if (type == 265)
			{
				name = "Poison Fang";
				width = 12;
				height = 12;
				aiStyle = 1;
				alpha = 255;
				friendly = true;
				magic = true;
				penetrate = 4;
			}
			else if (type == 266)
			{
				netImportant = true;
				alpha = 75;
				name = "Baby Slime";
				width = 24;
				height = 16;
				aiStyle = 26;
				penetrate = -1;
				timeLeft *= 5;
				minion = true;
				minionSlots = 1f;
			}
			else if (type == 267)
			{
				alpha = 255;
				name = "Poison Dart";
				width = 14;
				height = 14;
				aiStyle = 1;
				friendly = true;
			}
			else if (type == 268)
			{
				netImportant = true;
				name = "Eye Spring";
				width = 18;
				height = 32;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 269)
			{
				netImportant = true;
				name = "Baby Snowman";
				width = 20;
				height = 26;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 270)
			{
				name = "Skull";
				width = 26;
				height = 26;
				aiStyle = 1;
				alpha = 255;
				friendly = true;
				magic = true;
				penetrate = 3;
			}
			else if (type == 271)
			{
				name = "Boxing Glove";
				width = 20;
				height = 20;
				aiStyle = 13;
				friendly = true;
				penetrate = -1;
				alpha = 255;
				melee = true;
				scale = 1.2f;
			}
			else if (type == 272)
			{
				name = "Bananarang";
				width = 32;
				height = 32;
				aiStyle = 3;
				friendly = true;
				scale = 0.9f;
				penetrate = -1;
				melee = true;
			}
			else if (type == 273)
			{
				name = "Chain Knife";
				width = 26;
				height = 26;
				aiStyle = 13;
				friendly = true;
				penetrate = -1;
				alpha = 255;
				melee = true;
			}
			else if (type == 274)
			{
				name = "Death Sickle";
				width = 42;
				height = 42;
				alpha = 100;
				light = 0.5f;
				aiStyle = 18;
				friendly = true;
				penetrate = 5;
				tileCollide = false;
				scale = 1.1f;
				melee = true;
				timeLeft = 180;
			}
			else if (type == 275)
			{
				alpha = 255;
				name = "Seed";
				width = 14;
				height = 14;
				aiStyle = 1;
				hostile = true;
			}
			else if (type == 276)
			{
				alpha = 255;
				name = "Poison Seed";
				width = 14;
				height = 14;
				aiStyle = 1;
				hostile = true;
			}
			else if (type == 277)
			{
				alpha = 255;
				name = "Thorn Ball";
				width = 38;
				height = 38;
				aiStyle = 14;
				hostile = true;
			}
			else if (type == 278)
			{
				name = "Ichor Arrow";
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				light = 1f;
				ranged = true;
				maxUpdates = 1;
			}
			else if (type == 279)
			{
				name = "Ichor Bullet";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 1;
				light = 0.5f;
				alpha = 255;
				maxUpdates = 2;
				scale = 1.25f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 280)
			{
				name = "Golden Shower";
				width = 32;
				height = 32;
				aiStyle = 12;
				friendly = true;
				alpha = 255;
				penetrate = 5;
				maxUpdates = 2;
				ignoreWater = true;
				magic = true;
			}
			else if (type == 281)
			{
				name = "Explosive Bunny";
				width = 28;
				height = 28;
				aiStyle = 49;
				friendly = true;
				penetrate = 1;
				alpha = 255;
				timeLeft = 600;
			}
			else if (type == 282)
			{
				name = "Venom Arrow";
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				ranged = true;
				maxUpdates = 1;
			}
			else if (type == 283)
			{
				name = "Venom Bullet";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 1;
				light = 0.5f;
				alpha = 255;
				maxUpdates = 2;
				scale = 1.25f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 284)
			{
				name = "Party Bullet";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 1;
				light = 0.5f;
				alpha = 255;
				maxUpdates = 2;
				scale = 1.3f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 285)
			{
				name = "Nano Bullet";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 1;
				light = 0.5f;
				alpha = 255;
				maxUpdates = 2;
				scale = 1.3f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 286)
			{
				name = "Explosive Bullet";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 1;
				light = 0.5f;
				alpha = 255;
				maxUpdates = 2;
				scale = 1.3f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 287)
			{
				name = "Golden Bullet";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 1;
				light = 0.5f;
				alpha = 255;
				maxUpdates = 2;
				scale = 1.3f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 288)
			{
				name = "Golden Shower";
				width = 32;
				height = 32;
				aiStyle = 12;
				hostile = true;
				alpha = 255;
				penetrate = -1;
				maxUpdates = 2;
				ignoreWater = true;
				magic = true;
			}
			else if (type == 289)
			{
				name = "Confetti";
				width = 10;
				height = 10;
				aiStyle = 1;
				alpha = 255;
				penetrate = -1;
				timeLeft = 2;
			}
			else if (type == 290)
			{
				name = "Shadow Beam";
				width = 4;
				height = 4;
				aiStyle = 48;
				hostile = true;
				magic = true;
				maxUpdates = 100;
				timeLeft = 100;
				penetrate = -1;
			}
			else if (type == 291)
			{
				name = "Inferno";
				width = 12;
				height = 12;
				aiStyle = 50;
				hostile = true;
				alpha = 255;
				magic = true;
				tileCollide = false;
				penetrate = -1;
			}
			else if (type == 292)
			{
				name = "Inferno";
				width = 130;
				height = 130;
				aiStyle = 50;
				hostile = true;
				alpha = 255;
				magic = true;
				tileCollide = false;
				penetrate = -1;
			}
			else if (type == 293)
			{
				name = "Lost Soul";
				width = 12;
				height = 12;
				aiStyle = 51;
				hostile = true;
				alpha = 255;
				magic = true;
				tileCollide = false;
				maxUpdates = 1;
				penetrate = -1;
			}
			else if (type == 294)
			{
				name = "Shadow Beam";
				width = 4;
				height = 4;
				aiStyle = 48;
				friendly = true;
				magic = true;
				maxUpdates = 100;
				timeLeft = 300;
				penetrate = -1;
			}
			else if (type == 295)
			{
				name = "Inferno";
				width = 12;
				height = 12;
				aiStyle = 50;
				friendly = true;
				alpha = 255;
				magic = true;
				tileCollide = true;
			}
			else if (type == 296)
			{
				name = "Inferno";
				width = 150;
				height = 150;
				aiStyle = 50;
				friendly = true;
				alpha = 255;
				magic = true;
				tileCollide = false;
				penetrate = -1;
			}
			else if (type == 297)
			{
				name = "Lost Soul";
				width = 12;
				height = 12;
				aiStyle = 51;
				friendly = true;
				alpha = 255;
				magic = true;
				maxUpdates = 1;
			}
			else if (type == 298)
			{
				name = "Spirit Heal";
				width = 6;
				height = 6;
				aiStyle = 52;
				alpha = 255;
				magic = true;
				tileCollide = false;
				maxUpdates = 3;
			}
			else if (type == 299)
			{
				name = "Shadowflames";
				width = 6;
				height = 6;
				aiStyle = 1;
				hostile = true;
				alpha = 255;
				penetrate = -1;
				maxUpdates = 2;
				magic = true;
				ignoreWater = true;
				tileCollide = false;
			}
			else if (type == 300)
			{
				name = "Paladin's Hammer";
				width = 38;
				height = 38;
				aiStyle = 2;
				hostile = true;
				penetrate = -1;
				ignoreWater = true;
				tileCollide = false;
			}
			else if (type == 301)
			{
				name = "Paladin's Hammer";
				width = 38;
				height = 38;
				aiStyle = 3;
				friendly = true;
				penetrate = -1;
				melee = true;
				maxUpdates = 2;
			}
			else if (type == 302)
			{
				name = "Sniper Bullet";
				width = 4;
				height = 4;
				aiStyle = 1;
				hostile = true;
				penetrate = -1;
				light = 0.3f;
				alpha = 255;
				maxUpdates = 7;
				scale = 1.18f;
				timeLeft = 300;
				ranged = true;
				ignoreWater = true;
			}
			else if (type == 303)
			{
				name = "Rocket";
				width = 14;
				height = 14;
				aiStyle = 16;
				hostile = true;
				penetrate = -1;
				ranged = true;
			}
			else if (type == 304)
			{
				name = "Vampire Knife";
				alpha = 255;
				width = 30;
				height = 30;
				aiStyle = 2;
				friendly = true;
				penetrate = 1;
				melee = true;
				light = 0.2f;
				ignoreWater = true;
				maxUpdates = 0;
			}
			else if (type == 305)
			{
				name = "Vampire Heal";
				width = 6;
				height = 6;
				aiStyle = 52;
				alpha = 255;
				tileCollide = false;
				maxUpdates = 10;
			}
			else if (type == 306)
			{
				name = "Eater's Bite";
				alpha = 255;
				width = 14;
				height = 14;
				aiStyle = 2;
				friendly = true;
				penetrate = 1;
				melee = true;
				ignoreWater = true;
				maxUpdates = 1;
			}
			else if (type == 307)
			{
				name = "Tiny Eater";
				width = 16;
				height = 16;
				aiStyle = 36;
				penetrate = 1;
				alpha = 255;
				timeLeft = 600;
				melee = true;
				maxUpdates = 3;
			}
			else if (type == 308)
			{
				name = "Frost Hydra";
				width = 80;
				height = 74;
				aiStyle = 53;
				timeLeft = 3600;
				light = 0.25f;
				ignoreWater = true;
				coldDamage = true;
			}
			else if (type == 309)
			{
				name = "Frost Blast";
				width = 14;
				height = 14;
				aiStyle = 28;
				alpha = 255;
				penetrate = 1;
				friendly = true;
				maxUpdates = 3;
				coldDamage = true;
			}
			else if (type == 310)
			{
				netImportant = true;
				name = "Blue Flare";
				width = 6;
				height = 6;
				aiStyle = 33;
				friendly = true;
				penetrate = -1;
				alpha = 255;
				timeLeft = 36000;
			}
			else if (type == 311)
			{
				name = "Candy Corn";
				width = 10;
				height = 12;
				aiStyle = 1;
				friendly = true;
				penetrate = 3;
				alpha = 255;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 312)
			{
				name = "Jack 'O Lantern";
				alpha = 255;
				width = 32;
				height = 32;
				aiStyle = 1;
				friendly = true;
				ranged = true;
				timeLeft = 300;
			}
			else if (type == 313)
			{
				netImportant = true;
				name = "Spider";
				width = 30;
				height = 30;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 314)
			{
				netImportant = true;
				name = "Squashling";
				width = 24;
				height = 40;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 315)
			{
				netImportant = true;
				name = "Bat Hook";
				width = 14;
				height = 14;
				aiStyle = 7;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				timeLeft *= 10;
			}
			else if (type == 316)
			{
				alpha = 255;
				name = "Bat";
				width = 16;
				height = 16;
				aiStyle = 36;
				friendly = true;
				penetrate = 1;
				timeLeft = 600;
				magic = true;
			}
			else if (type == 317)
			{
				netImportant = true;
				name = "Raven";
				width = 28;
				height = 28;
				aiStyle = 54;
				penetrate = 1;
				timeLeft *= 5;
				minion = true;
				minionSlots = 1f;
			}
			else if (type == 318)
			{
				name = "Rotten Egg";
				width = 12;
				height = 14;
				aiStyle = 2;
				friendly = true;
				ranged = true;
			}
			else if (type == 319)
			{
				netImportant = true;
				name = "Black Cat";
				width = 36;
				height = 30;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 320)
			{
				name = "Bloody Machete";
				width = 34;
				height = 34;
				aiStyle = 3;
				friendly = true;
				penetrate = -1;
				melee = true;
			}
			else if (type == 321)
			{
				name = "Flaming Jack";
				width = 30;
				height = 30;
				aiStyle = 55;
				friendly = true;
				melee = true;
				tileCollide = false;
				ignoreWater = true;
			}
			else if (type == 322)
			{
				netImportant = true;
				name = "Wood Hook";
				width = 14;
				height = 14;
				aiStyle = 7;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				timeLeft *= 10;
			}
			else if (type == 323)
			{
				penetrate = 10;
				name = "Stake";
				maxUpdates = 3;
				width = 14;
				height = 14;
				aiStyle = 1;
				alpha = 255;
				friendly = true;
				ranged = true;
				scale = 0.8f;
			}
			else if (type == 324)
			{
				netImportant = true;
				name = "Cursed Sapling";
				width = 26;
				height = 38;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 325)
			{
				alpha = 255;
				penetrate = -1;
				name = "Flaming Wood";
				width = 14;
				height = 14;
				aiStyle = 1;
				hostile = true;
				tileCollide = false;
			}
			else if (type >= 326 && type <= 328)
			{
				name = "Greek Fire";
				if (type == 326)
				{
					width = 14;
					height = 16;
				}
				else if (type == 327)
				{
					width = 12;
					height = 14;
				}
				else
				{
					width = 6;
					height = 12;
				}
				aiStyle = 14;
				hostile = true;
				penetrate = -1;
				timeLeft = 360;
			}
			else if (type == 329)
			{
				name = "Flaming Scythe";
				width = 80;
				height = 80;
				light = 0.25f;
				aiStyle = 56;
				hostile = true;
				penetrate = -1;
				tileCollide = false;
				timeLeft = 420;
			}
			else if (type == 330)
			{
				name = "Star Anise";
				width = 22;
				height = 22;
				aiStyle = 2;
				friendly = true;
				penetrate = 6;
				ranged = true;
			}
			else if (type == 331)
			{
				netImportant = true;
				name = "Candy Cane Hook";
				width = 18;
				height = 18;
				aiStyle = 7;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				timeLeft *= 10;
			}
			else if (type == 332)
			{
				netImportant = true;
				name = "Christmas Hook";
				width = 18;
				height = 18;
				aiStyle = 7;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				timeLeft *= 10;
				light = 0.5f;
			}
			else if (type == 333)
			{
				name = "Fruitcake Chakram";
				width = 38;
				height = 38;
				aiStyle = 3;
				friendly = true;
				scale = 0.9f;
				penetrate = -1;
				melee = true;
			}
			else if (type == 334)
			{
				netImportant = true;
				name = "Puppy";
				width = 28;
				height = 28;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 335)
			{
				name = "Ornament";
				width = 22;
				height = 22;
				aiStyle = 2;
				friendly = true;
				penetrate = 1;
				melee = true;
			}
			else if (type == 336)
			{
				name = "Pine Needle";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				magic = true;
				scale = 0.8f;
				maxUpdates = 1;
			}
			else if (type == 337)
			{
				name = "Blizzard";
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				magic = true;
				maxUpdates = 1;
				tileCollide = false;
				coldDamage = true;
			}
			else if (type == 338 || type == 339 || type == 340 || type == 341)
			{
				name = "Rocket";
				width = 14;
				height = 14;
				aiStyle = 16;
				penetrate = -1;
				friendly = true;
				ranged = true;
				scale = 0.9f;
			}
			else if (type == 342)
			{
				name = "North Pole";
				width = 22;
				height = 2;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				scale = 1.1f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
				coldDamage = true;
			}
			else if (type == 343)
			{
				alpha = 255;
				name = "North Pole";
				width = 10;
				height = 10;
				aiStyle = 57;
				friendly = true;
				melee = true;
				scale = 1.1f;
				penetrate = 3;
				coldDamage = true;
			}
			else if (type == 344)
			{
				name = "North Pole";
				width = 26;
				height = 26;
				aiStyle = 1;
				friendly = true;
				scale = 0.9f;
				alpha = 255;
				melee = true;
				coldDamage = true;
			}
			else if (type == 345)
			{
				name = "Pine Needle";
				width = 4;
				height = 4;
				aiStyle = 1;
				hostile = true;
				scale = 0.8f;
			}
			else if (type == 346)
			{
				name = "Ornament";
				width = 18;
				height = 18;
				aiStyle = 14;
				hostile = true;
				penetrate = -1;
				timeLeft = 300;
			}
			else if (type == 347)
			{
				name = "Ornament";
				width = 6;
				height = 6;
				aiStyle = 2;
				hostile = true;
				penetrate = -1;
			}
			else if (type == 348)
			{
				name = "Frost Wave";
				aiStyle = 1;
				width = 48;
				height = 48;
				hostile = true;
				penetrate = -1;
				tileCollide = false;
				maxUpdates = 1;
				coldDamage = true;
			}
			else if (type == 349)
			{
				name = "Frost Shard";
				aiStyle = 1;
				width = 12;
				height = 12;
				hostile = true;
				penetrate = -1;
				coldDamage = true;
			}
			else if (type == 350)
			{
				alpha = 255;
				penetrate = -1;
				name = "Missile";
				width = 14;
				height = 14;
				aiStyle = 1;
				hostile = true;
				tileCollide = false;
				timeLeft /= 2;
			}
			else if (type == 351)
			{
				alpha = 255;
				penetrate = -1;
				name = "Present";
				width = 24;
				height = 24;
				aiStyle = 58;
				hostile = true;
				tileCollide = false;
			}
			else if (type == 352)
			{
				name = "Spike";
				width = 30;
				height = 30;
				aiStyle = 14;
				hostile = true;
				penetrate = -1;
				timeLeft /= 3;
			}
			else if (type == 353)
			{
				netImportant = true;
				name = "Baby Grinch";
				width = 18;
				height = 28;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 354)
			{
				name = "Crimsand Ball";
				knockBack = 6f;
				width = 10;
				height = 10;
				aiStyle = 10;
				friendly = true;
				penetrate = -1;
				maxUpdates = 1;
			}
			else if (type == 355)
			{
				name = "Venom Fang";
				width = 12;
				height = 12;
				aiStyle = 1;
				alpha = 255;
				friendly = true;
				magic = true;
				penetrate = 7;
			}
			else if (type == 356)
			{
				name = "Spectre Wrath";
				width = 6;
				height = 6;
				aiStyle = 59;
				alpha = 255;
				magic = true;
				tileCollide = false;
				maxUpdates = 3;
			}
			else if (type == 357)
			{
				name = "Pulse Bolt";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 6;
				alpha = 255;
				maxUpdates = 2;
				scale = 1.2f;
				timeLeft = 600;
				ranged = true;
			}
			else if (type == 358)
			{
				name = "Water Gun";
				width = 18;
				height = 18;
				aiStyle = 60;
				alpha = 255;
				penetrate = -1;
				maxUpdates = 2;
				ignoreWater = true;
			}
			else if (type == 359)
			{
				name = "Frost Bolt";
				width = 14;
				height = 14;
				aiStyle = 28;
				alpha = 255;
				magic = true;
				penetrate = 2;
				friendly = true;
				coldDamage = true;
			}
			else if ((type >= 360 && type <= 366) || type == 381 || type == 382)
			{
				name = "Bobber";
				width = 14;
				height = 14;
				aiStyle = 61;
				penetrate = -1;
				bobber = true;
			}
			else if (type == 367)
			{
				name = "Obsidian Swordfish";
				width = 18;
				height = 18;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				scale = 1.1f;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 368)
			{
				name = "Swordfish";
				width = 18;
				height = 18;
				aiStyle = 19;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 369)
			{
				name = "Sawtooth Shark";
				width = 22;
				height = 22;
				aiStyle = 20;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				hide = true;
				ownerHitCheck = true;
				melee = true;
			}
			else if (type == 370)
			{
				name = "Love Potion";
				width = 14;
				height = 14;
				aiStyle = 2;
				friendly = true;
				penetrate = 1;
			}
			else if (type == 371)
			{
				name = "Foul Potion";
				width = 14;
				height = 14;
				aiStyle = 2;
				friendly = true;
				penetrate = 1;
			}
			else if (type == 372)
			{
				name = "Fish Hook";
				width = 18;
				height = 18;
				aiStyle = 7;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				timeLeft *= 10;
			}
			else if (type == 373)
			{
				netImportant = true;
				name = "Hornet";
				width = 24;
				height = 26;
				aiStyle = 62;
				penetrate = -1;
				timeLeft *= 5;
				minion = true;
				minionSlots = 1f;
				tileCollide = false;
				ignoreWater = true;
			}
			else if (type == 374)
			{
				name = "Hornet Stinger";
				width = 10;
				height = 10;
				aiStyle = 0;
				friendly = true;
				penetrate = 1;
				aiStyle = 1;
				tileCollide = true;
				scale *= 0.9f;
			}
			else if (type == 375)
			{
				netImportant = true;
				name = "Flying Imp";
				width = 34;
				height = 26;
				aiStyle = 62;
				penetrate = -1;
				timeLeft *= 5;
				minion = true;
				minionSlots = 1f;
				tileCollide = false;
				ignoreWater = true;
			}
			else if (type == 376)
			{
				name = "Imp Fireball";
				width = 12;
				height = 12;
				aiStyle = 0;
				friendly = true;
				penetrate = -1;
				aiStyle = 1;
				tileCollide = true;
				timeLeft = 100;
				alpha = 255;
				maxUpdates = 1;
			}
			else if (type == 377)
			{
				name = "Spider Hiver";
				width = 66;
				height = 50;
				aiStyle = 53;
				timeLeft = 3600;
				ignoreWater = true;
			}
			else if (type == 378)
			{
				name = "Spider Egg";
				width = 16;
				height = 16;
				aiStyle = 14;
				friendly = true;
				penetrate = -1;
				timeLeft = 60;
				scale = 0.9f;
			}
			else if (type == 379)
			{
				name = "Baby Spider";
				width = 14;
				height = 10;
				aiStyle = 63;
				friendly = true;
				timeLeft = 300;
				penetrate = 1;
			}
			else if (type == 380)
			{
				netImportant = true;
				name = "Zephyr Fish";
				width = 26;
				height = 26;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 383)
			{
				name = "Anchor";
				width = 34;
				height = 34;
				aiStyle = 3;
				friendly = true;
				penetrate = -1;
				melee = true;
			}
			else if (type == 384)
			{
				name = "Sharknado";
				width = 150;
				height = 42;
				hostile = true;
				penetrate = -1;
				aiStyle = 64;
				tileCollide = false;
				ignoreWater = true;
				alpha = 255;
				timeLeft = 540;
			}
			else if (type == 385)
			{
				name = "Sharknado Bolt";
				width = 30;
				height = 30;
				hostile = true;
				penetrate = -1;
				aiStyle = 65;
				alpha = 255;
				timeLeft = 300;
			}
			else if (type == 386)
			{
				name = "Cthulunado";
				width = 150;
				height = 42;
				hostile = true;
				penetrate = -1;
				aiStyle = 64;
				tileCollide = false;
				ignoreWater = true;
				alpha = 255;
				timeLeft = 840;
			}
			else if (type == 387)
			{
				netImportant = true;
				name = "Retanimini";
				width = 40;
				height = 20;
				aiStyle = 66;
				penetrate = -1;
				timeLeft *= 5;
				minion = true;
				minionSlots = 0.5f;
				tileCollide = false;
				ignoreWater = true;
				friendly = true;
			}
			else if (type == 388)
			{
				netImportant = true;
				name = "Spazmamini";
				width = 40;
				height = 20;
				aiStyle = 66;
				penetrate = -1;
				timeLeft *= 5;
				minion = true;
				minionSlots = 0.5f;
				tileCollide = false;
				ignoreWater = true;
				friendly = true;
			}
			else if (type == 389)
			{
				name = "Mini Retina Laser";
				width = 4;
				height = 4;
				aiStyle = 1;
				friendly = true;
				penetrate = 3;
				light = 0.75f;
				alpha = 255;
				maxUpdates = 2;
				scale = 1.2f;
				timeLeft = 600;
			}
			else if (type == 390 || type == 391 || type == 392)
			{
				name = "Venom Spider";
				width = 18;
				height = 18;
				aiStyle = 26;
				penetrate = -1;
				netImportant = true;
				timeLeft *= 5;
				minion = true;
				minionSlots = 1f;
				if (type == 391)
				{
					name = "Jumper Spider";
				}
				if (type == 392)
				{
					name = "Dangerous Spider";
				}
			}
			else if (type == 393 || type == 394 || type == 395)
			{
				name = "One Eyed Pirate";
				width = 20;
				height = 30;
				aiStyle = 67;
				penetrate = -1;
				netImportant = true;
				timeLeft *= 5;
				minion = true;
				minionSlots = 1f;
				if (type == 394)
				{
					name = "Soulscourge Pirate";
				}
				if (type == 395)
				{
					name = "Pirate Captain";
				}
			}
			else if (type == 396)
			{
				name = "Slime Hook";
				width = 18;
				height = 18;
				aiStyle = 7;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				timeLeft *= 10;
				alpha = 100;
			}
			else if (type == 397)
			{
				name = "Sticky Grenade";
				width = 14;
				height = 14;
				aiStyle = 16;
				friendly = true;
				penetrate = -1;
				ranged = true;
				tileCollide = false;
			}
			else if (type == 398)
			{
				netImportant = true;
				name = "Mini Minotaur";
				width = 18;
				height = 38;
				aiStyle = 26;
				friendly = true;
				penetrate = -1;
				timeLeft *= 5;
			}
			else if (type == 399)
			{
				name = "Molotov Cocktail";
				width = 14;
				height = 14;
				aiStyle = 68;
				friendly = true;
				penetrate = 1;
				alpha = 255;
				ranged = true;
				noEnchantments = true;
			}
			else if (type >= 400 && type <= 402)
			{
				name = "Molotov Fire";
				if (type == 400)
				{
					width = 14;
					height = 16;
				}
				else if (type == 401)
				{
					width = 12;
					height = 14;
				}
				else
				{
					width = 6;
					height = 12;
				}
				aiStyle = 14;
				friendly = true;
				penetrate = -1;
				timeLeft = 360;
				ranged = true;
				noEnchantments = true;
			}
			else if (type == 403)
			{
				netImportant = true;
				name = "Track Hook";
				width = 18;
				height = 18;
				aiStyle = 7;
				friendly = true;
				penetrate = -1;
				tileCollide = false;
				timeLeft *= 10;
			}
			else if (type == 404)
			{
				name = "Flairon";
				width = 26;
				height = 26;
				aiStyle = 69;
				friendly = true;
				penetrate = -1;
				alpha = 255;
				melee = true;
			}
			else if (type == 405)
			{
				name = "Flairon Bubble";
				width = 14;
				height = 14;
				aiStyle = 70;
				friendly = true;
				penetrate = 1;
				alpha = 255;
				timeLeft = 90;
				melee = true;
				noEnchantments = true;
			}
			else if (type == 406)
			{
				name = "Slime Gun";
				width = 14;
				height = 14;
				aiStyle = 60;
				alpha = 255;
				penetrate = -1;
				maxUpdates = 2;
				ignoreWater = true;
			}
			else if (type == 407)
			{
				netImportant = true;
				name = "Tempest";
				width = 28;
				height = 40;
				aiStyle = 62;
				penetrate = -1;
				timeLeft *= 5;
				minion = true;
				friendly = true;
				minionSlots = 1f;
				tileCollide = false;
				ignoreWater = true;
			}
			else if (type == 408)
			{
				name = "Mini Sharkron";
				width = 10;
				height = 10;
				aiStyle = 1;
				friendly = true;
				alpha = 255;
				ignoreWater = true;
			}
			else if (type == 409)
			{
				name = "Typhoon";
				width = 30;
				height = 30;
				penetrate = -1;
				aiStyle = 71;
				alpha = 255;
				timeLeft = 360;
				friendly = true;
				tileCollide = true;
				maxUpdates = 2;
				magic = true;
				ignoreWater = true;
			}
			else if (type == 410)
			{
				name = "Bubble";
				width = 14;
				height = 14;
				aiStyle = 72;
				friendly = true;
				penetrate = 1;
				alpha = 255;
				timeLeft = 50;
				magic = true;
				ignoreWater = true;
			}
			else if (type >= 411 && type <= 414)
			{
				switch (type)
				{
				case 411:
					name = "Copper Coins";
					break;
				case 412:
					name = "Silver Coins";
					break;
				case 413:
					name = "Gold Coins";
					break;
				case 414:
					name = "Platinum Coins";
					break;
				}
				width = 10;
				height = 10;
				aiStyle = 10;
			}
			else if (type == 415 || type == 416 || type == 417 || type == 418)
			{
				name = "Rocket";
				width = 14;
				height = 14;
				aiStyle = 34;
				friendly = true;
				ranged = true;
				timeLeft = 45;
			}
			else if (type >= 419 && type <= 422)
			{
				name = "Firework Fountain";
				width = 4;
				height = 4;
				aiStyle = 73;
				friendly = true;
			}
			else
			{
				active = false;
			}
			width = (int)((float)width * scale);
			height = (int)((float)height * scale);
			maxPenetrate = penetrate;
		}

		public static int NewProjectile(float X, float Y, float SpeedX, float SpeedY, int Type, int Damage, float KnockBack, int Owner = 255, float ai0 = 0f, float ai1 = 0f)
		{
			int num = 1000;
			for (int i = 0; i < 1000; i++)
			{
				if (!Main.projectile[i].active)
				{
					num = i;
					break;
				}
			}
			if (num == 1000)
			{
				return num;
			}
			Main.projectile[num].SetDefaults(Type);
			Main.projectile[num].position.X = X - (float)Main.projectile[num].width * 0.5f;
			Main.projectile[num].position.Y = Y - (float)Main.projectile[num].height * 0.5f;
			Main.projectile[num].owner = Owner;
			Main.projectile[num].velocity.X = SpeedX;
			Main.projectile[num].velocity.Y = SpeedY;
			Main.projectile[num].damage = Damage;
			Main.projectile[num].knockBack = KnockBack;
			Main.projectile[num].identity = num;
			Main.projectile[num].gfxOffY = 0f;
			Main.projectile[num].stepSpeed = 1f;
			Main.projectile[num].wet = Collision.WetCollision(Main.projectile[num].position, Main.projectile[num].width, Main.projectile[num].height);
			if (Main.projectile[num].ignoreWater)
			{
				Main.projectile[num].wet = false;
			}
			Main.projectile[num].honeyWet = Collision.honey;
			if (Main.projectile[num].aiStyle == 1)
			{
				while (Main.projectile[num].velocity.X >= 16f || Main.projectile[num].velocity.X <= -16f || Main.projectile[num].velocity.Y >= 16f || Main.projectile[num].velocity.Y < -16f)
				{
					Main.projectile[num].velocity.X *= 0.97f;
					Main.projectile[num].velocity.Y *= 0.97f;
				}
			}
			if (Owner == Main.myPlayer)
			{
				switch (Type)
				{
				case 206:
					Main.projectile[num].ai[0] = (float)Main.rand.Next(-100, 101) * 0.0005f;
					Main.projectile[num].ai[1] = (float)Main.rand.Next(-100, 101) * 0.0005f;
					break;
				case 335:
					Main.projectile[num].ai[1] = Main.rand.Next(4);
					break;
				case 358:
					Main.projectile[num].ai[1] = (float)Main.rand.Next(10, 31) * 0.1f;
					break;
				case 406:
					Main.projectile[num].ai[1] = (float)Main.rand.Next(10, 21) * 0.1f;
					break;
				default:
					Main.projectile[num].ai[0] = ai0;
					Main.projectile[num].ai[1] = ai1;
					break;
				}
			}
			if (Main.netMode != 0 && Owner == Main.myPlayer)
			{
				NetMessage.SendData(27, -1, -1, "", num);
			}
			if (Owner == Main.myPlayer)
			{
				if (Type == 28)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 29)
				{
					Main.projectile[num].timeLeft = 300;
				}
				if (Type == 30)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 37)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 75)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 133)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 136)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 139)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 142)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 397)
				{
					Main.projectile[num].timeLeft = 180;
				}
				if (Type == 419)
				{
					Main.projectile[num].timeLeft = 600;
				}
				if (Type == 420)
				{
					Main.projectile[num].timeLeft = 600;
				}
				if (Type == 421)
				{
					Main.projectile[num].timeLeft = 600;
				}
				if (Type == 422)
				{
					Main.projectile[num].timeLeft = 600;
				}
			}
			if (Type == 249)
			{
				Main.projectile[num].frame = Main.rand.Next(5);
			}
			return num;
		}

		public void StatusNPC(int i)
		{
			if (melee && Main.player[owner].meleeEnchant > 0 && !noEnchantments)
			{
				int meleeEnchant = Main.player[owner].meleeEnchant;
				if (meleeEnchant == 1)
				{
					Main.npc[i].AddBuff(70, 60 * Main.rand.Next(5, 10));
				}
				if (meleeEnchant == 2)
				{
					Main.npc[i].AddBuff(39, 60 * Main.rand.Next(3, 7));
				}
				if (meleeEnchant == 3)
				{
					Main.npc[i].AddBuff(24, 60 * Main.rand.Next(3, 7));
				}
				if (meleeEnchant == 5)
				{
					Main.npc[i].AddBuff(69, 60 * Main.rand.Next(10, 20));
				}
				if (meleeEnchant == 6)
				{
					Main.npc[i].AddBuff(31, 60 * Main.rand.Next(1, 4));
				}
				if (meleeEnchant == 8)
				{
					Main.npc[i].AddBuff(20, 60 * Main.rand.Next(5, 10));
				}
				if (meleeEnchant == 4)
				{
					Main.npc[i].AddBuff(72, 120);
				}
			}
			if (type == 379)
			{
				Main.npc[i].AddBuff(70, 60 * Main.rand.Next(4, 7));
			}
			if (type >= 390 && type <= 392)
			{
				Main.npc[i].AddBuff(70, 60 * Main.rand.Next(2, 5));
			}
			if (type == 374)
			{
				Main.npc[i].AddBuff(20, 60 * Main.rand.Next(4, 7));
			}
			if (type == 376)
			{
				Main.npc[i].AddBuff(24, 60 * Main.rand.Next(3, 7));
			}
			if (type >= 399 && type <= 402)
			{
				Main.npc[i].AddBuff(24, 60 * Main.rand.Next(3, 7));
			}
			if (type == 295 || type == 296)
			{
				Main.npc[i].AddBuff(24, 60 * Main.rand.Next(8, 16));
			}
			if ((melee || ranged) && Main.player[owner].frostBurn && !noEnchantments)
			{
				Main.npc[i].AddBuff(44, 60 * Main.rand.Next(5, 15));
			}
			if (melee && Main.player[owner].magmaStone && !noEnchantments)
			{
				if (Main.rand.Next(7) == 0)
				{
					Main.npc[i].AddBuff(24, 360);
				}
				else if (Main.rand.Next(3) == 0)
				{
					Main.npc[i].AddBuff(24, 120);
				}
				else
				{
					Main.npc[i].AddBuff(24, 60);
				}
			}
			if (type == 287)
			{
				Main.npc[i].AddBuff(72, 120);
			}
			if (type == 285)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.npc[i].AddBuff(31, 180);
				}
				else
				{
					Main.npc[i].AddBuff(31, 60);
				}
			}
			if (type == 2 && Main.rand.Next(3) == 0)
			{
				Main.npc[i].AddBuff(24, 180);
			}
			if (type == 172)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.npc[i].AddBuff(44, 180);
				}
			}
			else if (type == 15)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(24, 300);
				}
			}
			else if (type == 253)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(44, 480);
				}
			}
			else if (type == 19)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.npc[i].AddBuff(24, 180);
				}
			}
			else if (type == 33)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.npc[i].AddBuff(20, 420);
				}
			}
			else if (type == 34)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(24, 240);
				}
			}
			else if (type == 35)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.npc[i].AddBuff(24, 180);
				}
			}
			else if (type == 54)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(20, 600);
				}
			}
			else if (type == 267)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.npc[i].AddBuff(20, 3600);
				}
				else
				{
					Main.npc[i].AddBuff(20, 1800);
				}
			}
			else if (type == 63)
			{
				if (Main.rand.Next(3) != 0)
				{
					Main.npc[i].AddBuff(31, 120);
				}
			}
			else if (type == 85 || type == 188)
			{
				Main.npc[i].AddBuff(24, 1200);
			}
			else if (type == 95 || type == 103 || type == 104)
			{
				Main.npc[i].AddBuff(39, 420);
			}
			else if (type == 278 || type == 279 || type == 280)
			{
				Main.npc[i].AddBuff(69, 600);
			}
			else if (type == 282 || type == 283)
			{
				Main.npc[i].AddBuff(70, 600);
			}
			if (type == 163 || type == 310)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.npc[i].AddBuff(24, 600);
				}
				else
				{
					Main.npc[i].AddBuff(24, 300);
				}
			}
			else if (type == 98)
			{
				Main.npc[i].AddBuff(20, 600);
			}
			else if (type == 184)
			{
				Main.npc[i].AddBuff(20, 900);
			}
			else if (type == 265)
			{
				Main.npc[i].AddBuff(20, 1800);
			}
			else if (type == 355)
			{
				Main.npc[i].AddBuff(70, 1800);
			}
		}

		public void StatusPvP(int i)
		{
			if (melee && Main.player[owner].meleeEnchant > 0 && !noEnchantments)
			{
				int meleeEnchant = Main.player[owner].meleeEnchant;
				if (meleeEnchant == 1)
				{
					Main.player[i].AddBuff(70, 60 * Main.rand.Next(5, 10));
				}
				if (meleeEnchant == 2)
				{
					Main.player[i].AddBuff(39, 60 * Main.rand.Next(3, 7));
				}
				if (meleeEnchant == 3)
				{
					Main.player[i].AddBuff(24, 60 * Main.rand.Next(3, 7));
				}
				if (meleeEnchant == 5)
				{
					Main.player[i].AddBuff(69, 60 * Main.rand.Next(10, 20));
				}
				if (meleeEnchant == 6)
				{
					Main.player[i].AddBuff(31, 60 * Main.rand.Next(1, 4));
				}
				if (meleeEnchant == 8)
				{
					Main.player[i].AddBuff(20, 60 * Main.rand.Next(5, 10));
				}
			}
			if (type == 295 || type == 296)
			{
				Main.player[i].AddBuff(24, 60 * Main.rand.Next(8, 16));
			}
			if ((melee || ranged) && Main.player[owner].frostBurn && !noEnchantments)
			{
				Main.player[i].AddBuff(44, 60 * Main.rand.Next(1, 8), false);
			}
			if (melee && Main.player[owner].magmaStone && !noEnchantments)
			{
				if (Main.rand.Next(7) == 0)
				{
					Main.player[i].AddBuff(24, 360);
				}
				else if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(24, 120);
				}
				else
				{
					Main.player[i].AddBuff(24, 60);
				}
			}
			if (type == 2 && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(24, 180, false);
			}
			if (type == 172)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(44, 240, false);
				}
			}
			else if (type == 15)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(24, 300, false);
				}
			}
			else if (type == 253)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(44, 480, false);
				}
			}
			else if (type == 19)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
				}
			}
			else if (type == 33)
			{
				if (Main.rand.Next(5) == 0)
				{
					Main.player[i].AddBuff(20, 420, false);
				}
			}
			else if (type == 34)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(24, 240, false);
				}
			}
			else if (type == 35)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
				}
			}
			else if (type == 54)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(20, 600, false);
				}
			}
			else if (type == 267)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(20, 3600);
				}
				else
				{
					Main.player[i].AddBuff(20, 1800);
				}
			}
			else if (type == 63)
			{
				if (Main.rand.Next(3) != 0)
				{
					Main.player[i].AddBuff(31, 120);
				}
			}
			else if (type == 85 || type == 188)
			{
				Main.player[i].AddBuff(24, 1200, false);
			}
			else if (type == 95 || type == 103 || type == 104)
			{
				Main.player[i].AddBuff(39, 420);
			}
			else if (type == 278 || type == 279 || type == 280)
			{
				Main.player[i].AddBuff(69, 900);
			}
			else if (type == 282 || type == 283)
			{
				Main.player[i].AddBuff(70, 600);
			}
			if (type == 163 || type == 310)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(24, 600);
				}
				else
				{
					Main.player[i].AddBuff(24, 300);
				}
			}
			else if (type == 265)
			{
				Main.player[i].AddBuff(20, 1200);
			}
			else if (type == 355)
			{
				Main.player[i].AddBuff(70, 1800);
			}
		}

		public void ghostHurt(int dmg, Vector2 Position)
		{
			if (!magic)
			{
				return;
			}
			int num = damage / 2;
			if (dmg / 2 <= 1)
			{
				return;
			}
			int num2 = -1;
			int num3 = 1000;
			if (Main.player[Main.myPlayer].ghostDmg > (float)num3)
			{
				return;
			}
			Main.player[Main.myPlayer].ghostDmg += num;
			int[] array = new int[200];
			int num4 = 0;
			int num5 = 0;
			for (int i = 0; i < 200; i++)
			{
				if (!Main.npc[i].active || Main.npc[i].friendly || Main.npc[i].lifeMax <= 5 || Main.npc[i].dontTakeDamage)
				{
					continue;
				}
				float num6 = Math.Abs(Main.npc[i].position.X + (float)(Main.npc[i].width / 2) - position.X + (float)(width / 2)) + Math.Abs(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2) - position.Y + (float)(height / 2));
				if (num6 < 800f)
				{
					if (Collision.CanHit(position, 1, 1, Main.npc[i].position, Main.npc[i].width, Main.npc[i].height) && num6 > 50f)
					{
						array[num5] = i;
						num5++;
					}
					else if (num5 == 0)
					{
						array[num4] = i;
						num4++;
					}
				}
			}
			if (num4 != 0 || num5 != 0)
			{
				num2 = ((num5 <= 0) ? array[Main.rand.Next(num4)] : array[Main.rand.Next(num5)]);
				float num7 = 4f;
				float num8 = Main.rand.Next(-100, 101);
				float num9 = Main.rand.Next(-100, 101);
				float num10 = (float)Math.Sqrt(num8 * num8 + num9 * num9);
				num10 = num7 / num10;
				num8 *= num10;
				num9 *= num10;
				NewProjectile(Position.X, Position.Y, num8, num9, 356, num, 0f, owner, num2);
			}
		}

		public void ghostHeal(int dmg, Vector2 Position)
		{
			float num = 0.2f;
			num -= (float)numHits * 0.05f;
			if (num <= 0f)
			{
				return;
			}
			float num2 = (float)dmg * num;
			if ((int)num2 <= 0 || Main.player[Main.myPlayer].lifeSteal <= 0f)
			{
				return;
			}
			Main.player[Main.myPlayer].lifeSteal -= num2;
			if (!magic)
			{
				return;
			}
			float num3 = 0f;
			int num4 = owner;
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active && !Main.player[i].dead && ((!Main.player[owner].hostile && !Main.player[i].hostile) || Main.player[owner].team == Main.player[i].team))
				{
					float num5 = Math.Abs(Main.player[i].position.X + (float)(Main.player[i].width / 2) - position.X + (float)(width / 2)) + Math.Abs(Main.player[i].position.Y + (float)(Main.player[i].height / 2) - position.Y + (float)(height / 2));
					if (num5 < 800f && (float)(Main.player[i].statLifeMax2 - Main.player[i].statLife) > num3)
					{
						num3 = Main.player[i].statLifeMax2 - Main.player[i].statLife;
						num4 = i;
					}
				}
			}
			NewProjectile(Position.X, Position.Y, 0f, 0f, 298, 0, 0f, owner, num4, num2);
		}

		public void vampireHeal(int dmg, Vector2 Position)
		{
			float num = (float)dmg * 0.075f;
			if ((int)num != 0 && !(Main.player[Main.myPlayer].lifeSteal <= 0f))
			{
				Main.player[Main.myPlayer].lifeSteal -= num;
				int num2 = owner;
				NewProjectile(Position.X, Position.Y, 0f, 0f, 305, 0, 0f, owner, num2, num);
			}
		}

		public void StatusPlayer(int i)
		{
			if (type == 348)
			{
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(46, 600);
				}
				else
				{
					Main.player[i].AddBuff(46, 300);
				}
				if (Main.rand.Next(3) != 0)
				{
					if (Main.rand.Next(16) == 0)
					{
						Main.player[i].AddBuff(47, 60);
					}
					else if (Main.rand.Next(12) == 0)
					{
						Main.player[i].AddBuff(47, 40);
					}
					else if (Main.rand.Next(8) == 0)
					{
						Main.player[i].AddBuff(47, 20);
					}
				}
			}
			if (type == 349)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(46, 600);
				}
				else if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(46, 300);
				}
			}
			if (type >= 399 && type <= 402)
			{
				Main.npc[i].AddBuff(24, 60 * Main.rand.Next(3, 7));
			}
			if (type == 55 && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(20, 600);
			}
			if (type == 44 && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(22, 900);
			}
			if (type == 293)
			{
				Main.player[i].AddBuff(80, 60 * Main.rand.Next(2, 7));
			}
			if (type == 82 && Main.rand.Next(3) == 0)
			{
				Main.player[i].AddBuff(24, 420);
			}
			if (type == 285)
			{
				if (Main.rand.Next(3) == 0)
				{
					Main.player[i].AddBuff(31, 180);
				}
				else
				{
					Main.player[i].AddBuff(31, 60);
				}
			}
			if (type == 96 || type == 101)
			{
				if (Main.rand.Next(6) == 0)
				{
					Main.player[i].AddBuff(39, 480);
				}
				else if (Main.rand.Next(4) == 0)
				{
					Main.player[i].AddBuff(39, 300);
				}
				else if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(39, 180);
				}
			}
			else if (type == 288)
			{
				Main.player[i].AddBuff(69, 900);
			}
			else if (type == 253 && Main.rand.Next(2) == 0)
			{
				Main.player[i].AddBuff(44, 600);
			}
			if (type == 291 || type == 292)
			{
				Main.player[i].AddBuff(24, 60 * Main.rand.Next(8, 16));
			}
			if (type == 98)
			{
				Main.player[i].AddBuff(20, 600);
			}
			if (type == 184)
			{
				Main.player[i].AddBuff(20, 900);
			}
			if (type == 290)
			{
				Main.player[i].AddBuff(32, 60 * Main.rand.Next(5, 16));
			}
			if (type == 174)
			{
				Main.player[i].AddBuff(46, 1200);
				if (!Main.player[i].frozen && Main.rand.Next(20) == 0)
				{
					Main.player[i].AddBuff(47, 90);
				}
			}
			if (type == 257)
			{
				Main.player[i].AddBuff(46, 2700);
				if (!Main.player[i].frozen && Main.rand.Next(5) == 0)
				{
					Main.player[i].AddBuff(47, 60);
				}
			}
			if (type == 177)
			{
				Main.player[i].AddBuff(46, 1500);
				if (!Main.player[i].frozen && Main.rand.Next(10) == 0)
				{
					Main.player[i].AddBuff(47, Main.rand.Next(30, 120));
				}
			}
			if (type == 176)
			{
				if (Main.rand.Next(4) == 0)
				{
					Main.player[i].AddBuff(20, 1200);
				}
				else if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(20, 300);
				}
			}
		}

		public void Damage()
		{
			if (type == 18 || type == 72 || type == 86 || type == 87 || aiStyle == 31 || aiStyle == 32 || type == 226 || type == 378 || (Main.projPet[type] && type != 266 && type != 407 && type != 317 && (type != 388 || ai[0] != 2f) && (type < 390 || type > 392) && (type < 393 || type > 395)))
			{
				return;
			}
			Rectangle rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
			if (type == 85 || type == 101)
			{
				int num = 30;
				rectangle.X -= num;
				rectangle.Y -= num;
				rectangle.Width += num * 2;
				rectangle.Height += num * 2;
			}
			if (type == 188)
			{
				int num2 = 20;
				rectangle.X -= num2;
				rectangle.Y -= num2;
				rectangle.Width += num2 * 2;
				rectangle.Height += num2 * 2;
			}
			if (aiStyle == 29)
			{
				int num3 = 4;
				rectangle.X -= num3;
				rectangle.Y -= num3;
				rectangle.Width += num3 * 2;
				rectangle.Height += num3 * 2;
			}
			if (friendly && owner == Main.myPlayer)
			{
				if (((aiStyle == 16 || type == 41) && type != 338 && type != 339 && type != 340 && type != 341 && (timeLeft <= 1 || type == 108 || type == 164)) || (type == 286 && localAI[1] == -1f))
				{
					int myPlayer = Main.myPlayer;
					if (Main.player[myPlayer].active && !Main.player[myPlayer].dead && !Main.player[myPlayer].immune && (!ownerHitCheck || Collision.CanHit(Main.player[owner].position, Main.player[owner].width, Main.player[owner].height, Main.player[myPlayer].position, Main.player[myPlayer].width, Main.player[myPlayer].height)))
					{
						Rectangle value = new Rectangle((int)Main.player[myPlayer].position.X, (int)Main.player[myPlayer].position.Y, Main.player[myPlayer].width, Main.player[myPlayer].height);
						if (rectangle.Intersects(value))
						{
							if (Main.player[myPlayer].position.X + (float)(Main.player[myPlayer].width / 2) < position.X + (float)(width / 2))
							{
								direction = -1;
							}
							else
							{
								direction = 1;
							}
							int num4 = Main.DamageVar(damage);
							StatusPlayer(myPlayer);
							Main.player[myPlayer].Hurt(num4, direction, true, false, Lang.deathMsg(owner, -1, whoAmI));
							if (Main.netMode != 0)
							{
								NetMessage.SendData(26, -1, -1, Lang.deathMsg(owner, -1, whoAmI), myPlayer, direction, num4, 1f);
							}
						}
					}
				}
				if (type != 69 && type != 70 && type != 10 && type != 11 && aiStyle != 45 && type != 379 && type != 407)
				{
					int num5 = (int)(position.X / 16f);
					int num6 = (int)((position.X + (float)width) / 16f) + 1;
					int num7 = (int)(position.Y / 16f);
					int num8 = (int)((position.Y + (float)height) / 16f) + 1;
					if (num5 < 0)
					{
						num5 = 0;
					}
					if (num6 > Main.maxTilesX)
					{
						num6 = Main.maxTilesX;
					}
					if (num7 < 0)
					{
						num7 = 0;
					}
					if (num8 > Main.maxTilesY)
					{
						num8 = Main.maxTilesY;
					}
					for (int i = num5; i < num6; i++)
					{
						for (int j = num7; j < num8; j++)
						{
							if (Main.tile[i, j] != null && Main.tileCut[Main.tile[i, j].type] && Main.tile[i, j + 1] != null && Main.tile[i, j + 1].type != 78)
							{
								WorldGen.KillTile(i, j);
								if (Main.netMode != 0)
								{
									NetMessage.SendData(17, -1, -1, "", 0, i, j);
								}
							}
						}
					}
				}
			}
			if (owner == Main.myPlayer)
			{
				if (damage > 0)
				{
					for (int k = 0; k < 200; k++)
					{
						if (!Main.npc[k].active || Main.npc[k].dontTakeDamage || (((Main.npc[k].friendly && type != 318 && (Main.npc[k].type != 22 || owner >= 255 || !Main.player[owner].killGuide) && (Main.npc[k].type != 54 || owner >= 255 || !Main.player[owner].killClothier)) || !friendly) && (!Main.npc[k].friendly || !hostile)) || (owner >= 0 && Main.npc[k].immune[owner] != 0 && maxPenetrate != 1))
						{
							continue;
						}
						bool flag = false;
						if (type == 11 && (Main.npc[k].type == 47 || Main.npc[k].type == 57))
						{
							flag = true;
						}
						else if (type == 31 && Main.npc[k].type == 69)
						{
							flag = true;
						}
						if (flag || (!Main.npc[k].noTileCollide && ownerHitCheck && !Collision.CanHit(Main.player[owner].position, Main.player[owner].width, Main.player[owner].height, Main.npc[k].position, Main.npc[k].width, Main.npc[k].height)))
						{
							continue;
						}
						Rectangle value2 = new Rectangle((int)Main.npc[k].position.X, (int)Main.npc[k].position.Y, Main.npc[k].width, Main.npc[k].height);
						if (!rectangle.Intersects(value2))
						{
							continue;
						}
						if (aiStyle == 3 && type != 301)
						{
							if (ai[0] == 0f)
							{
								velocity.X = 0f - velocity.X;
								velocity.Y = 0f - velocity.Y;
								netUpdate = true;
							}
							ai[0] = 1f;
						}
						else if (aiStyle == 16)
						{
							if (timeLeft > 3)
							{
								timeLeft = 3;
							}
							if (Main.npc[k].position.X + (float)(Main.npc[k].width / 2) < position.X + (float)(width / 2))
							{
								direction = -1;
							}
							else
							{
								direction = 1;
							}
						}
						else if (aiStyle == 68)
						{
							if (timeLeft > 3)
							{
								timeLeft = 3;
							}
							if (Main.npc[k].position.X + (float)(Main.npc[k].width / 2) < position.X + (float)(width / 2))
							{
								direction = -1;
							}
							else
							{
								direction = 1;
							}
						}
						else if (aiStyle == 50)
						{
							if (Main.npc[k].position.X + (float)(Main.npc[k].width / 2) < position.X + (float)(width / 2))
							{
								direction = -1;
							}
							else
							{
								direction = 1;
							}
						}
						if (aiStyle == 39)
						{
							if (ai[1] == 0f)
							{
								ai[1] = k + 1;
								netUpdate = true;
							}
							if (Main.player[owner].position.X + (float)(Main.player[owner].width / 2) < position.X + (float)(width / 2))
							{
								direction = 1;
							}
							else
							{
								direction = -1;
							}
						}
						if (type == 41 && timeLeft > 1)
						{
							timeLeft = 1;
						}
						bool flag2 = false;
						if (melee && Main.rand.Next(1, 101) <= Main.player[owner].meleeCrit)
						{
							flag2 = true;
						}
						if (ranged && Main.rand.Next(1, 101) <= Main.player[owner].rangedCrit)
						{
							flag2 = true;
						}
						if (magic && Main.rand.Next(1, 101) <= Main.player[owner].magicCrit)
						{
							flag2 = true;
						}
						int num9 = Main.DamageVar(damage);
						if (type == 323 && (Main.npc[k].type == 158 || Main.npc[k].type == 159))
						{
							num9 *= 10;
						}
						if (type == 294)
						{
							damage = (int)((double)damage * 0.8);
						}
						if (type == 261)
						{
							float num10 = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
							if (num10 < 1f)
							{
								num10 = 1f;
							}
							num9 = (int)((float)num9 * num10 / 8f);
						}
						StatusNPC(k);
						if (type != 221 && type != 227)
						{
							Main.player[owner].onHit(Main.npc[k].center().X, Main.npc[k].center().Y);
						}
						if (type == 317)
						{
							ai[1] = -1f;
							netUpdate = true;
						}
						int num11 = (int)Main.npc[k].StrikeNPC(num9, knockBack, direction, flag2);
						if (num11 > 0 && Main.npc[k].lifeMax > 5 && friendly && !hostile && aiStyle != 59)
						{
							if (Main.player[owner].ghostHeal)
							{
								ghostHeal(num11, new Vector2(Main.npc[k].center().X, Main.npc[k].center().Y));
							}
							if (Main.player[owner].ghostHurt)
							{
								ghostHurt(num11, new Vector2(Main.npc[k].center().X, Main.npc[k].center().Y));
							}
							if (melee && Main.player[owner].beetleOffense)
							{
								if (Main.player[owner].beetleOrbs == 0)
								{
									Main.player[owner].beetleCounter += num11 * 3;
								}
								else if (Main.player[owner].beetleOrbs == 1)
								{
									Main.player[owner].beetleCounter += num11 * 2;
								}
								else
								{
									Main.player[owner].beetleCounter += num11;
								}
								Main.player[owner].beetleCountdown = 0;
							}
						}
						if (type == 304 && num11 > 0 && Main.npc[k].lifeMax > 5)
						{
							vampireHeal(num11, new Vector2(Main.npc[k].center().X, Main.npc[k].center().Y));
						}
						if (melee && Main.player[owner].meleeEnchant == 7)
						{
							NewProjectile(Main.npc[k].center().X, Main.npc[k].center().Y, Main.npc[k].velocity.X, Main.npc[k].velocity.Y, 289, 0, 0f, owner);
						}
						if (Main.npc[k].value > 0f && Main.player[owner].coins && Main.rand.Next(5) == 0)
						{
							int num12 = 71;
							if (Main.rand.Next(10) == 0)
							{
								num12 = 72;
							}
							if (Main.rand.Next(100) == 0)
							{
								num12 = 73;
							}
							int num13 = Item.NewItem((int)Main.npc[k].position.X, (int)Main.npc[k].position.Y, Main.npc[k].width, Main.npc[k].height, num12);
							Main.item[num13].stack = Main.rand.Next(1, 11);
							Main.item[num13].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
							Main.item[num13].velocity.X = (float)Main.rand.Next(10, 31) * 0.2f * (float)direction;
							if (Main.netMode == 1)
							{
								NetMessage.SendData(21, -1, -1, "", num13);
							}
						}
						if (Main.netMode != 0)
						{
							if (flag2)
							{
								NetMessage.SendData(28, -1, -1, "", k, num9, knockBack, direction, 1);
							}
							else
							{
								NetMessage.SendData(28, -1, -1, "", k, num9, knockBack, direction);
							}
						}
						if (type >= 390 && type <= 392)
						{
							localAI[1] = 25f;
						}
						if (type == 286)
						{
							Main.npc[k].immune[owner] = 5;
						}
						else if (type == 246)
						{
							Main.npc[k].immune[owner] = 7;
						}
						else if (type == 249)
						{
							Main.npc[k].immune[owner] = 7;
						}
						else if (type == 190)
						{
							Main.npc[k].immune[owner] = 8;
						}
						else if (type == 409)
						{
							Main.npc[k].immune[owner] = 6;
						}
						else if (type == 407)
						{
							Main.npc[k].immune[owner] = 20;
						}
						else if (type == 311)
						{
							Main.npc[k].immune[owner] = 7;
						}
						else if (penetrate != 1)
						{
							Main.npc[k].immune[owner] = 10;
						}
						if (penetrate > 0 && type != 317)
						{
							if (type == 357)
							{
								damage = (int)((double)damage * 0.9);
							}
							penetrate--;
							if (penetrate == 0)
							{
								break;
							}
						}
						if (aiStyle == 7)
						{
							ai[0] = 1f;
							damage = 0;
							netUpdate = true;
						}
						else if (aiStyle == 13)
						{
							ai[0] = 1f;
							netUpdate = true;
						}
						else if (aiStyle == 69)
						{
							ai[0] = 1f;
							netUpdate = true;
						}
						numHits++;
					}
				}
				if (damage > 0 && Main.player[Main.myPlayer].hostile)
				{
					for (int l = 0; l < 255; l++)
					{
						if (l == owner || !Main.player[l].active || Main.player[l].dead || Main.player[l].immune || !Main.player[l].hostile || playerImmune[l] > 0 || (Main.player[Main.myPlayer].team != 0 && Main.player[Main.myPlayer].team == Main.player[l].team) || (ownerHitCheck && !Collision.CanHit(Main.player[owner].position, Main.player[owner].width, Main.player[owner].height, Main.player[l].position, Main.player[l].width, Main.player[l].height)))
						{
							continue;
						}
						Rectangle value3 = new Rectangle((int)Main.player[l].position.X, (int)Main.player[l].position.Y, Main.player[l].width, Main.player[l].height);
						if (!rectangle.Intersects(value3))
						{
							continue;
						}
						if (aiStyle == 3)
						{
							if (ai[0] == 0f)
							{
								velocity.X = 0f - velocity.X;
								velocity.Y = 0f - velocity.Y;
								netUpdate = true;
							}
							ai[0] = 1f;
						}
						else if (aiStyle == 16)
						{
							if (timeLeft > 3)
							{
								timeLeft = 3;
							}
							if (Main.player[l].position.X + (float)(Main.player[l].width / 2) < position.X + (float)(width / 2))
							{
								direction = -1;
							}
							else
							{
								direction = 1;
							}
						}
						else if (aiStyle == 68)
						{
							if (timeLeft > 3)
							{
								timeLeft = 3;
							}
							if (Main.player[l].position.X + (float)(Main.player[l].width / 2) < position.X + (float)(width / 2))
							{
								direction = -1;
							}
							else
							{
								direction = 1;
							}
						}
						if (type == 41 && timeLeft > 1)
						{
							timeLeft = 1;
						}
						bool flag3 = false;
						if (melee && Main.rand.Next(1, 101) <= Main.player[owner].meleeCrit)
						{
							flag3 = true;
						}
						int num14 = Main.DamageVar(damage);
						if (!Main.player[l].immune)
						{
							StatusPvP(l);
						}
						if (type != 221 && type != 227)
						{
							Main.player[owner].onHit(Main.player[l].center().X, Main.player[l].center().Y);
						}
						int num15 = (int)Main.player[l].Hurt(num14, direction, true, false, Lang.deathMsg(owner, -1, whoAmI), flag3);
						if (num15 > 0 && Main.player[owner].ghostHeal && friendly && !hostile)
						{
							ghostHeal(num15, new Vector2(Main.player[l].center().X, Main.player[l].center().Y));
						}
						if (type == 304 && num15 > 0)
						{
							vampireHeal(num15, new Vector2(Main.player[l].center().X, Main.player[l].center().Y));
						}
						if (melee && Main.player[owner].meleeEnchant == 7)
						{
							NewProjectile(Main.player[l].center().X, Main.player[l].center().Y, Main.player[l].velocity.X, Main.player[l].velocity.Y, 289, 0, 0f, owner);
						}
						if (Main.netMode != 0)
						{
							if (flag3)
							{
								NetMessage.SendData(26, -1, -1, Lang.deathMsg(owner, -1, whoAmI), l, direction, num14, 1f, 1);
							}
							else
							{
								NetMessage.SendData(26, -1, -1, Lang.deathMsg(owner, -1, whoAmI), l, direction, num14, 1f);
							}
						}
						playerImmune[l] = 40;
						if (penetrate > 0)
						{
							penetrate--;
							if (penetrate == 0)
							{
								break;
							}
						}
						if (aiStyle == 7)
						{
							ai[0] = 1f;
							damage = 0;
							netUpdate = true;
						}
						else if (aiStyle == 13)
						{
							ai[0] = 1f;
							netUpdate = true;
						}
						else if (aiStyle == 69)
						{
							ai[0] = 1f;
							netUpdate = true;
						}
					}
				}
			}
			if (type == 11 && Main.netMode != 1)
			{
				for (int m = 0; m < 200; m++)
				{
					if (!Main.npc[m].active)
					{
						continue;
					}
					if (Main.npc[m].type == 46)
					{
						Rectangle value4 = new Rectangle((int)Main.npc[m].position.X, (int)Main.npc[m].position.Y, Main.npc[m].width, Main.npc[m].height);
						if (rectangle.Intersects(value4))
						{
							Main.npc[m].Transform(47);
						}
					}
					else if (Main.npc[m].type == 55)
					{
						Rectangle value5 = new Rectangle((int)Main.npc[m].position.X, (int)Main.npc[m].position.Y, Main.npc[m].width, Main.npc[m].height);
						if (rectangle.Intersects(value5))
						{
							Main.npc[m].Transform(57);
						}
					}
				}
			}
			if (Main.netMode == 2 || !hostile || Main.myPlayer >= 255 || damage <= 0)
			{
				return;
			}
			int myPlayer2 = Main.myPlayer;
			if (!Main.player[myPlayer2].active || Main.player[myPlayer2].dead || Main.player[myPlayer2].immune)
			{
				return;
			}
			Rectangle value6 = new Rectangle((int)Main.player[myPlayer2].position.X, (int)Main.player[myPlayer2].position.Y, Main.player[myPlayer2].width, Main.player[myPlayer2].height);
			if (rectangle.Intersects(value6))
			{
				int num16 = direction;
				num16 = ((!(Main.player[myPlayer2].position.X + (float)(Main.player[myPlayer2].width / 2) < position.X + (float)(width / 2))) ? 1 : (-1));
				int num17 = Main.DamageVar(damage);
				if (!Main.player[myPlayer2].immune)
				{
					StatusPlayer(myPlayer2);
				}
				if (Main.player[myPlayer2].resistCold && coldDamage)
				{
					num17 = (int)((float)num17 * 0.7f);
				}
				Main.player[myPlayer2].Hurt(num17 * 2, num16, false, false, Lang.deathMsg(-1, -1, whoAmI));
			}
		}

		public void ProjLight()
		{
			if (!(light > 0f))
			{
				return;
			}
			float num = light;
			float num2 = light;
			float num3 = light;
			if (type == 332)
			{
				num3 *= 0.1f;
				num2 *= 0.6f;
			}
			else if (type == 259)
			{
				num3 *= 0.1f;
			}
			else if (type == 329)
			{
				num3 *= 0.1f;
				num2 *= 0.9f;
			}
			else if (type == 2 || type == 82)
			{
				num2 *= 0.75f;
				num3 *= 0.55f;
			}
			else if (type == 172)
			{
				num2 *= 0.55f;
				num *= 0.35f;
			}
			else if (type == 308)
			{
				num2 *= 0.7f;
				num *= 0.1f;
			}
			else if (type == 304)
			{
				num2 *= 0.2f;
				num3 *= 0.1f;
			}
			else if (type == 263)
			{
				num2 *= 0.7f;
				num *= 0.1f;
			}
			else if (type == 274)
			{
				num2 *= 0.1f;
				num *= 0.7f;
			}
			else if (type == 254)
			{
				num *= 0.1f;
			}
			else if (type == 94)
			{
				num *= 0.5f;
				num2 *= 0f;
			}
			else if (type == 95 || type == 96 || type == 103 || type == 104)
			{
				num *= 0.35f;
				num2 *= 1f;
				num3 *= 0f;
			}
			else if (type == 4)
			{
				num2 *= 0.1f;
				num *= 0.5f;
			}
			else if (type == 257)
			{
				num2 *= 0.9f;
				num *= 0.1f;
			}
			else if (type == 9)
			{
				num2 *= 0.1f;
				num3 *= 0.6f;
			}
			else if (type == 92)
			{
				num2 *= 0.6f;
				num *= 0.8f;
			}
			else if (type == 93)
			{
				num2 *= 1f;
				num *= 1f;
				num3 *= 0.01f;
			}
			else if (type == 12)
			{
				num *= 0.9f;
				num2 *= 0.8f;
				num3 *= 0.1f;
			}
			else if (type == 14 || type == 110 || type == 180 || type == 242 || type == 302)
			{
				num2 *= 0.7f;
				num3 *= 0.1f;
			}
			else if (type == 15)
			{
				num2 *= 0.4f;
				num3 *= 0.1f;
				num = 1f;
			}
			else if (type == 16)
			{
				num *= 0.1f;
				num2 *= 0.4f;
				num3 = 1f;
			}
			else if (type == 18)
			{
				num2 *= 0.1f;
				num *= 0.6f;
			}
			else if (type == 19)
			{
				num2 *= 0.5f;
				num3 *= 0.1f;
			}
			else if (type == 20)
			{
				num *= 0.1f;
				num3 *= 0.3f;
			}
			else if (type == 22)
			{
				num = 0f;
				num2 = 0f;
			}
			else if (type == 27)
			{
				num *= 0f;
				num2 *= 0.3f;
				num3 = 1f;
			}
			else if (type == 34)
			{
				num2 *= 0.1f;
				num3 *= 0.1f;
			}
			else if (type == 36)
			{
				num = 0.8f;
				num2 *= 0.2f;
				num3 *= 0.6f;
			}
			else if (type == 41)
			{
				num2 *= 0.8f;
				num3 *= 0.6f;
			}
			else if (type == 44 || type == 45)
			{
				num3 = 1f;
				num *= 0.6f;
				num2 *= 0.1f;
			}
			else if (type == 50)
			{
				num *= 0.7f;
				num3 *= 0.8f;
			}
			else if (type == 53)
			{
				num *= 0.7f;
				num2 *= 0.8f;
			}
			else if (type == 72)
			{
				num *= 0.45f;
				num2 *= 0.75f;
				num3 = 1f;
			}
			else if (type == 86)
			{
				num *= 1f;
				num2 *= 0.45f;
				num3 = 0.75f;
			}
			else if (type == 87)
			{
				num *= 0.45f;
				num2 = 1f;
				num3 *= 0.75f;
			}
			else if (type == 73)
			{
				num *= 0.4f;
				num2 *= 0.6f;
				num3 *= 1f;
			}
			else if (type == 74)
			{
				num *= 1f;
				num2 *= 0.4f;
				num3 *= 0.6f;
			}
			else if (type == 284)
			{
				num *= 1f;
				num2 *= 0.1f;
				num3 *= 0.8f;
			}
			else if (type == 285)
			{
				num *= 0.1f;
				num2 *= 0.5f;
				num3 *= 1f;
			}
			else if (type == 286)
			{
				num *= 1f;
				num2 *= 0.5f;
				num3 *= 0.1f;
			}
			else if (type == 287)
			{
				num *= 0.9f;
				num2 *= 1f;
				num3 *= 0.4f;
			}
			else if (type == 283)
			{
				num *= 0.8f;
				num2 *= 0.1f;
			}
			else if (type == 76 || type == 77 || type == 78)
			{
				num *= 1f;
				num2 *= 0.3f;
				num3 *= 0.6f;
			}
			else if (type == 79)
			{
				num = (float)Main.DiscoR / 255f;
				num2 = (float)Main.DiscoG / 255f;
				num3 = (float)Main.DiscoB / 255f;
			}
			else if (type == 80)
			{
				num *= 0f;
				num2 *= 0.8f;
				num3 *= 1f;
			}
			else if (type == 83 || type == 88)
			{
				num *= 0.7f;
				num2 *= 0f;
				num3 *= 1f;
			}
			else if (type == 100)
			{
				num *= 1f;
				num2 *= 0.5f;
				num3 *= 0f;
			}
			else if (type == 84 || type == 389)
			{
				num *= 0.8f;
				num2 *= 0f;
				num3 *= 0.5f;
			}
			else if (type == 89 || type == 90)
			{
				num2 *= 0.2f;
				num3 *= 1f;
				num *= 0.05f;
			}
			else if (type == 106)
			{
				num *= 0f;
				num2 *= 0.5f;
				num3 *= 1f;
			}
			else if (type == 113)
			{
				num *= 0.25f;
				num2 *= 0.75f;
				num3 *= 1f;
			}
			else if (type == 114 || type == 115)
			{
				num *= 0.5f;
				num2 *= 0.05f;
				num3 *= 1f;
			}
			else if (type == 116)
			{
				num3 *= 0.25f;
			}
			else if (type == 131)
			{
				num *= 0.1f;
				num2 *= 0.4f;
			}
			else if (type == 132 || type == 157)
			{
				num *= 0.2f;
				num3 *= 0.6f;
			}
			else if (type == 156)
			{
				num *= 1f;
				num3 *= 0.6f;
				num2 = 0f;
			}
			else if (type == 173)
			{
				num *= 0.3f;
				num3 *= 1f;
				num2 = 0.4f;
			}
			else if (type == 207)
			{
				num *= 0.4f;
				num3 *= 0.4f;
			}
			else if (type == 253)
			{
				num = 0f;
				num2 *= 0.4f;
			}
			else if (type == 211)
			{
				num *= 0.5f;
				num2 *= 0.9f;
				num3 *= 1f;
				if (localAI[0] == 0f)
				{
					light = 1.5f;
				}
				else
				{
					light = 1f;
				}
			}
			else if (type == 209)
			{
				float num4 = (255f - (float)alpha) / 255f;
				num *= 0.3f;
				num2 *= 0.4f;
				num3 *= 1.75f;
				num3 *= num4;
				num *= num4;
				num2 *= num4;
			}
			else if (type == 226 || ((type == 227) | (type == 229)))
			{
				num *= 0.25f;
				num2 *= 1f;
				num3 *= 0.5f;
			}
			else if (type == 251)
			{
				num = (float)Main.DiscoR / 255f;
				num2 = (float)Main.DiscoG / 255f;
				num3 = (float)Main.DiscoB / 255f;
				num = (num + 1f) / 2f;
				num2 = (num2 + 1f) / 2f;
				num3 = (num3 + 1f) / 2f;
				num *= light;
				num2 *= light;
				num3 *= light;
			}
			else if (type == 278 || type == 279)
			{
				num *= 1f;
				num2 *= 1f;
				num3 *= 0f;
			}
			Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), num, num2, num3);
		}

		public Vector2 center()
		{
			return new Vector2(position.X + (float)(width / 2), position.Y + (float)(height / 2));
		}

		public Rectangle getRect()
		{
			return new Rectangle((int)position.X, (int)position.Y, width, height);
		}

		public void Update(int i)
		{
			if (!active)
			{
				return;
			}
			if (type != 344)
			{
				if (Main.player[owner].frostBurn && (melee || ranged) && friendly && !hostile && !noEnchantments && Main.rand.Next(2 * (1 + maxUpdates)) == 0)
				{
					int num = Dust.NewDust(position, width, height, 135, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 2f);
					Main.dust[num].noGravity = true;
					Main.dust[num].velocity *= 0.7f;
					Main.dust[num].velocity.Y -= 0.5f;
				}
				if (melee && Main.player[owner].meleeEnchant > 0 && !noEnchantments)
				{
					if (Main.player[owner].meleeEnchant == 1 && Main.rand.Next(3) == 0)
					{
						int num2 = Dust.NewDust(position, width, height, 171, 0f, 0f, 100);
						Main.dust[num2].noGravity = true;
						Main.dust[num2].fadeIn = 1.5f;
						Main.dust[num2].velocity *= 0.25f;
					}
					if (Main.player[owner].meleeEnchant == 1)
					{
						if (Main.rand.Next(3) == 0)
						{
							int num3 = Dust.NewDust(position, width, height, 171, 0f, 0f, 100);
							Main.dust[num3].noGravity = true;
							Main.dust[num3].fadeIn = 1.5f;
							Main.dust[num3].velocity *= 0.25f;
						}
					}
					else if (Main.player[owner].meleeEnchant == 2)
					{
						if (Main.rand.Next(2) == 0)
						{
							int num4 = Dust.NewDust(position, width, height, 75, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 2.5f);
							Main.dust[num4].noGravity = true;
							Main.dust[num4].velocity *= 0.7f;
							Main.dust[num4].velocity.Y -= 0.5f;
						}
					}
					else if (Main.player[owner].meleeEnchant == 3)
					{
						if (Main.rand.Next(2) == 0)
						{
							int num5 = Dust.NewDust(position, width, height, 6, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 2.5f);
							Main.dust[num5].noGravity = true;
							Main.dust[num5].velocity *= 0.7f;
							Main.dust[num5].velocity.Y -= 0.5f;
						}
					}
					else if (Main.player[owner].meleeEnchant == 4)
					{
						int num6 = 0;
						if (Main.rand.Next(2) == 0)
						{
							num6 = Dust.NewDust(position, width, height, 57, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 1.1f);
							Main.dust[num6].noGravity = true;
							Main.dust[num6].velocity.X /= 2f;
							Main.dust[num6].velocity.Y /= 2f;
						}
					}
					else if (Main.player[owner].meleeEnchant == 5)
					{
						if (Main.rand.Next(2) == 0)
						{
							int num7 = Dust.NewDust(position, width, height, 169, 0f, 0f, 100);
							Main.dust[num7].velocity.X += direction;
							Main.dust[num7].velocity.Y += 0.2f;
							Main.dust[num7].noGravity = true;
						}
					}
					else if (Main.player[owner].meleeEnchant == 6)
					{
						if (Main.rand.Next(2) == 0)
						{
							int num8 = Dust.NewDust(position, width, height, 135, 0f, 0f, 100);
							Main.dust[num8].velocity.X += direction;
							Main.dust[num8].velocity.Y += 0.2f;
							Main.dust[num8].noGravity = true;
						}
					}
					else if (Main.player[owner].meleeEnchant == 7)
					{
						if (Main.rand.Next(20) == 0)
						{
							int num9 = Main.rand.Next(139, 143);
							int num10 = Dust.NewDust(position, width, height, num9, velocity.X, velocity.Y, 0, default(Color), 1.2f);
							Main.dust[num10].velocity.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
							Main.dust[num10].velocity.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
							Main.dust[num10].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
							Main.dust[num10].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
							Main.dust[num10].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
						}
						if (Main.rand.Next(40) == 0)
						{
							int num11 = Main.rand.Next(276, 283);
							int num12 = Gore.NewGore(position, velocity, num11);
							Main.gore[num12].velocity.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
							Main.gore[num12].velocity.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
							Main.gore[num12].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
							Main.gore[num12].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
							Main.gore[num12].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
						}
					}
					else if (Main.player[owner].meleeEnchant == 8 && Main.rand.Next(4) == 0)
					{
						int num13 = Dust.NewDust(position, width, height, 46, 0f, 0f, 100);
						Main.dust[num13].noGravity = true;
						Main.dust[num13].fadeIn = 1.5f;
						Main.dust[num13].velocity *= 0.25f;
					}
				}
				if (melee && Main.player[owner].magmaStone && !noEnchantments && Main.rand.Next(3) != 0)
				{
					int num14 = Dust.NewDust(new Vector2(position.X - 4f, position.Y - 4f), width + 8, height + 8, 6, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num14].scale = 1.5f;
					}
					Main.dust[num14].noGravity = true;
					Main.dust[num14].velocity.X *= 2f;
					Main.dust[num14].velocity.Y *= 2f;
				}
			}
			if (minion && numUpdates == 0)
			{
				minionPos = Main.player[owner].numMinions;
				if (Main.player[owner].slotsMinions + minionSlots > (float)Main.player[owner].maxMinions && owner == Main.myPlayer)
				{
					Kill();
				}
				else
				{
					Main.player[owner].numMinions++;
					Main.player[owner].slotsMinions += minionSlots;
				}
			}
			lastVelocity = velocity;
			float num15 = 1f + Math.Abs(velocity.X) / 3f;
			if (gfxOffY > 0f)
			{
				gfxOffY -= num15 * stepSpeed;
				if (gfxOffY < 0f)
				{
					gfxOffY = 0f;
				}
			}
			else if (gfxOffY < 0f)
			{
				gfxOffY += num15 * stepSpeed;
				if (gfxOffY > 0f)
				{
					gfxOffY = 0f;
				}
			}
			if (gfxOffY > 16f)
			{
				gfxOffY = 16f;
			}
			if (gfxOffY < -16f)
			{
				gfxOffY = -16f;
			}
			Vector2 vector = velocity;
			if (position.X <= Main.leftWorld || position.X + (float)width >= Main.rightWorld || position.Y <= Main.topWorld || position.Y + (float)height >= Main.bottomWorld)
			{
				active = false;
				return;
			}
			whoAmI = i;
			if (soundDelay > 0)
			{
				soundDelay--;
			}
			netUpdate = false;
			for (int j = 0; j < 255; j++)
			{
				if (playerImmune[j] > 0)
				{
					playerImmune[j]--;
				}
			}
			AI();
			if (owner < 255 && !Main.player[owner].active)
			{
				Kill();
			}
			if (type == 242 || type == 302)
			{
				wet = false;
			}
			if (!ignoreWater)
			{
				bool flag;
				bool flag2;
				try
				{
					flag = Collision.LavaCollision(position, width, height);
					flag2 = Collision.WetCollision(position, width, height);
					if (flag)
					{
						lavaWet = true;
					}
					if (Collision.honey)
					{
						honeyWet = true;
					}
				}
				catch
				{
					active = false;
					return;
				}
				if (wet && !lavaWet)
				{
					if (type == 85 || type == 15 || type == 34 || type == 188)
					{
						Kill();
					}
					if (type == 2)
					{
						type = 1;
						light = 0f;
					}
				}
				if (type == 80)
				{
					flag2 = false;
					wet = false;
					if (flag && ai[0] >= 0f)
					{
						Kill();
					}
				}
				if (flag2)
				{
					if (type != 155 && wetCount == 0 && !wet)
					{
						if (!flag)
						{
							if (honeyWet)
							{
								for (int k = 0; k < 10; k++)
								{
									int num16 = Dust.NewDust(new Vector2(position.X - 6f, position.Y + (float)(height / 2) - 8f), width + 12, 24, 152);
									Main.dust[num16].velocity.Y -= 1f;
									Main.dust[num16].velocity.X *= 2.5f;
									Main.dust[num16].scale = 1.3f;
									Main.dust[num16].alpha = 100;
									Main.dust[num16].noGravity = true;
								}
								Main.PlaySound(19, (int)position.X, (int)position.Y);
							}
							else
							{
								for (int l = 0; l < 10; l++)
								{
									int num17 = Dust.NewDust(new Vector2(position.X - 6f, position.Y + (float)(height / 2) - 8f), width + 12, 24, Dust.dustWater());
									Main.dust[num17].velocity.Y -= 4f;
									Main.dust[num17].velocity.X *= 2.5f;
									Main.dust[num17].scale = 1.3f;
									Main.dust[num17].alpha = 100;
									Main.dust[num17].noGravity = true;
								}
								Main.PlaySound(19, (int)position.X, (int)position.Y);
							}
						}
						else
						{
							for (int m = 0; m < 10; m++)
							{
								int num18 = Dust.NewDust(new Vector2(position.X - 6f, position.Y + (float)(height / 2) - 8f), width + 12, 24, 35);
								Main.dust[num18].velocity.Y -= 1.5f;
								Main.dust[num18].velocity.X *= 2.5f;
								Main.dust[num18].scale = 1.3f;
								Main.dust[num18].alpha = 100;
								Main.dust[num18].noGravity = true;
							}
							Main.PlaySound(19, (int)position.X, (int)position.Y);
						}
					}
					wet = true;
				}
				else if (wet)
				{
					wet = false;
					if (type == 155)
					{
						velocity.Y *= 0.5f;
					}
					else if (wetCount == 0)
					{
						wetCount = 10;
						if (!lavaWet)
						{
							if (honeyWet)
							{
								for (int n = 0; n < 10; n++)
								{
									int num19 = Dust.NewDust(new Vector2(position.X - 6f, position.Y + (float)(height / 2) - 8f), width + 12, 24, 152);
									Main.dust[num19].velocity.Y -= 1f;
									Main.dust[num19].velocity.X *= 2.5f;
									Main.dust[num19].scale = 1.3f;
									Main.dust[num19].alpha = 100;
									Main.dust[num19].noGravity = true;
								}
								Main.PlaySound(19, (int)position.X, (int)position.Y);
							}
							else
							{
								for (int num20 = 0; num20 < 10; num20++)
								{
									int num21 = Dust.NewDust(new Vector2(position.X - 6f, position.Y + (float)(height / 2)), width + 12, 24, Dust.dustWater());
									Main.dust[num21].velocity.Y -= 4f;
									Main.dust[num21].velocity.X *= 2.5f;
									Main.dust[num21].scale = 1.3f;
									Main.dust[num21].alpha = 100;
									Main.dust[num21].noGravity = true;
								}
								Main.PlaySound(19, (int)position.X, (int)position.Y);
							}
						}
						else
						{
							for (int num22 = 0; num22 < 10; num22++)
							{
								int num23 = Dust.NewDust(new Vector2(position.X - 6f, position.Y + (float)(height / 2) - 8f), width + 12, 24, 35);
								Main.dust[num23].velocity.Y -= 1.5f;
								Main.dust[num23].velocity.X *= 2.5f;
								Main.dust[num23].scale = 1.3f;
								Main.dust[num23].alpha = 100;
								Main.dust[num23].noGravity = true;
							}
							Main.PlaySound(19, (int)position.X, (int)position.Y);
						}
					}
				}
				if (!wet)
				{
					lavaWet = false;
					honeyWet = false;
				}
				if (wetCount > 0)
				{
					wetCount--;
				}
			}
			lastPosition = position;
			bool flag3 = false;
			if (tileCollide)
			{
				Vector2 vector2 = velocity;
				bool flag4 = true;
				if (type == 9 || type == 12 || type == 15 || type == 13 || type == 31 || type == 39 || type == 40)
				{
					flag4 = false;
				}
				if (Main.projPet[type])
				{
					flag4 = false;
					if (Main.player[owner].position.Y + (float)Main.player[owner].height - 12f > position.Y + (float)height)
					{
						flag4 = true;
					}
				}
				if (type == 317)
				{
					flag4 = true;
				}
				if (type == 373)
				{
					flag4 = true;
				}
				if (aiStyle == 10)
				{
					if (type == 42 || type == 65 || type == 68 || type == 354 || (type == 31 && ai[0] == 2f))
					{
						velocity = Collision.TileCollision(position, velocity, width, height, flag4, flag4);
					}
					else
					{
						velocity = Collision.AnyCollision(position, velocity, width, height);
					}
				}
				else if (aiStyle == 29)
				{
					int num24 = width - 8;
					int num25 = height - 8;
					Vector2 vector3 = new Vector2(position.X + (float)(width / 2) - (float)(num24 / 2), position.Y + (float)(height / 2) - (float)(num25 / 2));
					velocity = Collision.TileCollision(vector3, velocity, num24, num25, flag4, flag4);
				}
				else if (aiStyle == 49)
				{
					int num26 = width - 8;
					int num27 = height - 8;
					Vector2 vector4 = new Vector2(position.X + (float)(width / 2) - (float)(num26 / 2), position.Y + (float)(height / 2) - (float)(num27 / 2));
					velocity = Collision.TileCollision(vector4, velocity, num26, num27, flag4, flag4);
				}
				else if (type == 250 || type == 267 || type == 297 || type == 323)
				{
					int num28 = 2;
					int num29 = 2;
					Vector2 vector5 = new Vector2(position.X + (float)(width / 2) - (float)(num28 / 2), position.Y + (float)(height / 2) - (float)(num29 / 2));
					velocity = Collision.TileCollision(vector5, velocity, num28, num29, flag4, flag4);
				}
				else if (type == 308)
				{
					int num30 = 26;
					int num31 = height;
					Vector2 vector6 = new Vector2(position.X + (float)(width / 2) - (float)(num30 / 2), position.Y + (float)(height / 2) - (float)(num31 / 2));
					velocity = Collision.TileCollision(vector6, velocity, num30, num31, flag4, flag4);
				}
				else if (type == 261 || type == 277)
				{
					int num32 = 26;
					int num33 = 26;
					Vector2 vector7 = new Vector2(position.X + (float)(width / 2) - (float)(num32 / 2), position.Y + (float)(height / 2) - (float)(num33 / 2));
					velocity = Collision.TileCollision(vector7, velocity, num32, num33, flag4, flag4);
				}
				else if (type == 106 || type == 262 || type == 271 || type == 270 || type == 272 || type == 273 || type == 274 || type == 280 || type == 288 || type == 301 || type == 320 || type == 333 || type == 335 || type == 343 || type == 344)
				{
					int num34 = 10;
					int num35 = 10;
					Vector2 vector8 = new Vector2(position.X + (float)(width / 2) - (float)(num34 / 2), position.Y + (float)(height / 2) - (float)(num35 / 2));
					velocity = Collision.TileCollision(vector8, velocity, num34, num35, flag4, flag4);
				}
				else if (type == 248 || type == 247)
				{
					int num36 = width - 12;
					int num37 = height - 12;
					Vector2 vector9 = new Vector2(position.X + (float)(width / 2) - (float)(num36 / 2), position.Y + (float)(height / 2) - (float)(num37 / 2));
					velocity = Collision.TileCollision(vector9, velocity, num36, num37, flag4, flag4);
				}
				else if (aiStyle == 18 || type == 254)
				{
					int num38 = width - 36;
					int num39 = height - 36;
					Vector2 vector10 = new Vector2(position.X + (float)(width / 2) - (float)(num38 / 2), position.Y + (float)(height / 2) - (float)(num39 / 2));
					velocity = Collision.TileCollision(vector10, velocity, num38, num39, flag4, flag4);
				}
				else if (type == 182 || type == 190 || type == 33 || type == 229 || type == 237 || type == 243)
				{
					int num40 = width - 20;
					int num41 = height - 20;
					Vector2 vector11 = new Vector2(position.X + (float)(width / 2) - (float)(num40 / 2), position.Y + (float)(height / 2) - (float)(num41 / 2));
					velocity = Collision.TileCollision(vector11, velocity, num40, num41, flag4, flag4);
				}
				else if (aiStyle == 27)
				{
					int num42 = 6;
					velocity = Collision.TileCollision(new Vector2(position.X + (float)num42, position.Y + (float)num42), velocity, width - num42 * 2, height - num42 * 2, flag4, flag4);
				}
				else if (wet)
				{
					if (honeyWet)
					{
						Vector2 vector12 = velocity;
						velocity = Collision.TileCollision(position, velocity, width, height, flag4, flag4);
						vector = velocity * 0.25f;
						if (velocity.X != vector12.X)
						{
							vector.X = velocity.X;
						}
						if (velocity.Y != vector12.Y)
						{
							vector.Y = velocity.Y;
						}
					}
					else
					{
						Vector2 vector13 = velocity;
						velocity = Collision.TileCollision(position, velocity, width, height, flag4, flag4);
						vector = velocity * 0.5f;
						if (velocity.X != vector13.X)
						{
							vector.X = velocity.X;
						}
						if (velocity.Y != vector13.Y)
						{
							vector.Y = velocity.Y;
						}
					}
				}
				else
				{
					velocity = Collision.TileCollision(position, velocity, width, height, flag4, flag4);
					if (!Main.projPet[type])
					{
						Vector4 vector14 = Collision.SlopeCollision(position, velocity, width, height, 0f, true);
						if (position.X != vector14.X)
						{
							flag3 = true;
						}
						if (position.Y != vector14.Y)
						{
							flag3 = true;
						}
						if (velocity.X != vector14.Z)
						{
							flag3 = true;
						}
						if (velocity.Y != vector14.W)
						{
							flag3 = true;
						}
						position.X = vector14.X;
						position.Y = vector14.Y;
						velocity.X = vector14.Z;
						velocity.Y = vector14.W;
					}
				}
				if (vector2 != velocity)
				{
					flag3 = true;
				}
				if (flag3)
				{
					if (aiStyle == 54)
					{
						if (velocity.X != vector2.X)
						{
							velocity.X = vector2.X * -0.6f;
						}
						if (velocity.Y != vector2.Y)
						{
							velocity.Y = vector2.Y * -0.6f;
						}
					}
					else if (!Main.projPet[type])
					{
						if (type == 379)
						{
							if (velocity.X != vector2.X)
							{
								velocity.X = vector2.X * -0.6f;
							}
							if (velocity.Y != vector2.Y && vector2.Y > 2f)
							{
								velocity.Y = vector2.Y * -0.6f;
							}
						}
						else if (type == 409)
						{
							if (velocity.X != vector2.X)
							{
								velocity.X = vector2.X * -1f;
							}
							if (velocity.Y != vector2.Y)
							{
								velocity.Y = vector2.Y * -1f;
							}
						}
						else if (type == 254)
						{
							tileCollide = false;
							velocity = lastVelocity;
							if (timeLeft > 30)
							{
								timeLeft = 30;
							}
						}
						else if (type == 225 && penetrate > 0)
						{
							velocity.X = 0f - vector2.X;
							velocity.Y = 0f - vector2.Y;
							penetrate--;
						}
						else if (type == 155)
						{
							if (ai[1] > 10f)
							{
								string text = name + " was hit " + ai[1] + " times before touching the ground!";
								if (Main.netMode == 0)
								{
									Main.NewText(text, byte.MaxValue, 240, 20);
								}
								else if (Main.netMode == 2)
								{
									NetMessage.SendData(25, -1, -1, text, 255, 255f, 240f, 20f);
								}
							}
							ai[1] = 0f;
							if (velocity.X != vector2.X)
							{
								velocity.X = vector2.X * -0.6f;
							}
							if (velocity.Y != vector2.Y && vector2.Y > 2f)
							{
								velocity.Y = vector2.Y * -0.6f;
							}
						}
						else if (aiStyle == 33)
						{
							if (localAI[0] == 0f)
							{
								if (wet)
								{
									position += vector2 / 2f;
								}
								else
								{
									position += vector2;
								}
								velocity *= 0f;
								localAI[0] = 1f;
							}
						}
						else if (type != 308)
						{
							if (type == 94)
							{
								if (velocity.X != vector2.X)
								{
									velocity.X = 0f - vector2.X;
								}
								if (velocity.Y != vector2.Y)
								{
									velocity.Y = 0f - vector2.Y;
								}
							}
							else if (type == 311)
							{
								if (velocity.X != vector2.X)
								{
									velocity.X = 0f - vector2.X;
									ai[1] += 1f;
								}
								if (velocity.Y != vector2.Y)
								{
									velocity.Y = 0f - vector2.Y;
									ai[1] += 1f;
								}
								if (ai[1] > 4f)
								{
									Kill();
								}
							}
							else if (type == 312)
							{
								if (velocity.X != vector2.X)
								{
									velocity.X = 0f - vector2.X;
									ai[1] += 1f;
								}
								if (velocity.Y != vector2.Y)
								{
									velocity.Y = 0f - vector2.Y;
									ai[1] += 1f;
								}
							}
							else if (type == 281)
							{
								float num43 = Math.Abs(velocity.X) + Math.Abs(velocity.Y);
								if (num43 < 2f || ai[1] == 2f)
								{
									ai[1] = 2f;
								}
								else
								{
									if (velocity.X != vector2.X)
									{
										velocity.X = (0f - vector2.X) * 0.5f;
									}
									if (velocity.Y != vector2.Y)
									{
										velocity.Y = (0f - vector2.Y) * 0.5f;
									}
								}
							}
							else if (type == 290 || type == 294)
							{
								if (velocity.X != vector2.X)
								{
									position.X += velocity.X;
									velocity.X = 0f - vector2.X;
								}
								if (velocity.Y != vector2.Y)
								{
									position.Y += velocity.Y;
									velocity.Y = 0f - vector2.Y;
								}
							}
							else if ((type == 181 || type == 189 || type == 357) && penetrate > 0)
							{
								if (type == 357)
								{
									damage = (int)((double)damage * 0.9);
								}
								penetrate--;
								if (velocity.X != vector2.X)
								{
									velocity.X = 0f - vector2.X;
								}
								if (velocity.Y != vector2.Y)
								{
									velocity.Y = 0f - vector2.Y;
								}
							}
							else if (type == 307 && ai[1] < 5f)
							{
								ai[1] += 1f;
								if (velocity.X != vector2.X)
								{
									velocity.X = 0f - vector2.X;
								}
								if (velocity.Y != vector2.Y)
								{
									velocity.Y = 0f - vector2.Y;
								}
							}
							else if (type == 99)
							{
								if (velocity.Y != vector2.Y && vector2.Y > 5f)
								{
									Collision.HitTiles(position, velocity, width, height);
									Main.PlaySound(0, (int)position.X, (int)position.Y);
									velocity.Y = (0f - vector2.Y) * 0.2f;
								}
								if (velocity.X != vector2.X)
								{
									Kill();
								}
							}
							else if (type == 36)
							{
								if (penetrate > 1)
								{
									Collision.HitTiles(position, velocity, width, height);
									Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
									penetrate--;
									if (velocity.X != vector2.X)
									{
										velocity.X = 0f - vector2.X;
									}
									if (velocity.Y != vector2.Y)
									{
										velocity.Y = 0f - vector2.Y;
									}
								}
								else
								{
									Kill();
								}
							}
							else if (aiStyle == 21)
							{
								if (velocity.X != vector2.X)
								{
									velocity.X = 0f - vector2.X;
								}
								if (velocity.Y != vector2.Y)
								{
									velocity.Y = 0f - vector2.Y;
								}
							}
							else if (aiStyle == 17)
							{
								if (velocity.X != vector2.X)
								{
									velocity.X = vector2.X * -0.75f;
								}
								if (velocity.Y != vector2.Y && (double)vector2.Y > 1.5)
								{
									velocity.Y = vector2.Y * -0.7f;
								}
							}
							else if (aiStyle == 15)
							{
								bool flag5 = false;
								if (vector2.X != velocity.X)
								{
									if (Math.Abs(vector2.X) > 4f)
									{
										flag5 = true;
									}
									position.X += velocity.X;
									velocity.X = (0f - vector2.X) * 0.2f;
								}
								if (vector2.Y != velocity.Y)
								{
									if (Math.Abs(vector2.Y) > 4f)
									{
										flag5 = true;
									}
									position.Y += velocity.Y;
									velocity.Y = (0f - vector2.Y) * 0.2f;
								}
								ai[0] = 1f;
								if (flag5)
								{
									netUpdate = true;
									Collision.HitTiles(position, velocity, width, height);
									Main.PlaySound(0, (int)position.X, (int)position.Y);
								}
								if (wet)
								{
									vector = velocity;
								}
							}
							else if (aiStyle == 39)
							{
								Collision.HitTiles(position, velocity, width, height);
								if (type == 33 || type == 106)
								{
									if (velocity.X != vector2.X)
									{
										velocity.X = 0f - vector2.X;
									}
									if (velocity.Y != vector2.Y)
									{
										velocity.Y = 0f - vector2.Y;
									}
								}
								else
								{
									ai[0] = 1f;
									if (aiStyle == 3)
									{
										velocity.X = 0f - vector2.X;
										velocity.Y = 0f - vector2.Y;
									}
								}
								netUpdate = true;
								Main.PlaySound(0, (int)position.X, (int)position.Y);
							}
							else if (aiStyle == 3 || aiStyle == 13 || aiStyle == 69)
							{
								Collision.HitTiles(position, velocity, width, height);
								if (type == 33 || type == 106)
								{
									if (velocity.X != vector2.X)
									{
										velocity.X = 0f - vector2.X;
									}
									if (velocity.Y != vector2.Y)
									{
										velocity.Y = 0f - vector2.Y;
									}
								}
								else
								{
									ai[0] = 1f;
									if (aiStyle == 3 && type != 383)
									{
										velocity.X = 0f - vector2.X;
										velocity.Y = 0f - vector2.Y;
									}
								}
								netUpdate = true;
								Main.PlaySound(0, (int)position.X, (int)position.Y);
							}
							else if (aiStyle == 8 && type != 96)
							{
								Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
								ai[0] += 1f;
								if ((ai[0] >= 5f && type != 253) || (type == 253 && ai[0] >= 8f))
								{
									position += velocity;
									Kill();
								}
								else
								{
									if (type == 15 && velocity.Y > 4f)
									{
										if (velocity.Y != vector2.Y)
										{
											velocity.Y = (0f - vector2.Y) * 0.8f;
										}
									}
									else if (velocity.Y != vector2.Y)
									{
										velocity.Y = 0f - vector2.Y;
									}
									if (velocity.X != vector2.X)
									{
										velocity.X = 0f - vector2.X;
									}
								}
							}
							else if (aiStyle == 61)
							{
								if (velocity.X != vector2.X)
								{
									velocity.X = vector2.X * -0.3f;
								}
								if (velocity.Y != vector2.Y && vector2.Y > 1f)
								{
									velocity.Y = vector2.Y * -0.3f;
								}
							}
							else if (aiStyle == 14)
							{
								if (type == 261 && ((velocity.X != vector2.X && (vector2.X < -3f || vector2.X > 3f)) || (velocity.Y != vector2.Y && (vector2.Y < -3f || vector2.Y > 3f))))
								{
									Collision.HitTiles(position, velocity, width, height);
									Main.PlaySound(0, (int)center().X, (int)center().Y);
								}
								if (type >= 326 && type <= 328 && velocity.X != vector2.X)
								{
									velocity.X = vector2.X * -0.1f;
								}
								if (type >= 400 && type <= 402)
								{
									if (velocity.X != vector2.X)
									{
										velocity.X = vector2.X * -0.1f;
									}
								}
								else if (type == 50)
								{
									if (velocity.X != vector2.X)
									{
										velocity.X = vector2.X * -0.2f;
									}
									if (velocity.Y != vector2.Y && (double)vector2.Y > 1.5)
									{
										velocity.Y = vector2.Y * -0.2f;
									}
								}
								else if (type == 185)
								{
									if (velocity.X != vector2.X)
									{
										velocity.X = vector2.X * -0.9f;
									}
									if (velocity.Y != vector2.Y && vector2.Y > 1f)
									{
										velocity.Y = vector2.Y * -0.9f;
									}
								}
								else if (type == 277)
								{
									if (velocity.X != vector2.X)
									{
										velocity.X = vector2.X * -0.9f;
									}
									if (velocity.Y != vector2.Y && vector2.Y > 3f)
									{
										velocity.Y = vector2.Y * -0.9f;
									}
								}
								else
								{
									if (velocity.X != vector2.X)
									{
										velocity.X = vector2.X * -0.5f;
									}
									if (velocity.Y != vector2.Y && vector2.Y > 1f)
									{
										velocity.Y = vector2.Y * -0.5f;
									}
								}
							}
							else if (aiStyle == 16)
							{
								if (velocity.X != vector2.X)
								{
									velocity.X = vector2.X * -0.4f;
									if (type == 29)
									{
										velocity.X *= 0.8f;
									}
								}
								if (velocity.Y != vector2.Y && (double)vector2.Y > 0.7 && type != 102)
								{
									velocity.Y = vector2.Y * -0.4f;
									if (type == 29)
									{
										velocity.Y *= 0.8f;
									}
								}
								if (type == 134 || type == 137 || type == 140 || type == 143 || type == 303 || (type >= 338 && type <= 341))
								{
									velocity *= 0f;
									alpha = 255;
									timeLeft = 3;
								}
							}
							else if (aiStyle == 68)
							{
								velocity *= 0f;
								alpha = 255;
								timeLeft = 3;
							}
							else if (aiStyle != 9 || owner == Main.myPlayer)
							{
								position += velocity;
								Kill();
							}
						}
					}
				}
			}
			if (aiStyle != 4 && aiStyle != 38 && (aiStyle != 7 || ai[0] != 2f))
			{
				if (wet)
				{
					position += vector;
				}
				else
				{
					position += velocity;
				}
				if (Main.projPet[type] && tileCollide)
				{
					Vector4 vector15 = Collision.SlopeCollision(position, velocity, width, height);
					if (position.X != vector15.X)
					{
						flag3 = true;
					}
					if (position.Y != vector15.Y)
					{
						flag3 = true;
					}
					if (velocity.X != vector15.Z)
					{
						flag3 = true;
					}
					if (velocity.Y != vector15.W)
					{
						flag3 = true;
					}
					position.X = vector15.X;
					position.Y = vector15.Y;
					velocity.X = vector15.Z;
					velocity.Y = vector15.W;
				}
			}
			if ((aiStyle != 3 || ai[0] != 1f) && (aiStyle != 7 || ai[0] != 1f) && (aiStyle != 13 || ai[0] != 1f) && (aiStyle != 15 || ai[0] != 1f) && aiStyle != 65 && aiStyle != 69 && aiStyle != 15 && aiStyle != 26 && aiStyle != 67)
			{
				if (velocity.X < 0f)
				{
					direction = -1;
				}
				else
				{
					direction = 1;
				}
			}
			if (!active)
			{
				return;
			}
			ProjLight();
			if (type == 2 || type == 82)
			{
				Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100);
			}
			else if (type == 172)
			{
				Dust.NewDust(new Vector2(position.X, position.Y), width, height, 135, 0f, 0f, 100);
			}
			else if (type == 103)
			{
				int num44 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 75, 0f, 0f, 100);
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num44].noGravity = true;
					Main.dust[num44].scale *= 2f;
				}
			}
			else if (type == 278)
			{
				int num45 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 169, 0f, 0f, 100);
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num45].noGravity = true;
					Main.dust[num45].scale *= 1.5f;
				}
			}
			else if (type == 4)
			{
				if (Main.rand.Next(5) == 0)
				{
					Dust.NewDust(new Vector2(position.X, position.Y), width, height, 14, 0f, 0f, 150, default(Color), 1.1f);
				}
			}
			else if (type == 5)
			{
				int num46;
				switch (Main.rand.Next(3))
				{
				case 0:
					num46 = 15;
					break;
				case 1:
					num46 = 57;
					break;
				default:
					num46 = 58;
					break;
				}
				Dust.NewDust(position, width, height, num46, velocity.X * 0.5f, velocity.Y * 0.5f, 150, default(Color), 1.2f);
			}
			Damage();
			if (Main.netMode != 1 && type == 99)
			{
				Collision.SwitchTiles(position, width, height, lastPosition, 3);
			}
			if (type == 94 || type == 301 || type == 388 || type == 385 || type == 408 || type == 409)
			{
				for (int num47 = oldPos.Length - 1; num47 > 0; num47--)
				{
					oldPos[num47] = oldPos[num47 - 1];
				}
				oldPos[0] = position;
			}
			timeLeft--;
			if (timeLeft <= 0)
			{
				Kill();
			}
			if (penetrate == 0)
			{
				Kill();
			}
			if (active && owner == Main.myPlayer)
			{
				if (netUpdate2)
				{
					netUpdate = true;
				}
				if (!active)
				{
					netSpam = 0;
				}
				if (netUpdate)
				{
					if (netSpam < 60)
					{
						netSpam += 5;
						NetMessage.SendData(27, -1, -1, "", i);
						netUpdate2 = false;
					}
					else
					{
						netUpdate2 = true;
					}
				}
				if (netSpam > 0)
				{
					netSpam--;
				}
			}
			if (active && maxUpdates > 0)
			{
				numUpdates--;
				if (numUpdates >= 0)
				{
					Update(i);
				}
				else
				{
					numUpdates = maxUpdates;
				}
			}
			netUpdate = false;
		}

		public void FishingCheck()
		{
			int num = (int)(center().X / 16f);
			int num2 = (int)(center().Y / 16f);
			if (Main.tile[num, num2].liquid < 0)
			{
				num2++;
			}
			bool flag = false;
			bool flag2 = false;
			int num3 = num;
			int i = num;
			while (num3 > 10 && Main.tile[num3, num2].liquid > 0 && !WorldGen.SolidTile(num3, num2))
			{
				num3--;
			}
			for (; i < Main.maxTilesX - 10 && Main.tile[i, num2].liquid > 0 && !WorldGen.SolidTile(i, num2); i++)
			{
			}
			int num4 = 0;
			for (int j = num3; j <= i; j++)
			{
				int num5 = num2;
				while (Main.tile[j, num5].liquid > 0 && !WorldGen.SolidTile(j, num5) && num5 < Main.maxTilesY - 10)
				{
					num4++;
					num5++;
					if (Main.tile[j, num5].lava())
					{
						flag = true;
					}
					else if (Main.tile[j, num5].honey())
					{
						flag2 = true;
					}
				}
			}
			if (flag2)
			{
				num4 = (int)((double)num4 * 1.5);
			}
			if (num4 < 75)
			{
				return;
			}
			int num6 = Main.player[owner].FishingLevel();
			if (num6 == 0)
			{
				return;
			}
			if (num6 < 0)
			{
				if (num6 == -1 && (num < 380 || num > Main.maxTilesX - 380) && num4 > 1000 && !NPC.AnyNPCs(370))
				{
					ai[1] = Main.rand.Next(-180, -60) - 100;
					localAI[1] = num6;
					netUpdate = true;
				}
				return;
			}
			int num7 = 300;
			float num8 = (float)num4 / (float)num7;
			if (num8 < 1f)
			{
				num6 = (int)((float)num6 * num8);
			}
			int num9 = (num6 + 75) / 2;
			if (Main.player[owner].wet || Main.rand.Next(100) > num9)
			{
				return;
			}
			int num10 = 0;
			int num11 = 0;
			num11 = ((!((double)num2 < Main.worldSurface * 0.4)) ? (((double)num2 < Main.worldSurface) ? 1 : (((double)num2 < Main.rockLayer) ? 2 : ((num2 >= Main.maxTilesY - 300) ? 4 : 3))) : 0);
			int num12 = 150;
			int num13 = num12 / num6;
			int num14 = num12 * 2 / num6;
			int num15 = num12 * 7 / num6;
			int num16 = num12 * 15 / num6;
			int num17 = num12 * 30 / num6;
			if (num13 < 2)
			{
				num13 = 2;
			}
			if (num14 < 3)
			{
				num14 = 3;
			}
			if (num15 < 4)
			{
				num15 = 4;
			}
			if (num16 < 5)
			{
				num16 = 5;
			}
			if (num17 < 6)
			{
				num17 = 6;
			}
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			if (Main.rand.Next(num13) == 0)
			{
				flag3 = true;
			}
			if (Main.rand.Next(num14) == 0)
			{
				flag4 = true;
			}
			if (Main.rand.Next(num15) == 0)
			{
				flag5 = true;
			}
			if (Main.rand.Next(num16) == 0)
			{
				flag6 = true;
			}
			if (Main.rand.Next(num17) == 0)
			{
				flag7 = true;
			}
			int num18 = 10;
			if (Main.player[owner].cratePotion)
			{
				num18 += 10;
			}
			int num19 = Main.anglerQuestItemNetIDs[Main.anglerQuest];
			if (Main.player[owner].HasItem(num19))
			{
				num19 = -1;
			}
			if (Main.anglerQuestFinished)
			{
				num19 = -1;
			}
			if (flag)
			{
				if (Main.player[owner].inventory[Main.player[owner].selectedItem].type != 2422)
				{
					return;
				}
				if (flag7)
				{
					num10 = 2331;
				}
				else if (flag6)
				{
					num10 = 2312;
				}
				else if (flag5)
				{
					num10 = 2315;
				}
			}
			else if (flag2)
			{
				if (flag5 || (flag4 && Main.rand.Next(2) == 0))
				{
					num10 = 2314;
				}
				else if (flag4 && num19 == 2451)
				{
					num10 = 2451;
				}
			}
			else if (Main.rand.Next(50) > num6 && Main.rand.Next(50) > num6 && num4 < num7)
			{
				num10 = Main.rand.Next(2337, 2340);
			}
			else if (Main.rand.Next(100) < num18)
			{
				num10 = ((!flag6 && !flag7) ? ((!flag4) ? 2334 : 2335) : 2336);
			}
			else if (flag7 && Main.rand.Next(5) == 0)
			{
				num10 = 2423;
			}
			else if (flag7 && Main.rand.Next(10) == 0)
			{
				num10 = 2420;
			}
			else
			{
				bool flag8 = Main.player[owner].zoneEvil;
				bool flag9 = Main.player[owner].zoneBlood;
				if (flag8 && flag9)
				{
					if (Main.rand.Next(2) == 0)
					{
						flag9 = false;
					}
					else
					{
						flag8 = false;
					}
				}
				if (flag8)
				{
					if (flag7 && Main.hardMode && Main.player[owner].zoneSnow && num11 == 3)
					{
						num10 = 2429;
					}
					else if (flag5)
					{
						num10 = 2330;
					}
					else if (flag4 && num19 == 2454)
					{
						num10 = 2454;
					}
					else if (flag4 && num19 == 2485)
					{
						num10 = 2485;
					}
					else if (flag4 && num19 == 2457)
					{
						num10 = 2457;
					}
					else if (flag4)
					{
						num10 = 2318;
					}
				}
				else if (flag9)
				{
					if (flag7 && Main.hardMode && Main.player[owner].zoneSnow && num11 == 3)
					{
						num10 = 2429;
					}
					else if (flag4 && num19 == 2477)
					{
						num10 = 2477;
					}
					else if (flag4 && num19 == 2463)
					{
						num10 = 2463;
					}
					else if (flag4)
					{
						num10 = 2319;
					}
					else if (flag3)
					{
						num10 = 2305;
					}
				}
				else if (Main.player[owner].zoneHoly)
				{
					if (flag7 && Main.hardMode && Main.player[owner].zoneSnow && num11 == 3)
					{
						num10 = 2429;
					}
					else if (num11 > 1 && flag6)
					{
						num10 = 2317;
					}
					else if (num11 > 1 && flag5 && num19 == 2465)
					{
						num10 = 2465;
					}
					else if (num11 < 2 && flag5 && num19 == 2468)
					{
						num10 = 2468;
					}
					else if (flag5)
					{
						num10 = 2310;
					}
					else if (flag4 && num19 == 2471)
					{
						num10 = 2471;
					}
					else if (flag4)
					{
						num10 = 2307;
					}
				}
				if (num10 == 0 && Main.player[owner].zoneSnow)
				{
					if (num11 < 2 && flag4 && num19 == 2467)
					{
						num10 = 2467;
					}
					else if (num11 == 1 && flag4 && num19 == 2470)
					{
						num10 = 2470;
					}
					else if (num11 == 2 && flag4 && num19 == 2484)
					{
						num10 = 2484;
					}
					else if (num11 > 1 && flag4 && num19 == 2466)
					{
						num10 = 2466;
					}
					else if (flag4)
					{
						num10 = 2306;
					}
					else if (flag3)
					{
						num10 = 2299;
					}
				}
				if (num10 == 0 && Main.player[owner].zoneJungle)
				{
					if (num11 == 1 && flag4 && num19 == 2452)
					{
						num10 = 2452;
					}
					else if (num11 == 1 && flag4 && num19 == 2483)
					{
						num10 = 2483;
					}
					else if (num11 == 1 && flag4 && num19 == 2488)
					{
						num10 = 2488;
					}
					else if (num11 >= 1 && flag4 && num19 == 2486)
					{
						num10 = 2486;
					}
					else if (num11 > 1 && flag4)
					{
						num10 = 2311;
					}
					else if (flag4)
					{
						num10 = 2313;
					}
					else if (flag3)
					{
						num10 = 2302;
					}
				}
				if (num10 == 0 && Main.shroomTiles > 200 && flag4 && num19 == 2475)
				{
					num10 = 2475;
				}
				if (num10 == 0)
				{
					if (num11 <= 1 && (num < 380 || num > Main.maxTilesX - 380) && num4 > 1000)
					{
						num10 = ((flag6 && Main.rand.Next(2) == 0) ? 2341 : (flag6 ? 2342 : ((flag5 && Main.rand.Next(5) == 0) ? 2438 : ((flag5 && Main.rand.Next(2) == 0) ? 2332 : ((flag4 && num19 == 2480) ? 2480 : ((flag4 && num19 == 2481) ? 2481 : (flag4 ? 2316 : ((flag3 && Main.rand.Next(2) == 0) ? 2301 : ((!flag3) ? 2297 : 2300)))))))));
					}
					else
					{
						int sandTile = Main.sandTiles;
						int num21 = 1000;
					}
				}
				if (num10 == 0)
				{
					num10 = ((num11 == 0 && flag4 && num19 == 2453) ? 2453 : ((num11 < 2 && flag4 && num19 == 2461) ? 2461 : ((num11 < 2 && flag4 && num19 == 2473) ? 2473 : ((num11 < 2 && flag4 && num19 == 2476) ? 2476 : ((num11 < 2 && flag4 && num19 == 2458) ? 2458 : ((num11 < 2 && flag4 && num19 == 2459) ? 2459 : ((num11 == 0 && flag4) ? 2304 : ((num11 > 0 && num11 < 3 && flag4 && num19 == 2455) ? 2455 : ((num11 == 1 && flag4 && num19 == 2479) ? 2479 : ((num11 == 1 && flag4 && num19 == 2456) ? 2456 : ((num11 == 1 && flag4 && num19 == 2474) ? 2474 : ((num11 > 1 && flag5 && Main.rand.Next(5) == 0) ? ((!Main.hardMode || Main.rand.Next(2) != 0) ? 2436 : 2437) : ((num11 > 1 && flag7) ? 2308 : ((num11 > 1 && flag6) ? 2320 : ((num11 > 1 && flag5) ? 2321 : ((num11 > 1 && flag4 && num19 == 2478) ? 2478 : ((num11 > 1 && flag4 && num19 == 2450) ? 2450 : ((num11 > 1 && flag4 && num19 == 2464) ? 2464 : ((num11 > 1 && flag4 && num19 == 2469) ? 2469 : ((num11 > 2 && flag4 && num19 == 2462) ? 2462 : ((num11 > 2 && flag4 && num19 == 2482) ? 2482 : ((num11 > 2 && flag4 && num19 == 2472) ? 2472 : ((num11 > 2 && flag4 && num19 == 2460) ? 2460 : ((num11 > 1 && flag4) ? 2303 : ((num11 > 1 && flag3) ? 2309 : ((flag4 && num19 == 2487) ? 2487 : ((num4 <= 1000 || !flag3) ? 2290 : 2298)))))))))))))))))))))))))));
				}
			}
			if (num10 > 0)
			{
				if (Main.player[owner].sonarPotion)
				{
					Item item = new Item();
					item.SetDefaults(num10);
					item.position = position;
					ItemText.NewText(item, 1, true);
				}
				float num20 = num6;
				ai[1] = (float)Main.rand.Next(-180, -60) - num20;
				localAI[1] = num10;
				netUpdate = true;
			}
		}

		public void AI()
		{
			if (aiStyle == 1)
			{
				if (type == 323)
				{
					alpha -= 50;
					if (alpha < 0)
					{
						alpha = 0;
					}
				}
				if (type == 408)
				{
					alpha -= 40;
					if (alpha < 0)
					{
						alpha = 0;
					}
					spriteDirection = direction;
				}
				if (type == 282)
				{
					int num = Dust.NewDust(position, width, height, 171, 0f, 0f, 100);
					Main.dust[num].scale = (float)Main.rand.Next(1, 10) * 0.1f;
					Main.dust[num].noGravity = true;
					Main.dust[num].fadeIn = 1.5f;
					Main.dust[num].velocity *= 0.25f;
					Main.dust[num].velocity += velocity * 0.25f;
				}
				if (type == 275 || type == 276)
				{
					frameCounter++;
					if (frameCounter > 1)
					{
						frameCounter = 0;
						frame++;
						if (frame > 1)
						{
							frame = 0;
						}
					}
				}
				if (type == 225)
				{
					int num2 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 40);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].scale = 1.3f;
					Main.dust[num2].velocity *= 0.5f;
				}
				if (type == 174)
				{
					if (alpha == 0)
					{
						int num3 = Dust.NewDust(lastPosition - velocity * 3f, width, height, 76, 0f, 0f, 50);
						Main.dust[num3].noGravity = true;
						Main.dust[num3].noLight = true;
						Main.dust[num3].velocity *= 0.5f;
					}
					alpha -= 50;
					if (alpha < 0)
					{
						alpha = 0;
					}
					if (ai[1] == 0f)
					{
						ai[1] = 1f;
						Main.PlaySound(2, (int)position.X, (int)position.Y, 17);
					}
				}
				else if (type == 176)
				{
					if (alpha == 0)
					{
						int num4 = Dust.NewDust(lastPosition, width, height, 22, 0f, 0f, 100, default(Color), 0.5f);
						Main.dust[num4].noGravity = true;
						Main.dust[num4].noLight = true;
						Main.dust[num4].velocity *= 0.15f;
						Main.dust[num4].fadeIn = 0.8f;
					}
					alpha -= 50;
					if (alpha < 0)
					{
						alpha = 0;
					}
					if (ai[1] == 0f)
					{
						ai[1] = 1f;
						Main.PlaySound(2, (int)position.X, (int)position.Y, 17);
					}
				}
				if (type == 350)
				{
					alpha -= 100;
					if (alpha < 0)
					{
						alpha = 0;
					}
					Lighting.addLight((int)center().X / 16, (int)center().Y / 16, 0.9f, 0.6f, 0.2f);
					if (alpha == 0)
					{
						int num5 = 2;
						if (Main.rand.Next(2) == 0)
						{
							int num6 = Dust.NewDust(new Vector2(center().X - (float)num5, center().Y - (float)num5 - 2f) - velocity * 0.5f, num5 * 2, num5 * 2, 6, 0f, 0f, 100);
							Main.dust[num6].scale *= 1.8f + (float)Main.rand.Next(10) * 0.1f;
							Main.dust[num6].velocity *= 0.2f;
							Main.dust[num6].noGravity = true;
						}
						if (Main.rand.Next(4) == 0)
						{
							int num7 = (num7 = Dust.NewDust(new Vector2(center().X - (float)num5, center().Y - (float)num5 - 2f) - velocity * 0.5f, num5 * 2, num5 * 2, 31, 0f, 0f, 100, default(Color), 0.5f));
							Main.dust[num7].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
							Main.dust[num7].velocity *= 0.05f;
						}
					}
					if (ai[1] == 0f)
					{
						ai[1] = 1f;
						Main.PlaySound(2, (int)position.X, (int)position.Y, 42);
					}
				}
				if (type == 325)
				{
					alpha -= 100;
					if (alpha < 0)
					{
						alpha = 0;
					}
					Lighting.addLight((int)center().X / 16, (int)center().Y / 16, 0.9f, 0.6f, 0.2f);
					if (alpha == 0)
					{
						int num8 = 2;
						if (Main.rand.Next(2) == 0)
						{
							int num9 = Dust.NewDust(new Vector2(center().X - (float)num8, center().Y - (float)num8 - 2f) - velocity * 0.5f, num8 * 2, num8 * 2, 6, 0f, 0f, 100);
							Main.dust[num9].scale *= 1.8f + (float)Main.rand.Next(10) * 0.1f;
							Main.dust[num9].velocity *= 0.2f;
							Main.dust[num9].noGravity = true;
						}
						if (Main.rand.Next(4) == 0)
						{
							int num10 = (num10 = Dust.NewDust(new Vector2(center().X - (float)num8, center().Y - (float)num8 - 2f) - velocity * 0.5f, num8 * 2, num8 * 2, 31, 0f, 0f, 100, default(Color), 0.5f));
							Main.dust[num10].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
							Main.dust[num10].velocity *= 0.05f;
						}
					}
					if (ai[1] == 0f)
					{
						ai[1] = 1f;
						Main.PlaySound(2, (int)position.X, (int)position.Y, 42);
					}
				}
				if (type == 83 && ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 33);
				}
				if (type == 408 && ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(4, (int)position.X, (int)position.Y, 19);
				}
				if (type == 259 && ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 33);
				}
				if (type == 110 && ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 11);
				}
				if (type == 302 && ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 11);
				}
				if (type == 84 && ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 12);
				}
				if (type == 389 && ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 12);
				}
				if (type == 257 && ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 12);
				}
				if (type == 100 && ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 33);
				}
				if (type == 98 && ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 17);
				}
				if (type == 184 && ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 17);
				}
				if (type == 195 && ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 17);
				}
				if (type == 275 && ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 17);
				}
				if (type == 276 && ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 17);
				}
				if ((type == 81 || type == 82) && ai[1] == 0f)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 5);
					ai[1] = 1f;
				}
				if (type == 180 && ai[1] == 0f)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 11);
					ai[1] = 1f;
				}
				if (type == 248 && ai[1] == 0f)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 17);
					ai[1] = 1f;
				}
				if (type == 41)
				{
					int num11 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.6f);
					Main.dust[num11].noGravity = true;
					num11 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num11].noGravity = true;
				}
				else if (type == 55)
				{
					int num12 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 18, 0f, 0f, 0, default(Color), 0.9f);
					Main.dust[num12].noGravity = true;
				}
				else if (type == 374)
				{
					if (localAI[0] == 0f)
					{
						Main.PlaySound(2, (int)position.X, (int)position.Y, 17);
						localAI[0] = 1f;
					}
					if (Main.rand.Next(2) == 0)
					{
						int num13 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 18, 0f, 0f, 0, default(Color), 0.9f);
						Main.dust[num13].noGravity = true;
						Main.dust[num13].velocity *= 0.5f;
					}
				}
				else if (type == 376)
				{
					if (localAI[0] == 0f)
					{
						Main.PlaySound(2, (int)position.X, (int)position.Y, 20);
					}
					localAI[0] += 1f;
					if (localAI[0] > 3f)
					{
						int num14 = 1;
						if (localAI[0] > 5f)
						{
							num14 = 2;
						}
						for (int i = 0; i < num14; i++)
						{
							int num15 = Dust.NewDust(new Vector2(position.X, position.Y + 2f), width, height, 6, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2f);
							Main.dust[num15].noGravity = true;
							Main.dust[num15].velocity.X *= 0.3f;
							Main.dust[num15].velocity.Y *= 0.3f;
							Main.dust[num15].noLight = true;
						}
						if (wet && !lavaWet)
						{
							Kill();
							return;
						}
					}
				}
				else if (type == 91 && Main.rand.Next(2) == 0)
				{
					int num16 = Dust.NewDust(Type: (Main.rand.Next(2) != 0) ? 58 : 15, Position: position, Width: width, Height: height, SpeedX: velocity.X * 0.25f, SpeedY: velocity.Y * 0.25f, Alpha: 150, newColor: default(Color), Scale: 0.9f);
					Main.dust[num16].velocity *= 0.25f;
				}
				if (type == 163 || type == 310)
				{
					if (alpha > 0)
					{
						alpha -= 25;
					}
					if (alpha < 0)
					{
						alpha = 0;
					}
				}
				if (type == 20 || type == 14 || type == 36 || type == 83 || type == 84 || type == 389 || type == 89 || type == 100 || type == 104 || type == 110 || type == 180 || type == 279 || (type >= 158 && type <= 161) || (type >= 283 && type <= 287))
				{
					if (alpha > 0)
					{
						alpha -= 15;
					}
					if (alpha < 0)
					{
						alpha = 0;
					}
				}
				if (type == 242 || type == 302)
				{
					float num17 = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
					if (alpha > 0)
					{
						alpha -= (byte)((double)num17 * 0.9);
					}
					if (alpha < 0)
					{
						alpha = 0;
					}
				}
				if (type == 257)
				{
					if (alpha > 0)
					{
						alpha -= 10;
					}
					if (alpha < 0)
					{
						alpha = 0;
					}
				}
				if (type == 88)
				{
					if (alpha > 0)
					{
						alpha -= 10;
					}
					if (alpha < 0)
					{
						alpha = 0;
					}
				}
				if (type != 376 && type != 350 && type != 349 && type != 348 && type != 5 && type != 325 && type != 323 && type != 14 && type != 270 && type != 180 && type != 259 && type != 242 && type != 302 && type != 20 && type != 36 && type != 38 && type != 55 && type != 83 && type != 84 && type != 389 && type != 88 && type != 89 && type != 98 && type != 100 && type != 265 && type != 104 && type != 110 && type != 184 && type != 257 && type != 248 && (type < 283 || type > 287) && type != 279 && type != 299 && type != 355 && (type < 158 || type > 161) && type != 374)
				{
					ai[0] += 1f;
				}
				if (type == 349)
				{
					frame = (int)ai[0];
					velocity.Y += 0.2f;
					if (localAI[0] == 0f || localAI[0] == 2f)
					{
						scale += 0.01f;
						alpha -= 50;
						if (alpha <= 0)
						{
							localAI[0] = 1f;
							alpha = 0;
						}
					}
					else if (localAI[0] == 1f)
					{
						scale -= 0.01f;
						alpha += 50;
						if (alpha >= 255)
						{
							localAI[0] = 2f;
							alpha = 255;
						}
					}
				}
				if (type == 348)
				{
					if (localAI[1] == 0f)
					{
						localAI[1] = 1f;
						Main.PlaySound(2, (int)position.X, (int)position.Y, 8);
					}
					if (ai[0] == 0f || ai[0] == 2f)
					{
						scale += 0.01f;
						alpha -= 50;
						if (alpha <= 0)
						{
							ai[0] = 1f;
							alpha = 0;
						}
					}
					else if (ai[0] == 1f)
					{
						scale -= 0.01f;
						alpha += 50;
						if (alpha >= 255)
						{
							ai[0] = 2f;
							alpha = 255;
						}
					}
				}
				if (type == 299)
				{
					if (localAI[0] == 6f)
					{
						Main.PlaySound(2, (int)position.X, (int)position.Y, 8);
						for (int j = 0; j < 40; j++)
						{
							int num18 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 181, 0f, 0f, 100);
							Main.dust[num18].velocity *= 3f;
							Main.dust[num18].velocity += velocity * 0.75f;
							Main.dust[num18].scale *= 1.2f;
							Main.dust[num18].noGravity = true;
						}
					}
					localAI[0] += 1f;
					if (localAI[0] > 6f)
					{
						for (int k = 0; k < 3; k++)
						{
							int num19 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 181, velocity.X * 0.2f, velocity.Y * 0.2f, 100);
							Main.dust[num19].velocity *= 0.6f;
							Main.dust[num19].scale *= 1.4f;
							Main.dust[num19].noGravity = true;
						}
					}
				}
				else if (type == 270)
				{
					if (alpha > 0)
					{
						alpha -= 50;
					}
					if (alpha < 0)
					{
						alpha = 0;
					}
					frame++;
					if (frame > 2)
					{
						frame = 0;
					}
					for (int l = 0; l < 2; l++)
					{
						int num20 = Dust.NewDust(new Vector2(position.X + 4f, position.Y + 4f), width - 8, height - 8, 6, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num20].position -= velocity * 2f;
						Main.dust[num20].noGravity = true;
						Main.dust[num20].velocity.X *= 0.3f;
						Main.dust[num20].velocity.Y *= 0.3f;
					}
				}
				if (type == 259)
				{
					if (alpha > 0)
					{
						alpha -= 10;
					}
					if (alpha < 0)
					{
						alpha = 0;
					}
				}
				if (type == 265)
				{
					if (alpha > 0)
					{
						alpha -= 50;
					}
					if (alpha < 0)
					{
						alpha = 0;
					}
					if (alpha == 0)
					{
						int num21 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 163, velocity.X, velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num21].noGravity = true;
						Main.dust[num21].velocity *= 0.3f;
						Main.dust[num21].velocity -= velocity * 0.4f;
					}
				}
				if (type == 355)
				{
					if (alpha > 0)
					{
						alpha -= 50;
					}
					if (alpha < 0)
					{
						alpha = 0;
					}
					if (alpha == 0)
					{
						int num22 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 205, velocity.X, velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num22].noGravity = true;
						Main.dust[num22].velocity *= 0.3f;
						Main.dust[num22].velocity -= velocity * 0.4f;
					}
				}
				if (type == 357)
				{
					if (alpha < 170)
					{
						for (int m = 0; m < 10; m++)
						{
							float x = position.X - velocity.X / 10f * (float)m;
							float y = position.Y - velocity.Y / 10f * (float)m;
							int num23 = Dust.NewDust(new Vector2(x, y), 1, 1, 206);
							Main.dust[num23].alpha = alpha;
							Main.dust[num23].position.X = x;
							Main.dust[num23].position.Y = y;
							Main.dust[num23].velocity *= 0f;
							Main.dust[num23].noGravity = true;
						}
					}
					if (alpha > 0)
					{
						alpha -= 25;
					}
					if (alpha < 0)
					{
						alpha = 0;
					}
				}
				else if (type == 207)
				{
					if (alpha < 170)
					{
						for (int n = 0; n < 10; n++)
						{
							float x2 = position.X - velocity.X / 10f * (float)n;
							float y2 = position.Y - velocity.Y / 10f * (float)n;
							int num24 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 75);
							Main.dust[num24].alpha = alpha;
							Main.dust[num24].position.X = x2;
							Main.dust[num24].position.Y = y2;
							Main.dust[num24].velocity *= 0f;
							Main.dust[num24].noGravity = true;
						}
					}
					float num25 = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
					float num26 = localAI[0];
					if (num26 == 0f)
					{
						localAI[0] = num25;
						num26 = num25;
					}
					if (alpha > 0)
					{
						alpha -= 25;
					}
					if (alpha < 0)
					{
						alpha = 0;
					}
					float num27 = position.X;
					float num28 = position.Y;
					float num29 = 300f;
					bool flag = false;
					int num30 = 0;
					if (ai[1] == 0f)
					{
						for (int num31 = 0; num31 < 200; num31++)
						{
							if (Main.npc[num31].active && !Main.npc[num31].dontTakeDamage && !Main.npc[num31].friendly && Main.npc[num31].lifeMax > 5 && (ai[1] == 0f || ai[1] == (float)(num31 + 1)))
							{
								float num32 = Main.npc[num31].position.X + (float)(Main.npc[num31].width / 2);
								float num33 = Main.npc[num31].position.Y + (float)(Main.npc[num31].height / 2);
								float num34 = Math.Abs(position.X + (float)(width / 2) - num32) + Math.Abs(position.Y + (float)(height / 2) - num33);
								if (num34 < num29 && Collision.CanHit(new Vector2(position.X + (float)(width / 2), position.Y + (float)(height / 2)), 1, 1, Main.npc[num31].position, Main.npc[num31].width, Main.npc[num31].height))
								{
									num29 = num34;
									num27 = num32;
									num28 = num33;
									flag = true;
									num30 = num31;
								}
							}
						}
						if (flag)
						{
							ai[1] = num30 + 1;
						}
						flag = false;
					}
					if (ai[1] != 0f)
					{
						int num35 = (int)(ai[1] - 1f);
						if (Main.npc[num35].active)
						{
							float num36 = Main.npc[num35].position.X + (float)(Main.npc[num35].width / 2);
							float num37 = Main.npc[num35].position.Y + (float)(Main.npc[num35].height / 2);
							float num38 = Math.Abs(position.X + (float)(width / 2) - num36) + Math.Abs(position.Y + (float)(height / 2) - num37);
							if (num38 < 1000f)
							{
								flag = true;
								num27 = Main.npc[num35].position.X + (float)(Main.npc[num35].width / 2);
								num28 = Main.npc[num35].position.Y + (float)(Main.npc[num35].height / 2);
							}
						}
					}
					if (flag)
					{
						float num39 = num26;
						Vector2 vector = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
						float num40 = num27 - vector.X;
						float num41 = num28 - vector.Y;
						float num42 = (float)Math.Sqrt(num40 * num40 + num41 * num41);
						num42 = num39 / num42;
						num40 *= num42;
						num41 *= num42;
						int num43 = 8;
						velocity.X = (velocity.X * (float)(num43 - 1) + num40) / (float)num43;
						velocity.Y = (velocity.Y * (float)(num43 - 1) + num41) / (float)num43;
					}
				}
				else if (type == 81 || type == 91)
				{
					if (ai[0] >= 20f)
					{
						ai[0] = 20f;
						velocity.Y += 0.07f;
					}
				}
				else if (type == 174)
				{
					if (ai[0] >= 5f)
					{
						ai[0] = 5f;
						velocity.Y += 0.15f;
					}
				}
				else if (type == 337)
				{
					if (position.Y > Main.player[owner].position.Y - 300f)
					{
						tileCollide = true;
					}
					if ((double)position.Y < Main.worldSurface * 16.0)
					{
						tileCollide = true;
					}
					frame = (int)ai[1];
					if (Main.rand.Next(2) == 0)
					{
						int num44 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 197);
						Main.dust[num44].velocity *= 0.5f;
						Main.dust[num44].noGravity = true;
					}
				}
				else if (type == 344)
				{
					localAI[1] += 1f;
					if (localAI[1] > 5f)
					{
						alpha -= 50;
						if (alpha < 0)
						{
							alpha = 0;
						}
					}
					frame = (int)ai[1];
					if (localAI[1] > 20f)
					{
						localAI[1] = 20f;
						velocity.Y += 0.15f;
					}
					rotation += Main.windSpeed * 0.2f;
					velocity.X += Main.windSpeed * 0.1f;
				}
				else if (type == 336 || type == 345)
				{
					if (type == 345 && localAI[0] == 0f)
					{
						localAI[0] = 1f;
						Main.PlaySound(2, (int)position.X, (int)position.Y);
					}
					if (ai[0] >= 50f)
					{
						ai[0] = 50f;
						velocity.Y += 0.5f;
					}
				}
				else if (type == 246)
				{
					alpha -= 20;
					if (alpha < 0)
					{
						alpha = 0;
					}
					if (ai[0] >= 60f)
					{
						ai[0] = 60f;
						velocity.Y += 0.15f;
					}
				}
				else if (type == 311)
				{
					if (alpha > 0)
					{
						alpha -= 50;
					}
					if (alpha < 0)
					{
						alpha = 0;
					}
					if (ai[0] >= 30f)
					{
						ai[0] = 30f;
						if (ai[1] == 0f)
						{
							ai[1] = 1f;
						}
						velocity.Y += 0.5f;
					}
				}
				else if (type == 312)
				{
					if (ai[0] >= 5f)
					{
						alpha = 0;
					}
					if (ai[0] >= 20f)
					{
						ai[0] = 30f;
						velocity.Y += 0.5f;
					}
				}
				else if (type != 239 && type != 264)
				{
					if (type == 176)
					{
						if (ai[0] >= 15f)
						{
							ai[0] = 15f;
							velocity.Y += 0.05f;
						}
					}
					else if (type == 275 || type == 276)
					{
						if (alpha > 0)
						{
							alpha -= 30;
						}
						if (alpha < 0)
						{
							alpha = 0;
						}
						if (ai[0] >= 35f)
						{
							ai[0] = 35f;
							velocity.Y += 0.025f;
						}
					}
					else if (type == 172)
					{
						if (ai[0] >= 17f)
						{
							ai[0] = 17f;
							velocity.Y += 0.085f;
						}
					}
					else if (type == 117)
					{
						if (ai[0] >= 35f)
						{
							ai[0] = 35f;
							velocity.Y += 0.06f;
						}
					}
					else if (type == 120)
					{
						int num45 = Dust.NewDust(new Vector2(position.X - velocity.X, position.Y - velocity.Y), width, height, 67, velocity.X, velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num45].noGravity = true;
						Main.dust[num45].velocity *= 0.3f;
						if (ai[0] >= 30f)
						{
							ai[0] = 30f;
							velocity.Y += 0.05f;
						}
					}
					else if (type == 195)
					{
						if (ai[0] >= 20f)
						{
							ai[0] = 20f;
							velocity.Y += 0.075f;
						}
					}
					else if (type == 267)
					{
						localAI[0] += 1f;
						if (localAI[0] > 3f)
						{
							alpha = 0;
						}
						if (ai[0] >= 20f)
						{
							ai[0] = 20f;
							velocity.Y += 0.075f;
						}
					}
					else if (type == 408)
					{
						if (ai[0] >= 45f)
						{
							ai[0] = 45f;
							velocity.Y += 0.05f;
						}
					}
					else if (ai[0] >= 15f)
					{
						ai[0] = 15f;
						velocity.Y += 0.1f;
					}
				}
				if (type == 248)
				{
					if (velocity.X < 0f)
					{
						rotation -= (Math.Abs(velocity.X) + Math.Abs(velocity.Y)) * 0.05f;
					}
					else
					{
						rotation += (Math.Abs(velocity.X) + Math.Abs(velocity.Y)) * 0.05f;
					}
				}
				if (type == 270)
				{
					spriteDirection = direction;
					if (direction < 0)
					{
						rotation = (float)Math.Atan2(0f - velocity.Y, 0f - velocity.X);
					}
					else
					{
						rotation = (float)Math.Atan2(velocity.Y, velocity.X);
					}
				}
				else if (type == 311)
				{
					if (ai[1] != 0f)
					{
						rotation += velocity.X * 0.1f + (float)Main.rand.Next(-10, 11) * 0.025f;
					}
					else
					{
						rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
					}
				}
				else if (type == 312)
				{
					rotation += velocity.X * 0.02f;
				}
				else if (type == 408)
				{
					rotation = velocity.ToRotation();
					if (direction == -1)
					{
						rotation += (float)Math.PI;
					}
				}
				else if (type != 344)
				{
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
				}
				if (velocity.Y > 16f)
				{
					velocity.Y = 16f;
				}
			}
			else if (aiStyle == 2)
			{
				if (type == 93 && Main.rand.Next(5) == 0)
				{
					int num46 = Dust.NewDust(position, width, height, 57, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 0.3f);
					Main.dust[num46].velocity.X *= 0.3f;
					Main.dust[num46].velocity.Y *= 0.3f;
				}
				if (type == 304 && localAI[0] == 0f)
				{
					localAI[0] += 1f;
					alpha = 0;
				}
				if (type == 335)
				{
					frame = (int)ai[1];
				}
				rotation += (Math.Abs(velocity.X) + Math.Abs(velocity.Y)) * 0.03f * (float)direction;
				if (type == 162)
				{
					if (ai[1] == 0f)
					{
						ai[1] = 1f;
						Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					}
					ai[0] += 1f;
					if (ai[0] >= 18f)
					{
						velocity.Y += 0.28f;
						velocity.X *= 0.99f;
					}
					if (ai[0] > 2f)
					{
						alpha = 0;
						if (ai[0] == 3f)
						{
							for (int num47 = 0; num47 < 10; num47++)
							{
								int num48 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num48].velocity *= 0.5f;
								Main.dust[num48].velocity += velocity * 0.1f;
							}
							for (int num49 = 0; num49 < 5; num49++)
							{
								int num50 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num50].noGravity = true;
								Main.dust[num50].velocity *= 3f;
								Main.dust[num50].velocity += velocity * 0.2f;
								num50 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100);
								Main.dust[num50].velocity *= 2f;
								Main.dust[num50].velocity += velocity * 0.3f;
							}
							for (int num51 = 0; num51 < 1; num51++)
							{
								int num52 = Gore.NewGore(new Vector2(position.X - 10f, position.Y - 10f), default(Vector2), Main.rand.Next(61, 64));
								Main.gore[num52].position += velocity * 1.25f;
								Main.gore[num52].scale = 1.5f;
								Main.gore[num52].velocity += velocity * 0.5f;
								Main.gore[num52].velocity *= 0.02f;
							}
						}
					}
				}
				else if (type == 281)
				{
					if (ai[1] == 0f)
					{
						ai[1] = 1f;
						Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					}
					ai[0] += 1f;
					if (ai[0] >= 18f)
					{
						velocity.Y += 0.28f;
						velocity.X *= 0.99f;
					}
					if (ai[0] > 2f)
					{
						alpha = 0;
						if (ai[0] == 3f)
						{
							for (int num53 = 0; num53 < 10; num53++)
							{
								int num54 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num54].velocity *= 0.5f;
								Main.dust[num54].velocity += velocity * 0.1f;
							}
							for (int num55 = 0; num55 < 5; num55++)
							{
								int num56 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num56].noGravity = true;
								Main.dust[num56].velocity *= 3f;
								Main.dust[num56].velocity += velocity * 0.2f;
								num56 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100);
								Main.dust[num56].velocity *= 2f;
								Main.dust[num56].velocity += velocity * 0.3f;
							}
							for (int num57 = 0; num57 < 1; num57++)
							{
								int num58 = Gore.NewGore(new Vector2(position.X - 10f, position.Y - 10f), default(Vector2), Main.rand.Next(61, 64));
								Main.gore[num58].position += velocity * 1.25f;
								Main.gore[num58].scale = 1.5f;
								Main.gore[num58].velocity += velocity * 0.5f;
								Main.gore[num58].velocity *= 0.02f;
							}
						}
					}
				}
				else if (type == 240)
				{
					if (ai[1] == 0f)
					{
						ai[1] = 1f;
						Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					}
					ai[0] += 1f;
					if (ai[0] >= 16f)
					{
						velocity.Y += 0.18f;
						velocity.X *= 0.991f;
					}
					if (ai[0] > 2f)
					{
						alpha = 0;
						if (ai[0] == 3f)
						{
							for (int num59 = 0; num59 < 7; num59++)
							{
								int num60 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num60].velocity *= 0.5f;
								Main.dust[num60].velocity += velocity * 0.1f;
							}
							for (int num61 = 0; num61 < 3; num61++)
							{
								int num62 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num62].noGravity = true;
								Main.dust[num62].velocity *= 3f;
								Main.dust[num62].velocity += velocity * 0.2f;
								num62 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100);
								Main.dust[num62].velocity *= 2f;
								Main.dust[num62].velocity += velocity * 0.3f;
							}
							for (int num63 = 0; num63 < 1; num63++)
							{
								int num64 = Gore.NewGore(new Vector2(position.X - 10f, position.Y - 10f), default(Vector2), Main.rand.Next(61, 64));
								Main.gore[num64].position += velocity * 1.25f;
								Main.gore[num64].scale = 1.25f;
								Main.gore[num64].velocity += velocity * 0.5f;
								Main.gore[num64].velocity *= 0.02f;
							}
						}
					}
				}
				else if (type == 249)
				{
					ai[0] += 1f;
					if (ai[0] >= 0f)
					{
						velocity.Y += 0.25f;
					}
				}
				else if (type == 347)
				{
					ai[0] += 1f;
					if (ai[0] >= 5f)
					{
						velocity.Y += 0.25f;
					}
				}
				else if (type == 69 || type == 70)
				{
					ai[0] += 1f;
					if (ai[0] >= 10f)
					{
						velocity.Y += 0.25f;
						velocity.X *= 0.99f;
					}
				}
				else if (type == 166)
				{
					ai[0] += 1f;
					if (ai[0] >= 20f)
					{
						velocity.Y += 0.3f;
						velocity.X *= 0.98f;
					}
				}
				else if (type == 300)
				{
					if (ai[0] == 0f)
					{
						Main.PlaySound(2, (int)position.X, (int)position.Y);
					}
					ai[0] += 1f;
					if (ai[0] >= 60f)
					{
						velocity.Y += 0.2f;
						velocity.X *= 0.99f;
					}
				}
				else if (type == 306)
				{
					if (alpha <= 200)
					{
						for (int num65 = 0; num65 < 4; num65++)
						{
							float num66 = velocity.X / 4f * (float)num65;
							float num67 = velocity.Y / 4f * (float)num65;
							int num68 = Dust.NewDust(position, width, height, 184);
							Main.dust[num68].position.X = center().X - num66;
							Main.dust[num68].position.Y = center().Y - num67;
							Main.dust[num68].velocity *= 0f;
							Main.dust[num68].scale = 0.7f;
						}
					}
					alpha -= 50;
					if (alpha < 0)
					{
						alpha = 0;
					}
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 0.785f;
				}
				else if (type == 304)
				{
					ai[0] += 1f;
					if (ai[0] >= 30f)
					{
						alpha += 10;
						damage = (int)((double)damage * 0.9);
						knockBack = (int)((double)knockBack * 0.9);
						if (alpha >= 255)
						{
							active = false;
						}
					}
					if (ai[0] < 30f)
					{
						rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
					}
				}
				else if (type == 370 || type == 371)
				{
					ai[0] += 1f;
					if (ai[0] >= 15f)
					{
						velocity.Y += 0.3f;
						velocity.X *= 0.98f;
					}
				}
				else
				{
					ai[0] += 1f;
					if (ai[0] >= 20f)
					{
						velocity.Y += 0.4f;
						velocity.X *= 0.97f;
					}
					else if (type == 48 || type == 54 || type == 93)
					{
						rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
					}
				}
				if (velocity.Y > 16f)
				{
					velocity.Y = 16f;
				}
				if (type == 54 && Main.rand.Next(20) == 0)
				{
					Dust.NewDust(new Vector2(position.X, position.Y), width, height, 40, velocity.X * 0.1f, velocity.Y * 0.1f, 0, default(Color), 0.75f);
				}
			}
			else if (aiStyle == 3)
			{
				if (soundDelay == 0 && type != 383)
				{
					soundDelay = 8;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 7);
				}
				if (type == 19)
				{
					for (int num69 = 0; num69 < 2; num69++)
					{
						int num70 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num70].noGravity = true;
						Main.dust[num70].velocity.X *= 0.3f;
						Main.dust[num70].velocity.Y *= 0.3f;
					}
				}
				else if (type == 33)
				{
					if (Main.rand.Next(1) == 0)
					{
						int num71 = Dust.NewDust(position, width, height, 40, velocity.X * 0.25f, velocity.Y * 0.25f, 0, default(Color), 1.4f);
						Main.dust[num71].noGravity = true;
					}
				}
				else if (type == 320)
				{
					if (Main.rand.Next(3) == 0)
					{
						int num72 = Dust.NewDust(position, width, height, 5, velocity.X * 0.25f, velocity.Y * 0.25f, 0, default(Color), 1.1f);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num72].scale = 0.9f;
							Main.dust[num72].velocity *= 0.2f;
						}
						else
						{
							Main.dust[num72].noGravity = true;
						}
					}
				}
				else if (type == 6)
				{
					if (Main.rand.Next(5) == 0)
					{
						int num73;
						switch (Main.rand.Next(3))
						{
						case 0:
							num73 = 15;
							break;
						case 1:
							num73 = 57;
							break;
						default:
							num73 = 58;
							break;
						}
						Dust.NewDust(position, width, height, num73, velocity.X * 0.25f, velocity.Y * 0.25f, 150, default(Color), 0.7f);
					}
				}
				else if (type == 113 && Main.rand.Next(1) == 0)
				{
					int num74 = Dust.NewDust(position, width, height, 76, velocity.X * 0.15f, velocity.Y * 0.15f, 0, default(Color), 1.1f);
					Main.dust[num74].noGravity = true;
					Dust.NewDust(position, width, height, 15, velocity.X * 0.05f, velocity.Y * 0.05f, 150, default(Color), 0.6f);
				}
				if (ai[0] == 0f)
				{
					ai[1] += 1f;
					if (type == 106 && ai[1] >= 45f)
					{
						ai[0] = 1f;
						ai[1] = 0f;
						netUpdate = true;
					}
					if (type == 320 || type == 383)
					{
						if (ai[1] >= 10f)
						{
							velocity.Y += 0.5f;
							if (type == 383 && velocity.Y < 0f)
							{
								velocity.Y += 0.35f;
							}
							velocity.X *= 0.95f;
							if (velocity.Y > 16f)
							{
								velocity.Y = 16f;
							}
							if (type == 383 && Vector2.Distance(center(), Main.player[owner].center()) > 800f)
							{
								ai[0] = 1f;
							}
						}
					}
					else if (type == 182)
					{
						if (Main.rand.Next(2) == 0)
						{
							int num75 = Dust.NewDust(position, width, height, 57, 0f, 0f, 255, default(Color), 0.75f);
							Main.dust[num75].velocity *= 0.1f;
							Main.dust[num75].noGravity = true;
						}
						if (velocity.X > 0f)
						{
							spriteDirection = 1;
						}
						else if (velocity.X < 0f)
						{
							spriteDirection = -1;
						}
						float num76 = position.X;
						float num77 = position.Y;
						bool flag2 = false;
						if (ai[1] > 10f)
						{
							for (int num78 = 0; num78 < 200; num78++)
							{
								if (Main.npc[num78].active && !Main.npc[num78].dontTakeDamage && !Main.npc[num78].friendly && Main.npc[num78].lifeMax > 5)
								{
									float num79 = Main.npc[num78].position.X + (float)(Main.npc[num78].width / 2);
									float num80 = Main.npc[num78].position.Y + (float)(Main.npc[num78].height / 2);
									float num81 = Math.Abs(position.X + (float)(width / 2) - num79) + Math.Abs(position.Y + (float)(height / 2) - num80);
									if (num81 < 800f && Collision.CanHit(new Vector2(position.X + (float)(width / 2), position.Y + (float)(height / 2)), 1, 1, Main.npc[num78].position, Main.npc[num78].width, Main.npc[num78].height))
									{
										num76 = num79;
										num77 = num80;
										flag2 = true;
									}
								}
							}
						}
						if (!flag2)
						{
							num76 = position.X + (float)(width / 2) + velocity.X * 100f;
							num77 = position.Y + (float)(height / 2) + velocity.Y * 100f;
							if (ai[1] >= 30f)
							{
								ai[0] = 1f;
								ai[1] = 0f;
								netUpdate = true;
							}
						}
						float num82 = 12f;
						float num83 = 0.25f;
						Vector2 vector2 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
						float num84 = num76 - vector2.X;
						float num85 = num77 - vector2.Y;
						float num86 = (float)Math.Sqrt(num84 * num84 + num85 * num85);
						num86 = num82 / num86;
						num84 *= num86;
						num85 *= num86;
						if (velocity.X < num84)
						{
							velocity.X += num83;
							if (velocity.X < 0f && num84 > 0f)
							{
								velocity.X += num83 * 2f;
							}
						}
						else if (velocity.X > num84)
						{
							velocity.X -= num83;
							if (velocity.X > 0f && num84 < 0f)
							{
								velocity.X -= num83 * 2f;
							}
						}
						if (velocity.Y < num85)
						{
							velocity.Y += num83;
							if (velocity.Y < 0f && num85 > 0f)
							{
								velocity.Y += num83 * 2f;
							}
						}
						else if (velocity.Y > num85)
						{
							velocity.Y -= num83;
							if (velocity.Y > 0f && num85 < 0f)
							{
								velocity.Y -= num83 * 2f;
							}
						}
					}
					else if (type == 301)
					{
						if (ai[1] >= 20f)
						{
							ai[0] = 1f;
							ai[1] = 0f;
							netUpdate = true;
						}
					}
					else if (ai[1] >= 30f)
					{
						ai[0] = 1f;
						ai[1] = 0f;
						netUpdate = true;
					}
				}
				else
				{
					tileCollide = false;
					float num87 = 9f;
					float num88 = 0.4f;
					if (type == 19)
					{
						num87 = 13f;
						num88 = 0.6f;
					}
					else if (type == 33)
					{
						num87 = 15f;
						num88 = 0.8f;
					}
					else if (type == 182)
					{
						num87 = 16f;
						num88 = 1.2f;
					}
					else if (type == 106)
					{
						num87 = 16f;
						num88 = 1.2f;
					}
					else if (type == 272)
					{
						num87 = 15f;
						num88 = 1f;
					}
					else if (type == 333)
					{
						num87 = 12f;
						num88 = 0.6f;
					}
					else if (type == 301)
					{
						num87 = 15f;
						num88 = 3f;
					}
					else if (type == 320)
					{
						num87 = 15f;
						num88 = 3f;
					}
					else if (type == 383)
					{
						num87 = 16f;
						num88 = 4f;
					}
					Vector2 vector3 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
					float num89 = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - vector3.X;
					float num90 = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - vector3.Y;
					float num91 = (float)Math.Sqrt(num89 * num89 + num90 * num90);
					if (num91 > 3000f)
					{
						Kill();
					}
					num91 = num87 / num91;
					num89 *= num91;
					num90 *= num91;
					if (type == 383)
					{
						Vector2 vector4 = new Vector2(num89, num90) - velocity;
						if (vector4 != Vector2.Zero)
						{
							Vector2 vector5 = vector4;
							vector5.Normalize();
							velocity += vector5 * Math.Min(num88, vector4.Length());
						}
					}
					else
					{
						if (velocity.X < num89)
						{
							velocity.X += num88;
							if (velocity.X < 0f && num89 > 0f)
							{
								velocity.X += num88;
							}
						}
						else if (velocity.X > num89)
						{
							velocity.X -= num88;
							if (velocity.X > 0f && num89 < 0f)
							{
								velocity.X -= num88;
							}
						}
						if (velocity.Y < num90)
						{
							velocity.Y += num88;
							if (velocity.Y < 0f && num90 > 0f)
							{
								velocity.Y += num88;
							}
						}
						else if (velocity.Y > num90)
						{
							velocity.Y -= num88;
							if (velocity.Y > 0f && num90 < 0f)
							{
								velocity.Y -= num88;
							}
						}
					}
					if (Main.myPlayer == owner)
					{
						Rectangle rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
						Rectangle value = new Rectangle((int)Main.player[owner].position.X, (int)Main.player[owner].position.Y, Main.player[owner].width, Main.player[owner].height);
						if (rectangle.Intersects(value))
						{
							Kill();
						}
					}
				}
				if (type == 106)
				{
					rotation += 0.3f * (float)direction;
				}
				else if (type == 383)
				{
					if (ai[0] == 0f)
					{
						Vector2 vector6 = velocity;
						vector6.Normalize();
						rotation = (float)Math.Atan2(vector6.Y, vector6.X) + 1.57f;
					}
					else
					{
						Vector2 vector7 = center() - Main.player[owner].center();
						vector7.Normalize();
						rotation = (float)Math.Atan2(vector7.Y, vector7.X) + 1.57f;
					}
				}
				else
				{
					rotation += 0.4f * (float)direction;
				}
			}
			else if (aiStyle == 4)
			{
				rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
				if (ai[0] == 0f)
				{
					if (type >= 150 && type <= 152 && ai[1] == 0f && alpha == 255 && Main.rand.Next(2) == 0)
					{
						type++;
						netUpdate = true;
					}
					alpha -= 50;
					if (type >= 150 && type <= 152)
					{
						alpha -= 25;
					}
					if (alpha <= 0)
					{
						alpha = 0;
						ai[0] = 1f;
						if (ai[1] == 0f)
						{
							ai[1] += 1f;
							position += velocity * 1f;
						}
						if (type == 7 && Main.myPlayer == owner)
						{
							int num92 = type;
							if (ai[1] >= 6f)
							{
								num92++;
							}
							int num93 = NewProjectile(position.X + velocity.X + (float)(width / 2), position.Y + velocity.Y + (float)(height / 2), velocity.X, velocity.Y, num92, damage, knockBack, owner);
							Main.projectile[num93].damage = damage;
							Main.projectile[num93].ai[1] = ai[1] + 1f;
							NetMessage.SendData(27, -1, -1, "", num93);
						}
						else if ((type == 150 || type == 151) && Main.myPlayer == owner)
						{
							int num94 = type;
							if (type == 150)
							{
								num94 = 151;
							}
							else if (type == 151)
							{
								num94 = 150;
							}
							if (ai[1] >= 10f && type == 151)
							{
								num94 = 152;
							}
							int num95 = NewProjectile(position.X + velocity.X + (float)(width / 2), position.Y + velocity.Y + (float)(height / 2), velocity.X, velocity.Y, num94, damage, knockBack, owner);
							Main.projectile[num95].damage = damage;
							Main.projectile[num95].ai[1] = ai[1] + 1f;
							NetMessage.SendData(27, -1, -1, "", num95);
						}
					}
				}
				else
				{
					if (alpha < 170 && alpha + 5 >= 170)
					{
						if (type >= 150 && type <= 152)
						{
							for (int num96 = 0; num96 < 8; num96++)
							{
								int num97 = Dust.NewDust(position, width, height, 7, velocity.X * 0.025f, velocity.Y * 0.025f, 200, default(Color), 1.3f);
								Main.dust[num97].noGravity = true;
								Main.dust[num97].velocity *= 0.5f;
							}
						}
						else
						{
							for (int num98 = 0; num98 < 3; num98++)
							{
								Dust.NewDust(position, width, height, 18, velocity.X * 0.025f, velocity.Y * 0.025f, 170, default(Color), 1.2f);
							}
							Dust.NewDust(position, width, height, 14, 0f, 0f, 170, default(Color), 1.1f);
						}
					}
					if (type >= 150 && type <= 152)
					{
						alpha += 3;
					}
					else
					{
						alpha += 5;
					}
					if (alpha >= 255)
					{
						Kill();
					}
				}
			}
			else if (aiStyle == 5)
			{
				if (type == 92)
				{
					if (position.Y > ai[1])
					{
						tileCollide = true;
					}
				}
				else
				{
					if (ai[1] == 0f && !Collision.SolidCollision(position, width, height))
					{
						ai[1] = 1f;
						netUpdate = true;
					}
					if (ai[1] != 0f)
					{
						tileCollide = true;
					}
				}
				if (soundDelay == 0)
				{
					soundDelay = 20 + Main.rand.Next(40);
					Main.PlaySound(2, (int)position.X, (int)position.Y, 9);
				}
				if (localAI[0] == 0f)
				{
					localAI[0] = 1f;
				}
				alpha += (int)(25f * localAI[0]);
				if (alpha > 200)
				{
					alpha = 200;
					localAI[0] = -1f;
				}
				if (alpha < 0)
				{
					alpha = 0;
					localAI[0] = 1f;
				}
				rotation += (Math.Abs(velocity.X) + Math.Abs(velocity.Y)) * 0.01f * (float)direction;
				if (ai[1] == 1f || type == 92)
				{
					light = 0.9f;
					if (Main.rand.Next(10) == 0)
					{
						Dust.NewDust(position, width, height, 58, velocity.X * 0.5f, velocity.Y * 0.5f, 150, default(Color), 1.2f);
					}
					if (Main.rand.Next(20) == 0)
					{
						Gore.NewGore(position, new Vector2(velocity.X * 0.2f, velocity.Y * 0.2f), Main.rand.Next(16, 18));
					}
				}
			}
			else if (aiStyle == 6)
			{
				velocity *= 0.95f;
				ai[0] += 1f;
				if (ai[0] == 180f)
				{
					Kill();
				}
				if (ai[1] == 0f)
				{
					ai[1] = 1f;
					for (int num99 = 0; num99 < 30; num99++)
					{
						Dust.NewDust(position, width, height, 10 + type, velocity.X, velocity.Y, 50);
					}
				}
				if (type == 10 || type == 11)
				{
					int num100 = (int)(position.X / 16f) - 1;
					int num101 = (int)((position.X + (float)width) / 16f) + 2;
					int num102 = (int)(position.Y / 16f) - 1;
					int num103 = (int)((position.Y + (float)height) / 16f) + 2;
					if (num100 < 0)
					{
						num100 = 0;
					}
					if (num101 > Main.maxTilesX)
					{
						num101 = Main.maxTilesX;
					}
					if (num102 < 0)
					{
						num102 = 0;
					}
					if (num103 > Main.maxTilesY)
					{
						num103 = Main.maxTilesY;
					}
					Vector2 vector8 = default(Vector2);
					for (int num104 = num100; num104 < num101; num104++)
					{
						for (int num105 = num102; num105 < num103; num105++)
						{
							vector8.X = num104 * 16;
							vector8.Y = num105 * 16;
							if (!(position.X + (float)width > vector8.X) || !(position.X < vector8.X + 16f) || !(position.Y + (float)height > vector8.Y) || !(position.Y < vector8.Y + 16f) || Main.myPlayer != owner || !Main.tile[num104, num105].active())
							{
								continue;
							}
							if (type == 10)
							{
								if (Main.tile[num104, num105].type == 23 || Main.tile[num104, num105].type == 199)
								{
									Main.tile[num104, num105].type = 2;
									WorldGen.SquareTileFrame(num104, num105);
									if (Main.netMode == 1)
									{
										NetMessage.SendTileSquare(-1, num104, num105, 1);
									}
								}
								if (Main.tile[num104, num105].type == 25 || Main.tile[num104, num105].type == 203)
								{
									Main.tile[num104, num105].type = 1;
									WorldGen.SquareTileFrame(num104, num105);
									if (Main.netMode == 1)
									{
										NetMessage.SendTileSquare(-1, num104, num105, 1);
									}
								}
								if (Main.tile[num104, num105].type == 112 || Main.tile[num104, num105].type == 234)
								{
									Main.tile[num104, num105].type = 53;
									WorldGen.SquareTileFrame(num104, num105);
									if (Main.netMode == 1)
									{
										NetMessage.SendTileSquare(-1, num104, num105, 1);
									}
								}
								if (Main.tile[num104, num105].type == 163 || Main.tile[num104, num105].type == 200)
								{
									Main.tile[num104, num105].type = 161;
									WorldGen.SquareTileFrame(num104, num105);
									if (Main.netMode == 1)
									{
										NetMessage.SendTileSquare(-1, num104, num105, 1);
									}
								}
							}
							else
							{
								if (type != 11)
								{
									continue;
								}
								if (Main.tile[num104, num105].type == 109)
								{
									Main.tile[num104, num105].type = 2;
									WorldGen.SquareTileFrame(num104, num105);
									if (Main.netMode == 1)
									{
										NetMessage.SendTileSquare(-1, num104, num105, 1);
									}
								}
								if (Main.tile[num104, num105].type == 116)
								{
									Main.tile[num104, num105].type = 53;
									WorldGen.SquareTileFrame(num104, num105);
									if (Main.netMode == 1)
									{
										NetMessage.SendTileSquare(-1, num104, num105, 1);
									}
								}
								if (Main.tile[num104, num105].type == 117)
								{
									Main.tile[num104, num105].type = 1;
									WorldGen.SquareTileFrame(num104, num105);
									if (Main.netMode == 1)
									{
										NetMessage.SendTileSquare(-1, num104, num105, 1);
									}
								}
								if (Main.tile[num104, num105].type == 164)
								{
									Main.tile[num104, num105].type = 161;
									WorldGen.SquareTileFrame(num104, num105);
									if (Main.netMode == 1)
									{
										NetMessage.SendTileSquare(-1, num104, num105, 1);
									}
								}
							}
						}
					}
				}
			}
			else if (aiStyle == 7)
			{
				if (Main.player[owner].dead)
				{
					Kill();
					return;
				}
				Vector2 vector9 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
				float num106 = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - vector9.X;
				float num107 = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - vector9.Y;
				float num108 = (float)Math.Sqrt(num106 * num106 + num107 * num107);
				rotation = (float)Math.Atan2(num107, num106) - 1.57f;
				if (type == 256)
				{
					rotation = (float)Math.Atan2(num107, num106) + 3.9250002f;
				}
				if (ai[0] == 0f)
				{
					if ((num108 > 300f && type == 13) || (num108 > 400f && type == 32) || (num108 > 440f && type == 73) || (num108 > 440f && type == 74) || (num108 > 250f && type == 165) || (num108 > 350f && type == 256) || (num108 > 500f && type == 315) || (num108 > 550f && type == 322) || (num108 > 400f && type == 331) || (num108 > 550f && type == 332) || (num108 > 400f && type == 372) || (num108 > 400f && type == 396))
					{
						ai[0] = 1f;
					}
					else if (type >= 230 && type <= 235)
					{
						int num109 = 300 + (type - 230) * 30;
						if (num108 > (float)num109)
						{
							ai[0] = 1f;
						}
					}
					int num110 = (int)(position.X / 16f) - 1;
					int num111 = (int)((position.X + (float)width) / 16f) + 2;
					int num112 = (int)(position.Y / 16f) - 1;
					int num113 = (int)((position.Y + (float)height) / 16f) + 2;
					if (num110 < 0)
					{
						num110 = 0;
					}
					if (num111 > Main.maxTilesX)
					{
						num111 = Main.maxTilesX;
					}
					if (num112 < 0)
					{
						num112 = 0;
					}
					if (num113 > Main.maxTilesY)
					{
						num113 = Main.maxTilesY;
					}
					Vector2 vector10 = default(Vector2);
					for (int num114 = num110; num114 < num111; num114++)
					{
						for (int num115 = num112; num115 < num113; num115++)
						{
							if (Main.tile[num114, num115] == null)
							{
								Main.tile[num114, num115] = new Tile();
							}
							vector10.X = num114 * 16;
							vector10.Y = num115 * 16;
							if (!(position.X + (float)width > vector10.X) || !(position.X < vector10.X + 16f) || !(position.Y + (float)height > vector10.Y) || !(position.Y < vector10.Y + 16f) || !Main.tile[num114, num115].nactive() || (!Main.tileSolid[Main.tile[num114, num115].type] && Main.tile[num114, num115].type != 314) || (type == 403 && Main.tile[num114, num115].type != 314))
							{
								continue;
							}
							if (Main.player[owner].grapCount < 10)
							{
								Main.player[owner].grappling[Main.player[owner].grapCount] = whoAmI;
								Main.player[owner].grapCount++;
							}
							if (Main.myPlayer == owner)
							{
								int num116 = 0;
								int num117 = -1;
								int num118 = 100000;
								if (type == 73 || type == 74)
								{
									for (int num119 = 0; num119 < 1000; num119++)
									{
										if (num119 != whoAmI && Main.projectile[num119].active && Main.projectile[num119].owner == owner && Main.projectile[num119].aiStyle == 7 && Main.projectile[num119].ai[0] == 2f)
										{
											Main.projectile[num119].Kill();
										}
									}
								}
								else
								{
									int num120 = 3;
									if (type == 165)
									{
										num120 = 8;
									}
									if (type == 256)
									{
										num120 = 2;
									}
									if (type == 372)
									{
										num120 = 1;
									}
									for (int num121 = 0; num121 < 1000; num121++)
									{
										if (Main.projectile[num121].active && Main.projectile[num121].owner == owner && Main.projectile[num121].aiStyle == 7)
										{
											if (Main.projectile[num121].timeLeft < num118)
											{
												num117 = num121;
												num118 = Main.projectile[num121].timeLeft;
											}
											num116++;
										}
									}
									if (num116 > num120)
									{
										Main.projectile[num117].Kill();
									}
								}
							}
							WorldGen.KillTile(num114, num115, true, true);
							Main.PlaySound(0, num114 * 16, num115 * 16);
							velocity.X = 0f;
							velocity.Y = 0f;
							ai[0] = 2f;
							position.X = num114 * 16 + 8 - width / 2;
							position.Y = num115 * 16 + 8 - height / 2;
							damage = 0;
							netUpdate = true;
							if (Main.myPlayer == owner)
							{
								NetMessage.SendData(13, -1, -1, "", owner);
							}
							break;
						}
						if (ai[0] == 2f)
						{
							break;
						}
					}
				}
				else if (ai[0] == 1f)
				{
					float num122 = 11f;
					if (type == 32)
					{
						num122 = 15f;
					}
					if (type == 73 || type == 74)
					{
						num122 = 17f;
					}
					if (type == 315)
					{
						num122 = 20f;
					}
					if (type == 322)
					{
						num122 = 22f;
					}
					if (type >= 230 && type <= 235)
					{
						num122 = 11f + (float)(type - 230) * 0.75f;
					}
					if (type == 332)
					{
						num122 = 17f;
					}
					if (num108 < 24f)
					{
						Kill();
					}
					num108 = num122 / num108;
					num106 *= num108;
					num107 *= num108;
					velocity.X = num106;
					velocity.Y = num107;
				}
				else if (ai[0] == 2f)
				{
					int num123 = (int)(position.X / 16f) - 1;
					int num124 = (int)((position.X + (float)width) / 16f) + 2;
					int num125 = (int)(position.Y / 16f) - 1;
					int num126 = (int)((position.Y + (float)height) / 16f) + 2;
					if (num123 < 0)
					{
						num123 = 0;
					}
					if (num124 > Main.maxTilesX)
					{
						num124 = Main.maxTilesX;
					}
					if (num125 < 0)
					{
						num125 = 0;
					}
					if (num126 > Main.maxTilesY)
					{
						num126 = Main.maxTilesY;
					}
					bool flag3 = true;
					Vector2 vector11 = default(Vector2);
					for (int num127 = num123; num127 < num124; num127++)
					{
						for (int num128 = num125; num128 < num126; num128++)
						{
							if (Main.tile[num127, num128] == null)
							{
								Main.tile[num127, num128] = new Tile();
							}
							vector11.X = num127 * 16;
							vector11.Y = num128 * 16;
							if (position.X + (float)(width / 2) > vector11.X && position.X + (float)(width / 2) < vector11.X + 16f && position.Y + (float)(height / 2) > vector11.Y && position.Y + (float)(height / 2) < vector11.Y + 16f && Main.tile[num127, num128].nactive() && (Main.tileSolid[Main.tile[num127, num128].type] || Main.tile[num127, num128].type == 314))
							{
								flag3 = false;
							}
						}
					}
					if (flag3)
					{
						ai[0] = 1f;
					}
					else if (Main.player[owner].grapCount < 10)
					{
						Main.player[owner].grappling[Main.player[owner].grapCount] = whoAmI;
						Main.player[owner].grapCount++;
					}
				}
			}
			else if (aiStyle == 8)
			{
				if (type == 258 && localAI[0] == 0f)
				{
					localAI[0] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 20);
				}
				if (type == 96 && localAI[0] == 0f)
				{
					localAI[0] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 20);
				}
				if (type == 27)
				{
					for (int num129 = 0; num129 < 5; num129++)
					{
						float num130 = velocity.X / 3f * (float)num129;
						float num131 = velocity.Y / 3f * (float)num129;
						int num132 = 4;
						int num133 = Dust.NewDust(new Vector2(position.X + (float)num132, position.Y + (float)num132), width - num132 * 2, height - num132 * 2, 172, 0f, 0f, 100, default(Color), 1.2f);
						Main.dust[num133].noGravity = true;
						Main.dust[num133].velocity *= 0.1f;
						Main.dust[num133].velocity += velocity * 0.1f;
						Main.dust[num133].position.X -= num130;
						Main.dust[num133].position.Y -= num131;
					}
					if (Main.rand.Next(5) == 0)
					{
						int num134 = 4;
						int num135 = Dust.NewDust(new Vector2(position.X + (float)num134, position.Y + (float)num134), width - num134 * 2, height - num134 * 2, 172, 0f, 0f, 100, default(Color), 0.6f);
						Main.dust[num135].velocity *= 0.25f;
						Main.dust[num135].velocity += velocity * 0.5f;
					}
				}
				else if (type == 95 || type == 96)
				{
					int num136 = Dust.NewDust(new Vector2(position.X + velocity.X, position.Y + velocity.Y), width, height, 75, velocity.X, velocity.Y, 100, default(Color), 3f * scale);
					Main.dust[num136].noGravity = true;
				}
				else if (type == 253)
				{
					for (int num137 = 0; num137 < 2; num137++)
					{
						int num138 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 135, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num138].noGravity = true;
						Main.dust[num138].velocity.X *= 0.3f;
						Main.dust[num138].velocity.Y *= 0.3f;
					}
				}
				else
				{
					for (int num139 = 0; num139 < 2; num139++)
					{
						int num140 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2f);
						Main.dust[num140].noGravity = true;
						Main.dust[num140].velocity.X *= 0.3f;
						Main.dust[num140].velocity.Y *= 0.3f;
					}
				}
				if (type != 27 && type != 96 && type != 258)
				{
					ai[1] += 1f;
				}
				if (ai[1] >= 20f)
				{
					velocity.Y += 0.2f;
				}
				rotation += 0.3f * (float)direction;
				if (velocity.Y > 16f)
				{
					velocity.Y = 16f;
				}
			}
			else if (aiStyle == 9)
			{
				if (type == 34)
				{
					int num141 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 3.5f);
					Main.dust[num141].noGravity = true;
					Main.dust[num141].velocity *= 1.4f;
					num141 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 1.5f);
				}
				else if (type == 79)
				{
					if (soundDelay == 0 && Math.Abs(velocity.X) + Math.Abs(velocity.Y) > 2f)
					{
						soundDelay = 10;
						Main.PlaySound(2, (int)position.X, (int)position.Y, 9);
					}
					for (int num142 = 0; num142 < 1; num142++)
					{
						int num143 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2.5f);
						Main.dust[num143].velocity *= 0.1f;
						Main.dust[num143].velocity += velocity * 0.2f;
						Main.dust[num143].position.X = position.X + (float)(width / 2) + 4f + (float)Main.rand.Next(-2, 3);
						Main.dust[num143].position.Y = position.Y + (float)(height / 2) + (float)Main.rand.Next(-2, 3);
						Main.dust[num143].noGravity = true;
					}
				}
				else
				{
					if (soundDelay == 0 && Math.Abs(velocity.X) + Math.Abs(velocity.Y) > 2f)
					{
						soundDelay = 10;
						Main.PlaySound(2, (int)position.X, (int)position.Y, 9);
					}
					int num144 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 15, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num144].velocity *= 0.3f;
					Main.dust[num144].position.X = position.X + (float)(width / 2) + 4f + (float)Main.rand.Next(-4, 5);
					Main.dust[num144].position.Y = position.Y + (float)(height / 2) + (float)Main.rand.Next(-4, 5);
					Main.dust[num144].noGravity = true;
				}
				if (Main.myPlayer == owner && ai[0] == 0f)
				{
					if (Main.player[owner].channel)
					{
						float num145 = 12f;
						if (type == 16)
						{
							num145 = 15f;
						}
						Vector2 vector12 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
						float num146 = (float)Main.mouseX + Main.screenPosition.X - vector12.X;
						float num147 = (float)Main.mouseY + Main.screenPosition.Y - vector12.Y;
						if (Main.player[owner].gravDir == -1f)
						{
							num147 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector12.Y;
						}
						float num148 = (float)Math.Sqrt(num146 * num146 + num147 * num147);
						num148 = (float)Math.Sqrt(num146 * num146 + num147 * num147);
						if (num148 > num145)
						{
							num148 = num145 / num148;
							num146 *= num148;
							num147 *= num148;
							int num149 = (int)(num146 * 1000f);
							int num150 = (int)(velocity.X * 1000f);
							int num151 = (int)(num147 * 1000f);
							int num152 = (int)(velocity.Y * 1000f);
							if (num149 != num150 || num151 != num152)
							{
								netUpdate = true;
							}
							velocity.X = num146;
							velocity.Y = num147;
						}
						else
						{
							int num153 = (int)(num146 * 1000f);
							int num154 = (int)(velocity.X * 1000f);
							int num155 = (int)(num147 * 1000f);
							int num156 = (int)(velocity.Y * 1000f);
							if (num153 != num154 || num155 != num156)
							{
								netUpdate = true;
							}
							velocity.X = num146;
							velocity.Y = num147;
						}
					}
					else if (ai[0] == 0f)
					{
						ai[0] = 1f;
						netUpdate = true;
						float num157 = 12f;
						Vector2 vector13 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
						float num158 = (float)Main.mouseX + Main.screenPosition.X - vector13.X;
						float num159 = (float)Main.mouseY + Main.screenPosition.Y - vector13.Y;
						if (Main.player[owner].gravDir == -1f)
						{
							num159 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector13.Y;
						}
						float num160 = (float)Math.Sqrt(num158 * num158 + num159 * num159);
						if (num160 == 0f)
						{
							vector13 = new Vector2(Main.player[owner].position.X + (float)(Main.player[owner].width / 2), Main.player[owner].position.Y + (float)(Main.player[owner].height / 2));
							num158 = position.X + (float)width * 0.5f - vector13.X;
							num159 = position.Y + (float)height * 0.5f - vector13.Y;
							num160 = (float)Math.Sqrt(num158 * num158 + num159 * num159);
						}
						num160 = num157 / num160;
						num158 *= num160;
						num159 *= num160;
						velocity.X = num158;
						velocity.Y = num159;
						if (velocity.X == 0f && velocity.Y == 0f)
						{
							Kill();
						}
					}
				}
				if (type == 34)
				{
					rotation += 0.3f * (float)direction;
				}
				else if (velocity.X != 0f || velocity.Y != 0f)
				{
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 2.355f;
				}
				if (velocity.Y > 16f)
				{
					velocity.Y = 16f;
				}
			}
			else if (aiStyle == 10)
			{
				if (type == 31 && ai[0] != 2f)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num161 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 32, 0f, velocity.Y / 2f);
						Main.dust[num161].velocity.X *= 0.4f;
					}
				}
				else if (type == 39)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num162 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 38, 0f, velocity.Y / 2f);
						Main.dust[num162].velocity.X *= 0.4f;
					}
				}
				else if (type >= 411 && type <= 414)
				{
					if (Main.rand.Next(3) == 0)
					{
						int num163 = 9;
						if (type == 412 || type == 414)
						{
							num163 = 11;
						}
						if (type == 413)
						{
							num163 = 19;
						}
						int num164 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, num163, 0f, velocity.Y / 2f);
						Main.dust[num164].noGravity = true;
						Main.dust[num164].velocity -= velocity * 0.5f;
					}
				}
				else if (type == 40)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num165 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 36, 0f, velocity.Y / 2f);
						Main.dust[num165].velocity *= 0.4f;
					}
				}
				else if (type == 42 || type == 31)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num166 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 32);
						Main.dust[num166].velocity.X *= 0.4f;
					}
				}
				else if (type == 56 || type == 65)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num167 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 14);
						Main.dust[num167].velocity.X *= 0.4f;
					}
				}
				else if (type == 67 || type == 68)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num168 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 51);
						Main.dust[num168].velocity.X *= 0.4f;
					}
				}
				else if (type == 71)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num169 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 53);
						Main.dust[num169].velocity.X *= 0.4f;
					}
				}
				else if (type == 179)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num170 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 149);
						Main.dust[num170].velocity.X *= 0.4f;
					}
				}
				else if (type == 241 || type == 354)
				{
					if (Main.rand.Next(2) == 0)
					{
						int num171 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 36);
						Main.dust[num171].velocity.X *= 0.4f;
					}
				}
				else if (type != 109 && Main.rand.Next(20) == 0)
				{
					Dust.NewDust(new Vector2(position.X, position.Y), width, height, 0);
				}
				if (Main.myPlayer == owner && ai[0] == 0f)
				{
					if (Main.player[owner].channel)
					{
						float num172 = 12f;
						Vector2 vector14 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
						float num173 = (float)Main.mouseX + Main.screenPosition.X - vector14.X;
						float num174 = (float)Main.mouseY + Main.screenPosition.Y - vector14.Y;
						if (Main.player[owner].gravDir == -1f)
						{
							num174 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector14.Y;
						}
						float num175 = (float)Math.Sqrt(num173 * num173 + num174 * num174);
						num175 = (float)Math.Sqrt(num173 * num173 + num174 * num174);
						if (num175 > num172)
						{
							num175 = num172 / num175;
							num173 *= num175;
							num174 *= num175;
							if (num173 != velocity.X || num174 != velocity.Y)
							{
								netUpdate = true;
							}
							velocity.X = num173;
							velocity.Y = num174;
						}
						else
						{
							if (num173 != velocity.X || num174 != velocity.Y)
							{
								netUpdate = true;
							}
							velocity.X = num173;
							velocity.Y = num174;
						}
					}
					else
					{
						ai[0] = 1f;
						netUpdate = true;
					}
				}
				if (ai[0] == 1f && type != 109)
				{
					if (type == 42 || type == 65 || type == 68 || type == 354)
					{
						ai[1] += 1f;
						if (ai[1] >= 60f)
						{
							ai[1] = 60f;
							velocity.Y += 0.2f;
						}
					}
					else
					{
						velocity.Y += 0.41f;
					}
				}
				else if (ai[0] == 2f && type != 109)
				{
					velocity.Y += 0.2f;
					if ((double)velocity.X < -0.04)
					{
						velocity.X += 0.04f;
					}
					else if ((double)velocity.X > 0.04)
					{
						velocity.X -= 0.04f;
					}
					else
					{
						velocity.X = 0f;
					}
				}
				rotation += 0.1f;
				if (velocity.Y > 10f)
				{
					velocity.Y = 10f;
				}
			}
			else if (aiStyle == 11)
			{
				if (type == 72 || type == 86 || type == 87)
				{
					if (velocity.X > 0f)
					{
						spriteDirection = -1;
					}
					else if (velocity.X < 0f)
					{
						spriteDirection = 1;
					}
					rotation = velocity.X * 0.1f;
					frameCounter++;
					if (frameCounter >= 4)
					{
						frame++;
						frameCounter = 0;
					}
					if (frame >= 4)
					{
						frame = 0;
					}
					if (Main.rand.Next(6) == 0)
					{
						int num176 = 56;
						if (type == 86)
						{
							num176 = 73;
						}
						else if (type == 87)
						{
							num176 = 74;
						}
						int num177 = Dust.NewDust(position, width, height, num176, 0f, 0f, 200, default(Color), 0.8f);
						Main.dust[num177].velocity *= 0.3f;
					}
				}
				else
				{
					rotation += 0.02f;
				}
				if (Main.myPlayer == owner)
				{
					if (type == 72)
					{
						if (Main.player[Main.myPlayer].blueFairy)
						{
							timeLeft = 2;
						}
					}
					else if (type == 86)
					{
						if (Main.player[Main.myPlayer].redFairy)
						{
							timeLeft = 2;
						}
					}
					else if (type == 87)
					{
						if (Main.player[Main.myPlayer].greenFairy)
						{
							timeLeft = 2;
						}
					}
					else if (Main.player[Main.myPlayer].lightOrb)
					{
						timeLeft = 2;
					}
				}
				if (!Main.player[owner].dead)
				{
					float num178 = 3f;
					if (type == 72 || type == 86 || type == 87)
					{
						num178 = 3.75f;
					}
					Vector2 vector15 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
					float num179 = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - vector15.X;
					float num180 = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - vector15.Y;
					int num181 = 70;
					if (type == 18)
					{
						if (Main.player[owner].controlUp)
						{
							num180 = Main.player[owner].position.Y - 40f - vector15.Y;
							num179 -= 6f;
							num181 = 4;
						}
						else if (Main.player[owner].controlDown)
						{
							num180 = Main.player[owner].position.Y + (float)Main.player[owner].height + 40f - vector15.Y;
							num179 -= 6f;
							num181 = 4;
						}
					}
					float num182 = (float)Math.Sqrt(num179 * num179 + num180 * num180);
					num182 = (float)Math.Sqrt(num179 * num179 + num180 * num180);
					if (type == 72 || type == 86 || type == 87)
					{
						num181 = 40;
					}
					if (num182 > 800f)
					{
						position.X = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - (float)(width / 2);
						position.Y = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - (float)(height / 2);
					}
					else if (num182 > (float)num181)
					{
						num182 = num178 / num182;
						num179 *= num182;
						num180 *= num182;
						velocity.X = num179;
						velocity.Y = num180;
					}
					else
					{
						velocity.X = 0f;
						velocity.Y = 0f;
					}
				}
				else
				{
					Kill();
				}
			}
			else if (aiStyle == 12)
			{
				if (type == 288 && localAI[0] == 0f)
				{
					localAI[0] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 17);
				}
				if (type == 280 || type == 288)
				{
					scale -= 0.002f;
					if (scale <= 0f)
					{
						Kill();
					}
					if (type == 288)
					{
						ai[0] = 4f;
					}
					if (ai[0] > 3f)
					{
						velocity.Y += 0.075f;
						for (int num183 = 0; num183 < 3; num183++)
						{
							float num184 = velocity.X / 3f * (float)num183;
							float num185 = velocity.Y / 3f * (float)num183;
							int num186 = 14;
							int num187 = Dust.NewDust(new Vector2(position.X + (float)num186, position.Y + (float)num186), width - num186 * 2, height - num186 * 2, 170, 0f, 0f, 100);
							Main.dust[num187].noGravity = true;
							Main.dust[num187].velocity *= 0.1f;
							Main.dust[num187].velocity += velocity * 0.5f;
							Main.dust[num187].position.X -= num184;
							Main.dust[num187].position.Y -= num185;
						}
						if (Main.rand.Next(8) == 0)
						{
							int num188 = 16;
							int num189 = Dust.NewDust(new Vector2(position.X + (float)num188, position.Y + (float)num188), width - num188 * 2, height - num188 * 2, 170, 0f, 0f, 100, default(Color), 0.5f);
							Main.dust[num189].velocity *= 0.25f;
							Main.dust[num189].velocity += velocity * 0.5f;
						}
					}
					else
					{
						ai[0] += 1f;
					}
				}
				else
				{
					scale -= 0.02f;
					if (scale <= 0f)
					{
						Kill();
					}
					if (ai[0] > 3f)
					{
						velocity.Y += 0.2f;
						for (int num190 = 0; num190 < 1; num190++)
						{
							for (int num191 = 0; num191 < 3; num191++)
							{
								float num192 = velocity.X / 3f * (float)num191;
								float num193 = velocity.Y / 3f * (float)num191;
								int num194 = 6;
								int num195 = Dust.NewDust(new Vector2(position.X + (float)num194, position.Y + (float)num194), width - num194 * 2, height - num194 * 2, 172, 0f, 0f, 100, default(Color), 1.2f);
								Main.dust[num195].noGravity = true;
								Main.dust[num195].velocity *= 0.3f;
								Main.dust[num195].velocity += velocity * 0.5f;
								Main.dust[num195].position.X -= num192;
								Main.dust[num195].position.Y -= num193;
							}
							if (Main.rand.Next(8) == 0)
							{
								int num196 = 6;
								int num197 = Dust.NewDust(new Vector2(position.X + (float)num196, position.Y + (float)num196), width - num196 * 2, height - num196 * 2, 172, 0f, 0f, 100, default(Color), 0.75f);
								Main.dust[num197].velocity *= 0.5f;
								Main.dust[num197].velocity += velocity * 0.5f;
							}
						}
					}
					else
					{
						ai[0] += 1f;
					}
				}
			}
			else if (aiStyle == 13)
			{
				if (Main.player[owner].dead)
				{
					Kill();
					return;
				}
				Main.player[owner].itemAnimation = 5;
				Main.player[owner].itemTime = 5;
				if (alpha == 0)
				{
					if (position.X + (float)(width / 2) > Main.player[owner].position.X + (float)(Main.player[owner].width / 2))
					{
						Main.player[owner].ChangeDir(1);
					}
					else
					{
						Main.player[owner].ChangeDir(-1);
					}
				}
				Vector2 vector16 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
				float num198 = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - vector16.X;
				float num199 = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - vector16.Y;
				float num200 = (float)Math.Sqrt(num198 * num198 + num199 * num199);
				if (ai[0] == 0f)
				{
					if (num200 > 700f)
					{
						ai[0] = 1f;
					}
					else if (type == 262 && num200 > 500f)
					{
						ai[0] = 1f;
					}
					else if (type == 271 && num200 > 200f)
					{
						ai[0] = 1f;
					}
					else if (type == 273 && num200 > 150f)
					{
						ai[0] = 1f;
					}
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
					ai[1] += 1f;
					if (ai[1] > 5f)
					{
						alpha = 0;
					}
					if (type == 262 && ai[1] > 8f)
					{
						ai[1] = 8f;
					}
					if (type == 271 && ai[1] > 8f)
					{
						ai[1] = 8f;
					}
					if (type == 273 && ai[1] > 8f)
					{
						ai[1] = 8f;
					}
					if (type == 404 && ai[1] > 8f)
					{
						ai[1] = 0f;
					}
					if (ai[1] >= 10f)
					{
						ai[1] = 15f;
						velocity.Y += 0.3f;
					}
					if (type == 262 && velocity.X < 0f)
					{
						spriteDirection = -1;
					}
					else if (type == 262)
					{
						spriteDirection = 1;
					}
					if (type == 271 && velocity.X < 0f)
					{
						spriteDirection = -1;
					}
					else if (type == 271)
					{
						spriteDirection = 1;
					}
				}
				else if (ai[0] == 1f)
				{
					tileCollide = false;
					rotation = (float)Math.Atan2(num199, num198) - 1.57f;
					float num201 = 20f;
					if (type == 262)
					{
						num201 = 30f;
					}
					if (num200 < 50f)
					{
						Kill();
					}
					num200 = num201 / num200;
					num198 *= num200;
					num199 *= num200;
					velocity.X = num198;
					velocity.Y = num199;
					if (type == 262 && velocity.X < 0f)
					{
						spriteDirection = 1;
					}
					else if (type == 262)
					{
						spriteDirection = -1;
					}
					if (type == 271 && velocity.X < 0f)
					{
						spriteDirection = 1;
					}
					else if (type == 271)
					{
						spriteDirection = -1;
					}
				}
			}
			else if (aiStyle == 14)
			{
				if (type == 352)
				{
					if (localAI[1] == 0f)
					{
						localAI[1] = 1f;
					}
					alpha += (int)(25f * localAI[1]);
					if (alpha <= 0)
					{
						alpha = 0;
						localAI[1] = 1f;
					}
					else if (alpha >= 255)
					{
						alpha = 255;
						localAI[1] = -1f;
					}
					scale += localAI[1] * 0.01f;
				}
				if (type == 346)
				{
					if (localAI[0] == 0f)
					{
						localAI[0] = 1f;
						Main.PlaySound(2, (int)position.X, (int)position.Y);
					}
					frame = (int)ai[1];
					if (owner == Main.myPlayer && timeLeft == 1)
					{
						for (int num202 = 0; num202 < 5; num202++)
						{
							float num203 = 10f;
							Vector2 vector17 = new Vector2(center().X, center().Y);
							float num204 = Main.rand.Next(-20, 21);
							float num205 = Main.rand.Next(-20, 0);
							float num206 = (float)Math.Sqrt(num204 * num204 + num205 * num205);
							num206 = num203 / num206;
							num204 *= num206;
							num205 *= num206;
							num204 *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
							num205 *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
							NewProjectile(vector17.X, vector17.Y, num204, num205, 347, 40, 0f, Main.myPlayer, 0f, ai[1]);
						}
					}
				}
				if (type == 196)
				{
					int num207 = Main.rand.Next(1, 3);
					for (int num208 = 0; num208 < num207; num208++)
					{
						int num209 = Dust.NewDust(position, width, height, 31, 0f, 0f, 100);
						Main.dust[num209].alpha += Main.rand.Next(100);
						Main.dust[num209].velocity *= 0.3f;
						Main.dust[num209].velocity.X += (float)Main.rand.Next(-10, 11) * 0.025f;
						Main.dust[num209].velocity.Y -= 0.4f + (float)Main.rand.Next(-3, 14) * 0.15f;
						Main.dust[num209].fadeIn = 1.25f + (float)Main.rand.Next(20) * 0.15f;
					}
				}
				if (type == 53)
				{
					try
					{
						Vector2 vector18 = Collision.TileCollision(position, velocity, width, height);
						bool flag34 = velocity != vector18;
						int num210 = (int)(position.X / 16f) - 1;
						int num211 = (int)((position.X + (float)width) / 16f) + 2;
						int num212 = (int)(position.Y / 16f) - 1;
						int num213 = (int)((position.Y + (float)height) / 16f) + 2;
						if (num210 < 0)
						{
							num210 = 0;
						}
						if (num211 > Main.maxTilesX)
						{
							num211 = Main.maxTilesX;
						}
						if (num212 < 0)
						{
							num212 = 0;
						}
						if (num213 > Main.maxTilesY)
						{
							num213 = Main.maxTilesY;
						}
						Vector2 vector19 = default(Vector2);
						for (int num214 = num210; num214 < num211; num214++)
						{
							for (int num215 = num212; num215 < num213; num215++)
							{
								if (Main.tile[num214, num215] != null && Main.tile[num214, num215].nactive() && (Main.tileSolid[Main.tile[num214, num215].type] || (Main.tileSolidTop[Main.tile[num214, num215].type] && Main.tile[num214, num215].frameY == 0)))
								{
									vector19.X = num214 * 16;
									vector19.Y = num215 * 16;
									if (position.X + (float)width > vector19.X && position.X < vector19.X + 16f && position.Y + (float)height > vector19.Y && position.Y < vector19.Y + 16f)
									{
										velocity.X = 0f;
										velocity.Y = -0.2f;
									}
								}
							}
						}
					}
					catch
					{
					}
				}
				if (type == 277 && alpha > 0)
				{
					alpha -= 30;
					if (alpha < 0)
					{
						alpha = 0;
					}
				}
				if (type == 261 || type == 277)
				{
					ai[0] += 1f;
					if (ai[0] > 15f)
					{
						ai[0] = 15f;
						if (velocity.Y == 0f && velocity.X != 0f)
						{
							velocity.X *= 0.97f;
							if ((double)velocity.X > -0.01 && (double)velocity.X < 0.01)
							{
								Kill();
							}
						}
						velocity.Y += 0.2f;
					}
					rotation += velocity.X * 0.05f;
				}
				else if (type == 378)
				{
					if (localAI[0] == 0f)
					{
						Main.PlaySound(2, (int)position.X, (int)position.Y, 17);
						localAI[0] += 1f;
					}
					Rectangle rectangle2 = new Rectangle((int)position.X, (int)position.Y, width, height);
					for (int num216 = 0; num216 < 200; num216++)
					{
						if (Main.npc[num216].active && !Main.npc[num216].friendly && Main.npc[num216].lifeMax > 5)
						{
							Rectangle value2 = new Rectangle((int)Main.npc[num216].position.X, (int)Main.npc[num216].position.Y, Main.npc[num216].width, Main.npc[num216].height);
							if (rectangle2.Intersects(value2))
							{
								Kill();
								return;
							}
						}
					}
					ai[0] += 1f;
					if (ai[0] > 10f)
					{
						ai[0] = 90f;
						if (velocity.Y == 0f && velocity.X != 0f)
						{
							velocity.X *= 0.96f;
							if ((double)velocity.X > -0.01 && (double)velocity.X < 0.01)
							{
								Kill();
							}
						}
						velocity.Y += 0.2f;
					}
					rotation += velocity.X * 0.1f;
				}
				else
				{
					ai[0] += 1f;
					if (ai[0] > 5f)
					{
						ai[0] = 5f;
						if (velocity.Y == 0f && velocity.X != 0f)
						{
							velocity.X *= 0.97f;
							if ((double)velocity.X > -0.01 && (double)velocity.X < 0.01)
							{
								velocity.X = 0f;
								netUpdate = true;
							}
						}
						velocity.Y += 0.2f;
					}
					rotation += velocity.X * 0.1f;
				}
				if ((type >= 326 && type <= 328) || (type >= 400 && type <= 402))
				{
					if (wet)
					{
						Kill();
					}
					if (ai[1] == 0f && type >= 326 && type <= 328)
					{
						ai[1] = 1f;
						Main.PlaySound(2, (int)position.X, (int)position.Y, 13);
					}
					int num217 = Dust.NewDust(position, width, height, 6, 0f, 0f, 100);
					Main.dust[num217].position.X -= 2f;
					Main.dust[num217].position.Y += 2f;
					Main.dust[num217].scale += (float)Main.rand.Next(50) * 0.01f;
					Main.dust[num217].noGravity = true;
					Main.dust[num217].velocity.Y -= 2f;
					if (Main.rand.Next(2) == 0)
					{
						int num218 = Dust.NewDust(position, width, height, 6, 0f, 0f, 100);
						Main.dust[num218].position.X -= 2f;
						Main.dust[num218].position.Y += 2f;
						Main.dust[num218].scale += 0.3f + (float)Main.rand.Next(50) * 0.01f;
						Main.dust[num218].noGravity = true;
						Main.dust[num218].velocity *= 0.1f;
					}
					if ((double)velocity.Y < 0.25 && (double)velocity.Y > 0.15)
					{
						velocity.X *= 0.8f;
					}
					rotation = (0f - velocity.X) * 0.05f;
				}
				if (velocity.Y > 16f)
				{
					velocity.Y = 16f;
				}
			}
			else if (aiStyle == 15)
			{
				if (type == 25)
				{
					if (Main.rand.Next(15) == 0)
					{
						Dust.NewDust(position, width, height, 14, 0f, 0f, 150, default(Color), 1.3f);
					}
				}
				else if (type == 26)
				{
					int num219 = Dust.NewDust(position, width, height, 172, velocity.X * 0.4f, velocity.Y * 0.4f, 100, default(Color), 1.5f);
					Main.dust[num219].noGravity = true;
					Main.dust[num219].velocity.X /= 2f;
					Main.dust[num219].velocity.Y /= 2f;
				}
				else if (type == 35)
				{
					int num220 = Dust.NewDust(position, width, height, 6, velocity.X * 0.4f, velocity.Y * 0.4f, 100, default(Color), 3f);
					Main.dust[num220].noGravity = true;
					Main.dust[num220].velocity.X *= 2f;
					Main.dust[num220].velocity.Y *= 2f;
				}
				else if (type == 154)
				{
					int num221 = Dust.NewDust(position, width, height, 115, velocity.X * 0.4f, velocity.Y * 0.4f, 140, default(Color), 1.5f);
					Main.dust[num221].noGravity = true;
					Main.dust[num221].velocity *= 0.25f;
				}
				if (Main.player[owner].dead)
				{
					Kill();
					return;
				}
				Main.player[owner].itemAnimation = 10;
				Main.player[owner].itemTime = 10;
				if (position.X + (float)(width / 2) > Main.player[owner].position.X + (float)(Main.player[owner].width / 2))
				{
					Main.player[owner].ChangeDir(1);
					direction = 1;
				}
				else
				{
					Main.player[owner].ChangeDir(-1);
					direction = -1;
				}
				Vector2 vector20 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
				float num222 = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - vector20.X;
				float num223 = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - vector20.Y;
				float num224 = (float)Math.Sqrt(num222 * num222 + num223 * num223);
				if (ai[0] == 0f)
				{
					float num225 = 160f;
					if (type == 63)
					{
						num225 *= 1.5f;
					}
					if (type == 247)
					{
						num225 *= 1.5f;
					}
					tileCollide = true;
					if (num224 > num225)
					{
						ai[0] = 1f;
						netUpdate = true;
					}
					else if (!Main.player[owner].channel)
					{
						if (velocity.Y < 0f)
						{
							velocity.Y *= 0.9f;
						}
						velocity.Y += 1f;
						velocity.X *= 0.9f;
					}
				}
				else if (ai[0] == 1f)
				{
					float num226 = 14f / Main.player[owner].meleeSpeed;
					float num227 = 0.9f / Main.player[owner].meleeSpeed;
					float num228 = 300f;
					if (type == 63)
					{
						num228 *= 1.5f;
						num226 *= 1.5f;
						num227 *= 1.5f;
					}
					if (type == 247)
					{
						num228 *= 1.5f;
						num226 = 15.9f;
						num227 *= 2f;
					}
					Math.Abs(num222);
					Math.Abs(num223);
					if (ai[1] == 1f)
					{
						tileCollide = false;
					}
					if (!Main.player[owner].channel || num224 > num228 || !tileCollide)
					{
						ai[1] = 1f;
						if (tileCollide)
						{
							netUpdate = true;
						}
						tileCollide = false;
						if (num224 < 20f)
						{
							Kill();
						}
					}
					if (!tileCollide)
					{
						num227 *= 2f;
					}
					int num229 = 60;
					if (type == 247)
					{
						num229 = 100;
					}
					if (num224 > (float)num229 || !tileCollide)
					{
						num224 = num226 / num224;
						num222 *= num224;
						num223 *= num224;
						new Vector2(velocity.X, velocity.Y);
						float num230 = num222 - velocity.X;
						float num231 = num223 - velocity.Y;
						float num232 = (float)Math.Sqrt(num230 * num230 + num231 * num231);
						num232 = num227 / num232;
						num230 *= num232;
						num231 *= num232;
						velocity.X *= 0.98f;
						velocity.Y *= 0.98f;
						velocity.X += num230;
						velocity.Y += num231;
					}
					else
					{
						if (Math.Abs(velocity.X) + Math.Abs(velocity.Y) < 6f)
						{
							velocity.X *= 0.96f;
							velocity.Y += 0.2f;
						}
						if (Main.player[owner].velocity.X == 0f)
						{
							velocity.X *= 0.96f;
						}
					}
				}
				if (type == 247)
				{
					if (velocity.X < 0f)
					{
						rotation -= (Math.Abs(velocity.X) + Math.Abs(velocity.Y)) * 0.01f;
					}
					else
					{
						rotation += (Math.Abs(velocity.X) + Math.Abs(velocity.Y)) * 0.01f;
					}
					float num233 = position.X;
					float num234 = position.Y;
					float num235 = 600f;
					bool flag4 = false;
					if (owner == Main.myPlayer)
					{
						localAI[1] += 1f;
						if (localAI[1] > 20f)
						{
							localAI[1] = 20f;
							for (int num236 = 0; num236 < 200; num236++)
							{
								if (Main.npc[num236].active && !Main.npc[num236].dontTakeDamage && !Main.npc[num236].friendly && Main.npc[num236].lifeMax > 5)
								{
									float num237 = Main.npc[num236].position.X + (float)(Main.npc[num236].width / 2);
									float num238 = Main.npc[num236].position.Y + (float)(Main.npc[num236].height / 2);
									float num239 = Math.Abs(position.X + (float)(width / 2) - num237) + Math.Abs(position.Y + (float)(height / 2) - num238);
									if (num239 < num235 && Collision.CanHit(position, width, height, Main.npc[num236].position, Main.npc[num236].width, Main.npc[num236].height))
									{
										num235 = num239;
										num233 = num237;
										num234 = num238;
										flag4 = true;
									}
								}
							}
						}
					}
					if (flag4)
					{
						localAI[1] = 0f;
						float num240 = 14f;
						vector20 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
						num222 = num233 - vector20.X;
						num223 = num234 - vector20.Y;
						num224 = (float)Math.Sqrt(num222 * num222 + num223 * num223);
						num224 = num240 / num224;
						num222 *= num224;
						num223 *= num224;
						NewProjectile(vector20.X, vector20.Y, num222, num223, 248, (int)((double)damage / 1.5), knockBack / 2f, Main.myPlayer);
					}
				}
				else
				{
					rotation = (float)Math.Atan2(num223, num222) - velocity.X * 0.1f;
				}
			}
			else if (aiStyle == 16)
			{
				if (type == 108 || type == 164)
				{
					ai[0] += 1f;
					if (ai[0] > 3f)
					{
						Kill();
					}
				}
				if (type == 37 || type == 397)
				{
					try
					{
						int num241 = (int)(position.X / 16f) - 1;
						int num242 = (int)((position.X + (float)width) / 16f) + 2;
						int num243 = (int)(position.Y / 16f) - 1;
						int num244 = (int)((position.Y + (float)height) / 16f) + 2;
						if (num241 < 0)
						{
							num241 = 0;
						}
						if (num242 > Main.maxTilesX)
						{
							num242 = Main.maxTilesX;
						}
						if (num243 < 0)
						{
							num243 = 0;
						}
						if (num244 > Main.maxTilesY)
						{
							num244 = Main.maxTilesY;
						}
						Vector2 vector21 = default(Vector2);
						for (int num245 = num241; num245 < num242; num245++)
						{
							for (int num246 = num243; num246 < num244; num246++)
							{
								if (Main.tile[num245, num246] != null && Main.tile[num245, num246].nactive() && (Main.tileSolid[Main.tile[num245, num246].type] || (Main.tileSolidTop[Main.tile[num245, num246].type] && Main.tile[num245, num246].frameY == 0)))
								{
									vector21.X = num245 * 16;
									vector21.Y = num246 * 16;
									if (position.X + (float)width - 4f > vector21.X && position.X + 4f < vector21.X + 16f && position.Y + (float)height - 4f > vector21.Y && position.Y + 4f < vector21.Y + 16f)
									{
										velocity.X = 0f;
										velocity.Y = -0.2f;
									}
								}
							}
						}
					}
					catch
					{
					}
				}
				if (type == 102)
				{
					if (velocity.Y > 10f)
					{
						velocity.Y = 10f;
					}
					if (localAI[0] == 0f)
					{
						localAI[0] = 1f;
						Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					}
					frameCounter++;
					if (frameCounter > 3)
					{
						frame++;
						frameCounter = 0;
					}
					if (frame > 1)
					{
						frame = 0;
					}
					if (velocity.Y == 0f)
					{
						position.X += width / 2;
						position.Y += height / 2;
						width = 128;
						height = 128;
						position.X -= width / 2;
						position.Y -= height / 2;
						damage = 40;
						knockBack = 8f;
						timeLeft = 3;
						netUpdate = true;
					}
				}
				if (type == 303 && timeLeft <= 3 && hostile)
				{
					position.X += width / 2;
					position.Y += height / 2;
					width = 128;
					height = 128;
					position.X -= width / 2;
					position.Y -= height / 2;
				}
				if (owner == Main.myPlayer && timeLeft <= 3)
				{
					tileCollide = false;
					ai[1] = 0f;
					alpha = 255;
					if (type == 28 || type == 37 || type == 75)
					{
						position.X += width / 2;
						position.Y += height / 2;
						width = 128;
						height = 128;
						position.X -= width / 2;
						position.Y -= height / 2;
						damage = 100;
						knockBack = 8f;
					}
					else if (type == 29)
					{
						position.X += width / 2;
						position.Y += height / 2;
						width = 250;
						height = 250;
						position.X -= width / 2;
						position.Y -= height / 2;
						damage = 250;
						knockBack = 10f;
					}
					else if (type == 30 || type == 397)
					{
						position.X += width / 2;
						position.Y += height / 2;
						width = 128;
						height = 128;
						position.X -= width / 2;
						position.Y -= height / 2;
						knockBack = 8f;
					}
					else if (type == 133 || type == 134 || type == 135 || type == 136 || type == 137 || type == 138 || type == 338 || type == 339)
					{
						position.X += width / 2;
						position.Y += height / 2;
						width = 128;
						height = 128;
						position.X -= width / 2;
						position.Y -= height / 2;
						knockBack = 8f;
					}
					else if (type == 139 || type == 140 || type == 141 || type == 142 || type == 143 || type == 144 || type == 340 || type == 341)
					{
						position.X += width / 2;
						position.Y += height / 2;
						width = 200;
						height = 200;
						position.X -= width / 2;
						position.Y -= height / 2;
						knockBack = 10f;
					}
				}
				else
				{
					if (type != 30 && type != 397 && type != 108 && type != 133 && type != 134 && type != 135 && type != 136 && type != 137 && type != 138 && type != 139 && type != 140 && type != 141 && type != 142 && type != 143 && type != 144 && type != 164 && type != 303 && type < 338 && type < 341)
					{
						damage = 0;
					}
					if (type == 338 || type == 339 || type == 340 || type == 341)
					{
						localAI[1] += 1f;
						if (localAI[1] > 6f)
						{
							alpha = 0;
						}
						else
						{
							alpha = (int)(255f - 42f * localAI[1]) + 100;
							if (alpha > 255)
							{
								alpha = 255;
							}
						}
						for (int num247 = 0; num247 < 2; num247++)
						{
							float num248 = 0f;
							float num249 = 0f;
							if (num247 == 1)
							{
								num248 = velocity.X * 0.5f;
								num249 = velocity.Y * 0.5f;
							}
							if (localAI[1] > 9f)
							{
								if (Main.rand.Next(2) == 0)
								{
									int num250 = Dust.NewDust(new Vector2(position.X + 3f + num248, position.Y + 3f + num249) - velocity * 0.5f, width - 8, height - 8, 6, 0f, 0f, 100);
									Main.dust[num250].scale *= 1.4f + (float)Main.rand.Next(10) * 0.1f;
									Main.dust[num250].velocity *= 0.2f;
									Main.dust[num250].noGravity = true;
								}
								if (Main.rand.Next(2) == 0)
								{
									int num251 = Dust.NewDust(new Vector2(position.X + 3f + num248, position.Y + 3f + num249) - velocity * 0.5f, width - 8, height - 8, 31, 0f, 0f, 100, default(Color), 0.5f);
									Main.dust[num251].fadeIn = 0.5f + (float)Main.rand.Next(5) * 0.1f;
									Main.dust[num251].velocity *= 0.05f;
								}
							}
						}
						float num252 = position.X;
						float num253 = position.Y;
						float num254 = 600f;
						bool flag5 = false;
						ai[0] += 1f;
						if (ai[0] > 30f)
						{
							ai[0] = 30f;
							for (int num255 = 0; num255 < 200; num255++)
							{
								if (Main.npc[num255].active && !Main.npc[num255].dontTakeDamage && !Main.npc[num255].friendly && Main.npc[num255].lifeMax > 5)
								{
									float num256 = Main.npc[num255].position.X + (float)(Main.npc[num255].width / 2);
									float num257 = Main.npc[num255].position.Y + (float)(Main.npc[num255].height / 2);
									float num258 = Math.Abs(position.X + (float)(width / 2) - num256) + Math.Abs(position.Y + (float)(height / 2) - num257);
									if (num258 < num254 && Collision.CanHit(position, width, height, Main.npc[num255].position, Main.npc[num255].width, Main.npc[num255].height))
									{
										num254 = num258;
										num252 = num256;
										num253 = num257;
										flag5 = true;
									}
								}
							}
						}
						if (!flag5)
						{
							num252 = position.X + (float)(width / 2) + velocity.X * 100f;
							num253 = position.Y + (float)(height / 2) + velocity.Y * 100f;
						}
						float num259 = 16f;
						Vector2 vector22 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
						float num260 = num252 - vector22.X;
						float num261 = num253 - vector22.Y;
						float num262 = (float)Math.Sqrt(num260 * num260 + num261 * num261);
						num262 = num259 / num262;
						num260 *= num262;
						num261 *= num262;
						velocity.X = (velocity.X * 11f + num260) / 12f;
						velocity.Y = (velocity.Y * 11f + num261) / 12f;
					}
					else if (type == 134 || type == 137 || type == 140 || type == 143 || type == 303)
					{
						if (Math.Abs(velocity.X) >= 8f || Math.Abs(velocity.Y) >= 8f)
						{
							for (int num263 = 0; num263 < 2; num263++)
							{
								float num264 = 0f;
								float num265 = 0f;
								if (num263 == 1)
								{
									num264 = velocity.X * 0.5f;
									num265 = velocity.Y * 0.5f;
								}
								int num266 = Dust.NewDust(new Vector2(position.X + 3f + num264, position.Y + 3f + num265) - velocity * 0.5f, width - 8, height - 8, 6, 0f, 0f, 100);
								Main.dust[num266].scale *= 2f + (float)Main.rand.Next(10) * 0.1f;
								Main.dust[num266].velocity *= 0.2f;
								Main.dust[num266].noGravity = true;
								num266 = Dust.NewDust(new Vector2(position.X + 3f + num264, position.Y + 3f + num265) - velocity * 0.5f, width - 8, height - 8, 31, 0f, 0f, 100, default(Color), 0.5f);
								Main.dust[num266].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
								Main.dust[num266].velocity *= 0.05f;
							}
						}
						if (Math.Abs(velocity.X) < 15f && Math.Abs(velocity.Y) < 15f)
						{
							velocity *= 1.1f;
						}
					}
					else if (type == 133 || type == 136 || type == 139 || type == 142)
					{
						int num267 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100);
						Main.dust[num267].scale *= 1f + (float)Main.rand.Next(10) * 0.1f;
						Main.dust[num267].velocity *= 0.2f;
						Main.dust[num267].noGravity = true;
					}
					else if (type == 135 || type == 138 || type == 141 || type == 144)
					{
						if ((double)velocity.X > -0.2 && (double)velocity.X < 0.2 && (double)velocity.Y > -0.2 && (double)velocity.Y < 0.2)
						{
							alpha += 2;
							if (alpha > 200)
							{
								alpha = 200;
							}
						}
						else
						{
							alpha = 0;
							int num268 = Dust.NewDust(new Vector2(position.X + 3f, position.Y + 3f) - velocity * 0.5f, width - 8, height - 8, 31, 0f, 0f, 100);
							Main.dust[num268].scale *= 1.6f + (float)Main.rand.Next(5) * 0.1f;
							Main.dust[num268].velocity *= 0.05f;
							Main.dust[num268].noGravity = true;
						}
					}
					else if (type != 30 && type != 397 && Main.rand.Next(2) == 0)
					{
						int num269 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100);
						Main.dust[num269].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
						Main.dust[num269].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
						Main.dust[num269].noGravity = true;
						Main.dust[num269].position = center() + new Vector2(0f, -height / 2).Rotate(rotation) * 1.1f;
						Main.rand.Next(2);
						num269 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100);
						Main.dust[num269].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
						Main.dust[num269].noGravity = true;
						Main.dust[num269].position = center() + new Vector2(0f, -height / 2 - 6).Rotate(rotation) * 1.1f;
					}
				}
				ai[0] += 1f;
				if (type == 338 || type == 339 || type == 340 || type == 341)
				{
					if (velocity.X < 0f)
					{
						spriteDirection = -1;
						rotation = (float)Math.Atan2(0f - velocity.Y, 0f - velocity.X) - 1.57f;
					}
					else
					{
						spriteDirection = 1;
						rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
					}
				}
				else if (type == 134 || type == 137 || type == 140 || type == 143 || type == 303)
				{
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
				}
				else if (type == 135 || type == 138 || type == 141 || type == 144)
				{
					velocity.Y += 0.2f;
					velocity *= 0.97f;
					if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
					{
						velocity.X = 0f;
					}
					if ((double)velocity.Y > -0.1 && (double)velocity.Y < 0.1)
					{
						velocity.Y = 0f;
					}
				}
				else if (type == 133 || type == 136 || type == 139 || type == 142)
				{
					if (ai[0] > 15f)
					{
						if (velocity.Y == 0f)
						{
							velocity.X *= 0.95f;
						}
						velocity.Y += 0.2f;
					}
				}
				else if (((type == 30 || type == 397) && ai[0] > 10f) || (type != 30 && type != 397 && ai[0] > 5f))
				{
					ai[0] = 10f;
					if (velocity.Y == 0f && velocity.X != 0f)
					{
						velocity.X *= 0.97f;
						if (type == 29)
						{
							velocity.X *= 0.99f;
						}
						if ((double)velocity.X > -0.01 && (double)velocity.X < 0.01)
						{
							velocity.X = 0f;
							netUpdate = true;
						}
					}
					velocity.Y += 0.2f;
				}
				if (type != 134 && type != 137 && type != 140 && type != 143 && type != 303 && (type < 338 || type > 341))
				{
					rotation += velocity.X * 0.1f;
				}
			}
			else if (aiStyle == 17)
			{
				if (velocity.Y == 0f)
				{
					velocity.X *= 0.98f;
				}
				rotation += velocity.X * 0.1f;
				velocity.Y += 0.2f;
				if (owner == Main.myPlayer)
				{
					int num270 = (int)((position.X + (float)(width / 2)) / 16f);
					int num271 = (int)((position.Y + (float)height - 4f) / 16f);
					if (Main.tile[num270, num271] != null && !Main.tile[num270, num271].active())
					{
						int num272 = 0;
						if (type >= 201 && type <= 205)
						{
							num272 = type - 200;
						}
						WorldGen.PlaceTile(num270, num271, 85, false, false, owner, num272);
						if (Main.tile[num270, num271].active())
						{
							if (Main.netMode != 0)
							{
								NetMessage.SendData(17, -1, -1, "", 1, num270, num271, 85f, num272);
							}
							int num273 = Sign.ReadSign(num270, num271);
							if (num273 >= 0)
							{
								Sign.TextSign(num273, miscText);
							}
							Kill();
						}
					}
				}
			}
			else if (aiStyle == 18)
			{
				if (ai[1] == 0f && type == 44)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 8);
				}
				if (type == 263 || type == 274)
				{
					if (type == 274 && velocity.X < 0f)
					{
						spriteDirection = -1;
					}
					rotation += (float)direction * 0.05f;
					rotation += (float)direction * 0.5f * ((float)timeLeft / 180f);
					if (type == 274)
					{
						velocity *= 0.96f;
					}
					else
					{
						velocity *= 0.95f;
					}
				}
				else
				{
					rotation += (float)direction * 0.8f;
					ai[0] += 1f;
					if (!(ai[0] < 30f))
					{
						if (ai[0] < 100f)
						{
							velocity *= 1.06f;
						}
						else
						{
							ai[0] = 200f;
						}
					}
					for (int num274 = 0; num274 < 2; num274++)
					{
						int num275 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 27, 0f, 0f, 100);
						Main.dust[num275].noGravity = true;
					}
				}
			}
			else if (aiStyle == 19)
			{
				direction = Main.player[owner].direction;
				Main.player[owner].heldProj = whoAmI;
				Main.player[owner].itemTime = Main.player[owner].itemAnimation;
				position.X = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - (float)(width / 2);
				position.Y = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - (float)(height / 2);
				if (!Main.player[owner].frozen)
				{
					if (type == 46)
					{
						if (ai[0] == 0f)
						{
							ai[0] = 3f;
							netUpdate = true;
						}
						if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
						{
							ai[0] -= 1.6f;
						}
						else
						{
							ai[0] += 1.4f;
						}
					}
					else if (type == 105)
					{
						if (ai[0] == 0f)
						{
							ai[0] = 3f;
							netUpdate = true;
						}
						if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
						{
							ai[0] -= 2.4f;
						}
						else
						{
							ai[0] += 2.1f;
						}
					}
					else if (type == 367)
					{
						spriteDirection = -direction;
						if (ai[0] == 0f)
						{
							ai[0] = 3f;
							netUpdate = true;
						}
						if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
						{
							ai[0] -= 1.6f;
						}
						else
						{
							ai[0] += 1.5f;
						}
					}
					else if (type == 368)
					{
						spriteDirection = -direction;
						if (ai[0] == 0f)
						{
							ai[0] = 3f;
							netUpdate = true;
						}
						if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
						{
							ai[0] -= 1.5f;
						}
						else
						{
							ai[0] += 1.4f;
						}
					}
					else if (type == 222)
					{
						if (ai[0] == 0f)
						{
							ai[0] = 3f;
							netUpdate = true;
						}
						if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
						{
							ai[0] -= 2.4f;
							if (localAI[0] == 0f && Main.myPlayer == owner)
							{
								localAI[0] = 1f;
								NewProjectile(center().X + velocity.X * ai[0], center().Y + velocity.Y * ai[0], velocity.X, velocity.Y, 228, damage, knockBack, owner);
							}
						}
						else
						{
							ai[0] += 2.1f;
						}
					}
					else if (type == 342)
					{
						if (ai[0] == 0f)
						{
							ai[0] = 3f;
							netUpdate = true;
						}
						if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
						{
							ai[0] -= 2.4f;
							if (localAI[0] == 0f && Main.myPlayer == owner)
							{
								localAI[0] = 1f;
								if (Collision.CanHit(Main.player[owner].position, Main.player[owner].width, Main.player[owner].height, new Vector2(center().X + velocity.X * ai[0], center().Y + velocity.Y * ai[0]), width, height))
								{
									NewProjectile(center().X + velocity.X * ai[0], center().Y + velocity.Y * ai[0], velocity.X * 2.4f, velocity.Y * 2.4f, 343, (int)((double)damage * 0.8), knockBack * 0.85f, owner);
								}
							}
						}
						else
						{
							ai[0] += 2.1f;
						}
					}
					else if (type == 47)
					{
						if (ai[0] == 0f)
						{
							ai[0] = 4f;
							netUpdate = true;
						}
						if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
						{
							ai[0] -= 1.2f;
						}
						else
						{
							ai[0] += 0.9f;
						}
					}
					else if (type == 153)
					{
						spriteDirection = -direction;
						if (ai[0] == 0f)
						{
							ai[0] = 4f;
							netUpdate = true;
						}
						if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
						{
							ai[0] -= 1.5f;
						}
						else
						{
							ai[0] += 1.3f;
						}
					}
					else if (type == 49)
					{
						if (ai[0] == 0f)
						{
							ai[0] = 4f;
							netUpdate = true;
						}
						if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
						{
							ai[0] -= 1.1f;
						}
						else
						{
							ai[0] += 0.85f;
						}
					}
					else if (type == 64 || type == 215)
					{
						spriteDirection = -direction;
						if (ai[0] == 0f)
						{
							ai[0] = 3f;
							netUpdate = true;
						}
						if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
						{
							ai[0] -= 1.9f;
						}
						else
						{
							ai[0] += 1.7f;
						}
					}
					else if (type == 66 || type == 97 || type == 212 || type == 218)
					{
						spriteDirection = -direction;
						if (ai[0] == 0f)
						{
							ai[0] = 3f;
							netUpdate = true;
						}
						if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
						{
							ai[0] -= 2.1f;
						}
						else
						{
							ai[0] += 1.9f;
						}
					}
					else if (type == 130)
					{
						spriteDirection = -direction;
						if (ai[0] == 0f)
						{
							ai[0] = 3f;
							netUpdate = true;
						}
						if (Main.player[owner].itemAnimation < Main.player[owner].itemAnimationMax / 3)
						{
							ai[0] -= 1.3f;
						}
						else
						{
							ai[0] += 1f;
						}
					}
				}
				position += velocity * ai[0];
				if (type == 130)
				{
					if (ai[1] == 0f || ai[1] == 4f || ai[1] == 8f || ai[1] == 12f || ai[1] == 16f || ai[1] == 20f || ai[1] == 24f)
					{
						NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), velocity.X, velocity.Y, 131, damage / 3, 0f, owner);
					}
					ai[1] += 1f;
				}
				if (Main.player[owner].itemAnimation == 0)
				{
					Kill();
				}
				rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 2.355f;
				if (spriteDirection == -1)
				{
					rotation -= 1.57f;
				}
				if (type == 46)
				{
					if (Main.rand.Next(5) == 0)
					{
						Dust.NewDust(position, width, height, 14, 0f, 0f, 150, default(Color), 1.4f);
					}
					int num276 = Dust.NewDust(position, width, height, 27, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 1.2f);
					Main.dust[num276].noGravity = true;
					Main.dust[num276].velocity.X /= 2f;
					Main.dust[num276].velocity.Y /= 2f;
					num276 = Dust.NewDust(position - velocity * 2f, width, height, 27, 0f, 0f, 150, default(Color), 1.4f);
					Main.dust[num276].velocity.X /= 5f;
					Main.dust[num276].velocity.Y /= 5f;
				}
				else if (type == 105)
				{
					if (Main.rand.Next(3) == 0)
					{
						int num277 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 57, velocity.X * 0.2f, velocity.Y * 0.2f, 200, default(Color), 1.2f);
						Main.dust[num277].velocity += velocity * 0.3f;
						Main.dust[num277].velocity *= 0.2f;
					}
					if (Main.rand.Next(4) == 0)
					{
						int num278 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 43, 0f, 0f, 254, default(Color), 0.3f);
						Main.dust[num278].velocity += velocity * 0.5f;
						Main.dust[num278].velocity *= 0.5f;
					}
				}
				else if (type == 153)
				{
					int num279 = Dust.NewDust(position - velocity * 3f, width, height, 115, velocity.X * 0.4f, velocity.Y * 0.4f, 140);
					Main.dust[num279].noGravity = true;
					Main.dust[num279].fadeIn = 1.25f;
					Main.dust[num279].velocity *= 0.25f;
				}
			}
			else if (aiStyle == 20)
			{
				if (type == 252)
				{
					frameCounter++;
					if (frameCounter >= 4)
					{
						frameCounter = 0;
						frame++;
					}
					if (frame > 3)
					{
						frame = 0;
					}
				}
				if (soundDelay <= 0)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 22);
					soundDelay = 30;
				}
				if (Main.myPlayer == owner)
				{
					if (Main.player[owner].channel)
					{
						float num280 = Main.player[owner].inventory[Main.player[owner].selectedItem].shootSpeed * scale;
						Vector2 vector23 = new Vector2(Main.player[owner].position.X + (float)Main.player[owner].width * 0.5f, Main.player[owner].position.Y + (float)Main.player[owner].height * 0.5f);
						float num281 = (float)Main.mouseX + Main.screenPosition.X - vector23.X;
						float num282 = (float)Main.mouseY + Main.screenPosition.Y - vector23.Y;
						if (Main.player[owner].gravDir == -1f)
						{
							num282 = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector23.Y;
						}
						float num283 = (float)Math.Sqrt(num281 * num281 + num282 * num282);
						num283 = (float)Math.Sqrt(num281 * num281 + num282 * num282);
						num283 = num280 / num283;
						num281 *= num283;
						num282 *= num283;
						if (num281 != velocity.X || num282 != velocity.Y)
						{
							netUpdate = true;
						}
						velocity.X = num281;
						velocity.Y = num282;
					}
					else
					{
						Kill();
					}
				}
				if (velocity.X > 0f)
				{
					Main.player[owner].ChangeDir(1);
				}
				else if (velocity.X < 0f)
				{
					Main.player[owner].ChangeDir(-1);
				}
				spriteDirection = direction;
				Main.player[owner].ChangeDir(direction);
				Main.player[owner].heldProj = whoAmI;
				Main.player[owner].itemTime = 2;
				Main.player[owner].itemAnimation = 2;
				position.X = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - (float)(width / 2);
				position.Y = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - (float)(height / 2);
				rotation = (float)(Math.Atan2(velocity.Y, velocity.X) + 1.5700000524520874);
				if (Main.player[owner].direction == 1)
				{
					Main.player[owner].itemRotation = (float)Math.Atan2(velocity.Y * (float)direction, velocity.X * (float)direction);
				}
				else
				{
					Main.player[owner].itemRotation = (float)Math.Atan2(velocity.Y * (float)direction, velocity.X * (float)direction);
				}
				velocity.X *= 1f + (float)Main.rand.Next(-3, 4) * 0.01f;
				if (Main.rand.Next(6) == 0)
				{
					int num284 = Dust.NewDust(position + velocity * Main.rand.Next(6, 10) * 0.1f, width, height, 31, 0f, 0f, 80, default(Color), 1.4f);
					Main.dust[num284].position.X -= 4f;
					Main.dust[num284].noGravity = true;
					Main.dust[num284].velocity *= 0.2f;
					Main.dust[num284].velocity.Y = (float)(-Main.rand.Next(7, 13)) * 0.15f;
				}
			}
			else if (aiStyle == 21)
			{
				rotation = velocity.X * 0.1f;
				spriteDirection = -direction;
				if (Main.rand.Next(3) == 0)
				{
					int num285 = Dust.NewDust(position, width, height, 27, 0f, 0f, 80);
					Main.dust[num285].noGravity = true;
					Main.dust[num285].velocity *= 0.2f;
				}
				if (ai[1] == 1f)
				{
					ai[1] = 0f;
					Main.harpNote = ai[0];
					Main.PlaySound(2, (int)position.X, (int)position.Y, 26);
				}
			}
			else if (aiStyle == 22)
			{
				if (velocity.X == 0f && velocity.Y == 0f)
				{
					alpha = 255;
				}
				if (ai[1] < 0f)
				{
					if (velocity.X > 0f)
					{
						rotation += 0.3f;
					}
					else
					{
						rotation -= 0.3f;
					}
					int num286 = (int)(position.X / 16f) - 1;
					int num287 = (int)((position.X + (float)width) / 16f) + 2;
					int num288 = (int)(position.Y / 16f) - 1;
					int num289 = (int)((position.Y + (float)height) / 16f) + 2;
					if (num286 < 0)
					{
						num286 = 0;
					}
					if (num287 > Main.maxTilesX)
					{
						num287 = Main.maxTilesX;
					}
					if (num288 < 0)
					{
						num288 = 0;
					}
					if (num289 > Main.maxTilesY)
					{
						num289 = Main.maxTilesY;
					}
					int num290 = (int)position.X + 4;
					int num291 = (int)position.Y + 4;
					Vector2 vector24 = default(Vector2);
					for (int num292 = num286; num292 < num287; num292++)
					{
						for (int num293 = num288; num293 < num289; num293++)
						{
							if (Main.tile[num292, num293] != null && Main.tile[num292, num293].active() && Main.tile[num292, num293].type != 127 && Main.tileSolid[Main.tile[num292, num293].type] && !Main.tileSolidTop[Main.tile[num292, num293].type])
							{
								vector24.X = num292 * 16;
								vector24.Y = num293 * 16;
								if ((float)(num290 + 8) > vector24.X && (float)num290 < vector24.X + 16f && (float)(num291 + 8) > vector24.Y && (float)num291 < vector24.Y + 16f)
								{
									Kill();
								}
							}
						}
					}
					int num294 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 67);
					Main.dust[num294].noGravity = true;
					Main.dust[num294].velocity *= 0.3f;
				}
				else if (ai[0] < 0f)
				{
					if (ai[0] == -1f)
					{
						for (int num295 = 0; num295 < 10; num295++)
						{
							int num296 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 67, 0f, 0f, 0, default(Color), 1.1f);
							Main.dust[num296].noGravity = true;
							Main.dust[num296].velocity *= 1.3f;
						}
					}
					else if (Main.rand.Next(30) == 0)
					{
						int num297 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 67, 0f, 0f, 100);
						Main.dust[num297].velocity *= 0.2f;
					}
					int num298 = (int)position.X / 16;
					int num299 = (int)position.Y / 16;
					if (Main.tile[num298, num299] == null || !Main.tile[num298, num299].active())
					{
						Kill();
					}
					ai[0] -= 1f;
					if (ai[0] <= -300f && (Main.myPlayer == owner || Main.netMode == 2) && Main.tile[num298, num299].active() && Main.tile[num298, num299].type == 127)
					{
						WorldGen.KillTile(num298, num299);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, num298, num299);
						}
						Kill();
					}
				}
				else
				{
					int num300 = (int)(position.X / 16f) - 1;
					int num301 = (int)((position.X + (float)width) / 16f) + 2;
					int num302 = (int)(position.Y / 16f) - 1;
					int num303 = (int)((position.Y + (float)height) / 16f) + 2;
					if (num300 < 0)
					{
						num300 = 0;
					}
					if (num301 > Main.maxTilesX)
					{
						num301 = Main.maxTilesX;
					}
					if (num302 < 0)
					{
						num302 = 0;
					}
					if (num303 > Main.maxTilesY)
					{
						num303 = Main.maxTilesY;
					}
					int num304 = (int)position.X + 4;
					int num305 = (int)position.Y + 4;
					Vector2 vector25 = default(Vector2);
					for (int num306 = num300; num306 < num301; num306++)
					{
						for (int num307 = num302; num307 < num303; num307++)
						{
							if (Main.tile[num306, num307] != null && Main.tile[num306, num307].nactive() && Main.tile[num306, num307].type != 127 && Main.tileSolid[Main.tile[num306, num307].type] && !Main.tileSolidTop[Main.tile[num306, num307].type])
							{
								vector25.X = num306 * 16;
								vector25.Y = num307 * 16;
								if ((float)(num304 + 8) > vector25.X && (float)num304 < vector25.X + 16f && (float)(num305 + 8) > vector25.Y && (float)num305 < vector25.Y + 16f)
								{
									Kill();
								}
							}
						}
					}
					if (lavaWet)
					{
						Kill();
					}
					if (active)
					{
						int num308 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 67);
						Main.dust[num308].noGravity = true;
						Main.dust[num308].velocity *= 0.3f;
						int num309 = (int)ai[0];
						int num310 = (int)ai[1];
						if (velocity.X > 0f)
						{
							rotation += 0.3f;
						}
						else
						{
							rotation -= 0.3f;
						}
						if (Main.myPlayer == owner)
						{
							int num311 = (int)((position.X + (float)(width / 2)) / 16f);
							int num312 = (int)((position.Y + (float)(height / 2)) / 16f);
							bool flag6 = false;
							if (num311 == num309 && num312 == num310)
							{
								flag6 = true;
							}
							if (((velocity.X <= 0f && num311 <= num309) || (velocity.X >= 0f && num311 >= num309)) && ((velocity.Y <= 0f && num312 <= num310) || (velocity.Y >= 0f && num312 >= num310)))
							{
								flag6 = true;
							}
							if (flag6)
							{
								if (WorldGen.PlaceTile(num309, num310, 127, false, false, owner))
								{
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 1, (int)ai[0], (int)ai[1], 127f);
									}
									damage = 0;
									ai[0] = -1f;
									velocity *= 0f;
									alpha = 255;
									position.X = num309 * 16;
									position.Y = num310 * 16;
									netUpdate = true;
								}
								else
								{
									ai[1] = -1f;
								}
							}
						}
					}
				}
			}
			else if (aiStyle == 23)
			{
				if (type == 188 && ai[0] < 8f)
				{
					ai[0] = 8f;
				}
				if (timeLeft > 60)
				{
					timeLeft = 60;
				}
				if (ai[0] > 7f)
				{
					float num313 = 1f;
					if (ai[0] == 8f)
					{
						num313 = 0.25f;
					}
					else if (ai[0] == 9f)
					{
						num313 = 0.5f;
					}
					else if (ai[0] == 10f)
					{
						num313 = 0.75f;
					}
					ai[0] += 1f;
					int num314 = 6;
					if (type == 101)
					{
						num314 = 75;
					}
					if (num314 == 6 || Main.rand.Next(2) == 0)
					{
						for (int num315 = 0; num315 < 1; num315++)
						{
							int num316 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, num314, velocity.X * 0.2f, velocity.Y * 0.2f, 100);
							if (Main.rand.Next(3) != 0 || (num314 == 75 && Main.rand.Next(3) == 0))
							{
								Main.dust[num316].noGravity = true;
								Main.dust[num316].scale *= 3f;
								Main.dust[num316].velocity.X *= 2f;
								Main.dust[num316].velocity.Y *= 2f;
							}
							if (type == 188)
							{
								Main.dust[num316].scale *= 1.25f;
							}
							else
							{
								Main.dust[num316].scale *= 1.5f;
							}
							Main.dust[num316].velocity.X *= 1.2f;
							Main.dust[num316].velocity.Y *= 1.2f;
							Main.dust[num316].scale *= num313;
							if (num314 == 75)
							{
								Main.dust[num316].velocity += velocity;
								if (!Main.dust[num316].noGravity)
								{
									Main.dust[num316].velocity *= 0.5f;
								}
							}
						}
					}
				}
				else
				{
					ai[0] += 1f;
				}
				rotation += 0.3f * (float)direction;
			}
			else if (aiStyle == 24)
			{
				light = scale * 0.5f;
				rotation += velocity.X * 0.2f;
				ai[1] += 1f;
				if (type == 94)
				{
					if (Main.rand.Next(4) == 0)
					{
						int num317 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 70);
						Main.dust[num317].noGravity = true;
						Main.dust[num317].velocity *= 0.5f;
						Main.dust[num317].scale *= 0.9f;
					}
					velocity *= 0.985f;
					if (ai[1] > 130f)
					{
						scale -= 0.05f;
						if ((double)scale <= 0.2)
						{
							scale = 0.2f;
							Kill();
						}
					}
				}
				else
				{
					velocity *= 0.96f;
					if (ai[1] > 15f)
					{
						scale -= 0.05f;
						if ((double)scale <= 0.2)
						{
							scale = 0.2f;
							Kill();
						}
					}
				}
			}
			else if (aiStyle == 25)
			{
				if (ai[0] != 0f && velocity.Y <= 0f && velocity.X == 0f)
				{
					float num318 = 0.5f;
					int i2 = (int)((position.X - 8f) / 16f);
					int num319 = (int)(position.Y / 16f);
					bool flag7 = false;
					bool flag8 = false;
					if (WorldGen.SolidTile(i2, num319) || WorldGen.SolidTile(i2, num319 + 1))
					{
						flag7 = true;
					}
					i2 = (int)((position.X + (float)width + 8f) / 16f);
					if (WorldGen.SolidTile(i2, num319) || WorldGen.SolidTile(i2, num319 + 1))
					{
						flag8 = true;
					}
					if (flag7)
					{
						velocity.X = num318;
					}
					else if (flag8)
					{
						velocity.X = 0f - num318;
					}
					else
					{
						i2 = (int)((position.X - 8f - 16f) / 16f);
						num319 = (int)(position.Y / 16f);
						flag7 = false;
						flag8 = false;
						if (WorldGen.SolidTile(i2, num319) || WorldGen.SolidTile(i2, num319 + 1))
						{
							flag7 = true;
						}
						i2 = (int)((position.X + (float)width + 8f + 16f) / 16f);
						if (WorldGen.SolidTile(i2, num319) || WorldGen.SolidTile(i2, num319 + 1))
						{
							flag8 = true;
						}
						if (flag7)
						{
							velocity.X = num318;
						}
						else if (flag8)
						{
							velocity.X = 0f - num318;
						}
						else
						{
							i2 = (int)((position.X + 4f) / 16f);
							num319 = (int)((position.Y + (float)height + 8f) / 16f);
							if (WorldGen.SolidTile(i2, num319) || WorldGen.SolidTile(i2, num319 + 1))
							{
								flag7 = true;
							}
							if (!flag7)
							{
								velocity.X = num318;
							}
							else
							{
								velocity.X = 0f - num318;
							}
						}
					}
				}
				rotation += velocity.X * 0.06f;
				ai[0] = 1f;
				if (velocity.Y > 16f)
				{
					velocity.Y = 16f;
				}
				if (velocity.Y <= 6f)
				{
					if (velocity.X > 0f && velocity.X < 7f)
					{
						velocity.X += 0.05f;
					}
					if (velocity.X < 0f && velocity.X > -7f)
					{
						velocity.X -= 0.05f;
					}
				}
				velocity.Y += 0.3f;
			}
			else if (aiStyle == 26)
			{
				if (!Main.player[owner].active)
				{
					active = false;
					return;
				}
				bool flag9 = false;
				bool flag10 = false;
				bool flag11 = false;
				bool flag12 = false;
				int num320 = 85;
				if (type == 324)
				{
					num320 = 120;
				}
				if (type == 112)
				{
					num320 = 100;
				}
				if (type == 127)
				{
					num320 = 50;
				}
				if (type >= 191 && type <= 194)
				{
					if (lavaWet)
					{
						ai[0] = 1f;
						ai[1] = 0f;
					}
					num320 = 60 + 30 * minionPos;
				}
				else if (type == 266)
				{
					num320 = 60 + 30 * minionPos;
				}
				if (type == 111)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].bunny = false;
					}
					if (Main.player[owner].bunny)
					{
						timeLeft = 2;
					}
				}
				if (type == 112)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].penguin = false;
					}
					if (Main.player[owner].penguin)
					{
						timeLeft = 2;
					}
				}
				if (type == 334)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].puppy = false;
					}
					if (Main.player[owner].puppy)
					{
						timeLeft = 2;
					}
				}
				if (type == 353)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].grinch = false;
					}
					if (Main.player[owner].grinch)
					{
						timeLeft = 2;
					}
				}
				if (type == 127)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].turtle = false;
					}
					if (Main.player[owner].turtle)
					{
						timeLeft = 2;
					}
				}
				if (type == 175)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].eater = false;
					}
					if (Main.player[owner].eater)
					{
						timeLeft = 2;
					}
				}
				if (type == 197)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].skeletron = false;
					}
					if (Main.player[owner].skeletron)
					{
						timeLeft = 2;
					}
				}
				if (type == 198)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].hornet = false;
					}
					if (Main.player[owner].hornet)
					{
						timeLeft = 2;
					}
				}
				if (type == 199)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].tiki = false;
					}
					if (Main.player[owner].tiki)
					{
						timeLeft = 2;
					}
				}
				if (type == 200)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].lizard = false;
					}
					if (Main.player[owner].lizard)
					{
						timeLeft = 2;
					}
				}
				if (type == 208)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].parrot = false;
					}
					if (Main.player[owner].parrot)
					{
						timeLeft = 2;
					}
				}
				if (type == 209)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].truffle = false;
					}
					if (Main.player[owner].truffle)
					{
						timeLeft = 2;
					}
				}
				if (type == 210)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].sapling = false;
					}
					if (Main.player[owner].sapling)
					{
						timeLeft = 2;
					}
				}
				if (type == 324)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].cSapling = false;
					}
					if (Main.player[owner].cSapling)
					{
						timeLeft = 2;
					}
				}
				if (type == 313)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].spider = false;
					}
					if (Main.player[owner].spider)
					{
						timeLeft = 2;
					}
				}
				if (type == 314)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].squashling = false;
					}
					if (Main.player[owner].squashling)
					{
						timeLeft = 2;
					}
				}
				if (type == 211)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].wisp = false;
					}
					if (Main.player[owner].wisp)
					{
						timeLeft = 2;
					}
				}
				if (type == 236)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].dino = false;
					}
					if (Main.player[owner].dino)
					{
						timeLeft = 2;
					}
				}
				if (type == 266)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].slime = false;
					}
					if (Main.player[owner].slime)
					{
						timeLeft = 2;
					}
				}
				if (type == 268)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].eyeSpring = false;
					}
					if (Main.player[owner].eyeSpring)
					{
						timeLeft = 2;
					}
				}
				if (type == 269)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].snowman = false;
					}
					if (Main.player[owner].snowman)
					{
						timeLeft = 2;
					}
				}
				if (type == 319)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].blackCat = false;
					}
					if (Main.player[owner].blackCat)
					{
						timeLeft = 2;
					}
				}
				if (type == 380)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].zephyrfish = false;
					}
					if (Main.player[owner].zephyrfish)
					{
						timeLeft = 2;
					}
				}
				if (type >= 191 && type <= 194)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].pygmy = false;
					}
					if (Main.player[owner].pygmy)
					{
						timeLeft = Main.rand.Next(2, 10);
					}
				}
				if (type >= 390 && type <= 392)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].spiderMinion = false;
					}
					if (Main.player[owner].spiderMinion)
					{
						timeLeft = 2;
					}
				}
				if (type == 398)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].miniMinotaur = false;
					}
					if (Main.player[owner].miniMinotaur)
					{
						timeLeft = 2;
					}
				}
				if ((type >= 191 && type <= 194) || type == 266 || (type >= 390 && type <= 392))
				{
					num320 = 10;
					int num321 = 40 * (minionPos + 1) * Main.player[owner].direction;
					if (Main.player[owner].position.X + (float)(Main.player[owner].width / 2) < position.X + (float)(width / 2) - (float)num320 + (float)num321)
					{
						flag9 = true;
					}
					else if (Main.player[owner].position.X + (float)(Main.player[owner].width / 2) > position.X + (float)(width / 2) + (float)num320 + (float)num321)
					{
						flag10 = true;
					}
				}
				else if (Main.player[owner].position.X + (float)(Main.player[owner].width / 2) < position.X + (float)(width / 2) - (float)num320)
				{
					flag9 = true;
				}
				else if (Main.player[owner].position.X + (float)(Main.player[owner].width / 2) > position.X + (float)(width / 2) + (float)num320)
				{
					flag10 = true;
				}
				if (type == 175)
				{
					float num322 = 0.1f;
					tileCollide = false;
					int num323 = 300;
					Vector2 vector26 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
					float num324 = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - vector26.X;
					float num325 = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - vector26.Y;
					if (type == 127)
					{
						num325 = Main.player[owner].position.Y - vector26.Y;
					}
					float num326 = (float)Math.Sqrt(num324 * num324 + num325 * num325);
					float num327 = 7f;
					if (num326 < (float)num323 && Main.player[owner].velocity.Y == 0f && position.Y + (float)height <= Main.player[owner].position.Y + (float)Main.player[owner].height && !Collision.SolidCollision(position, width, height))
					{
						ai[0] = 0f;
						if (velocity.Y < -6f)
						{
							velocity.Y = -6f;
						}
					}
					if (num326 < 150f)
					{
						if (Math.Abs(velocity.X) > 2f || Math.Abs(velocity.Y) > 2f)
						{
							velocity *= 0.99f;
						}
						num322 = 0.01f;
						if (num324 < -2f)
						{
							num324 = -2f;
						}
						if (num324 > 2f)
						{
							num324 = 2f;
						}
						if (num325 < -2f)
						{
							num325 = -2f;
						}
						if (num325 > 2f)
						{
							num325 = 2f;
						}
					}
					else
					{
						if (num326 > 300f)
						{
							num322 = 0.2f;
						}
						num326 = num327 / num326;
						num324 *= num326;
						num325 *= num326;
					}
					if (Math.Abs(num324) > Math.Abs(num325) || num322 == 0.05f)
					{
						if (velocity.X < num324)
						{
							velocity.X += num322;
							if (num322 > 0.05f && velocity.X < 0f)
							{
								velocity.X += num322;
							}
						}
						if (velocity.X > num324)
						{
							velocity.X -= num322;
							if (num322 > 0.05f && velocity.X > 0f)
							{
								velocity.X -= num322;
							}
						}
					}
					if (Math.Abs(num324) <= Math.Abs(num325) || num322 == 0.05f)
					{
						if (velocity.Y < num325)
						{
							velocity.Y += num322;
							if (num322 > 0.05f && velocity.Y < 0f)
							{
								velocity.Y += num322;
							}
						}
						if (velocity.Y > num325)
						{
							velocity.Y -= num322;
							if (num322 > 0.05f && velocity.Y > 0f)
							{
								velocity.Y -= num322;
							}
						}
					}
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 1.57f;
					frameCounter++;
					if (frameCounter > 6)
					{
						frame++;
						frameCounter = 0;
					}
					if (frame > 1)
					{
						frame = 0;
					}
				}
				else if (type == 197)
				{
					float num328 = 0.1f;
					tileCollide = false;
					int num329 = 300;
					Vector2 vector27 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
					float num330 = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - vector27.X;
					float num331 = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - vector27.Y;
					if (type == 127)
					{
						num331 = Main.player[owner].position.Y - vector27.Y;
					}
					float num332 = (float)Math.Sqrt(num330 * num330 + num331 * num331);
					float num333 = 3f;
					if (num332 > 500f)
					{
						localAI[0] = 10000f;
					}
					if (localAI[0] >= 10000f)
					{
						num333 = 14f;
					}
					if (num332 < (float)num329 && Main.player[owner].velocity.Y == 0f && position.Y + (float)height <= Main.player[owner].position.Y + (float)Main.player[owner].height && !Collision.SolidCollision(position, width, height))
					{
						ai[0] = 0f;
						if (velocity.Y < -6f)
						{
							velocity.Y = -6f;
						}
					}
					if (num332 < 150f)
					{
						if (Math.Abs(velocity.X) > 2f || Math.Abs(velocity.Y) > 2f)
						{
							velocity *= 0.99f;
						}
						num328 = 0.01f;
						if (num330 < -2f)
						{
							num330 = -2f;
						}
						if (num330 > 2f)
						{
							num330 = 2f;
						}
						if (num331 < -2f)
						{
							num331 = -2f;
						}
						if (num331 > 2f)
						{
							num331 = 2f;
						}
					}
					else
					{
						if (num332 > 300f)
						{
							num328 = 0.2f;
						}
						num332 = num333 / num332;
						num330 *= num332;
						num331 *= num332;
					}
					if (velocity.X < num330)
					{
						velocity.X += num328;
						if (num328 > 0.05f && velocity.X < 0f)
						{
							velocity.X += num328;
						}
					}
					if (velocity.X > num330)
					{
						velocity.X -= num328;
						if (num328 > 0.05f && velocity.X > 0f)
						{
							velocity.X -= num328;
						}
					}
					if (velocity.Y < num331)
					{
						velocity.Y += num328;
						if (num328 > 0.05f && velocity.Y < 0f)
						{
							velocity.Y += num328;
						}
					}
					if (velocity.Y > num331)
					{
						velocity.Y -= num328;
						if (num328 > 0.05f && velocity.Y > 0f)
						{
							velocity.Y -= num328;
						}
					}
					localAI[0] += Main.rand.Next(10);
					if (localAI[0] > 10000f)
					{
						if (localAI[1] == 0f)
						{
							if (velocity.X < 0f)
							{
								localAI[1] = -1f;
							}
							else
							{
								localAI[1] = 1f;
							}
						}
						rotation += 0.25f * localAI[1];
						if (localAI[0] > 12000f)
						{
							localAI[0] = 0f;
						}
					}
					else
					{
						localAI[1] = 0f;
						float num334 = velocity.X * 0.1f;
						if (rotation > num334)
						{
							rotation -= (Math.Abs(velocity.X) + Math.Abs(velocity.Y)) * 0.01f;
							if (rotation < num334)
							{
								rotation = num334;
							}
						}
						if (rotation < num334)
						{
							rotation += (Math.Abs(velocity.X) + Math.Abs(velocity.Y)) * 0.01f;
							if (rotation > num334)
							{
								rotation = num334;
							}
						}
					}
					if ((double)rotation > 6.28)
					{
						rotation -= 6.28f;
					}
					if ((double)rotation < -6.28)
					{
						rotation += 6.28f;
					}
				}
				else if (type == 198 || type == 380)
				{
					float num335 = 0.4f;
					if (type == 380)
					{
						num335 = 0.3f;
					}
					tileCollide = false;
					int num336 = 100;
					Vector2 vector28 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
					float num337 = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - vector28.X;
					float num338 = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - vector28.Y;
					num338 += (float)Main.rand.Next(-10, 21);
					num337 += (float)Main.rand.Next(-10, 21);
					num337 += (float)(60 * -Main.player[owner].direction);
					num338 -= 60f;
					if (type == 127)
					{
						num338 = Main.player[owner].position.Y - vector28.Y;
					}
					float num339 = (float)Math.Sqrt(num337 * num337 + num338 * num338);
					float num340 = 14f;
					if (type == 380)
					{
						num340 = 6f;
					}
					if (num339 < (float)num336 && Main.player[owner].velocity.Y == 0f && position.Y + (float)height <= Main.player[owner].position.Y + (float)Main.player[owner].height && !Collision.SolidCollision(position, width, height))
					{
						ai[0] = 0f;
						if (velocity.Y < -6f)
						{
							velocity.Y = -6f;
						}
					}
					if (num339 < 50f)
					{
						if (Math.Abs(velocity.X) > 2f || Math.Abs(velocity.Y) > 2f)
						{
							velocity *= 0.99f;
						}
						num335 = 0.01f;
					}
					else
					{
						if (type == 380)
						{
							if (num339 < 100f)
							{
								num335 = 0.1f;
							}
							if (num339 > 300f)
							{
								num335 = 0.4f;
							}
						}
						else if (type == 198)
						{
							if (num339 < 100f)
							{
								num335 = 0.1f;
							}
							if (num339 > 300f)
							{
								num335 = 0.6f;
							}
						}
						num339 = num340 / num339;
						num337 *= num339;
						num338 *= num339;
					}
					if (velocity.X < num337)
					{
						velocity.X += num335;
						if (num335 > 0.05f && velocity.X < 0f)
						{
							velocity.X += num335;
						}
					}
					if (velocity.X > num337)
					{
						velocity.X -= num335;
						if (num335 > 0.05f && velocity.X > 0f)
						{
							velocity.X -= num335;
						}
					}
					if (velocity.Y < num338)
					{
						velocity.Y += num335;
						if (num335 > 0.05f && velocity.Y < 0f)
						{
							velocity.Y += num335 * 2f;
						}
					}
					if (velocity.Y > num338)
					{
						velocity.Y -= num335;
						if (num335 > 0.05f && velocity.Y > 0f)
						{
							velocity.Y -= num335 * 2f;
						}
					}
					if ((double)velocity.X > 0.25)
					{
						direction = -1;
					}
					else if ((double)velocity.X < -0.25)
					{
						direction = 1;
					}
					spriteDirection = direction;
					rotation = velocity.X * 0.05f;
					frameCounter++;
					int num341 = 2;
					if (type == 380)
					{
						num341 = 5;
					}
					if (frameCounter > num341)
					{
						frame++;
						frameCounter = 0;
					}
					if (frame > 3)
					{
						frame = 0;
					}
				}
				else if (type == 211)
				{
					float num342 = 0.2f;
					float num343 = 5f;
					tileCollide = false;
					Vector2 vector29 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
					float num344 = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - vector29.X;
					float num345 = Main.player[owner].position.Y + Main.player[owner].gfxOffY + (float)(Main.player[owner].height / 2) - vector29.Y;
					if (Main.player[owner].controlLeft)
					{
						num344 -= 120f;
					}
					else if (Main.player[owner].controlRight)
					{
						num344 += 120f;
					}
					if (Main.player[owner].controlDown)
					{
						num345 += 120f;
					}
					else
					{
						if (Main.player[owner].controlUp)
						{
							num345 -= 120f;
						}
						num345 -= 60f;
					}
					float num346 = (float)Math.Sqrt(num344 * num344 + num345 * num345);
					if (num346 > 1000f)
					{
						position.X += num344;
						position.Y += num345;
					}
					if (localAI[0] == 1f)
					{
						if (num346 < 10f && Math.Abs(Main.player[owner].velocity.X) + Math.Abs(Main.player[owner].velocity.Y) < num343 && Main.player[owner].velocity.Y == 0f)
						{
							localAI[0] = 0f;
						}
						num343 = 12f;
						if (num346 < num343)
						{
							velocity.X = num344;
							velocity.Y = num345;
						}
						else
						{
							num346 = num343 / num346;
							velocity.X = num344 * num346;
							velocity.Y = num345 * num346;
						}
						if ((double)velocity.X > 0.5)
						{
							direction = -1;
						}
						else if ((double)velocity.X < -0.5)
						{
							direction = 1;
						}
						spriteDirection = direction;
						rotation -= (0.2f + Math.Abs(velocity.X) * 0.025f) * (float)direction;
						frameCounter++;
						if (frameCounter > 3)
						{
							frame++;
							frameCounter = 0;
						}
						if (frame < 5)
						{
							frame = 5;
						}
						if (frame > 9)
						{
							frame = 5;
						}
						for (int num347 = 0; num347 < 2; num347++)
						{
							int num348 = Dust.NewDust(new Vector2(position.X + 3f, position.Y + 4f), 14, 14, 156);
							Main.dust[num348].velocity *= 0.2f;
							Main.dust[num348].noGravity = true;
							Main.dust[num348].scale = 1.25f;
						}
					}
					else
					{
						if (num346 > 200f)
						{
							localAI[0] = 1f;
						}
						if ((double)velocity.X > 0.5)
						{
							direction = -1;
						}
						else if ((double)velocity.X < -0.5)
						{
							direction = 1;
						}
						spriteDirection = direction;
						if (num346 < 10f)
						{
							velocity.X = num344;
							velocity.Y = num345;
							rotation = velocity.X * 0.05f;
							if (num346 < num343)
							{
								position += velocity;
								velocity *= 0f;
								num342 = 0f;
							}
							direction = -Main.player[owner].direction;
						}
						num346 = num343 / num346;
						num344 *= num346;
						num345 *= num346;
						if (velocity.X < num344)
						{
							velocity.X += num342;
							if (velocity.X < 0f)
							{
								velocity.X *= 0.99f;
							}
						}
						if (velocity.X > num344)
						{
							velocity.X -= num342;
							if (velocity.X > 0f)
							{
								velocity.X *= 0.99f;
							}
						}
						if (velocity.Y < num345)
						{
							velocity.Y += num342;
							if (velocity.Y < 0f)
							{
								velocity.Y *= 0.99f;
							}
						}
						if (velocity.Y > num345)
						{
							velocity.Y -= num342;
							if (velocity.Y > 0f)
							{
								velocity.Y *= 0.99f;
							}
						}
						if (velocity.X != 0f || velocity.Y != 0f)
						{
							rotation = velocity.X * 0.05f;
						}
						frameCounter++;
						if (frameCounter > 3)
						{
							frame++;
							frameCounter = 0;
						}
						if (frame > 4)
						{
							frame = 0;
						}
					}
				}
				else if (type == 199)
				{
					float num349 = 0.1f;
					tileCollide = false;
					int num350 = 200;
					Vector2 vector30 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
					float num351 = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - vector30.X;
					float num352 = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - vector30.Y;
					num352 -= 60f;
					num351 -= 2f;
					if (type == 127)
					{
						num352 = Main.player[owner].position.Y - vector30.Y;
					}
					float num353 = (float)Math.Sqrt(num351 * num351 + num352 * num352);
					float num354 = 4f;
					float num355 = num353;
					if (num353 < (float)num350 && Main.player[owner].velocity.Y == 0f && position.Y + (float)height <= Main.player[owner].position.Y + (float)Main.player[owner].height && !Collision.SolidCollision(position, width, height))
					{
						ai[0] = 0f;
						if (velocity.Y < -6f)
						{
							velocity.Y = -6f;
						}
					}
					if (num353 < 4f)
					{
						velocity.X = num351;
						velocity.Y = num352;
						num349 = 0f;
					}
					else
					{
						if (num353 > 350f)
						{
							num349 = 0.2f;
							num354 = 10f;
						}
						num353 = num354 / num353;
						num351 *= num353;
						num352 *= num353;
					}
					if (velocity.X < num351)
					{
						velocity.X += num349;
						if (velocity.X < 0f)
						{
							velocity.X += num349;
						}
					}
					if (velocity.X > num351)
					{
						velocity.X -= num349;
						if (velocity.X > 0f)
						{
							velocity.X -= num349;
						}
					}
					if (velocity.Y < num352)
					{
						velocity.Y += num349;
						if (velocity.Y < 0f)
						{
							velocity.Y += num349;
						}
					}
					if (velocity.Y > num352)
					{
						velocity.Y -= num349;
						if (velocity.Y > 0f)
						{
							velocity.Y -= num349;
						}
					}
					direction = -Main.player[owner].direction;
					spriteDirection = 1;
					rotation = velocity.Y * 0.05f * (float)(-direction);
					if (num355 >= 50f)
					{
						frameCounter++;
						if (frameCounter > 6)
						{
							frameCounter = 0;
							if (velocity.X < 0f)
							{
								if (frame < 2)
								{
									frame++;
								}
								if (frame > 2)
								{
									frame--;
								}
							}
							else
							{
								if (frame < 6)
								{
									frame++;
								}
								if (frame > 6)
								{
									frame--;
								}
							}
						}
					}
					else
					{
						frameCounter++;
						if (frameCounter > 6)
						{
							frame += direction;
							frameCounter = 0;
						}
						if (frame > 7)
						{
							frame = 0;
						}
						if (frame < 0)
						{
							frame = 7;
						}
					}
				}
				else
				{
					if (ai[1] == 0f)
					{
						int num356 = 500;
						if (type == 127)
						{
							num356 = 200;
						}
						if (type == 208)
						{
							num356 = 300;
						}
						if ((type >= 191 && type <= 194) || type == 266 || (type >= 390 && type <= 392))
						{
							num356 += 40 * minionPos;
							if (localAI[0] > 0f)
							{
								num356 += 500;
							}
							if (type == 266 && localAI[0] > 0f)
							{
								num356 += 100;
							}
						}
						if (Main.player[owner].rocketDelay2 > 0)
						{
							ai[0] = 1f;
						}
						Vector2 vector31 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
						float num357 = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - vector31.X;
						if (type >= 191)
						{
							int type2 = type;
							int num853 = 194;
						}
						float num358 = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - vector31.Y;
						float num359 = (float)Math.Sqrt(num357 * num357 + num358 * num358);
						if (num359 > 2000f)
						{
							position.X = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - (float)(width / 2);
							position.Y = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - (float)(height / 2);
						}
						else if (num359 > (float)num356 || (Math.Abs(num358) > 300f && (((type < 191 || type > 194) && type != 266 && (type < 390 || type > 392)) || !(localAI[0] > 0f))))
						{
							if (type != 324)
							{
								if (num358 > 0f && velocity.Y < 0f)
								{
									velocity.Y = 0f;
								}
								if (num358 < 0f && velocity.Y > 0f)
								{
									velocity.Y = 0f;
								}
							}
							ai[0] = 1f;
						}
					}
					if (type == 209 && ai[0] != 0f)
					{
						if (Main.player[owner].velocity.Y == 0f && alpha >= 100)
						{
							position.X = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - (float)(width / 2);
							position.Y = Main.player[owner].position.Y + (float)Main.player[owner].height - (float)height;
							ai[0] = 0f;
						}
						else
						{
							velocity.X = 0f;
							velocity.Y = 0f;
							alpha += 5;
							if (alpha > 255)
							{
								alpha = 255;
							}
						}
					}
					else if (ai[0] != 0f)
					{
						float num360 = 0.2f;
						int num361 = 200;
						if (type == 127)
						{
							num361 = 100;
						}
						if (type >= 191 && type <= 194)
						{
							num360 = 0.5f;
							num361 = 100;
						}
						tileCollide = false;
						Vector2 vector32 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
						float num362 = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - vector32.X;
						if ((type >= 191 && type <= 194) || type == 266 || (type >= 390 && type <= 392))
						{
							num362 -= (float)(40 * Main.player[owner].direction);
							float num363 = 600f;
							bool flag13 = false;
							for (int num364 = 0; num364 < 200; num364++)
							{
								if (Main.npc[num364].active && !Main.npc[num364].dontTakeDamage && !Main.npc[num364].friendly && Main.npc[num364].lifeMax > 5)
								{
									float num365 = Main.npc[num364].position.X + (float)(Main.npc[num364].width / 2);
									float num366 = Main.npc[num364].position.Y + (float)(Main.npc[num364].height / 2);
									float num367 = Math.Abs(Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - num365) + Math.Abs(Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - num366);
									if (num367 < num363)
									{
										flag13 = true;
										break;
									}
								}
							}
							if (!flag13)
							{
								num362 -= (float)(40 * minionPos * Main.player[owner].direction);
							}
						}
						float num368 = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - vector32.Y;
						if (type == 127)
						{
							num368 = Main.player[owner].position.Y - vector32.Y;
						}
						float num369 = (float)Math.Sqrt(num362 * num362 + num368 * num368);
						float num370 = 10f;
						float num371 = num369;
						if (type == 111)
						{
							num370 = 11f;
						}
						if (type == 127)
						{
							num370 = 9f;
						}
						if (type == 324)
						{
							num370 = 20f;
						}
						if (type >= 191 && type <= 194)
						{
							num360 = 0.4f;
							num370 = 12f;
							if (num370 < Math.Abs(Main.player[owner].velocity.X) + Math.Abs(Main.player[owner].velocity.Y))
							{
								num370 = Math.Abs(Main.player[owner].velocity.X) + Math.Abs(Main.player[owner].velocity.Y);
							}
						}
						if (type == 208 && Math.Abs(Main.player[owner].velocity.X) + Math.Abs(Main.player[owner].velocity.Y) > 4f)
						{
							num361 = -1;
						}
						if (num369 < (float)num361 && Main.player[owner].velocity.Y == 0f && position.Y + (float)height <= Main.player[owner].position.Y + (float)Main.player[owner].height && !Collision.SolidCollision(position, width, height))
						{
							ai[0] = 0f;
							if (velocity.Y < -6f)
							{
								velocity.Y = -6f;
							}
						}
						if (num369 < 60f)
						{
							num362 = velocity.X;
							num368 = velocity.Y;
						}
						else
						{
							num369 = num370 / num369;
							num362 *= num369;
							num368 *= num369;
						}
						if (type == 324)
						{
							if (num371 > 1000f)
							{
								if ((double)(Math.Abs(velocity.X) + Math.Abs(velocity.Y)) < (double)num370 - 1.25)
								{
									velocity *= 1.025f;
								}
								if ((double)(Math.Abs(velocity.X) + Math.Abs(velocity.Y)) > (double)num370 + 1.25)
								{
									velocity *= 0.975f;
								}
							}
							else if (num371 > 600f)
							{
								if (Math.Abs(velocity.X) + Math.Abs(velocity.Y) < num370 - 1f)
								{
									velocity *= 1.05f;
								}
								if (Math.Abs(velocity.X) + Math.Abs(velocity.Y) > num370 + 1f)
								{
									velocity *= 0.95f;
								}
							}
							else if (num371 > 400f)
							{
								if ((double)(Math.Abs(velocity.X) + Math.Abs(velocity.Y)) < (double)num370 - 0.5)
								{
									velocity *= 1.075f;
								}
								if ((double)(Math.Abs(velocity.X) + Math.Abs(velocity.Y)) > (double)num370 + 0.5)
								{
									velocity *= 0.925f;
								}
							}
							else
							{
								if ((double)(Math.Abs(velocity.X) + Math.Abs(velocity.Y)) < (double)num370 - 0.25)
								{
									velocity *= 1.1f;
								}
								if ((double)(Math.Abs(velocity.X) + Math.Abs(velocity.Y)) > (double)num370 + 0.25)
								{
									velocity *= 0.9f;
								}
							}
							velocity.X = (velocity.X * 34f + num362) / 35f;
							velocity.Y = (velocity.Y * 34f + num368) / 35f;
						}
						else
						{
							if (velocity.X < num362)
							{
								velocity.X += num360;
								if (velocity.X < 0f)
								{
									velocity.X += num360 * 1.5f;
								}
							}
							if (velocity.X > num362)
							{
								velocity.X -= num360;
								if (velocity.X > 0f)
								{
									velocity.X -= num360 * 1.5f;
								}
							}
							if (velocity.Y < num368)
							{
								velocity.Y += num360;
								if (velocity.Y < 0f)
								{
									velocity.Y += num360 * 1.5f;
								}
							}
							if (velocity.Y > num368)
							{
								velocity.Y -= num360;
								if (velocity.Y > 0f)
								{
									velocity.Y -= num360 * 1.5f;
								}
							}
						}
						if (type == 111)
						{
							frame = 7;
						}
						if (type == 112)
						{
							frame = 2;
						}
						if (type >= 191 && type <= 194 && frame < 12)
						{
							frame = Main.rand.Next(12, 18);
							frameCounter = 0;
						}
						if (type != 313)
						{
							if ((double)velocity.X > 0.5)
							{
								spriteDirection = -1;
							}
							else if ((double)velocity.X < -0.5)
							{
								spriteDirection = 1;
							}
						}
						if (type == 398)
						{
							if ((double)velocity.X > 0.5)
							{
								spriteDirection = 1;
							}
							else if ((double)velocity.X < -0.5)
							{
								spriteDirection = -1;
							}
						}
						if (type == 112)
						{
							if (spriteDirection == -1)
							{
								rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
							}
							else
							{
								rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
							}
						}
						else if (type >= 390 && type <= 392)
						{
							int num372 = (int)(center().X / 16f);
							int num373 = (int)(center().Y / 16f);
							if (Main.tile[num372, num373] != null && Main.tile[num372, num373].wall > 0)
							{
								rotation = velocity.ToRotation() + (float)Math.PI / 2f;
								frameCounter += (int)(Math.Abs(velocity.X) + Math.Abs(velocity.Y));
								if (frameCounter > 5)
								{
									frame++;
									frameCounter = 0;
								}
								if (frame > 7)
								{
									frame = 4;
								}
								if (frame < 4)
								{
									frame = 7;
								}
							}
							else
							{
								frameCounter++;
								if (frameCounter > 2)
								{
									frame++;
									frameCounter = 0;
								}
								if (frame < 8 || frame > 10)
								{
									frame = 8;
								}
								rotation = velocity.X * 0.1f;
							}
						}
						else if (type == 334)
						{
							frameCounter++;
							if (frameCounter > 1)
							{
								frame++;
								frameCounter = 0;
							}
							if (frame < 7 || frame > 10)
							{
								frame = 7;
							}
							rotation = velocity.X * 0.1f;
						}
						else if (type == 353)
						{
							frameCounter++;
							if (frameCounter > 6)
							{
								frame++;
								frameCounter = 0;
							}
							if (frame < 10 || frame > 13)
							{
								frame = 10;
							}
							rotation = velocity.X * 0.05f;
						}
						else if (type == 127)
						{
							frameCounter += 3;
							if (frameCounter > 6)
							{
								frame++;
								frameCounter = 0;
							}
							if (frame <= 5 || frame > 15)
							{
								frame = 6;
							}
							rotation = velocity.X * 0.1f;
						}
						else if (type == 269)
						{
							if (frame == 6)
							{
								frameCounter = 0;
							}
							else if (frame < 4 || frame > 6)
							{
								frameCounter = 0;
								frame = 4;
							}
							else
							{
								frameCounter++;
								if (frameCounter > 6)
								{
									frame++;
									frameCounter = 0;
								}
							}
							rotation = velocity.X * 0.05f;
						}
						else if (type == 266)
						{
							frameCounter++;
							if (frameCounter > 6)
							{
								frame++;
								frameCounter = 0;
							}
							if (frame < 2 || frame > 5)
							{
								frame = 2;
							}
							rotation = velocity.X * 0.1f;
						}
						else if (type == 324)
						{
							frameCounter++;
							if (frameCounter > 1)
							{
								frame++;
								frameCounter = 0;
							}
							if (frame < 6 || frame > 9)
							{
								frame = 6;
							}
							rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.58f;
							Lighting.addLight((int)center().X / 16, (int)center().Y / 16, 0.9f, 0.6f, 0.2f);
							for (int num374 = 0; num374 < 2; num374++)
							{
								int num375 = 4;
								int num376 = Dust.NewDust(new Vector2(center().X - (float)num375, center().Y - (float)num375) - velocity * 0f, num375 * 2, num375 * 2, 6, 0f, 0f, 100);
								Main.dust[num376].scale *= 1.8f + (float)Main.rand.Next(10) * 0.1f;
								Main.dust[num376].velocity *= 0.2f;
								if (num374 == 1)
								{
									Main.dust[num376].position -= velocity * 0.5f;
								}
								Main.dust[num376].noGravity = true;
								num376 = Dust.NewDust(new Vector2(center().X - (float)num375, center().Y - (float)num375) - velocity * 0f, num375 * 2, num375 * 2, 31, 0f, 0f, 100, default(Color), 0.5f);
								Main.dust[num376].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
								Main.dust[num376].velocity *= 0.05f;
								if (num374 == 1)
								{
									Main.dust[num376].position -= velocity * 0.5f;
								}
							}
						}
						else if (type == 268)
						{
							frameCounter++;
							if (frameCounter > 4)
							{
								frame++;
								frameCounter = 0;
							}
							if (frame < 6 || frame > 7)
							{
								frame = 6;
							}
							rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.58f;
						}
						else if (type == 200)
						{
							frameCounter += 3;
							if (frameCounter > 6)
							{
								frame++;
								frameCounter = 0;
							}
							if (frame <= 5 || frame > 9)
							{
								frame = 6;
							}
							rotation = velocity.X * 0.1f;
						}
						else if (type == 208)
						{
							rotation = velocity.X * 0.075f;
							frameCounter++;
							if (frameCounter > 6)
							{
								frame++;
								frameCounter = 0;
							}
							if (frame > 4)
							{
								frame = 1;
							}
							if (frame < 1)
							{
								frame = 1;
							}
						}
						else if (type == 236)
						{
							rotation = velocity.Y * 0.05f * (float)direction;
							if (velocity.Y < 0f)
							{
								frameCounter += 2;
							}
							else
							{
								frameCounter++;
							}
							if (frameCounter >= 6)
							{
								frame++;
								frameCounter = 0;
							}
							if (frame > 12)
							{
								frame = 9;
							}
							if (frame < 9)
							{
								frame = 9;
							}
						}
						else if (type == 314)
						{
							rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.58f;
							frameCounter++;
							if (frameCounter >= 3)
							{
								frame++;
								frameCounter = 0;
							}
							if (frame > 12)
							{
								frame = 7;
							}
							if (frame < 7)
							{
								frame = 7;
							}
						}
						else if (type == 319)
						{
							rotation = velocity.X * 0.05f;
							frameCounter++;
							if (frameCounter >= 6)
							{
								frame++;
								frameCounter = 0;
							}
							if (frame > 10)
							{
								frame = 6;
							}
							if (frame < 6)
							{
								frame = 6;
							}
						}
						else if (type == 210)
						{
							rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.58f;
							frameCounter += 3;
							if (frameCounter > 6)
							{
								frame++;
								frameCounter = 0;
							}
							if (frame > 11)
							{
								frame = 7;
							}
							if (frame < 7)
							{
								frame = 7;
							}
						}
						else if (type == 313)
						{
							position.Y += height;
							height = 54;
							position.Y -= height;
							position.X += width / 2;
							width = 54;
							position.X -= width / 2;
							rotation += velocity.X * 0.01f;
							frameCounter = 0;
							frame = 11;
						}
						else if (type == 398)
						{
							frameCounter++;
							if (frameCounter > 1)
							{
								frame++;
								frameCounter = 0;
							}
							if (frame < 6 || frame > 9)
							{
								frame = 6;
							}
							rotation = velocity.X * 0.1f;
						}
						else if (spriteDirection == -1)
						{
							rotation = (float)Math.Atan2(velocity.Y, velocity.X);
						}
						else
						{
							rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 3.14f;
						}
						if ((type < 191 || type > 194) && type != 398 && type != 390 && type != 391 && type != 392 && type != 127 && type != 200 && type != 208 && type != 210 && type != 236 && type != 266 && type != 268 && type != 269 && type != 313 && type != 314 && type != 319 && type != 324 && type != 334 && type != 353)
						{
							int num377 = Dust.NewDust(new Vector2(position.X + (float)(width / 2) - 4f, position.Y + (float)(height / 2) - 4f) - velocity, 8, 8, 16, (0f - velocity.X) * 0.5f, velocity.Y * 0.5f, 50, default(Color), 1.7f);
							Main.dust[num377].velocity.X = Main.dust[num377].velocity.X * 0.2f;
							Main.dust[num377].velocity.Y = Main.dust[num377].velocity.Y * 0.2f;
							Main.dust[num377].noGravity = true;
						}
					}
					else
					{
						if (type >= 191 && type <= 194)
						{
							float num378 = 40 * minionPos;
							int num379 = 30;
							int num380 = 60;
							localAI[0] -= 1f;
							if (localAI[0] < 0f)
							{
								localAI[0] = 0f;
							}
							if (ai[1] > 0f)
							{
								ai[1] -= 1f;
							}
							else
							{
								float num381 = position.X;
								float num382 = position.Y;
								float num383 = 100000f;
								float num384 = num383;
								int num385 = -1;
								for (int num386 = 0; num386 < 200; num386++)
								{
									if (!Main.npc[num386].active || Main.npc[num386].dontTakeDamage || Main.npc[num386].friendly || Main.npc[num386].lifeMax <= 5)
									{
										continue;
									}
									float num387 = Main.npc[num386].position.X + (float)(Main.npc[num386].width / 2);
									float num388 = Main.npc[num386].position.Y + (float)(Main.npc[num386].height / 2);
									float num389 = Math.Abs(position.X + (float)(width / 2) - num387) + Math.Abs(position.Y + (float)(height / 2) - num388);
									if (num389 < num383)
									{
										if (num385 == -1 && num389 <= num384)
										{
											num384 = num389;
											num381 = num387;
											num382 = num388;
										}
										if (Collision.CanHit(position, width, height, Main.npc[num386].position, Main.npc[num386].width, Main.npc[num386].height))
										{
											num383 = num389;
											num381 = num387;
											num382 = num388;
											num385 = num386;
										}
									}
								}
								if (num385 == -1 && num384 < num383)
								{
									num383 = num384;
								}
								float num390 = 400f;
								if ((double)position.Y > Main.worldSurface * 16.0)
								{
									num390 = 200f;
								}
								if (num383 < num390 + num378 && num385 == -1)
								{
									float num391 = num381 - (position.X + (float)(width / 2));
									if (num391 < -5f)
									{
										flag9 = true;
										flag10 = false;
									}
									else if (num391 > 5f)
									{
										flag10 = true;
										flag9 = false;
									}
								}
								else if (num385 >= 0 && num383 < 800f + num378)
								{
									localAI[0] = num380;
									float num392 = num381 - (position.X + (float)(width / 2));
									if (num392 > 300f || num392 < -300f)
									{
										if (num392 < -50f)
										{
											flag9 = true;
											flag10 = false;
										}
										else if (num392 > 50f)
										{
											flag10 = true;
											flag9 = false;
										}
									}
									else if (owner == Main.myPlayer)
									{
										ai[1] = num379;
										float num393 = 12f;
										Vector2 vector33 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)(height / 2) - 8f);
										float num394 = num381 - vector33.X + (float)Main.rand.Next(-20, 21);
										float num395 = Math.Abs(num394) * 0.1f;
										num395 = num395 * (float)Main.rand.Next(0, 100) * 0.001f;
										float num396 = num382 - vector33.Y + (float)Main.rand.Next(-20, 21) - num395;
										float num397 = (float)Math.Sqrt(num394 * num394 + num396 * num396);
										num397 = num393 / num397;
										num394 *= num397;
										num396 *= num397;
										int num398 = damage;
										int num399 = 195;
										int num400 = NewProjectile(vector33.X, vector33.Y, num394, num396, num399, num398, knockBack, Main.myPlayer);
										Main.projectile[num400].timeLeft = 300;
										if (num394 < 0f)
										{
											direction = -1;
										}
										if (num394 > 0f)
										{
											direction = 1;
										}
										netUpdate = true;
									}
								}
							}
						}
						bool flag14 = false;
						Vector2 vector34 = Vector2.Zero;
						if (type == 266 || (type >= 390 && type <= 392))
						{
							float num401 = 40 * minionPos;
							int num402 = 60;
							localAI[0] -= 1f;
							if (localAI[0] < 0f)
							{
								localAI[0] = 0f;
							}
							if (ai[1] > 0f)
							{
								ai[1] -= 1f;
							}
							else
							{
								float num403 = position.X;
								float num404 = position.Y;
								float num405 = 100000f;
								float num406 = num405;
								int num407 = -1;
								for (int num408 = 0; num408 < 200; num408++)
								{
									if (!Main.npc[num408].active || Main.npc[num408].dontTakeDamage || Main.npc[num408].friendly || Main.npc[num408].lifeMax <= 5)
									{
										continue;
									}
									float num409 = Main.npc[num408].position.X + (float)(Main.npc[num408].width / 2);
									float num410 = Main.npc[num408].position.Y + (float)(Main.npc[num408].height / 2);
									float num411 = Math.Abs(position.X + (float)(width / 2) - num409) + Math.Abs(position.Y + (float)(height / 2) - num410);
									if (num411 < num405)
									{
										if (num407 == -1 && num411 <= num406)
										{
											num406 = num411;
											num403 = num409;
											num404 = num410;
										}
										if (Collision.CanHit(position, width, height, Main.npc[num408].position, Main.npc[num408].width, Main.npc[num408].height))
										{
											num405 = num411;
											num403 = num409;
											num404 = num410;
											num407 = num408;
										}
									}
								}
								if (num407 == -1 && num406 < num405)
								{
									num405 = num406;
								}
								else if (num407 >= 0)
								{
									flag14 = true;
									vector34 = new Vector2(num403, num404) - center();
								}
								float num412 = 300f;
								if ((double)position.Y > Main.worldSurface * 16.0)
								{
									num412 = 150f;
								}
								if (type >= 390 && type <= 392)
								{
									num412 = 500f;
									if ((double)position.Y > Main.worldSurface * 16.0)
									{
										num412 = 250f;
									}
								}
								if (num405 < num412 + num401 && num407 == -1)
								{
									float num413 = num403 - (position.X + (float)(width / 2));
									if (num413 < -5f)
									{
										flag9 = true;
										flag10 = false;
									}
									else if (num413 > 5f)
									{
										flag10 = true;
										flag9 = false;
									}
								}
								bool flag15 = false;
								if (type >= 390 && type <= 392 && localAI[1] > 0f)
								{
									flag15 = true;
									localAI[1] -= 1f;
								}
								if (num407 >= 0 && num405 < 800f + num401)
								{
									friendly = true;
									localAI[0] = num402;
									float num414 = num403 - (position.X + (float)(width / 2));
									if (num414 < -10f)
									{
										flag9 = true;
										flag10 = false;
									}
									else if (num414 > 10f)
									{
										flag10 = true;
										flag9 = false;
									}
									if (num404 < center().Y - 100f && num414 > -50f && num414 < 50f && velocity.Y == 0f)
									{
										float num415 = Math.Abs(num404 - center().Y);
										if (num415 < 120f)
										{
											velocity.Y = -10f;
										}
										else if (num415 < 210f)
										{
											velocity.Y = -13f;
										}
										else if (num415 < 270f)
										{
											velocity.Y = -15f;
										}
										else if (num415 < 310f)
										{
											velocity.Y = -17f;
										}
										else if (num415 < 380f)
										{
											velocity.Y = -18f;
										}
									}
									if (flag15)
									{
										friendly = false;
										if (velocity.X < 0f)
										{
											flag9 = true;
										}
										else if (velocity.X > 0f)
										{
											flag10 = true;
										}
									}
								}
								else
								{
									friendly = false;
								}
							}
						}
						if (ai[1] != 0f)
						{
							flag9 = false;
							flag10 = false;
						}
						else if (type >= 191 && type <= 194 && localAI[0] == 0f)
						{
							direction = Main.player[owner].direction;
						}
						else if (type >= 390 && type <= 392)
						{
							int num416 = (int)(center().X / 16f);
							int num417 = (int)(center().Y / 16f);
							if (Main.tile[num416, num417] != null && Main.tile[num416, num417].wall > 0)
							{
								flag9 = (flag10 = false);
							}
						}
						if (type == 127)
						{
							if ((double)rotation > -0.1 && (double)rotation < 0.1)
							{
								rotation = 0f;
							}
							else if (rotation < 0f)
							{
								rotation += 0.1f;
							}
							else
							{
								rotation -= 0.1f;
							}
						}
						else if (type != 313)
						{
							rotation = 0f;
						}
						tileCollide = true;
						float num418 = 0.08f;
						float num419 = 6.5f;
						if (type == 127)
						{
							num419 = 2f;
							num418 = 0.04f;
						}
						if (type == 112)
						{
							num419 = 6f;
							num418 = 0.06f;
						}
						if (type == 334)
						{
							num419 = 8f;
							num418 = 0.08f;
						}
						if (type == 268)
						{
							num419 = 8f;
							num418 = 0.4f;
						}
						if (type == 324)
						{
							num418 = 0.1f;
							num419 = 3f;
						}
						if ((type >= 191 && type <= 194) || type == 266 || (type >= 390 && type <= 392))
						{
							num419 = 6f;
							num418 = 0.2f;
							if (num419 < Math.Abs(Main.player[owner].velocity.X) + Math.Abs(Main.player[owner].velocity.Y))
							{
								num419 = Math.Abs(Main.player[owner].velocity.X) + Math.Abs(Main.player[owner].velocity.Y);
								num418 = 0.3f;
							}
						}
						if (type >= 390 && type <= 392)
						{
							num418 *= 2f;
						}
						if (flag9)
						{
							if ((double)velocity.X > -3.5)
							{
								velocity.X -= num418;
							}
							else
							{
								velocity.X -= num418 * 0.25f;
							}
						}
						else if (flag10)
						{
							if ((double)velocity.X < 3.5)
							{
								velocity.X += num418;
							}
							else
							{
								velocity.X += num418 * 0.25f;
							}
						}
						else
						{
							velocity.X *= 0.9f;
							if (velocity.X >= 0f - num418 && velocity.X <= num418)
							{
								velocity.X = 0f;
							}
						}
						if (type == 208)
						{
							velocity.X *= 0.95f;
							if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
							{
								velocity.X = 0f;
							}
							flag9 = false;
							flag10 = false;
						}
						if (flag9 || flag10)
						{
							int num420 = (int)(position.X + (float)(width / 2)) / 16;
							int j2 = (int)(position.Y + (float)(height / 2)) / 16;
							if (type == 236)
							{
								num420 += direction;
							}
							if (flag9)
							{
								num420--;
							}
							if (flag10)
							{
								num420++;
							}
							num420 += (int)velocity.X;
							if (WorldGen.SolidTile(num420, j2))
							{
								flag12 = true;
							}
						}
						if (Main.player[owner].position.Y + (float)Main.player[owner].height - 8f > position.Y + (float)height)
						{
							flag11 = true;
						}
						if (type == 268 && frameCounter < 10)
						{
							flag12 = false;
						}
						Collision.StepUp(ref position, ref velocity, width, height, ref stepSpeed, ref gfxOffY);
						if (velocity.Y == 0f || type == 200)
						{
							if (!flag11 && (velocity.X < 0f || velocity.X > 0f))
							{
								int num421 = (int)(position.X + (float)(width / 2)) / 16;
								int j3 = (int)(position.Y + (float)(height / 2)) / 16 + 1;
								if (flag9)
								{
									num421--;
								}
								if (flag10)
								{
									num421++;
								}
								WorldGen.SolidTile(num421, j3);
							}
							if (flag12)
							{
								int num422 = (int)(position.X + (float)(width / 2)) / 16;
								int num423 = (int)(position.Y + (float)height) / 16 + 1;
								if (WorldGen.SolidTile(num422, num423) || Main.tile[num422, num423].halfBrick() || Main.tile[num422, num423].slope() > 0 || type == 200)
								{
									if (type == 200)
									{
										velocity.Y = -3.1f;
									}
									else
									{
										try
										{
											num422 = (int)(position.X + (float)(width / 2)) / 16;
											num423 = (int)(position.Y + (float)(height / 2)) / 16;
											if (flag9)
											{
												num422--;
											}
											if (flag10)
											{
												num422++;
											}
											num422 += (int)velocity.X;
											if (!WorldGen.SolidTile(num422, num423 - 1) && !WorldGen.SolidTile(num422, num423 - 2))
											{
												velocity.Y = -5.1f;
											}
											else if (!WorldGen.SolidTile(num422, num423 - 2))
											{
												velocity.Y = -7.1f;
											}
											else if (WorldGen.SolidTile(num422, num423 - 5))
											{
												velocity.Y = -11.1f;
											}
											else if (WorldGen.SolidTile(num422, num423 - 4))
											{
												velocity.Y = -10.1f;
											}
											else
											{
												velocity.Y = -9.1f;
											}
										}
										catch
										{
											velocity.Y = -9.1f;
										}
									}
									if (type == 127)
									{
										ai[0] = 1f;
									}
								}
							}
							else if (type == 266 && (flag9 || flag10))
							{
								velocity.Y -= 6f;
							}
						}
						if (velocity.X > num419)
						{
							velocity.X = num419;
						}
						if (velocity.X < 0f - num419)
						{
							velocity.X = 0f - num419;
						}
						if (velocity.X < 0f)
						{
							direction = -1;
						}
						if (velocity.X > 0f)
						{
							direction = 1;
						}
						if (velocity.X > num418 && flag10)
						{
							direction = 1;
						}
						if (velocity.X < 0f - num418 && flag9)
						{
							direction = -1;
						}
						if (type != 313)
						{
							if (direction == -1)
							{
								spriteDirection = 1;
							}
							if (direction == 1)
							{
								spriteDirection = -1;
							}
						}
						if (type == 398)
						{
							spriteDirection = direction;
						}
						if (type >= 191 && type <= 194)
						{
							if (ai[1] > 0f)
							{
								if (localAI[1] == 0f)
								{
									localAI[1] = 1f;
									frame = 1;
								}
								if (frame != 0)
								{
									frameCounter++;
									if (frameCounter > 4)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame == 4)
									{
										frame = 0;
									}
								}
							}
							else if (velocity.Y == 0f)
							{
								localAI[1] = 0f;
								if (velocity.X == 0f)
								{
									frame = 0;
									frameCounter = 0;
								}
								else if ((double)velocity.X < -0.8 || (double)velocity.X > 0.8)
								{
									frameCounter += (int)Math.Abs(velocity.X);
									frameCounter++;
									if (frameCounter > 6)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame < 5)
									{
										frame = 5;
									}
									if (frame >= 11)
									{
										frame = 5;
									}
								}
								else
								{
									frame = 0;
									frameCounter = 0;
								}
							}
							else if (velocity.Y < 0f)
							{
								frameCounter = 0;
								frame = 4;
							}
							else if (velocity.Y > 0f)
							{
								frameCounter = 0;
								frame = 4;
							}
							velocity.Y += 0.4f;
							if (velocity.Y > 10f)
							{
								velocity.Y = 10f;
							}
						}
						else if (type == 268)
						{
							if (velocity.Y == 0f)
							{
								if (frame > 5)
								{
									frameCounter = 0;
								}
								if (velocity.X == 0f)
								{
									int num424 = 3;
									frameCounter++;
									if (frameCounter < num424)
									{
										frame = 0;
									}
									else if (frameCounter < num424 * 2)
									{
										frame = 1;
									}
									else if (frameCounter < num424 * 3)
									{
										frame = 2;
									}
									else if (frameCounter < num424 * 4)
									{
										frame = 3;
									}
									else
									{
										frameCounter = num424 * 4;
									}
								}
								else
								{
									velocity.X *= 0.8f;
									frameCounter++;
									int num425 = 3;
									if (frameCounter < num425)
									{
										frame = 0;
									}
									else if (frameCounter < num425 * 2)
									{
										frame = 1;
									}
									else if (frameCounter < num425 * 3)
									{
										frame = 2;
									}
									else if (frameCounter < num425 * 4)
									{
										frame = 3;
									}
									else if (flag9 || flag10)
									{
										velocity.X *= 2f;
										frame = 4;
										velocity.Y = -6.1f;
										frameCounter = 0;
										for (int num426 = 0; num426 < 4; num426++)
										{
											int num427 = Dust.NewDust(new Vector2(position.X, position.Y + (float)height - 2f), width, 4, 5);
											Main.dust[num427].velocity += velocity;
											Main.dust[num427].velocity *= 0.4f;
										}
									}
									else
									{
										frameCounter = num425 * 4;
									}
								}
							}
							else if (velocity.Y < 0f)
							{
								frameCounter = 0;
								frame = 5;
							}
							else
							{
								frame = 4;
								frameCounter = 3;
							}
							velocity.Y += 0.4f;
							if (velocity.Y > 10f)
							{
								velocity.Y = 10f;
							}
						}
						else if (type == 269)
						{
							if (velocity.Y >= 0f && (double)velocity.Y <= 0.8)
							{
								if (velocity.X == 0f)
								{
									frame = 0;
									frameCounter = 0;
								}
								else if ((double)velocity.X < -0.8 || (double)velocity.X > 0.8)
								{
									int num428 = Dust.NewDust(new Vector2(position.X, position.Y + (float)height - 2f), width, 6, 76);
									Main.dust[num428].noGravity = true;
									Main.dust[num428].velocity *= 0.3f;
									Main.dust[num428].noLight = true;
									frameCounter += (int)Math.Abs(velocity.X);
									frameCounter++;
									if (frameCounter > 6)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame > 3)
									{
										frame = 0;
									}
								}
								else
								{
									frame = 0;
									frameCounter = 0;
								}
							}
							else
							{
								frameCounter = 0;
								frame = 2;
							}
							velocity.Y += 0.4f;
							if (velocity.Y > 10f)
							{
								velocity.Y = 10f;
							}
						}
						else if (type == 313)
						{
							int num429 = (int)(center().X / 16f);
							int num430 = (int)(center().Y / 16f);
							if (Main.tile[num429, num430] != null && Main.tile[num429, num430].wall > 0)
							{
								position.Y += height;
								height = 34;
								position.Y -= height;
								position.X += width / 2;
								width = 34;
								position.X -= width / 2;
								float num431 = 4f;
								Vector2 vector35 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
								float num432 = Main.player[owner].center().X - vector35.X;
								float num433 = Main.player[owner].center().Y - vector35.Y;
								float num434 = (float)Math.Sqrt(num432 * num432 + num433 * num433);
								float num435 = num431 / num434;
								num432 *= num435;
								num433 *= num435;
								if (num434 < 120f)
								{
									velocity.X *= 0.9f;
									velocity.Y *= 0.9f;
									if ((double)(Math.Abs(velocity.X) + Math.Abs(velocity.Y)) < 0.1)
									{
										velocity *= 0f;
									}
								}
								else
								{
									velocity.X = (velocity.X * 9f + num432) / 10f;
									velocity.Y = (velocity.Y * 9f + num433) / 10f;
								}
								if (num434 >= 120f)
								{
									spriteDirection = direction;
									rotation = (float)Math.Atan2(velocity.Y * (float)(-direction), velocity.X * (float)(-direction));
								}
								frameCounter += (int)(Math.Abs(velocity.X) + Math.Abs(velocity.Y));
								if (frameCounter > 6)
								{
									frame++;
									frameCounter = 0;
								}
								if (frame > 10)
								{
									frame = 5;
								}
								if (frame < 5)
								{
									frame = 10;
								}
							}
							else
							{
								rotation = 0f;
								if (direction == -1)
								{
									spriteDirection = 1;
								}
								if (direction == 1)
								{
									spriteDirection = -1;
								}
								position.Y += height;
								height = 30;
								position.Y -= height;
								position.X += width / 2;
								width = 30;
								position.X -= width / 2;
								if (velocity.Y >= 0f && (double)velocity.Y <= 0.8)
								{
									if (velocity.X == 0f)
									{
										frame = 0;
										frameCounter = 0;
									}
									else if ((double)velocity.X < -0.8 || (double)velocity.X > 0.8)
									{
										frameCounter += (int)Math.Abs(velocity.X);
										frameCounter++;
										if (frameCounter > 6)
										{
											frame++;
											frameCounter = 0;
										}
										if (frame > 3)
										{
											frame = 0;
										}
									}
									else
									{
										frame = 0;
										frameCounter = 0;
									}
								}
								else
								{
									frameCounter = 0;
									frame = 4;
								}
								velocity.Y += 0.4f;
								if (velocity.Y > 10f)
								{
									velocity.Y = 10f;
								}
							}
						}
						else if (type >= 390 && type <= 392)
						{
							int num436 = (int)(center().X / 16f);
							int num437 = (int)(center().Y / 16f);
							if (Main.tile[num436, num437] != null && Main.tile[num436, num437].wall > 0)
							{
								position.Y += height;
								height = 34;
								position.Y -= height;
								position.X += width / 2;
								width = 34;
								position.X -= width / 2;
								float num438 = 9f;
								float num439 = 40 * (minionPos + 1);
								Vector2 vector36 = Main.player[owner].center() - center();
								if (flag14)
								{
									vector36 = vector34;
									num439 = 10f;
								}
								if (vector36.Length() < num439)
								{
									velocity *= 0.9f;
									if ((double)(Math.Abs(velocity.X) + Math.Abs(velocity.Y)) < 0.1)
									{
										velocity *= 0f;
									}
								}
								else if (vector36.Length() < 800f || !flag14)
								{
									velocity = (velocity * 9f + Vector2.Normalize(vector36) * num438) / 10f;
								}
								if (vector36.Length() >= num439)
								{
									spriteDirection = direction;
									rotation = velocity.ToRotation() + (float)Math.PI / 2f;
								}
								else
								{
									rotation = vector36.ToRotation() + (float)Math.PI / 2f;
								}
								frameCounter += (int)(Math.Abs(velocity.X) + Math.Abs(velocity.Y));
								if (frameCounter > 5)
								{
									frame++;
									frameCounter = 0;
								}
								if (frame > 7)
								{
									frame = 4;
								}
								if (frame < 4)
								{
									frame = 7;
								}
							}
							else
							{
								rotation = 0f;
								if (direction == -1)
								{
									spriteDirection = 1;
								}
								if (direction == 1)
								{
									spriteDirection = -1;
								}
								position.Y += height;
								height = 30;
								position.Y -= height;
								position.X += width / 2;
								width = 30;
								position.X -= width / 2;
								if (frame >= 4 && frame <= 7)
								{
									Vector2 vector37 = Main.player[owner].center() - center();
									if (flag14)
									{
										vector37 = vector34;
									}
									float num440 = 0f - vector37.Y;
									if (!(vector37.Y > 0f))
									{
										if (num440 < 120f)
										{
											velocity.Y = -10f;
										}
										else if (num440 < 210f)
										{
											velocity.Y = -13f;
										}
										else if (num440 < 270f)
										{
											velocity.Y = -15f;
										}
										else if (num440 < 310f)
										{
											velocity.Y = -17f;
										}
										else if (num440 < 380f)
										{
											velocity.Y = -18f;
										}
									}
								}
								if (velocity.Y >= 0f && (double)velocity.Y <= 0.8)
								{
									if (velocity.X == 0f)
									{
										frame = 0;
										frameCounter = 0;
									}
									else if ((double)velocity.X < -0.8 || (double)velocity.X > 0.8)
									{
										frameCounter += (int)Math.Abs(velocity.X);
										frameCounter++;
										if (frameCounter > 5)
										{
											frame++;
											frameCounter = 0;
										}
										if (frame > 2)
										{
											frame = 0;
										}
									}
									else
									{
										frame = 0;
										frameCounter = 0;
									}
								}
								else
								{
									frameCounter = 0;
									frame = 3;
								}
								velocity.Y += 0.4f;
								if (velocity.Y > 10f)
								{
									velocity.Y = 10f;
								}
							}
						}
						else if (type == 314)
						{
							if (velocity.Y >= 0f && (double)velocity.Y <= 0.8)
							{
								if (velocity.X == 0f)
								{
									frame = 0;
									frameCounter = 0;
								}
								else if ((double)velocity.X < -0.8 || (double)velocity.X > 0.8)
								{
									frameCounter += (int)Math.Abs(velocity.X);
									frameCounter++;
									if (frameCounter > 6)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame > 6)
									{
										frame = 1;
									}
								}
								else
								{
									frame = 0;
									frameCounter = 0;
								}
							}
							else
							{
								frameCounter = 0;
								frame = 7;
							}
							velocity.Y += 0.4f;
							if (velocity.Y > 10f)
							{
								velocity.Y = 10f;
							}
						}
						else if (type == 319)
						{
							if (velocity.Y >= 0f && (double)velocity.Y <= 0.8)
							{
								if (velocity.X == 0f)
								{
									frame = 0;
									frameCounter = 0;
								}
								else if ((double)velocity.X < -0.8 || (double)velocity.X > 0.8)
								{
									frameCounter += (int)Math.Abs(velocity.X);
									frameCounter++;
									if (frameCounter > 8)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame > 5)
									{
										frame = 2;
									}
								}
								else
								{
									frame = 0;
									frameCounter = 0;
								}
							}
							else
							{
								frameCounter = 0;
								frame = 1;
							}
							velocity.Y += 0.4f;
							if (velocity.Y > 10f)
							{
								velocity.Y = 10f;
							}
						}
						else if (type == 236)
						{
							if (velocity.Y >= 0f && (double)velocity.Y <= 0.8)
							{
								if (velocity.X == 0f)
								{
									frame = 0;
									frameCounter = 0;
								}
								else if ((double)velocity.X < -0.8 || (double)velocity.X > 0.8)
								{
									if (frame < 2)
									{
										frame = 2;
									}
									frameCounter += (int)Math.Abs(velocity.X);
									frameCounter++;
									if (frameCounter > 6)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame > 8)
									{
										frame = 2;
									}
								}
								else
								{
									frame = 0;
									frameCounter = 0;
								}
							}
							else
							{
								frameCounter = 0;
								frame = 1;
							}
							velocity.Y += 0.4f;
							if (velocity.Y > 10f)
							{
								velocity.Y = 10f;
							}
						}
						else if (type == 266)
						{
							if (velocity.Y >= 0f && (double)velocity.Y <= 0.8)
							{
								if (velocity.X == 0f)
								{
									frameCounter++;
								}
								else
								{
									frameCounter += 3;
								}
							}
							else
							{
								frameCounter += 5;
							}
							if (frameCounter >= 20)
							{
								frameCounter -= 20;
								frame++;
							}
							if (frame > 1)
							{
								frame = 0;
							}
							if (wet && Main.player[owner].position.Y + (float)Main.player[owner].height < position.Y + (float)height && localAI[0] == 0f)
							{
								if (velocity.Y > -4f)
								{
									velocity.Y -= 0.2f;
								}
								if (velocity.Y > 0f)
								{
									velocity.Y *= 0.95f;
								}
							}
							else
							{
								velocity.Y += 0.4f;
							}
							if (velocity.Y > 10f)
							{
								velocity.Y = 10f;
							}
						}
						else if (type == 334)
						{
							if (velocity.Y == 0f)
							{
								if (velocity.X == 0f)
								{
									if (frame > 0)
									{
										frameCounter += 2;
										if (frameCounter > 6)
										{
											frame++;
											frameCounter = 0;
										}
										if (frame >= 7)
										{
											frame = 0;
										}
									}
									else
									{
										frame = 0;
										frameCounter = 0;
									}
								}
								else if ((double)velocity.X < -0.8 || (double)velocity.X > 0.8)
								{
									frameCounter += (int)Math.Abs((double)velocity.X * 0.75);
									frameCounter++;
									if (frameCounter > 6)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame >= 7 || frame < 1)
									{
										frame = 1;
									}
								}
								else if (frame > 0)
								{
									frameCounter += 2;
									if (frameCounter > 6)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame >= 7)
									{
										frame = 0;
									}
								}
								else
								{
									frame = 0;
									frameCounter = 0;
								}
							}
							else if (velocity.Y < 0f)
							{
								frameCounter = 0;
								frame = 2;
							}
							else if (velocity.Y > 0f)
							{
								frameCounter = 0;
								frame = 4;
							}
							velocity.Y += 0.4f;
							if (velocity.Y > 10f)
							{
								velocity.Y = 10f;
							}
						}
						else if (type == 353)
						{
							if (velocity.Y == 0f)
							{
								if (velocity.X == 0f)
								{
									frame = 0;
									frameCounter = 0;
								}
								else if ((double)velocity.X < -0.8 || (double)velocity.X > 0.8)
								{
									frameCounter += (int)Math.Abs(velocity.X);
									frameCounter++;
									if (frameCounter > 6)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame > 9)
									{
										frame = 2;
									}
								}
								else
								{
									frame = 0;
									frameCounter = 0;
								}
							}
							else if (velocity.Y < 0f)
							{
								frameCounter = 0;
								frame = 1;
							}
							else if (velocity.Y > 0f)
							{
								frameCounter = 0;
								frame = 1;
							}
							velocity.Y += 0.4f;
							if (velocity.Y > 10f)
							{
								velocity.Y = 10f;
							}
						}
						else if (type == 111)
						{
							if (velocity.Y == 0f)
							{
								if (velocity.X == 0f)
								{
									frame = 0;
									frameCounter = 0;
								}
								else if ((double)velocity.X < -0.8 || (double)velocity.X > 0.8)
								{
									frameCounter += (int)Math.Abs(velocity.X);
									frameCounter++;
									if (frameCounter > 6)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame >= 7)
									{
										frame = 0;
									}
								}
								else
								{
									frame = 0;
									frameCounter = 0;
								}
							}
							else if (velocity.Y < 0f)
							{
								frameCounter = 0;
								frame = 4;
							}
							else if (velocity.Y > 0f)
							{
								frameCounter = 0;
								frame = 6;
							}
							velocity.Y += 0.4f;
							if (velocity.Y > 10f)
							{
								velocity.Y = 10f;
							}
						}
						else if (type == 112)
						{
							if (velocity.Y == 0f)
							{
								if (velocity.X == 0f)
								{
									frame = 0;
									frameCounter = 0;
								}
								else if ((double)velocity.X < -0.8 || (double)velocity.X > 0.8)
								{
									frameCounter += (int)Math.Abs(velocity.X);
									frameCounter++;
									if (frameCounter > 6)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame >= 3)
									{
										frame = 0;
									}
								}
								else
								{
									frame = 0;
									frameCounter = 0;
								}
							}
							else if (velocity.Y < 0f)
							{
								frameCounter = 0;
								frame = 2;
							}
							else if (velocity.Y > 0f)
							{
								frameCounter = 0;
								frame = 2;
							}
							velocity.Y += 0.4f;
							if (velocity.Y > 10f)
							{
								velocity.Y = 10f;
							}
						}
						else if (type == 127)
						{
							if (velocity.Y == 0f)
							{
								if (velocity.X == 0f)
								{
									frame = 0;
									frameCounter = 0;
								}
								else if ((double)velocity.X < -0.1 || (double)velocity.X > 0.1)
								{
									frameCounter += (int)Math.Abs(velocity.X);
									frameCounter++;
									if (frameCounter > 6)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame > 5)
									{
										frame = 0;
									}
								}
								else
								{
									frame = 0;
									frameCounter = 0;
								}
							}
							else
							{
								frame = 0;
								frameCounter = 0;
							}
							velocity.Y += 0.4f;
							if (velocity.Y > 10f)
							{
								velocity.Y = 10f;
							}
						}
						else if (type == 200)
						{
							if (velocity.Y == 0f)
							{
								if (velocity.X == 0f)
								{
									frame = 0;
									frameCounter = 0;
								}
								else if ((double)velocity.X < -0.1 || (double)velocity.X > 0.1)
								{
									frameCounter += (int)Math.Abs(velocity.X);
									frameCounter++;
									if (frameCounter > 6)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame > 5)
									{
										frame = 0;
									}
								}
								else
								{
									frame = 0;
									frameCounter = 0;
								}
							}
							else
							{
								rotation = velocity.X * 0.1f;
								frameCounter++;
								if (velocity.Y < 0f)
								{
									frameCounter += 2;
								}
								if (frameCounter > 6)
								{
									frame++;
									frameCounter = 0;
								}
								if (frame > 9)
								{
									frame = 6;
								}
								if (frame < 6)
								{
									frame = 6;
								}
							}
							velocity.Y += 0.1f;
							if (velocity.Y > 4f)
							{
								velocity.Y = 4f;
							}
						}
						else if (type == 208)
						{
							if (velocity.Y == 0f && velocity.X == 0f)
							{
								if (Main.player[owner].position.X + (float)(Main.player[owner].width / 2) < position.X + (float)(width / 2))
								{
									direction = -1;
								}
								else if (Main.player[owner].position.X + (float)(Main.player[owner].width / 2) > position.X + (float)(width / 2))
								{
									direction = 1;
								}
								rotation = 0f;
								frame = 0;
							}
							else
							{
								rotation = velocity.X * 0.075f;
								frameCounter++;
								if (frameCounter > 6)
								{
									frame++;
									frameCounter = 0;
								}
								if (frame > 4)
								{
									frame = 1;
								}
								if (frame < 1)
								{
									frame = 1;
								}
							}
							velocity.Y += 0.1f;
							if (velocity.Y > 4f)
							{
								velocity.Y = 4f;
							}
						}
						else if (type == 209)
						{
							if (alpha > 0)
							{
								alpha -= 5;
								if (alpha < 0)
								{
									alpha = 0;
								}
							}
							if (velocity.Y == 0f)
							{
								if (velocity.X == 0f)
								{
									frame = 0;
									frameCounter = 0;
								}
								else if ((double)velocity.X < -0.1 || (double)velocity.X > 0.1)
								{
									frameCounter += (int)Math.Abs(velocity.X);
									frameCounter++;
									if (frameCounter > 6)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame > 11)
									{
										frame = 2;
									}
									if (frame < 2)
									{
										frame = 2;
									}
								}
								else
								{
									frame = 0;
									frameCounter = 0;
								}
							}
							else
							{
								frame = 1;
								frameCounter = 0;
								rotation = 0f;
							}
							velocity.Y += 0.4f;
							if (velocity.Y > 10f)
							{
								velocity.Y = 10f;
							}
						}
						else if (type == 324)
						{
							if (velocity.Y == 0f)
							{
								if ((double)velocity.X < -0.1 || (double)velocity.X > 0.1)
								{
									frameCounter += (int)Math.Abs(velocity.X);
									frameCounter++;
									if (frameCounter > 6)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame > 5)
									{
										frame = 2;
									}
									if (frame < 2)
									{
										frame = 2;
									}
								}
								else
								{
									frame = 0;
									frameCounter = 0;
								}
							}
							else
							{
								frameCounter = 0;
								frame = 1;
							}
							velocity.Y += 0.4f;
							if (velocity.Y > 14f)
							{
								velocity.Y = 14f;
							}
						}
						else if (type == 210)
						{
							if (velocity.Y == 0f)
							{
								if ((double)velocity.X < -0.1 || (double)velocity.X > 0.1)
								{
									frameCounter += (int)Math.Abs(velocity.X);
									frameCounter++;
									if (frameCounter > 6)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame > 6)
									{
										frame = 0;
									}
								}
								else
								{
									frame = 0;
									frameCounter = 0;
								}
							}
							else
							{
								rotation = velocity.X * 0.05f;
								frameCounter++;
								if (frameCounter > 6)
								{
									frame++;
									frameCounter = 0;
								}
								if (frame > 11)
								{
									frame = 7;
								}
								if (frame < 7)
								{
									frame = 7;
								}
							}
							velocity.Y += 0.4f;
							if (velocity.Y > 10f)
							{
								velocity.Y = 10f;
							}
						}
						else if (type == 398)
						{
							if (velocity.Y == 0f)
							{
								if (velocity.X == 0f)
								{
									frame = 0;
									frameCounter = 0;
								}
								else if ((double)velocity.X < -0.8 || (double)velocity.X > 0.8)
								{
									frameCounter += (int)Math.Abs(velocity.X);
									frameCounter++;
									if (frameCounter > 6)
									{
										frame++;
										frameCounter = 0;
									}
									if (frame >= 5)
									{
										frame = 0;
									}
								}
								else
								{
									frame = 0;
									frameCounter = 0;
								}
							}
							else if (velocity.Y != 0f)
							{
								frameCounter = 0;
								frame = 5;
							}
							velocity.Y += 0.4f;
							if (velocity.Y > 10f)
							{
								velocity.Y = 10f;
							}
						}
					}
				}
			}
			else if (aiStyle == 27)
			{
				if (type == 115)
				{
					ai[0] += 1f;
					if (ai[0] < 30f)
					{
						velocity *= 1.125f;
					}
				}
				if (type == 115 && localAI[1] < 5f)
				{
					localAI[1] = 5f;
					for (int num441 = 5; num441 < 25; num441++)
					{
						float num442 = velocity.X * (30f / (float)num441);
						float num443 = velocity.Y * (30f / (float)num441);
						num442 *= 80f;
						num443 *= 80f;
						int num444 = Dust.NewDust(new Vector2(position.X - num442, position.Y - num443), 8, 8, 27, lastVelocity.X, lastVelocity.Y, 100, default(Color), 0.9f);
						Main.dust[num444].velocity *= 0.25f;
						Main.dust[num444].velocity -= velocity * 5f;
					}
				}
				if (localAI[1] > 7f && type == 173)
				{
					int num445;
					switch (Main.rand.Next(3))
					{
					case 0:
						num445 = 15;
						break;
					case 1:
						num445 = 57;
						break;
					default:
						num445 = 58;
						break;
					}
					int num446 = Dust.NewDust(new Vector2(position.X - velocity.X * 4f + 2f, position.Y + 2f - velocity.Y * 4f), 8, 8, num445, 0f, 0f, 100, default(Color), 1.25f);
					Main.dust[num446].velocity *= 0.1f;
				}
				if (localAI[1] > 7f && type == 132)
				{
					int num447 = Dust.NewDust(new Vector2(position.X - velocity.X * 4f + 2f, position.Y + 2f - velocity.Y * 4f), 8, 8, 107, lastVelocity.X, lastVelocity.Y, 100, default(Color), 1.25f);
					Main.dust[num447].velocity *= -0.25f;
					num447 = Dust.NewDust(new Vector2(position.X - velocity.X * 4f + 2f, position.Y + 2f - velocity.Y * 4f), 8, 8, 107, lastVelocity.X, lastVelocity.Y, 100, default(Color), 1.25f);
					Main.dust[num447].velocity *= -0.25f;
					Main.dust[num447].position -= velocity * 0.5f;
				}
				if (localAI[1] < 15f)
				{
					localAI[1] += 1f;
				}
				else
				{
					if (type == 114 || type == 115)
					{
						int num448 = Dust.NewDust(new Vector2(position.X, position.Y + 4f), 8, 8, 27, lastVelocity.X, lastVelocity.Y, 100, default(Color), 0.6f);
						Main.dust[num448].velocity *= -0.25f;
					}
					else if (type == 116)
					{
						int num449 = Dust.NewDust(new Vector2(position.X - velocity.X * 5f + 2f, position.Y + 2f - velocity.Y * 5f), 8, 8, 64, lastVelocity.X, lastVelocity.Y, 100, default(Color), 1.5f);
						Main.dust[num449].velocity *= -0.25f;
						Main.dust[num449].noGravity = true;
					}
					if (localAI[0] == 0f)
					{
						scale -= 0.02f;
						alpha += 30;
						if (alpha >= 250)
						{
							alpha = 255;
							localAI[0] = 1f;
						}
					}
					else if (localAI[0] == 1f)
					{
						scale += 0.02f;
						alpha -= 30;
						if (alpha <= 0)
						{
							alpha = 0;
							localAI[0] = 0f;
						}
					}
				}
				if (ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 8);
				}
				if (type == 157)
				{
					rotation += (float)direction * 0.4f;
					spriteDirection = direction;
				}
				else
				{
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 0.785f;
				}
				if (velocity.Y > 16f)
				{
					velocity.Y = 16f;
				}
			}
			else if (aiStyle == 28)
			{
				if (type == 177)
				{
					for (int num450 = 0; num450 < 3; num450++)
					{
						int num451 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 137, velocity.X, velocity.Y, Main.rand.Next(0, 101), default(Color), 1f + (float)Main.rand.Next(-20, 40) * 0.01f);
						Main.dust[num451].noGravity = true;
						Main.dust[num451].velocity *= 0.3f;
					}
				}
				if (type == 118)
				{
					for (int num452 = 0; num452 < 2; num452++)
					{
						int num453 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 92, velocity.X, velocity.Y, 50, default(Color), 1.2f);
						Main.dust[num453].noGravity = true;
						Main.dust[num453].velocity *= 0.3f;
					}
				}
				if (type == 119 || type == 128 || type == 359)
				{
					for (int num454 = 0; num454 < 3; num454++)
					{
						int num455 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 92, velocity.X, velocity.Y, 50, default(Color), 1.2f);
						Main.dust[num455].noGravity = true;
						Main.dust[num455].velocity *= 0.3f;
					}
				}
				if (type == 309)
				{
					for (int num456 = 0; num456 < 3; num456++)
					{
						int num457 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 185, velocity.X, velocity.Y, 50, default(Color), 1.2f);
						Main.dust[num457].noGravity = true;
						Main.dust[num457].velocity *= 0.3f;
					}
				}
				if (type == 129)
				{
					for (int num458 = 0; num458 < 6; num458++)
					{
						int num459 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 106, velocity.X, velocity.Y, 100);
						Main.dust[num459].noGravity = true;
						Main.dust[num459].velocity *= 0.1f + (float)Main.rand.Next(4) * 0.1f;
						Main.dust[num459].scale *= 1f + (float)Main.rand.Next(5) * 0.1f;
					}
				}
				if (ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 28);
				}
			}
			else if (aiStyle == 29)
			{
				int num460 = type - 121 + 86;
				for (int num461 = 0; num461 < 2; num461++)
				{
					int num462 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, num460, velocity.X, velocity.Y, 50, default(Color), 1.2f);
					Main.dust[num462].noGravity = true;
					Main.dust[num462].velocity *= 0.3f;
				}
				if (ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 8);
				}
			}
			else if (aiStyle == 30)
			{
				velocity *= 0.8f;
				rotation += 0.2f;
				alpha += 4;
				if (alpha >= 255)
				{
					Kill();
				}
			}
			else if (aiStyle == 31)
			{
				int num463 = 110;
				int num464 = 0;
				if (type == 146)
				{
					num463 = 111;
					num464 = 2;
				}
				if (type == 147)
				{
					num463 = 112;
					num464 = 1;
				}
				if (type == 148)
				{
					num463 = 113;
					num464 = 3;
				}
				if (type == 149)
				{
					num463 = 114;
					num464 = 4;
				}
				if (owner == Main.myPlayer)
				{
					WorldGen.Convert((int)(position.X + (float)(width / 2)) / 16, (int)(position.Y + (float)(height / 2)) / 16, num464, 2);
				}
				if (timeLeft > 133)
				{
					timeLeft = 133;
				}
				if (ai[0] > 7f)
				{
					float num465 = 1f;
					if (ai[0] == 8f)
					{
						num465 = 0.2f;
					}
					else if (ai[0] == 9f)
					{
						num465 = 0.4f;
					}
					else if (ai[0] == 10f)
					{
						num465 = 0.6f;
					}
					else if (ai[0] == 11f)
					{
						num465 = 0.8f;
					}
					ai[0] += 1f;
					for (int num466 = 0; num466 < 1; num466++)
					{
						int num467 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, num463, velocity.X * 0.2f, velocity.Y * 0.2f, 100);
						Main.dust[num467].noGravity = true;
						Main.dust[num467].scale *= 1.75f;
						Main.dust[num467].velocity.X *= 2f;
						Main.dust[num467].velocity.Y *= 2f;
						Main.dust[num467].scale *= num465;
					}
				}
				else
				{
					ai[0] += 1f;
				}
				rotation += 0.3f * (float)direction;
			}
			else if (aiStyle == 32)
			{
				timeLeft = 10;
				ai[0] += 1f;
				if (ai[0] >= 20f)
				{
					ai[0] = 15f;
					for (int num468 = 0; num468 < 255; num468++)
					{
						Rectangle rectangle3 = new Rectangle((int)position.X, (int)position.Y, width, height);
						if (!Main.player[num468].active)
						{
							continue;
						}
						Rectangle value3 = new Rectangle((int)Main.player[num468].position.X, (int)Main.player[num468].position.Y, Main.player[num468].width, Main.player[num468].height);
						if (rectangle3.Intersects(value3))
						{
							ai[0] = 0f;
							velocity.Y = -4.5f;
							if (velocity.X > 2f)
							{
								velocity.X = 2f;
							}
							if (velocity.X < -2f)
							{
								velocity.X = -2f;
							}
							velocity.X = (velocity.X + (float)Main.player[num468].direction * 1.75f) / 2f;
							velocity.X += Main.player[num468].velocity.X * 3f;
							velocity.Y += Main.player[num468].velocity.Y;
							if (velocity.X > 6f)
							{
								velocity.X = 6f;
							}
							if (velocity.X < -6f)
							{
								velocity.X = -6f;
							}
							netUpdate = true;
							ai[1] += 1f;
						}
					}
				}
				if (velocity.X == 0f && velocity.Y == 0f)
				{
					Kill();
				}
				rotation += 0.02f * velocity.X;
				if (velocity.Y == 0f)
				{
					velocity.X *= 0.98f;
				}
				else if (wet)
				{
					velocity.X *= 0.99f;
				}
				else
				{
					velocity.X *= 0.995f;
				}
				if ((double)velocity.X > -0.03 && (double)velocity.X < 0.03)
				{
					velocity.X = 0f;
				}
				if (wet)
				{
					ai[1] = 0f;
					if (velocity.Y > 0f)
					{
						velocity.Y *= 0.95f;
					}
					velocity.Y -= 0.1f;
					if (velocity.Y < -4f)
					{
						velocity.Y = -4f;
					}
					if (velocity.X == 0f)
					{
						Kill();
					}
				}
				else
				{
					velocity.Y += 0.1f;
				}
				if (velocity.Y > 10f)
				{
					velocity.Y = 10f;
				}
			}
			else if (aiStyle == 33)
			{
				if (alpha > 0)
				{
					alpha -= 50;
					if (alpha < 0)
					{
						alpha = 0;
					}
				}
				float num469 = 4f;
				float num470 = ai[0];
				float num471 = ai[1];
				if (num470 == 0f && num471 == 0f)
				{
					num470 = 1f;
				}
				float num472 = (float)Math.Sqrt(num470 * num470 + num471 * num471);
				num472 = num469 / num472;
				num470 *= num472;
				num471 *= num472;
				if (alpha < 70)
				{
					int num473 = 127;
					if (type == 310)
					{
						num473 = 187;
					}
					int num474 = Dust.NewDust(new Vector2(position.X, position.Y - 2f), 6, 6, num473, velocity.X, velocity.Y, 100, default(Color), 1.6f);
					Main.dust[num474].noGravity = true;
					Main.dust[num474].position.X -= num470 * 1f;
					Main.dust[num474].position.Y -= num471 * 1f;
					Main.dust[num474].velocity.X -= num470;
					Main.dust[num474].velocity.Y -= num471;
				}
				if (localAI[0] == 0f)
				{
					ai[0] = velocity.X;
					ai[1] = velocity.Y;
					localAI[1] += 1f;
					if (localAI[1] >= 30f)
					{
						velocity.Y += 0.09f;
						localAI[1] = 30f;
					}
				}
				else
				{
					if (!Collision.SolidCollision(position, width, height))
					{
						localAI[0] = 0f;
						localAI[1] = 30f;
					}
					damage = 0;
				}
				if (velocity.Y > 16f)
				{
					velocity.Y = 16f;
				}
				rotation = (float)Math.Atan2(ai[1], ai[0]) + 1.57f;
			}
			else if (aiStyle == 34)
			{
				if (type >= 415 && type <= 418)
				{
					ai[0] += 1f;
					if (ai[0] > 4f)
					{
						int num475 = Dust.NewDust(new Vector2(position.X + 2f, position.Y + 20f), 8, 8, 6, velocity.X, velocity.Y, 100, default(Color), 1.2f);
						Main.dust[num475].noGravity = true;
						Main.dust[num475].velocity *= 0.2f;
					}
				}
				else
				{
					int num476 = Dust.NewDust(new Vector2(position.X + 2f, position.Y + 20f), 8, 8, 6, velocity.X, velocity.Y, 100, default(Color), 1.2f);
					Main.dust[num476].noGravity = true;
					Main.dust[num476].velocity *= 0.2f;
				}
			}
			else if (aiStyle == 35)
			{
				ai[0] += 1f;
				if (ai[0] > 30f)
				{
					velocity.Y += 0.2f;
					velocity.X *= 0.985f;
					if (velocity.Y > 14f)
					{
						velocity.Y = 14f;
					}
				}
				rotation += (Math.Abs(velocity.X) + Math.Abs(velocity.Y)) * (float)direction * 0.02f;
				if (owner == Main.myPlayer)
				{
					Vector2 vector38 = Collision.TileCollision(position, velocity, width, height, true, true);
					bool flag16 = false;
					if (vector38 != velocity)
					{
						flag16 = true;
					}
					else
					{
						int num477 = (int)(center().X + velocity.X) / 16;
						int num478 = (int)(center().Y + velocity.Y) / 16;
						if (Main.tile[num477, num478] != null && Main.tile[num477, num478].active() && Main.tile[num477, num478].bottomSlope())
						{
							flag16 = true;
							position.Y = num478 * 16 + 16 + 8;
							position.X = num477 * 16 + 8;
						}
					}
					if (flag16)
					{
						int num479 = (int)(position.X + (float)(width / 2)) / 16;
						int num480 = (int)(position.Y + (float)(height / 2)) / 16;
						position += vector38;
						int num481 = 10;
						if (Main.tile[num479, num480] != null)
						{
							for (; Main.tile[num479, num480] != null && Main.tile[num479, num480].active() && Main.tileRope[Main.tile[num479, num480].type]; num480++)
							{
							}
							while (num481 > 0)
							{
								num481--;
								if (Main.tile[num479, num480] == null)
								{
									break;
								}
								if (Main.tile[num479, num480].active() && (Main.tileCut[Main.tile[num479, num480].type] || Main.tile[num479, num480].type == 165))
								{
									WorldGen.KillTile(num479, num480);
									NetMessage.SendData(17, -1, -1, "", 0, num479, num480);
								}
								if (!Main.tile[num479, num480].active())
								{
									WorldGen.PlaceTile(num479, num480, 213);
									NetMessage.SendData(17, -1, -1, "", 1, num479, num480, 213f);
									ai[1] += 1f;
								}
								else
								{
									num481 = 0;
								}
								num480++;
							}
							Kill();
						}
					}
				}
			}
			else if (aiStyle == 36)
			{
				if (type != 307 && wet && !honeyWet)
				{
					Kill();
				}
				if (alpha > 0)
				{
					alpha -= 50;
				}
				else
				{
					maxUpdates = 0;
				}
				if (alpha < 0)
				{
					alpha = 0;
				}
				if (type == 307)
				{
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 1.57f;
					frameCounter++;
					if (frameCounter >= 6)
					{
						frame++;
						frameCounter = 0;
					}
					if (frame >= 2)
					{
						frame = 0;
					}
					for (int num482 = 0; num482 < 3; num482++)
					{
						float num483 = velocity.X / 3f * (float)num482;
						float num484 = velocity.Y / 3f * (float)num482;
						int num485 = Dust.NewDust(position, width, height, 184);
						Main.dust[num485].position.X = center().X - num483;
						Main.dust[num485].position.Y = center().Y - num484;
						Main.dust[num485].velocity *= 0f;
						Main.dust[num485].scale = 0.5f;
					}
				}
				else
				{
					if (type == 316)
					{
						if (velocity.X > 0f)
						{
							spriteDirection = -1;
						}
						else if (velocity.X < 0f)
						{
							spriteDirection = 1;
						}
					}
					else if (velocity.X > 0f)
					{
						spriteDirection = 1;
					}
					else if (velocity.X < 0f)
					{
						spriteDirection = -1;
					}
					rotation = velocity.X * 0.1f;
					frameCounter++;
					if (frameCounter >= 3)
					{
						frame++;
						frameCounter = 0;
					}
					if (frame >= 3)
					{
						frame = 0;
					}
				}
				float num486 = position.X;
				float num487 = position.Y;
				float num488 = 100000f;
				bool flag17 = false;
				ai[0] += 1f;
				if (ai[0] > 30f)
				{
					ai[0] = 30f;
					for (int num489 = 0; num489 < 200; num489++)
					{
						if (Main.npc[num489].active && !Main.npc[num489].dontTakeDamage && !Main.npc[num489].friendly && Main.npc[num489].lifeMax > 5 && (!Main.npc[num489].wet || type == 307))
						{
							float num490 = Main.npc[num489].position.X + (float)(Main.npc[num489].width / 2);
							float num491 = Main.npc[num489].position.Y + (float)(Main.npc[num489].height / 2);
							float num492 = Math.Abs(position.X + (float)(width / 2) - num490) + Math.Abs(position.Y + (float)(height / 2) - num491);
							if (num492 < 800f && num492 < num488 && Collision.CanHit(position, width, height, Main.npc[num489].position, Main.npc[num489].width, Main.npc[num489].height))
							{
								num488 = num492;
								num486 = num490;
								num487 = num491;
								flag17 = true;
							}
						}
					}
				}
				if (!flag17)
				{
					num486 = position.X + (float)(width / 2) + velocity.X * 100f;
					num487 = position.Y + (float)(height / 2) + velocity.Y * 100f;
				}
				else if (type == 307)
				{
					friendly = true;
				}
				float num493 = 6f;
				float num494 = 0.1f;
				if (type == 189)
				{
					num493 = 7f;
					num494 = 0.15f;
				}
				if (type == 307)
				{
					num493 = 9f;
					num494 = 0.2f;
				}
				if (type == 316)
				{
					num493 = 10f;
					num494 = 0.25f;
				}
				Vector2 vector39 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
				float num495 = num486 - vector39.X;
				float num496 = num487 - vector39.Y;
				float num497 = (float)Math.Sqrt(num495 * num495 + num496 * num496);
				num497 = num493 / num497;
				num495 *= num497;
				num496 *= num497;
				if (velocity.X < num495)
				{
					velocity.X += num494;
					if (velocity.X < 0f && num495 > 0f)
					{
						velocity.X += num494 * 2f;
					}
				}
				else if (velocity.X > num495)
				{
					velocity.X -= num494;
					if (velocity.X > 0f && num495 < 0f)
					{
						velocity.X -= num494 * 2f;
					}
				}
				if (velocity.Y < num496)
				{
					velocity.Y += num494;
					if (velocity.Y < 0f && num496 > 0f)
					{
						velocity.Y += num494 * 2f;
					}
				}
				else if (velocity.Y > num496)
				{
					velocity.Y -= num494;
					if (velocity.Y > 0f && num496 < 0f)
					{
						velocity.Y -= num494 * 2f;
					}
				}
			}
			else if (aiStyle == 37)
			{
				if (ai[1] == 0f)
				{
					ai[1] = position.Y - 5f;
				}
				if (ai[0] == 0f)
				{
					if (Collision.SolidCollision(position, width, height))
					{
						velocity.Y *= -1f;
						ai[0] += 1f;
					}
					else
					{
						float num498 = position.Y - ai[1];
						if (num498 > 300f)
						{
							velocity.Y *= -1f;
							ai[0] += 1f;
						}
					}
				}
				else if (Collision.SolidCollision(position, width, height) || position.Y < ai[1])
				{
					Kill();
				}
			}
			else if (aiStyle == 38)
			{
				ai[0] += 1f;
				if (ai[0] >= 6f)
				{
					ai[0] = 0f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 34);
					if (Main.myPlayer == owner)
					{
						NewProjectile(position.X, position.Y, velocity.X, velocity.Y, 188, damage, knockBack, owner);
					}
				}
			}
			else if (aiStyle == 39)
			{
				alpha -= 50;
				if (alpha < 0)
				{
					alpha = 0;
				}
				if (Main.player[owner].dead)
				{
					Kill();
					return;
				}
				if (alpha == 0)
				{
					Main.player[owner].itemAnimation = 5;
					Main.player[owner].itemTime = 5;
					if (position.X + (float)(width / 2) > Main.player[owner].position.X + (float)(Main.player[owner].width / 2))
					{
						Main.player[owner].ChangeDir(1);
					}
					else
					{
						Main.player[owner].ChangeDir(-1);
					}
				}
				Vector2 vector40 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
				float num499 = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - vector40.X;
				float num500 = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - vector40.Y;
				float num501 = (float)Math.Sqrt(num499 * num499 + num500 * num500);
				if (!Main.player[owner].channel && alpha == 0)
				{
					ai[0] = 1f;
					ai[1] = -1f;
				}
				if (ai[1] > 0f && num501 > 1500f)
				{
					ai[1] = 0f;
					ai[0] = 1f;
				}
				if (ai[1] > 0f)
				{
					tileCollide = false;
					int num502 = (int)ai[1] - 1;
					if (Main.npc[num502].active && Main.npc[num502].life > 0)
					{
						float num503 = 16f;
						vector40 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
						num499 = Main.npc[num502].position.X + (float)(Main.npc[num502].width / 2) - vector40.X;
						num500 = Main.npc[num502].position.Y + (float)(Main.npc[num502].height / 2) - vector40.Y;
						num501 = (float)Math.Sqrt(num499 * num499 + num500 * num500);
						if (num501 < num503)
						{
							velocity.X = num499;
							velocity.Y = num500;
							if (num501 > num503 / 2f)
							{
								if (velocity.X < 0f)
								{
									spriteDirection = -1;
									rotation = (float)Math.Atan2(0f - velocity.Y, 0f - velocity.X);
								}
								else
								{
									spriteDirection = 1;
									rotation = (float)Math.Atan2(velocity.Y, velocity.X);
								}
							}
						}
						else
						{
							num501 = num503 / num501;
							num499 *= num501;
							num500 *= num501;
							velocity.X = num499;
							velocity.Y = num500;
							if (velocity.X < 0f)
							{
								spriteDirection = -1;
								rotation = (float)Math.Atan2(0f - velocity.Y, 0f - velocity.X);
							}
							else
							{
								spriteDirection = 1;
								rotation = (float)Math.Atan2(velocity.Y, velocity.X);
							}
						}
						ai[0] = 1f;
					}
					else
					{
						ai[1] = 0f;
						float num504 = position.X;
						float num505 = position.Y;
						float num506 = 3000f;
						int num507 = -1;
						for (int num508 = 0; num508 < 200; num508++)
						{
							if (Main.npc[num508].active && !Main.npc[num508].friendly && Main.npc[num508].lifeMax > 5 && !Main.npc[num508].dontTakeDamage)
							{
								float num509 = Main.npc[num508].position.X + (float)(Main.npc[num508].width / 2);
								float num510 = Main.npc[num508].position.Y + (float)(Main.npc[num508].height / 2);
								float num511 = Math.Abs(position.X + (float)(width / 2) - num509) + Math.Abs(position.Y + (float)(height / 2) - num510);
								if (num511 < num506 && Collision.CanHit(position, width, height, Main.npc[num508].position, Main.npc[num508].width, Main.npc[num508].height))
								{
									num506 = num511;
									num504 = num509;
									num505 = num510;
									num507 = num508;
								}
							}
						}
						if (num507 >= 0)
						{
							float num512 = 16f;
							vector40 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
							num499 = num504 - vector40.X;
							num500 = num505 - vector40.Y;
							num501 = (float)Math.Sqrt(num499 * num499 + num500 * num500);
							num501 = num512 / num501;
							num499 *= num501;
							num500 *= num501;
							velocity.X = num499;
							velocity.Y = num500;
							ai[0] = 0f;
							ai[1] = num507 + 1;
						}
					}
				}
				else if (ai[0] == 0f)
				{
					if (num501 > 700f)
					{
						ai[0] = 1f;
					}
					if (velocity.X < 0f)
					{
						spriteDirection = -1;
						rotation = (float)Math.Atan2(0f - velocity.Y, 0f - velocity.X);
					}
					else
					{
						spriteDirection = 1;
						rotation = (float)Math.Atan2(velocity.Y, velocity.X);
					}
				}
				else if (ai[0] == 1f)
				{
					tileCollide = false;
					if (velocity.X < 0f)
					{
						spriteDirection = 1;
						rotation = (float)Math.Atan2(0f - velocity.Y, 0f - velocity.X);
					}
					else
					{
						spriteDirection = -1;
						rotation = (float)Math.Atan2(velocity.Y, velocity.X);
					}
					if (velocity.X < 0f)
					{
						spriteDirection = -1;
						rotation = (float)Math.Atan2(0f - velocity.Y, 0f - velocity.X);
					}
					else
					{
						spriteDirection = 1;
						rotation = (float)Math.Atan2(velocity.Y, velocity.X);
					}
					float num513 = 20f;
					if (num501 < 70f)
					{
						Kill();
					}
					num501 = num513 / num501;
					num499 *= num501;
					num500 *= num501;
					velocity.X = num499;
					velocity.Y = num500;
				}
				frameCounter++;
				if (frameCounter >= 4)
				{
					frame++;
					frameCounter = 0;
				}
				if (frame >= 4)
				{
					frame = 0;
				}
			}
			else if (aiStyle == 40)
			{
				localAI[0] += 1f;
				if (localAI[0] > 3f)
				{
					localAI[0] = 100f;
					alpha -= 50;
					if (alpha < 0)
					{
						alpha = 0;
					}
				}
				frameCounter++;
				if (frameCounter >= 3)
				{
					frame++;
					frameCounter = 0;
				}
				if (frame >= 5)
				{
					frame = 0;
				}
				velocity.X += ai[0];
				velocity.Y += ai[1];
				localAI[1] += 1f;
				if (localAI[1] == 50f)
				{
					localAI[1] = 51f;
					ai[0] = (float)Main.rand.Next(-100, 101) * 6E-05f;
					ai[1] = (float)Main.rand.Next(-100, 101) * 6E-05f;
				}
				if (Math.Abs(velocity.X) + Math.Abs(velocity.Y) > 16f)
				{
					velocity.X *= 0.95f;
					velocity.Y *= 0.95f;
				}
				if (Math.Abs(velocity.X) + Math.Abs(velocity.Y) < 12f)
				{
					velocity.X *= 1.05f;
					velocity.Y *= 1.05f;
				}
				rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 3.14f;
			}
			else if (aiStyle == 41)
			{
				if (localAI[0] == 0f)
				{
					localAI[0] = 1f;
					frame = Main.rand.Next(3);
				}
				rotation += velocity.X * 0.01f;
			}
			else if (aiStyle == 42)
			{
				if (!Main.player[owner].crystalLeaf)
				{
					Kill();
					return;
				}
				position.X = Main.player[owner].center().X - (float)(width / 2);
				position.Y = Main.player[owner].center().Y - (float)(height / 2) + Main.player[owner].gfxOffY - 60f;
				if (Main.player[owner].gravDir == -1f)
				{
					position.Y += 120f;
					rotation = 3.14f;
				}
				else
				{
					rotation = 0f;
				}
				position.X = (int)position.X;
				position.Y = (int)position.Y;
				float num514 = (float)(int)Main.mouseTextColor / 200f - 0.35f;
				num514 *= 0.2f;
				scale = num514 + 0.95f;
				if (owner == Main.myPlayer)
				{
					if (ai[0] == 0f)
					{
						float num515 = position.X;
						float num516 = position.Y;
						float num517 = 700f;
						bool flag18 = false;
						for (int num518 = 0; num518 < 200; num518++)
						{
							if (Main.npc[num518].active && !Main.npc[num518].friendly && Main.npc[num518].lifeMax > 5)
							{
								float num519 = Main.npc[num518].position.X + (float)(Main.npc[num518].width / 2);
								float num520 = Main.npc[num518].position.Y + (float)(Main.npc[num518].height / 2);
								float num521 = Math.Abs(position.X + (float)(width / 2) - num519) + Math.Abs(position.Y + (float)(height / 2) - num520);
								if (num521 < num517 && Collision.CanHit(position, width, height, Main.npc[num518].position, Main.npc[num518].width, Main.npc[num518].height))
								{
									num517 = num521;
									num515 = num519;
									num516 = num520;
									flag18 = true;
								}
							}
						}
						if (flag18)
						{
							float num522 = 12f;
							Vector2 vector41 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
							float num523 = num515 - vector41.X;
							float num524 = num516 - vector41.Y;
							float num525 = (float)Math.Sqrt(num523 * num523 + num524 * num524);
							num525 = num522 / num525;
							num523 *= num525;
							num524 *= num525;
							NewProjectile(center().X - 4f, center().Y, num523, num524, 227, 50, 5f, owner);
							ai[0] = 50f;
						}
					}
					else
					{
						ai[0] -= 1f;
					}
				}
			}
			else if (aiStyle == 43)
			{
				if (localAI[1] == 0f)
				{
					Main.PlaySound(6, (int)position.X, (int)position.Y);
					localAI[1] += 1f;
					for (int num526 = 0; num526 < 5; num526++)
					{
						int num527 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 157);
						Main.dust[num527].noGravity = true;
						Main.dust[num527].velocity *= 3f;
						Main.dust[num527].scale = 1.5f;
					}
				}
				ai[0] = (float)Main.rand.Next(-100, 101) * 0.0025f;
				ai[1] = (float)Main.rand.Next(-100, 101) * 0.0025f;
				if (localAI[0] == 0f)
				{
					scale += 0.05f;
					if ((double)scale > 1.2)
					{
						localAI[0] = 1f;
					}
				}
				else
				{
					scale -= 0.05f;
					if ((double)scale < 0.8)
					{
						localAI[0] = 0f;
					}
				}
				rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 3.14f;
				int num528 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 157);
				Main.dust[num528].noGravity = true;
				Main.dust[num528].velocity *= 0.1f;
				Main.dust[num528].scale = 1.5f;
			}
			else if (aiStyle == 44)
			{
				if (type == 228)
				{
					velocity *= 0.96f;
					alpha += 4;
					if (alpha > 255)
					{
						Kill();
					}
				}
				else if (type == 229)
				{
					if (ai[0] == 0f)
					{
						Main.PlaySound(2, (int)position.X, (int)position.Y, 8);
					}
					ai[0] += 1f;
					if (ai[0] > 20f)
					{
						velocity.Y += 0.3f;
						velocity.X *= 0.98f;
					}
				}
				frameCounter++;
				if (frameCounter > 5)
				{
					frame++;
					frameCounter = 0;
				}
				if (frame >= Main.projFrames[type])
				{
					frame = 0;
				}
			}
			else if (aiStyle == 45)
			{
				if (type == 237 || type == 243)
				{
					float num529 = ai[0];
					float num530 = ai[1];
					if (num529 != 0f && num530 != 0f)
					{
						bool flag19 = false;
						bool flag20 = false;
						if ((velocity.X < 0f && center().X < num529) || (velocity.X > 0f && center().X > num529))
						{
							flag19 = true;
						}
						if ((velocity.Y < 0f && center().Y < num530) || (velocity.Y > 0f && center().Y > num530))
						{
							flag20 = true;
						}
						if (flag19 && flag20)
						{
							Kill();
						}
					}
					rotation += velocity.X * 0.02f;
					frameCounter++;
					if (frameCounter > 4)
					{
						frameCounter = 0;
						frame++;
						if (frame > 3)
						{
							frame = 0;
						}
					}
				}
				else if (type == 238 || type == 244)
				{
					frameCounter++;
					if (frameCounter > 8)
					{
						frameCounter = 0;
						frame++;
						if (frame > 5)
						{
							frame = 0;
						}
					}
					ai[1] += 1f;
					if (type == 244 && ai[1] >= 1800f)
					{
						alpha += 5;
						if (alpha > 255)
						{
							alpha = 255;
							Kill();
						}
					}
					else if (type == 238 && ai[1] >= 3600f)
					{
						alpha += 5;
						if (alpha > 255)
						{
							alpha = 255;
							Kill();
						}
					}
					else
					{
						ai[0] += 1f;
						if (type == 244)
						{
							if (ai[0] > 10f)
							{
								ai[0] = 0f;
								if (owner == Main.myPlayer)
								{
									int num531 = (int)(position.X + 14f + (float)Main.rand.Next(width - 28));
									int num532 = (int)(position.Y + (float)height + 4f);
									NewProjectile(num531, num532, 0f, 5f, 245, damage, 0f, owner);
								}
							}
						}
						else if (ai[0] > 8f)
						{
							ai[0] = 0f;
							if (owner == Main.myPlayer)
							{
								int num533 = (int)(position.X + 14f + (float)Main.rand.Next(width - 28));
								int num534 = (int)(position.Y + (float)height + 4f);
								NewProjectile(num533, num534, 0f, 5f, 239, damage, 0f, owner);
							}
						}
					}
					localAI[0] += 1f;
					if (localAI[0] >= 10f)
					{
						localAI[0] = 0f;
						int num535 = 0;
						int num536 = 0;
						float num537 = 0f;
						int num538 = type;
						for (int num539 = 0; num539 < 1000; num539++)
						{
							if (Main.projectile[num539].active && Main.projectile[num539].owner == owner && Main.projectile[num539].type == num538 && Main.projectile[num539].ai[1] < 3600f)
							{
								num535++;
								if (Main.projectile[num539].ai[1] > num537)
								{
									num536 = num539;
									num537 = Main.projectile[num539].ai[1];
								}
							}
						}
						if (type == 244)
						{
							if (num535 > 1)
							{
								Main.projectile[num536].netUpdate = true;
								Main.projectile[num536].ai[1] = 36000f;
							}
						}
						else if (num535 > 2)
						{
							Main.projectile[num536].netUpdate = true;
							Main.projectile[num536].ai[1] = 36000f;
						}
					}
				}
				else if (type == 239)
				{
					alpha = 50;
				}
				else if (type == 245)
				{
					alpha = 100;
				}
				else if (type == 264)
				{
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
				}
			}
			else if (aiStyle == 46)
			{
				int num540 = 600;
				if (type == 250)
				{
					if (owner == Main.myPlayer)
					{
						localAI[0] += 1f;
						if (localAI[0] > 4f)
						{
							localAI[0] = 3f;
							NewProjectile(center().X, center().Y, velocity.X * 0.001f, velocity.Y * 0.001f, 251, damage, knockBack, owner);
						}
						if (timeLeft > num540)
						{
							timeLeft = num540;
						}
					}
					float num541 = 1f;
					if (velocity.Y < 0f)
					{
						num541 -= velocity.Y / 3f;
					}
					ai[0] += num541;
					if (ai[0] > 30f)
					{
						velocity.Y += 0.5f;
						if (velocity.Y > 0f)
						{
							velocity.X *= 0.95f;
						}
						else
						{
							velocity.X *= 1.05f;
						}
					}
					float x3 = velocity.X;
					float y3 = velocity.Y;
					float num542 = (float)Math.Sqrt(x3 * x3 + y3 * y3);
					num542 = 15.95f * scale / num542;
					x3 *= num542;
					y3 *= num542;
					velocity.X = x3;
					velocity.Y = y3;
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 1.57f;
				}
				else
				{
					if (localAI[0] == 0f)
					{
						if (velocity.X > 0f)
						{
							spriteDirection = -1;
							rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 1.57f;
						}
						else
						{
							spriteDirection = 1;
							rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 1.57f;
						}
						localAI[0] = 1f;
						timeLeft = num540;
					}
					velocity.X *= 0.98f;
					velocity.Y *= 0.98f;
					if (rotation == 0f)
					{
						alpha = 255;
					}
					else if (timeLeft < 10)
					{
						alpha = 255 - (int)(255f * (float)timeLeft / 10f);
					}
					else if (timeLeft > num540 - 10)
					{
						int num543 = num540 - timeLeft;
						alpha = 255 - (int)(255f * (float)num543 / 10f);
					}
					else
					{
						alpha = 0;
					}
				}
			}
			else if (aiStyle == 47)
			{
				if (ai[0] == 0f)
				{
					ai[0] = velocity.X;
					ai[1] = velocity.Y;
				}
				if (velocity.X > 0f)
				{
					rotation += (Math.Abs(velocity.Y) + Math.Abs(velocity.X)) * 0.001f;
				}
				else
				{
					rotation -= (Math.Abs(velocity.Y) + Math.Abs(velocity.X)) * 0.001f;
				}
				frameCounter++;
				if (frameCounter > 6)
				{
					frameCounter = 0;
					frame++;
					if (frame > 4)
					{
						frame = 0;
					}
				}
				if (Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y) > 2.0)
				{
					velocity *= 0.98f;
				}
				for (int num544 = 0; num544 < 1000; num544++)
				{
					if (num544 != whoAmI && Main.projectile[num544].active && Main.projectile[num544].owner == owner && Main.projectile[num544].type == type && timeLeft > Main.projectile[num544].timeLeft && Main.projectile[num544].timeLeft > 30)
					{
						Main.projectile[num544].timeLeft = 30;
					}
				}
				int[] array = new int[20];
				int num545 = 0;
				float num546 = 300f;
				bool flag21 = false;
				float num547 = 0f;
				float num548 = 0f;
				for (int num549 = 0; num549 < 200; num549++)
				{
					if (!Main.npc[num549].active || Main.npc[num549].dontTakeDamage || Main.npc[num549].friendly || Main.npc[num549].lifeMax <= 5)
					{
						continue;
					}
					float num550 = Main.npc[num549].position.X + (float)(Main.npc[num549].width / 2);
					float num551 = Main.npc[num549].position.Y + (float)(Main.npc[num549].height / 2);
					float num552 = Math.Abs(position.X + (float)(width / 2) - num550) + Math.Abs(position.Y + (float)(height / 2) - num551);
					if (num552 < num546 && Collision.CanHit(center(), 1, 1, Main.npc[num549].center(), 1, 1))
					{
						if (num545 < 20)
						{
							array[num545] = num549;
							num545++;
							num547 = num550;
							num548 = num551;
						}
						flag21 = true;
					}
				}
				if (timeLeft < 30)
				{
					flag21 = false;
				}
				if (flag21)
				{
					int num553 = Main.rand.Next(num545);
					num553 = array[num553];
					num547 = Main.npc[num553].position.X + (float)(Main.npc[num553].width / 2);
					num548 = Main.npc[num553].position.Y + (float)(Main.npc[num553].height / 2);
					localAI[0] += 1f;
					if (localAI[0] > 8f)
					{
						localAI[0] = 0f;
						float num554 = 6f;
						Vector2 vector42 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
						vector42 += velocity * 4f;
						float num555 = num547 - vector42.X;
						float num556 = num548 - vector42.Y;
						float num557 = (float)Math.Sqrt(num555 * num555 + num556 * num556);
						num557 = num554 / num557;
						num555 *= num557;
						num556 *= num557;
						NewProjectile(vector42.X, vector42.Y, num555, num556, 255, damage, knockBack, owner);
					}
				}
			}
			else if (aiStyle == 48)
			{
				if (type == 255)
				{
					for (int num558 = 0; num558 < 4; num558++)
					{
						Vector2 vector43 = position;
						vector43 -= velocity * ((float)num558 * 0.25f);
						alpha = 255;
						int num559 = Dust.NewDust(vector43, 1, 1, 160);
						Main.dust[num559].position = vector43;
						Main.dust[num559].position.X += width / 2;
						Main.dust[num559].position.Y += height / 2;
						Main.dust[num559].scale = (float)Main.rand.Next(70, 110) * 0.013f;
						Main.dust[num559].velocity *= 0.2f;
					}
				}
				else if (type == 290)
				{
					if (localAI[0] == 0f)
					{
						Main.PlaySound(2, (int)position.X, (int)position.Y, 8);
					}
					localAI[0] += 1f;
					if (localAI[0] > 3f)
					{
						for (int num560 = 0; num560 < 3; num560++)
						{
							Vector2 vector44 = position;
							vector44 -= velocity * ((float)num560 * 0.3334f);
							alpha = 255;
							int num561 = Dust.NewDust(vector44, 1, 1, 173);
							Main.dust[num561].position = vector44;
							Main.dust[num561].scale = (float)Main.rand.Next(70, 110) * 0.013f;
							Main.dust[num561].velocity *= 0.2f;
						}
					}
				}
				else if (type == 294)
				{
					localAI[0] += 1f;
					if (localAI[0] > 9f)
					{
						for (int num562 = 0; num562 < 4; num562++)
						{
							Vector2 vector45 = position;
							vector45 -= velocity * ((float)num562 * 0.25f);
							alpha = 255;
							int num563 = Dust.NewDust(vector45, 1, 1, 173);
							Main.dust[num563].position = vector45;
							Main.dust[num563].scale = (float)Main.rand.Next(70, 110) * 0.013f;
							Main.dust[num563].velocity *= 0.2f;
						}
					}
				}
				else
				{
					localAI[0] += 1f;
					if (localAI[0] > 3f)
					{
						for (int num564 = 0; num564 < 4; num564++)
						{
							Vector2 vector46 = position;
							vector46 -= velocity * ((float)num564 * 0.25f);
							alpha = 255;
							int num565 = Dust.NewDust(vector46, 1, 1, 162);
							Main.dust[num565].position = vector46;
							Main.dust[num565].position.X += width / 2;
							Main.dust[num565].position.Y += height / 2;
							Main.dust[num565].scale = (float)Main.rand.Next(70, 110) * 0.013f;
							Main.dust[num565].velocity *= 0.2f;
						}
					}
				}
			}
			else if (aiStyle == 49)
			{
				if (ai[1] == 0f)
				{
					ai[1] = 1f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
				}
				if (ai[1] == 1f)
				{
					if (velocity.X > 0f)
					{
						direction = 1;
					}
					else if (velocity.X < 0f)
					{
						direction = -1;
					}
					spriteDirection = direction;
					ai[0] += 1f;
					rotation += velocity.X * 0.05f + (float)direction * 0.05f;
					if (ai[0] >= 18f)
					{
						velocity.Y += 0.28f;
						velocity.X *= 0.99f;
					}
					if ((double)velocity.Y > 15.9)
					{
						velocity.Y = 15.9f;
					}
					if (ai[0] > 2f)
					{
						alpha = 0;
						if (ai[0] == 3f)
						{
							for (int num566 = 0; num566 < 10; num566++)
							{
								int num567 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.5f);
								Main.dust[num567].velocity *= 0.5f;
								Main.dust[num567].velocity += velocity * 0.1f;
							}
							for (int num568 = 0; num568 < 5; num568++)
							{
								int num569 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2f);
								Main.dust[num569].noGravity = true;
								Main.dust[num569].velocity *= 3f;
								Main.dust[num569].velocity += velocity * 0.2f;
								num569 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100);
								Main.dust[num569].velocity *= 2f;
								Main.dust[num569].velocity += velocity * 0.3f;
							}
							for (int num570 = 0; num570 < 1; num570++)
							{
								int num571 = Gore.NewGore(new Vector2(position.X - 10f, position.Y - 10f), default(Vector2), Main.rand.Next(61, 64));
								Main.gore[num571].position += velocity * 1.25f;
								Main.gore[num571].scale = 1.5f;
								Main.gore[num571].velocity += velocity * 0.5f;
								Main.gore[num571].velocity *= 0.02f;
							}
						}
					}
				}
				else if (ai[1] == 2f)
				{
					rotation = 0f;
					velocity.X *= 0.95f;
					velocity.Y += 0.2f;
				}
			}
			else if (aiStyle == 50)
			{
				if (type == 291)
				{
					if (localAI[0] == 0f)
					{
						Main.PlaySound(2, (int)position.X, (int)position.Y, 20);
						localAI[0] += 1f;
					}
					bool flag22 = false;
					bool flag23 = false;
					if (velocity.X < 0f && position.X < ai[0])
					{
						flag22 = true;
					}
					if (velocity.X > 0f && position.X > ai[0])
					{
						flag22 = true;
					}
					if (velocity.Y < 0f && position.Y < ai[1])
					{
						flag23 = true;
					}
					if (velocity.Y > 0f && position.Y > ai[1])
					{
						flag23 = true;
					}
					if (flag22 && flag23)
					{
						Kill();
					}
					for (int num572 = 0; num572 < 10; num572++)
					{
						int num573 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 174, 0f, 0f, 100, default(Color), 1.2f);
						Main.dust[num573].noGravity = true;
						Main.dust[num573].velocity *= 0.5f;
						Main.dust[num573].velocity += velocity * 0.1f;
					}
				}
				else if (type == 295)
				{
					for (int num574 = 0; num574 < 8; num574++)
					{
						int num575 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 174, 0f, 0f, 100, default(Color), 1.2f);
						Main.dust[num575].noGravity = true;
						Main.dust[num575].velocity *= 0.5f;
						Main.dust[num575].velocity += velocity * 0.1f;
					}
				}
				else
				{
					if (localAI[0] == 0f)
					{
						Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
						localAI[0] += 1f;
					}
					ai[0] += 1f;
					if (type == 296)
					{
						ai[0] += 3f;
					}
					float num576 = 25f;
					if (ai[0] > 180f)
					{
						num576 -= (ai[0] - 180f) / 2f;
					}
					if (num576 <= 0f)
					{
						num576 = 0f;
						Kill();
					}
					if (type == 296)
					{
						num576 *= 0.7f;
					}
					for (int num577 = 0; (float)num577 < num576; num577++)
					{
						float num578 = Main.rand.Next(-10, 11);
						float num579 = Main.rand.Next(-10, 11);
						float num580 = Main.rand.Next(3, 9);
						float num581 = (float)Math.Sqrt(num578 * num578 + num579 * num579);
						num581 = num580 / num581;
						num578 *= num581;
						num579 *= num581;
						int num582 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 174, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num582].noGravity = true;
						Main.dust[num582].position.X = center().X;
						Main.dust[num582].position.Y = center().Y;
						Main.dust[num582].position.X += Main.rand.Next(-10, 11);
						Main.dust[num582].position.Y += Main.rand.Next(-10, 11);
						Main.dust[num582].velocity.X = num578;
						Main.dust[num582].velocity.Y = num579;
					}
				}
			}
			else if (aiStyle == 51)
			{
				if (type == 297)
				{
					localAI[0] += 1f;
					if (localAI[0] > 4f)
					{
						for (int num583 = 0; num583 < 5; num583++)
						{
							int num584 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 175, 0f, 0f, 100, default(Color), 2f);
							Main.dust[num584].noGravity = true;
							Main.dust[num584].velocity *= 0f;
						}
					}
				}
				else
				{
					if (localAI[0] == 0f)
					{
						Main.PlaySound(2, (int)position.X, (int)position.Y, 8);
						localAI[0] += 1f;
					}
					for (int num585 = 0; num585 < 9; num585++)
					{
						int num586 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 175, 0f, 0f, 100, default(Color), 1.3f);
						Main.dust[num586].noGravity = true;
						Main.dust[num586].velocity *= 0f;
					}
				}
				float num587 = center().X;
				float num588 = center().Y;
				float num589 = 400f;
				bool flag24 = false;
				if (type == 297)
				{
					for (int num590 = 0; num590 < 200; num590++)
					{
						if (Main.npc[num590].active && !Main.npc[num590].dontTakeDamage && !Main.npc[num590].friendly && Main.npc[num590].lifeMax > 5 && Collision.CanHit(center(), 1, 1, Main.npc[num590].center(), 1, 1))
						{
							float num591 = Main.npc[num590].position.X + (float)(Main.npc[num590].width / 2);
							float num592 = Main.npc[num590].position.Y + (float)(Main.npc[num590].height / 2);
							float num593 = Math.Abs(position.X + (float)(width / 2) - num591) + Math.Abs(position.Y + (float)(height / 2) - num592);
							if (num593 < num589)
							{
								num589 = num593;
								num587 = num591;
								num588 = num592;
								flag24 = true;
							}
						}
					}
				}
				else
				{
					num589 = 200f;
					for (int num594 = 0; num594 < 255; num594++)
					{
						if (Main.player[num594].active && !Main.player[num594].dead)
						{
							float num595 = Main.player[num594].position.X + (float)(Main.player[num594].width / 2);
							float num596 = Main.player[num594].position.Y + (float)(Main.player[num594].height / 2);
							float num597 = Math.Abs(position.X + (float)(width / 2) - num595) + Math.Abs(position.Y + (float)(height / 2) - num596);
							if (num597 < num589)
							{
								num589 = num597;
								num587 = num595;
								num588 = num596;
								flag24 = true;
							}
						}
					}
				}
				if (flag24)
				{
					float num598 = 3f;
					if (type == 297)
					{
						num598 = 6f;
					}
					Vector2 vector47 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
					float num599 = num587 - vector47.X;
					float num600 = num588 - vector47.Y;
					float num601 = (float)Math.Sqrt(num599 * num599 + num600 * num600);
					num601 = num598 / num601;
					num599 *= num601;
					num600 *= num601;
					if (type == 297)
					{
						velocity.X = (velocity.X * 20f + num599) / 21f;
						velocity.Y = (velocity.Y * 20f + num600) / 21f;
					}
					else
					{
						velocity.X = (velocity.X * 100f + num599) / 101f;
						velocity.Y = (velocity.Y * 100f + num600) / 101f;
					}
				}
			}
			else if (aiStyle == 52)
			{
				int num602 = (int)ai[0];
				float num603 = 4f;
				Vector2 vector48 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
				float num604 = Main.player[num602].center().X - vector48.X;
				float num605 = Main.player[num602].center().Y - vector48.Y;
				float num606 = (float)Math.Sqrt(num604 * num604 + num605 * num605);
				if (num606 < 50f && position.X < Main.player[num602].position.X + (float)Main.player[num602].width && position.X + (float)width > Main.player[num602].position.X && position.Y < Main.player[num602].position.Y + (float)Main.player[num602].height && position.Y + (float)height > Main.player[num602].position.Y)
				{
					if (owner == Main.myPlayer)
					{
						int num607 = (int)ai[1];
						Main.player[num602].HealEffect(num607, false);
						Main.player[num602].statLife += num607;
						if (Main.player[num602].statLife > Main.player[num602].statLifeMax2)
						{
							Main.player[num602].statLife = Main.player[num602].statLifeMax2;
						}
						NetMessage.SendData(66, -1, -1, "", num602, num607);
					}
					Kill();
				}
				num606 = num603 / num606;
				num604 *= num606;
				num605 *= num606;
				velocity.X = (velocity.X * 15f + num604) / 16f;
				velocity.Y = (velocity.Y * 15f + num605) / 16f;
				if (type == 305)
				{
					for (int num608 = 0; num608 < 3; num608++)
					{
						float num609 = velocity.X * 0.334f * (float)num608;
						float num610 = (0f - velocity.Y * 0.334f) * (float)num608;
						int num611 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 183, 0f, 0f, 100, default(Color), 1.1f);
						Main.dust[num611].noGravity = true;
						Main.dust[num611].velocity *= 0f;
						Main.dust[num611].position.X -= num609;
						Main.dust[num611].position.Y -= num610;
					}
				}
				else
				{
					for (int num612 = 0; num612 < 5; num612++)
					{
						float num613 = velocity.X * 0.2f * (float)num612;
						float num614 = (0f - velocity.Y * 0.2f) * (float)num612;
						int num615 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 175, 0f, 0f, 100, default(Color), 1.3f);
						Main.dust[num615].noGravity = true;
						Main.dust[num615].velocity *= 0f;
						Main.dust[num615].position.X -= num613;
						Main.dust[num615].position.Y -= num614;
					}
				}
			}
			else if (aiStyle == 53)
			{
				if (localAI[0] == 0f)
				{
					localAI[1] = 1f;
					localAI[0] = 1f;
					ai[0] = 120f;
					int num616 = 80;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 46);
					if (type == 308)
					{
						for (int num617 = 0; num617 < num616; num617++)
						{
							int num618 = Dust.NewDust(new Vector2(position.X, position.Y + 16f), width, height - 16, 185);
							Main.dust[num618].velocity *= 2f;
							Main.dust[num618].noGravity = true;
							Main.dust[num618].scale *= 1.15f;
						}
					}
					if (type == 377)
					{
						frame = 4;
						num616 = 40;
						for (int num619 = 0; num619 < num616; num619++)
						{
							int num620 = Dust.NewDust(position + Vector2.UnitY * 16f, width, height - 16, 171, 0f, 0f, 100);
							Main.dust[num620].scale = (float)Main.rand.Next(1, 10) * 0.1f;
							Main.dust[num620].noGravity = true;
							Main.dust[num620].fadeIn = 1.5f;
							Main.dust[num620].velocity *= 0.75f;
						}
					}
				}
				velocity.X = 0f;
				velocity.Y += 0.2f;
				if (velocity.Y > 16f)
				{
					velocity.Y = 16f;
				}
				bool flag25 = false;
				float num621 = center().X;
				float num622 = center().Y;
				float num623 = 1000f;
				for (int num624 = 0; num624 < 200; num624++)
				{
					if (Main.npc[num624].active && !Main.npc[num624].dontTakeDamage && !Main.npc[num624].friendly && Main.npc[num624].lifeMax > 5)
					{
						float num625 = Main.npc[num624].position.X + (float)(Main.npc[num624].width / 2);
						float num626 = Main.npc[num624].position.Y + (float)(Main.npc[num624].height / 2);
						float num627 = Math.Abs(position.X + (float)(width / 2) - num625) + Math.Abs(position.Y + (float)(height / 2) - num626);
						if (num627 < num623 && Collision.CanHit(position, width, height, Main.npc[num624].position, Main.npc[num624].width, Main.npc[num624].height))
						{
							num623 = num627;
							num621 = num625;
							num622 = num626;
							flag25 = true;
						}
					}
				}
				if (flag25)
				{
					float num628 = num621;
					float num629 = num622;
					num621 -= center().X;
					num622 -= center().Y;
					int num630 = 0;
					if (num621 < 0f)
					{
						spriteDirection = -1;
					}
					else
					{
						spriteDirection = 1;
					}
					num630 = ((!(num622 > 0f)) ? ((Math.Abs(num622) > Math.Abs(num621) * 3f) ? 4 : ((Math.Abs(num622) > Math.Abs(num621) * 2f) ? 3 : ((!(Math.Abs(num621) > Math.Abs(num622) * 3f)) ? ((Math.Abs(num621) > Math.Abs(num622) * 2f) ? 1 : 2) : 0))) : 0);
					if (type == 308)
					{
						frame = num630 * 2;
					}
					else if (type == 377)
					{
						frame = num630;
					}
					if (ai[0] > 40f && localAI[1] == 0f && type == 308)
					{
						frame++;
					}
					if (ai[0] <= 0f)
					{
						localAI[1] = 0f;
						ai[0] = 60f;
						if (Main.myPlayer == owner)
						{
							float num631 = 6f;
							int num632 = 309;
							if (type == 377)
							{
								num632 = 378;
								num631 = 9f;
							}
							Vector2 vector49 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
							switch (num630)
							{
							case 0:
								vector49.Y += 12f;
								vector49.X += 24 * spriteDirection;
								break;
							case 1:
								vector49.Y += 0f;
								vector49.X += 24 * spriteDirection;
								break;
							case 2:
								vector49.Y -= 2f;
								vector49.X += 24 * spriteDirection;
								break;
							case 3:
								vector49.Y -= 6f;
								vector49.X += 14 * spriteDirection;
								break;
							case 4:
								vector49.Y -= 14f;
								vector49.X += 2 * spriteDirection;
								break;
							}
							if (spriteDirection < 0)
							{
								vector49.X += 10f;
							}
							float num633 = num628 - vector49.X;
							float num634 = num629 - vector49.Y;
							float num635 = (float)Math.Sqrt(num633 * num633 + num634 * num634);
							num635 = num631 / num635;
							num633 *= num635;
							num634 *= num635;
							int num636 = damage;
							NewProjectile(vector49.X, vector49.Y, num633, num634, num632, num636, knockBack, Main.myPlayer);
						}
					}
				}
				else if (ai[0] <= 60f && (frame == 1 || frame == 3 || frame == 5 || frame == 7 || frame == 9))
				{
					frame--;
				}
				if (ai[0] > 0f)
				{
					ai[0] -= 1f;
				}
			}
			else if (aiStyle == 54)
			{
				if (type == 317)
				{
					if (Main.player[Main.myPlayer].dead)
					{
						Main.player[Main.myPlayer].raven = false;
					}
					if (Main.player[Main.myPlayer].raven)
					{
						timeLeft = 2;
					}
				}
				for (int num637 = 0; num637 < 1000; num637++)
				{
					if (num637 != whoAmI && Main.projectile[num637].active && Main.projectile[num637].owner == owner && Main.projectile[num637].type == type && Math.Abs(position.X - Main.projectile[num637].position.X) + Math.Abs(position.Y - Main.projectile[num637].position.Y) < (float)width)
					{
						if (position.X < Main.projectile[num637].position.X)
						{
							velocity.X -= 0.05f;
						}
						else
						{
							velocity.X += 0.05f;
						}
						if (position.Y < Main.projectile[num637].position.Y)
						{
							velocity.Y -= 0.05f;
						}
						else
						{
							velocity.Y += 0.05f;
						}
					}
				}
				float num638 = position.X;
				float num639 = position.Y;
				float num640 = 800f;
				bool flag26 = false;
				int num641 = 500;
				if (ai[1] != 0f || friendly)
				{
					num641 = 1400;
				}
				if (Math.Abs(center().X - Main.player[owner].center().X) + Math.Abs(center().Y - Main.player[owner].center().Y) > (float)num641)
				{
					ai[0] = 1f;
				}
				if (ai[0] == 0f)
				{
					tileCollide = true;
					for (int num642 = 0; num642 < 200; num642++)
					{
						if (Main.npc[num642].active && !Main.npc[num642].dontTakeDamage && !Main.npc[num642].friendly && Main.npc[num642].lifeMax > 5)
						{
							float num643 = Main.npc[num642].position.X + (float)(Main.npc[num642].width / 2);
							float num644 = Main.npc[num642].position.Y + (float)(Main.npc[num642].height / 2);
							float num645 = Math.Abs(position.X + (float)(width / 2) - num643) + Math.Abs(position.Y + (float)(height / 2) - num644);
							if (num645 < num640 && Collision.CanHit(position, width, height, Main.npc[num642].position, Main.npc[num642].width, Main.npc[num642].height))
							{
								num640 = num645;
								num638 = num643;
								num639 = num644;
								flag26 = true;
							}
						}
					}
				}
				else
				{
					tileCollide = false;
				}
				if (!flag26)
				{
					friendly = true;
					float num646 = 8f;
					if (ai[0] == 1f)
					{
						num646 = 12f;
					}
					Vector2 vector50 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
					float num647 = Main.player[owner].center().X - vector50.X;
					float num648 = Main.player[owner].center().Y - vector50.Y - 60f;
					float num649 = (float)Math.Sqrt(num647 * num647 + num648 * num648);
					if (num649 < 100f && ai[0] == 1f && !Collision.SolidCollision(position, width, height))
					{
						ai[0] = 0f;
					}
					if (num649 > 2000f)
					{
						position.X = Main.player[owner].center().X - (float)(width / 2);
						position.Y = Main.player[owner].center().Y - (float)(width / 2);
					}
					if (num649 > 70f)
					{
						num649 = num646 / num649;
						num647 *= num649;
						num648 *= num649;
						velocity.X = (velocity.X * 20f + num647) / 21f;
						velocity.Y = (velocity.Y * 20f + num648) / 21f;
					}
					else
					{
						if (velocity.X == 0f && velocity.Y == 0f)
						{
							velocity.X = -0.15f;
							velocity.Y = -0.05f;
						}
						velocity *= 1.01f;
					}
					friendly = false;
					rotation = velocity.X * 0.05f;
					frameCounter++;
					if (frameCounter >= 4)
					{
						frameCounter = 0;
						frame++;
					}
					if (frame > 3)
					{
						frame = 0;
					}
					if ((double)Math.Abs(velocity.X) > 0.2)
					{
						spriteDirection = -direction;
					}
				}
				else
				{
					if (ai[1] == -1f)
					{
						ai[1] = 17f;
					}
					if (ai[1] > 0f)
					{
						ai[1] -= 1f;
					}
					if (ai[1] == 0f)
					{
						friendly = true;
						float num650 = 8f;
						Vector2 vector51 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
						float num651 = num638 - vector51.X;
						float num652 = num639 - vector51.Y;
						float num653 = (float)Math.Sqrt(num651 * num651 + num652 * num652);
						if (num653 < 100f)
						{
							num650 = 10f;
						}
						num653 = num650 / num653;
						num651 *= num653;
						num652 *= num653;
						velocity.X = (velocity.X * 14f + num651) / 15f;
						velocity.Y = (velocity.Y * 14f + num652) / 15f;
					}
					else
					{
						friendly = false;
						if (Math.Abs(velocity.X) + Math.Abs(velocity.Y) < 10f)
						{
							velocity *= 1.05f;
						}
					}
					rotation = velocity.X * 0.05f;
					frameCounter++;
					if (frameCounter >= 4)
					{
						frameCounter = 0;
						frame++;
					}
					if (frame < 4)
					{
						frame = 4;
					}
					if (frame > 7)
					{
						frame = 4;
					}
					if ((double)Math.Abs(velocity.X) > 0.2)
					{
						spriteDirection = -direction;
					}
				}
			}
			else if (aiStyle == 55)
			{
				frameCounter++;
				if (frameCounter > 0)
				{
					frame++;
					frameCounter = 0;
					if (frame > 2)
					{
						frame = 0;
					}
				}
				if (velocity.X < 0f)
				{
					spriteDirection = -1;
					rotation = (float)Math.Atan2(0f - velocity.Y, 0f - velocity.X);
				}
				else
				{
					spriteDirection = 1;
					rotation = (float)Math.Atan2(velocity.Y, velocity.X);
				}
				if (ai[0] >= 0f && ai[0] < 200f)
				{
					int num654 = (int)ai[0];
					if (Main.npc[num654].active)
					{
						float num655 = 8f;
						Vector2 vector52 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
						float num656 = Main.npc[num654].position.X - vector52.X;
						float num657 = Main.npc[num654].position.Y - vector52.Y;
						float num658 = (float)Math.Sqrt(num656 * num656 + num657 * num657);
						num658 = num655 / num658;
						num656 *= num658;
						num657 *= num658;
						velocity.X = (velocity.X * 14f + num656) / 15f;
						velocity.Y = (velocity.Y * 14f + num657) / 15f;
					}
					else
					{
						float num659 = 1000f;
						for (int num660 = 0; num660 < 200; num660++)
						{
							if (Main.npc[num660].active && !Main.npc[num660].dontTakeDamage && !Main.npc[num660].friendly && Main.npc[num660].lifeMax > 5)
							{
								float num661 = Main.npc[num660].position.X + (float)(Main.npc[num660].width / 2);
								float num662 = Main.npc[num660].position.Y + (float)(Main.npc[num660].height / 2);
								float num663 = Math.Abs(position.X + (float)(width / 2) - num661) + Math.Abs(position.Y + (float)(height / 2) - num662);
								if (num663 < num659 && Collision.CanHit(position, width, height, Main.npc[num660].position, Main.npc[num660].width, Main.npc[num660].height))
								{
									num659 = num663;
									ai[0] = num660;
								}
							}
						}
					}
					int num664 = 8;
					int num665 = Dust.NewDust(new Vector2(position.X + (float)num664, position.Y + (float)num664), width - num664 * 2, height - num664 * 2, 6);
					Main.dust[num665].velocity *= 0.5f;
					Main.dust[num665].velocity += velocity * 0.5f;
					Main.dust[num665].noGravity = true;
					Main.dust[num665].noLight = true;
					Main.dust[num665].scale = 1.4f;
				}
				else
				{
					Kill();
				}
			}
			else if (aiStyle == 56)
			{
				if (localAI[0] == 0f)
				{
					localAI[0] = 1f;
					rotation = ai[0];
					spriteDirection = -(int)ai[1];
				}
				if (Math.Abs(velocity.X) + Math.Abs(velocity.Y) < 16f)
				{
					velocity *= 1.05f;
				}
				if (velocity.X < 0f)
				{
					direction = -1;
				}
				else
				{
					direction = 1;
				}
				rotation += (Math.Abs(velocity.X) + Math.Abs(velocity.Y)) * 0.025f * (float)direction;
			}
			else if (aiStyle == 57)
			{
				ai[0] += 1f;
				if (ai[0] > 30f)
				{
					ai[0] = 30f;
					velocity.Y += 0.25f;
					if (velocity.Y > 16f)
					{
						velocity.Y = 16f;
					}
					velocity.X *= 0.995f;
				}
				rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
				alpha -= 50;
				if (alpha < 0)
				{
					alpha = 0;
				}
				if (owner == Main.myPlayer)
				{
					localAI[0] += 1f;
					if (localAI[0] >= 4f)
					{
						localAI[0] = 0f;
						int num666 = 0;
						for (int num667 = 0; num667 < 1000; num667++)
						{
							if (Main.projectile[num667].active && Main.projectile[num667].owner == owner && Main.projectile[num667].type == 344)
							{
								num666++;
							}
						}
						float num668 = (float)damage * 0.8f;
						float num669 = 1f;
						if (num666 > 100)
						{
							num669 = num666 - 100;
							num669 = 1f - num669 / 100f;
							num668 *= num669;
						}
						if (num666 > 100)
						{
							localAI[0] -= 1f;
						}
						if (num666 > 120)
						{
							localAI[0] -= 1f;
						}
						if (num666 > 140)
						{
							localAI[0] -= 1f;
						}
						if (num666 > 150)
						{
							localAI[0] -= 1f;
						}
						if (num666 > 160)
						{
							localAI[0] -= 1f;
						}
						if (num666 > 165)
						{
							localAI[0] -= 1f;
						}
						if (num666 > 170)
						{
							localAI[0] -= 2f;
						}
						if (num666 > 175)
						{
							localAI[0] -= 3f;
						}
						if (num666 > 180)
						{
							localAI[0] -= 4f;
						}
						if (num666 > 185)
						{
							localAI[0] -= 5f;
						}
						if (num666 > 190)
						{
							localAI[0] -= 6f;
						}
						if (num666 > 195)
						{
							localAI[0] -= 7f;
						}
						if (num668 > (float)damage * 0.1f)
						{
							NewProjectile(center().X, center().Y, 0f, 0f, 344, (int)num668, knockBack * 0.55f, owner, 0f, Main.rand.Next(3));
						}
					}
				}
			}
			else if (aiStyle == 58)
			{
				alpha -= 50;
				if (alpha < 0)
				{
					alpha = 0;
				}
				if (ai[0] == 0f)
				{
					frame = 0;
					ai[1] += 1f;
					if (ai[1] > 30f)
					{
						velocity.Y += 0.1f;
					}
					if (velocity.Y >= 0f)
					{
						ai[0] = 1f;
					}
				}
				if (ai[0] == 1f)
				{
					frame = 1;
					velocity.Y += 0.1f;
					if (velocity.Y > 3f)
					{
						velocity.Y = 3f;
					}
					velocity.X *= 0.99f;
				}
				rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
			}
			else if (aiStyle == 59)
			{
				ai[1] += 1f;
				if (ai[1] >= 60f)
				{
					friendly = true;
					int num670 = (int)ai[0];
					if (!Main.npc[num670].active)
					{
						num670 = -1;
						int[] array2 = new int[200];
						int num671 = 0;
						for (int num672 = 0; num672 < 200; num672++)
						{
							if (Main.npc[num672].active && !Main.npc[num672].friendly && Main.npc[num672].lifeMax > 5 && !Main.npc[num672].dontTakeDamage)
							{
								float num673 = Math.Abs(Main.npc[num672].position.X + (float)(Main.npc[num672].width / 2) - position.X + (float)(width / 2)) + Math.Abs(Main.npc[num672].position.Y + (float)(Main.npc[num672].height / 2) - position.Y + (float)(height / 2));
								if (num673 < 800f)
								{
									array2[num671] = num672;
									num671++;
								}
							}
						}
						if (num671 == 0)
						{
							Kill();
							return;
						}
						num670 = array2[Main.rand.Next(num671)];
						ai[0] = num670;
					}
					float num674 = 4f;
					Vector2 vector53 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
					float num675 = Main.npc[num670].center().X - vector53.X;
					float num676 = Main.npc[num670].center().Y - vector53.Y;
					float num677 = (float)Math.Sqrt(num675 * num675 + num676 * num676);
					num677 = num674 / num677;
					num675 *= num677;
					num676 *= num677;
					int num678 = 30;
					velocity.X = (velocity.X * (float)(num678 - 1) + num675) / (float)num678;
					velocity.Y = (velocity.Y * (float)(num678 - 1) + num676) / (float)num678;
				}
				for (int num679 = 0; num679 < 5; num679++)
				{
					float num680 = velocity.X * 0.2f * (float)num679;
					float num681 = (0f - velocity.Y * 0.2f) * (float)num679;
					int num682 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 175, 0f, 0f, 100, default(Color), 1.3f);
					Main.dust[num682].noGravity = true;
					Main.dust[num682].velocity *= 0f;
					Main.dust[num682].position.X -= num680;
					Main.dust[num682].position.Y -= num681;
				}
			}
			else if (aiStyle == 60)
			{
				scale -= 0.015f;
				if (scale <= 0f)
				{
					velocity *= 5f;
					lastVelocity = velocity;
					Kill();
				}
				if (ai[0] > 3f)
				{
					int num683 = 103;
					if (type == 406)
					{
						num683 = 137;
					}
					if (owner == Main.myPlayer)
					{
						Rectangle rectangle4 = new Rectangle((int)position.X, (int)position.Y, width, height);
						for (int num684 = 0; num684 < 200; num684++)
						{
							if (Main.npc[num684].active && !Main.npc[num684].dontTakeDamage && Main.npc[num684].lifeMax > 1)
							{
								Rectangle value4 = new Rectangle((int)Main.npc[num684].position.X, (int)Main.npc[num684].position.Y, Main.npc[num684].width, Main.npc[num684].height);
								if (rectangle4.Intersects(value4))
								{
									Main.npc[num684].AddBuff(num683, 1500);
									Kill();
								}
							}
						}
						for (int num685 = 0; num685 < 255; num685++)
						{
							if (num685 != owner && Main.player[num685].active && !Main.player[num685].dead)
							{
								Rectangle value5 = new Rectangle((int)Main.player[num685].position.X, (int)Main.player[num685].position.Y, Main.player[num685].width, Main.player[num685].height);
								if (rectangle4.Intersects(value5))
								{
									Main.player[num685].AddBuff(num683, 1500, false);
									Kill();
								}
							}
						}
					}
					ai[0] += ai[1];
					if (ai[0] > 30f)
					{
						velocity.Y += 0.1f;
					}
					if (type == 358)
					{
						for (int num686 = 0; num686 < 1; num686++)
						{
							for (int num687 = 0; num687 < 6; num687++)
							{
								float num688 = velocity.X / 6f * (float)num687;
								float num689 = velocity.Y / 6f * (float)num687;
								int num690 = 6;
								int num691 = Dust.NewDust(new Vector2(position.X + (float)num690, position.Y + (float)num690), width - num690 * 2, height - num690 * 2, 211, 0f, 0f, 75, default(Color), 1.2f);
								if (Main.rand.Next(2) == 0)
								{
									Main.dust[num691].alpha += 25;
								}
								if (Main.rand.Next(2) == 0)
								{
									Main.dust[num691].alpha += 25;
								}
								if (Main.rand.Next(2) == 0)
								{
									Main.dust[num691].alpha += 25;
								}
								Main.dust[num691].noGravity = true;
								Main.dust[num691].velocity *= 0.3f;
								Main.dust[num691].velocity += velocity * 0.5f;
								Main.dust[num691].position = center();
								Main.dust[num691].position.X -= num688;
								Main.dust[num691].position.Y -= num689;
								Main.dust[num691].velocity *= 0.2f;
							}
							if (Main.rand.Next(4) == 0)
							{
								int num692 = 6;
								int num693 = Dust.NewDust(new Vector2(position.X + (float)num692, position.Y + (float)num692), width - num692 * 2, height - num692 * 2, 211, 0f, 0f, 75, default(Color), 0.65f);
								Main.dust[num693].velocity *= 0.5f;
								Main.dust[num693].velocity += velocity * 0.5f;
							}
						}
					}
					if (type == 406)
					{
						int num694 = 175;
						Color newColor = new Color(0, 80, 255, 100);
						for (int num695 = 0; num695 < 6; num695++)
						{
							Vector2 vector54 = velocity * num695 / 6f;
							int num696 = 6;
							int num697 = Dust.NewDust(position + Vector2.One * 6f, width - num696 * 2, height - num696 * 2, 4, 0f, 0f, num694, newColor, 1.2f);
							if (Main.rand.Next(2) == 0)
							{
								Main.dust[num697].alpha += 25;
							}
							if (Main.rand.Next(2) == 0)
							{
								Main.dust[num697].alpha += 25;
							}
							if (Main.rand.Next(2) == 0)
							{
								Main.dust[num697].alpha += 25;
							}
							Main.dust[num697].noGravity = true;
							Main.dust[num697].velocity *= 0.3f;
							Main.dust[num697].velocity += velocity * 0.5f;
							Main.dust[num697].position = center();
							Main.dust[num697].position.X -= vector54.X;
							Main.dust[num697].position.Y -= vector54.Y;
							Main.dust[num697].velocity *= 0.2f;
						}
						if (Main.rand.Next(4) == 0)
						{
							int num698 = 6;
							int num699 = Dust.NewDust(position + Vector2.One * 6f, width - num698 * 2, height - num698 * 2, 4, 0f, 0f, num694, newColor, 1.2f);
							Main.dust[num699].velocity *= 0.5f;
							Main.dust[num699].velocity += velocity * 0.5f;
						}
					}
				}
				else
				{
					ai[0] += 1f;
				}
			}
			else if (aiStyle == 61)
			{
				timeLeft = 60;
				if (Main.player[owner].inventory[Main.player[owner].selectedItem].fishingPole == 0)
				{
					Kill();
				}
				else if (Main.player[owner].inventory[Main.player[owner].selectedItem].shoot != type)
				{
					Kill();
				}
				else if (Main.player[owner].pulley)
				{
					Kill();
				}
				else if (Main.player[owner].mount.Active)
				{
					Kill();
				}
				else if (Main.player[owner].dead)
				{
					Kill();
				}
				if (ai[1] > 0f && localAI[1] >= 0f)
				{
					localAI[1] = -1f;
					if (!lavaWet && !honeyWet)
					{
						for (int num700 = 0; num700 < 100; num700++)
						{
							int num701 = Dust.NewDust(new Vector2(position.X - 6f, position.Y - 10f), width + 12, 24, Dust.dustWater());
							Main.dust[num701].velocity.Y -= 4f;
							Main.dust[num701].velocity.X *= 2.5f;
							Main.dust[num701].scale = 0.8f;
							Main.dust[num701].alpha = 100;
							Main.dust[num701].noGravity = true;
						}
						Main.PlaySound(19, (int)position.X, (int)position.Y, 0);
					}
				}
				if (ai[0] >= 1f)
				{
					if (ai[0] == 2f)
					{
						ai[0] += 1f;
						Main.PlaySound(2, (int)position.X, (int)position.Y, 17);
						if (!lavaWet && !honeyWet)
						{
							for (int num702 = 0; num702 < 100; num702++)
							{
								int num703 = Dust.NewDust(new Vector2(position.X - 6f, position.Y - 10f), width + 12, 24, Dust.dustWater());
								Main.dust[num703].velocity.Y -= 4f;
								Main.dust[num703].velocity.X *= 2.5f;
								Main.dust[num703].scale = 0.8f;
								Main.dust[num703].alpha = 100;
								Main.dust[num703].noGravity = true;
							}
							Main.PlaySound(19, (int)position.X, (int)position.Y, 0);
						}
					}
					if (localAI[0] < 100f)
					{
						localAI[0] += 1f;
					}
					tileCollide = false;
					float num704 = 15.9f;
					int num705 = 10;
					Vector2 vector55 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
					float num706 = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - vector55.X;
					float num707 = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - vector55.Y;
					float num708 = (float)Math.Sqrt(num706 * num706 + num707 * num707);
					if (num708 > 3000f)
					{
						Kill();
					}
					num708 = num704 / num708;
					num706 *= num708;
					num707 *= num708;
					velocity.X = (velocity.X * (float)(num705 - 1) + num706) / (float)num705;
					velocity.Y = (velocity.Y * (float)(num705 - 1) + num707) / (float)num705;
					if (Main.myPlayer == owner)
					{
						Rectangle rectangle5 = new Rectangle((int)position.X, (int)position.Y, width, height);
						Rectangle value6 = new Rectangle((int)Main.player[owner].position.X, (int)Main.player[owner].position.Y, Main.player[owner].width, Main.player[owner].height);
						if (rectangle5.Intersects(value6))
						{
							if (ai[1] > 0f && ai[1] < 2749f)
							{
								int num709 = (int)ai[1];
								Item item = new Item();
								item.SetDefaults(num709);
								Item item2 = Main.player[owner].GetItem(owner, item);
								if (item2.stack > 0)
								{
									int number = Item.NewItem((int)position.X, (int)position.Y, width, height, num709, 1, false, 0, true);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(21, -1, -1, "", number, 1f);
									}
								}
								else
								{
									item.position.X = center().X - (float)(item.width / 2);
									item.position.Y = center().Y - (float)(item.height / 2);
									item.active = true;
									ItemText.NewText(item, 0);
								}
							}
							Kill();
						}
					}
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
				}
				else
				{
					bool flag27 = false;
					Vector2 vector56 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
					float num710 = Main.player[owner].position.X + (float)(Main.player[owner].width / 2) - vector56.X;
					float num711 = Main.player[owner].position.Y + (float)(Main.player[owner].height / 2) - vector56.Y;
					rotation = (float)Math.Atan2(num711, num710) + 1.57f;
					float num712 = (float)Math.Sqrt(num710 * num710 + num711 * num711);
					if (num712 > 900f)
					{
						ai[0] = 1f;
					}
					if (wet)
					{
						rotation = 0f;
						velocity.X *= 0.9f;
						int num713 = (int)(center().X + (float)((width / 2 + 8) * direction)) / 16;
						int num714 = (int)(center().Y / 16f);
						float num854 = position.Y / 16f;
						int num715 = (int)((position.Y + (float)height) / 16f);
						if (Main.tile[num713, num714] == null)
						{
							Main.tile[num713, num714] = new Tile();
						}
						if (Main.tile[num713, num715] == null)
						{
							Main.tile[num713, num715] = new Tile();
						}
						if (velocity.Y > 0f)
						{
							velocity.Y *= 0.5f;
						}
						num713 = (int)(center().X / 16f);
						num714 = (int)(center().Y / 16f);
						float num716 = position.Y + (float)height;
						if (Main.tile[num713, num714 - 1] == null)
						{
							Main.tile[num713, num714 - 1] = new Tile();
						}
						if (Main.tile[num713, num714] == null)
						{
							Main.tile[num713, num714] = new Tile();
						}
						if (Main.tile[num713, num714 + 1] == null)
						{
							Main.tile[num713, num714 + 1] = new Tile();
						}
						if (Main.tile[num713, num714 - 1].liquid > 0)
						{
							num716 = num714 * 16;
							num716 -= (float)(Main.tile[num713, num714 - 1].liquid / 16);
						}
						else if (Main.tile[num713, num714].liquid > 0)
						{
							num716 = (num714 + 1) * 16;
							num716 -= (float)(Main.tile[num713, num714].liquid / 16);
						}
						else if (Main.tile[num713, num714 + 1].liquid > 0)
						{
							num716 = (num714 + 2) * 16;
							num716 -= (float)(Main.tile[num713, num714 + 1].liquid / 16);
						}
						if (center().Y > num716)
						{
							velocity.Y -= 0.1f;
							if (velocity.Y < -8f)
							{
								velocity.Y = -8f;
							}
							if (center().Y + velocity.Y < num716)
							{
								velocity.Y = num716 - center().Y;
							}
						}
						else
						{
							velocity.Y = num716 - center().Y;
						}
						if ((double)velocity.Y >= -0.01 && (double)velocity.Y <= 0.01)
						{
							flag27 = true;
						}
					}
					else
					{
						if (velocity.Y == 0f)
						{
							velocity.X *= 0.95f;
						}
						velocity.X *= 0.98f;
						velocity.Y += 0.2f;
						if (velocity.Y > 15.9f)
						{
							velocity.Y = 15.9f;
						}
					}
					if (ai[1] != 0f)
					{
						flag27 = true;
					}
					if (flag27)
					{
						if (ai[1] == 0f && Main.myPlayer == owner)
						{
							int num717 = Main.player[owner].FishingLevel();
							if (num717 == -9000)
							{
								localAI[1] += 5f;
								localAI[1] += Main.rand.Next(1, 3);
								if (localAI[1] > 660f)
								{
									localAI[1] = 0f;
									FishingCheck();
								}
							}
							else
							{
								if (Main.rand.Next(300) < num717)
								{
									localAI[1] += Main.rand.Next(1, 3);
								}
								localAI[1] += num717 / 30;
								localAI[1] += Main.rand.Next(1, 3);
								if (Main.rand.Next(60) == 0)
								{
									localAI[1] += 60f;
								}
								if (localAI[1] > 660f)
								{
									localAI[1] = 0f;
									FishingCheck();
								}
							}
						}
						else if (ai[1] < 0f)
						{
							if (velocity.Y == 0f || (honeyWet && (double)velocity.Y >= -0.01 && (double)velocity.Y <= 0.01))
							{
								velocity.Y = (float)Main.rand.Next(100, 500) * 0.015f;
								velocity.X = (float)Main.rand.Next(-100, 101) * 0.015f;
								wet = false;
								lavaWet = false;
								honeyWet = false;
							}
							ai[1] += Main.rand.Next(1, 5);
							if (ai[1] >= 0f)
							{
								ai[1] = 0f;
								localAI[1] = 0f;
								netUpdate = true;
							}
						}
					}
				}
			}
			if (aiStyle == 62)
			{
				if (type == 373)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].hornetMinion = false;
					}
					if (Main.player[owner].hornetMinion)
					{
						timeLeft = 2;
					}
				}
				if (type == 375)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].impMinion = false;
					}
					if (Main.player[owner].impMinion)
					{
						timeLeft = 2;
					}
				}
				if (type == 407)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].sharknadoMinion = false;
					}
					if (Main.player[owner].sharknadoMinion)
					{
						timeLeft = 2;
					}
				}
				float num718 = 0.05f;
				float num719 = width;
				if (type == 407)
				{
					num718 = 0.1f;
					num719 *= 2f;
				}
				for (int num720 = 0; num720 < 1000; num720++)
				{
					if (num720 != whoAmI && Main.projectile[num720].active && Main.projectile[num720].owner == owner && Main.projectile[num720].type == type && Math.Abs(position.X - Main.projectile[num720].position.X) + Math.Abs(position.Y - Main.projectile[num720].position.Y) < num719)
					{
						if (position.X < Main.projectile[num720].position.X)
						{
							velocity.X -= num718;
						}
						else
						{
							velocity.X += num718;
						}
						if (position.Y < Main.projectile[num720].position.Y)
						{
							velocity.Y -= num718;
						}
						else
						{
							velocity.Y += num718;
						}
					}
				}
				Vector2 vector57 = position;
				float num721 = 400f;
				bool flag28 = false;
				tileCollide = true;
				if (type == 407)
				{
					tileCollide = false;
					if (Collision.SolidCollision(position, width, height))
					{
						alpha += 20;
						if (alpha > 150)
						{
							alpha = 150;
						}
					}
					else
					{
						alpha -= 50;
						if (alpha < 60)
						{
							alpha = 60;
						}
					}
				}
				if (type == 407)
				{
					Vector2 vector58 = Main.player[owner].center();
					for (int num722 = 0; num722 < 200; num722++)
					{
						NPC nPC = Main.npc[num722];
						if (nPC.active && !nPC.dontTakeDamage && !nPC.friendly && nPC.lifeMax > 5)
						{
							float num723 = Vector2.Distance(nPC.center(), vector58);
							if (((Vector2.Distance(vector58, vector57) > num723 && num723 < num721) || !flag28) && Collision.CanHitLine(position, width, height, nPC.position, nPC.width, nPC.height))
							{
								num721 = num723;
								vector57 = nPC.center();
								flag28 = true;
							}
						}
					}
				}
				else
				{
					for (int num724 = 0; num724 < 200; num724++)
					{
						NPC nPC2 = Main.npc[num724];
						if (nPC2.active && !nPC2.dontTakeDamage && !nPC2.friendly && nPC2.lifeMax > 5)
						{
							float num725 = Vector2.Distance(nPC2.center(), center());
							if (((Vector2.Distance(center(), vector57) > num725 && num725 < num721) || !flag28) && Collision.CanHitLine(position, width, height, nPC2.position, nPC2.width, nPC2.height))
							{
								num721 = num725;
								vector57 = nPC2.center();
								flag28 = true;
							}
						}
					}
				}
				int num726 = 500;
				if (flag28)
				{
					num726 = 1000;
				}
				Player player = Main.player[owner];
				if (Vector2.Distance(player.center(), center()) > (float)num726)
				{
					ai[0] = 1f;
					netUpdate = true;
				}
				if (ai[0] == 1f)
				{
					tileCollide = false;
				}
				if (flag28 && ai[0] == 0f)
				{
					Vector2 vector59 = vector57 - center();
					float num727 = vector59.Length();
					vector59.Normalize();
					if (type == 407)
					{
						if (num727 > 400f)
						{
							float num728 = 2f;
							vector59 *= num728;
							velocity = (velocity * 20f + vector59) / 21f;
						}
						else
						{
							velocity *= 0.96f;
						}
					}
					if (num727 > 200f)
					{
						float num729 = 6f;
						vector59 *= num729;
						velocity.X = (velocity.X * 40f + vector59.X) / 41f;
						velocity.Y = (velocity.Y * 40f + vector59.Y) / 41f;
					}
					else if (type == 375)
					{
						if (num727 < 150f)
						{
							float num730 = 4f;
							vector59 *= 0f - num730;
							velocity.X = (velocity.X * 40f + vector59.X) / 41f;
							velocity.Y = (velocity.Y * 40f + vector59.Y) / 41f;
						}
						else
						{
							velocity *= 0.97f;
						}
					}
					else if (velocity.Y > -1f)
					{
						velocity.Y -= 0.1f;
					}
				}
				else
				{
					if (!Collision.CanHitLine(center(), 1, 1, Main.player[owner].center(), 1, 1))
					{
						ai[0] = 1f;
					}
					float num731 = 6f;
					if (ai[0] == 1f)
					{
						num731 = 15f;
					}
					if (type == 407)
					{
						num731 = 9f;
					}
					Vector2 vector60 = center();
					Vector2 vector61 = player.center() - vector60 + new Vector2(0f, -60f);
					if (type == 407)
					{
						vector61 += new Vector2(0f, 40f);
					}
					if (type == 375)
					{
						ai[1] = 3600f;
						netUpdate = true;
						vector61 = player.center() - vector60;
						int num732 = 1;
						for (int num733 = 0; num733 < whoAmI; num733++)
						{
							if (Main.projectile[num733].active && Main.projectile[num733].owner == owner && Main.projectile[num733].type == type)
							{
								num732++;
							}
						}
						vector61.X -= 10 * Main.player[owner].direction;
						vector61.X -= num732 * 40 * Main.player[owner].direction;
						vector61.Y -= 10f;
					}
					float num734 = vector61.Length();
					if (num734 > 200f && num731 < 9f)
					{
						num731 = 9f;
					}
					if (type == 375)
					{
						num731 = (int)((double)num731 * 0.75);
					}
					if (num734 < 100f && ai[0] == 1f && !Collision.SolidCollision(position, width, height))
					{
						ai[0] = 0f;
						netUpdate = true;
					}
					if (num734 > 2000f)
					{
						position.X = Main.player[owner].center().X - (float)(width / 2);
						position.Y = Main.player[owner].center().Y - (float)(width / 2);
					}
					if (type == 375)
					{
						if (num734 > 10f)
						{
							vector61.Normalize();
							if (num734 < 50f)
							{
								num731 /= 2f;
							}
							vector61 *= num731;
							velocity = (velocity * 20f + vector61) / 21f;
						}
						else
						{
							direction = Main.player[owner].direction;
							velocity *= 0.9f;
						}
					}
					else if (type == 407)
					{
						if (Math.Abs(vector61.X) > 40f || Math.Abs(vector61.Y) > 10f)
						{
							vector61.Normalize();
							vector61 *= num731;
							vector61 *= new Vector2(1.25f, 0.65f);
							velocity = (velocity * 20f + vector61) / 21f;
						}
						else
						{
							if (velocity.X == 0f && velocity.Y == 0f)
							{
								velocity.X = -0.15f;
								velocity.Y = -0.05f;
							}
							velocity *= 1.01f;
						}
					}
					else if (num734 > 70f)
					{
						vector61.Normalize();
						vector61 *= num731;
						velocity = (velocity * 20f + vector61) / 21f;
					}
					else
					{
						if (velocity.X == 0f && velocity.Y == 0f)
						{
							velocity.X = -0.15f;
							velocity.Y = -0.05f;
						}
						velocity *= 1.01f;
					}
				}
				rotation = velocity.X * 0.05f;
				frameCounter++;
				if (type == 373)
				{
					if (frameCounter > 1)
					{
						frame++;
						frameCounter = 0;
					}
					if (frame > 2)
					{
						frame = 0;
					}
				}
				if (type == 375)
				{
					if (frameCounter >= 16)
					{
						frameCounter = 0;
					}
					frame = frameCounter / 4;
					if (ai[1] > 0f && ai[1] < 16f)
					{
						frame += 4;
					}
					if (Main.rand.Next(6) == 0)
					{
						int num735 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num735].velocity *= 0.3f;
						Main.dust[num735].noGravity = true;
						Main.dust[num735].noLight = true;
					}
				}
				if (type == 407)
				{
					int num736 = 2;
					if (frameCounter >= 6 * num736)
					{
						frameCounter = 0;
					}
					frame = frameCounter / num736;
					if (Main.rand.Next(5) == 0)
					{
						int num737 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 217, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num737].velocity *= 0.3f;
						Main.dust[num737].noGravity = true;
						Main.dust[num737].noLight = true;
					}
				}
				if (velocity.X > 0f)
				{
					spriteDirection = (direction = -1);
				}
				else if (velocity.X < 0f)
				{
					spriteDirection = (direction = 1);
				}
				if (type == 373)
				{
					if (ai[1] > 0f)
					{
						ai[1] += Main.rand.Next(1, 4);
					}
					if (ai[1] > 90f)
					{
						ai[1] = 0f;
						netUpdate = true;
					}
				}
				else if (type == 375)
				{
					if (ai[1] > 0f)
					{
						ai[1] += 1f;
						if (Main.rand.Next(3) == 0)
						{
							ai[1] += 1f;
						}
					}
					if (ai[1] > (float)Main.rand.Next(180, 900))
					{
						ai[1] = 0f;
						netUpdate = true;
					}
				}
				else if (type == 407)
				{
					if (ai[1] > 0f)
					{
						ai[1] += 1f;
						if (Main.rand.Next(3) != 0)
						{
							ai[1] += 1f;
						}
					}
					if (ai[1] > 60f)
					{
						ai[1] = 0f;
						netUpdate = true;
					}
				}
				if (ai[0] == 0f)
				{
					float num738 = 0f;
					int num739 = 0;
					if (type == 373)
					{
						num738 = 10f;
						num739 = 374;
					}
					else if (type == 375)
					{
						num738 = 11f;
						num739 = 376;
					}
					else if (type == 407)
					{
						num738 = 14f;
						num739 = 408;
					}
					if (flag28)
					{
						if (type == 375)
						{
							if ((vector57 - center()).X > 0f)
							{
								spriteDirection = (direction = -1);
							}
							else if ((vector57 - center()).X < 0f)
							{
								spriteDirection = (direction = 1);
							}
						}
						if ((type != 407 || !Collision.SolidCollision(position, width, height)) && ai[1] == 0f)
						{
							ai[1] += 1f;
							if (Main.myPlayer == owner)
							{
								Vector2 vector62 = vector57 - center();
								vector62.Normalize();
								vector62 *= num738;
								int num740 = NewProjectile(center().X, center().Y, vector62.X, vector62.Y, num739, damage, 0f, Main.myPlayer);
								Main.projectile[num740].timeLeft = 300;
								Main.projectile[num740].netUpdate = true;
								netUpdate = true;
							}
						}
					}
				}
			}
			if (aiStyle == 63)
			{
				if (!Main.player[owner].active)
				{
					active = false;
					return;
				}
				Vector2 value7 = position;
				bool flag29 = false;
				float num741 = 500f;
				for (int num742 = 0; num742 < 200; num742++)
				{
					NPC nPC3 = Main.npc[num742];
					if (nPC3.active && !nPC3.dontTakeDamage && !nPC3.friendly && nPC3.lifeMax > 5)
					{
						float num743 = Vector2.Distance(nPC3.center(), center());
						if (((Vector2.Distance(center(), value7) > num743 && num743 < num741) || !flag29) && Collision.CanHit(position, width, height, nPC3.position, nPC3.width, nPC3.height))
						{
							num741 = num743;
							value7 = nPC3.center();
							flag29 = true;
						}
					}
				}
				if (!flag29)
				{
					velocity.X *= 0.95f;
				}
				else
				{
					float num744 = 5f;
					float num745 = 0.08f;
					if (velocity.Y == 0f)
					{
						bool flag30 = false;
						if (center().Y - 50f > value7.Y)
						{
							flag30 = true;
						}
						if (flag30)
						{
							velocity.Y = -6f;
						}
					}
					else
					{
						num744 = 8f;
						num745 = 0.12f;
					}
					velocity.X += (float)Math.Sign(value7.X - center().X) * num745;
					if (velocity.X < 0f - num744)
					{
						velocity.X = 0f - num744;
					}
					if (velocity.X > num744)
					{
						velocity.X = num744;
					}
				}
				float num746 = 0f;
				Collision.StepUp(ref position, ref velocity, width, height, ref num746, ref gfxOffY);
				if (velocity.Y != 0f)
				{
					frame = 3;
				}
				else
				{
					if (Math.Abs(velocity.X) > 0.2f)
					{
						frameCounter++;
					}
					if (frameCounter >= 9)
					{
						frameCounter = 0;
					}
					if (frameCounter >= 6)
					{
						frame = 2;
					}
					else if (frameCounter >= 3)
					{
						frame = 1;
					}
					else
					{
						frame = 0;
					}
				}
				if (velocity.X != 0f)
				{
					direction = Math.Sign(velocity.X);
				}
				spriteDirection = -direction;
				velocity.Y += 0.2f;
				if (velocity.Y > 16f)
				{
					velocity.Y = 16f;
				}
			}
			else if (aiStyle == 64)
			{
				int num747 = 10;
				int num748 = 15;
				float num749 = 1f;
				int num750 = 150;
				int num751 = 42;
				if (type == 386)
				{
					num747 = 16;
					num748 = 16;
					num749 = 1.5f;
				}
				if (velocity.X != 0f)
				{
					direction = (spriteDirection = -Math.Sign(velocity.X));
				}
				frameCounter++;
				if (frameCounter > 2)
				{
					frame++;
					frameCounter = 0;
				}
				if (frame >= 6)
				{
					frame = 0;
				}
				if (localAI[0] == 0f && Main.myPlayer == owner)
				{
					localAI[0] = 1f;
					position.X += width / 2;
					position.Y += height / 2;
					scale = ((float)(num747 + num748) - ai[1]) * num749 / (float)(num748 + num747);
					width = (int)((float)num750 * scale);
					height = (int)((float)num751 * scale);
					position.X -= width / 2;
					position.Y -= height / 2;
					netUpdate = true;
				}
				if (ai[1] != -1f)
				{
					scale = ((float)(num747 + num748) - ai[1]) * num749 / (float)(num748 + num747);
					width = (int)((float)num750 * scale);
					height = (int)((float)num751 * scale);
				}
				if (!Collision.SolidCollision(position, width, height))
				{
					alpha -= 30;
					if (alpha < 60)
					{
						alpha = 60;
					}
					if (type == 386 && alpha < 100)
					{
						alpha = 100;
					}
				}
				else
				{
					alpha += 30;
					if (alpha > 150)
					{
						alpha = 150;
					}
				}
				if (ai[0] > 0f)
				{
					ai[0] -= 1f;
				}
				if (ai[0] == 1f && ai[1] > 0f && owner == Main.myPlayer)
				{
					netUpdate = true;
					Vector2 vector63 = center();
					vector63.Y -= (float)num751 * scale / 2f;
					float num752 = ((float)(num747 + num748) - ai[1] + 1f) * num749 / (float)(num748 + num747);
					vector63.Y -= (float)num751 * num752 / 2f;
					vector63.Y += 2f;
					NewProjectile(vector63.X, vector63.Y, velocity.X, velocity.Y, type, damage, knockBack, owner, 10f, ai[1] - 1f);
					int num753 = 4;
					if (type == 386)
					{
						num753 = 2;
					}
					if ((int)ai[1] % num753 == 0 && ai[1] != 0f)
					{
						int num754 = 372;
						if (type == 386)
						{
							num754 = 373;
						}
						int num755 = NPC.NewNPC((int)vector63.X, (int)vector63.Y, num754);
						Main.npc[num755].velocity = velocity;
						Main.npc[num755].netUpdate = true;
						if (type == 386)
						{
							Main.npc[num755].ai[2] = width;
							Main.npc[num755].ai[3] = -1.5f;
						}
					}
				}
				if (ai[0] <= 0f)
				{
					float num756 = (float)Math.PI / 30f;
					float num757 = (float)width / 5f;
					if (type == 386)
					{
						num757 *= 2f;
					}
					float num758 = (float)(Math.Cos(num756 * (0f - ai[0])) - 0.5) * num757;
					position.X -= num758 * (float)(-direction);
					ai[0] -= 1f;
					num758 = (float)(Math.Cos(num756 * (0f - ai[0])) - 0.5) * num757;
					position.X += num758 * (float)(-direction);
				}
			}
			else if (aiStyle == 65)
			{
				if (ai[1] > 0f)
				{
					int num759 = (int)ai[1] - 1;
					if (num759 < 255)
					{
						localAI[0] += 1f;
						if (localAI[0] > 10f)
						{
							int num760 = 6;
							for (int num761 = 0; num761 < num760; num761++)
							{
								Vector2 spinningpoint = Vector2.Normalize(velocity) * new Vector2((float)width / 2f, height) * 0.75f;
								spinningpoint = spinningpoint.Rotate((double)(num761 - (num760 / 2 - 1)) * Math.PI / (double)(float)num760) + center();
								Vector2 vector64 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
								int num762 = Dust.NewDust(spinningpoint + vector64, 0, 0, 172, vector64.X * 2f, vector64.Y * 2f, 100, default(Color), 1.4f);
								Main.dust[num762].noGravity = true;
								Main.dust[num762].noLight = true;
								Main.dust[num762].velocity /= 4f;
								Main.dust[num762].velocity -= velocity;
							}
							alpha -= 5;
							if (alpha < 100)
							{
								alpha = 100;
							}
							rotation += velocity.X * 0.1f;
							frame = (int)(localAI[0] / 3f) % 3;
						}
						Vector2 value8 = Main.player[num759].center() - center();
						float num763 = 4f;
						num763 += localAI[0] / 20f;
						velocity = Vector2.Normalize(value8) * num763;
						if (value8.Length() < 50f)
						{
							Kill();
						}
					}
				}
				else
				{
					float num764 = (float)Math.PI / 15f;
					float num765 = 4f;
					float num766 = (float)(Math.Cos(num764 * ai[0]) - 0.5) * num765;
					velocity.Y -= num766;
					ai[0] += 1f;
					num766 = (float)(Math.Cos(num764 * ai[0]) - 0.5) * num765;
					velocity.Y += num766;
					localAI[0] += 1f;
					if (localAI[0] > 10f)
					{
						alpha -= 5;
						if (alpha < 100)
						{
							alpha = 100;
						}
						rotation += velocity.X * 0.1f;
						frame = (int)(localAI[0] / 3f) % 3;
					}
				}
				if (wet)
				{
					position.Y -= 16f;
					Kill();
				}
			}
			else if (aiStyle == 66)
			{
				if (type == 387 || type == 388)
				{
					if (Main.player[owner].dead)
					{
						Main.player[owner].twinsMinion = false;
					}
					if (Main.player[owner].twinsMinion)
					{
						timeLeft = 2;
					}
				}
				float num767 = 0.05f;
				for (int num768 = 0; num768 < 1000; num768++)
				{
					if (num768 != whoAmI && Main.projectile[num768].active && Main.projectile[num768].owner == owner && (Main.projectile[num768].type == 387 || Main.projectile[num768].type == 388) && Math.Abs(position.X - Main.projectile[num768].position.X) + Math.Abs(position.Y - Main.projectile[num768].position.Y) < (float)width)
					{
						if (position.X < Main.projectile[num768].position.X)
						{
							velocity.X -= num767;
						}
						else
						{
							velocity.X += num767;
						}
						if (position.Y < Main.projectile[num768].position.Y)
						{
							velocity.Y -= num767;
						}
						else
						{
							velocity.Y += num767;
						}
					}
				}
				if (ai[0] == 2f && type == 388)
				{
					ai[1] += 1f;
					maxUpdates = 1;
					rotation = velocity.ToRotation() + (float)Math.PI;
					frameCounter++;
					if (frameCounter > 1)
					{
						frame++;
						frameCounter = 0;
					}
					if (frame > 2)
					{
						frame = 0;
					}
					if (!(ai[1] > 40f))
					{
						return;
					}
					ai[1] = 1f;
					ai[0] = 0f;
					maxUpdates = 0;
					numUpdates = 0;
					netUpdate = true;
				}
				Vector2 vector65 = position;
				float num769 = 400f;
				bool flag31 = false;
				if (ai[0] != 1f)
				{
					tileCollide = true;
				}
				for (int num770 = 0; num770 < 200; num770++)
				{
					NPC nPC4 = Main.npc[num770];
					if (nPC4.active && !nPC4.dontTakeDamage && !nPC4.friendly && nPC4.lifeMax > 5)
					{
						float num771 = Vector2.Distance(nPC4.center(), center());
						if (((Vector2.Distance(center(), vector65) > num771 && num771 < num769) || !flag31) && Collision.CanHitLine(position, width, height, nPC4.position, nPC4.width, nPC4.height))
						{
							num769 = num771;
							vector65 = nPC4.center();
							flag31 = true;
						}
					}
				}
				int num772 = 500;
				if (flag31)
				{
					num772 = 1000;
				}
				Player player2 = Main.player[owner];
				if (Vector2.Distance(player2.center(), center()) > (float)num772)
				{
					ai[0] = 1f;
					tileCollide = false;
					netUpdate = true;
				}
				if (flag31 && ai[0] == 0f)
				{
					Vector2 vector66 = vector65 - center();
					float num773 = vector66.Length();
					vector66.Normalize();
					if (num773 > 200f)
					{
						float num774 = 6f;
						if (type == 388)
						{
							num774 = 8f;
						}
						vector66 *= num774;
						velocity = (velocity * 40f + vector66) / 41f;
					}
					else
					{
						float num775 = 4f;
						vector66 *= 0f - num775;
						velocity = (velocity * 40f + vector66) / 41f;
					}
				}
				else
				{
					float num776 = 6f;
					if (ai[0] == 1f)
					{
						num776 = 15f;
					}
					Vector2 vector67 = center();
					Vector2 vector68 = player2.center() - vector67 + new Vector2(0f, -60f);
					float num777 = vector68.Length();
					if (num777 > 200f && num776 < 8f)
					{
						num776 = 8f;
					}
					if (num777 < 150f && ai[0] == 1f && !Collision.SolidCollision(position, width, height))
					{
						ai[0] = 0f;
						netUpdate = true;
					}
					if (num777 > 2000f)
					{
						position.X = Main.player[owner].center().X - (float)(width / 2);
						position.Y = Main.player[owner].center().Y - (float)(height / 2);
						netUpdate = true;
					}
					if (num777 > 70f)
					{
						vector68.Normalize();
						vector68 *= num776;
						velocity = (velocity * 40f + vector68) / 41f;
					}
					else if (velocity.X == 0f && velocity.Y == 0f)
					{
						velocity.X = -0.15f;
						velocity.Y = -0.05f;
					}
				}
				if (type == 388)
				{
					rotation = velocity.ToRotation() + (float)Math.PI;
				}
				if (type == 387)
				{
					if (flag31)
					{
						rotation = (vector65 - center()).ToRotation() + (float)Math.PI;
					}
					else
					{
						rotation = velocity.ToRotation() + (float)Math.PI;
					}
				}
				frameCounter++;
				if (frameCounter > 3)
				{
					frame++;
					frameCounter = 0;
				}
				if (frame > 2)
				{
					frame = 0;
				}
				if (ai[1] > 0f)
				{
					ai[1] += Main.rand.Next(1, 4);
				}
				if (ai[1] > 90f && type == 387)
				{
					ai[1] = 0f;
					netUpdate = true;
				}
				if (ai[1] > 40f && type == 388)
				{
					ai[1] = 0f;
					netUpdate = true;
				}
				if (ai[0] == 0f)
				{
					if (type == 387)
					{
						float num778 = 8f;
						int num779 = 389;
						if (flag31 && ai[1] == 0f)
						{
							ai[1] += 1f;
							if (Main.myPlayer == owner && Collision.CanHitLine(position, width, height, vector65, 0, 0))
							{
								Vector2 vector69 = vector65 - center();
								vector69.Normalize();
								vector69 *= num778;
								int num780 = NewProjectile(center().X, center().Y, vector69.X, vector69.Y, num779, (int)((float)damage * 0.8f), 0f, Main.myPlayer);
								Main.projectile[num780].timeLeft = 300;
								netUpdate = true;
							}
						}
					}
					if (type == 388 && ai[1] == 0f && flag31 && num769 < 500f)
					{
						ai[1] += 1f;
						if (Main.myPlayer == owner)
						{
							ai[0] = 2f;
							Vector2 vector70 = vector65 - center();
							vector70.Normalize();
							velocity = vector70 * 8f;
							netUpdate = true;
						}
					}
				}
			}
			else if (aiStyle == 67)
			{
				Player player3 = Main.player[owner];
				if (!player3.active)
				{
					active = false;
					return;
				}
				if (player3.dead)
				{
					player3.pirateMinion = false;
				}
				if (player3.pirateMinion)
				{
					timeLeft = 2;
				}
				Vector2 vector71 = player3.center();
				vector71.X -= (15 + player3.width / 2) * player3.direction;
				vector71.X -= minionPos * 40 * player3.direction;
				if (ai[0] == 0f)
				{
					float num781 = 500f;
					if (Main.player[owner].rocketDelay2 > 0)
					{
						ai[0] = 1f;
						netUpdate = true;
					}
					Vector2 vector72 = player3.center() - center();
					if (vector72.Length() > 2000f)
					{
						position = player3.center() - new Vector2(width, height) / 2f;
					}
					else if (vector72.Length() > num781 || Math.Abs(vector72.Y) > 300f)
					{
						ai[0] = 1f;
						netUpdate = true;
						if (velocity.Y > 0f && vector72.Y < 0f)
						{
							velocity.Y = 0f;
						}
						if (velocity.Y < 0f && vector72.Y > 0f)
						{
							velocity.Y = 0f;
						}
					}
				}
				int num782 = -1;
				float num783 = 450f;
				int num784 = 15;
				if (ai[0] == 0f)
				{
					for (int num785 = 0; num785 < 200; num785++)
					{
						NPC nPC5 = Main.npc[num785];
						if (nPC5.active && !nPC5.dontTakeDamage && !nPC5.friendly && nPC5.lifeMax > 5)
						{
							float num786 = (nPC5.center() - center()).Length();
							if (num786 < num783)
							{
								num782 = num785;
								num783 = num786;
							}
						}
					}
				}
				if (ai[0] == 1f)
				{
					tileCollide = false;
					float num787 = 0.2f;
					float num788 = 10f;
					int num789 = 200;
					if (num788 < Math.Abs(player3.velocity.X) + Math.Abs(player3.velocity.Y))
					{
						num788 = Math.Abs(player3.velocity.X) + Math.Abs(player3.velocity.Y);
					}
					Vector2 vector73 = player3.center() - center();
					float num790 = vector73.Length();
					if (num790 > 2000f)
					{
						position = player3.center() - new Vector2(width, height) / 2f;
					}
					if (num790 < (float)num789 && player3.velocity.Y == 0f && position.Y + (float)height <= player3.position.Y + (float)player3.height && !Collision.SolidCollision(position, width, height))
					{
						ai[0] = 0f;
						netUpdate = true;
						if (velocity.Y < -6f)
						{
							velocity.Y = -6f;
						}
					}
					if (!(num790 < 60f))
					{
						vector73.Normalize();
						vector73 *= num788;
						if (velocity.X < vector73.X)
						{
							velocity.X += num787;
							if (velocity.X < 0f)
							{
								velocity.X += num787 * 1.5f;
							}
						}
						if (velocity.X > vector73.X)
						{
							velocity.X -= num787;
							if (velocity.X > 0f)
							{
								velocity.X -= num787 * 1.5f;
							}
						}
						if (velocity.Y < vector73.Y)
						{
							velocity.Y += num787;
							if (velocity.Y < 0f)
							{
								velocity.Y += num787 * 1.5f;
							}
						}
						if (velocity.Y > vector73.Y)
						{
							velocity.Y -= num787;
							if (velocity.Y > 0f)
							{
								velocity.Y -= num787 * 1.5f;
							}
						}
					}
					if (velocity.X != 0f)
					{
						spriteDirection = Math.Sign(velocity.X);
					}
					frameCounter++;
					if (frameCounter > 3)
					{
						frame++;
						frameCounter = 0;
					}
					if ((frame < 10) | (frame > 13))
					{
						frame = 10;
					}
					rotation = velocity.X * 0.1f;
				}
				if (ai[0] == 2f)
				{
					friendly = true;
					spriteDirection = direction;
					rotation = 0f;
					frame = 4 + (int)((float)num784 - ai[1]) / (num784 / 3);
					if (velocity.Y != 0f)
					{
						frame += 3;
					}
					velocity.Y += 0.4f;
					if (velocity.Y > 10f)
					{
						velocity.Y = 10f;
					}
					ai[1] -= 1f;
					if (ai[1] <= 0f)
					{
						ai[1] = 0f;
						ai[0] = 0f;
						friendly = false;
						netUpdate = true;
						return;
					}
				}
				if (num782 >= 0)
				{
					float num791 = 400f;
					float num792 = 20f;
					if ((double)position.Y > Main.worldSurface * 16.0)
					{
						num791 = 200f;
					}
					NPC nPC6 = Main.npc[num782];
					Vector2 vector74 = nPC6.center();
					float num793 = (vector74 - center()).Length();
					Collision.CanHit(position, width, height, nPC6.position, nPC6.width, nPC6.height);
					if (num793 < num791)
					{
						vector71 = vector74;
						if (vector74.Y < center().Y - 30f && velocity.Y == 0f)
						{
							float num794 = Math.Abs(vector74.Y - center().Y);
							if (num794 < 120f)
							{
								velocity.Y = -10f;
							}
							else if (num794 < 210f)
							{
								velocity.Y = -13f;
							}
							else if (num794 < 270f)
							{
								velocity.Y = -15f;
							}
							else if (num794 < 310f)
							{
								velocity.Y = -17f;
							}
							else if (num794 < 380f)
							{
								velocity.Y = -18f;
							}
						}
					}
					if (num793 < num792)
					{
						ai[0] = 2f;
						ai[1] = num784;
						netUpdate = true;
					}
				}
				if (ai[0] == 0f)
				{
					tileCollide = true;
					float num795 = 0.5f;
					float num796 = 4f;
					float num797 = 4f;
					float num798 = 0.1f;
					if (num797 < Math.Abs(player3.velocity.X) + Math.Abs(player3.velocity.Y))
					{
						num797 = Math.Abs(player3.velocity.X) + Math.Abs(player3.velocity.Y);
						num795 = 0.7f;
					}
					int num799 = 0;
					bool flag32 = false;
					float num800 = vector71.X - center().X;
					if (Math.Abs(num800) > 5f)
					{
						if (num800 < 0f)
						{
							num799 = -1;
							if (velocity.X > 0f - num796)
							{
								velocity.X -= num795;
							}
							else
							{
								velocity.X -= num798;
							}
						}
						else
						{
							num799 = 1;
							if (velocity.X < num796)
							{
								velocity.X += num795;
							}
							else
							{
								velocity.X += num798;
							}
						}
					}
					else
					{
						velocity.X *= 0.9f;
						if (Math.Abs(velocity.X) < num795 * 2f)
						{
							velocity.X = 0f;
						}
					}
					if (num799 != 0)
					{
						int num801 = (int)(position.X + (float)(width / 2)) / 16;
						int num802 = (int)position.Y / 16;
						num801 += num799;
						num801 += (int)velocity.X;
						for (int num803 = num802; num803 < num802 + height / 16 + 1; num803++)
						{
							if (WorldGen.SolidTile(num801, num803))
							{
								flag32 = true;
							}
						}
					}
					Collision.StepUp(ref position, ref velocity, width, height, ref stepSpeed, ref gfxOffY);
					if (velocity.Y == 0f && flag32)
					{
						for (int num804 = 0; num804 < 3; num804++)
						{
							int num805 = (int)(position.X + (float)(width / 2)) / 16;
							if (num804 == 0)
							{
								num805 = (int)position.X / 16;
							}
							if (num804 == 2)
							{
								num805 = (int)(position.X + (float)width) / 16;
							}
							int num806 = (int)(position.Y + (float)height) / 16 + 1;
							if (!WorldGen.SolidTile(num805, num806) && !Main.tile[num805, num806].halfBrick() && Main.tile[num805, num806].slope() <= 0)
							{
								continue;
							}
							try
							{
								num805 = (int)(position.X + (float)(width / 2)) / 16;
								num806 = (int)(position.Y + (float)(height / 2)) / 16;
								num805 += num799;
								num805 += (int)velocity.X;
								if (!WorldGen.SolidTile(num805, num806 - 1) && !WorldGen.SolidTile(num805, num806 - 2))
								{
									velocity.Y = -5.1f;
								}
								else if (!WorldGen.SolidTile(num805, num806 - 2))
								{
									velocity.Y = -7.1f;
								}
								else if (WorldGen.SolidTile(num805, num806 - 5))
								{
									velocity.Y = -11.1f;
								}
								else if (WorldGen.SolidTile(num805, num806 - 4))
								{
									velocity.Y = -10.1f;
								}
								else
								{
									velocity.Y = -9.1f;
								}
							}
							catch
							{
								velocity.Y = -9.1f;
							}
						}
					}
					if (velocity.X > num797)
					{
						velocity.X = num797;
					}
					if (velocity.X < 0f - num797)
					{
						velocity.X = 0f - num797;
					}
					if (velocity.X < 0f)
					{
						direction = -1;
					}
					if (velocity.X > 0f)
					{
						direction = 1;
					}
					if (velocity.X > num795 && num799 == 1)
					{
						direction = 1;
					}
					if (velocity.X < 0f - num795 && num799 == -1)
					{
						direction = -1;
					}
					spriteDirection = direction;
					rotation = 0f;
					if (velocity.Y == 0f)
					{
						if (velocity.X == 0f)
						{
							frame = 0;
							frameCounter = 0;
						}
						else if (Math.Abs(velocity.X) >= 0.5f)
						{
							frameCounter += (int)Math.Abs(velocity.X);
							frameCounter++;
							if (frameCounter > 10)
							{
								frame++;
								frameCounter = 0;
							}
							if (frame >= 4)
							{
								frame = 0;
							}
						}
						else
						{
							frame = 0;
							frameCounter = 0;
						}
					}
					else if (velocity.Y != 0f)
					{
						frameCounter = 0;
						frame = 14;
					}
					velocity.Y += 0.4f;
					if (velocity.Y > 10f)
					{
						velocity.Y = 10f;
					}
				}
				localAI[0] += 1f;
				if (velocity.X == 0f)
				{
					localAI[0] += 1f;
				}
				if (localAI[0] >= (float)Main.rand.Next(900, 1200))
				{
					localAI[0] = 0f;
					for (int num807 = 0; num807 < 6; num807++)
					{
						int num808 = Dust.NewDust(center() + Vector2.UnitX * -direction * 8f - Vector2.One * 5f + Vector2.UnitY * 8f, 3, 6, 216, -direction, 1f);
						Main.dust[num808].velocity /= 2f;
						Main.dust[num808].scale = 0.8f;
					}
					int num809 = Gore.NewGore(center() + Vector2.UnitX * -direction * 8f, Vector2.Zero, Main.rand.Next(580, 583));
					Main.gore[num809].velocity /= 2f;
					Main.gore[num809].velocity.Y = Math.Abs(Main.gore[num809].velocity.Y);
					Main.gore[num809].velocity.X = (0f - Math.Abs(Main.gore[num809].velocity.X)) * (float)direction;
				}
			}
			else if (aiStyle == 68)
			{
				rotation += 0.25f * (float)direction;
				ai[0] += 1f;
				if (ai[0] >= 3f)
				{
					alpha -= 40;
					if (alpha < 0)
					{
						alpha = 0;
					}
				}
				if (ai[0] >= 15f)
				{
					velocity.Y += 0.2f;
					if (velocity.Y > 16f)
					{
						velocity.Y = 16f;
					}
					velocity.X *= 0.99f;
				}
				if (alpha == 0)
				{
					Vector2 spinningpoint2 = new Vector2(4f, -8f);
					float num810 = rotation;
					if (direction == -1)
					{
						spinningpoint2.X = -4f;
					}
					spinningpoint2 = spinningpoint2.Rotate(num810);
					for (int num811 = 0; num811 < 1; num811++)
					{
						int num812 = Dust.NewDust(center() + spinningpoint2 - Vector2.One * 5f, 4, 4, 6);
						Main.dust[num812].scale = 1.5f;
						Main.dust[num812].noGravity = true;
						Main.dust[num812].velocity = Main.dust[num812].velocity * 0.25f + Vector2.Normalize(spinningpoint2) * 1f;
						Main.dust[num812].velocity = Main.dust[num812].velocity.Rotate(-(float)Math.PI / 2f * (float)direction);
					}
				}
				spriteDirection = direction;
				if (owner == Main.myPlayer && timeLeft <= 3)
				{
					tileCollide = false;
					alpha = 255;
					position.X += width / 2;
					position.Y += height / 2;
					width = 80;
					height = 80;
					position.X -= width / 2;
					position.Y -= height / 2;
					knockBack = 8f;
				}
				if (wet && timeLeft > 3)
				{
					timeLeft = 3;
				}
			}
			else if (aiStyle == 69)
			{
				Vector2 vector75 = Main.player[owner].center() - center();
				rotation = vector75.ToRotation() - 1.57f;
				if (Main.player[owner].dead)
				{
					Kill();
					return;
				}
				Main.player[owner].itemAnimation = 10;
				Main.player[owner].itemTime = 10;
				if (vector75.X < 0f)
				{
					Main.player[owner].ChangeDir(1);
					direction = 1;
				}
				else
				{
					Main.player[owner].ChangeDir(-1);
					direction = -1;
				}
				Main.player[owner].itemRotation = (vector75 * -1f * direction).ToRotation();
				spriteDirection = ((!(vector75.X > 0f)) ? 1 : (-1));
				if (ai[0] == 0f && vector75.Length() > 400f)
				{
					ai[0] = 1f;
				}
				if (ai[0] == 1f || ai[0] == 2f)
				{
					float num813 = vector75.Length();
					if (num813 > 1500f)
					{
						Kill();
						return;
					}
					if (num813 > 600f)
					{
						ai[0] = 2f;
					}
					tileCollide = false;
					float num814 = 20f;
					if (ai[0] == 2f)
					{
						num814 = 40f;
					}
					velocity = Vector2.Normalize(vector75) * num814;
					if (vector75.Length() < num814)
					{
						Kill();
						return;
					}
				}
				ai[1] += 1f;
				if (ai[1] > 5f)
				{
					alpha = 0;
				}
				if ((int)ai[1] % 3 == 0 && owner == Main.myPlayer)
				{
					Vector2 spinningpoint3 = vector75 * -1f;
					spinningpoint3.Normalize();
					spinningpoint3 *= (float)Main.rand.Next(45, 65) * 0.1f;
					spinningpoint3 = spinningpoint3.Rotate((Main.rand.NextDouble() - 0.5) * 1.5707963705062866);
					NewProjectile(center().X, center().Y, spinningpoint3.X, spinningpoint3.Y, 405, damage, knockBack, owner, -10f);
				}
			}
			else if (aiStyle == 70)
			{
				if (ai[0] == 0f)
				{
					float num815 = 500f;
					int num816 = -1;
					for (int num817 = 0; num817 < 200; num817++)
					{
						NPC nPC7 = Main.npc[num817];
						if (nPC7.active && !nPC7.dontTakeDamage && !nPC7.friendly && nPC7.lifeMax > 5 && Collision.CanHit(position, width, height, nPC7.position, nPC7.width, nPC7.height))
						{
							float num818 = (nPC7.center() - center()).Length();
							if (num818 < num815)
							{
								num816 = num817;
								num815 = num818;
							}
						}
					}
					ai[0] = num816 + 1;
					if (ai[0] == 0f)
					{
						ai[0] = -15f;
					}
					if (ai[0] > 0f)
					{
						float num819 = (float)Main.rand.Next(35, 75) / 10f;
						velocity = Vector2.Normalize(Main.npc[(int)ai[0] - 1].center() - center() + new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101))) * num819;
						netUpdate = true;
					}
				}
				else if (ai[0] > 0f)
				{
					Vector2 vector76 = Vector2.Normalize(Main.npc[(int)ai[0] - 1].center() - center());
					velocity = (velocity * 40f + vector76 * 12f) / 41f;
				}
				else
				{
					ai[0] += 1f;
					alpha -= 25;
					if (alpha < 50)
					{
						alpha = 50;
					}
					velocity *= 0.95f;
				}
				if (ai[1] == 0f)
				{
					ai[1] = (float)Main.rand.Next(80, 121) / 100f;
					netUpdate = true;
				}
				scale = ai[1];
			}
			else if (aiStyle == 71)
			{
				localAI[1] += 1f;
				if (localAI[1] > 10f && Main.rand.Next(3) == 0)
				{
					int num820 = 6;
					for (int num821 = 0; num821 < num820; num821++)
					{
						Vector2 spinningpoint4 = Vector2.Normalize(velocity) * new Vector2(width, height) / 2f;
						spinningpoint4 = spinningpoint4.Rotate((double)(num821 - (num820 / 2 - 1)) * Math.PI / (double)(float)num820) + center();
						Vector2 vector77 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
						int num822 = Dust.NewDust(spinningpoint4 + vector77, 0, 0, 217, vector77.X * 2f, vector77.Y * 2f, 100, default(Color), 1.4f);
						Main.dust[num822].noGravity = true;
						Main.dust[num822].noLight = true;
						Main.dust[num822].velocity /= 4f;
						Main.dust[num822].velocity -= velocity;
					}
					alpha -= 5;
					if (alpha < 50)
					{
						alpha = 50;
					}
					rotation += velocity.X * 0.1f;
					frame = (int)(localAI[1] / 3f) % 3;
					Lighting.addLight((int)center().X / 16, (int)center().Y / 16, 0.1f, 0.4f, 0.6f);
				}
				int num823 = -1;
				Vector2 vector78 = center();
				float num824 = 500f;
				if (localAI[0] > 0f)
				{
					localAI[0] -= 1f;
				}
				if (ai[0] == 0f && localAI[0] == 0f)
				{
					for (int num825 = 0; num825 < 200; num825++)
					{
						NPC nPC8 = Main.npc[num825];
						if (nPC8.active && !nPC8.dontTakeDamage && !nPC8.friendly && nPC8.lifeMax > 5 && (ai[0] == 0f || ai[0] == (float)(num825 + 1)))
						{
							Vector2 vector79 = nPC8.center();
							float num826 = Vector2.Distance(vector79, vector78);
							if (num826 < num824 && Collision.CanHit(position, width, height, nPC8.position, nPC8.width, nPC8.height))
							{
								num824 = num826;
								vector78 = vector79;
								num823 = num825;
							}
						}
					}
					if (num823 >= 0)
					{
						ai[0] = num823 + 1;
						netUpdate = true;
					}
					num823 = -1;
				}
				if (localAI[0] == 0f && ai[0] == 0f)
				{
					localAI[0] = 30f;
				}
				bool flag33 = false;
				if (ai[0] != 0f)
				{
					int num827 = (int)(ai[0] - 1f);
					if (Main.npc[num827].active && !Main.npc[num827].dontTakeDamage && Main.npc[num827].immune[owner] == 0)
					{
						float num828 = Main.npc[num827].position.X + (float)(Main.npc[num827].width / 2);
						float num829 = Main.npc[num827].position.Y + (float)(Main.npc[num827].height / 2);
						float num830 = Math.Abs(position.X + (float)(width / 2) - num828) + Math.Abs(position.Y + (float)(height / 2) - num829);
						if (num830 < 1000f)
						{
							flag33 = true;
							vector78 = Main.npc[num827].center();
						}
					}
					else
					{
						ai[0] = 0f;
						flag33 = false;
						netUpdate = true;
					}
				}
				if (flag33)
				{
					Vector2 v = vector78 - center();
					float num831 = velocity.ToRotation();
					float num832 = v.ToRotation();
					double num833 = num832 - num831;
					if (num833 > Math.PI)
					{
						num833 -= Math.PI * 2.0;
					}
					if (num833 < -Math.PI)
					{
						num833 += Math.PI * 2.0;
					}
					velocity = velocity.Rotate(num833 * 0.10000000149011612);
				}
				float num834 = velocity.Length();
				velocity.Normalize();
				velocity *= num834 + 0.0025f;
			}
			else if (aiStyle == 72)
			{
				localAI[0] += 1f;
				if (localAI[0] > 5f)
				{
					alpha -= 25;
					if (alpha < 50)
					{
						alpha = 50;
					}
				}
				velocity *= 0.96f;
				if (ai[1] == 0f)
				{
					ai[1] = (float)Main.rand.Next(60, 121) / 100f;
					netUpdate = true;
				}
				scale = ai[1];
				position = center();
				int num835 = 14;
				int num836 = 14;
				width = (int)((float)num835 * ai[1]);
				height = (int)((float)num836 * ai[1]);
				position -= new Vector2(width / 2, height / 2);
			}
			if (aiStyle != 73)
			{
				return;
			}
			int num837 = (int)ai[0];
			int num838 = (int)ai[1];
			Tile tile = Main.tile[num837, num838];
			if (tile == null || !tile.active() || tile.type != 338)
			{
				Kill();
				return;
			}
			float num839 = 2f;
			float num840 = (float)timeLeft / 60f;
			if (num840 < 1f)
			{
				num839 *= num840;
			}
			if (type == 419)
			{
				for (int num841 = 0; num841 < 2; num841++)
				{
					Vector2 spinningpoint5 = new Vector2(0f, 0f - num839);
					spinningpoint5 *= 0.85f + (float)Main.rand.NextDouble() * 0.2f;
					spinningpoint5 = spinningpoint5.Rotate((Main.rand.NextDouble() - 0.5) * 1.5707963705062866);
					int num842 = Dust.NewDust(position, width, height, 222, 0f, 0f, 100);
					Dust dust = Main.dust[num842];
					dust.scale = 1f + (float)Main.rand.NextDouble() * 0.3f;
					dust.velocity *= 0.5f;
					if (dust.velocity.Y > 0f)
					{
						dust.velocity.Y *= -1f;
					}
					dust.position -= new Vector2(2 + Main.rand.Next(-2, 3), 0f);
					dust.velocity += spinningpoint5;
					dust.scale = 0.6f;
					dust.fadeIn = dust.scale + 0.2f;
					dust.velocity.Y *= 2f;
				}
			}
			if (type == 420)
			{
				for (int num843 = 0; num843 < 2; num843++)
				{
					Vector2 spinningpoint6 = new Vector2(0f, 0f - num839);
					spinningpoint6 *= 0.85f + (float)Main.rand.NextDouble() * 0.2f;
					spinningpoint6 = spinningpoint6.Rotate((Main.rand.NextDouble() - 0.5) * 1.5707963705062866);
					int num844 = 219;
					if (Main.rand.Next(5) == 0)
					{
						num844 = 222;
					}
					int num845 = Dust.NewDust(position, width, height, num844, 0f, 0f, 100);
					Dust dust2 = Main.dust[num845];
					dust2.scale = 1f + (float)Main.rand.NextDouble() * 0.3f;
					dust2.velocity *= 0.5f;
					if (dust2.velocity.Y > 0f)
					{
						dust2.velocity.Y *= -1f;
					}
					dust2.position -= new Vector2(2 + Main.rand.Next(-2, 3), 0f);
					dust2.velocity += spinningpoint6;
					dust2.velocity.X *= 0.5f;
					dust2.scale = 0.6f;
					dust2.fadeIn = dust2.scale + 0.2f;
					dust2.velocity.Y *= 2f;
				}
			}
			if (type == 421)
			{
				for (int num846 = 0; num846 < 2; num846++)
				{
					Vector2 spinningpoint7 = new Vector2(0f, 0f - num839);
					spinningpoint7 *= 0.85f + (float)Main.rand.NextDouble() * 0.2f;
					spinningpoint7 = spinningpoint7.Rotate((Main.rand.NextDouble() - 0.5) * 0.7853981852531433);
					int num847 = Dust.NewDust(position, width, height, 221, 0f, 0f, 100);
					Dust dust3 = Main.dust[num847];
					dust3.scale = 1f + (float)Main.rand.NextDouble() * 0.3f;
					dust3.velocity *= 0.1f;
					if (dust3.velocity.Y > 0f)
					{
						dust3.velocity.Y *= -1f;
					}
					dust3.position -= new Vector2(2 + Main.rand.Next(-2, 3), 0f);
					dust3.velocity += spinningpoint7;
					dust3.scale = 0.6f;
					dust3.fadeIn = dust3.scale + 0.2f;
					dust3.velocity.Y *= 2.5f;
				}
				if (timeLeft % 10 == 0)
				{
					float num848 = 0.85f + (float)Main.rand.NextDouble() * 0.2f;
					for (int num849 = 0; num849 < 9; num849++)
					{
						Vector2 vector80 = new Vector2((float)(num849 - 4) / 5f, (0f - num839) * num848);
						int num850 = Dust.NewDust(position, width, height, 222, 0f, 0f, 100);
						Dust dust4 = Main.dust[num850];
						dust4.scale = 0.7f + (float)Main.rand.NextDouble() * 0.3f;
						dust4.velocity *= 0f;
						if (dust4.velocity.Y > 0f)
						{
							dust4.velocity.Y *= -1f;
						}
						dust4.position -= new Vector2(2 + Main.rand.Next(-2, 3), 0f);
						dust4.velocity += vector80;
						dust4.scale = 0.6f;
						dust4.fadeIn = dust4.scale + 0.2f;
						dust4.velocity.Y *= 2f;
					}
				}
			}
			if (type != 422)
			{
				return;
			}
			for (int num851 = 0; num851 < 2; num851++)
			{
				Vector2 spinningpoint8 = new Vector2(0f, 0f - num839);
				spinningpoint8 *= 0.85f + (float)Main.rand.NextDouble() * 0.2f;
				spinningpoint8 = spinningpoint8.Rotate((Main.rand.NextDouble() - 0.5) * 1.5707963705062866);
				int num852 = Dust.NewDust(position, width, height, 219 + Main.rand.Next(5), 0f, 0f, 100);
				Dust dust5 = Main.dust[num852];
				dust5.scale = 1f + (float)Main.rand.NextDouble() * 0.3f;
				dust5.velocity *= 0.5f;
				if (dust5.velocity.Y > 0f)
				{
					dust5.velocity.Y *= -1f;
				}
				dust5.position -= new Vector2(2 + Main.rand.Next(-2, 3), 0f);
				dust5.velocity += spinningpoint8;
				dust5.scale = 0.6f;
				dust5.fadeIn = dust5.scale + 0.2f;
				dust5.velocity.Y *= 2f;
			}
		}

		public void Kill()
		{
			if (!active)
			{
				return;
			}
			timeLeft = 0;
			if (type == 405)
			{
				Main.PlaySound(2, (int)position.X, (int)position.Y, 54);
				center();
				for (int i = 0; i < 20; i++)
				{
					int num = 10;
					Vector2 vector18 = ((float)Main.rand.NextDouble() * ((float)Math.PI * 2f)).ToRotationVector2() * Main.rand.Next(24, 41) / 8f;
					int num2 = Dust.NewDust(center() - Vector2.One * num, num * 2, num * 2, 212);
					Dust dust = Main.dust[num2];
					Vector2 vector = Vector2.Normalize(dust.position - center());
					dust.position = center() + vector * num * scale;
					if (i < 30)
					{
						dust.velocity = vector * dust.velocity.Length();
					}
					else
					{
						dust.velocity = vector * Main.rand.Next(45, 91) / 10f;
					}
					dust.color = Main.hslToRgb((float)(0.4000000059604645 + Main.rand.NextDouble() * 0.20000000298023224), 0.9f, 0.5f);
					dust.color = Color.Lerp(dust.color, Color.White, 0.3f);
					dust.noGravity = true;
					dust.scale = 0.7f;
				}
			}
			if (type == 410)
			{
				Main.PlaySound(2, (int)position.X, (int)position.Y, 54);
				center();
				for (int j = 0; j < 10; j++)
				{
					int num3 = (int)(10f * ai[1]);
					Vector2 vector19 = ((float)Main.rand.NextDouble() * ((float)Math.PI * 2f)).ToRotationVector2() * Main.rand.Next(24, 41) / 8f;
					int num4 = Dust.NewDust(center() - Vector2.One * num3, num3 * 2, num3 * 2, 212);
					Dust dust2 = Main.dust[num4];
					Vector2 vector2 = Vector2.Normalize(dust2.position - center());
					dust2.position = center() + vector2 * num3 * scale;
					if (j < 30)
					{
						dust2.velocity = vector2 * dust2.velocity.Length();
					}
					else
					{
						dust2.velocity = vector2 * Main.rand.Next(45, 91) / 10f;
					}
					dust2.color = Main.hslToRgb((float)(0.4000000059604645 + Main.rand.NextDouble() * 0.20000000298023224), 0.9f, 0.5f);
					dust2.color = Color.Lerp(dust2.color, Color.White, 0.3f);
					dust2.noGravity = true;
					dust2.scale = 0.7f;
				}
			}
			if (type == 408)
			{
				for (int k = 0; k < 15; k++)
				{
					int num5 = Dust.NewDust(center() - Vector2.One * 10f, 50, 50, 5, 0f, -2f);
					Main.dust[num5].velocity /= 2f;
				}
				int num6 = 0;
				int num7 = 10;
				num6 = Gore.NewGore(center(), velocity * 0.8f, 584);
				Main.gore[num6].timeLeft /= num7;
				num6 = Gore.NewGore(center(), velocity * 0.9f, 585);
				Main.gore[num6].timeLeft /= num7;
				num6 = Gore.NewGore(center(), velocity * 1f, 586);
				Main.gore[num6].timeLeft /= num7;
			}
			if (type == 385)
			{
				Main.PlaySound(4, (int)center().X, (int)center().Y, 19);
				int num8 = 36;
				for (int l = 0; l < num8; l++)
				{
					Vector2 spinningpoint = Vector2.Normalize(velocity) * new Vector2((float)width / 2f, height) * 0.75f;
					spinningpoint = spinningpoint.Rotate((float)(l - (num8 / 2 - 1)) * ((float)Math.PI * 2f) / (float)num8) + center();
					Vector2 vector3 = spinningpoint - center();
					int num9 = Dust.NewDust(spinningpoint + vector3, 0, 0, 172, vector3.X * 2f, vector3.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num9].noGravity = true;
					Main.dust[num9].noLight = true;
					Main.dust[num9].velocity = vector3;
				}
				if (owner == Main.myPlayer)
				{
					if (ai[1] < 1f)
					{
						int num10 = NewProjectile(center().X - (float)(direction * 30), center().Y - 4f, (float)(-direction) * 0.01f, 0f, 384, 40, 4f, owner, 16f, 15f);
						Main.projectile[num10].netUpdate = true;
					}
					else
					{
						int num11 = (int)(center().Y / 16f);
						int num12 = (int)(center().X / 16f);
						int num13 = 100;
						if (num12 < 10)
						{
							num12 = 10;
						}
						if (num12 > Main.maxTilesX - 10)
						{
							num12 = Main.maxTilesX - 10;
						}
						if (num11 < 10)
						{
							num11 = 10;
						}
						if (num11 > Main.maxTilesY - num13 - 10)
						{
							num11 = Main.maxTilesY - num13 - 10;
						}
						for (int m = num11; m < num11 + num13; m++)
						{
							Tile tile = Main.tile[num12, m];
							if (tile.active() && (Main.tileSolid[tile.type] || tile.liquid != 0))
							{
								num11 = m;
								break;
							}
						}
						int num14 = NewProjectile(num12 * 16 + 8, num11 * 16 - 24, 0f, 0f, 386, 80, 4f, Main.myPlayer, 16f, 24f);
						Main.projectile[num14].netUpdate = true;
					}
				}
			}
			if (type == 399)
			{
				Main.PlaySound(13, (int)position.X, (int)position.Y);
				Vector2 vector4 = new Vector2(20f, 20f);
				for (int n = 0; n < 5; n++)
				{
					Dust.NewDust(center() - vector4 / 2f, (int)vector4.X, (int)vector4.Y, 12, 0f, 0f, 0, Color.Red);
				}
				for (int num15 = 0; num15 < 10; num15++)
				{
					int num16 = Dust.NewDust(center() - vector4 / 2f, (int)vector4.X, (int)vector4.Y, 31, 0f, 0f, 100, default(Color), 1.5f);
					Main.dust[num16].velocity *= 1.4f;
				}
				for (int num17 = 0; num17 < 20; num17++)
				{
					int num18 = Dust.NewDust(center() - vector4 / 2f, (int)vector4.X, (int)vector4.Y, 6, 0f, 0f, 100, default(Color), 2.5f);
					Main.dust[num18].noGravity = true;
					Main.dust[num18].velocity *= 5f;
					num18 = Dust.NewDust(center() - vector4 / 2f, (int)vector4.X, (int)vector4.Y, 6, 0f, 0f, 100, default(Color), 1.5f);
					Main.dust[num18].velocity *= 3f;
				}
				if (Main.myPlayer == owner)
				{
					for (int num19 = 0; num19 < 6; num19++)
					{
						float num20 = (0f - velocity.X) * (float)Main.rand.Next(20, 50) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
						float num21 = (0f - Math.Abs(velocity.Y)) * (float)Main.rand.Next(30, 50) * 0.01f + (float)Main.rand.Next(-20, 5) * 0.4f;
						NewProjectile(center().X + num20, center().Y + num21, num20, num21, 400 + Main.rand.Next(3), (int)((double)damage * 0.5), 0f, owner);
					}
				}
			}
			if (type == 384 || type == 386)
			{
				for (int num22 = 0; num22 < 20; num22++)
				{
					int num23 = Dust.NewDust(position, width, height, 212, direction * 2, 0f, 100, default(Color), 1.4f);
					Dust dust3 = Main.dust[num23];
					dust3.color = Color.CornflowerBlue;
					dust3.color = Color.Lerp(dust3.color, Color.White, 0.3f);
					dust3.noGravity = true;
				}
			}
			if (type == 1 || type == 81 || type == 98)
			{
				Main.PlaySound(0, (int)position.X, (int)position.Y);
				for (int num24 = 0; num24 < 10; num24++)
				{
					Dust.NewDust(new Vector2(position.X, position.Y), width, height, 7);
				}
			}
			if (type == 336 || type == 345)
			{
				for (int num25 = 0; num25 < 6; num25++)
				{
					int num26 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 196);
					Main.dust[num26].noGravity = true;
					Main.dust[num26].scale = scale;
				}
			}
			if (type == 358)
			{
				velocity = lastVelocity * 0.2f;
				for (int num27 = 0; num27 < 100; num27++)
				{
					int num28 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 211, 0f, 0f, 75, default(Color), 1.2f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num28].alpha += 25;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num28].alpha += 25;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num28].alpha += 25;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num28].scale = 0.6f;
					}
					else
					{
						Main.dust[num28].noGravity = true;
					}
					Main.dust[num28].velocity *= 0.3f;
					Main.dust[num28].velocity += velocity;
					Main.dust[num28].velocity *= 1f + (float)Main.rand.Next(-100, 101) * 0.01f;
					Main.dust[num28].velocity.X += (float)Main.rand.Next(-50, 51) * 0.015f;
					Main.dust[num28].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.015f;
					Main.dust[num28].position = center();
				}
			}
			if (type == 406)
			{
				int num29 = 175;
				Color newColor = new Color(0, 80, 255, 100);
				velocity = lastVelocity * 0.2f;
				for (int num30 = 0; num30 < 40; num30++)
				{
					int num31 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 4, 0f, 0f, num29, newColor, 1.6f);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num31].alpha += 25;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num31].alpha += 25;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num31].alpha += 25;
					}
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num31].scale = 0.6f;
					}
					else
					{
						Main.dust[num31].noGravity = true;
					}
					Main.dust[num31].velocity *= 0.3f;
					Main.dust[num31].velocity += velocity;
					Main.dust[num31].velocity *= 1f + (float)Main.rand.Next(-100, 101) * 0.01f;
					Main.dust[num31].velocity.X += (float)Main.rand.Next(-50, 51) * 0.015f;
					Main.dust[num31].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.015f;
					Main.dust[num31].position = center();
				}
			}
			if (type == 344)
			{
				for (int num32 = 0; num32 < 3; num32++)
				{
					int num33 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 197);
					Main.dust[num33].noGravity = true;
					Main.dust[num33].scale = scale;
				}
			}
			else if (type == 343)
			{
				Main.PlaySound(2, (int)position.X, (int)position.Y, 27);
				for (int num34 = 4; num34 < 31; num34++)
				{
					float num35 = lastVelocity.X * (30f / (float)num34);
					float num36 = lastVelocity.Y * (30f / (float)num34);
					int num37 = Dust.NewDust(new Vector2(lastPosition.X - num35, lastPosition.Y - num36), 8, 8, 197, lastVelocity.X, lastVelocity.Y, 100, default(Color), 1.2f);
					Main.dust[num37].noGravity = true;
					Main.dust[num37].velocity *= 0.5f;
				}
			}
			else if (type == 349)
			{
				Main.PlaySound(2, (int)position.X, (int)position.Y, 27);
				for (int num38 = 0; num38 < 3; num38++)
				{
					int num39 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 76);
					Main.dust[num39].noGravity = true;
					Main.dust[num39].noLight = true;
					Main.dust[num39].scale = 0.7f;
				}
			}
			if (type == 323)
			{
				Main.PlaySound(0, (int)position.X, (int)position.Y);
				for (int num40 = 0; num40 < 20; num40++)
				{
					int num41 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 7);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num41].noGravity = true;
						Main.dust[num41].scale = 1.3f;
						Main.dust[num41].velocity *= 1.5f;
						Main.dust[num41].velocity -= lastVelocity * 0.5f;
						Main.dust[num41].velocity *= 1.5f;
					}
					else
					{
						Main.dust[num41].velocity *= 0.75f;
						Main.dust[num41].velocity -= lastVelocity * 0.25f;
						Main.dust[num41].scale = 0.8f;
					}
				}
			}
			if (type == 346)
			{
				Main.PlaySound(2, (int)position.X, (int)position.Y, 27);
				for (int num42 = 0; num42 < 10; num42++)
				{
					int num43 = 10;
					if (ai[1] == 1f)
					{
						num43 = 4;
					}
					int num44 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, num43);
					Main.dust[num44].noGravity = true;
				}
			}
			if (type == 335)
			{
				Main.PlaySound(2, (int)position.X, (int)position.Y, 27);
				for (int num45 = 0; num45 < 10; num45++)
				{
					int num46 = 90 - (int)ai[1];
					int num47 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, num46);
					Main.dust[num47].noLight = true;
					Main.dust[num47].scale = 0.8f;
				}
			}
			if (type == 318)
			{
				Main.PlaySound(0, (int)position.X, (int)position.Y);
				for (int num48 = 0; num48 < 10; num48++)
				{
					int num49 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 30);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num49].noGravity = true;
					}
				}
			}
			if (type == 378)
			{
				for (int num50 = 0; num50 < 10; num50++)
				{
					int num51 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 30);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num51].noGravity = true;
					}
				}
			}
			else if (type == 311)
			{
				for (int num52 = 0; num52 < 5; num52++)
				{
					int num53 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 189);
					Main.dust[num53].scale = 0.85f;
					Main.dust[num53].noGravity = true;
					Main.dust[num53].velocity += velocity * 0.5f;
				}
			}
			else if (type == 316)
			{
				for (int num54 = 0; num54 < 5; num54++)
				{
					int num55 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 195);
					Main.dust[num55].scale = 0.85f;
					Main.dust[num55].noGravity = true;
					Main.dust[num55].velocity += velocity * 0.5f;
				}
			}
			else if (type == 184 || type == 195)
			{
				Main.PlaySound(0, (int)position.X, (int)position.Y);
				for (int num56 = 0; num56 < 5; num56++)
				{
					Dust.NewDust(new Vector2(position.X, position.Y), width, height, 7);
				}
			}
			else if (type == 275 || type == 276)
			{
				Main.PlaySound(0, (int)position.X, (int)position.Y);
				for (int num57 = 0; num57 < 5; num57++)
				{
					Dust.NewDust(new Vector2(position.X, position.Y), width, height, 7);
				}
			}
			else if (type == 291)
			{
				if (owner == Main.myPlayer)
				{
					NewProjectile(center().X, center().Y, 0f, 0f, 292, damage, knockBack, owner);
				}
			}
			else if (type == 295)
			{
				if (owner == Main.myPlayer)
				{
					NewProjectile(center().X, center().Y, 0f, 0f, 296, (int)((double)damage * 0.65), knockBack, owner);
				}
			}
			else if (type == 270)
			{
				Main.PlaySound(0, (int)position.X, (int)position.Y, 27);
				for (int num58 = 0; num58 < 20; num58++)
				{
					int num59 = Dust.NewDust(position, width, height, 26, 0f, 0f, 100);
					Main.dust[num59].noGravity = true;
					Main.dust[num59].velocity *= 1.2f;
					Main.dust[num59].scale = 1.3f;
					Main.dust[num59].velocity -= lastVelocity * 0.3f;
					num59 = Dust.NewDust(new Vector2(position.X + 4f, position.Y + 4f), width - 8, height - 8, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num59].noGravity = true;
					Main.dust[num59].velocity *= 3f;
				}
			}
			else if (type == 265)
			{
				Main.PlaySound(0, (int)position.X, (int)position.Y, 27);
				for (int num60 = 0; num60 < 15; num60++)
				{
					int num61 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 163, 0f, 0f, 100, default(Color), 1.2f);
					Main.dust[num61].noGravity = true;
					Main.dust[num61].velocity *= 1.2f;
					Main.dust[num61].velocity -= lastVelocity * 0.3f;
				}
			}
			else if (type == 355)
			{
				Main.PlaySound(0, (int)position.X, (int)position.Y, 27);
				for (int num62 = 0; num62 < 15; num62++)
				{
					int num63 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 205, 0f, 0f, 100, default(Color), 1.2f);
					Main.dust[num63].noGravity = true;
					Main.dust[num63].velocity *= 1.2f;
					Main.dust[num63].velocity -= lastVelocity * 0.3f;
				}
			}
			else if (type == 304)
			{
				for (int num64 = 0; num64 < 3; num64++)
				{
					int num65 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 182, 0f, 0f, 100, default(Color), 0.8f);
					Main.dust[num65].noGravity = true;
					Main.dust[num65].velocity *= 1.2f;
					Main.dust[num65].velocity -= lastVelocity * 0.3f;
				}
			}
			else if (type == 263)
			{
				Main.PlaySound(2, (int)position.X, (int)position.Y, 27);
				for (int num66 = 0; num66 < 15; num66++)
				{
					int num67 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 92, velocity.X, velocity.Y, Main.rand.Next(0, 101), default(Color), 1f + (float)Main.rand.Next(40) * 0.01f);
					Main.dust[num67].noGravity = true;
					Main.dust[num67].velocity *= 2f;
				}
			}
			else if (type == 261)
			{
				Main.PlaySound(0, (int)position.X, (int)position.Y);
				for (int num68 = 0; num68 < 5; num68++)
				{
					Dust.NewDust(new Vector2(position.X, position.Y), width, height, 148);
				}
			}
			else if (type == 229)
			{
				for (int num69 = 0; num69 < 25; num69++)
				{
					int num70 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 157);
					Main.dust[num70].noGravity = true;
					Main.dust[num70].velocity *= 1.5f;
					Main.dust[num70].scale = 1.5f;
				}
			}
			else if (type == 239)
			{
				int num71 = Dust.NewDust(new Vector2(position.X, position.Y + (float)height - 2f), 2, 2, 154);
				Main.dust[num71].position.X -= 2f;
				Main.dust[num71].alpha = 38;
				Main.dust[num71].velocity *= 0.1f;
				Main.dust[num71].velocity += -lastVelocity * 0.25f;
				Main.dust[num71].scale = 0.95f;
			}
			else if (type == 245)
			{
				int num72 = Dust.NewDust(new Vector2(position.X, position.Y + (float)height - 2f), 2, 2, 114);
				Main.dust[num72].noGravity = true;
				Main.dust[num72].position.X -= 2f;
				Main.dust[num72].alpha = 38;
				Main.dust[num72].velocity *= 0.1f;
				Main.dust[num72].velocity += -lastVelocity * 0.25f;
				Main.dust[num72].scale = 0.95f;
			}
			else if (type == 264)
			{
				int num73 = Dust.NewDust(new Vector2(position.X, position.Y + (float)height - 2f), 2, 2, 54);
				Main.dust[num73].noGravity = true;
				Main.dust[num73].position.X -= 2f;
				Main.dust[num73].alpha = 38;
				Main.dust[num73].velocity *= 0.1f;
				Main.dust[num73].velocity += -lastVelocity * 0.25f;
				Main.dust[num73].scale = 0.95f;
			}
			else if (type == 206 || type == 225)
			{
				Main.PlaySound(6, (int)position.X, (int)position.Y);
				for (int num74 = 0; num74 < 5; num74++)
				{
					Dust.NewDust(new Vector2(position.X, position.Y), width, height, 40);
				}
			}
			else if (type == 227)
			{
				Main.PlaySound(6, (int)position.X, (int)position.Y);
				for (int num75 = 0; num75 < 15; num75++)
				{
					int num76 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 157);
					Main.dust[num76].noGravity = true;
					Main.dust[num76].velocity += lastVelocity;
					Main.dust[num76].scale = 1.5f;
				}
			}
			else if (type == 237 && owner == Main.myPlayer)
			{
				NewProjectile(center().X, center().Y, 0f, 0f, 238, damage, knockBack, owner);
			}
			else if (type == 243 && owner == Main.myPlayer)
			{
				NewProjectile(center().X, center().Y, 0f, 0f, 244, damage, knockBack, owner);
			}
			else if (type == 120)
			{
				Main.PlaySound(0, (int)position.X, (int)position.Y);
				for (int num77 = 0; num77 < 10; num77++)
				{
					int num78 = Dust.NewDust(new Vector2(position.X - velocity.X, position.Y - velocity.Y), width, height, 67, velocity.X, velocity.Y, 100);
					if (num77 < 5)
					{
						Main.dust[num78].noGravity = true;
					}
					Main.dust[num78].velocity *= 0.2f;
				}
			}
			else if (type == 181 || type == 189)
			{
				for (int num79 = 0; num79 < 6; num79++)
				{
					int num80 = Dust.NewDust(position, width, height, 150, velocity.X, velocity.Y, 50);
					Main.dust[num80].noGravity = true;
					Main.dust[num80].scale = 1f;
				}
			}
			else if (type == 178)
			{
				for (int num81 = 0; num81 < 85; num81++)
				{
					int num82 = Main.rand.Next(139, 143);
					int num83 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, num82, velocity.X, velocity.Y, 0, default(Color), 1.2f);
					Main.dust[num83].velocity.X += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.dust[num83].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.dust[num83].velocity.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.dust[num83].velocity.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.dust[num83].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.dust[num83].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.dust[num83].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
				}
				for (int num84 = 0; num84 < 40; num84++)
				{
					int num85 = Main.rand.Next(276, 283);
					int num86 = Gore.NewGore(position, velocity, num85);
					Main.gore[num86].velocity.X += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[num86].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[num86].velocity.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[num86].velocity.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[num86].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
					Main.gore[num86].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.gore[num86].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
				}
			}
			else if (type == 289)
			{
				for (int num87 = 0; num87 < 30; num87++)
				{
					int num88 = Main.rand.Next(139, 143);
					int num89 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, num88, velocity.X, velocity.Y, 0, default(Color), 1.2f);
					Main.dust[num89].velocity.X += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.dust[num89].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.dust[num89].velocity.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.dust[num89].velocity.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.dust[num89].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.dust[num89].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.dust[num89].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
				}
				for (int num90 = 0; num90 < 15; num90++)
				{
					int num91 = Main.rand.Next(276, 283);
					int num92 = Gore.NewGore(position, velocity, num91);
					Main.gore[num92].velocity.X += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[num92].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[num92].velocity.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[num92].velocity.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[num92].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
					Main.gore[num92].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
					Main.gore[num92].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
				}
			}
			else if (type == 171)
			{
				if (ai[1] == 0f)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
				}
				if (ai[1] < 10f)
				{
					Vector2 vector5 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
					float num93 = 0f - velocity.X;
					float num94 = 0f - velocity.Y;
					float num95 = 1f;
					if (ai[0] <= 17f)
					{
						num95 = ai[0] / 17f;
					}
					int num96 = (int)(30f * num95);
					float num97 = 1f;
					if (ai[0] <= 30f)
					{
						num97 = ai[0] / 30f;
					}
					float num98 = 0.4f * num97;
					float num99 = num98;
					num94 += num99;
					for (int num100 = 0; num100 < num96; num100++)
					{
						float num101 = (float)Math.Sqrt(num93 * num93 + num94 * num94);
						float num102 = 5.6f;
						if (Math.Abs(num93) + Math.Abs(num94) < 1f)
						{
							num102 *= Math.Abs(num93) + Math.Abs(num94) / 1f;
						}
						num101 = num102 / num101;
						num93 *= num101;
						num94 *= num101;
						Math.Atan2(num94, num93);
						if ((float)num100 > ai[1])
						{
							for (int num103 = 0; num103 < 4; num103++)
							{
								int num104 = Dust.NewDust(vector5, width, height, 129);
								Main.dust[num104].noGravity = true;
								Main.dust[num104].velocity *= 0.3f;
							}
						}
						vector5.X += num93;
						vector5.Y += num94;
						num93 = 0f - velocity.X;
						num94 = 0f - velocity.Y;
						num99 += num98;
						num94 += num99;
					}
				}
			}
			else if (type == 117)
			{
				Main.PlaySound(0, (int)position.X, (int)position.Y);
				for (int num105 = 0; num105 < 10; num105++)
				{
					Dust.NewDust(new Vector2(position.X, position.Y), width, height, 26);
				}
			}
			else if (type == 166)
			{
				Main.PlaySound(2, (int)position.X, (int)position.Y, 51);
				for (int num106 = 0; num106 < 10; num106++)
				{
					int num107 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 76);
					Main.dust[num107].noGravity = true;
					Main.dust[num107].velocity -= lastVelocity * 0.25f;
				}
			}
			else if (type == 158)
			{
				Main.PlaySound(0, (int)position.X, (int)position.Y);
				for (int num108 = 0; num108 < 10; num108++)
				{
					int num109 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 9);
					Main.dust[num109].noGravity = true;
					Main.dust[num109].velocity -= velocity * 0.5f;
				}
			}
			else if (type == 159)
			{
				Main.PlaySound(0, (int)position.X, (int)position.Y);
				for (int num110 = 0; num110 < 10; num110++)
				{
					int num111 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 11);
					Main.dust[num111].noGravity = true;
					Main.dust[num111].velocity -= velocity * 0.5f;
				}
			}
			else if (type == 160)
			{
				Main.PlaySound(0, (int)position.X, (int)position.Y);
				for (int num112 = 0; num112 < 10; num112++)
				{
					int num113 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 19);
					Main.dust[num113].noGravity = true;
					Main.dust[num113].velocity -= velocity * 0.5f;
				}
			}
			else if (type == 161)
			{
				Main.PlaySound(0, (int)position.X, (int)position.Y);
				for (int num114 = 0; num114 < 10; num114++)
				{
					int num115 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 11);
					Main.dust[num115].noGravity = true;
					Main.dust[num115].velocity -= velocity * 0.5f;
				}
			}
			else if (type >= 191 && type <= 194)
			{
				int num116 = Gore.NewGore(new Vector2(position.X - (float)(width / 2), position.Y - (float)(height / 2)), new Vector2(0f, 0f), Main.rand.Next(61, 64), scale);
				Main.gore[num116].velocity *= 0.1f;
			}
			else if (!Main.projPet[type])
			{
				if (type == 93)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num117 = 0; num117 < 10; num117++)
					{
						int num118 = Dust.NewDust(position, width, height, 57, 0f, 0f, 100, default(Color), 0.5f);
						Main.dust[num118].velocity.X *= 2f;
						Main.dust[num118].velocity.Y *= 2f;
					}
				}
				else if (type == 99)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num119 = 0; num119 < 30; num119++)
					{
						int num120 = Dust.NewDust(position, width, height, 1);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num120].scale *= 1.4f;
						}
						velocity *= 1.9f;
					}
				}
				else if (type == 91 || type == 92)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num121 = 0; num121 < 10; num121++)
					{
						Dust.NewDust(position, width, height, 58, velocity.X * 0.1f, velocity.Y * 0.1f, 150, default(Color), 1.2f);
					}
					for (int num122 = 0; num122 < 3; num122++)
					{
						Gore.NewGore(position, new Vector2(velocity.X * 0.05f, velocity.Y * 0.05f), Main.rand.Next(16, 18));
					}
					if (type == 12 && damage < 500)
					{
						for (int num123 = 0; num123 < 10; num123++)
						{
							Dust.NewDust(position, width, height, 57, velocity.X * 0.1f, velocity.Y * 0.1f, 150, default(Color), 1.2f);
						}
						for (int num124 = 0; num124 < 3; num124++)
						{
							Gore.NewGore(position, new Vector2(velocity.X * 0.05f, velocity.Y * 0.05f), Main.rand.Next(16, 18));
						}
					}
					if ((type == 91 || (type == 92 && ai[0] > 0f)) && owner == Main.myPlayer)
					{
						float x = position.X + (float)Main.rand.Next(-400, 400);
						float y = position.Y - (float)Main.rand.Next(600, 900);
						Vector2 vector6 = new Vector2(x, y);
						float num125 = position.X + (float)(width / 2) - vector6.X;
						float num126 = position.Y + (float)(height / 2) - vector6.Y;
						int num127 = 22;
						float num128 = (float)Math.Sqrt(num125 * num125 + num126 * num126);
						num128 = (float)num127 / num128;
						num125 *= num128;
						num126 *= num128;
						int num129 = damage;
						if (type == 91)
						{
							num129 = (int)((float)num129 * 0.5f);
						}
						int num130 = NewProjectile(x, y, num125, num126, 92, num129, knockBack, owner);
						if (type == 91)
						{
							Main.projectile[num130].ai[1] = position.Y;
							Main.projectile[num130].ai[0] = 1f;
						}
						else
						{
							Main.projectile[num130].ai[1] = position.Y;
						}
					}
				}
				else if (type == 89)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num131 = 0; num131 < 5; num131++)
					{
						int num132 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 68);
						Main.dust[num132].noGravity = true;
						Main.dust[num132].velocity *= 1.5f;
						Main.dust[num132].scale *= 0.9f;
					}
					if (type == 89 && owner == Main.myPlayer)
					{
						for (int num133 = 0; num133 < 3; num133++)
						{
							float num134 = (0f - velocity.X) * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
							float num135 = (0f - velocity.Y) * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
							NewProjectile(position.X + num134, position.Y + num135, num134, num135, 90, (int)((double)damage * 0.5), 0f, owner);
						}
					}
				}
				else if (type == 177)
				{
					for (int num136 = 0; num136 < 20; num136++)
					{
						int num137 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 137, 0f, 0f, Main.rand.Next(0, 101), default(Color), 1f + (float)Main.rand.Next(-20, 40) * 0.01f);
						Main.dust[num137].velocity -= lastVelocity * 0.2f;
						if (Main.rand.Next(3) == 0)
						{
							Main.dust[num137].scale *= 0.8f;
							Main.dust[num137].velocity *= 0.5f;
						}
						else
						{
							Main.dust[num137].noGravity = true;
						}
					}
				}
				else if (type == 119 || type == 118 || type == 128 || type == 359)
				{
					int num138 = 10;
					if (type == 119 || type == 359)
					{
						num138 = 20;
					}
					Main.PlaySound(2, (int)position.X, (int)position.Y, 27);
					for (int num139 = 0; num139 < num138; num139++)
					{
						int num140 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 92);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num140].velocity *= 2f;
							Main.dust[num140].noGravity = true;
							Main.dust[num140].scale *= 1.75f;
						}
						else
						{
							Main.dust[num140].scale *= 0.5f;
						}
					}
				}
				else if (type == 309)
				{
					int num141 = 10;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 27);
					for (int num142 = 0; num142 < num141; num142++)
					{
						int num143 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 185);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num143].velocity *= 2f;
							Main.dust[num143].noGravity = true;
							Main.dust[num143].scale *= 1.75f;
						}
					}
				}
				else if (type == 308)
				{
					int num144 = 80;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 27);
					for (int num145 = 0; num145 < num144; num145++)
					{
						int num146 = Dust.NewDust(new Vector2(position.X, position.Y + 16f), width, height - 16, 185);
						Main.dust[num146].velocity *= 2f;
						Main.dust[num146].noGravity = true;
						Main.dust[num146].scale *= 1.15f;
					}
				}
				else if (aiStyle == 29)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					int num147 = type - 121 + 86;
					for (int num148 = 0; num148 < 15; num148++)
					{
						int num149 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, num147, lastVelocity.X, lastVelocity.Y, 50, default(Color), 1.2f);
						Main.dust[num149].noGravity = true;
						Main.dust[num149].scale *= 1.25f;
						Main.dust[num149].velocity *= 0.5f;
					}
				}
				else if (type == 337)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 27);
					for (int num150 = 0; num150 < 10; num150++)
					{
						int num151 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 197);
						Main.dust[num151].noGravity = true;
					}
				}
				else if (type == 379 || type == 377)
				{
					for (int num152 = 0; num152 < 5; num152++)
					{
						int num153 = Dust.NewDust(position, width, height, 171, 0f, 0f, 100);
						Main.dust[num153].scale = (float)Main.rand.Next(1, 10) * 0.1f;
						Main.dust[num153].noGravity = true;
						Main.dust[num153].fadeIn = 1.5f;
						Main.dust[num153].velocity *= 0.75f;
					}
				}
				else if (type == 80)
				{
					if (ai[0] >= 0f)
					{
						Main.PlaySound(2, (int)position.X, (int)position.Y, 27);
						for (int num154 = 0; num154 < 10; num154++)
						{
							Dust.NewDust(new Vector2(position.X, position.Y), width, height, 67);
						}
					}
					int num155 = (int)position.X / 16;
					int num156 = (int)position.Y / 16;
					if (Main.tile[num155, num156] == null)
					{
						Main.tile[num155, num156] = new Tile();
					}
					if (Main.tile[num155, num156].type == 127 && Main.tile[num155, num156].active())
					{
						WorldGen.KillTile(num155, num156);
					}
				}
				else if (type == 76 || type == 77 || type == 78)
				{
					for (int num157 = 0; num157 < 5; num157++)
					{
						int num158 = Dust.NewDust(position, width, height, 27, 0f, 0f, 80, default(Color), 1.5f);
						Main.dust[num158].noGravity = true;
					}
				}
				else if (type == 55)
				{
					for (int num159 = 0; num159 < 5; num159++)
					{
						int num160 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 18, 0f, 0f, 0, default(Color), 1.5f);
						Main.dust[num160].noGravity = true;
					}
				}
				else if (type == 51 || type == 267)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num161 = 0; num161 < 5; num161++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 0, 0f, 0f, 0, default(Color), 0.7f);
					}
				}
				else if (type == 2 || type == 82)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num162 = 0; num162 < 20; num162++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100);
					}
				}
				else if (type == 172)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num163 = 0; num163 < 20; num163++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 135, 0f, 0f, 100);
					}
				}
				else if (type == 103)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num164 = 0; num164 < 20; num164++)
					{
						int num165 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 75, 0f, 0f, 100);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num165].scale *= 2.5f;
							Main.dust[num165].noGravity = true;
							Main.dust[num165].velocity *= 5f;
						}
					}
				}
				else if (type == 278)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num166 = 0; num166 < 20; num166++)
					{
						int num167 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 169, 0f, 0f, 100);
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num167].scale *= 1.5f;
							Main.dust[num167].noGravity = true;
							Main.dust[num167].velocity *= 5f;
						}
					}
				}
				else if (type == 3 || type == 48 || type == 54)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num168 = 0; num168 < 10; num168++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 1, velocity.X * 0.1f, velocity.Y * 0.1f, 0, default(Color), 0.75f);
					}
				}
				else if (type == 330)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num169 = 0; num169 < 10; num169++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 0, velocity.X * 0.4f, velocity.Y * 0.4f, 0, default(Color), 0.75f);
					}
				}
				else if (type == 4)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num170 = 0; num170 < 10; num170++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 14, 0f, 0f, 150, default(Color), 1.1f);
					}
				}
				else if (type == 5)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num171 = 0; num171 < 60; num171++)
					{
						int num172;
						switch (Main.rand.Next(3))
						{
						case 0:
							num172 = 15;
							break;
						case 1:
							num172 = 57;
							break;
						default:
							num172 = 58;
							break;
						}
						Dust.NewDust(position, width, height, num172, velocity.X * 0.5f, velocity.Y * 0.5f, 150, default(Color), 1.5f);
					}
				}
				else if (type == 9 || type == 12)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num173 = 0; num173 < 10; num173++)
					{
						Dust.NewDust(position, width, height, 58, velocity.X * 0.1f, velocity.Y * 0.1f, 150, default(Color), 1.2f);
					}
					for (int num174 = 0; num174 < 3; num174++)
					{
						Gore.NewGore(position, new Vector2(velocity.X * 0.05f, velocity.Y * 0.05f), Main.rand.Next(16, 18));
					}
					if (type == 12 && damage < 100)
					{
						for (int num175 = 0; num175 < 10; num175++)
						{
							Dust.NewDust(position, width, height, 57, velocity.X * 0.1f, velocity.Y * 0.1f, 150, default(Color), 1.2f);
						}
						for (int num176 = 0; num176 < 3; num176++)
						{
							Gore.NewGore(position, new Vector2(velocity.X * 0.05f, velocity.Y * 0.05f), Main.rand.Next(16, 18));
						}
					}
				}
				else if (type == 281)
				{
					Main.PlaySound(4, (int)position.X, (int)position.Y);
					int num177 = Gore.NewGore(position, new Vector2((float)Main.rand.Next(-20, 21) * 0.2f, (float)Main.rand.Next(-20, 21) * 0.2f), 76);
					Main.gore[num177].velocity -= velocity * 0.5f;
					num177 = Gore.NewGore(new Vector2(position.X, position.Y), new Vector2((float)Main.rand.Next(-20, 21) * 0.2f, (float)Main.rand.Next(-20, 21) * 0.2f), 77);
					Main.gore[num177].velocity -= velocity * 0.5f;
					Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					for (int num178 = 0; num178 < 20; num178++)
					{
						int num179 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num179].velocity *= 1.4f;
					}
					for (int num180 = 0; num180 < 10; num180++)
					{
						int num181 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num181].noGravity = true;
						Main.dust[num181].velocity *= 5f;
						num181 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num181].velocity *= 3f;
					}
					num177 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num177].velocity *= 0.4f;
					Main.gore[num177].velocity.X += 1f;
					Main.gore[num177].velocity.Y += 1f;
					num177 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num177].velocity *= 0.4f;
					Main.gore[num177].velocity.X -= 1f;
					Main.gore[num177].velocity.Y += 1f;
					num177 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num177].velocity *= 0.4f;
					Main.gore[num177].velocity.X += 1f;
					Main.gore[num177].velocity.Y -= 1f;
					num177 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num177].velocity *= 0.4f;
					Main.gore[num177].velocity.X -= 1f;
					Main.gore[num177].velocity.Y -= 1f;
					position.X += width / 2;
					position.Y += height / 2;
					width = 128;
					height = 128;
					position.X -= width / 2;
					position.Y -= height / 2;
					Damage();
				}
				else if (type == 162)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					for (int num182 = 0; num182 < 20; num182++)
					{
						int num183 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num183].velocity *= 1.4f;
					}
					for (int num184 = 0; num184 < 10; num184++)
					{
						int num185 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num185].noGravity = true;
						Main.dust[num185].velocity *= 5f;
						num185 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num185].velocity *= 3f;
					}
					int num186 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num186].velocity *= 0.4f;
					Main.gore[num186].velocity.X += 1f;
					Main.gore[num186].velocity.Y += 1f;
					num186 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num186].velocity *= 0.4f;
					Main.gore[num186].velocity.X -= 1f;
					Main.gore[num186].velocity.Y += 1f;
					num186 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num186].velocity *= 0.4f;
					Main.gore[num186].velocity.X += 1f;
					Main.gore[num186].velocity.Y -= 1f;
					num186 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num186].velocity *= 0.4f;
					Main.gore[num186].velocity.X -= 1f;
					Main.gore[num186].velocity.Y -= 1f;
					position.X += width / 2;
					position.Y += height / 2;
					width = 128;
					height = 128;
					position.X -= width / 2;
					position.Y -= height / 2;
					Damage();
				}
				else if (type == 240)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					for (int num187 = 0; num187 < 20; num187++)
					{
						int num188 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num188].velocity *= 1.4f;
					}
					for (int num189 = 0; num189 < 10; num189++)
					{
						int num190 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num190].noGravity = true;
						Main.dust[num190].velocity *= 5f;
						num190 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num190].velocity *= 3f;
					}
					int num191 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num191].velocity *= 0.4f;
					Main.gore[num191].velocity.X += 1f;
					Main.gore[num191].velocity.Y += 1f;
					num191 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num191].velocity *= 0.4f;
					Main.gore[num191].velocity.X -= 1f;
					Main.gore[num191].velocity.Y += 1f;
					num191 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num191].velocity *= 0.4f;
					Main.gore[num191].velocity.X += 1f;
					Main.gore[num191].velocity.Y -= 1f;
					num191 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num191].velocity *= 0.4f;
					Main.gore[num191].velocity.X -= 1f;
					Main.gore[num191].velocity.Y -= 1f;
					position.X += width / 2;
					position.Y += height / 2;
					width = 96;
					height = 96;
					position.X -= width / 2;
					position.Y -= height / 2;
					Damage();
				}
				else if (type == 283 || type == 282)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num192 = 0; num192 < 10; num192++)
					{
						int num193 = Dust.NewDust(position, width, height, 171, 0f, 0f, 100);
						Main.dust[num193].scale = (float)Main.rand.Next(1, 10) * 0.1f;
						Main.dust[num193].noGravity = true;
						Main.dust[num193].fadeIn = 1.5f;
						Main.dust[num193].velocity *= 0.75f;
					}
				}
				else if (type == 284)
				{
					for (int num194 = 0; num194 < 10; num194++)
					{
						int num195 = Main.rand.Next(139, 143);
						int num196 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, num195, (0f - velocity.X) * 0.3f, (0f - velocity.Y) * 0.3f, 0, default(Color), 1.2f);
						Main.dust[num196].velocity.X += (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.dust[num196].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.dust[num196].velocity.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.dust[num196].velocity.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.dust[num196].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
						Main.dust[num196].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
						Main.dust[num196].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
					}
					for (int num197 = 0; num197 < 5; num197++)
					{
						int num198 = Main.rand.Next(276, 283);
						int num199 = Gore.NewGore(position, -velocity * 0.3f, num198);
						Main.gore[num199].velocity.X += (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.gore[num199].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.gore[num199].velocity.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.gore[num199].velocity.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.gore[num199].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
						Main.gore[num199].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
						Main.gore[num199].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
					}
				}
				else if (type == 286)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					for (int num200 = 0; num200 < 7; num200++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.5f);
					}
					for (int num201 = 0; num201 < 3; num201++)
					{
						int num202 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num202].noGravity = true;
						Main.dust[num202].velocity *= 3f;
						num202 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num202].velocity *= 2f;
					}
					int num203 = Gore.NewGore(new Vector2(position.X - 10f, position.Y - 10f), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num203].velocity *= 0.3f;
					Main.gore[num203].velocity.X += (float)Main.rand.Next(-10, 11) * 0.05f;
					Main.gore[num203].velocity.Y += (float)Main.rand.Next(-10, 11) * 0.05f;
					if (owner == Main.myPlayer)
					{
						localAI[1] = -1f;
						maxPenetrate = 0;
						position.X += width / 2;
						position.Y += height / 2;
						width = 80;
						height = 80;
						position.X -= width / 2;
						position.Y -= height / 2;
						Damage();
					}
				}
				else if (type == 14 || type == 20 || type == 36 || type == 83 || type == 84 || type == 389 || type == 104 || type == 279 || type == 100 || type == 110 || type == 180 || type == 207 || type == 357 || type == 242 || type == 302 || type == 257 || type == 259 || type == 285 || type == 287)
				{
					Collision.HitTiles(position, velocity, width, height);
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
				}
				else if (type == 15 || type == 34 || type == 321)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num204 = 0; num204 < 20; num204++)
					{
						int num205 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, (0f - velocity.X) * 0.2f, (0f - velocity.Y) * 0.2f, 100, default(Color), 2f);
						Main.dust[num205].noGravity = true;
						Main.dust[num205].velocity *= 2f;
						num205 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, (0f - velocity.X) * 0.2f, (0f - velocity.Y) * 0.2f, 100);
						Main.dust[num205].velocity *= 2f;
					}
				}
				else if (type == 253)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num206 = 0; num206 < 20; num206++)
					{
						int num207 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 135, (0f - velocity.X) * 0.2f, (0f - velocity.Y) * 0.2f, 100, default(Color), 2f);
						Main.dust[num207].noGravity = true;
						Main.dust[num207].velocity *= 2f;
						num207 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 135, (0f - velocity.X) * 0.2f, (0f - velocity.Y) * 0.2f, 100);
						Main.dust[num207].velocity *= 2f;
					}
				}
				else if (type == 95 || type == 96)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num208 = 0; num208 < 20; num208++)
					{
						int num209 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 75, (0f - velocity.X) * 0.2f, (0f - velocity.Y) * 0.2f, 100, default(Color), 2f * scale);
						Main.dust[num209].noGravity = true;
						Main.dust[num209].velocity *= 2f;
						num209 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 75, (0f - velocity.X) * 0.2f, (0f - velocity.Y) * 0.2f, 100, default(Color), 1f * scale);
						Main.dust[num209].velocity *= 2f;
					}
				}
				else if (type == 79)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num210 = 0; num210 < 20; num210++)
					{
						int num211 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2f);
						Main.dust[num211].noGravity = true;
						Main.dust[num211].velocity *= 4f;
					}
				}
				else if (type == 16)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num212 = 0; num212 < 20; num212++)
					{
						int num213 = Dust.NewDust(new Vector2(position.X - velocity.X, position.Y - velocity.Y), width, height, 15, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num213].noGravity = true;
						Main.dust[num213].velocity *= 2f;
						num213 = Dust.NewDust(new Vector2(position.X - velocity.X, position.Y - velocity.Y), width, height, 15, 0f, 0f, 100);
					}
				}
				else if (type == 17)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num214 = 0; num214 < 5; num214++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 0);
					}
				}
				else if (type == 31 || type == 42)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num215 = 0; num215 < 5; num215++)
					{
						int num216 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 32);
						Main.dust[num216].velocity *= 0.6f;
					}
				}
				else if (type >= 411 && type <= 414)
				{
					int num217 = 9;
					if (type == 412 || type == 414)
					{
						num217 = 11;
					}
					if (type == 413)
					{
						num217 = 19;
					}
					for (int num218 = 0; num218 < 5; num218++)
					{
						int num219 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, num217, 0f, velocity.Y / 2f);
						Main.dust[num219].noGravity = true;
						Main.dust[num219].velocity -= velocity * 0.5f;
					}
				}
				else if (type == 109)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num220 = 0; num220 < 5; num220++)
					{
						int num221 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 51, 0f, 0f, 0, default(Color), 0.6f);
						Main.dust[num221].velocity *= 0.6f;
					}
				}
				else if (type == 39)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num222 = 0; num222 < 5; num222++)
					{
						int num223 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 38);
						Main.dust[num223].velocity *= 0.6f;
					}
				}
				else if (type == 71)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num224 = 0; num224 < 5; num224++)
					{
						int num225 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 53);
						Main.dust[num225].velocity *= 0.6f;
					}
				}
				else if (type == 40)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num226 = 0; num226 < 5; num226++)
					{
						int num227 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 36);
						Main.dust[num227].velocity *= 0.6f;
					}
				}
				else if (type == 21)
				{
					Main.PlaySound(0, (int)position.X, (int)position.Y);
					for (int num228 = 0; num228 < 10; num228++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 26, 0f, 0f, 0, default(Color), 0.8f);
					}
				}
				else if (type == 24)
				{
					for (int num229 = 0; num229 < 10; num229++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 1, velocity.X * 0.1f, velocity.Y * 0.1f, 0, default(Color), 0.75f);
					}
				}
				else if (type == 27)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num230 = 0; num230 < 30; num230++)
					{
						int num231 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 172, velocity.X * 0.1f, velocity.Y * 0.1f, 100);
						Main.dust[num231].noGravity = true;
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 172, velocity.X * 0.1f, velocity.Y * 0.1f, 100, default(Color), 0.5f);
					}
				}
				else if (type == 38)
				{
					for (int num232 = 0; num232 < 10; num232++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 42, velocity.X * 0.1f, velocity.Y * 0.1f);
					}
				}
				else if (type == 44 || type == 45)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num233 = 0; num233 < 30; num233++)
					{
						int num234 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 27, velocity.X, velocity.Y, 100, default(Color), 1.7f);
						Main.dust[num234].noGravity = true;
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 27, velocity.X, velocity.Y, 100);
					}
				}
				else if (type == 41)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					for (int num235 = 0; num235 < 10; num235++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.5f);
					}
					for (int num236 = 0; num236 < 5; num236++)
					{
						int num237 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num237].noGravity = true;
						Main.dust[num237].velocity *= 3f;
						num237 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num237].velocity *= 2f;
					}
					int num238 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num238].velocity *= 0.4f;
					Main.gore[num238].velocity.X += (float)Main.rand.Next(-10, 11) * 0.1f;
					Main.gore[num238].velocity.Y += (float)Main.rand.Next(-10, 11) * 0.1f;
					num238 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num238].velocity *= 0.4f;
					Main.gore[num238].velocity.X += (float)Main.rand.Next(-10, 11) * 0.1f;
					Main.gore[num238].velocity.Y += (float)Main.rand.Next(-10, 11) * 0.1f;
					if (owner == Main.myPlayer)
					{
						penetrate = -1;
						position.X += width / 2;
						position.Y += height / 2;
						width = 64;
						height = 64;
						position.X -= width / 2;
						position.Y -= height / 2;
						Damage();
					}
				}
				else if (type == 306)
				{
					Main.PlaySound(3, (int)position.X, (int)position.Y);
					for (int num239 = 0; num239 < 20; num239++)
					{
						int num240 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 184);
						Main.dust[num240].scale *= 1.1f;
						Main.dust[num240].noGravity = true;
					}
					for (int num241 = 0; num241 < 30; num241++)
					{
						int num242 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 184);
						Main.dust[num242].velocity *= 2.5f;
						Main.dust[num242].scale *= 0.8f;
						Main.dust[num242].noGravity = true;
					}
					if (owner == Main.myPlayer)
					{
						int num243 = 2;
						if (Main.rand.Next(10) == 0)
						{
							num243++;
						}
						if (Main.rand.Next(10) == 0)
						{
							num243++;
						}
						if (Main.rand.Next(10) == 0)
						{
							num243++;
						}
						for (int num244 = 0; num244 < num243; num244++)
						{
							float num245 = (float)Main.rand.Next(-35, 36) * 0.02f;
							float num246 = (float)Main.rand.Next(-35, 36) * 0.02f;
							num245 *= 10f;
							num246 *= 10f;
							NewProjectile(position.X, position.Y, num245, num246, 307, (int)((double)damage * 0.7), (int)((double)knockBack * 0.35), Main.myPlayer);
						}
					}
				}
				else if (type == 183)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					for (int num247 = 0; num247 < 20; num247++)
					{
						int num248 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num248].velocity *= 1f;
					}
					int num249 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num249].velocity.X += 1f;
					Main.gore[num249].velocity.Y += 1f;
					Main.gore[num249].velocity *= 0.3f;
					num249 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num249].velocity.X -= 1f;
					Main.gore[num249].velocity.Y += 1f;
					Main.gore[num249].velocity *= 0.3f;
					num249 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num249].velocity.X += 1f;
					Main.gore[num249].velocity.Y -= 1f;
					Main.gore[num249].velocity *= 0.3f;
					num249 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num249].velocity.X -= 1f;
					Main.gore[num249].velocity.Y -= 1f;
					Main.gore[num249].velocity *= 0.3f;
					if (owner == Main.myPlayer)
					{
						int num250 = Main.rand.Next(15, 25);
						for (int num251 = 0; num251 < num250; num251++)
						{
							float speedX = (float)Main.rand.Next(-35, 36) * 0.02f;
							float speedY = (float)Main.rand.Next(-35, 36) * 0.02f;
							NewProjectile(position.X, position.Y, speedX, speedY, 181, damage, 0f, Main.myPlayer);
						}
					}
				}
				else if (aiStyle == 34)
				{
					if (owner != Main.myPlayer)
					{
						timeLeft = 60;
					}
					Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					if (type == 167)
					{
						for (int num252 = 0; num252 < 400; num252++)
						{
							float num253 = 16f;
							if (num252 < 300)
							{
								num253 = 12f;
							}
							if (num252 < 200)
							{
								num253 = 8f;
							}
							if (num252 < 100)
							{
								num253 = 4f;
							}
							int num254 = 130;
							int num255 = Dust.NewDust(new Vector2(position.X, position.Y), 6, 6, num254, 0f, 0f, 100);
							float num256 = Main.dust[num255].velocity.X;
							float y2 = Main.dust[num255].velocity.Y;
							if (num256 == 0f && y2 == 0f)
							{
								num256 = 1f;
							}
							float num257 = (float)Math.Sqrt(num256 * num256 + y2 * y2);
							num257 = num253 / num257;
							num256 *= num257;
							y2 *= num257;
							Main.dust[num255].velocity *= 0.5f;
							Main.dust[num255].velocity.X += num256;
							Main.dust[num255].velocity.Y += y2;
							Main.dust[num255].scale = 1.3f;
							Main.dust[num255].noGravity = true;
						}
					}
					if (type == 168)
					{
						for (int num258 = 0; num258 < 400; num258++)
						{
							float num259 = 2f * ((float)num258 / 100f);
							if (num258 > 100)
							{
								num259 = 10f;
							}
							if (num258 > 250)
							{
								num259 = 13f;
							}
							int num260 = 131;
							int num261 = Dust.NewDust(new Vector2(position.X, position.Y), 6, 6, num260, 0f, 0f, 100);
							float num262 = Main.dust[num261].velocity.X;
							float y3 = Main.dust[num261].velocity.Y;
							if (num262 == 0f && y3 == 0f)
							{
								num262 = 1f;
							}
							float num263 = (float)Math.Sqrt(num262 * num262 + y3 * y3);
							num263 = num259 / num263;
							if (num258 <= 200)
							{
								num262 *= num263;
								y3 *= num263;
							}
							else
							{
								num262 = num262 * num263 * 1.25f;
								y3 = y3 * num263 * 0.75f;
							}
							Main.dust[num261].velocity *= 0.5f;
							Main.dust[num261].velocity.X += num262;
							Main.dust[num261].velocity.Y += y3;
							if (num258 > 100)
							{
								Main.dust[num261].scale = 1.3f;
								Main.dust[num261].noGravity = true;
							}
						}
					}
					if (type == 169)
					{
						Vector2 vector7 = ((float)Main.rand.NextDouble() * ((float)Math.PI * 2f)).ToRotationVector2();
						float num264 = Main.rand.Next(5, 9);
						float num265 = Main.rand.Next(12, 17);
						float value = Main.rand.Next(3, 7);
						float num266 = 20f;
						for (float num267 = 0f; num267 < num264; num267 += 1f)
						{
							for (int num268 = 0; num268 < 2; num268++)
							{
								Vector2 value2 = vector7.Rotate(((num268 == 0) ? 1f : (-1f)) * ((float)Math.PI * 2f) / (num264 * 2f));
								for (float num269 = 0f; num269 < num266; num269 += 1f)
								{
									Vector2 vector8 = Vector2.Lerp(vector7, value2, num269 / num266);
									float num270 = MathHelper.Lerp(num265, value, num269 / num266);
									int num271 = Dust.NewDust(new Vector2(position.X, position.Y), 6, 6, 133, 0f, 0f, 100, default(Color), 1.3f);
									Main.dust[num271].velocity *= 0.1f;
									Main.dust[num271].noGravity = true;
									Main.dust[num271].velocity += vector8 * num270;
								}
							}
							vector7 = vector7.Rotate((float)Math.PI * 2f / num264);
						}
						for (float num272 = 0f; num272 < num264; num272 += 1f)
						{
							for (int num273 = 0; num273 < 2; num273++)
							{
								Vector2 value3 = vector7.Rotate(((num273 == 0) ? 1f : (-1f)) * ((float)Math.PI * 2f) / (num264 * 2f));
								for (float num274 = 0f; num274 < num266; num274 += 1f)
								{
									Vector2 vector9 = Vector2.Lerp(vector7, value3, num274 / num266);
									float num275 = MathHelper.Lerp(num265, value, num274 / num266) / 2f;
									int num276 = Dust.NewDust(new Vector2(position.X, position.Y), 6, 6, 133, 0f, 0f, 100, default(Color), 1.3f);
									Main.dust[num276].velocity *= 0.1f;
									Main.dust[num276].noGravity = true;
									Main.dust[num276].velocity += vector9 * num275;
								}
							}
							vector7 = vector7.Rotate((float)Math.PI * 2f / num264);
						}
						for (int num277 = 0; num277 < 100; num277++)
						{
							float num278 = num265;
							int num279 = 132;
							int num280 = Dust.NewDust(new Vector2(position.X, position.Y), 6, 6, num279, 0f, 0f, 100);
							float num281 = Main.dust[num280].velocity.X;
							float y4 = Main.dust[num280].velocity.Y;
							if (num281 == 0f && y4 == 0f)
							{
								num281 = 1f;
							}
							float num282 = (float)Math.Sqrt(num281 * num281 + y4 * y4);
							num282 = num278 / num282;
							num281 *= num282;
							y4 *= num282;
							Main.dust[num280].velocity *= 0.5f;
							Main.dust[num280].velocity.X += num281;
							Main.dust[num280].velocity.Y += y4;
							Main.dust[num280].scale = 1.3f;
							Main.dust[num280].noGravity = true;
						}
					}
					if (type == 170)
					{
						for (int num283 = 0; num283 < 400; num283++)
						{
							int num284 = 133;
							float num285 = 16f;
							if (num283 > 100)
							{
								num285 = 11f;
							}
							if (num283 > 100)
							{
								num284 = 134;
							}
							if (num283 > 200)
							{
								num285 = 8f;
							}
							if (num283 > 200)
							{
								num284 = 133;
							}
							if (num283 > 300)
							{
								num285 = 5f;
							}
							if (num283 > 300)
							{
								num284 = 134;
							}
							int num286 = Dust.NewDust(new Vector2(position.X, position.Y), 6, 6, num284, 0f, 0f, 100);
							float num287 = Main.dust[num286].velocity.X;
							float y5 = Main.dust[num286].velocity.Y;
							if (num287 == 0f && y5 == 0f)
							{
								num287 = 1f;
							}
							float num288 = (float)Math.Sqrt(num287 * num287 + y5 * y5);
							num288 = num285 / num288;
							if (num283 > 300)
							{
								num287 = num287 * num288 * 0.7f;
								y5 *= num288;
							}
							else if (num283 > 200)
							{
								num287 *= num288;
								y5 = y5 * num288 * 0.7f;
							}
							else if (num283 > 100)
							{
								num287 = num287 * num288 * 0.7f;
								y5 *= num288;
							}
							else
							{
								num287 *= num288;
								y5 = y5 * num288 * 0.7f;
							}
							Main.dust[num286].velocity *= 0.5f;
							Main.dust[num286].velocity.X += num287;
							Main.dust[num286].velocity.Y += y5;
							if (Main.rand.Next(3) != 0)
							{
								Main.dust[num286].scale = 1.3f;
								Main.dust[num286].noGravity = true;
							}
						}
					}
					if (type == 415)
					{
						Vector2 vector10 = (vector10 = ((float)Main.rand.NextDouble() * ((float)Math.PI * 2f)).ToRotationVector2());
						float num289 = Main.rand.Next(5, 9);
						float num290 = (float)Main.rand.Next(10, 15) * 0.66f;
						float num291 = (float)Main.rand.Next(4, 7) / 2f;
						int num292 = 30;
						for (int num293 = 0; (float)num293 < (float)num292 * num289; num293++)
						{
							if (num293 % num292 == 0)
							{
								vector10 = vector10.Rotate((float)Math.PI * 2f / num289);
							}
							float num294 = MathHelper.Lerp(num291, num290, (float)(num293 % num292) / (float)num292);
							int num295 = 130;
							int num296 = Dust.NewDust(new Vector2(position.X, position.Y), 6, 6, num295, 0f, 0f, 100);
							Main.dust[num296].velocity *= 0.1f;
							Main.dust[num296].velocity += vector10 * num294;
							Main.dust[num296].scale = 1.3f;
							Main.dust[num296].noGravity = true;
						}
						for (int num297 = 0; num297 < 100; num297++)
						{
							float num298 = num290;
							if (num297 < 30)
							{
								num298 = (num291 + num290) / 2f;
							}
							int num299 = 130;
							int num300 = Dust.NewDust(new Vector2(position.X, position.Y), 6, 6, num299, 0f, 0f, 100);
							float num301 = Main.dust[num300].velocity.X;
							float y6 = Main.dust[num300].velocity.Y;
							if (num301 == 0f && y6 == 0f)
							{
								num301 = 1f;
							}
							float num302 = (float)Math.Sqrt(num301 * num301 + y6 * y6);
							num302 = num298 / num302;
							num301 *= num302;
							y6 *= num302;
							Main.dust[num300].velocity *= 0.5f;
							Main.dust[num300].velocity.X += num301;
							Main.dust[num300].velocity.Y += y6;
							Main.dust[num300].scale = 1.3f;
							Main.dust[num300].noGravity = true;
						}
					}
					if (type == 416)
					{
						Vector2 vector11 = ((float)Main.rand.NextDouble() * ((float)Math.PI * 2f)).ToRotationVector2();
						Vector2 vector12 = vector11;
						float num303 = Main.rand.Next(3, 6) * 2;
						int num304 = 20;
						float num305 = ((Main.rand.Next(2) == 0) ? 1f : (-1f));
						bool flag = true;
						for (int num306 = 0; (float)num306 < (float)num304 * num303; num306++)
						{
							if (num306 % num304 == 0)
							{
								vector12 = vector12.Rotate(num305 * ((float)Math.PI * 2f / num303));
								vector11 = vector12;
								flag = !flag;
							}
							else
							{
								float num307 = (float)Math.PI * 2f / ((float)num304 * num303);
								vector11 = vector11.Rotate(num307 * num305 * 3f);
							}
							float num308 = MathHelper.Lerp(1f, 8f, (float)(num306 % num304) / (float)num304);
							int num309 = 131;
							int num310 = Dust.NewDust(new Vector2(position.X, position.Y), 6, 6, num309, 0f, 0f, 100, default(Color), 1.4f);
							Main.dust[num310].velocity *= 0.1f;
							Main.dust[num310].velocity += vector11 * num308;
							if (flag)
							{
								Main.dust[num310].scale = 0.9f;
							}
							Main.dust[num310].noGravity = true;
						}
					}
					if (type == 417)
					{
						float num311 = (float)Main.rand.NextDouble() * ((float)Math.PI * 2f);
						float num312 = (float)Main.rand.NextDouble() * ((float)Math.PI * 2f);
						float num313 = 4f + (float)Main.rand.NextDouble() * 3f;
						float num314 = 4f + (float)Main.rand.NextDouble() * 3f;
						float num315 = num313;
						if (num314 > num315)
						{
							num315 = num314;
						}
						for (int num316 = 0; num316 < 150; num316++)
						{
							int num317 = 132;
							float num318 = num315;
							if (num316 > 50)
							{
								num318 = num314;
							}
							if (num316 > 50)
							{
								num317 = 133;
							}
							if (num316 > 100)
							{
								num318 = num313;
							}
							if (num316 > 100)
							{
								num317 = 132;
							}
							int num319 = Dust.NewDust(new Vector2(position.X, position.Y), 6, 6, num317, 0f, 0f, 100);
							Vector2 vector13 = Main.dust[num319].velocity;
							vector13.Normalize();
							vector13 *= num318;
							if (num316 > 100)
							{
								vector13.X *= 0.5f;
								vector13 = vector13.Rotate(num311);
							}
							else if (num316 > 50)
							{
								vector13.Y *= 0.5f;
								vector13 = vector13.Rotate(num312);
							}
							Main.dust[num319].velocity *= 0.2f;
							Main.dust[num319].velocity += vector13;
							if (num316 <= 200)
							{
								Main.dust[num319].scale = 1.3f;
								Main.dust[num319].noGravity = true;
							}
						}
					}
					if (type == 418)
					{
						Vector2 vector14 = ((float)Main.rand.NextDouble() * ((float)Math.PI * 2f)).ToRotationVector2();
						float num320 = Main.rand.Next(5, 12);
						float num321 = (float)Main.rand.Next(9, 14) * 0.66f;
						float num322 = (float)Main.rand.Next(2, 4) * 0.66f;
						float num323 = 15f;
						for (float num324 = 0f; num324 < num320; num324 += 1f)
						{
							for (int num325 = 0; num325 < 2; num325++)
							{
								Vector2 value4 = vector14.Rotate(((num325 == 0) ? 1f : (-1f)) * ((float)Math.PI * 2f) / (num320 * 2f));
								for (float num326 = 0f; num326 < num323; num326 += 1f)
								{
									Vector2 vector15 = Vector2.SmoothStep(vector14, value4, num326 / num323);
									float num327 = MathHelper.SmoothStep(num321, num322, num326 / num323);
									int num328 = Dust.NewDust(new Vector2(position.X, position.Y), 6, 6, 134, 0f, 0f, 100, default(Color), 1.3f);
									Main.dust[num328].velocity *= 0.1f;
									Main.dust[num328].noGravity = true;
									Main.dust[num328].velocity += vector15 * num327;
								}
							}
							vector14 = vector14.Rotate((float)Math.PI * 2f / num320);
						}
						for (int num329 = 0; num329 < 120; num329++)
						{
							float num330 = num321;
							int num331 = 133;
							if (num329 < 80)
							{
								num330 = num322 - 0.5f;
							}
							else
							{
								num331 = 131;
							}
							int num332 = Dust.NewDust(new Vector2(position.X, position.Y), 6, 6, num331, 0f, 0f, 100);
							float num333 = Main.dust[num332].velocity.X;
							float y7 = Main.dust[num332].velocity.Y;
							if (num333 == 0f && y7 == 0f)
							{
								num333 = 1f;
							}
							float num334 = (float)Math.Sqrt(num333 * num333 + y7 * y7);
							num334 = num330 / num334;
							num333 *= num334;
							y7 *= num334;
							Main.dust[num332].velocity *= 0.2f;
							Main.dust[num332].velocity.X += num333;
							Main.dust[num332].velocity.Y += y7;
							Main.dust[num332].scale = 1.3f;
							Main.dust[num332].noGravity = true;
						}
					}
					position.X += width / 2;
					position.Y += height / 2;
					width = 192;
					height = 192;
					position.X -= width / 2;
					position.Y -= height / 2;
					penetrate = -1;
					Damage();
				}
				else if (type == 312)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					position.X += width / 2;
					position.Y += height / 2;
					width = 22;
					height = 22;
					position.X -= width / 2;
					position.Y -= height / 2;
					for (int num335 = 0; num335 < 30; num335++)
					{
						int num336 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num336].velocity *= 1.4f;
					}
					for (int num337 = 0; num337 < 20; num337++)
					{
						int num338 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 3.5f);
						Main.dust[num338].noGravity = true;
						Main.dust[num338].velocity *= 7f;
						num338 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num338].velocity *= 3f;
					}
					for (int num339 = 0; num339 < 2; num339++)
					{
						float num340 = 0.4f;
						if (num339 == 1)
						{
							num340 = 0.8f;
						}
						int num341 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num341].velocity *= num340;
						Main.gore[num341].velocity.X += 1f;
						Main.gore[num341].velocity.Y += 1f;
						num341 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num341].velocity *= num340;
						Main.gore[num341].velocity.X -= 1f;
						Main.gore[num341].velocity.Y += 1f;
						num341 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num341].velocity *= num340;
						Main.gore[num341].velocity.X += 1f;
						Main.gore[num341].velocity.Y -= 1f;
						num341 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num341].velocity *= num340;
						Main.gore[num341].velocity.X -= 1f;
						Main.gore[num341].velocity.Y -= 1f;
					}
					position.X += width / 2;
					position.Y += height / 2;
					width = 128;
					height = 128;
					position.X -= width / 2;
					position.Y -= height / 2;
					Damage();
				}
				else if (type == 133 || type == 134 || type == 135 || type == 136 || type == 137 || type == 138 || type == 303 || type == 338 || type == 339)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					position.X += width / 2;
					position.Y += height / 2;
					width = 22;
					height = 22;
					position.X -= width / 2;
					position.Y -= height / 2;
					for (int num342 = 0; num342 < 30; num342++)
					{
						int num343 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num343].velocity *= 1.4f;
					}
					for (int num344 = 0; num344 < 20; num344++)
					{
						int num345 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 3.5f);
						Main.dust[num345].noGravity = true;
						Main.dust[num345].velocity *= 7f;
						num345 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num345].velocity *= 3f;
					}
					for (int num346 = 0; num346 < 2; num346++)
					{
						float num347 = 0.4f;
						if (num346 == 1)
						{
							num347 = 0.8f;
						}
						int num348 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num348].velocity *= num347;
						Main.gore[num348].velocity.X += 1f;
						Main.gore[num348].velocity.Y += 1f;
						num348 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num348].velocity *= num347;
						Main.gore[num348].velocity.X -= 1f;
						Main.gore[num348].velocity.Y += 1f;
						num348 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num348].velocity *= num347;
						Main.gore[num348].velocity.X += 1f;
						Main.gore[num348].velocity.Y -= 1f;
						num348 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num348].velocity *= num347;
						Main.gore[num348].velocity.X -= 1f;
						Main.gore[num348].velocity.Y -= 1f;
					}
				}
				else if (type == 139 || type == 140 || type == 141 || type == 142 || type == 143 || type == 144 || type == 340 || type == 341)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					position.X += width / 2;
					position.Y += height / 2;
					width = 80;
					height = 80;
					position.X -= width / 2;
					position.Y -= height / 2;
					for (int num349 = 0; num349 < 40; num349++)
					{
						int num350 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num350].velocity *= 3f;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num350].scale = 0.5f;
							Main.dust[num350].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
						}
					}
					for (int num351 = 0; num351 < 70; num351++)
					{
						int num352 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 3f);
						Main.dust[num352].noGravity = true;
						Main.dust[num352].velocity *= 5f;
						num352 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num352].velocity *= 2f;
					}
					for (int num353 = 0; num353 < 3; num353++)
					{
						float num354 = 0.33f;
						if (num353 == 1)
						{
							num354 = 0.66f;
						}
						if (num353 == 2)
						{
							num354 = 1f;
						}
						int num355 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 24f, position.Y + (float)(height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num355].velocity *= num354;
						Main.gore[num355].velocity.X += 1f;
						Main.gore[num355].velocity.Y += 1f;
						num355 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 24f, position.Y + (float)(height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num355].velocity *= num354;
						Main.gore[num355].velocity.X -= 1f;
						Main.gore[num355].velocity.Y += 1f;
						num355 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 24f, position.Y + (float)(height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num355].velocity *= num354;
						Main.gore[num355].velocity.X += 1f;
						Main.gore[num355].velocity.Y -= 1f;
						num355 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 24f, position.Y + (float)(height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num355].velocity *= num354;
						Main.gore[num355].velocity.X -= 1f;
						Main.gore[num355].velocity.Y -= 1f;
					}
					position.X += width / 2;
					position.Y += height / 2;
					width = 10;
					height = 10;
					position.X -= width / 2;
					position.Y -= height / 2;
				}
				else if (type == 246)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					for (int num356 = 0; num356 < 10; num356++)
					{
						int num357 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num357].velocity *= 0.9f;
					}
					for (int num358 = 0; num358 < 5; num358++)
					{
						int num359 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num359].noGravity = true;
						Main.dust[num359].velocity *= 3f;
						num359 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num359].velocity *= 2f;
					}
					int num360 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num360].velocity *= 0.3f;
					Main.gore[num360].velocity.X += Main.rand.Next(-1, 2);
					Main.gore[num360].velocity.Y += Main.rand.Next(-1, 2);
					position.X += width / 2;
					position.Y += height / 2;
					width = 150;
					height = 150;
					position.X -= width / 2;
					position.Y -= height / 2;
					penetrate = -1;
					maxPenetrate = 0;
					Damage();
					if (owner == Main.myPlayer)
					{
						int num361 = Main.rand.Next(2, 6);
						for (int num362 = 0; num362 < num361; num362++)
						{
							float num363 = Main.rand.Next(-100, 101);
							num363 += 0.01f;
							float num364 = Main.rand.Next(-100, 101);
							num363 -= 0.01f;
							float num365 = (float)Math.Sqrt(num363 * num363 + num364 * num364);
							num365 = 8f / num365;
							num363 *= num365;
							num364 *= num365;
							int num366 = NewProjectile(center().X - lastVelocity.X, center().Y - lastVelocity.Y, num363, num364, 249, damage, knockBack, owner);
							Main.projectile[num366].maxPenetrate = 0;
						}
					}
				}
				else if (type == 249)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					for (int num367 = 0; num367 < 7; num367++)
					{
						int num368 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num368].velocity *= 0.8f;
					}
					for (int num369 = 0; num369 < 2; num369++)
					{
						int num370 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num370].noGravity = true;
						Main.dust[num370].velocity *= 2.5f;
						num370 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num370].velocity *= 1.5f;
					}
					int num371 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num371].velocity *= 0.2f;
					Main.gore[num371].velocity.X += Main.rand.Next(-1, 2);
					Main.gore[num371].velocity.Y += Main.rand.Next(-1, 2);
					position.X += width / 2;
					position.Y += height / 2;
					width = 100;
					height = 100;
					position.X -= width / 2;
					position.Y -= height / 2;
					penetrate = -1;
					Damage();
				}
				else if (type == 28 || type == 30 || type == 37 || type == 75 || type == 102 || type == 164 || type == 397)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					position.X += width / 2;
					position.Y += height / 2;
					width = 22;
					height = 22;
					position.X -= width / 2;
					position.Y -= height / 2;
					for (int num372 = 0; num372 < 20; num372++)
					{
						int num373 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num373].velocity *= 1.4f;
					}
					for (int num374 = 0; num374 < 10; num374++)
					{
						int num375 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2.5f);
						Main.dust[num375].noGravity = true;
						Main.dust[num375].velocity *= 5f;
						num375 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num375].velocity *= 3f;
					}
					int num376 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num376].velocity *= 0.4f;
					Main.gore[num376].velocity.X += 1f;
					Main.gore[num376].velocity.Y += 1f;
					num376 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num376].velocity *= 0.4f;
					Main.gore[num376].velocity.X -= 1f;
					Main.gore[num376].velocity.Y += 1f;
					num376 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num376].velocity *= 0.4f;
					Main.gore[num376].velocity.X += 1f;
					Main.gore[num376].velocity.Y -= 1f;
					num376 = Gore.NewGore(new Vector2(position.X, position.Y), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num376].velocity *= 0.4f;
					Main.gore[num376].velocity.X -= 1f;
					Main.gore[num376].velocity.Y -= 1f;
				}
				else if (type == 29 || type == 108)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 14);
					if (type == 29)
					{
						position.X += width / 2;
						position.Y += height / 2;
						width = 200;
						height = 200;
						position.X -= width / 2;
						position.Y -= height / 2;
					}
					for (int num377 = 0; num377 < 50; num377++)
					{
						int num378 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num378].velocity *= 1.4f;
					}
					for (int num379 = 0; num379 < 80; num379++)
					{
						int num380 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 3f);
						Main.dust[num380].noGravity = true;
						Main.dust[num380].velocity *= 5f;
						num380 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 6, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num380].velocity *= 3f;
					}
					for (int num381 = 0; num381 < 2; num381++)
					{
						int num382 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 24f, position.Y + (float)(height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num382].scale = 1.5f;
						Main.gore[num382].velocity.X += 1.5f;
						Main.gore[num382].velocity.Y += 1.5f;
						num382 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 24f, position.Y + (float)(height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num382].scale = 1.5f;
						Main.gore[num382].velocity.X -= 1.5f;
						Main.gore[num382].velocity.Y += 1.5f;
						num382 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 24f, position.Y + (float)(height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num382].scale = 1.5f;
						Main.gore[num382].velocity.X += 1.5f;
						Main.gore[num382].velocity.Y -= 1.5f;
						num382 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 24f, position.Y + (float)(height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64));
						Main.gore[num382].scale = 1.5f;
						Main.gore[num382].velocity.X -= 1.5f;
						Main.gore[num382].velocity.Y -= 1.5f;
					}
					position.X += width / 2;
					position.Y += height / 2;
					width = 10;
					height = 10;
					position.X -= width / 2;
					position.Y -= height / 2;
				}
				else if (type == 69)
				{
					Main.PlaySound(13, (int)position.X, (int)position.Y);
					for (int num383 = 0; num383 < 5; num383++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 13);
					}
					for (int num384 = 0; num384 < 30; num384++)
					{
						int num385 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 33, 0f, -2f, 0, default(Color), 1.1f);
						Main.dust[num385].alpha = 100;
						Main.dust[num385].velocity.X *= 1.5f;
						Main.dust[num385].velocity *= 3f;
					}
				}
				else if (type == 70)
				{
					Main.PlaySound(13, (int)position.X, (int)position.Y);
					for (int num386 = 0; num386 < 5; num386++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 13);
					}
					for (int num387 = 0; num387 < 30; num387++)
					{
						int num388 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 52, 0f, -2f, 0, default(Color), 1.1f);
						Main.dust[num388].alpha = 100;
						Main.dust[num388].velocity.X *= 1.5f;
						Main.dust[num388].velocity *= 3f;
					}
				}
				else if (type == 114 || type == 115)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num389 = 4; num389 < 31; num389++)
					{
						float num390 = lastVelocity.X * (30f / (float)num389);
						float num391 = lastVelocity.Y * (30f / (float)num389);
						int num392 = Dust.NewDust(new Vector2(position.X - num390, position.Y - num391), 8, 8, 27, lastVelocity.X, lastVelocity.Y, 100, default(Color), 1.4f);
						Main.dust[num392].noGravity = true;
						Main.dust[num392].velocity *= 0.5f;
						num392 = Dust.NewDust(new Vector2(position.X - num390, position.Y - num391), 8, 8, 27, lastVelocity.X, lastVelocity.Y, 100, default(Color), 0.9f);
						Main.dust[num392].velocity *= 0.5f;
					}
				}
				else if (type == 116)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num393 = 4; num393 < 31; num393++)
					{
						float num394 = lastVelocity.X * (30f / (float)num393);
						float num395 = lastVelocity.Y * (30f / (float)num393);
						int num396 = Dust.NewDust(new Vector2(position.X - num394, position.Y - num395), 8, 8, 64, lastVelocity.X, lastVelocity.Y, 100, default(Color), 1.8f);
						Main.dust[num396].noGravity = true;
						num396 = Dust.NewDust(new Vector2(position.X - num394, position.Y - num395), 8, 8, 64, lastVelocity.X, lastVelocity.Y, 100, default(Color), 1.4f);
						Main.dust[num396].noGravity = true;
					}
				}
				else if (type == 173)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num397 = 4; num397 < 24; num397++)
					{
						float num398 = lastVelocity.X * (30f / (float)num397);
						float num399 = lastVelocity.Y * (30f / (float)num397);
						int num400;
						switch (Main.rand.Next(3))
						{
						case 0:
							num400 = 15;
							break;
						case 1:
							num400 = 57;
							break;
						default:
							num400 = 58;
							break;
						}
						int num401 = Dust.NewDust(new Vector2(position.X - num398, position.Y - num399), 8, 8, num400, lastVelocity.X * 0.2f, lastVelocity.Y * 0.2f, 100, default(Color), 1.8f);
						Main.dust[num401].velocity *= 1.5f;
						Main.dust[num401].noGravity = true;
					}
				}
				else if (type == 132)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num402 = 4; num402 < 31; num402++)
					{
						float num403 = lastVelocity.X * (30f / (float)num402);
						float num404 = lastVelocity.Y * (30f / (float)num402);
						int num405 = Dust.NewDust(new Vector2(lastPosition.X - num403, lastPosition.Y - num404), 8, 8, 107, lastVelocity.X, lastVelocity.Y, 100, default(Color), 1.8f);
						Main.dust[num405].noGravity = true;
						Main.dust[num405].velocity *= 0.5f;
						num405 = Dust.NewDust(new Vector2(lastPosition.X - num403, lastPosition.Y - num404), 8, 8, 107, lastVelocity.X, lastVelocity.Y, 100, default(Color), 1.4f);
						Main.dust[num405].velocity *= 0.05f;
					}
				}
				else if (type == 156)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num406 = 4; num406 < 31; num406++)
					{
						float num407 = lastVelocity.X * (30f / (float)num406);
						float num408 = lastVelocity.Y * (30f / (float)num406);
						int num409 = Dust.NewDust(new Vector2(lastPosition.X - num407, lastPosition.Y - num408), 8, 8, 73, lastVelocity.X, lastVelocity.Y, 255, default(Color), 1.8f);
						Main.dust[num409].noGravity = true;
						Main.dust[num409].velocity *= 0.5f;
						num409 = Dust.NewDust(new Vector2(lastPosition.X - num407, lastPosition.Y - num408), 8, 8, 73, lastVelocity.X, lastVelocity.Y, 255, default(Color), 1.4f);
						Main.dust[num409].velocity *= 0.05f;
						Main.dust[num409].noGravity = true;
					}
				}
				else if (type == 157)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
					for (int num410 = 4; num410 < 31; num410++)
					{
						int num411 = Dust.NewDust(position, width, height, 107, lastVelocity.X, lastVelocity.Y, 100, default(Color), 1.8f);
						Main.dust[num411].noGravity = true;
						Main.dust[num411].velocity *= 0.5f;
					}
				}
				else if (type == 370)
				{
					Main.PlaySound(2, (int)position.X, (int)position.Y, 4);
					for (int num412 = 0; num412 < 5; num412++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 13);
					}
					for (int num413 = 0; num413 < 30; num413++)
					{
						Vector2 vector16 = new Vector2(Main.rand.Next(-10, 11), Main.rand.Next(-10, 11));
						vector16.Normalize();
						int num414 = Gore.NewGore(center() + vector16 * 10f, vector16 * Main.rand.Next(4, 9) * 0.66f + Vector2.UnitY * 1.5f, 331, (float)Main.rand.Next(40, 141) * 0.01f);
						Main.gore[num414].sticky = false;
					}
				}
				else if (type == 371)
				{
					Main.PlaySound(13, (int)position.X, (int)position.Y);
					Main.PlaySound(2, (int)position.X, (int)position.Y, 16);
					for (int num415 = 0; num415 < 5; num415++)
					{
						Dust.NewDust(new Vector2(position.X, position.Y), width, height, 13);
					}
					for (int num416 = 0; num416 < 30; num416++)
					{
						Vector2 vector17 = new Vector2(Main.rand.Next(-10, 11), Main.rand.Next(-10, 11));
						vector17.Normalize();
						vector17 *= 0.4f;
						int num417 = Gore.NewGore(center() + vector17 * 10f, vector17 * Main.rand.Next(4, 9) * 0.66f + Vector2.UnitY * 1.5f, Main.rand.Next(435, 438), (float)Main.rand.Next(20, 100) * 0.01f);
						Main.gore[num417].sticky = false;
					}
				}
			}
			if (owner == Main.myPlayer)
			{
				if (type == 28 || type == 29 || type == 37 || type == 108 || type == 136 || type == 137 || type == 138 || type == 142 || type == 143 || type == 144 || type == 339 || type == 341)
				{
					int num418 = 3;
					if (type == 28 || type == 37)
					{
						num418 = 4;
					}
					if (type == 29)
					{
						num418 = 7;
					}
					if (type == 142 || type == 143 || type == 144 || type == 341)
					{
						num418 = 5;
					}
					if (type == 108)
					{
						num418 = 10;
					}
					int num419 = (int)(position.X / 16f - (float)num418);
					int num420 = (int)(position.X / 16f + (float)num418);
					int num421 = (int)(position.Y / 16f - (float)num418);
					int num422 = (int)(position.Y / 16f + (float)num418);
					if (num419 < 0)
					{
						num419 = 0;
					}
					if (num420 > Main.maxTilesX)
					{
						num420 = Main.maxTilesX;
					}
					if (num421 < 0)
					{
						num421 = 0;
					}
					if (num422 > Main.maxTilesY)
					{
						num422 = Main.maxTilesY;
					}
					bool flag2 = false;
					for (int num423 = num419; num423 <= num420; num423++)
					{
						for (int num424 = num421; num424 <= num422; num424++)
						{
							float num425 = Math.Abs((float)num423 - position.X / 16f);
							float num426 = Math.Abs((float)num424 - position.Y / 16f);
							double num427 = Math.Sqrt(num425 * num425 + num426 * num426);
							if (num427 < (double)num418 && Main.tile[num423, num424] != null && Main.tile[num423, num424].wall == 0)
							{
								flag2 = true;
								break;
							}
						}
					}
					for (int num428 = num419; num428 <= num420; num428++)
					{
						for (int num429 = num421; num429 <= num422; num429++)
						{
							float num430 = Math.Abs((float)num428 - position.X / 16f);
							float num431 = Math.Abs((float)num429 - position.Y / 16f);
							double num432 = Math.Sqrt(num430 * num430 + num431 * num431);
							if (!(num432 < (double)num418))
							{
								continue;
							}
							bool flag3 = true;
							if (Main.tile[num428, num429] != null && Main.tile[num428, num429].active())
							{
								flag3 = true;
								if (Main.tileDungeon[Main.tile[num428, num429].type] || Main.tile[num428, num429].type == 21 || Main.tile[num428, num429].type == 26 || Main.tile[num428, num429].type == 107 || Main.tile[num428, num429].type == 108 || Main.tile[num428, num429].type == 111 || Main.tile[num428, num429].type == 226 || Main.tile[num428, num429].type == 237 || Main.tile[num428, num429].type == 221 || Main.tile[num428, num429].type == 222 || Main.tile[num428, num429].type == 223 || Main.tile[num428, num429].type == 211)
								{
									flag3 = false;
								}
								if (!Main.hardMode && Main.tile[num428, num429].type == 58)
								{
									flag3 = false;
								}
								if (flag3)
								{
									WorldGen.KillTile(num428, num429);
									if (!Main.tile[num428, num429].active() && Main.netMode != 0)
									{
										NetMessage.SendData(17, -1, -1, "", 0, num428, num429);
									}
								}
							}
							if (!flag3)
							{
								continue;
							}
							for (int num433 = num428 - 1; num433 <= num428 + 1; num433++)
							{
								for (int num434 = num429 - 1; num434 <= num429 + 1; num434++)
								{
									if (Main.tile[num433, num434] != null && Main.tile[num433, num434].wall > 0 && flag2)
									{
										WorldGen.KillWall(num433, num434);
										if (Main.tile[num433, num434].wall == 0 && Main.netMode != 0)
										{
											NetMessage.SendData(17, -1, -1, "", 2, num433, num434);
										}
									}
								}
							}
						}
					}
				}
				if (Main.netMode != 0)
				{
					NetMessage.SendData(29, -1, -1, "", identity, owner);
				}
				if (!noDropItem)
				{
					int num435 = -1;
					if (aiStyle == 10)
					{
						int num436 = (int)(position.X + (float)(width / 2)) / 16;
						int num437 = (int)(position.Y + (float)(width / 2)) / 16;
						int num438 = 0;
						int num439 = 2;
						if (type == 109)
						{
							num438 = 147;
							num439 = 0;
						}
						if (type == 31)
						{
							num438 = 53;
							num439 = 0;
						}
						if (type == 42)
						{
							num438 = 53;
							num439 = 0;
						}
						if (type == 56)
						{
							num438 = 112;
							num439 = 0;
						}
						if (type == 65)
						{
							num438 = 112;
							num439 = 0;
						}
						if (type == 67)
						{
							num438 = 116;
							num439 = 0;
						}
						if (type == 68)
						{
							num438 = 116;
							num439 = 0;
						}
						if (type == 71)
						{
							num438 = 123;
							num439 = 0;
						}
						if (type == 39)
						{
							num438 = 59;
							num439 = 176;
						}
						if (type == 40)
						{
							num438 = 57;
							num439 = 172;
						}
						if (type == 179)
						{
							num438 = 224;
							num439 = 0;
						}
						if (type == 241)
						{
							num438 = 234;
							num439 = 0;
						}
						if (type == 354)
						{
							num438 = 234;
							num439 = 0;
						}
						if (type == 411)
						{
							num438 = 330;
							num439 = 71;
						}
						if (type == 412)
						{
							num438 = 331;
							num439 = 72;
						}
						if (type == 413)
						{
							num438 = 332;
							num439 = 73;
						}
						if (type == 414)
						{
							num438 = 333;
							num439 = 74;
						}
						if (Main.tile[num436, num437].halfBrick() && velocity.Y > 0f && Math.Abs(velocity.Y) > Math.Abs(velocity.X))
						{
							num437--;
						}
						if (!Main.tile[num436, num437].active())
						{
							WorldGen.PlaceTile(num436, num437, num438, false, true);
							if (Main.tile[num436, num437].active() && Main.tile[num436, num437].type == num438)
							{
								if (Main.tile[num436, num437 + 1].halfBrick() || Main.tile[num436, num437 + 1].slope() != 0)
								{
									WorldGen.SlopeTile(num436, num437 + 1);
									if (Main.netMode == 2)
									{
										NetMessage.SendData(17, -1, -1, "", 14, num436, num437 + 1);
									}
								}
								if (Main.netMode != 0)
								{
									NetMessage.SendData(17, -1, -1, "", 1, num436, num437, num438);
								}
							}
							else if (num439 > 0)
							{
								num435 = Item.NewItem((int)position.X, (int)position.Y, width, height, num439);
							}
						}
						else if (num439 > 0)
						{
							num435 = Item.NewItem((int)position.X, (int)position.Y, width, height, num439);
						}
					}
					if (type == 1 && Main.rand.Next(3) == 0)
					{
						num435 = Item.NewItem((int)position.X, (int)position.Y, width, height, 40);
					}
					if (type == 103 && Main.rand.Next(6) == 0)
					{
						num435 = ((Main.rand.Next(3) != 0) ? Item.NewItem((int)position.X, (int)position.Y, width, height, 40) : Item.NewItem((int)position.X, (int)position.Y, width, height, 545));
					}
					if (type == 2 && Main.rand.Next(3) == 0)
					{
						num435 = ((Main.rand.Next(3) != 0) ? Item.NewItem((int)position.X, (int)position.Y, width, height, 40) : Item.NewItem((int)position.X, (int)position.Y, width, height, 41));
					}
					if (type == 172 && Main.rand.Next(3) == 0)
					{
						num435 = ((Main.rand.Next(3) != 0) ? Item.NewItem((int)position.X, (int)position.Y, width, height, 40) : Item.NewItem((int)position.X, (int)position.Y, width, height, 988));
					}
					if (type == 171)
					{
						if (ai[1] == 0f)
						{
							num435 = Item.NewItem((int)position.X, (int)position.Y, width, height, 985);
							Main.item[num435].noGrabDelay = 0;
						}
						else if (ai[1] < 10f)
						{
							num435 = Item.NewItem((int)position.X, (int)position.Y, width, height, 965, (int)(10f - ai[1]));
							Main.item[num435].noGrabDelay = 0;
						}
					}
					if (type == 91 && Main.rand.Next(6) == 0)
					{
						num435 = Item.NewItem((int)position.X, (int)position.Y, width, height, 516);
					}
					if (type == 50 && Main.rand.Next(3) == 0)
					{
						num435 = Item.NewItem((int)position.X, (int)position.Y, width, height, 282);
					}
					if (type == 53 && Main.rand.Next(3) == 0)
					{
						num435 = Item.NewItem((int)position.X, (int)position.Y, width, height, 286);
					}
					if (type == 48 && Main.rand.Next(2) == 0)
					{
						num435 = Item.NewItem((int)position.X, (int)position.Y, width, height, 279);
					}
					if (type == 54 && Main.rand.Next(2) == 0)
					{
						num435 = Item.NewItem((int)position.X, (int)position.Y, width, height, 287);
					}
					if (type == 3 && Main.rand.Next(2) == 0)
					{
						num435 = Item.NewItem((int)position.X, (int)position.Y, width, height, 42);
					}
					if (type == 4 && Main.rand.Next(4) == 0)
					{
						num435 = Item.NewItem((int)position.X, (int)position.Y, width, height, 47);
					}
					if (type == 12 && damage > 500)
					{
						num435 = Item.NewItem((int)position.X, (int)position.Y, width, height, 75);
					}
					if (type == 155)
					{
						num435 = Item.NewItem((int)position.X, (int)position.Y, width, height, 859);
					}
					if (type == 21 && Main.rand.Next(2) == 0)
					{
						num435 = Item.NewItem((int)position.X, (int)position.Y, width, height, 154);
					}
					if (Main.netMode == 1 && num435 >= 0)
					{
						NetMessage.SendData(21, -1, -1, "", num435, 1f);
					}
				}
				if (type == 69 || type == 70)
				{
					int num440 = (int)(position.X + (float)(width / 2)) / 16;
					int num441 = (int)(position.Y + (float)(height / 2)) / 16;
					for (int num442 = num440 - 4; num442 <= num440 + 4; num442++)
					{
						for (int num443 = num441 - 4; num443 <= num441 + 4; num443++)
						{
							if (Math.Abs(num442 - num440) + Math.Abs(num443 - num441) >= 6)
							{
								continue;
							}
							if (type == 69)
							{
								if (Main.tile[num442, num443].type == 2)
								{
									Main.tile[num442, num443].type = 109;
									WorldGen.SquareTileFrame(num442, num443);
									NetMessage.SendTileSquare(-1, num442, num443, 1);
								}
								else if (Main.tile[num442, num443].type == 1 || Main.tileMoss[Main.tile[num442, num443].type])
								{
									Main.tile[num442, num443].type = 117;
									WorldGen.SquareTileFrame(num442, num443);
									NetMessage.SendTileSquare(-1, num442, num443, 1);
								}
								else if (Main.tile[num442, num443].type == 53 || Main.tile[num442, num443].type == 234)
								{
									Main.tile[num442, num443].type = 116;
									WorldGen.SquareTileFrame(num442, num443);
									NetMessage.SendTileSquare(-1, num442, num443, 1);
								}
								else if (Main.tile[num442, num443].type == 23 || Main.tile[num442, num443].type == 199)
								{
									Main.tile[num442, num443].type = 109;
									WorldGen.SquareTileFrame(num442, num443);
									NetMessage.SendTileSquare(-1, num442, num443, 1);
								}
								else if (Main.tile[num442, num443].type == 25 || Main.tile[num442, num443].type == 203)
								{
									Main.tile[num442, num443].type = 117;
									WorldGen.SquareTileFrame(num442, num443);
									NetMessage.SendTileSquare(-1, num442, num443, 1);
								}
								else if (Main.tile[num442, num443].type == 161 || Main.tile[num442, num443].type == 163 || Main.tile[num442, num443].type == 200)
								{
									Main.tile[num442, num443].type = 164;
									WorldGen.SquareTileFrame(num442, num443);
									NetMessage.SendTileSquare(-1, num442, num443, 1);
								}
								else if (Main.tile[num442, num443].type == 112)
								{
									Main.tile[num442, num443].type = 116;
									WorldGen.SquareTileFrame(num442, num443);
									NetMessage.SendTileSquare(-1, num442, num443, 1);
								}
								else if (Main.tile[num442, num443].type == 161 || Main.tile[num442, num443].type == 163)
								{
									Main.tile[num442, num443].type = 164;
									WorldGen.SquareTileFrame(num442, num443);
									NetMessage.SendTileSquare(-1, num442, num443, 1);
								}
							}
							else if (Main.tile[num442, num443].type == 2)
							{
								Main.tile[num442, num443].type = 23;
								WorldGen.SquareTileFrame(num442, num443);
								NetMessage.SendTileSquare(-1, num442, num443, 1);
							}
							else if (Main.tile[num442, num443].type == 1 || Main.tileMoss[Main.tile[num442, num443].type])
							{
								Main.tile[num442, num443].type = 25;
								WorldGen.SquareTileFrame(num442, num443);
								NetMessage.SendTileSquare(-1, num442, num443, 1);
							}
							else if (Main.tile[num442, num443].type == 53)
							{
								Main.tile[num442, num443].type = 112;
								WorldGen.SquareTileFrame(num442, num443);
								NetMessage.SendTileSquare(-1, num442, num443, 1);
							}
							else if (Main.tile[num442, num443].type == 109)
							{
								Main.tile[num442, num443].type = 23;
								WorldGen.SquareTileFrame(num442, num443);
								NetMessage.SendTileSquare(-1, num442, num443, 1);
							}
							else if (Main.tile[num442, num443].type == 117)
							{
								Main.tile[num442, num443].type = 25;
								WorldGen.SquareTileFrame(num442, num443);
								NetMessage.SendTileSquare(-1, num442, num443, 1);
							}
							else if (Main.tile[num442, num443].type == 116)
							{
								Main.tile[num442, num443].type = 112;
								WorldGen.SquareTileFrame(num442, num443);
								NetMessage.SendTileSquare(-1, num442, num443, 1);
							}
							else if (Main.tile[num442, num443].type == 161 || Main.tile[num442, num443].type == 164 || Main.tile[num442, num443].type == 200)
							{
								Main.tile[num442, num443].type = 163;
								WorldGen.SquareTileFrame(num442, num443);
								NetMessage.SendTileSquare(-1, num442, num443, 1);
							}
						}
					}
				}
				if (type == 370 || type == 371)
				{
					float num444 = 80f;
					int num445 = 119;
					if (type == 371)
					{
						num445 = 120;
					}
					for (int num446 = 0; num446 < 255; num446++)
					{
						Player player = Main.player[num446];
						if (player.active && !player.dead && Vector2.Distance(center(), player.center()) < num444)
						{
							player.AddBuff(num445, 1800);
						}
					}
					for (int num447 = 0; num447 < 200; num447++)
					{
						NPC nPC = Main.npc[num447];
						if (nPC.active && nPC.life > 0 && Vector2.Distance(center(), nPC.center()) < num444)
						{
							nPC.AddBuff(num445, 1800);
						}
					}
				}
				if (type == 378)
				{
					int num448 = Main.rand.Next(2, 4);
					if (Main.rand.Next(5) == 0)
					{
						num448++;
					}
					for (int num449 = 0; num449 < num448; num449++)
					{
						float x2 = velocity.X;
						float y8 = velocity.Y;
						x2 *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
						y8 *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
						NewProjectile(center().X, center().Y, x2, y8, 379, damage, knockBack, owner);
					}
				}
			}
			active = false;
		}

		public Color GetAlpha(Color newColor)
		{
			if (type == 34 || type == 15 || type == 93 || type == 94 || type == 95 || type == 96 || type == 253 || type == 258 || (type == 102 && alpha < 255))
			{
				return new Color(200, 200, 200, 25);
			}
			if (type == 352)
			{
				return new Color(250, 250, 250, alpha);
			}
			if (type == 409)
			{
				return new Color(250, 250, 250, 200);
			}
			if (type == 348 || type == 349)
			{
				return new Color(200, 200, 200, alpha);
			}
			if (type == 337)
			{
				return new Color(250, 250, 250, 150);
			}
			if (type == 343 || type == 344)
			{
				float num = 1f - (float)alpha / 255f;
				return new Color((int)(250f * num), (int)(250f * num), (int)(250f * num), (int)(100f * num));
			}
			if (type == 332)
			{
				return new Color(255, 255, 255, 255);
			}
			if (type == 329)
			{
				return new Color(200, 200, 200, 50);
			}
			if (type >= 326 && type <= 328)
			{
				return Color.Transparent;
			}
			if (type >= 400 && type <= 402)
			{
				return Color.Transparent;
			}
			if (type == 324 && frame >= 6 && frame <= 9)
			{
				return new Color(255, 255, 255, 255);
			}
			if (type == 16)
			{
				return new Color(255, 255, 255, 0);
			}
			if (type == 321)
			{
				return new Color(200, 200, 200, 0);
			}
			if (type == 76 || type == 77 || type == 78)
			{
				return new Color(255, 255, 255, 0);
			}
			if (type == 308)
			{
				return new Color(200, 200, 255, 125);
			}
			if (type == 263)
			{
				if (timeLeft < 255)
				{
					return new Color(255, 255, 255, (byte)timeLeft);
				}
				return new Color(255, 255, 255, 255);
			}
			if (type == 274)
			{
				if (timeLeft < 85)
				{
					byte b = (byte)(timeLeft * 3);
					byte a = (byte)(100f * ((float)(int)b / 255f));
					return new Color(b, b, b, a);
				}
				return new Color(255, 255, 255, 100);
			}
			if (type == 5)
			{
				return new Color(255, 255, 255, 0);
			}
			if (type == 300 || type == 301)
			{
				return new Color(250, 250, 250, 50);
			}
			if (type == 304)
			{
				return new Color(255 - alpha, 255 - alpha, 255 - alpha, (byte)((float)(255 - alpha) / 3f));
			}
			if (type == 116 || type == 132 || type == 156 || type == 157 || type == 157 || type == 173)
			{
				if (localAI[1] >= 15f)
				{
					return new Color(255, 255, 255, alpha);
				}
				if (localAI[1] < 5f)
				{
					return Color.Transparent;
				}
				int num2 = (int)((localAI[1] - 5f) / 10f * 255f);
				return new Color(num2, num2, num2, num2);
			}
			if (type == 254)
			{
				if (timeLeft < 30)
				{
					float num3 = (float)timeLeft / 30f;
					alpha = (int)(255f - 255f * num3);
				}
				return new Color(255 - alpha, 255 - alpha, 255 - alpha, 0);
			}
			if (type == 265 || type == 355)
			{
				if (alpha > 0)
				{
					return Color.Transparent;
				}
				return new Color(255, 255, 255, 0);
			}
			if (type == 270)
			{
				if (alpha > 0)
				{
					return Color.Transparent;
				}
				return new Color(255, 255, 255, 200);
			}
			if (type == 257)
			{
				if (alpha > 200)
				{
					return Color.Transparent;
				}
				return new Color(255 - alpha, 255 - alpha, 255 - alpha, 0);
			}
			if (type == 259)
			{
				if (alpha > 200)
				{
					return Color.Transparent;
				}
				return new Color(255 - alpha, 255 - alpha, 255 - alpha, 0);
			}
			if (type >= 150 && type <= 152)
			{
				return new Color(255 - alpha, 255 - alpha, 255 - alpha, 255 - alpha);
			}
			if (type == 250)
			{
				return Color.Transparent;
			}
			int r;
			int g;
			int b2;
			if (type == 251)
			{
				r = 255 - alpha;
				g = 255 - alpha;
				b2 = 255 - alpha;
				return new Color(r, g, b2, 0);
			}
			if (type == 131)
			{
				return new Color(255 - alpha, 255 - alpha, 255 - alpha, 0);
			}
			if (type == 211)
			{
				return new Color(255, 255, 255, 0);
			}
			if (type == 229)
			{
				return new Color(255, 255, 255, 50);
			}
			if (type == 221)
			{
				return new Color(255, 255, 255, 200);
			}
			if (type == 207)
			{
				r = 255 - alpha;
				g = 255 - alpha;
				b2 = 255 - alpha;
			}
			else
			{
				if (type == 242)
				{
					if (alpha < 140)
					{
						return new Color(255, 255, 255, 100);
					}
					return Color.Transparent;
				}
				if (type == 209)
				{
					r = newColor.R - alpha;
					g = newColor.G - alpha;
					b2 = newColor.B - alpha / 2;
				}
				else
				{
					if (type == 130)
					{
						return new Color(255, 255, 255, 175);
					}
					if (type == 182)
					{
						return new Color(255, 255, 255, 200);
					}
					if (type == 226)
					{
						r = 255;
						g = 255;
						b2 = 255;
						float num4 = (float)(int)Main.mouseTextColor / 200f - 0.3f;
						r = (int)((float)r * num4);
						g = (int)((float)g * num4);
						b2 = (int)((float)b2 * num4);
						r += 50;
						if (r > 255)
						{
							r = 255;
						}
						g += 50;
						if (g > 255)
						{
							g = 255;
						}
						b2 += 50;
						if (b2 > 255)
						{
							b2 = 255;
						}
						return new Color(r, g, b2, 200);
					}
					if (type == 227)
					{
						r = (g = (b2 = 255));
						float num5 = (float)(int)Main.mouseTextColor / 100f - 1.6f;
						r = (int)((float)r * num5);
						g = (int)((float)g * num5);
						b2 = (int)((float)b2 * num5);
						int a2 = (int)(100f * num5);
						r += 50;
						if (r > 255)
						{
							r = 255;
						}
						g += 50;
						if (g > 255)
						{
							g = 255;
						}
						b2 += 50;
						if (b2 > 255)
						{
							b2 = 255;
						}
						return new Color(r, g, b2, a2);
					}
					if (type == 114 || type == 115)
					{
						if (localAI[1] >= 15f)
						{
							return new Color(255, 255, 255, alpha);
						}
						if (localAI[1] < 5f)
						{
							return Color.Transparent;
						}
						int num6 = (int)((localAI[1] - 5f) / 10f * 255f);
						return new Color(num6, num6, num6, num6);
					}
					if (type == 83 || type == 88 || type == 89 || type == 90 || type == 100 || type == 104 || type == 279 || (type >= 283 && type <= 287))
					{
						if (alpha < 200)
						{
							return new Color(255 - alpha, 255 - alpha, 255 - alpha, 0);
						}
						return Color.Transparent;
					}
					if (type == 34 || type == 35 || type == 15 || type == 19 || type == 44 || type == 45)
					{
						return Color.White;
					}
					if (type == 79)
					{
						r = Main.DiscoR;
						g = Main.DiscoG;
						b2 = Main.DiscoB;
						return default(Color);
					}
					if (type == 9 || type == 15 || type == 34 || type == 50 || type == 53 || type == 76 || type == 77 || type == 78 || type == 92 || type == 91)
					{
						r = newColor.R - alpha / 3;
						g = newColor.G - alpha / 3;
						b2 = newColor.B - alpha / 3;
					}
					else
					{
						if (type == 18)
						{
							return new Color(255, 255, 255, 50);
						}
						if (type == 16 || type == 44 || type == 45)
						{
							r = newColor.R;
							g = newColor.G;
							b2 = newColor.B;
						}
						else if (type == 12 || type == 72 || type == 86 || type == 87)
						{
							return new Color(255, 255, 255, newColor.A - alpha);
						}
					}
				}
			}
			float num7 = (float)(255 - alpha) / 255f;
			r = (int)((float)(int)newColor.R * num7);
			g = (int)((float)(int)newColor.G * num7);
			b2 = (int)((float)(int)newColor.B * num7);
			int num8 = newColor.A - alpha;
			if (num8 < 0)
			{
				num8 = 0;
			}
			if (num8 > 255)
			{
				num8 = 255;
			}
			return new Color(r, g, b2, num8);
		}

		public override string ToString()
		{
			return "name:" + name + ", active:" + active + ", whoAmI:" + whoAmI;
		}
	}
}
