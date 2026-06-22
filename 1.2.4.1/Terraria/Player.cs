using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Terraria
{
	public class Player
	{
		public const int maxBuffs = 22;

		public const int defaultWidth = 20;

		public const int defaultHeight = 42;

		public int beetleOrbs;

		public float beetleCounter;

		public int beetleCountdown;

		public bool beetleDefense;

		public bool beetleOffense;

		public bool beetleBuff;

		public bool manaMagnet;

		public bool lifeMagnet;

		public bool lifeForce;

		public bool calmed;

		public bool inferno;

		public float flameRingRot;

		public float flameRingScale = 1f;

		public byte flameRingFrame;

		public byte flameRingAlpha;

		public int netManaTime;

		public int netLifeTime;

		public bool netMana;

		public bool netLife;

		public Vector2[] beetlePos = new Vector2[3];

		public Vector2[] beetleVel = new Vector2[3];

		public int beetleFrame;

		public int beetleFrameCounter;

		public static int manaSickTime = 300;

		public static int manaSickTimeMax = 600;

		public static float manaSickLessDmg = 0.25f;

		public float manaSickReduction;

		public bool manaSick;

		public bool stairFall;

		public int loadStatus;

		public Vector2[] itemFlamePos = new Vector2[7];

		public int itemFlameCount;

		public bool outOfRange;

		public float lifeSteal = 99999f;

		public float ghostDmg;

		public bool teleporting;

		public float teleportTime;

		public int teleportStyle;

		public bool sloping;

		public bool chilled;

		public bool frozen;

		public bool ichor;

		public int ropeCount;

		public int manaRegenBonus;

		public int manaRegenDelayBonus;

		public int dash;

		public int dashTime;

		public int dashDelay;

		public float accRunSpeed;

		public int gem = -1;

		public int gemCount;

		public byte meleeEnchant;

		public byte pulleyDir;

		public bool pulley;

		public int pulleyFrame;

		public float pulleyFrameCounter;

		public bool blackBelt;

		public bool sliding;

		public int slideDir;

		public int launcherWait;

		public bool iceSkate;

		public bool carpet;

		public int spikedBoots;

		public int carpetFrame = -1;

		public float carpetFrameCounter;

		public bool canCarpet;

		public int carpetTime;

		public int miscCounter;

		public int infernoCounter;

		public bool sandStorm;

		public bool crimsonRegen;

		public bool ghostHeal;

		public bool ghostHurt;

		public bool sticky;

		public bool slippy;

		public bool slippy2;

		public bool powerrun;

		public bool flapSound;

		public bool iceBarrier;

		public bool dangerSense;

		public float endurance;

		public bool loveStruck;

		public bool stinky;

		public bool resistCold;

		public bool panic;

		public byte iceBarrierFrame;

		public byte iceBarrierFrameCounter;

		public bool shadowDodge;

		public float shadowDodgeCount;

		public bool palladiumRegen;

		public bool onHitDodge;

		public bool onHitRegen;

		public bool onHitPetal;

		public int petalTimer;

		public int shadowDodgeTimer;

		public int fishingSkill;

		public bool cratePotion;

		public bool sonarPotion;

		public bool accFishingLine;

		public bool accTackleBox;

		public int maxMinions = 1;

		public int numMinions;

		public float slotsMinions;

		public bool pygmy;

		public bool raven;

		public bool slime;

		public bool hornetMinion;

		public bool impMinion;

		public bool twinsMinion;

		public bool spiderMinion;

		public bool pirateMinion;

		public bool sharknadoMinion;

		public float wingTime;

		public int wings;

		public int wingsLogic;

		public int wingTimeMax;

		public int wingFrame;

		public int wingFrameCounter;

		public bool male = true;

		public bool ghost;

		public int ghostFrame;

		public int ghostFrameCounter;

		public int miscTimer;

		public bool pvpDeath;

		public bool zoneDungeon;

		public bool zoneEvil;

		public bool zoneHoly;

		public bool zoneMeteor;

		public bool zoneJungle;

		public bool zoneSnow;

		public bool zoneBlood;

		public bool zoneCandle;

		public bool boneArmor;

		public bool frostArmor;

		public bool honey;

		public bool crystalLeaf;

		public bool paladinBuff;

		public bool paladinGive;

		public float townNPCs;

		public Vector2 position;

		public Vector2 oldPosition;

		public Vector2 velocity;

		public Vector2 oldVelocity;

		public double headFrameCounter;

		public double bodyFrameCounter;

		public double legFrameCounter;

		public int netSkip;

		public int oldSelectItem;

		public bool immune;

		public int immuneTime;

		public int immuneAlphaDirection;

		public int immuneAlpha;

		public int team;

		public bool hbLocked;

		public static int nameLen = 20;

		private float maxRegenDelay;

		public string chatText = "";

		public int sign = -1;

		public bool editedChestName;

		public int chatShowTime;

		public int reuseDelay;

		public int aggro;

		public float activeNPCs;

		public bool mouseInterface;

		public bool lastMouseInterface;

		public int noThrow;

		public int changeItem = -1;

		public int selectedItem;

		public Item[] armor = new Item[16];

		public Item[] dye = new Item[8];

		public int itemAnimation;

		public int itemAnimationMax;

		public int itemTime;

		public int toolTime;

		public float itemRotation;

		public int itemWidth;

		public int itemHeight;

		public Vector2 itemLocation;

		public bool poundRelease;

		public float ghostFade;

		public float ghostDir = 1f;

		public int[] buffType = new int[22];

		public int[] buffTime = new int[22];

		public bool[] buffImmune = new bool[140];

		public int heldProj = -1;

		public int breathCD;

		public int breathMax = 200;

		public int breath = 200;

		public int lavaCD;

		public int lavaMax;

		public int lavaTime;

		public bool ignoreWater;

		public bool socialShadow;

		public bool socialGhost;

		public bool armorSteath;

		public int stealthTimer;

		public float stealth = 1f;

		public string setBonus = "";

		public Item[] inventory = new Item[59];

		public Chest bank = new Chest(true);

		public Chest bank2 = new Chest(true);

		public float headRotation;

		public float bodyRotation;

		public float legRotation;

		public Vector2 headPosition;

		public Vector2 bodyPosition;

		public Vector2 legPosition;

		public Vector2 headVelocity;

		public Vector2 bodyVelocity;

		public Vector2 legVelocity;

		public float fullRotation;

		public Vector2 fullRotationOrigin = Vector2.Zero;

		public int nonTorch = -1;

		public float gfxOffY;

		public float stepSpeed = 1f;

		public static bool deadForGood = false;

		public bool dead;

		public int respawnTimer;

		public string name = "";

		public int attackCD;

		public int potionDelay;

		public byte difficulty;

		public bool wet;

		public byte wetCount;

		public bool lavaWet;

		public bool honeyWet;

		public byte wetSlime;

		public HitTile hitTile;

		public int jump;

		public int head = -1;

		public int body = -1;

		public int legs = -1;

		public sbyte handon = -1;

		public sbyte handoff = -1;

		public sbyte back = -1;

		public sbyte front = -1;

		public sbyte shoe = -1;

		public sbyte waist = -1;

		public sbyte shield = -1;

		public sbyte neck = -1;

		public sbyte face = -1;

		public sbyte balloon = -1;

		public BitsByte hideVisual = (byte)0;

		public Rectangle headFrame;

		public Rectangle bodyFrame;

		public Rectangle legFrame;

		public Rectangle hairFrame;

		public bool controlLeft;

		public bool controlRight;

		public bool controlUp;

		public bool controlDown;

		public bool controlJump;

		public bool controlUseItem;

		public bool controlUseTile;

		public bool controlThrow;

		public bool controlInv;

		public bool controlHook;

		public bool controlTorch;

		public bool controlMap;

		public bool controlSmart;

		public bool releaseJump;

		public bool releaseUp;

		public bool releaseUseItem;

		public bool releaseUseTile;

		public bool releaseInventory;

		public bool releaseHook;

		public bool releaseThrow;

		public bool releaseQuickMana;

		public bool releaseQuickHeal;

		public bool releaseLeft;

		public bool releaseRight;

		public bool releaseSmart;

		public bool mapZoomIn;

		public bool mapZoomOut;

		public bool mapAlphaUp;

		public bool mapAlphaDown;

		public bool mapFullScreen;

		public bool mapStyle;

		public bool releaseMapFullscreen;

		public bool releaseMapStyle;

		public int leftTimer;

		public int rightTimer;

		public bool delayUseItem;

		public bool active;

		public int width = 20;

		public int height = 42;

		public int direction = 1;

		public bool showItemIcon;

		public bool showItemIconR;

		public int showItemIcon2;

		public string showItemIconText = "";

		public int whoAmi;

		public int runSoundDelay;

		public float shadow;

		public Vector2[] shadowPos = new Vector2[3];

		public float[] shadowRotation = new float[3];

		public Vector2[] shadowOrigin = new Vector2[3];

		public int shadowCount;

		public float manaCost = 1f;

		public bool fireWalk;

		public bool channel;

		public int step = -1;

		public int anglerQuestsFinished;

		public int statDefense;

		public int statLifeMax = 100;

		public int statLifeMax2 = 100;

		public int statLife = 100;

		public int statMana;

		public int statManaMax;

		public int statManaMax2;

		public int lifeRegen;

		public int lifeRegenCount;

		public int lifeRegenTime;

		public int manaRegen;

		public int manaRegenCount;

		public int manaRegenDelay;

		public bool manaRegenBuff;

		public bool noKnockback;

		public bool spaceGun;

		public float gravDir = 1f;

		public bool ammoCost80;

		public bool ammoCost75;

		public int stickyBreak;

		public bool magicQuiver;

		public bool magmaStone;

		public bool lavaRose;

		public bool ammoBox;

		public bool ammoPotion;

		public bool chaosState;

		public bool lightOrb;

		public bool blueFairy;

		public bool redFairy;

		public bool greenFairy;

		public bool bunny;

		public bool turtle;

		public bool eater;

		public bool penguin;

		public bool puppy;

		public bool grinch;

		public bool miniMinotaur;

		public bool wearsRobe;

		public bool minecartLeft;

		public bool onWrongGround;

		public bool onTrack;

		public int cartRampTime;

		public bool cartFlip;

		public float trackBoost;

		public Vector2 lastBoost = Vector2.Zero;

		public Mount mount;

		public bool blackCat;

		public bool spider;

		public bool squashling;

		public bool magicCuffs;

		public bool coldDash;

		public bool eyeSpring;

		public bool snowman;

		public bool scope;

		public bool dino;

		public bool skeletron;

		public bool hornet;

		public bool zephyrfish;

		public bool tiki;

		public bool parrot;

		public bool truffle;

		public bool sapling;

		public bool cSapling;

		public bool wisp;

		public bool lizard;

		public bool archery;

		public bool poisoned;

		public bool venom;

		public bool blind;

		public bool blackout;

		public bool frostBurn;

		public bool onFrostBurn;

		public bool burned;

		public bool suffocating;

		public byte suffocateDelay;

		public bool dripping;

		public bool drippingSlime;

		public bool onFire;

		public bool onFire2;

		public bool noItems;

		public bool wereWolf;

		public bool wolfAcc;

		public bool rulerAcc;

		public bool bleed;

		public bool confused;

		public bool accMerman;

		public bool merman;

		public bool brokenArmor;

		public bool silence;

		public bool slow;

		public bool gross;

		public bool tongued;

		public bool kbGlove;

		public bool kbBuff;

		public bool starCloak;

		public bool longInvince;

		public bool pStone;

		public bool manaFlower;

		public int meleeCrit = 4;

		public int rangedCrit = 4;

		public int magicCrit = 4;

		public float meleeDamage = 1f;

		public float rangedDamage = 1f;

		public float bulletDamage = 1f;

		public float arrowDamage = 1f;

		public float rocketDamage = 1f;

		public float magicDamage = 1f;

		public float minionDamage = 1f;

		public float minionKB;

		public float meleeSpeed = 1f;

		public float moveSpeed = 1f;

		public float pickSpeed = 1f;

		public float wallSpeed = 1f;

		public float tileSpeed = 1f;

		public bool autoPaint;

		public int SpawnX = -1;

		public int SpawnY = -1;

		public int[] spX = new int[200];

		public int[] spY = new int[200];

		public string[] spN = new string[200];

		public int[] spI = new int[200];

		public static int tileRangeX = 5;

		public static int tileRangeY = 4;

		public static int tileTargetX;

		public static int tileTargetY;

		public static float defaultGravity = 0.4f;

		private static int jumpHeight = 15;

		private static float jumpSpeed = 5.01f;

		public float gravity = defaultGravity;

		public float maxFallSpeed = 10f;

		public float maxRunSpeed = 3f;

		public float runAcceleration = 0.08f;

		public float runSlowdown = 0.2f;

		public bool adjWater;

		public bool adjHoney;

		public bool adjLava;

		public bool oldAdjWater;

		public bool oldAdjHoney;

		public bool oldAdjLava;

		public bool[] adjTile = new bool[340];

		public bool[] oldAdjTile = new bool[340];

		private static int defaultItemGrabRange = 38;

		private static float itemGrabSpeed = 0.45f;

		private static float itemGrabSpeedMax = 4f;

		public byte hairDye;

		public Color hairDyeColor = Color.Transparent;

		public float hairDyeVar;

		public Color hairColor = new Color(215, 90, 55);

		public Color skinColor = new Color(255, 125, 90);

		public Color eyeColor = new Color(105, 90, 75);

		public Color shirtColor = new Color(175, 165, 140);

		public Color underShirtColor = new Color(160, 180, 215);

		public Color pantsColor = new Color(255, 230, 175);

		public Color shoeColor = new Color(160, 105, 60);

		public int hair;

		public bool hostile;

		public int accCompass;

		public int accWatch;

		public int accDepthMeter;

		public bool discount;

		public bool coins;

		public bool accDivingHelm;

		public bool accFlipper;

		public bool doubleJump;

		public bool jumpAgain;

		public bool dJumpEffect;

		public bool doubleJump2;

		public bool jumpAgain2;

		public bool dJumpEffect2;

		public bool doubleJump3;

		public bool jumpAgain3;

		public bool dJumpEffect3;

		public bool autoJump;

		public bool justJumped;

		public float jumpSpeedBoost;

		public int extraFall;

		public bool doubleJump4;

		public bool jumpAgain4;

		public bool dJumpEffect4;

		public bool spawnMax;

		public int blockRange;

		public int[] grappling = new int[20];

		public int grapCount;

		public int rocketTime;

		public int rocketTimeMax = 7;

		public int rocketDelay;

		public int rocketDelay2;

		public bool rocketRelease;

		public bool rocketFrame;

		public int rocketBoots;

		public bool canRocket;

		public bool jumpBoost;

		public bool noFallDmg;

		public int swimTime;

		public bool killGuide;

		public bool killClothier;

		public bool lavaImmune;

		public bool gills;

		public bool slowFall;

		public bool findTreasure;

		public bool invis;

		public bool detectCreature;

		public bool nightVision;

		public bool enemySpawns;

		public bool thorns;

		public bool turtleArmor;

		public bool turtleThorns;

		public bool spiderArmor;

		public bool waterWalk;

		public bool waterWalk2;

		public bool gravControl;

		public bool gravControl2;

		public bool bee;

		public int chest = -1;

		public int chestX;

		public int chestY;

		public int talkNPC = -1;

		public int fallStart;

		public int fallStart2;

		public int slowCount;

		public int potionDelayTime = Item.potionDelay;

		public static bool lastPound = true;

		public void HealEffect(int healAmount, bool broadcast = true)
		{
			CombatText.NewText(new Rectangle((int)position.X, (int)position.Y, width, height), new Color(100, 255, 100, 255), string.Concat(healAmount));
			if (broadcast && Main.netMode == 1 && whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(35, -1, -1, "", whoAmi, healAmount);
			}
		}

		public void ManaEffect(int manaAmount)
		{
			CombatText.NewText(new Rectangle((int)position.X, (int)position.Y, width, height), new Color(100, 100, 255, 255), string.Concat(manaAmount));
			if (Main.netMode == 1 && whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(43, -1, -1, "", whoAmi, manaAmount);
			}
		}

		public static byte FindClosest(Vector2 Position, int Width, int Height)
		{
			byte result = 0;
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active)
				{
					result = (byte)i;
					break;
				}
			}
			float num = -1f;
			for (int j = 0; j < 255; j++)
			{
				if (Main.player[j].active && !Main.player[j].dead)
				{
					float num2 = Math.Abs(Main.player[j].position.X + (float)(Main.player[j].width / 2) - (Position.X + (float)(Width / 2))) + Math.Abs(Main.player[j].position.Y + (float)(Main.player[j].height / 2) - (Position.Y + (float)(Height / 2)));
					if (num == -1f || num2 < num)
					{
						num = num2;
						result = (byte)j;
					}
				}
			}
			return result;
		}

		public void checkArmor()
		{
		}

		public void toggleInv()
		{
			if (Main.ingameOptionsWindow)
			{
				IngameOptions.Close();
			}
			else if (talkNPC >= 0)
			{
				talkNPC = -1;
				Main.npcChatCornerItem = 0;
				Main.npcChatText = "";
				Main.PlaySound(11);
			}
			else if (sign >= 0)
			{
				sign = -1;
				Main.editSign = false;
				Main.npcChatText = "";
				Main.PlaySound(11);
			}
			else if (Main.clothesWindow)
			{
				Main.CancelClothesWindow();
			}
			else if (!Main.playerInventory)
			{
				Recipe.FindRecipes();
				Main.playerInventory = true;
				Main.PlaySound(10);
			}
			else
			{
				Main.playerInventory = false;
				Main.PlaySound(11);
			}
		}

		public void dropItemCheck()
		{
			if (!Main.playerInventory)
			{
				noThrow = 0;
			}
			if (noThrow > 0)
			{
				noThrow--;
			}
			if (!Main.craftGuide && Main.guideItem.type > 0)
			{
				int num = Item.NewItem((int)position.X, (int)position.Y, width, height, Main.guideItem.type);
				Main.guideItem.position = Main.item[num].position;
				Main.item[num] = Main.guideItem;
				Main.guideItem = new Item();
				if (Main.netMode == 0)
				{
					Main.item[num].noGrabDelay = 100;
				}
				Main.item[num].velocity.Y = -2f;
				Main.item[num].velocity.X = (float)(4 * direction) + velocity.X;
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", num);
				}
			}
			if (!Main.reforge && Main.reforgeItem.type > 0)
			{
				int num2 = Item.NewItem((int)position.X, (int)position.Y, width, height, Main.reforgeItem.type);
				Main.reforgeItem.position = Main.item[num2].position;
				Main.item[num2] = Main.reforgeItem;
				Main.reforgeItem = new Item();
				if (Main.netMode == 0)
				{
					Main.item[num2].noGrabDelay = 100;
				}
				Main.item[num2].velocity.Y = -2f;
				Main.item[num2].velocity.X = (float)(4 * direction) + velocity.X;
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", num2);
				}
			}
			if (Main.myPlayer == whoAmi)
			{
				inventory[58] = Main.mouseItem.Clone();
			}
			bool flag = true;
			if (Main.mouseItem.type > 0 && Main.mouseItem.stack > 0 && !Main.gamePaused)
			{
				tileTargetX = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
				tileTargetY = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
				if (gravDir == -1f)
				{
					tileTargetY = (int)((Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16f);
				}
				if (selectedItem != 58)
				{
					oldSelectItem = selectedItem;
				}
				selectedItem = 58;
				flag = false;
			}
			if (flag && selectedItem == 58)
			{
				selectedItem = oldSelectItem;
			}
			if (Main.tile[tileTargetX, tileTargetY] != null && Main.tile[tileTargetX, tileTargetY].type == 334 && ItemFitsWeaponRack(inventory[selectedItem]))
			{
				noThrow = 2;
			}
			if (((controlThrow && releaseThrow && inventory[selectedItem].type > 0 && !Main.chatMode) || (((Main.mouseRight && !mouseInterface && Main.mouseRightRelease) || !Main.playerInventory) && Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)) && noThrow <= 0)
			{
				Item item = new Item();
				bool flag2 = false;
				if (((Main.mouseRight && !mouseInterface && Main.mouseRightRelease) || !Main.playerInventory) && Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)
				{
					item = inventory[selectedItem];
					inventory[selectedItem] = Main.mouseItem;
					delayUseItem = true;
					controlUseItem = false;
					flag2 = true;
				}
				int num3 = Item.NewItem((int)position.X, (int)position.Y, width, height, inventory[selectedItem].type);
				if (!flag2 && inventory[selectedItem].type == 8 && inventory[selectedItem].stack > 1)
				{
					inventory[selectedItem].stack--;
				}
				else
				{
					inventory[selectedItem].position = Main.item[num3].position;
					Main.item[num3] = inventory[selectedItem];
					inventory[selectedItem] = new Item();
				}
				if (Main.netMode == 0)
				{
					Main.item[num3].noGrabDelay = 100;
				}
				Main.item[num3].velocity.Y = -2f;
				Main.item[num3].velocity.X = (float)(4 * direction) + velocity.X;
				if (((Main.mouseRight && !mouseInterface) || !Main.playerInventory) && Main.mouseItem.type > 0)
				{
					inventory[selectedItem] = item;
					Main.mouseItem = new Item();
				}
				else
				{
					itemAnimation = 10;
					itemAnimationMax = 10;
				}
				Recipe.FindRecipes();
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", num3);
				}
			}
		}

		public int HasBuff(int type)
		{
			if (buffImmune[type])
			{
				return -1;
			}
			for (int i = 0; i < 22; i++)
			{
				if (buffTime[i] >= 1 && buffType[i] == type)
				{
					return i;
				}
			}
			return -1;
		}

		public void AddBuff(int type, int time, bool quiet = true)
		{
			if (buffImmune[type])
			{
				return;
			}
			if (!quiet && Main.netMode == 1)
			{
				bool flag = true;
				for (int i = 0; i < 22; i++)
				{
					if (buffType[i] == type)
					{
						flag = false;
					}
				}
				if (flag)
				{
					NetMessage.SendData(55, -1, -1, "", whoAmi, type, time);
				}
			}
			int num = -1;
			for (int j = 0; j < 22; j++)
			{
				if (buffType[j] != type)
				{
					continue;
				}
				if (type == 94)
				{
					buffTime[j] += time;
					if (buffTime[j] > manaSickTimeMax)
					{
						buffTime[j] = manaSickTimeMax;
					}
				}
				else if (buffTime[j] < time)
				{
					buffTime[j] = time;
				}
				return;
			}
			if (Main.vanityPet[type] || Main.lightPet[type])
			{
				for (int k = 0; k < 22; k++)
				{
					if (Main.vanityPet[type] && Main.vanityPet[buffType[k]])
					{
						DelBuff(k);
					}
					if (Main.lightPet[type] && Main.lightPet[buffType[k]])
					{
						DelBuff(k);
					}
				}
			}
			while (num == -1)
			{
				int num2 = -1;
				for (int l = 0; l < 22; l++)
				{
					if (!Main.debuff[buffType[l]])
					{
						num2 = l;
						break;
					}
				}
				if (num2 == -1)
				{
					return;
				}
				for (int m = num2; m < 22; m++)
				{
					if (buffType[m] == 0)
					{
						num = m;
						break;
					}
				}
				if (num == -1)
				{
					DelBuff(num2);
				}
			}
			buffType[num] = type;
			buffTime[num] = time;
			if (!Main.meleeBuff[type])
			{
				return;
			}
			for (int n = 0; n < 22; n++)
			{
				if (n != num && Main.meleeBuff[buffType[n]])
				{
					DelBuff(n);
				}
			}
		}

		public void DelBuff(int b)
		{
			buffTime[b] = 0;
			buffType[b] = 0;
			for (int i = 0; i < 21; i++)
			{
				if (buffTime[i] == 0 || buffType[i] == 0)
				{
					for (int j = i + 1; j < 22; j++)
					{
						buffTime[j - 1] = buffTime[j];
						buffType[j - 1] = buffType[j];
						buffTime[j] = 0;
						buffType[j] = 0;
					}
				}
			}
		}

		public void ClearBuff(int type)
		{
			for (int i = 0; i < 22; i++)
			{
				if (buffType[i] == type)
				{
					DelBuff(i);
				}
			}
		}

		public void QuickHeal()
		{
			if (noItems || statLife == statLifeMax2 || potionDelay > 0)
			{
				return;
			}
			int num = statLifeMax2 - statLife;
			Item item = null;
			int num2 = -statLifeMax2;
			for (int i = 0; i < 58; i++)
			{
				Item item2 = inventory[i];
				if (item2.stack <= 0 || item2.type <= 0 || !item2.potion || item2.healLife <= 0)
				{
					continue;
				}
				int num3 = item2.healLife - num;
				if (num2 < 0)
				{
					if (num3 > num2)
					{
						item = item2;
						num2 = num3;
					}
				}
				else if (num3 < num2 && num3 >= 0)
				{
					item = item2;
					num2 = num3;
				}
			}
			if (item != null)
			{
				Main.PlaySound(2, (int)position.X, (int)position.Y, item.useSound);
				if (item.potion)
				{
					potionDelay = potionDelayTime;
					AddBuff(21, potionDelay);
				}
				statLife += item.healLife;
				statMana += item.healMana;
				if (statLife > statLifeMax2)
				{
					statLife = statLifeMax2;
				}
				if (statMana > statManaMax2)
				{
					statMana = statManaMax2;
				}
				if (item.healLife > 0 && Main.myPlayer == whoAmi)
				{
					HealEffect(item.healLife);
				}
				if (item.healMana > 0 && Main.myPlayer == whoAmi)
				{
					ManaEffect(item.healMana);
				}
				item.stack--;
				if (item.stack <= 0)
				{
					item.type = 0;
					item.name = "";
				}
				Recipe.FindRecipes();
			}
		}

		public void QuickMana()
		{
			if (noItems || statMana == statManaMax2)
			{
				return;
			}
			for (int i = 0; i < 58; i++)
			{
				if (inventory[i].stack <= 0 || inventory[i].type <= 0 || inventory[i].healMana <= 0 || (potionDelay != 0 && inventory[i].potion))
				{
					continue;
				}
				Main.PlaySound(2, (int)position.X, (int)position.Y, inventory[i].useSound);
				if (inventory[i].potion)
				{
					potionDelay = potionDelayTime;
					AddBuff(21, potionDelay);
				}
				statLife += inventory[i].healLife;
				statMana += inventory[i].healMana;
				if (statLife > statLifeMax2)
				{
					statLife = statLifeMax2;
				}
				if (statMana > statManaMax2)
				{
					statMana = statManaMax2;
				}
				if (inventory[i].healLife > 0 && Main.myPlayer == whoAmi)
				{
					HealEffect(inventory[i].healLife);
				}
				if (inventory[i].healMana > 0)
				{
					AddBuff(94, manaSickTime);
					if (Main.myPlayer == whoAmi)
					{
						ManaEffect(inventory[i].healMana);
					}
				}
				inventory[i].stack--;
				if (inventory[i].stack <= 0)
				{
					inventory[i].type = 0;
					inventory[i].name = "";
				}
				Recipe.FindRecipes();
				break;
			}
		}

		public int countBuffs()
		{
			int num = 0;
			for (int i = 0; i < 22; i++)
			{
				if (buffType[num] > 0)
				{
					num++;
				}
			}
			return num;
		}

		public void QuickBuff()
		{
			if (noItems)
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < 58; i++)
			{
				if (countBuffs() == 22)
				{
					return;
				}
				if (inventory[i].stack <= 0 || inventory[i].type <= 0 || inventory[i].buffType <= 0 || inventory[i].summon || inventory[i].buffType == 90)
				{
					continue;
				}
				int num2 = inventory[i].buffType;
				bool flag = true;
				for (int j = 0; j < 22; j++)
				{
					if (num2 == 27 && (buffType[j] == num2 || buffType[j] == 101 || buffType[j] == 102))
					{
						flag = false;
						break;
					}
					if (buffType[j] == num2)
					{
						flag = false;
						break;
					}
					if (Main.meleeBuff[num2] && Main.meleeBuff[buffType[j]])
					{
						flag = false;
						break;
					}
				}
				if (Main.lightPet[inventory[i].buffType] || Main.vanityPet[inventory[i].buffType])
				{
					for (int k = 0; k < 22; k++)
					{
						if (Main.lightPet[buffType[k]] && Main.lightPet[inventory[i].buffType])
						{
							flag = false;
						}
						if (Main.vanityPet[buffType[k]] && Main.vanityPet[inventory[i].buffType])
						{
							flag = false;
						}
					}
				}
				if (inventory[i].mana > 0 && flag)
				{
					if (statMana >= (int)((float)inventory[i].mana * manaCost))
					{
						manaRegenDelay = (int)maxRegenDelay;
						statMana -= (int)((float)inventory[i].mana * manaCost);
					}
					else
					{
						flag = false;
					}
				}
				if (whoAmi == Main.myPlayer && inventory[i].type == 603 && !Main.cEd)
				{
					flag = false;
				}
				if (num2 == 27)
				{
					num2 = Main.rand.Next(3);
					if (num2 == 0)
					{
						num2 = 27;
					}
					if (num2 == 1)
					{
						num2 = 101;
					}
					if (num2 == 2)
					{
						num2 = 102;
					}
				}
				if (!flag)
				{
					continue;
				}
				num = inventory[i].useSound;
				int num3 = inventory[i].buffTime;
				if (num3 == 0)
				{
					num3 = 3600;
				}
				AddBuff(num2, num3);
				if (inventory[i].consumable)
				{
					inventory[i].stack--;
					if (inventory[i].stack <= 0)
					{
						inventory[i].type = 0;
						inventory[i].name = "";
					}
				}
			}
			if (num > 0)
			{
				Main.PlaySound(2, (int)position.X, (int)position.Y, num);
				Recipe.FindRecipes();
			}
		}

		public void StatusNPC(int type, int i)
		{
			if (meleeEnchant > 0)
			{
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
			if (frostBurn)
			{
				Main.npc[i].AddBuff(44, 60 * Main.rand.Next(5, 15));
			}
			if (magmaStone)
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
			switch (type)
			{
			case 121:
				if (Main.rand.Next(2) == 0)
				{
					Main.npc[i].AddBuff(24, 180);
				}
				break;
			case 122:
				if (Main.rand.Next(10) == 0)
				{
					Main.npc[i].AddBuff(24, 180);
				}
				break;
			case 190:
				if (Main.rand.Next(4) == 0)
				{
					Main.npc[i].AddBuff(20, 420);
				}
				break;
			case 217:
				if (Main.rand.Next(5) == 0)
				{
					Main.npc[i].AddBuff(24, 180);
				}
				break;
			case 1123:
				if (Main.rand.Next(10) != 0)
				{
					Main.npc[i].AddBuff(31, 120);
				}
				break;
			}
		}

		public void StatusPvP(int type, int i)
		{
			if (meleeEnchant > 0)
			{
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
			if (frostBurn)
			{
				Main.player[i].AddBuff(44, 60 * Main.rand.Next(1, 8));
			}
			if (magmaStone)
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
			switch (type)
			{
			case 121:
				if (Main.rand.Next(2) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
				}
				break;
			case 122:
				if (Main.rand.Next(10) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
				}
				break;
			case 190:
				if (Main.rand.Next(4) == 0)
				{
					Main.player[i].AddBuff(20, 420, false);
				}
				break;
			case 217:
				if (Main.rand.Next(5) == 0)
				{
					Main.player[i].AddBuff(24, 180, false);
				}
				break;
			case 1123:
				if (Main.rand.Next(9) != 0)
				{
					Main.player[i].AddBuff(31, 120, false);
				}
				break;
			}
		}

		public void Ghost()
		{
			immune = false;
			immuneAlpha = 0;
			controlUp = false;
			controlLeft = false;
			controlDown = false;
			controlRight = false;
			controlJump = false;
			if (Main.hasFocus && !Main.chatMode && !Main.editSign && !Main.editChest && !Main.blockInput)
			{
				Keys[] pressedKeys = Main.keyState.GetPressedKeys();
				if (Main.blockKey != Keys.None)
				{
					bool flag = false;
					for (int i = 0; i < pressedKeys.Length; i++)
					{
						if (pressedKeys[i] == Main.blockKey)
						{
							pressedKeys[i] = Keys.None;
							flag = true;
						}
					}
					if (!flag)
					{
						Main.blockKey = Keys.None;
					}
				}
				for (int j = 0; j < pressedKeys.Length; j++)
				{
					string text = string.Concat(pressedKeys[j]);
					if (text == Main.cUp)
					{
						controlUp = true;
					}
					if (text == Main.cLeft)
					{
						controlLeft = true;
					}
					if (text == Main.cDown)
					{
						controlDown = true;
					}
					if (text == Main.cRight)
					{
						controlRight = true;
					}
					if (text == Main.cJump)
					{
						controlJump = true;
					}
				}
			}
			if (controlUp || controlJump)
			{
				if (velocity.Y > 0f)
				{
					velocity.Y *= 0.9f;
				}
				velocity.Y -= 0.1f;
				if (velocity.Y < -3f)
				{
					velocity.Y = -3f;
				}
			}
			else if (controlDown)
			{
				if (velocity.Y < 0f)
				{
					velocity.Y *= 0.9f;
				}
				velocity.Y += 0.1f;
				if (velocity.Y > 3f)
				{
					velocity.Y = 3f;
				}
			}
			else if ((double)velocity.Y < -0.1 || (double)velocity.Y > 0.1)
			{
				velocity.Y *= 0.9f;
			}
			else
			{
				velocity.Y = 0f;
			}
			if (controlLeft && !controlRight)
			{
				if (velocity.X > 0f)
				{
					velocity.X *= 0.9f;
				}
				velocity.X -= 0.1f;
				if (velocity.X < -3f)
				{
					velocity.X = -3f;
				}
			}
			else if (controlRight && !controlLeft)
			{
				if (velocity.X < 0f)
				{
					velocity.X *= 0.9f;
				}
				velocity.X += 0.1f;
				if (velocity.X > 3f)
				{
					velocity.X = 3f;
				}
			}
			else if ((double)velocity.X < -0.1 || (double)velocity.X > 0.1)
			{
				velocity.X *= 0.9f;
			}
			else
			{
				velocity.X = 0f;
			}
			position += velocity;
			ghostFrameCounter++;
			if (velocity.X < 0f)
			{
				direction = -1;
			}
			else if (velocity.X > 0f)
			{
				direction = 1;
			}
			if (ghostFrameCounter >= 8)
			{
				ghostFrameCounter = 0;
				ghostFrame++;
				if (ghostFrame >= 4)
				{
					ghostFrame = 0;
				}
			}
			if (position.X < Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
			{
				position.X = Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
				velocity.X = 0f;
			}
			if (position.X + (float)width > Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f)
			{
				position.X = Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)width;
				velocity.X = 0f;
			}
			if (position.Y < Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
			{
				position.Y = Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
				if ((double)velocity.Y < -0.1)
				{
					velocity.Y = -0.1f;
				}
			}
			if (position.Y > Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)height)
			{
				position.Y = Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)height;
				velocity.Y = 0f;
			}
		}

		public Vector2 Center()
		{
			return new Vector2(position.X + (float)(width / 2), position.Y + (float)(height / 2));
		}

		public void onHit(float x, float y)
		{
			if (Main.myPlayer != whoAmi)
			{
				return;
			}
			if (onHitDodge && shadowDodgeTimer == 0 && Main.rand.Next(4) == 0)
			{
				if (!shadowDodge)
				{
					shadowDodgeTimer = 1200;
				}
				AddBuff(59, 1200);
			}
			if (onHitRegen)
			{
				AddBuff(58, 300);
			}
			if (onHitPetal && petalTimer == 0)
			{
				petalTimer = 20;
				int num = 1;
				if (x < position.X + (float)(width / 2))
				{
					num = -1;
				}
				num = direction;
				float num2 = Main.screenPosition.X;
				if (num < 0)
				{
					num2 += (float)Main.screenWidth;
				}
				float y2 = Main.screenPosition.Y;
				y2 += (float)Main.rand.Next(Main.screenHeight);
				Vector2 vector = new Vector2(num2, y2);
				float num3 = x - vector.X;
				float num4 = y - vector.Y;
				num3 += (float)Main.rand.Next(-50, 51) * 0.1f;
				num4 += (float)Main.rand.Next(-50, 51) * 0.1f;
				int num5 = 24;
				float num6 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
				num6 = (float)num5 / num6;
				num3 *= num6;
				num4 *= num6;
				Projectile.NewProjectile(num2, y2, num3, num4, 221, 36, 0f, whoAmi);
			}
			if (!crystalLeaf || petalTimer != 0)
			{
				return;
			}
			int type = inventory[selectedItem].type;
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].owner == whoAmi && Main.projectile[i].type == 226)
				{
					petalTimer = 50;
					float num7 = 12f;
					Vector2 vector2 = new Vector2(Main.projectile[i].position.X + (float)width * 0.5f, Main.projectile[i].position.Y + (float)height * 0.5f);
					float num8 = x - vector2.X;
					float num9 = y - vector2.Y;
					float num10 = (float)Math.Sqrt(num8 * num8 + num9 * num9);
					num10 = num7 / num10;
					num8 *= num10;
					num9 *= num10;
					Projectile.NewProjectile(Main.projectile[i].center().X - 4f, Main.projectile[i].center().Y, num8, num9, 227, 50, 5f, whoAmi);
					break;
				}
			}
		}

		public void openPresent()
		{
			if (Main.rand.Next(15) == 0 && Main.hardMode)
			{
				int number = Item.NewItem((int)position.X, (int)position.Y, width, height, 602);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f);
				}
				return;
			}
			if (Main.rand.Next(400) == 0)
			{
				int number2 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1927);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number2, 1f);
				}
				return;
			}
			if (Main.rand.Next(150) == 0)
			{
				int number3 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1870);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number3, 1f);
				}
				number3 = Item.NewItem((int)position.X, (int)position.Y, width, height, 97, Main.rand.Next(30, 61));
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number3, 1f);
				}
				return;
			}
			if (Main.rand.Next(150) == 0)
			{
				int number4 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1909);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number4, 1f);
				}
				return;
			}
			if (Main.rand.Next(150) == 0)
			{
				int number5 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1917);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number5, 1f);
				}
				return;
			}
			if (Main.rand.Next(150) == 0)
			{
				int number6 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1915);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number6, 1f);
				}
				return;
			}
			if (Main.rand.Next(150) == 0)
			{
				int number7 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1918);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number7, 1f);
				}
				return;
			}
			if (Main.rand.Next(150) == 0)
			{
				int number8 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1921);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number8, 1f);
				}
				return;
			}
			if (Main.rand.Next(300) == 0)
			{
				int number9 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1923);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number9, 1f);
				}
				return;
			}
			if (Main.rand.Next(40) == 0)
			{
				int number10 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1907);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number10, 1f);
				}
				return;
			}
			if (Main.rand.Next(10) == 0)
			{
				int number11 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1908);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number11, 1f);
				}
				return;
			}
			if (Main.rand.Next(15) == 0)
			{
				switch (Main.rand.Next(5))
				{
				case 0:
				{
					int number13 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1932);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f);
					}
					number13 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1933);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f);
					}
					number13 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1934);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number13, 1f);
					}
					break;
				}
				case 1:
				{
					int number15 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1935);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number15, 1f);
					}
					number15 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1936);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number15, 1f);
					}
					number15 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1937);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number15, 1f);
					}
					break;
				}
				case 2:
				{
					int number16 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1940);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number16, 1f);
					}
					number16 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1941);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number16, 1f);
					}
					number16 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1942);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number16, 1f);
					}
					break;
				}
				case 3:
				{
					int number14 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1938);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number14, 1f);
					}
					break;
				}
				case 4:
				{
					int number12 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1939);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number12, 1f);
					}
					break;
				}
				}
				return;
			}
			if (Main.rand.Next(7) == 0)
			{
				int num = Main.rand.Next(3);
				if (num == 0)
				{
					num = 1911;
				}
				if (num == 1)
				{
					num = 1919;
				}
				if (num == 2)
				{
					num = 1920;
				}
				int number17 = Item.NewItem((int)position.X, (int)position.Y, width, height, num);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number17, 1f);
				}
				return;
			}
			if (Main.rand.Next(8) == 0)
			{
				int number18 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1912, Main.rand.Next(1, 4));
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number18, 1f);
				}
				return;
			}
			if (Main.rand.Next(9) == 0)
			{
				int number19 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1913, Main.rand.Next(20, 41));
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number19, 1f);
				}
				return;
			}
			switch (Main.rand.Next(3))
			{
			case 0:
			{
				int number21 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1872, Main.rand.Next(20, 50));
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number21, 1f);
				}
				break;
			}
			case 1:
			{
				int number22 = Item.NewItem((int)position.X, (int)position.Y, width, height, 586, Main.rand.Next(20, 50));
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number22, 1f);
				}
				break;
			}
			default:
			{
				int number20 = Item.NewItem((int)position.X, (int)position.Y, width, height, 591, Main.rand.Next(20, 50));
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number20, 1f);
				}
				break;
			}
			}
		}

		public void openCrate(int type)
		{
			switch (type - 2334)
			{
			case 0:
			{
				bool flag2 = true;
				while (flag2)
				{
					if (Main.hardMode && flag2 && Main.rand.Next(25) == 0)
					{
						int type5 = 2424;
						int stack6 = 1;
						int number6 = Item.NewItem((int)position.X, (int)position.Y, width, height, type5, stack6);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number6, 1f);
						}
						flag2 = false;
					}
					if (Main.rand.Next(7) == 0)
					{
						int type6;
						int stack7;
						if (Main.rand.Next(3) == 0)
						{
							type6 = 73;
							stack7 = Main.rand.Next(1, 6);
						}
						else
						{
							type6 = 72;
							stack7 = Main.rand.Next(20, 91);
						}
						int number7 = Item.NewItem((int)position.X, (int)position.Y, width, height, type6, stack7);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number7, 1f);
						}
						flag2 = false;
					}
					if (Main.rand.Next(7) == 0)
					{
						int num3 = Main.rand.Next(8);
						switch (num3)
						{
						case 0:
							num3 = 12;
							break;
						case 1:
							num3 = 11;
							break;
						case 2:
							num3 = 14;
							break;
						case 3:
							num3 = 13;
							break;
						case 4:
							num3 = 699;
							break;
						case 5:
							num3 = 700;
							break;
						case 6:
							num3 = 701;
							break;
						case 7:
							num3 = 702;
							break;
						}
						if (Main.hardMode && Main.rand.Next(2) == 0)
						{
							num3 = Main.rand.Next(6);
							switch (num3)
							{
							case 0:
								num3 = 364;
								break;
							case 1:
								num3 = 365;
								break;
							case 2:
								num3 = 366;
								break;
							case 3:
								num3 = 1104;
								break;
							case 4:
								num3 = 1105;
								break;
							case 5:
								num3 = 1106;
								break;
							}
						}
						int stack8 = Main.rand.Next(8, 21);
						int number8 = Item.NewItem((int)position.X, (int)position.Y, width, height, num3, stack8);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number8, 1f);
						}
						flag2 = false;
					}
					if (Main.rand.Next(8) == 0)
					{
						int num4 = Main.rand.Next(8);
						switch (num4)
						{
						case 0:
							num4 = 20;
							break;
						case 1:
							num4 = 22;
							break;
						case 2:
							num4 = 21;
							break;
						case 3:
							num4 = 19;
							break;
						case 4:
							num4 = 703;
							break;
						case 5:
							num4 = 704;
							break;
						case 6:
							num4 = 705;
							break;
						case 7:
							num4 = 706;
							break;
						}
						int num5 = Main.rand.Next(2, 8);
						if (Main.hardMode && Main.rand.Next(2) == 0)
						{
							num4 = Main.rand.Next(6);
							switch (num4)
							{
							case 0:
								num4 = 381;
								break;
							case 1:
								num4 = 382;
								break;
							case 2:
								num4 = 391;
								break;
							case 3:
								num4 = 1184;
								break;
							case 4:
								num4 = 1191;
								break;
							case 5:
								num4 = 1198;
								break;
							}
							num5 -= Main.rand.Next(2);
						}
						int number9 = Item.NewItem((int)position.X, (int)position.Y, width, height, num4, num5);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number9, 1f);
						}
						flag2 = false;
					}
					if (Main.rand.Next(7) == 0)
					{
						int num6 = Main.rand.Next(10);
						switch (num6)
						{
						case 0:
							num6 = 288;
							break;
						case 1:
							num6 = 290;
							break;
						case 2:
							num6 = 292;
							break;
						case 3:
							num6 = 299;
							break;
						case 4:
							num6 = 298;
							break;
						case 5:
							num6 = 304;
							break;
						case 6:
							num6 = 291;
							break;
						case 7:
							num6 = 2322;
							break;
						case 8:
							num6 = 2323;
							break;
						case 9:
							num6 = 2329;
							break;
						}
						int stack9 = Main.rand.Next(1, 4);
						int number10 = Item.NewItem((int)position.X, (int)position.Y, width, height, num6, stack9);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number10, 1f);
						}
						flag2 = false;
					}
				}
				if (Main.rand.Next(3) == 0)
				{
					int num7 = Main.rand.Next(2);
					switch (num7)
					{
					case 0:
						num7 = 28;
						break;
					case 1:
						num7 = 110;
						break;
					}
					int stack10 = Main.rand.Next(5, 16);
					int number11 = Item.NewItem((int)position.X, (int)position.Y, width, height, num7, stack10);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number11, 1f);
					}
				}
				break;
			}
			case 1:
			{
				bool flag3 = true;
				while (flag3)
				{
					if (flag3 && Main.rand.Next(25) == 0)
					{
						int type7 = 2501;
						int stack11 = 1;
						int number12 = Item.NewItem((int)position.X, (int)position.Y, width, height, type7, stack11);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number12, 1f);
						}
						flag3 = false;
					}
					if (flag3 && Main.rand.Next(20) == 0)
					{
						int type8 = 2587;
						int stack12 = 1;
						int number13 = Item.NewItem((int)position.X, (int)position.Y, width, height, type8, stack12);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number13, 1f);
						}
						flag3 = false;
					}
					if (flag3 && Main.rand.Next(15) == 0)
					{
						int type9 = 2608;
						int stack13 = 1;
						int number14 = Item.NewItem((int)position.X, (int)position.Y, width, height, type9, stack13);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number14, 1f);
						}
						flag3 = false;
					}
					if (Main.rand.Next(4) == 0)
					{
						int type10 = 73;
						int stack14 = Main.rand.Next(5, 11);
						int number15 = Item.NewItem((int)position.X, (int)position.Y, width, height, type10, stack14);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number15, 1f);
						}
						flag3 = false;
					}
					if (Main.rand.Next(4) == 0)
					{
						int num8 = Main.rand.Next(8);
						switch (num8)
						{
						case 0:
							num8 = 20;
							break;
						case 1:
							num8 = 22;
							break;
						case 2:
							num8 = 21;
							break;
						case 3:
							num8 = 19;
							break;
						case 4:
							num8 = 703;
							break;
						case 5:
							num8 = 704;
							break;
						case 6:
							num8 = 705;
							break;
						case 7:
							num8 = 706;
							break;
						}
						int num9 = Main.rand.Next(6, 15);
						if (Main.hardMode && Main.rand.Next(3) != 0)
						{
							num8 = Main.rand.Next(6);
							switch (num8)
							{
							case 0:
								num8 = 381;
								break;
							case 1:
								num8 = 382;
								break;
							case 2:
								num8 = 391;
								break;
							case 3:
								num8 = 1184;
								break;
							case 4:
								num8 = 1191;
								break;
							case 5:
								num8 = 1198;
								break;
							}
							num9 -= Main.rand.Next(2);
						}
						int number16 = Item.NewItem((int)position.X, (int)position.Y, width, height, num8, num9);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number16, 1f);
						}
						flag3 = false;
					}
					if (Main.rand.Next(4) == 0)
					{
						int num10 = Main.rand.Next(8);
						switch (num10)
						{
						case 0:
							num10 = 288;
							break;
						case 1:
							num10 = 296;
							break;
						case 2:
							num10 = 304;
							break;
						case 3:
							num10 = 305;
							break;
						case 4:
							num10 = 2322;
							break;
						case 5:
							num10 = 2323;
							break;
						case 6:
							num10 = 2324;
							break;
						case 7:
							num10 = 2327;
							break;
						}
						int stack15 = Main.rand.Next(2, 5);
						int number17 = Item.NewItem((int)position.X, (int)position.Y, width, height, num10, stack15);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number17, 1f);
						}
						flag3 = false;
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					int type11 = Main.rand.Next(188, 190);
					int stack16 = Main.rand.Next(5, 16);
					int number18 = Item.NewItem((int)position.X, (int)position.Y, width, height, type11, stack16);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number18, 1f);
					}
				}
				break;
			}
			case 2:
			{
				bool flag = true;
				while (flag)
				{
					if (flag && Main.rand.Next(10) == 0)
					{
						int type2 = 2491;
						int stack = 1;
						int number = Item.NewItem((int)position.X, (int)position.Y, width, height, type2, stack);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number, 1f);
						}
						flag = false;
					}
					if (Main.rand.Next(3) == 0)
					{
						int type3 = 73;
						int stack2 = Main.rand.Next(8, 21);
						int number2 = Item.NewItem((int)position.X, (int)position.Y, width, height, type3, stack2);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number2, 1f);
						}
						flag = false;
					}
					if (Main.rand.Next(3) != 0)
					{
						continue;
					}
					int num = Main.rand.Next(4);
					switch (num)
					{
					case 0:
						num = 21;
						break;
					case 1:
						num = 19;
						break;
					case 2:
						num = 705;
						break;
					case 3:
						num = 706;
						break;
					}
					if (Main.hardMode && Main.rand.Next(3) != 0)
					{
						num = Main.rand.Next(4);
						switch (num)
						{
						case 0:
							num = 382;
							break;
						case 1:
							num = 391;
							break;
						case 2:
							num = 1191;
							break;
						case 3:
							num = 1198;
							break;
						}
					}
					int stack3 = Main.rand.Next(15, 31);
					int number3 = Item.NewItem((int)position.X, (int)position.Y, width, height, num, stack3);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number3, 1f);
					}
					flag = false;
				}
				if (Main.rand.Next(3) == 0)
				{
					int num2 = Main.rand.Next(5);
					switch (num2)
					{
					case 0:
						num2 = 288;
						break;
					case 1:
						num2 = 296;
						break;
					case 2:
						num2 = 305;
						break;
					case 3:
						num2 = 2322;
						break;
					case 4:
						num2 = 2323;
						break;
					}
					int stack4 = Main.rand.Next(2, 6);
					int number4 = Item.NewItem((int)position.X, (int)position.Y, width, height, num2, stack4);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number4, 1f);
					}
				}
				if (Main.rand.Next(2) == 0)
				{
					int type4 = Main.rand.Next(499, 501);
					int stack5 = Main.rand.Next(5, 21);
					int number5 = Item.NewItem((int)position.X, (int)position.Y, width, height, type4, stack5);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number5, 1f);
					}
				}
				break;
			}
			}
		}

		public void openGoodieBag()
		{
			if (Main.rand.Next(150) == 0)
			{
				int number = Item.NewItem((int)position.X, (int)position.Y, width, height, 1810);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f);
				}
				return;
			}
			if (Main.rand.Next(150) == 0)
			{
				int number2 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1800);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number2, 1f);
				}
				return;
			}
			if (Main.rand.Next(3) == 1)
			{
				int number3 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1809, Main.rand.Next(10, 41));
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number3, 1f);
				}
				return;
			}
			if (Main.rand.Next(10) == 0)
			{
				int number4 = Item.NewItem((int)position.X, (int)position.Y, width, height, Main.rand.Next(1846, 1851));
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number4, 1f);
				}
				return;
			}
			switch (Main.rand.Next(19))
			{
			case 0:
			{
				int number6 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1749);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number6, 1f);
				}
				number6 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1750);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number6, 1f);
				}
				number6 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1751);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number6, 1f);
				}
				break;
			}
			case 1:
			{
				int number17 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1746);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number17, 1f);
				}
				number17 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1747);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number17, 1f);
				}
				number17 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1748);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number17, 1f);
				}
				break;
			}
			case 2:
			{
				int number18 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1752);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number18, 1f);
				}
				number18 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1753);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number18, 1f);
				}
				break;
			}
			case 3:
			{
				int number19 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1767);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number19, 1f);
				}
				number19 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1768);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number19, 1f);
				}
				number19 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1769);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number19, 1f);
				}
				break;
			}
			case 4:
			{
				int number11 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1770);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number11, 1f);
				}
				number11 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1771);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number11, 1f);
				}
				break;
			}
			case 5:
			{
				int number8 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1772);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number8, 1f);
				}
				number8 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1773);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number8, 1f);
				}
				break;
			}
			case 6:
			{
				int number22 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1754);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number22, 1f);
				}
				number22 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1755);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number22, 1f);
				}
				number22 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1756);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number22, 1f);
				}
				break;
			}
			case 7:
			{
				int number10 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1757);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number10, 1f);
				}
				number10 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1758);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number10, 1f);
				}
				number10 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1759);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number10, 1f);
				}
				break;
			}
			case 8:
			{
				int number12 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1760);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number12, 1f);
				}
				number12 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1761);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number12, 1f);
				}
				number12 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1762);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number12, 1f);
				}
				break;
			}
			case 9:
			{
				int number20 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1763);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number20, 1f);
				}
				number20 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1764);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number20, 1f);
				}
				number20 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1765);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number20, 1f);
				}
				break;
			}
			case 10:
			{
				int number14 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1766);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number14, 1f);
				}
				number14 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1775);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number14, 1f);
				}
				number14 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1776);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number14, 1f);
				}
				break;
			}
			case 11:
			{
				int number7 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1777);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number7, 1f);
				}
				number7 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1778);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number7, 1f);
				}
				break;
			}
			case 12:
			{
				int number16 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1779);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number16, 1f);
				}
				number16 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1780);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number16, 1f);
				}
				number16 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1781);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number16, 1f);
				}
				break;
			}
			case 13:
			{
				int number13 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1819);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number13, 1f);
				}
				number13 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1820);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number13, 1f);
				}
				break;
			}
			case 14:
			{
				int number23 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1821);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number23, 1f);
				}
				number23 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1822);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number23, 1f);
				}
				number23 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1823);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number23, 1f);
				}
				break;
			}
			case 15:
			{
				int number21 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1824);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number21, 1f);
				}
				break;
			}
			case 16:
			{
				int number15 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1838);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number15, 1f);
				}
				number15 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1839);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number15, 1f);
				}
				number15 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1840);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number15, 1f);
				}
				break;
			}
			case 17:
			{
				int number9 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1841);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number9, 1f);
				}
				number9 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1842);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number9, 1f);
				}
				number9 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1843);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number9, 1f);
				}
				break;
			}
			case 18:
			{
				int number5 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1851);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number5, 1f);
				}
				number5 = Item.NewItem((int)position.X, (int)position.Y, width, height, 1852);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number5, 1f);
				}
				break;
			}
			}
		}

		public void UpdateBuffs(int i)
		{
			int[] array = new int[423];
			for (int j = 0; j < 1000; j++)
			{
				if (Main.projectile[j].active && Main.projectile[j].owner == i)
				{
					array[Main.projectile[j].type]++;
				}
			}
			for (int k = 0; k < 22; k++)
			{
				if (buffType[k] <= 0 || buffTime[k] <= 0)
				{
					continue;
				}
				if (whoAmi == Main.myPlayer && buffType[k] != 28)
				{
					buffTime[k]--;
				}
				if (buffType[k] == 1)
				{
					lavaImmune = true;
					fireWalk = true;
				}
				else if (buffType[k] == 2)
				{
					lifeRegen += 2;
				}
				else if (buffType[k] == 3)
				{
					moveSpeed += 0.25f;
				}
				else if (buffType[k] == 4)
				{
					gills = true;
				}
				else if (buffType[k] == 5)
				{
					statDefense += 8;
				}
				else if (buffType[k] == 6)
				{
					manaRegenBuff = true;
				}
				else if (buffType[k] == 7)
				{
					magicDamage += 0.2f;
				}
				else if (buffType[k] == 8)
				{
					slowFall = true;
				}
				else if (buffType[k] == 9)
				{
					findTreasure = true;
				}
				else if (buffType[k] == 10)
				{
					invis = true;
				}
				else if (buffType[k] == 11)
				{
					Lighting.addLight((int)(position.X + (float)(width / 2)) / 16, (int)(position.Y + (float)(height / 2)) / 16, 0.8f, 0.95f, 1f);
				}
				else if (buffType[k] == 12)
				{
					nightVision = true;
				}
				else if (buffType[k] == 13)
				{
					enemySpawns = true;
				}
				else if (buffType[k] == 14)
				{
					thorns = true;
				}
				else if (buffType[k] == 15)
				{
					waterWalk = true;
				}
				else if (buffType[k] == 16)
				{
					archery = true;
				}
				else if (buffType[k] == 17)
				{
					detectCreature = true;
				}
				else if (buffType[k] == 18)
				{
					gravControl = true;
				}
				else if (buffType[k] == 30)
				{
					bleed = true;
				}
				else if (buffType[k] == 31)
				{
					confused = true;
				}
				else if (buffType[k] == 32)
				{
					slow = true;
				}
				else if (buffType[k] == 35)
				{
					silence = true;
				}
				else if (buffType[k] == 46)
				{
					chilled = true;
				}
				else if (buffType[k] == 47)
				{
					frozen = true;
				}
				else if (buffType[k] == 69)
				{
					ichor = true;
					statDefense -= 20;
				}
				else if (buffType[k] == 36)
				{
					brokenArmor = true;
				}
				else if (buffType[k] == 48)
				{
					honey = true;
				}
				else if (buffType[k] == 59)
				{
					shadowDodge = true;
				}
				else if (buffType[k] == 93)
				{
					ammoBox = true;
				}
				else if (buffType[k] == 58)
				{
					palladiumRegen = true;
				}
				else if (buffType[k] == 88)
				{
					chaosState = true;
				}
				else if (buffType[k] == 63)
				{
					moveSpeed += 1f;
				}
				else if (buffType[k] == 104)
				{
					pickSpeed -= 0.25f;
				}
				else if (buffType[k] == 105)
				{
					lifeMagnet = true;
				}
				else if (buffType[k] == 106)
				{
					calmed = true;
				}
				else if (buffType[k] == 121)
				{
					fishingSkill += 15;
				}
				else if (buffType[k] == 122)
				{
					sonarPotion = true;
				}
				else if (buffType[k] == 123)
				{
					cratePotion = true;
				}
				else if (buffType[k] == 107)
				{
					tileSpeed += 0.25f;
					wallSpeed += 0.25f;
					blockRange++;
				}
				else if (buffType[k] == 108)
				{
					kbBuff = true;
				}
				else if (buffType[k] == 109)
				{
					ignoreWater = true;
					accFlipper = true;
				}
				else if (buffType[k] == 110)
				{
					maxMinions++;
				}
				else if (buffType[k] == 111)
				{
					dangerSense = true;
				}
				else if (buffType[k] == 112)
				{
					ammoPotion = true;
				}
				else if (buffType[k] == 113)
				{
					lifeForce = true;
					statLifeMax2 += statLifeMax / 5 / 20 * 20;
				}
				else if (buffType[k] == 114)
				{
					endurance += 0.1f;
				}
				else if (buffType[k] == 115)
				{
					meleeCrit += 10;
					rangedCrit += 10;
					magicCrit += 10;
				}
				else if (buffType[k] == 116)
				{
					inferno = true;
					Lighting.addLight((int)(Center().X / 16f), (int)(Center().Y / 16f), 0.65f, 0.4f, 0.1f);
					int num = 24;
					float num2 = 200f;
					bool flag = infernoCounter % 60 == 0;
					int num3 = 10;
					if (whoAmi != Main.myPlayer)
					{
						continue;
					}
					for (int l = 0; l < 200; l++)
					{
						NPC nPC = Main.npc[l];
						if (!nPC.active || nPC.friendly || nPC.damage <= 0 || nPC.dontTakeDamage || nPC.buffImmune[num] || !(Vector2.Distance(center(), nPC.center()) <= num2))
						{
							continue;
						}
						if (nPC.HasBuff(num) == -1)
						{
							nPC.AddBuff(num, 120);
						}
						if (flag)
						{
							nPC.StrikeNPC(num3, 0f, 0);
							if (Main.netMode != 0)
							{
								NetMessage.SendData(28, -1, -1, "", l, num3);
							}
						}
					}
					if (!hostile)
					{
						continue;
					}
					for (int m = 0; m < 255; m++)
					{
						Player player = Main.player[m];
						if (player == this || !player.active || player.dead || !player.hostile || player.buffImmune[num] || (player.team == team && player.team != 0) || !(Vector2.Distance(center(), player.center()) <= num2))
						{
							continue;
						}
						if (player.HasBuff(num) == -1)
						{
							player.AddBuff(num, 120);
						}
						if (flag)
						{
							player.Hurt(num3, 0, true, false, "");
							if (Main.netMode != 0)
							{
								NetMessage.SendData(26, -1, -1, Lang.deathMsg(whoAmi), m, 0f, num3, 1f);
							}
						}
					}
				}
				else if (buffType[k] == 117)
				{
					meleeDamage += 0.1f;
					rangedDamage += 0.1f;
					magicDamage += 0.1f;
					minionDamage += 0.1f;
				}
				else if (buffType[k] == 119)
				{
					loveStruck = true;
				}
				else if (buffType[k] == 120)
				{
					stinky = true;
				}
				else if (buffType[k] == 124)
				{
					resistCold = true;
				}
				else if (buffType[k] == 94)
				{
					manaSick = true;
					manaSickReduction = manaSickLessDmg * ((float)buffTime[k] / (float)manaSickTime);
				}
				else if (buffType[k] >= 95 && buffType[k] <= 97)
				{
					buffTime[k] = 5;
					int num4 = (byte)(1 + buffType[k] - 95);
					if (beetleOrbs > 0 && beetleOrbs != num4)
					{
						if (beetleOrbs > num4)
						{
							DelBuff(k);
							k--;
						}
						else
						{
							for (int n = 0; n < 22; n++)
							{
								if (buffType[n] >= 95 && buffType[n] <= 95 + num4 - 1)
								{
									DelBuff(n);
									n--;
								}
							}
						}
					}
					beetleOrbs = num4;
					if (!beetleDefense)
					{
						beetleOrbs = 0;
						DelBuff(k);
						k--;
					}
					else
					{
						beetleBuff = true;
					}
				}
				else if (buffType[k] >= 98 && buffType[k] <= 100)
				{
					int num5 = (byte)(1 + buffType[k] - 98);
					if (beetleOrbs > 0 && beetleOrbs != num5)
					{
						if (beetleOrbs > num5)
						{
							DelBuff(k);
							k--;
						}
						else
						{
							for (int num6 = 0; num6 < 22; num6++)
							{
								if (buffType[num6] >= 98 && buffType[num6] <= 98 + num5 - 1)
								{
									DelBuff(num6);
									num6--;
								}
							}
						}
					}
					beetleOrbs = num5;
					meleeDamage += 0.1f * (float)beetleOrbs;
					meleeSpeed += 0.1f * (float)beetleOrbs;
					if (!beetleOffense)
					{
						beetleOrbs = 0;
						DelBuff(k);
						k--;
					}
					else
					{
						beetleBuff = true;
					}
				}
				else if (buffType[k] == 62)
				{
					if ((double)statLife <= (double)statLifeMax2 * 0.25)
					{
						Lighting.addLight((int)(Center().X / 16f), (int)(Center().Y / 16f), 0.1f, 0.2f, 0.45f);
						iceBarrier = true;
						statDefense += 30;
						iceBarrierFrameCounter++;
						if (iceBarrierFrameCounter > 2)
						{
							iceBarrierFrameCounter = 0;
							iceBarrierFrame++;
							if (iceBarrierFrame >= 12)
							{
								iceBarrierFrame = 0;
							}
						}
					}
					else
					{
						DelBuff(k);
						k--;
					}
				}
				else if (buffType[k] == 49)
				{
					for (int num7 = 191; num7 <= 194; num7++)
					{
						if (array[num7] > 0)
						{
							pygmy = true;
						}
					}
					if (!pygmy)
					{
						DelBuff(k);
						k--;
					}
					else
					{
						buffTime[k] = 18000;
					}
				}
				else if (buffType[k] == 83)
				{
					if (array[317] > 0)
					{
						raven = true;
					}
					if (!raven)
					{
						DelBuff(k);
						k--;
					}
					else
					{
						buffTime[k] = 18000;
					}
				}
				else if (buffType[k] == 64)
				{
					if (array[266] > 0)
					{
						slime = true;
					}
					if (!slime)
					{
						DelBuff(k);
						k--;
					}
					else
					{
						buffTime[k] = 18000;
					}
				}
				else if (buffType[k] == 125)
				{
					if (array[373] > 0)
					{
						hornetMinion = true;
					}
					if (!hornetMinion)
					{
						DelBuff(k);
						k--;
					}
					else
					{
						buffTime[k] = 18000;
					}
				}
				else if (buffType[k] == 126)
				{
					if (array[375] > 0)
					{
						impMinion = true;
					}
					if (!impMinion)
					{
						DelBuff(k);
						k--;
					}
					else
					{
						buffTime[k] = 18000;
					}
				}
				else if (buffType[k] == 133)
				{
					if (array[390] > 0 || array[391] > 0 || array[392] > 0)
					{
						spiderMinion = true;
					}
					if (!spiderMinion)
					{
						DelBuff(k);
						k--;
					}
					else
					{
						buffTime[k] = 18000;
					}
				}
				else if (buffType[k] == 134)
				{
					if (array[387] > 0 || array[388] > 0)
					{
						twinsMinion = true;
					}
					if (!twinsMinion)
					{
						DelBuff(k);
						k--;
					}
					else
					{
						buffTime[k] = 18000;
					}
				}
				else if (buffType[k] == 135)
				{
					if (array[393] > 0 || array[394] > 0 || array[395] > 0)
					{
						pirateMinion = true;
					}
					if (!pirateMinion)
					{
						DelBuff(k);
						k--;
					}
					else
					{
						buffTime[k] = 18000;
					}
				}
				else if (buffType[k] == 139)
				{
					if (array[407] > 0)
					{
						sharknadoMinion = true;
					}
					if (!sharknadoMinion)
					{
						DelBuff(k);
						k--;
					}
					else
					{
						buffTime[k] = 18000;
					}
				}
				else if (buffType[k] == 90)
				{
					mount.SetMount(0, this);
					buffTime[k] = 10;
				}
				else if (buffType[k] == 128)
				{
					mount.SetMount(1, this);
					buffTime[k] = 10;
				}
				else if (buffType[k] == 129)
				{
					mount.SetMount(2, this);
					buffTime[k] = 10;
				}
				else if (buffType[k] == 130)
				{
					mount.SetMount(3, this);
					buffTime[k] = 10;
				}
				else if (buffType[k] == 118)
				{
					mount.SetMount(6, this, true);
					buffTime[k] = 10;
				}
				else if (buffType[k] == 138)
				{
					mount.SetMount(6, this);
					buffTime[k] = 10;
				}
				else if (buffType[k] == 131)
				{
					ignoreWater = true;
					accFlipper = true;
					mount.SetMount(4, this);
					buffTime[k] = 10;
				}
				else if (buffType[k] == 132)
				{
					mount.SetMount(5, this);
					buffTime[k] = 10;
				}
				else if (buffType[k] == 37)
				{
					if (Main.wof >= 0 && Main.npc[Main.wof].type == 113)
					{
						gross = true;
						buffTime[k] = 10;
					}
					else
					{
						DelBuff(k);
						k--;
					}
				}
				else if (buffType[k] == 38)
				{
					buffTime[k] = 10;
					tongued = true;
				}
				else if (buffType[k] == 19)
				{
					buffTime[k] = 18000;
					lightOrb = true;
					bool flag2 = true;
					if (array[18] > 0)
					{
						flag2 = false;
					}
					if (flag2)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 18, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 27 || buffType[k] == 101 || buffType[k] == 102)
				{
					buffTime[k] = 18000;
					bool flag3 = true;
					int num8 = 72;
					if (buffType[k] == 27)
					{
						blueFairy = true;
					}
					if (buffType[k] == 101)
					{
						num8 = 86;
						redFairy = true;
					}
					if (buffType[k] == 102)
					{
						num8 = 87;
						greenFairy = true;
					}
					if (head == 45 && body == 26 && legs == 25)
					{
						num8 = 72;
					}
					if (array[num8] > 0)
					{
						flag3 = false;
					}
					if (flag3)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, num8, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 40)
				{
					buffTime[k] = 18000;
					bunny = true;
					bool flag4 = true;
					if (array[111] > 0)
					{
						flag4 = false;
					}
					if (flag4)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 111, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 41)
				{
					buffTime[k] = 18000;
					penguin = true;
					bool flag5 = true;
					if (array[112] > 0)
					{
						flag5 = false;
					}
					if (flag5)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 112, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 91)
				{
					buffTime[k] = 18000;
					puppy = true;
					bool flag6 = true;
					if (array[334] > 0)
					{
						flag6 = false;
					}
					if (flag6)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 334, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 92)
				{
					buffTime[k] = 18000;
					grinch = true;
					bool flag7 = true;
					if (array[353] > 0)
					{
						flag7 = false;
					}
					if (flag7)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 353, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 84)
				{
					buffTime[k] = 18000;
					blackCat = true;
					bool flag8 = true;
					if (array[319] > 0)
					{
						flag8 = false;
					}
					if (flag8)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 319, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 61)
				{
					buffTime[k] = 18000;
					dino = true;
					bool flag9 = true;
					if (array[236] > 0)
					{
						flag9 = false;
					}
					if (flag9)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 236, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 65)
				{
					buffTime[k] = 18000;
					eyeSpring = true;
					bool flag10 = true;
					if (array[268] > 0)
					{
						flag10 = false;
					}
					if (flag10)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 268, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 66)
				{
					buffTime[k] = 18000;
					snowman = true;
					bool flag11 = true;
					if (array[269] > 0)
					{
						flag11 = false;
					}
					if (flag11)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 269, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 42)
				{
					buffTime[k] = 18000;
					turtle = true;
					bool flag12 = true;
					if (array[127] > 0)
					{
						flag12 = false;
					}
					if (flag12)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 127, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 45)
				{
					buffTime[k] = 18000;
					eater = true;
					bool flag13 = true;
					if (array[175] > 0)
					{
						flag13 = false;
					}
					if (flag13)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 175, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 50)
				{
					buffTime[k] = 18000;
					skeletron = true;
					bool flag14 = true;
					if (array[197] > 0)
					{
						flag14 = false;
					}
					if (flag14)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 197, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 51)
				{
					buffTime[k] = 18000;
					hornet = true;
					bool flag15 = true;
					if (array[198] > 0)
					{
						flag15 = false;
					}
					if (flag15)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 198, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 52)
				{
					buffTime[k] = 18000;
					tiki = true;
					bool flag16 = true;
					if (array[199] > 0)
					{
						flag16 = false;
					}
					if (flag16)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 199, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 53)
				{
					buffTime[k] = 18000;
					lizard = true;
					bool flag17 = true;
					if (array[200] > 0)
					{
						flag17 = false;
					}
					if (flag17)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 200, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 54)
				{
					buffTime[k] = 18000;
					parrot = true;
					bool flag18 = true;
					if (array[208] > 0)
					{
						flag18 = false;
					}
					if (flag18)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 208, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 55)
				{
					buffTime[k] = 18000;
					truffle = true;
					bool flag19 = true;
					if (array[209] > 0)
					{
						flag19 = false;
					}
					if (flag19)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 209, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 56)
				{
					buffTime[k] = 18000;
					sapling = true;
					bool flag20 = true;
					if (array[210] > 0)
					{
						flag20 = false;
					}
					if (flag20)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 210, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 85)
				{
					buffTime[k] = 18000;
					cSapling = true;
					bool flag21 = true;
					if (array[324] > 0)
					{
						flag21 = false;
					}
					if (flag21)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 324, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 81)
				{
					buffTime[k] = 18000;
					spider = true;
					bool flag22 = true;
					if (array[313] > 0)
					{
						flag22 = false;
					}
					if (flag22)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 313, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 82)
				{
					buffTime[k] = 18000;
					squashling = true;
					bool flag23 = true;
					if (array[314] > 0)
					{
						flag23 = false;
					}
					if (flag23)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 314, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 57)
				{
					buffTime[k] = 18000;
					wisp = true;
					bool flag24 = true;
					if (array[211] > 0)
					{
						flag24 = false;
					}
					if (flag24)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 211, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 60)
				{
					buffTime[k] = 18000;
					crystalLeaf = true;
					bool flag25 = true;
					for (int num9 = 0; num9 < 1000; num9++)
					{
						if (Main.projectile[num9].active && Main.projectile[num9].owner == whoAmi && Main.projectile[num9].type == 226)
						{
							if (!flag25)
							{
								Main.projectile[num9].Kill();
							}
							flag25 = false;
						}
					}
					if (flag25)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 226, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 127)
				{
					buffTime[k] = 18000;
					zephyrfish = true;
					bool flag26 = true;
					if (array[380] > 0)
					{
						flag26 = false;
					}
					if (flag26)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 380, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 136)
				{
					buffTime[k] = 18000;
					miniMinotaur = true;
					bool flag27 = true;
					if (array[398] > 0)
					{
						flag27 = false;
					}
					if (flag27)
					{
						Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), 0f, 0f, 398, 0, 0f, whoAmi);
					}
				}
				else if (buffType[k] == 70)
				{
					venom = true;
				}
				else if (buffType[k] == 20)
				{
					poisoned = true;
				}
				else if (buffType[k] == 21)
				{
					potionDelay = buffTime[k];
				}
				else if (buffType[k] == 22)
				{
					blind = true;
				}
				else if (buffType[k] == 80)
				{
					blackout = true;
				}
				else if (buffType[k] == 23)
				{
					noItems = true;
				}
				else if (buffType[k] == 24)
				{
					onFire = true;
				}
				else if (buffType[k] == 103)
				{
					dripping = true;
				}
				else if (buffType[k] == 137)
				{
					drippingSlime = true;
				}
				else if (buffType[k] == 67)
				{
					burned = true;
				}
				else if (buffType[k] == 68)
				{
					suffocating = true;
				}
				else if (buffType[k] == 39)
				{
					onFire2 = true;
				}
				else if (buffType[k] == 44)
				{
					onFrostBurn = true;
				}
				else if (buffType[k] == 43)
				{
					paladinBuff = true;
				}
				else if (buffType[k] == 29)
				{
					magicCrit += 2;
					magicDamage += 0.05f;
					statManaMax2 += 20;
					manaCost -= 0.02f;
				}
				else if (buffType[k] == 28)
				{
					if (!Main.dayTime && wolfAcc && !merman)
					{
						lifeRegen++;
						wereWolf = true;
						meleeCrit += 2;
						meleeDamage += 0.051f;
						meleeSpeed += 0.051f;
						statDefense += 3;
						moveSpeed += 0.05f;
					}
					else
					{
						DelBuff(k);
						k--;
					}
				}
				else if (buffType[k] == 33)
				{
					meleeDamage -= 0.051f;
					meleeSpeed -= 0.051f;
					statDefense -= 4;
					moveSpeed -= 0.1f;
				}
				else if (buffType[k] == 25)
				{
					statDefense -= 4;
					meleeCrit += 2;
					meleeDamage += 0.1f;
					meleeSpeed += 0.1f;
				}
				else if (buffType[k] == 26)
				{
					statDefense += 2;
					meleeCrit += 2;
					meleeDamage += 0.05f;
					meleeSpeed += 0.05f;
					magicCrit += 2;
					magicDamage += 0.05f;
					rangedCrit += 2;
					rangedDamage += 0.05f;
					minionDamage += 0.05f;
					minionKB += 0.5f;
					moveSpeed += 0.2f;
				}
				else if (buffType[k] == 71)
				{
					meleeEnchant = 1;
				}
				else if (buffType[k] == 73)
				{
					meleeEnchant = 2;
				}
				else if (buffType[k] == 74)
				{
					meleeEnchant = 3;
				}
				else if (buffType[k] == 75)
				{
					meleeEnchant = 4;
				}
				else if (buffType[k] == 76)
				{
					meleeEnchant = 5;
				}
				else if (buffType[k] == 77)
				{
					meleeEnchant = 6;
				}
				else if (buffType[k] == 78)
				{
					meleeEnchant = 7;
				}
				else if (buffType[k] == 79)
				{
					meleeEnchant = 8;
				}
			}
		}

		public void UpdateEquips(int i)
		{
			for (int j = 0; j < 8; j++)
			{
				statDefense += armor[j].defense;
				lifeRegen += armor[j].lifeRegen;
				if (armor[j].type == 268)
				{
					accDivingHelm = true;
				}
				if (armor[j].type == 238)
				{
					magicDamage += 0.15f;
				}
				if (armor[j].type == 2277)
				{
					magicDamage += 0.05f;
					meleeDamage += 0.05f;
					rangedDamage += 0.05f;
					magicCrit += 5;
					rangedCrit += 5;
					meleeCrit += 5;
					meleeSpeed += 0.1f;
					moveSpeed += 0.1f;
				}
				if (armor[j].type == 2279)
				{
					magicDamage += 0.06f;
					magicCrit += 6;
					manaCost -= 0.1f;
				}
				if (armor[j].type == 2275)
				{
					magicDamage += 0.07f;
					magicCrit += 7;
				}
				if (armor[j].type == 123 || armor[j].type == 124 || armor[j].type == 125)
				{
					magicDamage += 0.07f;
				}
				if (armor[j].type == 151 || armor[j].type == 152 || armor[j].type == 153 || armor[j].type == 959)
				{
					rangedDamage += 0.05f;
				}
				if (armor[j].type == 111 || armor[j].type == 228 || armor[j].type == 229 || armor[j].type == 230 || armor[j].type == 960 || armor[j].type == 961 || armor[j].type == 962)
				{
					statManaMax2 += 20;
				}
				if (armor[j].type == 228 || armor[j].type == 229 || armor[j].type == 230 || armor[j].type == 960 || armor[j].type == 961 || armor[j].type == 962)
				{
					magicCrit += 3;
				}
				if (armor[j].type == 100 || armor[j].type == 101 || armor[j].type == 102)
				{
					meleeSpeed += 0.07f;
				}
				if (armor[j].type == 956 || armor[j].type == 957 || armor[j].type == 958)
				{
					meleeSpeed += 0.07f;
				}
				if (armor[j].type == 791 || armor[j].type == 792 || armor[j].type == 793)
				{
					meleeDamage += 0.02f;
					rangedDamage += 0.02f;
					magicDamage += 0.02f;
				}
				if (armor[j].type == 371)
				{
					magicCrit += 9;
					statManaMax2 += 40;
				}
				if (armor[j].type == 372)
				{
					moveSpeed += 0.07f;
					meleeSpeed += 0.12f;
				}
				if (armor[j].type == 373)
				{
					rangedDamage += 0.1f;
					rangedCrit += 6;
				}
				if (armor[j].type == 374)
				{
					magicCrit += 3;
					meleeCrit += 3;
					rangedCrit += 3;
				}
				if (armor[j].type == 375)
				{
					moveSpeed += 0.1f;
				}
				if (armor[j].type == 376)
				{
					magicDamage += 0.15f;
					statManaMax2 += 60;
				}
				if (armor[j].type == 377)
				{
					meleeCrit += 5;
					meleeDamage += 0.1f;
				}
				if (armor[j].type == 378)
				{
					rangedDamage += 0.12f;
					rangedCrit += 7;
				}
				if (armor[j].type == 379)
				{
					rangedDamage += 0.05f;
					meleeDamage += 0.05f;
					magicDamage += 0.05f;
				}
				if (armor[j].type == 380)
				{
					magicCrit += 3;
					meleeCrit += 3;
					rangedCrit += 3;
				}
				if (armor[j].type >= 2367 && armor[j].type <= 2369)
				{
					fishingSkill += 5;
				}
				if (armor[j].type == 400)
				{
					magicDamage += 0.11f;
					magicCrit += 11;
					statManaMax2 += 80;
				}
				if (armor[j].type == 401)
				{
					meleeCrit += 7;
					meleeDamage += 0.14f;
				}
				if (armor[j].type == 402)
				{
					rangedDamage += 0.14f;
					rangedCrit += 8;
				}
				if (armor[j].type == 403)
				{
					rangedDamage += 0.06f;
					meleeDamage += 0.06f;
					magicDamage += 0.06f;
				}
				if (armor[j].type == 404)
				{
					magicCrit += 4;
					meleeCrit += 4;
					rangedCrit += 4;
					moveSpeed += 0.05f;
				}
				if (armor[j].type == 1205)
				{
					meleeDamage += 0.08f;
					meleeSpeed += 0.12f;
				}
				if (armor[j].type == 1206)
				{
					rangedDamage += 0.09f;
					rangedCrit += 9;
				}
				if (armor[j].type == 1207)
				{
					magicDamage += 0.07f;
					magicCrit += 7;
					statManaMax2 += 60;
				}
				if (armor[j].type == 1208)
				{
					meleeDamage += 0.03f;
					rangedDamage += 0.03f;
					magicDamage += 0.03f;
					magicCrit += 2;
					meleeCrit += 2;
					rangedCrit += 2;
				}
				if (armor[j].type == 1209)
				{
					meleeDamage += 0.02f;
					rangedDamage += 0.02f;
					magicDamage += 0.02f;
					magicCrit++;
					meleeCrit++;
					rangedCrit++;
				}
				if (armor[j].type == 1210)
				{
					meleeDamage += 0.07f;
					meleeSpeed += 0.07f;
					moveSpeed += 0.07f;
				}
				if (armor[j].type == 1211)
				{
					rangedCrit += 15;
					moveSpeed += 0.08f;
				}
				if (armor[j].type == 1212)
				{
					magicCrit += 18;
					statManaMax2 += 80;
				}
				if (armor[j].type == 1213)
				{
					magicCrit += 6;
					meleeCrit += 6;
					rangedCrit += 6;
				}
				if (armor[j].type == 1214)
				{
					moveSpeed += 0.11f;
				}
				if (armor[j].type == 1215)
				{
					meleeDamage += 0.08f;
					meleeCrit += 8;
					meleeSpeed += 0.08f;
				}
				if (armor[j].type == 1216)
				{
					rangedDamage += 0.16f;
					rangedCrit += 7;
				}
				if (armor[j].type == 1217)
				{
					magicDamage += 0.16f;
					magicCrit += 7;
					statManaMax2 += 100;
				}
				if (armor[j].type == 1218)
				{
					meleeDamage += 0.04f;
					rangedDamage += 0.04f;
					magicDamage += 0.04f;
					magicCrit += 3;
					meleeCrit += 3;
					rangedCrit += 3;
				}
				if (armor[j].type == 1219)
				{
					meleeDamage += 0.03f;
					rangedDamage += 0.03f;
					magicDamage += 0.03f;
					magicCrit += 3;
					meleeCrit += 3;
					rangedCrit += 3;
					moveSpeed += 0.06f;
				}
				if (armor[j].type == 558)
				{
					magicDamage += 0.12f;
					magicCrit += 12;
					statManaMax2 += 100;
				}
				if (armor[j].type == 559)
				{
					meleeCrit += 10;
					meleeDamage += 0.1f;
					meleeSpeed += 0.1f;
				}
				if (armor[j].type == 553)
				{
					rangedDamage += 0.15f;
					rangedCrit += 8;
				}
				if (armor[j].type == 551)
				{
					magicCrit += 7;
					meleeCrit += 7;
					rangedCrit += 7;
				}
				if (armor[j].type == 552)
				{
					rangedDamage += 0.07f;
					meleeDamage += 0.07f;
					magicDamage += 0.07f;
					moveSpeed += 0.08f;
				}
				if (armor[j].type == 1001)
				{
					meleeDamage += 0.16f;
					meleeCrit += 6;
				}
				if (armor[j].type == 1002)
				{
					rangedDamage += 0.16f;
					ammoCost80 = true;
				}
				if (armor[j].type == 1003)
				{
					statManaMax2 += 80;
					manaCost -= 0.17f;
					magicDamage += 0.16f;
				}
				if (armor[j].type == 1004)
				{
					meleeDamage += 0.05f;
					magicDamage += 0.05f;
					rangedDamage += 0.05f;
					magicCrit += 7;
					meleeCrit += 7;
					rangedCrit += 7;
				}
				if (armor[j].type == 1005)
				{
					magicCrit += 8;
					meleeCrit += 8;
					rangedCrit += 8;
					moveSpeed += 0.05f;
				}
				if (armor[j].type == 2189)
				{
					statManaMax2 += 60;
					manaCost -= 0.13f;
					magicDamage += 0.05f;
					magicCrit += 5;
				}
				if (armor[j].type == 1503)
				{
					magicDamage -= 0.4f;
				}
				if (armor[j].type == 1504)
				{
					magicDamage += 0.07f;
					magicCrit += 7;
				}
				if (armor[j].type == 1505)
				{
					magicDamage += 0.08f;
					moveSpeed += 0.08f;
				}
				if (armor[j].type == 1546)
				{
					rangedCrit += 5;
					arrowDamage += 0.15f;
				}
				if (armor[j].type == 1547)
				{
					rangedCrit += 5;
					bulletDamage += 0.15f;
				}
				if (armor[j].type == 1548)
				{
					rangedCrit += 5;
					rocketDamage += 0.15f;
				}
				if (armor[j].type == 1549)
				{
					rangedCrit += 13;
					rangedDamage += 0.13f;
					ammoCost80 = true;
				}
				if (armor[j].type == 1550)
				{
					rangedCrit += 7;
					moveSpeed += 0.12f;
				}
				if (armor[j].type == 1282)
				{
					statManaMax2 += 20;
					manaCost -= 0.05f;
				}
				if (armor[j].type == 1283)
				{
					statManaMax2 += 40;
					manaCost -= 0.07f;
				}
				if (armor[j].type == 1284)
				{
					statManaMax2 += 40;
					manaCost -= 0.09f;
				}
				if (armor[j].type == 1285)
				{
					statManaMax2 += 60;
					manaCost -= 0.11f;
				}
				if (armor[j].type == 1286)
				{
					statManaMax2 += 60;
					manaCost -= 0.13f;
				}
				if (armor[j].type == 1287)
				{
					statManaMax2 += 80;
					manaCost -= 0.15f;
				}
				if (armor[j].type == 1316 || armor[j].type == 1317 || armor[j].type == 1318)
				{
					aggro += 250;
				}
				if (armor[j].type == 1316)
				{
					meleeDamage += 0.06f;
				}
				if (armor[j].type == 1317)
				{
					meleeDamage += 0.08f;
					meleeCrit += 8;
				}
				if (armor[j].type == 1318)
				{
					meleeCrit += 4;
				}
				if (armor[j].type == 2199 || armor[j].type == 2202)
				{
					aggro += 250;
				}
				if (armor[j].type == 2201)
				{
					aggro += 400;
				}
				if (armor[j].type == 2199)
				{
					meleeDamage += 0.06f;
				}
				if (armor[j].type == 2200)
				{
					meleeDamage += 0.08f;
					meleeCrit += 8;
					meleeSpeed += 0.06f;
					moveSpeed += 0.06f;
				}
				if (armor[j].type == 2201)
				{
					meleeDamage += 0.05f;
					meleeCrit += 5;
				}
				if (armor[j].type == 2202)
				{
					meleeSpeed += 0.06f;
					moveSpeed += 0.06f;
				}
				if (armor[j].type == 684)
				{
					rangedDamage += 0.16f;
					meleeDamage += 0.16f;
				}
				if (armor[j].type == 685)
				{
					meleeCrit += 11;
					rangedCrit += 11;
				}
				if (armor[j].type == 686)
				{
					moveSpeed += 0.08f;
					meleeSpeed += 0.07f;
				}
				if (armor[j].type == 2361)
				{
					maxMinions++;
					minionDamage += 0.04f;
				}
				if (armor[j].type == 2362)
				{
					maxMinions++;
					minionDamage += 0.04f;
				}
				if (armor[j].type == 2363)
				{
					minionDamage += 0.05f;
				}
				if (armor[j].type >= 1158 && armor[j].type <= 1161)
				{
					maxMinions++;
				}
				if (armor[j].type >= 1159 && armor[j].type <= 1161)
				{
					minionDamage += 0.1f;
				}
				if (armor[j].type >= 2370 && armor[j].type <= 2371)
				{
					minionDamage += 0.05f;
					maxMinions++;
				}
				if (armor[j].type == 2372)
				{
					minionDamage += 0.06f;
					maxMinions++;
				}
				if (armor[j].type >= 1832 && armor[j].type <= 1834)
				{
					maxMinions++;
				}
				if (armor[j].type >= 1832 && armor[j].type <= 1834)
				{
					minionDamage += 0.11f;
				}
				if (armor[j].prefix == 62)
				{
					statDefense++;
				}
				if (armor[j].prefix == 63)
				{
					statDefense += 2;
				}
				if (armor[j].prefix == 64)
				{
					statDefense += 3;
				}
				if (armor[j].prefix == 65)
				{
					statDefense += 4;
				}
				if (armor[j].prefix == 66)
				{
					statManaMax2 += 20;
				}
				if (armor[j].prefix == 67)
				{
					meleeCrit += 2;
					rangedCrit += 2;
					magicCrit += 2;
				}
				if (armor[j].prefix == 68)
				{
					meleeCrit += 4;
					rangedCrit += 4;
					magicCrit += 4;
				}
				if (armor[j].prefix == 69)
				{
					meleeDamage += 0.01f;
					rangedDamage += 0.01f;
					magicDamage += 0.01f;
					minionDamage += 0.01f;
				}
				if (armor[j].prefix == 70)
				{
					meleeDamage += 0.02f;
					rangedDamage += 0.02f;
					magicDamage += 0.02f;
					minionDamage += 0.02f;
				}
				if (armor[j].prefix == 71)
				{
					meleeDamage += 0.03f;
					rangedDamage += 0.03f;
					magicDamage += 0.03f;
					minionDamage += 0.03f;
				}
				if (armor[j].prefix == 72)
				{
					meleeDamage += 0.04f;
					rangedDamage += 0.04f;
					magicDamage += 0.04f;
					minionDamage += 0.04f;
				}
				if (armor[j].prefix == 73)
				{
					moveSpeed += 0.01f;
				}
				if (armor[j].prefix == 74)
				{
					moveSpeed += 0.02f;
				}
				if (armor[j].prefix == 75)
				{
					moveSpeed += 0.03f;
				}
				if (armor[j].prefix == 76)
				{
					moveSpeed += 0.04f;
				}
				if (armor[j].prefix == 77)
				{
					meleeSpeed += 0.01f;
				}
				if (armor[j].prefix == 78)
				{
					meleeSpeed += 0.02f;
				}
				if (armor[j].prefix == 79)
				{
					meleeSpeed += 0.03f;
				}
				if (armor[j].prefix == 80)
				{
					meleeSpeed += 0.04f;
				}
			}
			for (int k = 3; k < 8; k++)
			{
				if (armor[k].type == 2373)
				{
					accFishingLine = true;
				}
				if (armor[k].type == 2374)
				{
					fishingSkill += 10;
				}
				if (armor[k].type == 2375)
				{
					accTackleBox = true;
				}
				if (armor[k].type == 2423)
				{
					autoJump = true;
					jumpSpeedBoost += 2.4f;
					extraFall += 15;
				}
				if (armor[k].type == 15 && accWatch < 1)
				{
					accWatch = 1;
				}
				if (armor[k].type == 16 && accWatch < 2)
				{
					accWatch = 2;
				}
				if (armor[k].type == 17 && accWatch < 3)
				{
					accWatch = 3;
				}
				if (armor[k].type == 707 && accWatch < 1)
				{
					accWatch = 1;
				}
				if (armor[k].type == 708 && accWatch < 2)
				{
					accWatch = 2;
				}
				if (armor[k].type == 709 && accWatch < 3)
				{
					accWatch = 3;
				}
				if (armor[k].type == 18 && accDepthMeter < 1)
				{
					accDepthMeter = 1;
				}
				if (armor[k].type == 857)
				{
					doubleJump2 = true;
				}
				if (armor[k].type == 983)
				{
					doubleJump2 = true;
					jumpBoost = true;
				}
				if (armor[k].type == 987)
				{
					doubleJump3 = true;
				}
				if (armor[k].type == 1163)
				{
					doubleJump3 = true;
					jumpBoost = true;
				}
				if (armor[k].type == 1724)
				{
					doubleJump4 = true;
				}
				if (armor[k].type == 1863)
				{
					doubleJump4 = true;
					jumpBoost = true;
				}
				if (armor[k].type == 1164)
				{
					doubleJump = true;
					doubleJump2 = true;
					doubleJump3 = true;
					jumpBoost = true;
				}
				if (armor[k].type == 1250)
				{
					jumpBoost = true;
					doubleJump = true;
					noFallDmg = true;
				}
				if (armor[k].type == 1252)
				{
					doubleJump2 = true;
					jumpBoost = true;
					noFallDmg = true;
				}
				if (armor[k].type == 1251)
				{
					doubleJump3 = true;
					jumpBoost = true;
					noFallDmg = true;
				}
				if (armor[k].type == 1249)
				{
					jumpBoost = true;
					bee = true;
				}
				if (armor[k].type == 1253 && (double)statLife <= (double)statLifeMax2 * 0.25)
				{
					AddBuff(62, 5);
				}
				if (armor[k].type == 1290)
				{
					panic = true;
				}
				if ((armor[k].type == 1300 || armor[k].type == 1858) && (inventory[selectedItem].useAmmo == 14 || inventory[selectedItem].useAmmo == 311 || inventory[selectedItem].useAmmo == 323))
				{
					scope = true;
				}
				if (armor[k].type == 1858)
				{
					rangedCrit += 10;
					rangedDamage += 0.1f;
				}
				if (armor[k].type == 1303 && wet)
				{
					Lighting.addLight((int)center().X / 16, (int)center().Y / 16, 0.9f, 0.2f, 0.6f);
				}
				if (armor[k].type == 1301)
				{
					meleeCrit += 8;
					rangedCrit += 8;
					magicCrit += 8;
					meleeDamage += 0.1f;
					rangedDamage += 0.1f;
					magicDamage += 0.1f;
					minionDamage += 0.1f;
				}
				if (armor[k].type == 982)
				{
					statManaMax2 += 20;
					manaRegenDelayBonus++;
					manaRegenBonus += 25;
				}
				if (armor[k].type == 1595)
				{
					statManaMax2 += 20;
					magicCuffs = true;
				}
				if (armor[k].type == 2219)
				{
					manaMagnet = true;
				}
				if (armor[k].type == 2220)
				{
					manaMagnet = true;
					magicDamage += 0.15f;
				}
				if (armor[k].type == 2221)
				{
					manaMagnet = true;
					magicCuffs = true;
				}
				if (whoAmi == Main.myPlayer && armor[k].type == 1923)
				{
					tileRangeX++;
					tileRangeY++;
				}
				if (armor[k].type == 1247)
				{
					starCloak = true;
					bee = true;
				}
				if (armor[k].type == 1248)
				{
					meleeCrit += 10;
					rangedCrit += 10;
					magicCrit += 10;
				}
				if (armor[k].type == 854)
				{
					discount = true;
				}
				if (armor[k].type == 855)
				{
					coins = true;
				}
				if (armor[k].type == 53)
				{
					doubleJump = true;
				}
				if (armor[k].type == 54)
				{
					accRunSpeed = 6f;
				}
				if (armor[k].type == 1579)
				{
					accRunSpeed = 6f;
					coldDash = true;
				}
				if (armor[k].type == 128)
				{
					rocketBoots = 1;
				}
				if (armor[k].type == 156)
				{
					noKnockback = true;
				}
				if (armor[k].type == 158)
				{
					noFallDmg = true;
				}
				if (armor[k].type == 934)
				{
					carpet = true;
				}
				if (armor[k].type == 953)
				{
					spikedBoots++;
				}
				if (armor[k].type == 975)
				{
					spikedBoots++;
				}
				if (armor[k].type == 976)
				{
					spikedBoots += 2;
				}
				if (armor[k].type == 977)
				{
					dash = 1;
				}
				if (armor[k].type == 963)
				{
					blackBelt = true;
				}
				if (armor[k].type == 984)
				{
					blackBelt = true;
					dash = 1;
					spikedBoots = 2;
				}
				if (armor[k].type == 1131)
				{
					gravControl2 = true;
				}
				if (armor[k].type == 1132)
				{
					bee = true;
				}
				if (armor[k].type == 1578)
				{
					bee = true;
					panic = true;
				}
				if (armor[k].type == 950)
				{
					iceSkate = true;
				}
				if (armor[k].type == 159)
				{
					jumpBoost = true;
				}
				if (armor[k].type == 187)
				{
					accFlipper = true;
				}
				if (armor[k].type == 211)
				{
					meleeSpeed += 0.12f;
				}
				if (armor[k].type == 223)
				{
					manaCost -= 0.06f;
				}
				if (armor[k].type == 285)
				{
					moveSpeed += 0.05f;
				}
				if (armor[k].type == 212)
				{
					moveSpeed += 0.1f;
				}
				if (armor[k].type == 267)
				{
					killGuide = true;
				}
				if (armor[k].type == 1307)
				{
					killClothier = true;
				}
				if (armor[k].type == 193)
				{
					fireWalk = true;
				}
				if (armor[k].type == 861)
				{
					accMerman = true;
					wolfAcc = true;
				}
				if (armor[k].type == 862)
				{
					starCloak = true;
					longInvince = true;
				}
				if (armor[k].type == 860)
				{
					pStone = true;
				}
				if (armor[k].type == 863)
				{
					waterWalk2 = true;
				}
				if (armor[k].type == 907)
				{
					waterWalk2 = true;
					fireWalk = true;
				}
				if (armor[k].type == 908)
				{
					waterWalk = true;
					fireWalk = true;
					lavaMax += 420;
				}
				if (armor[k].type == 906)
				{
					lavaMax += 420;
				}
				if (armor[k].type == 485)
				{
					wolfAcc = true;
				}
				if (armor[k].type == 486)
				{
					rulerAcc = true;
				}
				if (armor[k].type == 393)
				{
					accCompass = 1;
				}
				if (armor[k].type == 394)
				{
					accFlipper = true;
					accDivingHelm = true;
				}
				if (armor[k].type == 395)
				{
					accWatch = 3;
					accDepthMeter = 1;
					accCompass = 1;
				}
				if (armor[k].type == 396)
				{
					noFallDmg = true;
					fireWalk = true;
				}
				if (armor[k].type == 397)
				{
					noKnockback = true;
					fireWalk = true;
				}
				if (armor[k].type == 399)
				{
					jumpBoost = true;
					doubleJump = true;
				}
				if (armor[k].type == 405)
				{
					accRunSpeed = 6f;
					rocketBoots = 2;
				}
				if (armor[k].type == 1860)
				{
					accFlipper = true;
					accDivingHelm = true;
					if (wet)
					{
						Lighting.addLight((int)center().X / 16, (int)center().Y / 16, 0.9f, 0.2f, 0.6f);
					}
				}
				if (armor[k].type == 1861)
				{
					accFlipper = true;
					accDivingHelm = true;
					iceSkate = true;
					if (wet)
					{
						Lighting.addLight((int)center().X / 16, (int)center().Y / 16, 0.2f, 0.8f, 0.9f);
					}
				}
				if (armor[k].type == 2214)
				{
					tileSpeed += 0.5f;
				}
				if (whoAmi == Main.myPlayer && armor[k].type == 2215)
				{
					tileRangeX += 3;
					tileRangeY += 2;
				}
				if (armor[k].type == 2216)
				{
					autoPaint = true;
				}
				if (armor[k].type == 2217)
				{
					wallSpeed += 0.5f;
				}
				if (armor[k].type == 897)
				{
					kbGlove = true;
					meleeSpeed += 0.12f;
				}
				if (armor[k].type == 1343)
				{
					kbGlove = true;
					meleeSpeed += 0.09f;
					meleeDamage += 0.09f;
					magmaStone = true;
				}
				if (armor[k].type == 1167)
				{
					minionKB += 2f;
					minionDamage += 0.15f;
				}
				if (armor[k].type == 1864)
				{
					minionKB += 2f;
					minionDamage += 0.15f;
					maxMinions++;
				}
				if (armor[k].type == 1845)
				{
					minionDamage += 0.1f;
					maxMinions++;
				}
				if (armor[k].type == 1321)
				{
					magicQuiver = true;
					arrowDamage += 0.1f;
				}
				if (armor[k].type == 1322)
				{
					magmaStone = true;
				}
				if (armor[k].type == 1323)
				{
					lavaRose = true;
				}
				if (armor[k].type == 938)
				{
					noKnockback = true;
					if ((double)statLife > (double)statLifeMax2 * 0.25)
					{
						if (i == Main.myPlayer)
						{
							paladinGive = true;
						}
						else if (miscCounter % 5 == 0)
						{
							int myPlayer = Main.myPlayer;
							if (Main.player[myPlayer].team == team && team != 0)
							{
								float num = position.X - Main.player[myPlayer].position.X;
								float num2 = position.Y - Main.player[myPlayer].position.Y;
								float num3 = (float)Math.Sqrt(num * num + num2 * num2);
								if (num3 < 800f)
								{
									Main.player[myPlayer].AddBuff(43, 10);
								}
							}
						}
					}
				}
				if (armor[k].type == 936)
				{
					kbGlove = true;
					meleeSpeed += 0.12f;
					meleeDamage += 0.12f;
				}
				if (armor[k].type == 898)
				{
					accRunSpeed = 6.75f;
					rocketBoots = 2;
					moveSpeed += 0.08f;
				}
				if (armor[k].type == 1862)
				{
					accRunSpeed = 6.75f;
					rocketBoots = 3;
					moveSpeed += 0.08f;
					iceSkate = true;
				}
				if (armor[k].type == 1865)
				{
					lifeRegen += 2;
					statDefense += 4;
					meleeSpeed += 0.1f;
					meleeDamage += 0.1f;
					meleeCrit += 2;
					rangedDamage += 0.1f;
					rangedCrit += 2;
					magicDamage += 0.1f;
					magicCrit += 2;
					pickSpeed -= 0.15f;
					minionDamage += 0.1f;
					minionKB += 0.5f;
				}
				if (armor[k].type == 899 && Main.dayTime)
				{
					lifeRegen += 2;
					statDefense += 4;
					meleeSpeed += 0.1f;
					meleeDamage += 0.1f;
					meleeCrit += 2;
					rangedDamage += 0.1f;
					rangedCrit += 2;
					magicDamage += 0.1f;
					magicCrit += 2;
					pickSpeed -= 0.15f;
					minionDamage += 0.1f;
					minionKB += 0.5f;
				}
				if (armor[k].type == 900 && !Main.dayTime)
				{
					lifeRegen += 2;
					statDefense += 4;
					meleeSpeed += 0.1f;
					meleeDamage += 0.1f;
					meleeCrit += 2;
					rangedDamage += 0.1f;
					rangedCrit += 2;
					magicDamage += 0.1f;
					magicCrit += 2;
					pickSpeed -= 0.15f;
					minionDamage += 0.1f;
					minionKB += 0.5f;
				}
				if (armor[k].type == 407)
				{
					blockRange = 1;
				}
				if (armor[k].type == 489)
				{
					magicDamage += 0.15f;
				}
				if (armor[k].type == 490)
				{
					meleeDamage += 0.15f;
				}
				if (armor[k].type == 491)
				{
					rangedDamage += 0.15f;
				}
				if (armor[k].type == 935)
				{
					magicDamage += 0.12f;
					meleeDamage += 0.12f;
					rangedDamage += 0.12f;
					minionDamage += 0.12f;
				}
				if (armor[k].type == 492)
				{
					wingTimeMax = 100;
				}
				if (armor[k].type == 493)
				{
					wingTimeMax = 100;
				}
				if (armor[k].type == 665)
				{
					wingTimeMax = 220;
				}
				if (armor[k].type == 748)
				{
					wingTimeMax = 115;
				}
				if (armor[k].type == 749)
				{
					wingTimeMax = 130;
				}
				if (armor[k].type == 761)
				{
					wingTimeMax = 130;
				}
				if (armor[k].type == 785)
				{
					wingTimeMax = 140;
				}
				if (armor[k].type == 786)
				{
					wingTimeMax = 140;
				}
				if (armor[k].type == 821)
				{
					wingTimeMax = 160;
				}
				if (armor[k].type == 822)
				{
					wingTimeMax = 160;
				}
				if (armor[k].type == 823)
				{
					wingTimeMax = 160;
				}
				if (armor[k].type == 2280)
				{
					wingTimeMax = 160;
				}
				if (armor[k].type == 2494)
				{
					wingTimeMax = 100;
				}
				if (armor[k].type == 2609)
				{
					wingTimeMax = 180;
					ignoreWater = true;
				}
				if (armor[k].type == 948)
				{
					wingTimeMax = 180;
				}
				if (armor[k].type == 1162)
				{
					wingTimeMax = 160;
				}
				if (armor[k].type == 1165)
				{
					wingTimeMax = 140;
				}
				if (armor[k].type == 1515)
				{
					wingTimeMax = 130;
				}
				if (armor[k].type == 1583)
				{
					wingTimeMax = 190;
				}
				if (armor[k].type == 1584)
				{
					wingTimeMax = 190;
				}
				if (armor[k].type == 1585)
				{
					wingTimeMax = 190;
				}
				if (armor[k].type == 1586)
				{
					wingTimeMax = 190;
				}
				if (armor[k].type == 1797)
				{
					wingTimeMax = 180;
				}
				if (armor[k].type == 1830)
				{
					wingTimeMax = 180;
				}
				if (armor[k].type == 1866)
				{
					wingTimeMax = 170;
				}
				if (armor[k].type == 1871)
				{
					wingTimeMax = 170;
				}
				if (armor[k].type == 885)
				{
					buffImmune[30] = true;
				}
				if (armor[k].type == 886)
				{
					buffImmune[36] = true;
				}
				if (armor[k].type == 887)
				{
					buffImmune[20] = true;
				}
				if (armor[k].type == 888)
				{
					buffImmune[22] = true;
				}
				if (armor[k].type == 889)
				{
					buffImmune[32] = true;
				}
				if (armor[k].type == 890)
				{
					buffImmune[35] = true;
				}
				if (armor[k].type == 891)
				{
					buffImmune[23] = true;
				}
				if (armor[k].type == 892)
				{
					buffImmune[33] = true;
				}
				if (armor[k].type == 893)
				{
					buffImmune[31] = true;
				}
				if (armor[k].type == 901)
				{
					buffImmune[33] = true;
					buffImmune[36] = true;
				}
				if (armor[k].type == 902)
				{
					buffImmune[30] = true;
					buffImmune[20] = true;
				}
				if (armor[k].type == 903)
				{
					buffImmune[32] = true;
					buffImmune[31] = true;
				}
				if (armor[k].type == 904)
				{
					buffImmune[35] = true;
					buffImmune[23] = true;
				}
				if (armor[k].type == 1921)
				{
					buffImmune[46] = true;
					buffImmune[47] = true;
				}
				if (armor[k].type == 1612)
				{
					buffImmune[33] = true;
					buffImmune[36] = true;
					buffImmune[30] = true;
					buffImmune[20] = true;
					buffImmune[32] = true;
					buffImmune[31] = true;
					buffImmune[35] = true;
					buffImmune[23] = true;
					buffImmune[22] = true;
				}
				if (armor[k].type == 1613)
				{
					noKnockback = true;
					fireWalk = true;
					buffImmune[33] = true;
					buffImmune[36] = true;
					buffImmune[30] = true;
					buffImmune[20] = true;
					buffImmune[32] = true;
					buffImmune[31] = true;
					buffImmune[35] = true;
					buffImmune[23] = true;
					buffImmune[22] = true;
				}
				if (armor[k].type == 497)
				{
					accMerman = true;
				}
				if (armor[k].type == 535)
				{
					pStone = true;
				}
				if (armor[k].type == 536)
				{
					kbGlove = true;
				}
				if (armor[k].type == 532)
				{
					starCloak = true;
				}
				if (armor[k].type == 554)
				{
					longInvince = true;
				}
				if (armor[k].type == 555)
				{
					manaFlower = true;
					manaCost -= 0.08f;
				}
				if (Main.myPlayer != whoAmi)
				{
					continue;
				}
				if (armor[k].type == 576 && Main.rand.Next(18000) == 0 && Main.curMusic > 0 && Main.curMusic <= 33)
				{
					int num4 = 0;
					if (Main.curMusic == 1)
					{
						num4 = 0;
					}
					if (Main.curMusic == 2)
					{
						num4 = 1;
					}
					if (Main.curMusic == 3)
					{
						num4 = 2;
					}
					if (Main.curMusic == 4)
					{
						num4 = 4;
					}
					if (Main.curMusic == 5)
					{
						num4 = 5;
					}
					if (Main.curMusic == 6)
					{
						num4 = 3;
					}
					if (Main.curMusic == 7)
					{
						num4 = 6;
					}
					if (Main.curMusic == 8)
					{
						num4 = 7;
					}
					if (Main.curMusic == 9)
					{
						num4 = 9;
					}
					if (Main.curMusic == 10)
					{
						num4 = 8;
					}
					if (Main.curMusic == 11)
					{
						num4 = 11;
					}
					if (Main.curMusic == 12)
					{
						num4 = 10;
					}
					if (Main.curMusic == 13)
					{
						num4 = 12;
					}
					if (Main.curMusic == 29)
					{
						armor[k].SetDefaults(1610);
					}
					else if (Main.curMusic == 30)
					{
						armor[k].SetDefaults(1963);
					}
					else if (Main.curMusic == 31)
					{
						armor[k].SetDefaults(1964);
					}
					else if (Main.curMusic == 32)
					{
						armor[k].SetDefaults(1965);
					}
					else if (Main.curMusic == 33)
					{
						armor[k].SetDefaults(2742);
					}
					else if (Main.curMusic > 13)
					{
						armor[k].SetDefaults(1596 + Main.curMusic - 14);
					}
					else
					{
						armor[k].SetDefaults(num4 + 562);
					}
				}
				if (armor[k].type >= 562 && armor[k].type <= 574)
				{
					Main.musicBox2 = armor[k].type - 562;
				}
				if (armor[k].type >= 1596 && armor[k].type <= 1609)
				{
					Main.musicBox2 = armor[k].type - 1596 + 13;
				}
				if (armor[k].type == 1610)
				{
					Main.musicBox2 = 27;
				}
				if (armor[k].type == 1963)
				{
					Main.musicBox2 = 28;
				}
				if (armor[k].type == 1964)
				{
					Main.musicBox2 = 29;
				}
				if (armor[k].type == 1965)
				{
					Main.musicBox2 = 30;
				}
				if (armor[k].type == 2742)
				{
					Main.musicBox2 = 31;
				}
			}
			for (int l = 3; l < 8; l++)
			{
				if (armor[l].wingSlot > 0)
				{
					if (!hideVisual[l] || (velocity.Y != 0f && !mount.Active))
					{
						wings = armor[l].wingSlot;
					}
					wingsLogic = armor[l].wingSlot;
				}
			}
			for (int m = 11; m < 16; m++)
			{
				if (armor[m].wingSlot > 0)
				{
					wings = armor[m].wingSlot;
				}
			}
		}

		public void UpdateArmorSets(int i)
		{
			setBonus = "";
			if (body == 67 && legs == 56 && head >= 103 && head <= 105)
			{
				setBonus = Lang.setBonus(31);
				armorSteath = true;
			}
			if ((head == 52 && body == 32 && legs == 31) || (head == 53 && body == 33 && legs == 32) || (head == 54 && body == 34 && legs == 33) || (head == 55 && body == 35 && legs == 34) || (head == 70 && body == 46 && legs == 42) || (head == 71 && body == 47 && legs == 43) || (head == 166 && body == 173 && legs == 108) || (head == 167 && body == 174 && legs == 109))
			{
				setBonus = Lang.setBonus(20);
				statDefense++;
			}
			if ((head == 1 && body == 1 && legs == 1) || ((head == 72 || head == 2) && body == 2 && legs == 2) || (head == 47 && body == 28 && legs == 27))
			{
				setBonus = Lang.setBonus(0);
				statDefense += 2;
			}
			if ((head == 3 && body == 3 && legs == 3) || ((head == 73 || head == 4) && body == 4 && legs == 4) || (head == 48 && body == 29 && legs == 28) || (head == 49 && body == 30 && legs == 29))
			{
				setBonus = Lang.setBonus(1);
				statDefense += 3;
			}
			if (head == 50 && body == 31 && legs == 30)
			{
				setBonus = Lang.setBonus(32);
				statDefense += 4;
			}
			if (head == 112 && body == 75 && legs == 64)
			{
				setBonus = Lang.setBonus(33);
				meleeDamage += 0.1f;
				magicDamage += 0.1f;
				rangedDamage += 0.1f;
			}
			if (head == 157 && body == 105 && legs == 98)
			{
				int num = 0;
				setBonus = Lang.setBonus(38);
				beetleOffense = true;
				beetleCounter -= 3f;
				beetleCounter -= beetleCountdown / 10;
				beetleCountdown++;
				if (beetleCounter < 0f)
				{
					beetleCounter = 0f;
				}
				int num2 = 400;
				int num3 = 1200;
				int num4 = 4600;
				if (beetleCounter > (float)(num2 + num3 + num4 + num3))
				{
					beetleCounter = num2 + num3 + num4 + num3;
				}
				if (beetleCounter > (float)(num2 + num3 + num4))
				{
					AddBuff(100, 5, false);
					num = 3;
				}
				else if (beetleCounter > (float)(num2 + num3))
				{
					AddBuff(99, 5, false);
					num = 2;
				}
				else if (beetleCounter > (float)num2)
				{
					AddBuff(98, 5, false);
					num = 1;
				}
				if (num < beetleOrbs)
				{
					beetleCountdown = 0;
				}
				else if (num > beetleOrbs)
				{
					beetleCounter += 200f;
				}
				if (num != beetleOrbs && beetleOrbs > 0)
				{
					for (int j = 0; j < 22; j++)
					{
						if (buffType[j] >= 98 && buffType[j] <= 100 && buffType[j] != 97 + num)
						{
							DelBuff(j);
						}
					}
				}
			}
			else if (head == 157 && body == 106 && legs == 98)
			{
				setBonus = Lang.setBonus(37);
				beetleDefense = true;
				beetleCounter += 1f;
				int num5 = 180;
				if (beetleCounter >= (float)num5)
				{
					if (beetleOrbs > 0 && beetleOrbs < 3)
					{
						for (int k = 0; k < 22; k++)
						{
							if (buffType[k] >= 95 && buffType[k] <= 96)
							{
								DelBuff(k);
							}
						}
					}
					if (beetleOrbs < 3)
					{
						AddBuff(95 + beetleOrbs, 5, false);
						beetleCounter = 0f;
					}
					else
					{
						beetleCounter = num5;
					}
				}
			}
			if (!beetleDefense && !beetleOffense)
			{
				beetleCounter = 0f;
			}
			else
			{
				beetleFrameCounter++;
				if (beetleFrameCounter >= 1)
				{
					beetleFrameCounter = 0;
					beetleFrame++;
					if (beetleFrame > 2)
					{
						beetleFrame = 0;
					}
				}
				for (int l = beetleOrbs; l < 3; l++)
				{
					beetlePos[l].X = 0f;
					beetlePos[l].Y = 0f;
				}
				for (int m = 0; m < beetleOrbs; m++)
				{
					beetlePos[m] += beetleVel[m];
					beetleVel[m].X += (float)Main.rand.Next(-100, 101) * 0.005f;
					beetleVel[m].Y += (float)Main.rand.Next(-100, 101) * 0.005f;
					float x = beetlePos[m].X;
					float y = beetlePos[m].Y;
					float num6 = (float)Math.Sqrt(x * x + y * y);
					if (num6 > 100f)
					{
						num6 = 20f / num6;
						x *= 0f - num6;
						y *= 0f - num6;
						int num7 = 10;
						beetleVel[m].X = (beetleVel[m].X * (float)(num7 - 1) + x) / (float)num7;
						beetleVel[m].Y = (beetleVel[m].Y * (float)(num7 - 1) + y) / (float)num7;
					}
					else if (num6 > 30f)
					{
						num6 = 10f / num6;
						x *= 0f - num6;
						y *= 0f - num6;
						int num8 = 20;
						beetleVel[m].X = (beetleVel[m].X * (float)(num8 - 1) + x) / (float)num8;
						beetleVel[m].Y = (beetleVel[m].Y * (float)(num8 - 1) + y) / (float)num8;
					}
					x = beetleVel[m].X;
					y = beetleVel[m].Y;
					num6 = (float)Math.Sqrt(x * x + y * y);
					if (num6 > 2f)
					{
						beetleVel[m] *= 0.9f;
					}
					beetlePos[m] -= velocity * 0.25f;
				}
			}
			if (head == 14 && ((body >= 58 && body <= 63) || body == 167))
			{
				setBonus = Lang.setBonus(28);
				magicCrit += 10;
			}
			if (head == 159 && ((body >= 58 && body <= 63) || body == 167))
			{
				setBonus = Lang.setBonus(36);
				statManaMax2 += 60;
			}
			if ((head == 5 || head == 74) && (body == 5 || body == 48) && (legs == 5 || legs == 44))
			{
				setBonus = Lang.setBonus(2);
				moveSpeed += 0.15f;
			}
			if (head == 57 && body == 37 && legs == 35)
			{
				setBonus = Lang.setBonus(21);
				crimsonRegen = true;
			}
			if (head == 101 && body == 66 && legs == 55)
			{
				setBonus = Lang.setBonus(30);
				ghostHeal = true;
			}
			if (head == 156 && body == 66 && legs == 55)
			{
				setBonus = Lang.setBonus(35);
				ghostHurt = true;
			}
			if (head == 6 && body == 6 && legs == 6)
			{
				setBonus = Lang.setBonus(3);
				spaceGun = true;
			}
			if (head == 46 && body == 27 && legs == 26)
			{
				frostArmor = true;
				setBonus = Lang.setBonus(22);
				frostBurn = true;
			}
			if ((head == 75 || head == 7) && body == 7 && legs == 7)
			{
				boneArmor = true;
				setBonus = Lang.setBonus(4);
				ammoCost80 = true;
			}
			if ((head == 76 || head == 8) && (body == 49 || body == 8) && (legs == 45 || legs == 8))
			{
				setBonus = Lang.setBonus(5);
				manaCost -= 0.16f;
			}
			if (head == 9 && body == 9 && legs == 9)
			{
				setBonus = Lang.setBonus(6);
				meleeDamage += 0.17f;
			}
			if (head == 11 && body == 20 && legs == 19)
			{
				setBonus = Lang.setBonus(7);
				pickSpeed -= 0.3f;
			}
			if ((head == 78 || head == 79 || head == 80) && body == 51 && legs == 47)
			{
				setBonus = Lang.setBonus(27);
				AddBuff(60, 18000);
			}
			else if (crystalLeaf)
			{
				for (int n = 0; n < 22; n++)
				{
					if (buffType[n] == 60)
					{
						DelBuff(n);
					}
				}
			}
			if (head == 99 && body == 65 && legs == 54)
			{
				setBonus = Lang.setBonus(29);
				thorns = true;
				turtleThorns = true;
			}
			if (body == 17 && legs == 16)
			{
				if (head == 29)
				{
					setBonus = Lang.setBonus(8);
					manaCost -= 0.14f;
				}
				else if (head == 30)
				{
					setBonus = Lang.setBonus(9);
					meleeSpeed += 0.15f;
				}
				else if (head == 31)
				{
					setBonus = Lang.setBonus(10);
					ammoCost80 = true;
				}
			}
			if (body == 18 && legs == 17)
			{
				if (head == 32)
				{
					setBonus = Lang.setBonus(11);
					manaCost -= 0.17f;
				}
				else if (head == 33)
				{
					setBonus = Lang.setBonus(12);
					meleeCrit += 5;
				}
				else if (head == 34)
				{
					setBonus = Lang.setBonus(13);
					ammoCost80 = true;
				}
			}
			if (body == 19 && legs == 18)
			{
				if (head == 35)
				{
					setBonus = Lang.setBonus(14);
					manaCost -= 0.19f;
				}
				else if (head == 36)
				{
					setBonus = Lang.setBonus(15);
					meleeSpeed += 0.18f;
					moveSpeed += 0.18f;
				}
				else if (head == 37)
				{
					setBonus = Lang.setBonus(16);
					ammoCost75 = true;
				}
			}
			if (body == 54 && legs == 49 && (head == 83 || head == 84 || head == 85))
			{
				setBonus = Lang.setBonus(24);
				onHitRegen = true;
			}
			if (body == 55 && legs == 50 && (head == 86 || head == 87 || head == 88))
			{
				setBonus = Lang.setBonus(25);
				onHitPetal = true;
			}
			if (body == 56 && legs == 51 && (head == 89 || head == 90 || head == 91))
			{
				setBonus = Lang.setBonus(26);
				onHitDodge = true;
			}
			if (body == 24 && legs == 23)
			{
				if (head == 42)
				{
					setBonus = Lang.setBonus(17);
					manaCost -= 0.2f;
				}
				else if (head == 43)
				{
					setBonus = Lang.setBonus(18);
					meleeSpeed += 0.19f;
					moveSpeed += 0.19f;
				}
				else if (head == 41)
				{
					setBonus = Lang.setBonus(19);
					ammoCost75 = true;
				}
			}
			if (head == 82 && body == 53 && legs == 48)
			{
				setBonus = Lang.setBonus(23);
				maxMinions++;
			}
			if (head == 134 && body == 95 && legs == 79)
			{
				setBonus = Lang.setBonus(34);
				minionDamage += 0.25f;
			}
			if (head == 160 && body == 168 && legs == 103)
			{
				setBonus = Lang.setBonus(39);
				minionDamage += 0.1f;
			}
			if (head == 162 && body == 170 && legs == 105)
			{
				setBonus = Lang.setBonus(40);
				minionDamage += 0.12f;
			}
		}

		public void UpdateSocialShadow()
		{
			shadowCount++;
			if (shadowCount == 1)
			{
				shadowPos[2] = shadowPos[1];
				shadowRotation[2] = shadowRotation[1];
				shadowOrigin[2] = shadowOrigin[1];
			}
			else if (shadowCount == 2)
			{
				shadowPos[1] = shadowPos[0];
				shadowRotation[1] = shadowRotation[0];
				shadowOrigin[1] = shadowOrigin[0];
			}
			else if (shadowCount >= 3)
			{
				shadowCount = 0;
				shadowPos[0] = position;
				shadowPos[0].Y += gfxOffY;
				shadowRotation[0] = fullRotation;
				shadowOrigin[0] = fullRotationOrigin;
			}
		}

		public void UpdateTeleportVisuals()
		{
			if (!(teleportTime > 0f))
			{
				return;
			}
			if (teleportStyle == 1)
			{
				if ((float)Main.rand.Next(100) <= 100f * teleportTime)
				{
					int num = Dust.NewDust(new Vector2(getRect().X, getRect().Y), getRect().Width, getRect().Height, 164);
					Main.dust[num].scale = teleportTime * 1.5f;
					Main.dust[num].noGravity = true;
					Main.dust[num].velocity *= 1.1f;
				}
			}
			else if (teleportStyle == 2)
			{
				teleportTime = 0.005f;
			}
			else if (teleportStyle == 0 && (float)Main.rand.Next(100) <= 100f * teleportTime * 2f)
			{
				int num2 = Dust.NewDust(new Vector2(getRect().X, getRect().Y), getRect().Width, getRect().Height, 159);
				Main.dust[num2].scale = teleportTime * 1.5f;
				Main.dust[num2].noGravity = true;
				Main.dust[num2].velocity *= 1.1f;
			}
			teleportTime -= 0.005f;
		}

		public void UpdateBiomes()
		{
			zoneEvil = false;
			if (Main.evilTiles >= 200)
			{
				zoneEvil = true;
			}
			zoneHoly = false;
			if (Main.holyTiles >= 100)
			{
				zoneHoly = true;
			}
			zoneMeteor = false;
			if (Main.meteorTiles >= 50)
			{
				zoneMeteor = true;
			}
			zoneDungeon = false;
			if (Main.dungeonTiles >= 250 && (double)position.Y > Main.worldSurface * 16.0)
			{
				int num = (int)position.X / 16;
				int num2 = (int)position.Y / 16;
				if (Main.wallDungeon[Main.tile[num, num2].wall])
				{
					zoneDungeon = true;
				}
			}
			zoneJungle = false;
			if (Main.jungleTiles >= 80)
			{
				zoneJungle = true;
			}
			zoneSnow = false;
			if (Main.snowTiles >= 300)
			{
				zoneSnow = true;
			}
			zoneBlood = false;
			if (Main.bloodTiles >= 200)
			{
				zoneBlood = true;
			}
			if (Main.waterCandles > 0)
			{
				zoneCandle = true;
			}
			else
			{
				zoneCandle = false;
			}
		}

		public void UpdateDead()
		{
			gem = -1;
			slippy = false;
			slippy2 = false;
			powerrun = false;
			wings = 0;
			wingsLogic = 0;
			face = (neck = (back = (front = (handoff = (handon = (shoe = (waist = (balloon = (shield = 0)))))))));
			poisoned = false;
			venom = false;
			onFire = false;
			dripping = false;
			drippingSlime = false;
			burned = false;
			suffocating = false;
			onFire2 = false;
			onFrostBurn = false;
			blind = false;
			blackout = false;
			gravDir = 1f;
			for (int i = 0; i < 22; i++)
			{
				buffTime[i] = 0;
				buffType[i] = 0;
			}
			if (whoAmi == Main.myPlayer)
			{
				Main.npcChatText = "";
				Main.editSign = false;
			}
			grappling[0] = -1;
			grappling[1] = -1;
			grappling[2] = -1;
			sign = -1;
			talkNPC = -1;
			Main.npcChatCornerItem = 0;
			statLife = 0;
			channel = false;
			potionDelay = 0;
			chest = -1;
			changeItem = -1;
			itemAnimation = 0;
			immuneAlpha += 2;
			if (immuneAlpha > 255)
			{
				immuneAlpha = 255;
			}
			headPosition += headVelocity;
			bodyPosition += bodyVelocity;
			legPosition += legVelocity;
			headRotation += headVelocity.X * 0.1f;
			bodyRotation += bodyVelocity.X * 0.1f;
			legRotation += legVelocity.X * 0.1f;
			headVelocity.Y += 0.1f;
			bodyVelocity.Y += 0.1f;
			legVelocity.Y += 0.1f;
			headVelocity.X *= 0.99f;
			bodyVelocity.X *= 0.99f;
			legVelocity.X *= 0.99f;
			if (difficulty == 2)
			{
				if (respawnTimer > 0)
				{
					respawnTimer--;
				}
				else if (whoAmi == Main.myPlayer || Main.netMode == 2)
				{
					ghost = true;
				}
				return;
			}
			respawnTimer--;
			if (respawnTimer <= 0 && Main.myPlayer == whoAmi)
			{
				if (Main.mouseItem.type > 0)
				{
					Main.playerInventory = true;
				}
				Spawn();
			}
		}

		public void SmartCursorLookup()
		{
			if (whoAmi != Main.myPlayer)
			{
				return;
			}
			Main.smartDigShowing = false;
			if (!Main.smartDigEnabled)
			{
				return;
			}
			Item item = inventory[selectedItem];
			Vector2 vector = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			if (gravDir == -1f)
			{
				vector.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;
			}
			int tileTargetX2 = tileTargetX;
			int tileTargetY2 = tileTargetY;
			int tileBoost = item.tileBoost;
			int num = (int)(position.X / 16f) - tileRangeX - tileBoost + 1;
			int num2 = (int)((position.X + (float)width) / 16f) + tileRangeX + tileBoost - 1;
			int num3 = (int)(position.Y / 16f) - tileRangeY - tileBoost + 1;
			int num4 = (int)((position.Y + (float)height) / 16f) + tileRangeY + tileBoost - 2;
			if (num < 10)
			{
				num = 10;
			}
			if (num2 > Main.maxTilesX - 10)
			{
				num2 = Main.maxTilesX - 10;
			}
			if (num3 < 10)
			{
				num3 = 10;
			}
			if (num4 > Main.maxTilesY - 10)
			{
				num4 = Main.maxTilesY - 10;
			}
			List<Tuple<int, int>> list = new List<Tuple<int, int>>();
			for (int i = 0; i < grapCount; i++)
			{
				Projectile projectile = Main.projectile[grappling[i]];
				int item2 = (int)projectile.center().X / 16;
				int item3 = (int)projectile.center().Y / 16;
				list.Add(new Tuple<int, int>(item2, item3));
			}
			int num5 = -1;
			int num6 = -1;
			if (item.axe > 0 && num5 == -1 && num6 == -1)
			{
				float num7 = -1f;
				for (int j = num; j <= num2; j++)
				{
					for (int k = num3; k <= num4; k++)
					{
						if (!Main.tile[j, k].active())
						{
							continue;
						}
						Tile tile = Main.tile[j, k];
						if (!Main.tileAxe[tile.type])
						{
							continue;
						}
						int num8 = j;
						int l = k;
						if (tile.type == 5)
						{
							if (Collision.InTileBounds(num8 + 1, l, num, num3, num2, num4))
							{
								if (Main.tile[num8, l].frameY >= 198 && Main.tile[num8, l].frameX == 44)
								{
									num8++;
								}
								if (Main.tile[num8, l].frameX == 66 && Main.tile[num8, l].frameY <= 44)
								{
									num8++;
								}
								if (Main.tile[num8, l].frameX == 44 && Main.tile[num8, l].frameY >= 132 && Main.tile[num8, l].frameY <= 176)
								{
									num8++;
								}
							}
							if (Collision.InTileBounds(num8 - 1, l, num, num3, num2, num4))
							{
								if (Main.tile[num8, l].frameY >= 198 && Main.tile[num8, l].frameX == 66)
								{
									num8--;
								}
								if (Main.tile[num8, l].frameX == 88 && Main.tile[num8, l].frameY >= 66 && Main.tile[num8, l].frameY <= 110)
								{
									num8--;
								}
								if (Main.tile[num8, l].frameX == 22 && Main.tile[num8, l].frameY >= 132 && Main.tile[num8, l].frameY <= 176)
								{
									num8--;
								}
							}
							for (; Main.tile[num8, l].active() && Main.tile[num8, l].type == 5 && Main.tile[num8, l + 1].type == 5 && Collision.InTileBounds(num8, l + 1, num, num3, num2, num4); l++)
							{
							}
						}
						if (tile.type == 80)
						{
							if (Collision.InTileBounds(num8 + 1, l, num, num3, num2, num4))
							{
								if (Main.tile[num8, l].frameX == 54)
								{
									num8++;
								}
								if (Main.tile[num8, l].frameX == 108 && Main.tile[num8, l].frameY == 36)
								{
									num8++;
								}
							}
							if (Collision.InTileBounds(num8 - 1, l, num, num3, num2, num4))
							{
								if (Main.tile[num8, l].frameX == 36)
								{
									num8--;
								}
								if (Main.tile[num8, l].frameX == 108 && Main.tile[num8, l].frameY == 18)
								{
									num8--;
								}
							}
							for (; Main.tile[num8, l].active() && Main.tile[num8, l].type == 80 && Main.tile[num8, l + 1].type == 80 && Collision.InTileBounds(num8, l + 1, num, num3, num2, num4); l++)
							{
							}
						}
						if (tile.type == 323 || tile.type == 72)
						{
							for (; Main.tile[num8, l].active() && ((Main.tile[num8, l].type == 323 && Main.tile[num8, l + 1].type == 323) || (Main.tile[num8, l].type == 72 && Main.tile[num8, l + 1].type == 72)) && Collision.InTileBounds(num8, l + 1, num, num3, num2, num4); l++)
							{
							}
						}
						float num9 = Vector2.Distance(new Vector2(num8, l) * 16f + Vector2.One * 8f, vector);
						if (num7 == -1f || num9 < num7)
						{
							num7 = num9;
							num5 = num8;
							num6 = l;
						}
					}
				}
			}
			if (item.pick > 0 && num5 == -1 && num6 == -1)
			{
				Vector2 vector2 = vector - center();
				int num10 = Math.Sign(vector2.X);
				int num11 = Math.Sign(vector2.Y);
				if (Math.Abs(vector2.X) > Math.Abs(vector2.Y) * 3f)
				{
					num11 = 0;
					vector.Y = center().Y;
				}
				if (Math.Abs(vector2.Y) > Math.Abs(vector2.X) * 3f)
				{
					num10 = 0;
					vector.X = center().X;
				}
				int num85 = (int)center().X / 16;
				int num86 = (int)center().Y / 16;
				List<Tuple<int, int>> list2 = new List<Tuple<int, int>>();
				List<Tuple<int, int>> list3 = new List<Tuple<int, int>>();
				int num12 = 1;
				if (num11 == -1 && num10 != 0)
				{
					num12 = -1;
				}
				int num13 = (int)((position.X + (float)(width / 2) + (float)((width / 2 - 1) * num10)) / 16f);
				int num14 = (int)(((double)position.Y + 0.1) / 16.0);
				if (num12 == -1)
				{
					num14 = (int)((position.Y + (float)height - 1f) / 16f);
				}
				int num15 = width / 16 + ((width % 16 != 0) ? 1 : 0);
				int num16 = height / 16 + ((height % 16 != 0) ? 1 : 0);
				if (num10 != 0)
				{
					for (int m = 0; m < num16; m++)
					{
						if (Main.tile[num13, num14 + m * num12] == null)
						{
							return;
						}
						list2.Add(new Tuple<int, int>(num13, num14 + m * num12));
					}
				}
				if (num11 != 0)
				{
					for (int n = 0; n < num15; n++)
					{
						if (Main.tile[(int)(position.X / 16f) + n, num14] == null)
						{
							return;
						}
						list2.Add(new Tuple<int, int>((int)(position.X / 16f) + n, num14));
					}
				}
				int num17 = (int)((vector.X + (float)((width / 2 - 1) * num10)) / 16f);
				int num18 = (int)(((double)vector.Y + 0.1 - (double)(height / 2 + 1)) / 16.0);
				if (num12 == -1)
				{
					num18 = (int)((vector.Y + (float)(height / 2) - 1f) / 16f);
				}
				if (gravDir == -1f && num11 == 0)
				{
					num18++;
				}
				if (num18 < 10)
				{
					num18 = 10;
				}
				if (num18 > Main.maxTilesY - 10)
				{
					num18 = Main.maxTilesY - 10;
				}
				int num19 = width / 16 + ((width % 16 != 0) ? 1 : 0);
				int num20 = height / 16 + ((height % 16 != 0) ? 1 : 0);
				if (num10 != 0)
				{
					for (int num21 = 0; num21 < num20; num21++)
					{
						if (Main.tile[num17, num18 + num21 * num12] == null)
						{
							return;
						}
						list3.Add(new Tuple<int, int>(num17, num18 + num21 * num12));
					}
				}
				if (num11 != 0)
				{
					for (int num22 = 0; num22 < num19; num22++)
					{
						if (Main.tile[(int)((vector.X - (float)(width / 2)) / 16f) + num22, num18] == null)
						{
							return;
						}
						list3.Add(new Tuple<int, int>((int)((vector.X - (float)(width / 2)) / 16f) + num22, num18));
					}
				}
				List<Tuple<int, int>> list4 = new List<Tuple<int, int>>();
				while (list2.Count > 0)
				{
					Tuple<int, int> tuple = list2[0];
					Tuple<int, int> tuple2 = list3[0];
					Tuple<int, int> tuple3 = Collision.TupleHitLine(tuple.Item1, tuple.Item2, tuple2.Item1, tuple2.Item2, num10 * (int)gravDir, -num11 * (int)gravDir, list);
					if (tuple3.Item1 == -1 || tuple3.Item2 == -1)
					{
						list2.Remove(tuple);
						list3.Remove(tuple2);
						continue;
					}
					if (tuple3.Item1 != tuple2.Item1 || tuple3.Item2 != tuple2.Item2)
					{
						list4.Add(tuple3);
					}
					Tile tile2 = Main.tile[tuple3.Item1, tuple3.Item2];
					if (!tile2.inActive() && tile2.active() && Main.tileSolid[tile2.type] && !Main.tileSolidTop[tile2.type] && !list.Contains(tuple3))
					{
						list4.Add(tuple3);
					}
					list2.Remove(tuple);
					list3.Remove(tuple2);
				}
				if (list4.Count > 0)
				{
					float num23 = -1f;
					Tuple<int, int> tuple4 = list4[0];
					for (int num24 = 0; num24 < list4.Count; num24++)
					{
						float num25 = Vector2.Distance(new Vector2(list4[num24].Item1, list4[num24].Item2) * 16f + Vector2.One * 8f, center());
						if (num23 == -1f || num25 < num23)
						{
							num23 = num25;
							tuple4 = list4[num24];
						}
					}
					if (Collision.InTileBounds(tuple4.Item1, tuple4.Item2, num, num3, num2, num4))
					{
						num5 = tuple4.Item1;
						num6 = tuple4.Item2;
					}
				}
				list2.Clear();
				list3.Clear();
				list4.Clear();
			}
			if ((item.type == 509 || item.type == 850 || item.type == 851) && num5 == -1 && num6 == -1)
			{
				List<Tuple<int, int>> list5 = new List<Tuple<int, int>>();
				int num26 = 0;
				if (item.type == 509)
				{
					num26 = 1;
				}
				if (item.type == 850)
				{
					num26 = 2;
				}
				if (item.type == 851)
				{
					num26 = 3;
				}
				bool flag = false;
				if (Main.tile[tileTargetX, tileTargetY].wire() && num26 == 1)
				{
					flag = true;
				}
				if (Main.tile[tileTargetX, tileTargetY].wire2() && num26 == 2)
				{
					flag = true;
				}
				if (Main.tile[tileTargetX, tileTargetY].wire3() && num26 == 3)
				{
					flag = true;
				}
				if (!flag)
				{
					for (int num27 = num; num27 <= num2; num27++)
					{
						for (int num28 = num3; num28 <= num4; num28++)
						{
							Tile tile3 = Main.tile[num27, num28];
							if ((!tile3.wire() || num26 != 1) && (!tile3.wire2() || num26 != 2) && (!tile3.wire3() || num26 != 3))
							{
								continue;
							}
							if (num26 == 1)
							{
								if (!Main.tile[num27 - 1, num28].wire())
								{
									list5.Add(new Tuple<int, int>(num27 - 1, num28));
								}
								if (!Main.tile[num27 + 1, num28].wire())
								{
									list5.Add(new Tuple<int, int>(num27 + 1, num28));
								}
								if (!Main.tile[num27, num28 - 1].wire())
								{
									list5.Add(new Tuple<int, int>(num27, num28 - 1));
								}
								if (!Main.tile[num27, num28 + 1].wire())
								{
									list5.Add(new Tuple<int, int>(num27, num28 + 1));
								}
							}
							if (num26 == 2)
							{
								if (!Main.tile[num27 - 1, num28].wire2())
								{
									list5.Add(new Tuple<int, int>(num27 - 1, num28));
								}
								if (!Main.tile[num27 + 1, num28].wire2())
								{
									list5.Add(new Tuple<int, int>(num27 + 1, num28));
								}
								if (!Main.tile[num27, num28 - 1].wire2())
								{
									list5.Add(new Tuple<int, int>(num27, num28 - 1));
								}
								if (!Main.tile[num27, num28 + 1].wire2())
								{
									list5.Add(new Tuple<int, int>(num27, num28 + 1));
								}
							}
							if (num26 == 3)
							{
								if (!Main.tile[num27 - 1, num28].wire3())
								{
									list5.Add(new Tuple<int, int>(num27 - 1, num28));
								}
								if (!Main.tile[num27 + 1, num28].wire3())
								{
									list5.Add(new Tuple<int, int>(num27 + 1, num28));
								}
								if (!Main.tile[num27, num28 - 1].wire3())
								{
									list5.Add(new Tuple<int, int>(num27, num28 - 1));
								}
								if (!Main.tile[num27, num28 + 1].wire3())
								{
									list5.Add(new Tuple<int, int>(num27, num28 + 1));
								}
							}
						}
					}
				}
				if (list5.Count > 0)
				{
					float num29 = -1f;
					Tuple<int, int> tuple5 = list5[0];
					for (int num30 = 0; num30 < list5.Count; num30++)
					{
						float num31 = Vector2.Distance(new Vector2(list5[num30].Item1, list5[num30].Item2) * 16f + Vector2.One * 8f, vector);
						if (num29 == -1f || num31 < num29)
						{
							num29 = num31;
							tuple5 = list5[num30];
						}
					}
					if (Collision.InTileBounds(tuple5.Item1, tuple5.Item2, num, num3, num2, num4))
					{
						num5 = tuple5.Item1;
						num6 = tuple5.Item2;
					}
				}
				list5.Clear();
			}
			if (item.hammer > 0 && num5 == -1 && num6 == -1)
			{
				Vector2 vector3 = vector - center();
				int num32 = Math.Sign(vector3.X);
				int num33 = Math.Sign(vector3.Y);
				if (Math.Abs(vector3.X) > Math.Abs(vector3.Y) * 3f)
				{
					num33 = 0;
					vector.Y = center().Y;
				}
				if (Math.Abs(vector3.Y) > Math.Abs(vector3.X) * 3f)
				{
					num32 = 0;
					vector.X = center().X;
				}
				int num87 = (int)center().X / 16;
				int num88 = (int)center().Y / 16;
				List<Tuple<int, int>> list6 = new List<Tuple<int, int>>();
				List<Tuple<int, int>> list7 = new List<Tuple<int, int>>();
				int num34 = 1;
				if (num33 == -1 && num32 != 0)
				{
					num34 = -1;
				}
				int num35 = (int)((position.X + (float)(width / 2) + (float)((width / 2 - 1) * num32)) / 16f);
				int num36 = (int)(((double)position.Y + 0.1) / 16.0);
				if (num34 == -1)
				{
					num36 = (int)((position.Y + (float)height - 1f) / 16f);
				}
				int num37 = width / 16 + ((width % 16 != 0) ? 1 : 0);
				int num38 = height / 16 + ((height % 16 != 0) ? 1 : 0);
				if (num32 != 0)
				{
					for (int num39 = 0; num39 < num38; num39++)
					{
						if (Main.tile[num35, num36 + num39 * num34] == null)
						{
							return;
						}
						list6.Add(new Tuple<int, int>(num35, num36 + num39 * num34));
					}
				}
				if (num33 != 0)
				{
					for (int num40 = 0; num40 < num37; num40++)
					{
						if (Main.tile[(int)(position.X / 16f) + num40, num36] == null)
						{
							return;
						}
						list6.Add(new Tuple<int, int>((int)(position.X / 16f) + num40, num36));
					}
				}
				int num41 = (int)((vector.X + (float)((width / 2 - 1) * num32)) / 16f);
				int num42 = (int)(((double)vector.Y + 0.1 - (double)(height / 2 + 1)) / 16.0);
				if (num34 == -1)
				{
					num42 = (int)((vector.Y + (float)(height / 2) - 1f) / 16f);
				}
				if (gravDir == -1f && num33 == 0)
				{
					num42++;
				}
				if (num42 < 10)
				{
					num42 = 10;
				}
				if (num42 > Main.maxTilesY - 10)
				{
					num42 = Main.maxTilesY - 10;
				}
				int num43 = width / 16 + ((width % 16 != 0) ? 1 : 0);
				int num44 = height / 16 + ((height % 16 != 0) ? 1 : 0);
				if (num32 != 0)
				{
					for (int num45 = 0; num45 < num44; num45++)
					{
						if (Main.tile[num41, num42 + num45 * num34] == null)
						{
							return;
						}
						list7.Add(new Tuple<int, int>(num41, num42 + num45 * num34));
					}
				}
				if (num33 != 0)
				{
					for (int num46 = 0; num46 < num43; num46++)
					{
						if (Main.tile[(int)((vector.X - (float)(width / 2)) / 16f) + num46, num42] == null)
						{
							return;
						}
						list7.Add(new Tuple<int, int>((int)((vector.X - (float)(width / 2)) / 16f) + num46, num42));
					}
				}
				List<Tuple<int, int>> list8 = new List<Tuple<int, int>>();
				while (list6.Count > 0)
				{
					Tuple<int, int> tuple6 = list6[0];
					Tuple<int, int> tuple7 = list7[0];
					Tuple<int, int> tuple8 = Collision.TupleHitLineWall(tuple6.Item1, tuple6.Item2, tuple7.Item1, tuple7.Item2);
					if (tuple8.Item1 == -1 || tuple8.Item2 == -1)
					{
						list6.Remove(tuple6);
						list7.Remove(tuple7);
						continue;
					}
					if (tuple8.Item1 != tuple7.Item1 || tuple8.Item2 != tuple7.Item2)
					{
						list8.Add(tuple8);
					}
					Tile tile10 = Main.tile[tuple8.Item1, tuple8.Item2];
					if (Collision.HitWallSubstep(tuple8.Item1, tuple8.Item2))
					{
						list8.Add(tuple8);
					}
					list6.Remove(tuple6);
					list7.Remove(tuple7);
				}
				if (list8.Count > 0)
				{
					float num47 = -1f;
					Tuple<int, int> tuple9 = list8[0];
					for (int num48 = 0; num48 < list8.Count; num48++)
					{
						float num49 = Vector2.Distance(new Vector2(list8[num48].Item1, list8[num48].Item2) * 16f + Vector2.One * 8f, center());
						if (num47 == -1f || num49 < num47)
						{
							num47 = num49;
							tuple9 = list8[num48];
						}
					}
					if (Collision.InTileBounds(tuple9.Item1, tuple9.Item2, num, num3, num2, num4))
					{
						poundRelease = false;
						num5 = tuple9.Item1;
						num6 = tuple9.Item2;
					}
				}
				list8.Clear();
				list6.Clear();
				list7.Clear();
			}
			if (item.hammer > 0 && num5 == -1 && num6 == -1)
			{
				List<Tuple<int, int>> list9 = new List<Tuple<int, int>>();
				for (int num50 = num; num50 <= num2; num50++)
				{
					for (int num51 = num3; num51 <= num4; num51++)
					{
						if (Main.tile[num50, num51].wall > 0 && Collision.HitWallSubstep(num50, num51))
						{
							list9.Add(new Tuple<int, int>(num50, num51));
						}
					}
				}
				if (list9.Count > 0)
				{
					float num52 = -1f;
					Tuple<int, int> tuple10 = list9[0];
					for (int num53 = 0; num53 < list9.Count; num53++)
					{
						float num54 = Vector2.Distance(new Vector2(list9[num53].Item1, list9[num53].Item2) * 16f + Vector2.One * 8f, vector);
						if (num52 == -1f || num54 < num52)
						{
							num52 = num54;
							tuple10 = list9[num53];
						}
					}
					if (Collision.InTileBounds(tuple10.Item1, tuple10.Item2, num, num3, num2, num4))
					{
						poundRelease = false;
						num5 = tuple10.Item1;
						num6 = tuple10.Item2;
					}
				}
				list9.Clear();
			}
			if (item.type == 510 && num5 == -1 && num6 == -1)
			{
				List<Tuple<int, int>> list10 = new List<Tuple<int, int>>();
				for (int num55 = num; num55 <= num2; num55++)
				{
					for (int num56 = num3; num56 <= num4; num56++)
					{
						Tile tile4 = Main.tile[num55, num56];
						if (tile4.wire() || tile4.wire2() || tile4.wire3())
						{
							list10.Add(new Tuple<int, int>(num55, num56));
						}
					}
				}
				if (list10.Count > 0)
				{
					float num57 = -1f;
					Tuple<int, int> tuple11 = list10[0];
					for (int num58 = 0; num58 < list10.Count; num58++)
					{
						float num59 = Vector2.Distance(new Vector2(list10[num58].Item1, list10[num58].Item2) * 16f + Vector2.One * 8f, vector);
						if (num57 == -1f || num59 < num57)
						{
							num57 = num59;
							tuple11 = list10[num58];
						}
					}
					if (Collision.InTileBounds(tuple11.Item1, tuple11.Item2, num, num3, num2, num4))
					{
						num5 = tuple11.Item1;
						num6 = tuple11.Item2;
					}
				}
				list10.Clear();
			}
			if (item.createTile == 19 && num5 == -1 && num6 == -1)
			{
				List<Tuple<int, int>> list11 = new List<Tuple<int, int>>();
				bool flag2 = false;
				if (Main.tile[tileTargetX, tileTargetY].active() && Main.tile[tileTargetX, tileTargetY].type == 19)
				{
					flag2 = true;
				}
				if (!flag2)
				{
					for (int num60 = num; num60 <= num2; num60++)
					{
						for (int num61 = num3; num61 <= num4; num61++)
						{
							Tile tile5 = Main.tile[num60, num61];
							if (tile5.active() && tile5.type == 19)
							{
								if (!Main.tile[num60 - 1, num61 - 1].active())
								{
									list11.Add(new Tuple<int, int>(num60 - 1, num61 - 1));
								}
								if (!Main.tile[num60 - 1, num61].active())
								{
									list11.Add(new Tuple<int, int>(num60 - 1, num61));
								}
								if (!Main.tile[num60 - 1, num61 + 1].active())
								{
									list11.Add(new Tuple<int, int>(num60 - 1, num61 + 1));
								}
								if (!Main.tile[num60 + 1, num61 - 1].active())
								{
									list11.Add(new Tuple<int, int>(num60 + 1, num61 - 1));
								}
								if (!Main.tile[num60 + 1, num61].active())
								{
									list11.Add(new Tuple<int, int>(num60 + 1, num61));
								}
								if (!Main.tile[num60 + 1, num61 + 1].active())
								{
									list11.Add(new Tuple<int, int>(num60 + 1, num61 + 1));
								}
							}
						}
					}
				}
				if (list11.Count > 0)
				{
					float num62 = -1f;
					Tuple<int, int> tuple12 = list11[0];
					for (int num63 = 0; num63 < list11.Count; num63++)
					{
						float num64 = Vector2.Distance(new Vector2(list11[num63].Item1, list11[num63].Item2) * 16f + Vector2.One * 8f, vector);
						if (num62 == -1f || num64 < num62)
						{
							num62 = num64;
							tuple12 = list11[num63];
						}
					}
					if (Collision.InTileBounds(tuple12.Item1, tuple12.Item2, num, num3, num2, num4))
					{
						num5 = tuple12.Item1;
						num6 = tuple12.Item2;
					}
				}
				list11.Clear();
			}
			if ((item.type == 2340 || item.type == 2739) && num5 == -1 && num6 == -1)
			{
				List<Tuple<int, int>> list12 = new List<Tuple<int, int>>();
				bool flag3 = false;
				if (Main.tile[tileTargetX, tileTargetY].active() && Main.tile[tileTargetX, tileTargetY].type == 314)
				{
					flag3 = true;
				}
				if (!flag3)
				{
					for (int num65 = num; num65 <= num2; num65++)
					{
						for (int num66 = num3; num66 <= num4; num66++)
						{
							Tile tile6 = Main.tile[num65, num66];
							if (tile6.active() && tile6.type == 314)
							{
								bool flag4 = Main.tile[num65 + 1, num66 + 1].active() && Main.tile[num65 + 1, num66 + 1].type == 314;
								bool flag5 = Main.tile[num65 + 1, num66 - 1].active() && Main.tile[num65 + 1, num66 - 1].type == 314;
								bool flag6 = Main.tile[num65 - 1, num66 + 1].active() && Main.tile[num65 - 1, num66 + 1].type == 314;
								bool flag7 = Main.tile[num65 - 1, num66 - 1].active() && Main.tile[num65 - 1, num66 - 1].type == 314;
								if ((!Main.tile[num65 - 1, num66 - 1].active() || Main.tileCut[Main.tile[num65 - 1, num66 - 1].type]) && (flag4 || !flag5))
								{
									list12.Add(new Tuple<int, int>(num65 - 1, num66 - 1));
								}
								if (!Main.tile[num65 - 1, num66].active() || Main.tileCut[Main.tile[num65 - 1, num66].type])
								{
									list12.Add(new Tuple<int, int>(num65 - 1, num66));
								}
								if ((!Main.tile[num65 - 1, num66 + 1].active() || Main.tileCut[Main.tile[num65 - 1, num66 + 1].type]) && (flag5 || !flag4))
								{
									list12.Add(new Tuple<int, int>(num65 - 1, num66 + 1));
								}
								if ((!Main.tile[num65 + 1, num66 - 1].active() || Main.tileCut[Main.tile[num65 + 1, num66 - 1].type]) && (flag6 || !flag7))
								{
									list12.Add(new Tuple<int, int>(num65 + 1, num66 - 1));
								}
								if (!Main.tile[num65 + 1, num66].active() || Main.tileCut[Main.tile[num65 + 1, num66].type])
								{
									list12.Add(new Tuple<int, int>(num65 + 1, num66));
								}
								if ((!Main.tile[num65 + 1, num66 + 1].active() || Main.tileCut[Main.tile[num65 + 1, num66 + 1].type]) && (flag7 || !flag6))
								{
									list12.Add(new Tuple<int, int>(num65 + 1, num66 + 1));
								}
							}
						}
					}
				}
				if (list12.Count > 0)
				{
					float num67 = -1f;
					Tuple<int, int> tuple13 = list12[0];
					for (int num68 = 0; num68 < list12.Count; num68++)
					{
						if ((!Main.tile[list12[num68].Item1, list12[num68].Item2 - 1].active() || Main.tile[list12[num68].Item1, list12[num68].Item2 - 1].type != 314) && (!Main.tile[list12[num68].Item1, list12[num68].Item2 + 1].active() || Main.tile[list12[num68].Item1, list12[num68].Item2 + 1].type != 314))
						{
							float num69 = Vector2.Distance(new Vector2(list12[num68].Item1, list12[num68].Item2) * 16f + Vector2.One * 8f, vector);
							if (num67 == -1f || num69 < num67)
							{
								num67 = num69;
								tuple13 = list12[num68];
							}
						}
					}
					if (Collision.InTileBounds(tuple13.Item1, tuple13.Item2, num, num3, num2, num4) && num67 != -1f)
					{
						num5 = tuple13.Item1;
						num6 = tuple13.Item2;
					}
				}
				list12.Clear();
			}
			if (item.type == 2492 && num5 == -1 && num6 == -1)
			{
				List<Tuple<int, int>> list13 = new List<Tuple<int, int>>();
				bool flag8 = false;
				if (Main.tile[tileTargetX, tileTargetY].active() && Main.tile[tileTargetX, tileTargetY].type == 314)
				{
					flag8 = true;
				}
				if (!flag8)
				{
					for (int num70 = num; num70 <= num2; num70++)
					{
						for (int num71 = num3; num71 <= num4; num71++)
						{
							Tile tile7 = Main.tile[num70, num71];
							if (tile7.active() && tile7.type == 314)
							{
								if (!Main.tile[num70 - 1, num71].active() || Main.tileCut[Main.tile[num70 - 1, num71].type])
								{
									list13.Add(new Tuple<int, int>(num70 - 1, num71));
								}
								if (!Main.tile[num70 + 1, num71].active() || Main.tileCut[Main.tile[num70 + 1, num71].type])
								{
									list13.Add(new Tuple<int, int>(num70 + 1, num71));
								}
							}
						}
					}
				}
				if (list13.Count > 0)
				{
					float num72 = -1f;
					Tuple<int, int> tuple14 = list13[0];
					for (int num73 = 0; num73 < list13.Count; num73++)
					{
						if ((!Main.tile[list13[num73].Item1, list13[num73].Item2 - 1].active() || Main.tile[list13[num73].Item1, list13[num73].Item2 - 1].type != 314) && (!Main.tile[list13[num73].Item1, list13[num73].Item2 + 1].active() || Main.tile[list13[num73].Item1, list13[num73].Item2 + 1].type != 314))
						{
							float num74 = Vector2.Distance(new Vector2(list13[num73].Item1, list13[num73].Item2) * 16f + Vector2.One * 8f, vector);
							if (num72 == -1f || num74 < num72)
							{
								num72 = num74;
								tuple14 = list13[num73];
							}
						}
					}
					if (Collision.InTileBounds(tuple14.Item1, tuple14.Item2, num, num3, num2, num4) && num72 != -1f)
					{
						num5 = tuple14.Item1;
						num6 = tuple14.Item2;
					}
				}
				list13.Clear();
			}
			if (item.createWall > 0 && num5 == -1 && num6 == -1)
			{
				List<Tuple<int, int>> list14 = new List<Tuple<int, int>>();
				for (int num75 = num; num75 <= num2; num75++)
				{
					for (int num76 = num3; num76 <= num4; num76++)
					{
						Tile tile8 = Main.tile[num75, num76];
						if (tile8.wall == 0 && (!tile8.active() || !Main.tileSolid[tile8.type] || Main.tileSolidTop[tile8.type]) && Collision.CanHit(position, width, height, new Vector2(num75, num76) * 16f, 16, 16))
						{
							bool flag9 = false;
							if (Main.tile[num75 - 1, num76].active() || Main.tile[num75 - 1, num76].wall > 0)
							{
								flag9 = true;
							}
							if (Main.tile[num75 + 1, num76].active() || Main.tile[num75 + 1, num76].wall > 0)
							{
								flag9 = true;
							}
							if (Main.tile[num75, num76 - 1].active() || Main.tile[num75, num76 - 1].wall > 0)
							{
								flag9 = true;
							}
							if (Main.tile[num75, num76 + 1].active() || Main.tile[num75, num76 + 1].wall > 0)
							{
								flag9 = true;
							}
							if (Main.tile[num75, num76].active() && Main.tile[num75, num76].type == 11 && (Main.tile[num75, num76].frameX < 18 || Main.tile[num75, num76].frameX > 54))
							{
								flag9 = false;
							}
							if (flag9)
							{
								list14.Add(new Tuple<int, int>(num75, num76));
							}
						}
					}
				}
				if (list14.Count > 0)
				{
					float num77 = -1f;
					Tuple<int, int> tuple15 = list14[0];
					for (int num78 = 0; num78 < list14.Count; num78++)
					{
						float num79 = Vector2.Distance(new Vector2(list14[num78].Item1, list14[num78].Item2) * 16f + Vector2.One * 8f, vector);
						if (num77 == -1f || num79 < num77)
						{
							num77 = num79;
							tuple15 = list14[num78];
						}
					}
					if (Collision.InTileBounds(tuple15.Item1, tuple15.Item2, num, num3, num2, num4))
					{
						num5 = tuple15.Item1;
						num6 = tuple15.Item2;
					}
				}
				list14.Clear();
			}
			if (item.createTile > -1 && Main.tileSolid[item.createTile] && !Main.tileSolidTop[item.createTile] && !Main.tileFrameImportant[item.createTile] && num5 == -1 && num6 == -1)
			{
				List<Tuple<int, int>> list15 = new List<Tuple<int, int>>();
				bool flag10 = false;
				if (Main.tile[tileTargetX, tileTargetY].active())
				{
					flag10 = true;
				}
				if (!Collision.InTileBounds(tileTargetX, tileTargetY, num, num3, num2, num4))
				{
					flag10 = true;
				}
				if (!flag10)
				{
					for (int num80 = num; num80 <= num2; num80++)
					{
						for (int num81 = num3; num81 <= num4; num81++)
						{
							Tile tile9 = Main.tile[num80, num81];
							if (!tile9.active() || Main.tileCut[tile9.type])
							{
								bool flag11 = false;
								if (Main.tile[num80 - 1, num81].active() && Main.tileSolid[Main.tile[num80 - 1, num81].type] && !Main.tileSolidTop[Main.tile[num80 - 1, num81].type])
								{
									flag11 = true;
								}
								if (Main.tile[num80 + 1, num81].active() && Main.tileSolid[Main.tile[num80 + 1, num81].type] && !Main.tileSolidTop[Main.tile[num80 + 1, num81].type])
								{
									flag11 = true;
								}
								if (Main.tile[num80, num81 - 1].active() && Main.tileSolid[Main.tile[num80, num81 - 1].type] && !Main.tileSolidTop[Main.tile[num80, num81 - 1].type])
								{
									flag11 = true;
								}
								if (Main.tile[num80, num81 + 1].active() && Main.tileSolid[Main.tile[num80, num81 + 1].type] && !Main.tileSolidTop[Main.tile[num80, num81 + 1].type])
								{
									flag11 = true;
								}
								if (flag11)
								{
									list15.Add(new Tuple<int, int>(num80, num81));
								}
							}
						}
					}
				}
				if (list15.Count > 0)
				{
					float num82 = -1f;
					Tuple<int, int> tuple16 = list15[0];
					for (int num83 = 0; num83 < list15.Count; num83++)
					{
						if (Collision.EmptyTile(list15[num83].Item1, list15[num83].Item2))
						{
							float num84 = Vector2.Distance(new Vector2(list15[num83].Item1, list15[num83].Item2) * 16f + Vector2.One * 8f, vector);
							if (num82 == -1f || num84 < num82)
							{
								num82 = num84;
								tuple16 = list15[num83];
							}
						}
					}
					if (Collision.InTileBounds(tuple16.Item1, tuple16.Item2, num, num3, num2, num4) && num82 != -1f)
					{
						num5 = tuple16.Item1;
						num6 = tuple16.Item2;
					}
				}
				list15.Clear();
			}
			if (num5 != -1 && num6 != -1)
			{
				Main.smartDigX = (tileTargetX = num5);
				Main.smartDigY = (tileTargetY = num6);
				Main.smartDigShowing = true;
			}
			list.Clear();
		}

		public void SmartitemLookup()
		{
			if (controlTorch && itemAnimation == 0)
			{
				int num = 0;
				int num2 = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
				int num3 = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
				if (gravDir == -1f)
				{
					num3 = (int)((Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16f);
				}
				int num4 = -10;
				int num5 = -10;
				int num6 = -10;
				int num7 = -10;
				int num8 = -10;
				for (int i = 0; i < 50; i++)
				{
					if (inventory[i].pick > 0 && num4 == -10)
					{
						num4 = inventory[i].tileBoost;
					}
					if (inventory[i].axe > 0 && num5 == -10)
					{
						num5 = inventory[i].tileBoost;
					}
					if (inventory[i].hammer > 0 && num6 == -10)
					{
						num6 = inventory[i].tileBoost;
					}
					if ((inventory[i].type == 929 || inventory[i].type == 1338) && num7 == -10)
					{
						num7 = inventory[i].tileBoost;
					}
					if ((inventory[i].type == 424 || inventory[i].type == 1103) && num8 == -10)
					{
						num8 = inventory[i].tileBoost;
					}
				}
				int num9 = 0;
				int num10 = 0;
				if (position.X / 16f >= (float)num2)
				{
					num9 = (int)(position.X / 16f) - num2;
				}
				if ((position.X + (float)width) / 16f <= (float)num2)
				{
					num9 = num2 - (int)((position.X + (float)width) / 16f);
				}
				if (position.Y / 16f >= (float)num3)
				{
					num10 = (int)(position.Y / 16f) - num3;
				}
				if ((position.Y + (float)height) / 16f <= (float)num3)
				{
					num10 = num3 - (int)((position.Y + (float)height) / 16f);
				}
				bool flag = false;
				bool flag2 = false;
				try
				{
					flag2 = Main.tile[num2, num3].liquid > 0;
					if (Main.tile[num2, num3].active())
					{
						int type = Main.tile[num2, num3].type;
						if (type == 219 && num9 <= num8 + tileRangeX && num10 <= num8 + tileRangeY)
						{
							num = 7;
							flag = true;
						}
						else if (type == 209 && num9 <= num7 + tileRangeX && num10 <= num7 + tileRangeY)
						{
							num = 6;
							flag = true;
						}
						else if (Main.tileHammer[type] && num9 <= num6 + tileRangeX && num10 <= num6 + tileRangeY)
						{
							num = 1;
							flag = true;
						}
						else if (Main.tileAxe[type] && num9 <= num5 + tileRangeX && num10 <= num5 + tileRangeY)
						{
							num = 2;
							flag = true;
						}
						else if (num9 <= num4 + tileRangeX && num10 <= num4 + tileRangeY)
						{
							num = 3;
							flag = true;
						}
					}
					else if (flag2 && wet)
					{
						num = 4;
						flag = true;
					}
				}
				catch
				{
				}
				if (!flag && wet)
				{
					num = 4;
				}
				if (num == 0 || num == 4)
				{
					float num11 = Math.Abs((float)Main.mouseX + Main.screenPosition.X - (position.X + (float)(width / 2)));
					float num12 = Math.Abs((float)Main.mouseY + Main.screenPosition.Y - (position.Y + (float)(height / 2))) * 1.3f;
					float num13 = (float)Math.Sqrt(num11 * num11 + num12 * num12);
					if (num13 > 200f)
					{
						num = 5;
					}
				}
				for (int j = 0; j < 50; j++)
				{
					int type2 = inventory[j].type;
					switch (num)
					{
					case 0:
						switch (type2)
						{
						case 8:
						case 427:
						case 428:
						case 429:
						case 430:
						case 431:
						case 432:
						case 433:
						case 523:
						case 974:
						case 1245:
						case 1333:
						case 2274:
							if (nonTorch == -1)
							{
								nonTorch = selectedItem;
							}
							selectedItem = j;
							return;
						case 282:
						case 286:
							if (nonTorch == -1)
							{
								nonTorch = selectedItem;
							}
							selectedItem = j;
							break;
						}
						break;
					case 1:
						if (inventory[j].hammer > 0)
						{
							if (nonTorch == -1)
							{
								nonTorch = selectedItem;
							}
							selectedItem = j;
							return;
						}
						break;
					case 2:
						if (inventory[j].axe > 0)
						{
							if (nonTorch == -1)
							{
								nonTorch = selectedItem;
							}
							selectedItem = j;
							return;
						}
						break;
					case 3:
						if (inventory[j].pick > 0)
						{
							if (nonTorch == -1)
							{
								nonTorch = selectedItem;
							}
							selectedItem = j;
							return;
						}
						break;
					case 4:
						if (inventory[j].type != 282 && inventory[j].type != 286 && inventory[j].type != 930 && (type2 == 8 || type2 == 427 || type2 == 428 || type2 == 429 || type2 == 430 || type2 == 431 || type2 == 432 || type2 == 433 || type2 == 974 || type2 == 1245 || type2 == 2274))
						{
							if (nonTorch == -1)
							{
								nonTorch = selectedItem;
							}
							if (inventory[selectedItem].createTile != 4)
							{
								selectedItem = j;
							}
							break;
						}
						if ((type2 == 282 || type2 == 286) && flag2)
						{
							if (nonTorch == -1)
							{
								nonTorch = selectedItem;
							}
							selectedItem = j;
							return;
						}
						if (type2 == 930 && flag2)
						{
							bool flag4 = false;
							for (int num16 = 57; num16 >= 0; num16--)
							{
								if (inventory[num16].ammo == inventory[j].useAmmo)
								{
									flag4 = true;
									break;
								}
							}
							if (flag4)
							{
								if (nonTorch == -1)
								{
									nonTorch = selectedItem;
								}
								selectedItem = j;
								return;
							}
						}
						else if (type2 == 1333 || type2 == 523)
						{
							if (nonTorch == -1)
							{
								nonTorch = selectedItem;
							}
							selectedItem = j;
							return;
						}
						break;
					case 5:
						switch (type2)
						{
						case 8:
						case 427:
						case 428:
						case 429:
						case 430:
						case 431:
						case 432:
						case 433:
						case 523:
						case 974:
						case 1245:
						case 1333:
						case 2274:
							if (nonTorch == -1)
							{
								nonTorch = selectedItem;
							}
							if (inventory[selectedItem].createTile != 4)
							{
								selectedItem = j;
							}
							break;
						case 930:
						{
							bool flag3 = false;
							for (int num14 = 57; num14 >= 0; num14--)
							{
								if (inventory[num14].ammo == inventory[j].useAmmo)
								{
									flag3 = true;
									break;
								}
							}
							if (flag3)
							{
								if (nonTorch == -1)
								{
									nonTorch = selectedItem;
								}
								selectedItem = j;
								return;
							}
							break;
						}
						case 282:
						case 286:
							if (nonTorch == -1)
							{
								nonTorch = selectedItem;
							}
							selectedItem = j;
							return;
						}
						break;
					case 6:
					{
						int num15 = 929;
						if (Main.tile[num2, num3].frameX >= 72)
						{
							num15 = 1338;
						}
						if (type2 == num15)
						{
							if (nonTorch == -1)
							{
								nonTorch = selectedItem;
							}
							selectedItem = j;
							return;
						}
						break;
					}
					case 7:
						if (type2 == 424 || type2 == 1103)
						{
							if (nonTorch == -1)
							{
								nonTorch = selectedItem;
							}
							selectedItem = j;
							return;
						}
						break;
					}
				}
			}
			else if (nonTorch > -1 && itemAnimation == 0)
			{
				selectedItem = nonTorch;
				nonTorch = -1;
			}
		}

		public void ResetEffects()
		{
			armorSteath = false;
			statDefense = 0;
			accWatch = 0;
			accCompass = 0;
			accDepthMeter = 0;
			accDivingHelm = false;
			lifeRegen = 0;
			manaCost = 1f;
			meleeSpeed = 1f;
			meleeDamage = 1f;
			rangedDamage = 1f;
			magicDamage = 1f;
			minionDamage = 1f;
			minionKB = 0f;
			moveSpeed = 1f;
			boneArmor = false;
			honey = false;
			frostArmor = false;
			rocketBoots = 0;
			fireWalk = false;
			noKnockback = false;
			jumpBoost = false;
			noFallDmg = false;
			accFlipper = false;
			spawnMax = false;
			spaceGun = false;
			killGuide = false;
			killClothier = false;
			lavaImmune = false;
			gills = false;
			slowFall = false;
			findTreasure = false;
			invis = false;
			nightVision = false;
			enemySpawns = false;
			thorns = false;
			aggro = 0;
			waterWalk = false;
			waterWalk2 = false;
			detectCreature = false;
			gravControl = false;
			bee = false;
			gravControl2 = false;
			statLifeMax2 = statLifeMax;
			statManaMax2 = statManaMax;
			ammoCost80 = false;
			ammoCost75 = false;
			manaRegenBuff = false;
			meleeCrit = 4;
			rangedCrit = 4;
			magicCrit = 4;
			arrowDamage = 1f;
			bulletDamage = 1f;
			rocketDamage = 1f;
			lightOrb = false;
			blueFairy = false;
			redFairy = false;
			greenFairy = false;
			wisp = false;
			bunny = false;
			turtle = false;
			eater = false;
			skeletron = false;
			hornet = false;
			zephyrfish = false;
			tiki = false;
			lizard = false;
			parrot = false;
			sapling = false;
			cSapling = false;
			truffle = false;
			shadowDodge = false;
			palladiumRegen = false;
			chaosState = false;
			onHitDodge = false;
			onHitRegen = false;
			onHitPetal = false;
			iceBarrier = false;
			maxMinions = 1;
			ammoBox = false;
			ammoPotion = false;
			penguin = false;
			inferno = false;
			manaMagnet = false;
			lifeMagnet = false;
			lifeForce = false;
			dangerSense = false;
			endurance = 0f;
			calmed = false;
			beetleOrbs = 0;
			beetleBuff = false;
			miniMinotaur = false;
			fishingSkill = 0;
			cratePotion = false;
			sonarPotion = false;
			accTackleBox = false;
			accFishingLine = false;
			wallSpeed = 1f;
			tileSpeed = 1f;
			autoPaint = false;
			manaSick = false;
			puppy = false;
			grinch = false;
			blackCat = false;
			spider = false;
			squashling = false;
			magicCuffs = false;
			coldDash = false;
			magicQuiver = false;
			magmaStone = false;
			lavaRose = false;
			eyeSpring = false;
			snowman = false;
			scope = false;
			panic = false;
			dino = false;
			crystalLeaf = false;
			pygmy = false;
			raven = false;
			slime = false;
			hornetMinion = false;
			impMinion = false;
			twinsMinion = false;
			spiderMinion = false;
			pirateMinion = false;
			sharknadoMinion = false;
			chilled = false;
			frozen = false;
			ichor = false;
			manaRegenBonus = 0;
			manaRegenDelayBonus = 0;
			carpet = false;
			iceSkate = false;
			dash = 0;
			spikedBoots = 0;
			blackBelt = false;
			lavaMax = 0;
			archery = false;
			poisoned = false;
			venom = false;
			blind = false;
			blackout = false;
			onFire = false;
			dripping = false;
			drippingSlime = false;
			burned = false;
			suffocating = false;
			onFire2 = false;
			onFrostBurn = false;
			frostBurn = false;
			noItems = false;
			blockRange = 0;
			pickSpeed = 1f;
			wereWolf = false;
			rulerAcc = false;
			bleed = false;
			confused = false;
			wings = 0;
			wingsLogic = 0;
			wingTimeMax = 0;
			brokenArmor = false;
			silence = false;
			slow = false;
			gross = false;
			tongued = false;
			kbGlove = false;
			kbBuff = false;
			starCloak = false;
			longInvince = false;
			pStone = false;
			manaFlower = false;
			crimsonRegen = false;
			ghostHeal = false;
			ghostHurt = false;
			turtleArmor = false;
			turtleThorns = false;
			spiderArmor = false;
			loveStruck = false;
			stinky = false;
			resistCold = false;
			ignoreWater = false;
			meleeEnchant = 0;
			discount = false;
			coins = false;
			doubleJump2 = false;
			doubleJump3 = false;
			doubleJump4 = false;
			paladinBuff = false;
			paladinGive = false;
			autoJump = false;
			justJumped = false;
			jumpSpeedBoost = 0f;
			extraFall = 0;
			if (whoAmi == Main.myPlayer)
			{
				tileRangeX = 5;
				tileRangeY = 4;
			}
			mount.CheckMountBuff(this);
		}

		public void UpdateImmunity()
		{
			if (immune)
			{
				immuneTime--;
				if (immuneTime <= 0)
				{
					immune = false;
				}
				immuneAlpha += immuneAlphaDirection * 50;
				if (immuneAlpha <= 50)
				{
					immuneAlphaDirection = 1;
				}
				else if (immuneAlpha >= 205)
				{
					immuneAlphaDirection = -1;
				}
			}
			else
			{
				immuneAlpha = 0;
			}
		}

		public void UpdateLifeRegen()
		{
			if (poisoned)
			{
				if (lifeRegen > 0)
				{
					lifeRegen = 0;
				}
				lifeRegenTime = 0;
				lifeRegen -= 4;
			}
			else if (venom)
			{
				if (lifeRegen > 0)
				{
					lifeRegen = 0;
				}
				lifeRegenTime = 0;
				lifeRegen -= 12;
			}
			if (onFire)
			{
				if (lifeRegen > 0)
				{
					lifeRegen = 0;
				}
				lifeRegenTime = 0;
				lifeRegen -= 8;
			}
			if (onFrostBurn)
			{
				if (lifeRegen > 0)
				{
					lifeRegen = 0;
				}
				lifeRegenTime = 0;
				lifeRegen -= 12;
			}
			if (onFire2)
			{
				if (lifeRegen > 0)
				{
					lifeRegen = 0;
				}
				lifeRegenTime = 0;
				lifeRegen -= 12;
			}
			if (burned)
			{
				if (lifeRegen > 0)
				{
					lifeRegen = 0;
				}
				lifeRegenTime = 0;
				lifeRegen -= 60;
				moveSpeed *= 0.5f;
			}
			if (suffocating)
			{
				if (lifeRegen > 0)
				{
					lifeRegen = 0;
				}
				lifeRegenTime = 0;
				lifeRegen -= 40;
			}
			lifeRegenTime++;
			if (crimsonRegen)
			{
				lifeRegenTime++;
			}
			if (honey)
			{
				lifeRegenTime += 2;
				lifeRegen += 2;
			}
			if (whoAmi == Main.myPlayer && Main.campfire)
			{
				lifeRegen++;
			}
			if (whoAmi == Main.myPlayer && Main.heartLantern)
			{
				lifeRegen += 2;
			}
			if (bleed)
			{
				lifeRegenTime = 0;
			}
			float num = 0f;
			if (lifeRegenTime >= 300)
			{
				num += 1f;
			}
			if (lifeRegenTime >= 600)
			{
				num += 1f;
			}
			if (lifeRegenTime >= 900)
			{
				num += 1f;
			}
			if (lifeRegenTime >= 1200)
			{
				num += 1f;
			}
			if (lifeRegenTime >= 1500)
			{
				num += 1f;
			}
			if (lifeRegenTime >= 1800)
			{
				num += 1f;
			}
			if (lifeRegenTime >= 2400)
			{
				num += 1f;
			}
			if (lifeRegenTime >= 3000)
			{
				num += 1f;
			}
			if (lifeRegenTime >= 3600)
			{
				num += 1f;
				lifeRegenTime = 3600;
			}
			num = ((velocity.X != 0f && grappling[0] <= 0) ? (num * 0.5f) : (num * 1.25f));
			if (crimsonRegen)
			{
				num *= 1.5f;
			}
			if (whoAmi == Main.myPlayer && Main.campfire)
			{
				num *= 1.1f;
			}
			float num2 = (float)statLifeMax2 / 400f * 0.85f + 0.15f;
			num *= num2;
			lifeRegen += (int)Math.Round(num);
			lifeRegenCount += lifeRegen;
			if (palladiumRegen)
			{
				lifeRegenCount += 6;
			}
			while (lifeRegenCount >= 120)
			{
				lifeRegenCount -= 120;
				if (statLife < statLifeMax2)
				{
					statLife++;
					if (crimsonRegen)
					{
						for (int i = 0; i < 10; i++)
						{
							int num3 = Dust.NewDust(position, width, height, 5, 0f, 0f, 175, default(Color), 1.75f);
							Main.dust[num3].noGravity = true;
							Main.dust[num3].velocity *= 0.75f;
							int num4 = Main.rand.Next(-40, 41);
							int num5 = Main.rand.Next(-40, 41);
							Main.dust[num3].position.X += num4;
							Main.dust[num3].position.Y += num5;
							Main.dust[num3].velocity.X = (float)(-num4) * 0.075f;
							Main.dust[num3].velocity.Y = (float)(-num5) * 0.075f;
						}
					}
				}
				if (statLife > statLifeMax2)
				{
					statLife = statLifeMax2;
				}
			}
			if (burned || suffocating)
			{
				while (lifeRegenCount <= -600)
				{
					lifeRegenCount += 600;
					statLife -= 5;
					CombatText.NewText(new Rectangle((int)position.X, (int)position.Y, width, height), new Color(255, 60, 70, 255), string.Concat(5), false, true);
					if (statLife <= 0 && whoAmi == Main.myPlayer)
					{
						if (suffocating)
						{
							KillMe(10.0, 0, false, " " + Lang.dt[2]);
						}
						else
						{
							KillMe(10.0, 0, false, " " + Lang.dt[1]);
						}
					}
				}
				return;
			}
			while (lifeRegenCount <= -120)
			{
				if (lifeRegenCount <= -480)
				{
					lifeRegenCount += 480;
					statLife -= 4;
					CombatText.NewText(new Rectangle((int)position.X, (int)position.Y, width, height), new Color(255, 60, 70, 255), string.Concat(4), false, true);
				}
				else if (lifeRegenCount <= -360)
				{
					lifeRegenCount += 360;
					statLife -= 3;
					CombatText.NewText(new Rectangle((int)position.X, (int)position.Y, width, height), new Color(255, 60, 70, 255), string.Concat(3), false, true);
				}
				else if (lifeRegenCount <= -240)
				{
					lifeRegenCount += 240;
					statLife -= 2;
					CombatText.NewText(new Rectangle((int)position.X, (int)position.Y, width, height), new Color(255, 60, 70, 255), string.Concat(2), false, true);
				}
				else
				{
					lifeRegenCount += 120;
					statLife--;
					CombatText.NewText(new Rectangle((int)position.X, (int)position.Y, width, height), new Color(255, 60, 70, 255), string.Concat(1), false, true);
				}
				if (statLife <= 0 && whoAmi == Main.myPlayer)
				{
					if (poisoned || venom)
					{
						KillMe(10.0, 0, false, " " + Lang.dt[0]);
					}
					else
					{
						KillMe(10.0, 0, false, " " + Lang.dt[1]);
					}
				}
			}
		}

		public void UpdateManaRegen()
		{
			if (manaRegenDelay > 0)
			{
				manaRegenDelay--;
				manaRegenDelay -= manaRegenDelayBonus;
				if ((velocity.X == 0f && velocity.Y == 0f) || grappling[0] >= 0 || manaRegenBuff)
				{
					manaRegenDelay--;
				}
			}
			if (manaRegenBuff && manaRegenDelay > 20)
			{
				manaRegenDelay = 20;
			}
			if (manaRegenDelay <= 0)
			{
				manaRegenDelay = 0;
				manaRegen = statManaMax2 / 7 + 1 + manaRegenBonus;
				if ((velocity.X == 0f && velocity.Y == 0f) || grappling[0] >= 0 || manaRegenBuff)
				{
					manaRegen += statManaMax2 / 2;
				}
				float num = (float)statMana / (float)statManaMax2 * 0.8f + 0.2f;
				if (manaRegenBuff)
				{
					num = 1f;
				}
				manaRegen = (int)((double)((float)manaRegen * num) * 1.15);
			}
			else
			{
				manaRegen = 0;
			}
			manaRegenCount += manaRegen;
			while (manaRegenCount >= 120)
			{
				bool flag = false;
				manaRegenCount -= 120;
				if (statMana < statManaMax2)
				{
					statMana++;
					flag = true;
				}
				if (statMana < statManaMax2)
				{
					continue;
				}
				if (whoAmi == Main.myPlayer && flag)
				{
					Main.PlaySound(25);
					for (int i = 0; i < 5; i++)
					{
						int num2 = Dust.NewDust(position, width, height, 45, 0f, 0f, 255, default(Color), (float)Main.rand.Next(20, 26) * 0.1f);
						Main.dust[num2].noLight = true;
						Main.dust[num2].noGravity = true;
						Main.dust[num2].velocity *= 0.5f;
					}
				}
				statMana = statManaMax2;
			}
		}

		public void UpdateJumpHeight()
		{
			if (mount.Active)
			{
				jumpHeight = mount.JumpHeight(velocity.X);
				jumpSpeed = mount.JumpSpeed(velocity.X);
			}
			else
			{
				if (jumpBoost)
				{
					jumpHeight = 20;
					jumpSpeed = 6.51f;
				}
				if (wereWolf)
				{
					jumpHeight += 2;
					jumpSpeed += 0.2f;
				}
				jumpSpeed += jumpSpeedBoost;
			}
			if (sticky)
			{
				jumpHeight /= 10;
				jumpSpeed /= 5f;
			}
		}

		public void FindPulley()
		{
			if (!controlUp && !controlDown)
			{
				return;
			}
			int num = (int)(position.X + (float)(width / 2)) / 16;
			int num2 = (int)(position.Y - 8f) / 16;
			if (Main.tile[num, num2] == null || !Main.tile[num, num2].active() || !Main.tileRope[Main.tile[num, num2].type])
			{
				return;
			}
			float num3 = position.Y;
			if (Main.tile[num, num2 - 1] == null)
			{
				Main.tile[num, num2 - 1] = new Tile();
			}
			if (Main.tile[num, num2 + 1] == null)
			{
				Main.tile[num, num2 + 1] = new Tile();
			}
			if ((!Main.tile[num, num2 - 1].active() || !Main.tileRope[Main.tile[num, num2 - 1].type]) && (!Main.tile[num, num2 + 1].active() || !Main.tileRope[Main.tile[num, num2 + 1].type]))
			{
				num3 = num2 * 16 + 22;
			}
			float num4 = num * 16 + 8 - width / 2 + 6 * direction;
			int num5 = num * 16 + 8 - width / 2 + 6;
			int num6 = num * 16 + 8 - width / 2;
			int num7 = num * 16 + 8 - width / 2 + -6;
			int num8 = 1;
			float num9 = Math.Abs(position.X - (float)num5);
			if (Math.Abs(position.X - (float)num6) < num9)
			{
				num8 = 2;
				num9 = Math.Abs(position.X - (float)num6);
			}
			if (Math.Abs(position.X - (float)num7) < num9)
			{
				num8 = 3;
				num9 = Math.Abs(position.X - (float)num7);
			}
			if (num8 == 1)
			{
				num4 = num5;
				pulleyDir = 2;
				direction = 1;
			}
			if (num8 == 2)
			{
				num4 = num6;
				pulleyDir = 1;
			}
			if (num8 == 3)
			{
				num4 = num7;
				pulleyDir = 2;
				direction = -1;
			}
			if (!Collision.SolidCollision(new Vector2(num4, position.Y), width, height))
			{
				if (whoAmi == Main.myPlayer)
				{
					Main.cameraX = Main.cameraX + position.X - num4;
				}
				pulley = true;
				position.X = num4;
				gfxOffY = position.Y - num3;
				stepSpeed = 2.5f;
				position.Y = num3;
				velocity.X = 0f;
				return;
			}
			num4 = num5;
			pulleyDir = 2;
			direction = 1;
			if (!Collision.SolidCollision(new Vector2(num4, position.Y), width, height))
			{
				if (whoAmi == Main.myPlayer)
				{
					Main.cameraX = Main.cameraX + position.X - num4;
				}
				pulley = true;
				position.X = num4;
				gfxOffY = position.Y - num3;
				stepSpeed = 2.5f;
				position.Y = num3;
				velocity.X = 0f;
				return;
			}
			num4 = num7;
			pulleyDir = 2;
			direction = -1;
			if (!Collision.SolidCollision(new Vector2(num4, position.Y), width, height))
			{
				if (whoAmi == Main.myPlayer)
				{
					Main.cameraX = Main.cameraX + position.X - num4;
				}
				pulley = true;
				position.X = num4;
				gfxOffY = position.Y - num3;
				stepSpeed = 2.5f;
				position.Y = num3;
				velocity.X = 0f;
			}
		}

		public void HorizontalMovement()
		{
			if (trackBoost != 0f)
			{
				velocity.X += trackBoost;
				trackBoost = 0f;
				if (velocity.X < 0f)
				{
					if (velocity.X < 0f - maxRunSpeed)
					{
						velocity.X = 0f - maxRunSpeed;
					}
				}
				else if (velocity.X > maxRunSpeed)
				{
					velocity.X = maxRunSpeed;
				}
			}
			if (controlLeft && velocity.X > 0f - maxRunSpeed)
			{
				if (!mount.Active || mount.Type != 6 || velocity.Y == 0f)
				{
					if (velocity.X > runSlowdown)
					{
						velocity.X -= runSlowdown;
					}
					velocity.X -= runAcceleration;
				}
				if (onWrongGround)
				{
					if (velocity.X < 0f - runSlowdown)
					{
						velocity.X += runSlowdown;
					}
					else
					{
						velocity.X = 0f;
					}
				}
				if (mount.Active && mount.Type == 6 && !onWrongGround)
				{
					if (velocity.X < 0f)
					{
						direction = -1;
					}
					else
					{
						if (velocity.Y != 0f)
						{
							return;
						}
						Main.PlaySound(2, (int)position.X + width / 2, (int)position.Y + height / 2, 55);
						if ((double)Math.Abs(velocity.X) > (double)maxRunSpeed * 0.66)
						{
							if (Main.rand.Next(2) == 0)
							{
								Minecart.WheelSparks(position + velocity * 0.66f, width, height, 1);
							}
							if (Main.rand.Next(2) == 0)
							{
								Minecart.WheelSparks(position + velocity * 0.33f, width, height, 1);
							}
							if (Main.rand.Next(2) == 0)
							{
								Minecart.WheelSparks(position, width, height, 1);
							}
						}
						else if ((double)Math.Abs(velocity.X) > (double)maxRunSpeed * 0.33)
						{
							if (Main.rand.Next(3) != 0)
							{
								Minecart.WheelSparks(position + velocity * 0.5f, width, height, 1);
							}
							if (Main.rand.Next(3) != 0)
							{
								Minecart.WheelSparks(position, width, height, 1);
							}
						}
						else
						{
							Minecart.WheelSparks(position, width, height, 1);
						}
					}
				}
				else if (!sandStorm && (itemAnimation == 0 || inventory[selectedItem].useTurn))
				{
					direction = -1;
				}
			}
			else if (controlRight && velocity.X < maxRunSpeed)
			{
				if (!mount.Active || mount.Type != 6 || velocity.Y == 0f)
				{
					if (velocity.X < 0f - runSlowdown)
					{
						velocity.X += runSlowdown;
					}
					velocity.X += runAcceleration;
				}
				if (onWrongGround)
				{
					if (velocity.X > runSlowdown)
					{
						velocity.X -= runSlowdown;
					}
					else
					{
						velocity.X = 0f;
					}
				}
				if (mount.Active && mount.Type == 6 && !onWrongGround)
				{
					if (velocity.X > 0f)
					{
						direction = 1;
					}
					else
					{
						if (velocity.Y != 0f)
						{
							return;
						}
						Main.PlaySound(2, (int)position.X + width / 2, (int)position.Y + height / 2, 55);
						if ((double)Math.Abs(velocity.X) > (double)maxRunSpeed * 0.66)
						{
							if (Main.rand.Next(2) == 0)
							{
								Minecart.WheelSparks(position + velocity * 0.66f, width, height, 1);
							}
							if (Main.rand.Next(2) == 0)
							{
								Minecart.WheelSparks(position + velocity * 0.33f, width, height, 1);
							}
							if (Main.rand.Next(2) == 0)
							{
								Minecart.WheelSparks(position, width, height, 1);
							}
						}
						else if ((double)Math.Abs(velocity.X) > (double)maxRunSpeed * 0.33)
						{
							if (Main.rand.Next(3) != 0)
							{
								Minecart.WheelSparks(position + velocity * 0.5f, width, height, 1);
							}
							if (Main.rand.Next(3) != 0)
							{
								Minecart.WheelSparks(position, width, height, 1);
							}
						}
						else
						{
							Minecart.WheelSparks(position, width, height, 1);
						}
					}
				}
				else if (!sandStorm && (itemAnimation == 0 || inventory[selectedItem].useTurn))
				{
					direction = 1;
				}
			}
			else if (controlLeft && velocity.X > 0f - accRunSpeed && dashDelay >= 0)
			{
				if (mount.Active && mount.Type == 6)
				{
					if (velocity.X < 0f)
					{
						direction = -1;
					}
				}
				else if (itemAnimation == 0 || inventory[selectedItem].useTurn)
				{
					direction = -1;
				}
				if (velocity.Y == 0f || wingsLogic > 0 || mount.CanFly)
				{
					if (velocity.X > runSlowdown)
					{
						velocity.X -= runSlowdown;
					}
					velocity.X -= runAcceleration * 0.2f;
					if (wingsLogic > 0)
					{
						velocity.X -= runAcceleration * 0.2f;
					}
				}
				if (onWrongGround)
				{
					if (velocity.X < runSlowdown)
					{
						velocity.X += runSlowdown;
					}
					else
					{
						velocity.X = 0f;
					}
				}
				if (!(velocity.X < (0f - (accRunSpeed + maxRunSpeed)) / 2f) || velocity.Y != 0f || mount.Active)
				{
					return;
				}
				int num = 0;
				if (gravDir == -1f)
				{
					num -= height;
				}
				if (runSoundDelay == 0 && velocity.Y == 0f)
				{
					Main.PlaySound(17, (int)position.X, (int)position.Y);
					runSoundDelay = 9;
				}
				if (wings == 3)
				{
					int num2 = Dust.NewDust(new Vector2(position.X - 4f, position.Y + (float)height + (float)num), width + 8, 4, 186, (0f - velocity.X) * 0.5f, velocity.Y * 0.5f, 50, default(Color), 1.5f);
					Main.dust[num2].velocity *= 0.025f;
					num2 = Dust.NewDust(new Vector2(position.X - 4f, position.Y + (float)height + (float)num), width + 8, 4, 186, (0f - velocity.X) * 0.5f, velocity.Y * 0.5f, 50, default(Color), 1.5f);
					Main.dust[num2].velocity *= 0.2f;
				}
				else if (coldDash)
				{
					for (int i = 0; i < 2; i++)
					{
						int num3 = ((i != 0) ? Dust.NewDust(new Vector2(position.X + (float)(width / 2), position.Y + (float)height + gfxOffY), width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f) : Dust.NewDust(new Vector2(position.X, position.Y + (float)height + gfxOffY), width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f));
						Main.dust[num3].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
						Main.dust[num3].noGravity = true;
						Main.dust[num3].noLight = true;
						Main.dust[num3].velocity *= 0.001f;
						Main.dust[num3].velocity.Y -= 0.003f;
					}
				}
				else
				{
					int num4 = Dust.NewDust(new Vector2(position.X - 4f, position.Y + (float)height + (float)num), width + 8, 4, 16, (0f - velocity.X) * 0.5f, velocity.Y * 0.5f, 50, default(Color), 1.5f);
					Main.dust[num4].velocity.X = Main.dust[num4].velocity.X * 0.2f;
					Main.dust[num4].velocity.Y = Main.dust[num4].velocity.Y * 0.2f;
				}
			}
			else if (controlRight && velocity.X < accRunSpeed)
			{
				if (mount.Active && mount.Type == 6)
				{
					if (velocity.X > 0f)
					{
						direction = -1;
					}
				}
				else if (itemAnimation == 0 || inventory[selectedItem].useTurn)
				{
					direction = 1;
				}
				if (velocity.Y == 0f || wingsLogic > 0 || mount.CanFly)
				{
					if (velocity.X < 0f - runSlowdown)
					{
						velocity.X += runSlowdown;
					}
					velocity.X += runAcceleration * 0.2f;
					if (wingsLogic > 0)
					{
						velocity.X += runAcceleration * 0.2f;
					}
				}
				if (onWrongGround)
				{
					if (velocity.X > runSlowdown)
					{
						velocity.X -= runSlowdown;
					}
					else
					{
						velocity.X = 0f;
					}
				}
				if (!(velocity.X > (accRunSpeed + maxRunSpeed) / 2f) || velocity.Y != 0f || mount.Active)
				{
					return;
				}
				int num5 = 0;
				if (gravDir == -1f)
				{
					num5 -= height;
				}
				if (runSoundDelay == 0 && velocity.Y == 0f)
				{
					Main.PlaySound(17, (int)position.X, (int)position.Y);
					runSoundDelay = 9;
				}
				if (wings == 3)
				{
					int num6 = Dust.NewDust(new Vector2(position.X - 4f, position.Y + (float)height + (float)num5), width + 8, 4, 186, (0f - velocity.X) * 0.5f, velocity.Y * 0.5f, 50, default(Color), 1.5f);
					Main.dust[num6].velocity *= 0.025f;
					num6 = Dust.NewDust(new Vector2(position.X - 4f, position.Y + (float)height + (float)num5), width + 8, 4, 186, (0f - velocity.X) * 0.5f, velocity.Y * 0.5f, 50, default(Color), 1.5f);
					Main.dust[num6].velocity *= 0.2f;
				}
				else if (coldDash)
				{
					for (int j = 0; j < 2; j++)
					{
						int num7 = ((j != 0) ? Dust.NewDust(new Vector2(position.X + (float)(width / 2), position.Y + (float)height + gfxOffY), width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f) : Dust.NewDust(new Vector2(position.X, position.Y + (float)height + gfxOffY), width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f));
						Main.dust[num7].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
						Main.dust[num7].noGravity = true;
						Main.dust[num7].noLight = true;
						Main.dust[num7].velocity *= 0.001f;
						Main.dust[num7].velocity.Y -= 0.003f;
					}
				}
				else
				{
					int num8 = Dust.NewDust(new Vector2(position.X - 4f, position.Y + (float)height + (float)num5), width + 8, 4, 16, (0f - velocity.X) * 0.5f, velocity.Y * 0.5f, 50, default(Color), 1.5f);
					Main.dust[num8].velocity.X = Main.dust[num8].velocity.X * 0.2f;
					Main.dust[num8].velocity.Y = Main.dust[num8].velocity.Y * 0.2f;
				}
			}
			else if (mount.Active && mount.Type == 6 && Math.Abs(velocity.X) >= 1f)
			{
				if (onWrongGround)
				{
					if (velocity.X > 0f)
					{
						if (velocity.X > runSlowdown)
						{
							velocity.X -= runSlowdown;
						}
						else
						{
							velocity.X = 0f;
						}
					}
					else if (velocity.X < 0f)
					{
						if (velocity.X < 0f - runSlowdown)
						{
							velocity.X += runSlowdown;
						}
						else
						{
							velocity.X = 0f;
						}
					}
				}
				if (velocity.X > maxRunSpeed)
				{
					velocity.X = maxRunSpeed;
				}
				if (velocity.X < 0f - maxRunSpeed)
				{
					velocity.X = 0f - maxRunSpeed;
				}
			}
			else if (velocity.Y == 0f)
			{
				if (velocity.X > runSlowdown)
				{
					velocity.X -= runSlowdown;
				}
				else if (velocity.X < 0f - runSlowdown)
				{
					velocity.X += runSlowdown;
				}
				else
				{
					velocity.X = 0f;
				}
			}
			else if ((double)velocity.X > (double)runSlowdown * 0.5)
			{
				velocity.X -= runSlowdown * 0.5f;
			}
			else if ((double)velocity.X < (double)(0f - runSlowdown) * 0.5)
			{
				velocity.X += runSlowdown * 0.5f;
			}
			else
			{
				velocity.X = 0f;
			}
		}

		public void JumpMovement()
		{
			if (controlJump)
			{
				bool flag = false;
				if (mount.Active && mount.Type == 3 && wetSlime > 0)
				{
					flag = true;
				}
				if (jump > 0)
				{
					if (velocity.Y == 0f)
					{
						jump = 0;
					}
					else
					{
						velocity.Y = (0f - jumpSpeed) * gravDir;
						if (merman && (!mount.Active || mount.Type != 6))
						{
							if (swimTime <= 10)
							{
								swimTime = 30;
							}
						}
						else
						{
							jump--;
						}
					}
				}
				else if ((sliding || velocity.Y == 0f || flag || jumpAgain || jumpAgain2 || jumpAgain3 || jumpAgain4 || (wet && accFlipper && (!mount.Active || mount.Type != 6))) && (releaseJump || (autoJump && (velocity.Y == 0f || sliding))))
				{
					if (sliding || velocity.Y == 0f)
					{
						justJumped = true;
					}
					bool flag2 = false;
					if (wet && accFlipper)
					{
						if (swimTime == 0)
						{
							swimTime = 30;
						}
						flag2 = true;
					}
					bool flag3 = false;
					bool flag4 = false;
					bool flag5 = false;
					if (!flag)
					{
						if (jumpAgain2)
						{
							flag3 = true;
							jumpAgain2 = false;
						}
						else if (jumpAgain3)
						{
							flag4 = true;
							jumpAgain3 = false;
						}
						else if (jumpAgain4)
						{
							jumpAgain4 = false;
							flag5 = true;
						}
						else
						{
							jumpAgain = false;
						}
					}
					canRocket = false;
					rocketRelease = false;
					if ((velocity.Y == 0f || sliding || (autoJump && justJumped)) && doubleJump)
					{
						jumpAgain = true;
					}
					if ((velocity.Y == 0f || sliding || (autoJump && justJumped)) && doubleJump2)
					{
						jumpAgain2 = true;
					}
					if ((velocity.Y == 0f || sliding || (autoJump && justJumped)) && doubleJump3)
					{
						jumpAgain3 = true;
					}
					if ((velocity.Y == 0f || sliding || (autoJump && justJumped)) && doubleJump4)
					{
						jumpAgain4 = true;
					}
					if (velocity.Y == 0f || flag2 || sliding || flag)
					{
						velocity.Y = (0f - jumpSpeed) * gravDir;
						jump = jumpHeight;
						if (sliding)
						{
							velocity.X = 3 * -slideDir;
						}
					}
					else if (flag3)
					{
						dJumpEffect2 = true;
						float gravDir2 = gravDir;
						float num7 = -1f;
						Main.PlaySound(16, (int)position.X, (int)position.Y);
						velocity.Y = (0f - jumpSpeed) * gravDir;
						jump = jumpHeight * 3;
					}
					else if (flag4)
					{
						dJumpEffect3 = true;
						float gravDir3 = gravDir;
						float num8 = -1f;
						Main.PlaySound(16, (int)position.X, (int)position.Y);
						velocity.Y = (0f - jumpSpeed) * gravDir;
						jump = (int)((double)jumpHeight * 1.5);
					}
					else if (flag5)
					{
						dJumpEffect4 = true;
						int num = height;
						if (gravDir == -1f)
						{
							num = 0;
						}
						Main.PlaySound(2, (int)position.X, (int)position.Y, 16);
						velocity.Y = (0f - jumpSpeed) * gravDir;
						jump = jumpHeight * 2;
						for (int i = 0; i < 10; i++)
						{
							int num2 = Dust.NewDust(new Vector2(position.X - 34f, position.Y + (float)num - 16f), 102, 32, 188, (0f - velocity.X) * 0.5f, velocity.Y * 0.5f, 100, default(Color), 1.5f);
							Main.dust[num2].velocity.X = Main.dust[num2].velocity.X * 0.5f - velocity.X * 0.1f;
							Main.dust[num2].velocity.Y = Main.dust[num2].velocity.Y * 0.5f - velocity.Y * 0.3f;
						}
						int num3 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 16f, position.Y + (float)num - 16f), new Vector2(0f - velocity.X, 0f - velocity.Y), Main.rand.Next(435, 438));
						Main.gore[num3].velocity.X = Main.gore[num3].velocity.X * 0.1f - velocity.X * 0.1f;
						Main.gore[num3].velocity.Y = Main.gore[num3].velocity.Y * 0.1f - velocity.Y * 0.05f;
						num3 = Gore.NewGore(new Vector2(position.X - 36f, position.Y + (float)num - 16f), new Vector2(0f - velocity.X, 0f - velocity.Y), Main.rand.Next(435, 438));
						Main.gore[num3].velocity.X = Main.gore[num3].velocity.X * 0.1f - velocity.X * 0.1f;
						Main.gore[num3].velocity.Y = Main.gore[num3].velocity.Y * 0.1f - velocity.Y * 0.05f;
						num3 = Gore.NewGore(new Vector2(position.X + (float)width + 4f, position.Y + (float)num - 16f), new Vector2(0f - velocity.X, 0f - velocity.Y), Main.rand.Next(435, 438));
						Main.gore[num3].velocity.X = Main.gore[num3].velocity.X * 0.1f - velocity.X * 0.1f;
						Main.gore[num3].velocity.Y = Main.gore[num3].velocity.Y * 0.1f - velocity.Y * 0.05f;
					}
					else
					{
						dJumpEffect = true;
						int num4 = height;
						if (gravDir == -1f)
						{
							num4 = 0;
						}
						Main.PlaySound(16, (int)position.X, (int)position.Y);
						velocity.Y = (0f - jumpSpeed) * gravDir;
						jump = (int)((double)jumpHeight * 0.75);
						for (int j = 0; j < 10; j++)
						{
							int num5 = Dust.NewDust(new Vector2(position.X - 34f, position.Y + (float)num4 - 16f), 102, 32, 16, (0f - velocity.X) * 0.5f, velocity.Y * 0.5f, 100, default(Color), 1.5f);
							Main.dust[num5].velocity.X = Main.dust[num5].velocity.X * 0.5f - velocity.X * 0.1f;
							Main.dust[num5].velocity.Y = Main.dust[num5].velocity.Y * 0.5f - velocity.Y * 0.3f;
						}
						int num6 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 16f, position.Y + (float)num4 - 16f), new Vector2(0f - velocity.X, 0f - velocity.Y), Main.rand.Next(11, 14));
						Main.gore[num6].velocity.X = Main.gore[num6].velocity.X * 0.1f - velocity.X * 0.1f;
						Main.gore[num6].velocity.Y = Main.gore[num6].velocity.Y * 0.1f - velocity.Y * 0.05f;
						num6 = Gore.NewGore(new Vector2(position.X - 36f, position.Y + (float)num4 - 16f), new Vector2(0f - velocity.X, 0f - velocity.Y), Main.rand.Next(11, 14));
						Main.gore[num6].velocity.X = Main.gore[num6].velocity.X * 0.1f - velocity.X * 0.1f;
						Main.gore[num6].velocity.Y = Main.gore[num6].velocity.Y * 0.1f - velocity.Y * 0.05f;
						num6 = Gore.NewGore(new Vector2(position.X + (float)width + 4f, position.Y + (float)num4 - 16f), new Vector2(0f - velocity.X, 0f - velocity.Y), Main.rand.Next(11, 14));
						Main.gore[num6].velocity.X = Main.gore[num6].velocity.X * 0.1f - velocity.X * 0.1f;
						Main.gore[num6].velocity.Y = Main.gore[num6].velocity.Y * 0.1f - velocity.Y * 0.05f;
					}
				}
				releaseJump = false;
			}
			else
			{
				jump = 0;
				releaseJump = true;
				rocketRelease = true;
			}
		}

		public void DashMovement()
		{
			if (dashDelay > 0)
			{
				dashDelay--;
			}
			else if (dashDelay < 0)
			{
				for (int i = 0; i < 2; i++)
				{
					int num = ((velocity.Y != 0f) ? Dust.NewDust(new Vector2(position.X, position.Y + (float)(height / 2) - 8f), width, 16, 31, 0f, 0f, 100, default(Color), 1.4f) : Dust.NewDust(new Vector2(position.X, position.Y + (float)height - 4f), width, 8, 31, 0f, 0f, 100, default(Color), 1.4f));
					Main.dust[num].velocity *= 0.1f;
					Main.dust[num].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
				}
				if (velocity.X > 13f || velocity.X < -13f)
				{
					velocity.X *= 0.99f;
					return;
				}
				if (velocity.X > accRunSpeed || velocity.X < 0f - accRunSpeed)
				{
					velocity.X *= 0.9f;
					return;
				}
				dashDelay = 20;
				if (velocity.X < 0f)
				{
					velocity.X = 0f - accRunSpeed;
				}
				else if (velocity.X > 0f)
				{
					velocity.X = accRunSpeed;
				}
			}
			else
			{
				if (dash <= 0 || mount.Active)
				{
					return;
				}
				int num2 = 0;
				bool flag = false;
				if (dashTime > 0)
				{
					dashTime--;
				}
				if (dashTime < 0)
				{
					dashTime++;
				}
				if (controlRight && releaseRight)
				{
					if (dashTime > 0)
					{
						num2 = 1;
						flag = true;
						dashTime = 0;
					}
					else
					{
						dashTime = 15;
					}
				}
				else if (controlLeft && releaseLeft)
				{
					if (dashTime < 0)
					{
						num2 = -1;
						flag = true;
						dashTime = 0;
					}
					else
					{
						dashTime = -15;
					}
				}
				if (flag)
				{
					velocity.X = 15.9f * (float)num2;
					dashDelay = -1;
					for (int j = 0; j < 20; j++)
					{
						int num3 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num3].position.X += Main.rand.Next(-5, 6);
						Main.dust[num3].position.Y += Main.rand.Next(-5, 6);
						Main.dust[num3].velocity *= 0.2f;
						Main.dust[num3].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
					}
					int num4 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 24f, position.Y + (float)(height / 2) - 34f), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num4].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[num4].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[num4].velocity *= 0.4f;
					num4 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 24f, position.Y + (float)(height / 2) - 14f), default(Vector2), Main.rand.Next(61, 64));
					Main.gore[num4].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[num4].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
					Main.gore[num4].velocity *= 0.4f;
				}
			}
		}

		public void WallslideMovement()
		{
			sliding = false;
			if (slideDir == 0 || spikedBoots <= 0 || mount.Active || ((!controlLeft || slideDir != -1) && (!controlRight || slideDir != 1)))
			{
				return;
			}
			bool flag = false;
			float num = position.X;
			if (slideDir == 1)
			{
				num += (float)width;
			}
			num += (float)slideDir;
			float num2 = position.Y + (float)height + 1f;
			if (gravDir < 0f)
			{
				num2 = position.Y - 1f;
			}
			num /= 16f;
			num2 /= 16f;
			if (WorldGen.SolidTile((int)num, (int)num2) && WorldGen.SolidTile((int)num, (int)num2 - 1))
			{
				flag = true;
			}
			if (spikedBoots >= 2)
			{
				if (!flag || ((!(velocity.Y > 0f) || gravDir != 1f) && (!(velocity.Y < gravity) || gravDir != -1f)))
				{
					return;
				}
				float num3 = gravity;
				if (slowFall)
				{
					num3 = ((!controlUp) ? (gravity / 3f * gravDir) : (gravity / 10f * gravDir));
				}
				fallStart = (int)(position.Y / 16f);
				if ((controlDown && gravDir == 1f) || (controlUp && gravDir == -1f))
				{
					velocity.Y = 4f * gravDir;
					int num4 = Dust.NewDust(new Vector2(position.X + (float)(width / 2) + (float)((width / 2 - 4) * slideDir), position.Y + (float)(height / 2) + (float)(height / 2 - 4) * gravDir), 8, 8, 31);
					if (slideDir < 0)
					{
						Main.dust[num4].position.X -= 10f;
					}
					if (gravDir < 0f)
					{
						Main.dust[num4].position.Y -= 12f;
					}
					Main.dust[num4].velocity *= 0.1f;
					Main.dust[num4].scale *= 1.2f;
					Main.dust[num4].noGravity = true;
				}
				else if (gravDir == -1f)
				{
					velocity.Y = (0f - num3 + 1E-05f) * gravDir;
				}
				else
				{
					velocity.Y = (0f - num3 + 1E-05f) * gravDir;
				}
				sliding = true;
			}
			else if ((flag && (double)velocity.Y > 0.5 && gravDir == 1f) || ((double)velocity.Y < -0.5 && gravDir == -1f))
			{
				fallStart = (int)(position.Y / 16f);
				if (controlDown)
				{
					velocity.Y = 4f * gravDir;
				}
				else
				{
					velocity.Y = 0.5f * gravDir;
				}
				sliding = true;
				int num5 = Dust.NewDust(new Vector2(position.X + (float)(width / 2) + (float)((width / 2 - 4) * slideDir), position.Y + (float)(height / 2) + (float)(height / 2 - 4) * gravDir), 8, 8, 31);
				if (slideDir < 0)
				{
					Main.dust[num5].position.X -= 10f;
				}
				if (gravDir < 0f)
				{
					Main.dust[num5].position.Y -= 12f;
				}
				Main.dust[num5].velocity *= 0.1f;
				Main.dust[num5].scale *= 1.2f;
				Main.dust[num5].noGravity = true;
			}
		}

		public void CarpetMovement()
		{
			bool flag = false;
			if (grappling[0] == -1 && carpet && !jumpAgain && !jumpAgain2 && !jumpAgain3 && !jumpAgain4 && jump == 0 && velocity.Y != 0f && rocketTime == 0 && wingTime == 0f && !mount.Active)
			{
				if (controlJump && canCarpet)
				{
					canCarpet = false;
					carpetTime = 300;
				}
				if (carpetTime > 0 && controlJump)
				{
					fallStart = (int)(position.Y / 16f);
					flag = true;
					carpetTime--;
					if (gravDir == 1f && velocity.Y > 0f - gravity)
					{
						velocity.Y = 0f - (gravity + 1E-06f);
					}
					else if (gravDir == -1f && velocity.Y < gravity)
					{
						velocity.Y = gravity + 1E-06f;
					}
					carpetFrameCounter += 1f + Math.Abs(velocity.X * 0.5f);
					if (carpetFrameCounter > 8f)
					{
						carpetFrameCounter = 0f;
						carpetFrame++;
					}
					if (carpetFrame < 0)
					{
						carpetFrame = 0;
					}
					if (carpetFrame > 5)
					{
						carpetFrame = 0;
					}
				}
			}
			if (!flag)
			{
				carpetFrame = -1;
			}
		}

		public void DoubleJumpVisuals()
		{
			if (dJumpEffect && doubleJump && !jumpAgain && (jumpAgain2 || !doubleJump2) && ((gravDir == 1f && velocity.Y < 0f) || (gravDir == -1f && velocity.Y > 0f)))
			{
				int num = height;
				if (gravDir == -1f)
				{
					num = -6;
				}
				int num2 = Dust.NewDust(new Vector2(position.X - 4f, position.Y + (float)num), width + 8, 4, 16, (0f - velocity.X) * 0.5f, velocity.Y * 0.5f, 100, default(Color), 1.5f);
				Main.dust[num2].velocity.X = Main.dust[num2].velocity.X * 0.5f - velocity.X * 0.1f;
				Main.dust[num2].velocity.Y = Main.dust[num2].velocity.Y * 0.5f - velocity.Y * 0.3f;
			}
			if (dJumpEffect2 && doubleJump2 && !jumpAgain2 && ((gravDir == 1f && velocity.Y < 0f) || (gravDir == -1f && velocity.Y > 0f)))
			{
				int num3 = height;
				if (gravDir == -1f)
				{
					num3 = -6;
				}
				float num4 = ((float)jump / 75f + 1f) / 2f;
				for (int i = 0; i < 3; i++)
				{
					int num5 = Dust.NewDust(new Vector2(position.X, position.Y + (float)(num3 / 2)), width, 32, 124, velocity.X * 0.3f, velocity.Y * 0.3f, 150, default(Color), 1f * num4);
					Main.dust[num5].velocity *= 0.5f * num4;
					Main.dust[num5].fadeIn = 1.5f * num4;
				}
				sandStorm = true;
				if (miscCounter % 3 == 0)
				{
					int num6 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 18f, position.Y + (float)(num3 / 2)), new Vector2(0f - velocity.X, 0f - velocity.Y), Main.rand.Next(220, 223), num4);
					Main.gore[num6].velocity = velocity * 0.3f * num4;
					Main.gore[num6].alpha = 100;
				}
			}
			if (dJumpEffect4 && doubleJump4 && !jumpAgain4 && ((gravDir == 1f && velocity.Y < 0f) || (gravDir == -1f && velocity.Y > 0f)))
			{
				int num7 = height;
				if (gravDir == -1f)
				{
					num7 = -6;
				}
				int num8 = Dust.NewDust(new Vector2(position.X - 4f, position.Y + (float)num7), width + 8, 4, 188, (0f - velocity.X) * 0.5f, velocity.Y * 0.5f, 100, default(Color), 1.5f);
				Main.dust[num8].velocity.X = Main.dust[num8].velocity.X * 0.5f - velocity.X * 0.1f;
				Main.dust[num8].velocity.Y = Main.dust[num8].velocity.Y * 0.5f - velocity.Y * 0.3f;
				Main.dust[num8].velocity *= 0.5f;
			}
			if (!dJumpEffect3 || !doubleJump3 || jumpAgain3 || ((gravDir != 1f || !(velocity.Y < 0f)) && (gravDir != -1f || !(velocity.Y > 0f))))
			{
				return;
			}
			int num9 = height - 6;
			if (gravDir == -1f)
			{
				num9 = 6;
			}
			for (int j = 0; j < 2; j++)
			{
				int num10 = Dust.NewDust(new Vector2(position.X, position.Y + (float)num9), width, 12, 76, velocity.X * 0.3f, velocity.Y * 0.3f);
				Main.dust[num10].velocity *= 0.1f;
				if (j == 0)
				{
					Main.dust[num10].velocity += velocity * 0.03f;
				}
				else
				{
					Main.dust[num10].velocity -= velocity * 0.03f;
				}
				Main.dust[num10].noLight = true;
			}
			for (int k = 0; k < 3; k++)
			{
				int num11 = Dust.NewDust(new Vector2(position.X, position.Y + (float)num9), width, 12, 76, velocity.X * 0.3f, velocity.Y * 0.3f);
				Main.dust[num11].fadeIn = 1.5f;
				Main.dust[num11].velocity *= 0.6f;
				Main.dust[num11].velocity += velocity * 0.8f;
				Main.dust[num11].noGravity = true;
				Main.dust[num11].noLight = true;
			}
			for (int l = 0; l < 3; l++)
			{
				int num12 = Dust.NewDust(new Vector2(position.X, position.Y + (float)num9), width, 12, 76, velocity.X * 0.3f, velocity.Y * 0.3f);
				Main.dust[num12].fadeIn = 1.5f;
				Main.dust[num12].velocity *= 0.6f;
				Main.dust[num12].velocity -= velocity * 0.8f;
				Main.dust[num12].noGravity = true;
				Main.dust[num12].noLight = true;
			}
		}

		public void WingMovement()
		{
			if (wingsLogic == 4 && controlUp)
			{
				velocity.Y -= 0.2f * gravDir;
				if (gravDir == 1f)
				{
					if (velocity.Y > 0f)
					{
						velocity.Y -= 1f;
					}
					else if (velocity.Y > 0f - jumpSpeed)
					{
						velocity.Y -= 0.2f;
					}
					if (velocity.Y < (0f - jumpSpeed) * 3f)
					{
						velocity.Y = (0f - jumpSpeed) * 3f;
					}
				}
				else
				{
					if (velocity.Y < 0f)
					{
						velocity.Y += 1f;
					}
					else if (velocity.Y < jumpSpeed)
					{
						velocity.Y += 0.2f;
					}
					if (velocity.Y > jumpSpeed * 3f)
					{
						velocity.Y = jumpSpeed * 3f;
					}
				}
				wingTime -= 2f;
				return;
			}
			if (wingsLogic == 3 && controlUp)
			{
				velocity.Y -= 0.3f * gravDir;
				if (gravDir == 1f)
				{
					if (velocity.Y > 0f)
					{
						velocity.Y -= 1f;
					}
					else if (velocity.Y > 0f - jumpSpeed)
					{
						velocity.Y -= 0.2f;
					}
					if (velocity.Y < (0f - jumpSpeed) * 3f)
					{
						velocity.Y = (0f - jumpSpeed) * 3f;
					}
				}
				else
				{
					if (velocity.Y < 0f)
					{
						velocity.Y += 1f;
					}
					else if (velocity.Y < jumpSpeed)
					{
						velocity.Y += 0.2f;
					}
					if (velocity.Y > jumpSpeed * 3f)
					{
						velocity.Y = jumpSpeed * 3f;
					}
				}
				wingTime -= 2f;
				return;
			}
			if (wingsLogic == 26)
			{
				velocity.Y -= 0.125f * gravDir;
				if (gravDir == 1f)
				{
					if (velocity.Y > 0f)
					{
						velocity.Y -= 0.75f;
					}
					else if (velocity.Y > 0f - jumpSpeed)
					{
						velocity.Y -= 0.15f;
					}
					if (velocity.Y < (0f - jumpSpeed) * 3f)
					{
						velocity.Y = (0f - jumpSpeed) * 2f;
					}
				}
				else
				{
					if (velocity.Y < 0f)
					{
						velocity.Y += 0.75f;
					}
					else if (velocity.Y < jumpSpeed)
					{
						velocity.Y += 0.15f;
					}
					if (velocity.Y > jumpSpeed * 3f)
					{
						velocity.Y = jumpSpeed * 2f;
					}
				}
				wingTime -= 1f;
				return;
			}
			velocity.Y -= 0.1f * gravDir;
			if (gravDir == 1f)
			{
				if (velocity.Y > 0f)
				{
					velocity.Y -= 0.5f;
				}
				else if ((double)velocity.Y > (double)(0f - jumpSpeed) * 0.5)
				{
					velocity.Y -= 0.1f;
				}
				if (velocity.Y < (0f - jumpSpeed) * 1.5f)
				{
					velocity.Y = (0f - jumpSpeed) * 1.5f;
				}
			}
			else
			{
				if (velocity.Y < 0f)
				{
					velocity.Y += 0.5f;
				}
				else if ((double)velocity.Y < (double)jumpSpeed * 0.5)
				{
					velocity.Y += 0.1f;
				}
				if (velocity.Y > jumpSpeed * 1.5f)
				{
					velocity.Y = jumpSpeed * 1.5f;
				}
			}
			if (wingsLogic == 22 && controlDown && !controlLeft && !controlRight)
			{
				wingTime -= 0.5f;
			}
			else
			{
				wingTime -= 1f;
			}
		}

		public void WOFTongue()
		{
			if (Main.wof < 0 || !Main.npc[Main.wof].active)
			{
				return;
			}
			float num = Main.npc[Main.wof].position.X + 40f;
			if (Main.npc[Main.wof].direction > 0)
			{
				num -= 96f;
			}
			if (position.X + (float)width > num && position.X < num + 140f && gross)
			{
				noKnockback = false;
				Hurt(50, Main.npc[Main.wof].direction);
			}
			if (!gross && position.Y > (float)((Main.maxTilesY - 250) * 16) && position.X > num - 1920f && position.X < num + 1920f)
			{
				AddBuff(37, 10);
				Main.PlaySound(4, (int)Main.npc[Main.wof].position.X, (int)Main.npc[Main.wof].position.Y, 10);
			}
			if (gross)
			{
				if (position.Y < (float)((Main.maxTilesY - 200) * 16))
				{
					AddBuff(38, 10);
				}
				if (Main.npc[Main.wof].direction < 0)
				{
					if (position.X + (float)(width / 2) > Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) + 40f)
					{
						AddBuff(38, 10);
					}
				}
				else if (position.X + (float)(width / 2) < Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - 40f)
				{
					AddBuff(38, 10);
				}
			}
			if (!tongued)
			{
				return;
			}
			controlHook = false;
			controlUseItem = false;
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].aiStyle == 7)
				{
					Main.projectile[i].Kill();
				}
			}
			Vector2 vector = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
			float num2 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - vector.X;
			float num3 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2) - vector.Y;
			float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
			if (num4 > 3000f)
			{
				KillMe(1000.0, 0, false, " tried to escape.");
			}
			else if (Main.npc[Main.wof].position.X < 608f || Main.npc[Main.wof].position.X > (float)((Main.maxTilesX - 38) * 16))
			{
				KillMe(1000.0, 0, false, " was licked.");
			}
		}

		public void StatusPlayer(NPC npc)
		{
			if (npc.type >= 269 && npc.type <= 272)
			{
				if (Main.rand.Next(3) == 0)
				{
					AddBuff(30, 600);
				}
				else if (Main.rand.Next(3) == 0)
				{
					AddBuff(32, 300);
				}
			}
			if (npc.type >= 273 && npc.type <= 276 && Main.rand.Next(2) == 0)
			{
				AddBuff(36, 600);
			}
			if (npc.type >= 277 && npc.type <= 280)
			{
				AddBuff(24, 600);
			}
			if (((npc.type == 1 && npc.name == "Black Slime") || npc.type == 81 || npc.type == 79) && Main.rand.Next(4) == 0)
			{
				AddBuff(22, 900);
			}
			if ((npc.type == 23 || npc.type == 25) && Main.rand.Next(3) == 0)
			{
				AddBuff(24, 420);
			}
			if ((npc.type == 34 || npc.type == 83 || npc.type == 84) && Main.rand.Next(3) == 0)
			{
				AddBuff(23, 240);
			}
			if ((npc.type == 104 || npc.type == 102) && Main.rand.Next(8) == 0)
			{
				AddBuff(30, 2700);
			}
			if (npc.type == 75 && Main.rand.Next(10) == 0)
			{
				AddBuff(35, 420);
			}
			if ((npc.type == 163 || npc.type == 238) && Main.rand.Next(10) == 0)
			{
				AddBuff(70, 480);
			}
			if ((npc.type == 79 || npc.type == 103) && Main.rand.Next(5) == 0)
			{
				AddBuff(35, 420);
			}
			if ((npc.type == 75 || npc.type == 78 || npc.type == 82) && Main.rand.Next(8) == 0)
			{
				AddBuff(32, 900);
			}
			if ((npc.type == 93 || npc.type == 109 || npc.type == 80) && Main.rand.Next(14) == 0)
			{
				AddBuff(31, 300);
			}
			if (npc.type >= 305 && npc.type <= 314 && Main.rand.Next(10) == 0)
			{
				AddBuff(33, 3600);
			}
			if (npc.type == 77 && Main.rand.Next(6) == 0)
			{
				AddBuff(36, 18000);
			}
			if (npc.type == 112 && Main.rand.Next(20) == 0)
			{
				AddBuff(33, 18000);
			}
			if (npc.type == 182 && Main.rand.Next(25) == 0)
			{
				AddBuff(33, 7200);
			}
			if (npc.type == 141 && Main.rand.Next(2) == 0)
			{
				AddBuff(20, 600);
			}
			if (npc.type == 147 && !frozen && Main.rand.Next(12) == 0)
			{
				AddBuff(46, 600);
			}
			if (npc.type == 150)
			{
				if (Main.rand.Next(2) == 0)
				{
					AddBuff(46, 900);
				}
				if (!frozen && Main.rand.Next(35) == 0)
				{
					AddBuff(47, 60);
				}
			}
			if (npc.type == 184)
			{
				AddBuff(46, 1200);
				if (!frozen && Main.rand.Next(15) == 0)
				{
					AddBuff(47, 60);
				}
			}
		}

		public void GrappleMovement()
		{
			if (grappling[0] < 0)
			{
				return;
			}
			if (Main.myPlayer == whoAmi && mount.Active)
			{
				mount.Dismount(this);
			}
			canCarpet = true;
			carpetFrame = -1;
			wingFrame = 1;
			if (velocity.Y == 0f || (wet && (double)velocity.Y > -0.02 && (double)velocity.Y < 0.02))
			{
				wingFrame = 0;
			}
			if (wings == 4)
			{
				wingFrame = 3;
			}
			wingTime = wingTimeMax;
			rocketTime = rocketTimeMax;
			rocketDelay = 0;
			rocketFrame = false;
			canRocket = false;
			rocketRelease = false;
			fallStart = (int)(position.Y / 16f);
			int num = -1;
			float num2 = 0f;
			float num3 = 0f;
			for (int i = 0; i < grapCount; i++)
			{
				if (Main.projectile[grappling[i]].type == 403)
				{
					num = i;
				}
				num2 += Main.projectile[grappling[i]].position.X + (float)(Main.projectile[grappling[i]].width / 2);
				num3 += Main.projectile[grappling[i]].position.Y + (float)(Main.projectile[grappling[i]].height / 2);
			}
			num2 /= (float)grapCount;
			num3 /= (float)grapCount;
			Vector2 vector = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
			float num4 = num2 - vector.X;
			float num5 = num3 - vector.Y;
			float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
			float num7 = 11f;
			if (Main.projectile[grappling[0]].type == 315)
			{
				num7 = 16f;
			}
			float num8 = num6;
			num8 = ((!(num6 > num7)) ? 1f : (num7 / num6));
			num4 *= num8;
			num5 *= num8;
			velocity.X = num4;
			velocity.Y = num5;
			if (num != -1)
			{
				Projectile projectile = Main.projectile[grappling[num]];
				if (projectile.position.X < position.X + (float)width && projectile.position.X + (float)projectile.width >= position.X && projectile.position.Y < position.Y + (float)height && projectile.position.Y + (float)projectile.height >= position.Y)
				{
					int num9 = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
					int num10 = (int)(projectile.position.Y + (float)(projectile.height / 2)) / 16;
					velocity = Vector2.Zero;
					if (Main.tile[num9, num10].type == 314)
					{
						Vector2 Position = default(Vector2);
						Position.X = projectile.position.X + (float)(projectile.width / 2) - (float)(width / 2);
						Position.Y = projectile.position.Y + (float)(projectile.height / 2) - (float)(height / 2);
						grappling[0] = -1;
						grapCount = 0;
						for (int j = 0; j < 1000; j++)
						{
							if (Main.projectile[j].active && Main.projectile[j].owner == whoAmi && Main.projectile[j].aiStyle == 7)
							{
								Main.projectile[j].Kill();
							}
						}
						int num11 = height + Mount.GetHeightBoost(6);
						if (Minecart.GetOnTrack(num9, num10, ref Position, width, num11) && !Collision.SolidCollision(Position, width, num11 - 20))
						{
							position = Position;
							mount.SetMount(6, this, minecartLeft);
							Minecart.WheelSparks(position, width, height, 25);
						}
					}
				}
			}
			if (itemAnimation == 0)
			{
				if (velocity.X > 0f)
				{
					ChangeDir(1);
				}
				if (velocity.X < 0f)
				{
					ChangeDir(-1);
				}
			}
			if (controlJump)
			{
				if (!releaseJump)
				{
					return;
				}
				if ((velocity.Y == 0f || (wet && (double)velocity.Y > -0.02 && (double)velocity.Y < 0.02)) && !controlDown)
				{
					velocity.Y = 0f - jumpSpeed;
					jump = jumpHeight / 2;
					releaseJump = false;
				}
				else
				{
					velocity.Y += 0.01f;
					releaseJump = false;
				}
				if (doubleJump)
				{
					jumpAgain = true;
				}
				if (doubleJump2)
				{
					jumpAgain2 = true;
				}
				if (doubleJump3)
				{
					jumpAgain3 = true;
				}
				if (doubleJump4)
				{
					jumpAgain4 = true;
				}
				grappling[0] = 0;
				grapCount = 0;
				for (int k = 0; k < 1000; k++)
				{
					if (Main.projectile[k].active && Main.projectile[k].owner == whoAmi && Main.projectile[k].aiStyle == 7)
					{
						Main.projectile[k].Kill();
					}
				}
			}
			else
			{
				releaseJump = true;
			}
		}

		public void StickyMovement()
		{
			bool flag = false;
			if (mount.Type == 6 && Math.Abs(velocity.X) > 5f)
			{
				flag = true;
			}
			int num = width / 2;
			int num2 = height / 2;
			new Vector2(position.X + (float)(width / 2) - (float)(num / 2), position.Y + (float)(height / 2) - (float)(num2 / 2));
			Vector2 vector = Collision.StickyTiles(position, velocity, width, height);
			if (vector.Y != -1f && vector.X != -1f)
			{
				int num3 = (int)vector.X;
				int num4 = (int)vector.Y;
				int type = Main.tile[num3, num4].type;
				if (whoAmi == Main.myPlayer && type == 51 && (velocity.X != 0f || velocity.Y != 0f))
				{
					stickyBreak++;
					if (stickyBreak > Main.rand.Next(20, 100) || flag)
					{
						stickyBreak = 0;
						WorldGen.KillTile(num3, num4);
						if (Main.netMode == 1 && !Main.tile[num3, num4].active() && Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, num3, num4);
						}
					}
				}
				if (flag)
				{
					return;
				}
				fallStart = (int)(position.Y / 16f);
				if (type != 229)
				{
					jump = 0;
				}
				if (velocity.X > 1f)
				{
					velocity.X = 1f;
				}
				if (velocity.X < -1f)
				{
					velocity.X = -1f;
				}
				if (velocity.Y > 1f)
				{
					velocity.Y = 1f;
				}
				if (velocity.Y < -5f)
				{
					velocity.Y = -5f;
				}
				if ((double)velocity.X > 0.75 || (double)velocity.X < -0.75)
				{
					velocity.X *= 0.85f;
				}
				else
				{
					velocity.X *= 0.6f;
				}
				if (velocity.Y < 0f)
				{
					velocity.Y *= 0.96f;
				}
				else
				{
					velocity.Y *= 0.3f;
				}
				if (type != 229 || Main.rand.Next(5) != 0 || (!((double)velocity.Y > 0.15) && !(velocity.Y < 0f)))
				{
					return;
				}
				if ((float)(num3 * 16) < position.X + (float)(width / 2))
				{
					int num5 = Dust.NewDust(new Vector2(position.X - 4f, num4 * 16), 4, 16, 153, 0f, 0f, 50);
					Main.dust[num5].scale += (float)Main.rand.Next(0, 6) * 0.1f;
					Main.dust[num5].velocity *= 0.1f;
					Main.dust[num5].noGravity = true;
				}
				else
				{
					int num6 = Dust.NewDust(new Vector2(position.X + (float)width - 2f, num4 * 16), 4, 16, 153, 0f, 0f, 50);
					Main.dust[num6].scale += (float)Main.rand.Next(0, 6) * 0.1f;
					Main.dust[num6].velocity *= 0.1f;
					Main.dust[num6].noGravity = true;
				}
				if (Main.tile[num3, num4 + 1] != null && Main.tile[num3, num4 + 1].type == 229 && position.Y + (float)height > (float)((num4 + 1) * 16))
				{
					if ((float)(num3 * 16) < position.X + (float)(width / 2))
					{
						int num7 = Dust.NewDust(new Vector2(position.X - 4f, num4 * 16 + 16), 4, 16, 153, 0f, 0f, 50);
						Main.dust[num7].scale += (float)Main.rand.Next(0, 6) * 0.1f;
						Main.dust[num7].velocity *= 0.1f;
						Main.dust[num7].noGravity = true;
					}
					else
					{
						int num8 = Dust.NewDust(new Vector2(position.X + (float)width - 2f, num4 * 16 + 16), 4, 16, 153, 0f, 0f, 50);
						Main.dust[num8].scale += (float)Main.rand.Next(0, 6) * 0.1f;
						Main.dust[num8].velocity *= 0.1f;
						Main.dust[num8].noGravity = true;
					}
				}
				if (Main.tile[num3, num4 + 2] != null && Main.tile[num3, num4 + 2].type == 229 && position.Y + (float)height > (float)((num4 + 2) * 16))
				{
					if ((float)(num3 * 16) < position.X + (float)(width / 2))
					{
						int num9 = Dust.NewDust(new Vector2(position.X - 4f, num4 * 16 + 32), 4, 16, 153, 0f, 0f, 50);
						Main.dust[num9].scale += (float)Main.rand.Next(0, 6) * 0.1f;
						Main.dust[num9].velocity *= 0.1f;
						Main.dust[num9].noGravity = true;
					}
					else
					{
						int num10 = Dust.NewDust(new Vector2(position.X + (float)width - 2f, num4 * 16 + 32), 4, 16, 153, 0f, 0f, 50);
						Main.dust[num10].scale += (float)Main.rand.Next(0, 6) * 0.1f;
						Main.dust[num10].velocity *= 0.1f;
						Main.dust[num10].noGravity = true;
					}
				}
			}
			else
			{
				stickyBreak = 0;
			}
		}

		public void CheckDrowning()
		{
			bool flag = Collision.DrownCollision(position, width, height, gravDir);
			if (armor[0].type == 250)
			{
				flag = true;
			}
			if (inventory[selectedItem].type == 186)
			{
				try
				{
					int num = (int)((position.X + (float)(width / 2) + (float)(6 * direction)) / 16f);
					int num2 = 0;
					if (gravDir == -1f)
					{
						num2 = height;
					}
					int num3 = (int)((position.Y + (float)num2 - 44f * gravDir) / 16f);
					if (Main.tile[num, num3].liquid < 128)
					{
						if (Main.tile[num, num3] == null)
						{
							Main.tile[num, num3] = new Tile();
						}
						if (!Main.tile[num, num3].active() || !Main.tileSolid[Main.tile[num, num3].type] || Main.tileSolidTop[Main.tile[num, num3].type])
						{
							flag = false;
						}
					}
				}
				catch
				{
				}
			}
			if (gills)
			{
				flag = false;
			}
			if (Main.myPlayer == whoAmi)
			{
				if (merman)
				{
					flag = false;
				}
				if (flag)
				{
					breathCD++;
					int num4 = 7;
					if (inventory[selectedItem].type == 186)
					{
						num4 *= 2;
					}
					if (accDivingHelm)
					{
						num4 *= 4;
					}
					if (breathCD >= num4)
					{
						breathCD = 0;
						breath--;
						if (breath == 0)
						{
							Main.PlaySound(23);
						}
						if (breath <= 0)
						{
							lifeRegenTime = 0;
							breath = 0;
							statLife -= 2;
							if (statLife <= 0)
							{
								statLife = 0;
								KillMe(10.0, 0, false, Lang.deathMsg(-1, -1, -1, 1));
							}
						}
					}
				}
				else
				{
					breath += 3;
					if (breath > breathMax)
					{
						breath = breathMax;
					}
					breathCD = 0;
				}
			}
			if (flag && Main.rand.Next(20) == 0 && !lavaWet && !honeyWet)
			{
				int num5 = 0;
				if (gravDir == -1f)
				{
					num5 += height - 12;
				}
				if (inventory[selectedItem].type == 186)
				{
					Dust.NewDust(new Vector2(position.X + (float)(10 * direction) + 4f, position.Y + (float)num5 - 54f * gravDir), width - 8, 8, 34, 0f, 0f, 0, default(Color), 1.2f);
				}
				else
				{
					Dust.NewDust(new Vector2(position.X + (float)(12 * direction), position.Y + (float)num5 + 4f * gravDir), width - 8, 8, 34, 0f, 0f, 0, default(Color), 1.2f);
				}
			}
		}

		public void CheckIceBreak()
		{
			if (!(velocity.Y > 7f))
			{
				return;
			}
			Vector2 vector = position + velocity;
			int num = (int)(vector.X / 16f);
			int num2 = (int)((vector.X + (float)width) / 16f);
			int num3 = (int)((position.Y + (float)height + 1f) / 16f);
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num3 + 1; j++)
				{
					if (Main.tile[i, j].nactive() && Main.tile[i, j].type == 162)
					{
						WorldGen.KillTile(i, j);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, i, j);
						}
					}
				}
			}
		}

		public void SlopeDownMovement()
		{
			sloping = false;
			float y = velocity.Y;
			Vector4 vector = Collision.WalkDownSlope(position, velocity, width, height, gravity * gravDir);
			position.X = vector.X;
			position.Y = vector.Y;
			velocity.X = vector.Z;
			velocity.Y = vector.W;
			if (velocity.Y != y)
			{
				sloping = true;
			}
		}

		public void HoneyCollision(bool fallThrough, bool ignorePlats)
		{
			int num = ((!onTrack) ? height : (height - 20));
			Vector2 vector = velocity;
			velocity = Collision.TileCollision(position, velocity, width, num, fallThrough, ignorePlats, (int)gravDir);
			Vector2 vector2 = velocity * 0.25f;
			if (velocity.X != vector.X)
			{
				vector2.X = velocity.X;
			}
			if (velocity.Y != vector.Y)
			{
				vector2.Y = velocity.Y;
			}
			position += vector2;
		}

		public void WaterCollision(bool fallThrough, bool ignorePlats)
		{
			int num = ((!onTrack) ? height : (height - 20));
			Vector2 vector = velocity;
			velocity = Collision.TileCollision(position, velocity, width, num, fallThrough, ignorePlats, (int)gravDir);
			Vector2 vector2 = velocity * 0.5f;
			if (velocity.X != vector.X)
			{
				vector2.X = velocity.X;
			}
			if (velocity.Y != vector.Y)
			{
				vector2.Y = velocity.Y;
			}
			position += vector2;
		}

		public void DryCollision(bool fallThrough, bool ignorePlats)
		{
			velocity = Collision.TileCollision(Height: (!onTrack) ? height : (height - 10), Position: position, Velocity: velocity, Width: width, fallThrough: fallThrough, fall2: ignorePlats, gravDir: (int)gravDir);
			if (Collision.up && gravDir == 1f)
			{
				jump = 0;
			}
			if (waterWalk || waterWalk2)
			{
				Vector2 vector = velocity;
				velocity = Collision.WaterCollision(position, velocity, width, height, controlDown, false, waterWalk);
				if (vector != velocity)
				{
					fallStart = (int)(position.Y / 16f);
				}
			}
			position += velocity;
		}

		public void SlopingCollision()
		{
			if (controlDown || grappling[0] >= 0 || gravDir == -1f)
			{
				stairFall = true;
			}
			Vector4 vector = Collision.SlopeCollision(position, velocity, width, height, gravity, stairFall);
			if (Collision.stairFall)
			{
				stairFall = true;
			}
			else if (!controlDown)
			{
				stairFall = false;
			}
			if (Collision.stair && Math.Abs(vector.Y - position.Y) > 8f + Math.Abs(velocity.X))
			{
				gfxOffY -= vector.Y - position.Y;
				stepSpeed = 4f;
			}
			position.X = vector.X;
			position.Y = vector.Y;
			velocity.X = vector.Z;
			velocity.Y = vector.W;
			if (gravDir == -1f && velocity.Y == 0.0101f)
			{
				velocity.Y = 0f;
			}
		}

		public void FloorVisuals(bool Falling)
		{
			int num = (int)((position.X + (float)(width / 2)) / 16f);
			int num2 = (int)((position.Y + (float)height) / 16f);
			int num3 = -1;
			if (Main.tile[num - 1, num2] == null)
			{
				Main.tile[num - 1, num2] = new Tile();
			}
			if (Main.tile[num + 1, num2] == null)
			{
				Main.tile[num + 1, num2] = new Tile();
			}
			if (Main.tile[num, num2] == null)
			{
				Main.tile[num, num2] = new Tile();
			}
			if (Main.tile[num, num2].nactive() && Main.tileSolid[Main.tile[num, num2].type])
			{
				num3 = Main.tile[num, num2].type;
			}
			else if (Main.tile[num - 1, num2].nactive() && Main.tileSolid[Main.tile[num - 1, num2].type])
			{
				num3 = Main.tile[num - 1, num2].type;
			}
			else if (Main.tile[num + 1, num2].nactive() && Main.tileSolid[Main.tile[num + 1, num2].type])
			{
				num3 = Main.tile[num + 1, num2].type;
			}
			if (num3 <= -1)
			{
				return;
			}
			if (num3 == 229)
			{
				sticky = true;
			}
			else
			{
				sticky = false;
			}
			if (num3 == 161 || num3 == 162 || num3 == 163 || num3 == 164 || num3 == 200)
			{
				slippy = true;
			}
			else
			{
				slippy = false;
			}
			if (num3 == 197)
			{
				slippy2 = true;
			}
			else
			{
				slippy2 = false;
			}
			if (num3 == 198)
			{
				powerrun = true;
			}
			else
			{
				powerrun = false;
			}
			if (Main.tile[num - 1, num2].slope() != 0 || Main.tile[num, num2].slope() != 0 || Main.tile[num + 1, num2].slope() != 0)
			{
				num3 = -1;
			}
			if (wet || mount.Type == 6 || (num3 != 147 && num3 != 25 && num3 != 53 && num3 != 189 && num3 != 0 && num3 != 123 && num3 != 57 && num3 != 112 && num3 != 116 && num3 != 196 && num3 != 193 && num3 != 195 && num3 != 197 && num3 != 199 && num3 != 229))
			{
				return;
			}
			int num4 = 1;
			if (Falling)
			{
				num4 = 20;
			}
			for (int i = 0; i < num4; i++)
			{
				bool flag = true;
				int num5 = 76;
				if (num3 == 53)
				{
					num5 = 32;
				}
				if (num3 == 189)
				{
					num5 = 16;
				}
				if (num3 == 0)
				{
					num5 = 0;
				}
				if (num3 == 123)
				{
					num5 = 53;
				}
				if (num3 == 57)
				{
					num5 = 36;
				}
				if (num3 == 112)
				{
					num5 = 14;
				}
				if (num3 == 116)
				{
					num5 = 51;
				}
				if (num3 == 196)
				{
					num5 = 108;
				}
				if (num3 == 193)
				{
					num5 = 4;
				}
				if (num3 == 195 || num3 == 199)
				{
					num5 = 5;
				}
				if (num3 == 197)
				{
					num5 = 4;
				}
				if (num3 == 229)
				{
					num5 = 153;
				}
				if (num3 == 25)
				{
					num5 = 37;
				}
				if (num5 == 32 && Main.rand.Next(2) == 0)
				{
					flag = false;
				}
				if (num5 == 14 && Main.rand.Next(2) == 0)
				{
					flag = false;
				}
				if (num5 == 51 && Main.rand.Next(2) == 0)
				{
					flag = false;
				}
				if (num5 == 36 && Main.rand.Next(2) == 0)
				{
					flag = false;
				}
				if (num5 == 0 && Main.rand.Next(3) != 0)
				{
					flag = false;
				}
				if (num5 == 53 && Main.rand.Next(3) != 0)
				{
					flag = false;
				}
				Color newColor = default(Color);
				if (num3 == 193)
				{
					newColor = new Color(30, 100, 255, 100);
				}
				if (num3 == 197)
				{
					newColor = new Color(97, 200, 255, 100);
				}
				if (!Falling)
				{
					float num6 = Math.Abs(velocity.X) / 3f;
					if ((float)Main.rand.Next(100) > num6 * 100f)
					{
						flag = false;
					}
				}
				if (!flag)
				{
					continue;
				}
				float num7 = velocity.X;
				if (num7 > 6f)
				{
					num7 = 6f;
				}
				if (num7 < -6f)
				{
					num7 = -6f;
				}
				if (velocity.X == 0f && !Falling)
				{
					continue;
				}
				int num8 = Dust.NewDust(new Vector2(position.X, position.Y + (float)height - 2f), width, 6, num5, 0f, 0f, 50, newColor);
				if (num5 == 76)
				{
					Main.dust[num8].scale += (float)Main.rand.Next(3) * 0.1f;
					Main.dust[num8].noLight = true;
				}
				if (num5 == 16 || num5 == 108 || num5 == 153)
				{
					Main.dust[num8].scale += (float)Main.rand.Next(6) * 0.1f;
				}
				if (num5 == 37)
				{
					Main.dust[num8].scale += 0.25f;
					Main.dust[num8].alpha = 50;
				}
				if (num5 == 5)
				{
					Main.dust[num8].scale += (float)Main.rand.Next(2, 8) * 0.1f;
				}
				Main.dust[num8].noGravity = true;
				if (num4 > 1)
				{
					Main.dust[num8].velocity.X *= 1.2f;
					Main.dust[num8].velocity.Y *= 0.8f;
					Main.dust[num8].velocity.Y -= 1f;
					Main.dust[num8].velocity *= 0.8f;
					Main.dust[num8].scale += (float)Main.rand.Next(3) * 0.1f;
					Main.dust[num8].velocity.X = (Main.dust[num8].position.X - (position.X + (float)(width / 2))) * 0.2f;
					if (Main.dust[num8].velocity.Y > 0f)
					{
						Main.dust[num8].velocity.Y *= -1f;
					}
					Main.dust[num8].velocity.X += num7 * 0.3f;
				}
				else
				{
					Main.dust[num8].velocity *= 0.2f;
				}
				Main.dust[num8].position.X -= num7 * 1f;
			}
		}

		public void BordersMovement()
		{
			if (position.X < Main.leftWorld + 640f + 16f)
			{
				position.X = Main.leftWorld + 640f + 16f;
				velocity.X = 0f;
			}
			if (position.X + (float)width > Main.rightWorld - 640f - 32f)
			{
				position.X = Main.rightWorld - 640f - 32f - (float)width;
				velocity.X = 0f;
			}
			if (position.Y < Main.topWorld + 640f + 16f)
			{
				position.Y = Main.topWorld + 640f + 16f;
				if ((double)velocity.Y < 0.11)
				{
					velocity.Y = 0.11f;
				}
				gravDir = 1f;
			}
			if (position.Y > Main.bottomWorld - 640f - 32f - (float)height)
			{
				position.Y = Main.bottomWorld - 640f - 32f - (float)height;
				velocity.Y = 0f;
			}
		}

		public void UpdatePlayer(int i)
		{
			if (launcherWait > 0)
			{
				launcherWait--;
			}
			maxFallSpeed = 10f;
			gravity = defaultGravity;
			jumpHeight = 15;
			jumpSpeed = 5.01f;
			maxRunSpeed = 3f;
			runAcceleration = 0.08f;
			runSlowdown = 0.2f;
			accRunSpeed = maxRunSpeed;
			if (!mount.Active || mount.Type != 6)
			{
				onWrongGround = false;
			}
			heldProj = -1;
			if (wet)
			{
				if (honeyWet)
				{
					gravity = 0.1f;
					maxFallSpeed = 3f;
				}
				else if (merman)
				{
					gravity = 0.3f;
					maxFallSpeed = 7f;
				}
				else
				{
					gravity = 0.2f;
					maxFallSpeed = 5f;
					jumpHeight = 30;
					jumpSpeed = 6.01f;
				}
			}
			maxFallSpeed += 0.01f;
			bool flag = false;
			if (active)
			{
				if (ghostDmg > 0f)
				{
					ghostDmg -= 2.5f;
				}
				if (ghostDmg < 0f)
				{
					ghostDmg = 0f;
				}
				if (lifeSteal < 80f)
				{
					lifeSteal += 0.6f;
				}
				if (lifeSteal > 80f)
				{
					lifeSteal = 80f;
				}
				if (mount.Active)
				{
					position.Y += height;
					height = 42 + mount.HeightBoost;
					position.Y -= height;
					if (mount.Type == 0)
					{
						int num = (int)(position.X + (float)(width / 2)) / 16;
						int j = (int)(position.Y + (float)(height / 2) - 14f) / 16;
						Lighting.addLight(num, j, 0.5f, 0.2f, 0.05f);
						Lighting.addLight(num + direction, j, 0.5f, 0.2f, 0.05f);
						Lighting.addLight(num + direction * 2, j, 0.5f, 0.2f, 0.05f);
					}
				}
				else
				{
					position.Y += height;
					height = 42;
					position.Y -= height;
				}
				Main.numPlayers++;
				outOfRange = false;
				if (whoAmi != Main.myPlayer)
				{
					int num2 = (int)(position.X + (float)(width / 2)) / 16;
					int num3 = (int)(position.Y + (float)(height / 2)) / 16;
					if (Main.tile[num2, num3] == null)
					{
						flag = true;
					}
					else if (Main.tile[num2 - 3, num3] == null)
					{
						flag = true;
					}
					else if (Main.tile[num2 + 3, num3] == null)
					{
						flag = true;
					}
					else if (Main.tile[num2, num3 - 3] == null)
					{
						flag = true;
					}
					else if (Main.tile[num2, num3 + 3] == null)
					{
						flag = true;
					}
					if (flag)
					{
						outOfRange = true;
						numMinions = 0;
						slotsMinions = 0f;
						itemAnimation = 0;
						PlayerFrame();
					}
				}
			}
			if (!active || flag)
			{
				return;
			}
			miscCounter++;
			if (miscCounter >= 300)
			{
				miscCounter = 0;
			}
			infernoCounter++;
			if (infernoCounter >= 180)
			{
				infernoCounter = 0;
			}
			float num4 = Main.maxTilesX / 4200;
			num4 *= num4;
			float num5 = (float)((double)(position.Y / 16f - (60f + 10f * num4)) / (Main.worldSurface / 6.0));
			if ((double)num5 < 0.25)
			{
				num5 = 0.25f;
			}
			if (num5 > 1f)
			{
				num5 = 1f;
			}
			gravity *= num5;
			maxRegenDelay = (1f - (float)statMana / (float)statManaMax2) * 60f * 4f + 45f;
			maxRegenDelay *= 0.7f;
			UpdateSocialShadow();
			UpdateTeleportVisuals();
			whoAmi = i;
			if (runSoundDelay > 0)
			{
				runSoundDelay--;
			}
			if (attackCD > 0)
			{
				attackCD--;
			}
			if (itemAnimation == 0)
			{
				attackCD = 0;
			}
			if (chatShowTime > 0)
			{
				chatShowTime--;
			}
			if (potionDelay > 0)
			{
				potionDelay--;
			}
			if (i == Main.myPlayer)
			{
				if (Main.trashItem.type >= 1522 && Main.trashItem.type <= 1527)
				{
					Main.trashItem.SetDefaults(0);
				}
				UpdateBiomes();
			}
			if (ghost)
			{
				Ghost();
				return;
			}
			if (dead)
			{
				UpdateDead();
				return;
			}
			if (i == Main.myPlayer)
			{
				controlUp = false;
				controlLeft = false;
				controlDown = false;
				controlRight = false;
				controlJump = false;
				controlUseItem = false;
				controlUseTile = false;
				controlThrow = false;
				controlInv = false;
				controlHook = false;
				controlTorch = false;
				controlSmart = false;
				mapStyle = false;
				mapAlphaDown = false;
				mapAlphaUp = false;
				mapFullScreen = false;
				mapZoomIn = false;
				mapZoomOut = false;
				if (Main.hasFocus)
				{
					if (!Main.chatMode && !Main.editSign && !Main.editChest && !Main.blockInput)
					{
						Keys[] pressedKeys = Main.keyState.GetPressedKeys();
						if (Main.blockKey != Keys.None)
						{
							bool flag2 = false;
							for (int k = 0; k < pressedKeys.Length; k++)
							{
								if (pressedKeys[k] == Main.blockKey)
								{
									pressedKeys[k] = Keys.None;
									flag2 = true;
								}
							}
							if (!flag2)
							{
								Main.blockKey = Keys.None;
							}
						}
						bool flag3 = false;
						bool flag4 = false;
						for (int l = 0; l < pressedKeys.Length; l++)
						{
							string text = string.Concat(pressedKeys[l]);
							if (text == Main.cUp)
							{
								controlUp = true;
							}
							if (text == Main.cLeft)
							{
								controlLeft = true;
							}
							if (text == Main.cDown)
							{
								controlDown = true;
							}
							if (text == Main.cRight)
							{
								controlRight = true;
							}
							if (text == Main.cJump)
							{
								controlJump = true;
							}
							if (text == Main.cThrowItem)
							{
								controlThrow = true;
							}
							if (text == Main.cInv)
							{
								controlInv = true;
							}
							if (text == Main.cBuff)
							{
								QuickBuff();
							}
							if (text == Main.cHeal)
							{
								flag4 = true;
							}
							if (text == Main.cMana)
							{
								flag3 = true;
							}
							if (text == Main.cHook)
							{
								controlHook = true;
							}
							if (text == Main.cTorch)
							{
								controlTorch = true;
							}
							if (text == Main.cSmart)
							{
								controlSmart = true;
							}
							if (Main.mapEnabled)
							{
								if (text == Main.cMapZoomIn)
								{
									mapZoomIn = true;
								}
								if (text == Main.cMapZoomOut)
								{
									mapZoomOut = true;
								}
								if (text == Main.cMapAlphaUp)
								{
									mapAlphaUp = true;
								}
								if (text == Main.cMapAlphaDown)
								{
									mapAlphaDown = true;
								}
								if (text == Main.cMapFull)
								{
									mapFullScreen = true;
								}
								if (text == Main.cMapStyle)
								{
									mapStyle = true;
								}
							}
						}
						if (Main.gamePad)
						{
							GamePadState state = GamePad.GetState(PlayerIndex.One);
							if (state.DPad.Up == ButtonState.Pressed)
							{
								controlUp = true;
							}
							if (state.DPad.Down == ButtonState.Pressed)
							{
								controlDown = true;
							}
							if (state.DPad.Left == ButtonState.Pressed)
							{
								controlLeft = true;
							}
							if (state.DPad.Right == ButtonState.Pressed)
							{
								controlRight = true;
							}
							if (state.Triggers.Left > 0f)
							{
								controlJump = true;
							}
							if (state.Triggers.Right > 0f)
							{
								controlUseItem = true;
							}
							Main.mouseX = (int)((float)(Main.screenWidth / 2) + state.ThumbSticks.Right.X * (float)tileRangeX * 16f);
							Main.mouseY = (int)((float)(Main.screenHeight / 2) - state.ThumbSticks.Right.Y * (float)tileRangeX * 16f);
							if (state.ThumbSticks.Right.X == 0f)
							{
								Main.mouseX = Main.screenWidth / 2 + direction * 2;
							}
						}
						if (Main.mapFullscreen)
						{
							if (controlUp)
							{
								Main.mapFullscreenPos.Y -= 1f * (16f / Main.mapFullscreenScale);
							}
							if (controlDown)
							{
								Main.mapFullscreenPos.Y += 1f * (16f / Main.mapFullscreenScale);
							}
							if (controlLeft)
							{
								Main.mapFullscreenPos.X -= 1f * (16f / Main.mapFullscreenScale);
							}
							if (controlRight)
							{
								Main.mapFullscreenPos.X += 1f * (16f / Main.mapFullscreenScale);
							}
							controlUp = false;
							controlLeft = false;
							controlDown = false;
							controlRight = false;
							controlJump = false;
							controlUseItem = false;
							controlUseTile = false;
							controlThrow = false;
							controlHook = false;
							controlTorch = false;
							controlSmart = false;
						}
						if (flag4)
						{
							if (releaseQuickHeal)
							{
								QuickHeal();
							}
							releaseQuickHeal = false;
						}
						else
						{
							releaseQuickHeal = true;
						}
						if (flag3)
						{
							if (releaseQuickMana)
							{
								QuickMana();
							}
							releaseQuickMana = false;
						}
						else
						{
							releaseQuickMana = true;
						}
						if (controlLeft && controlRight)
						{
							controlLeft = false;
							controlRight = false;
						}
						if (Main.cSmartToggle)
						{
							if (controlSmart && releaseSmart)
							{
								Main.PlaySound(12);
								Main.smartDigEnabled = !Main.smartDigEnabled;
							}
						}
						else
						{
							if (Main.smartDigEnabled != controlSmart)
							{
								Main.PlaySound(12);
							}
							Main.smartDigEnabled = controlSmart;
						}
						if (controlSmart)
						{
							releaseSmart = false;
						}
						else
						{
							releaseSmart = true;
						}
						if (Main.mapFullscreen)
						{
							if (mapZoomIn)
							{
								Main.mapFullscreenScale *= 1.05f;
							}
							if (mapZoomOut)
							{
								Main.mapFullscreenScale *= 0.95f;
							}
						}
						else
						{
							if (Main.mapStyle == 1)
							{
								if (mapZoomIn)
								{
									Main.mapMinimapScale *= 1.025f;
								}
								if (mapZoomOut)
								{
									Main.mapMinimapScale *= 0.975f;
								}
								if (mapAlphaUp)
								{
									Main.mapMinimapAlpha += 0.015f;
								}
								if (mapAlphaDown)
								{
									Main.mapMinimapAlpha -= 0.015f;
								}
							}
							else if (Main.mapStyle == 2)
							{
								if (mapZoomIn)
								{
									Main.mapOverlayScale *= 1.05f;
								}
								if (mapZoomOut)
								{
									Main.mapOverlayScale *= 0.95f;
								}
								if (mapAlphaUp)
								{
									Main.mapOverlayAlpha += 0.015f;
								}
								if (mapAlphaDown)
								{
									Main.mapOverlayAlpha -= 0.015f;
								}
							}
							if (mapStyle)
							{
								if (releaseMapStyle)
								{
									Main.PlaySound(12);
									Main.mapStyle++;
									if (Main.mapStyle > 2)
									{
										Main.mapStyle = 0;
									}
								}
								releaseMapStyle = false;
							}
							else
							{
								releaseMapStyle = true;
							}
						}
						if (mapFullScreen)
						{
							if (releaseMapFullscreen)
							{
								if (Main.mapFullscreen)
								{
									Main.PlaySound(11);
									Main.mapFullscreen = false;
								}
								else
								{
									Main.playerInventory = false;
									talkNPC = -1;
									Main.npcChatCornerItem = 0;
									Main.PlaySound(10);
									float mapFullscreenScale = 2.5f;
									Main.mapFullscreenScale = mapFullscreenScale;
									Main.mapFullscreen = true;
									Main.resetMapFull = true;
									Main.buffString = string.Empty;
								}
							}
							releaseMapFullscreen = false;
						}
						else
						{
							releaseMapFullscreen = true;
						}
					}
					if (confused)
					{
						bool flag5 = controlLeft;
						bool flag6 = controlUp;
						controlLeft = controlRight;
						controlRight = flag5;
						controlUp = controlRight;
						controlDown = flag6;
					}
					else if (cartFlip)
					{
						if (controlRight || controlLeft)
						{
							bool flag7 = controlLeft;
							controlLeft = controlRight;
							controlRight = flag7;
						}
						else
						{
							cartFlip = false;
						}
					}
					if (Main.mouseLeft)
					{
						if (!Main.blockMouse && !mouseInterface)
						{
							controlUseItem = true;
						}
					}
					else
					{
						Main.blockMouse = false;
					}
					if (Main.mouseRight && !mouseInterface && !Main.blockMouse)
					{
						controlUseTile = true;
					}
					if (controlInv)
					{
						if (releaseInventory)
						{
							if (Main.mapFullscreen)
							{
								Main.mapFullscreen = false;
								releaseInventory = false;
								Main.PlaySound(11);
							}
							else
							{
								toggleInv();
							}
						}
						releaseInventory = false;
					}
					else
					{
						releaseInventory = true;
					}
					if (delayUseItem)
					{
						if (!controlUseItem)
						{
							delayUseItem = false;
						}
						controlUseItem = false;
					}
					if (itemAnimation == 0 && itemTime == 0)
					{
						dropItemCheck();
						int num6 = selectedItem;
						if (!Main.chatMode && selectedItem != 58 && !Main.editSign && !Main.editChest)
						{
							if (Main.keyState.IsKeyDown(Keys.D1))
							{
								selectedItem = 0;
							}
							if (Main.keyState.IsKeyDown(Keys.D2))
							{
								selectedItem = 1;
							}
							if (Main.keyState.IsKeyDown(Keys.D3))
							{
								selectedItem = 2;
							}
							if (Main.keyState.IsKeyDown(Keys.D4))
							{
								selectedItem = 3;
							}
							if (Main.keyState.IsKeyDown(Keys.D5))
							{
								selectedItem = 4;
							}
							if (Main.keyState.IsKeyDown(Keys.D6))
							{
								selectedItem = 5;
							}
							if (Main.keyState.IsKeyDown(Keys.D7))
							{
								selectedItem = 6;
							}
							if (Main.keyState.IsKeyDown(Keys.D8))
							{
								selectedItem = 7;
							}
							if (Main.keyState.IsKeyDown(Keys.D9))
							{
								selectedItem = 8;
							}
							if (Main.keyState.IsKeyDown(Keys.D0))
							{
								selectedItem = 9;
							}
						}
						if (num6 != selectedItem)
						{
							Main.PlaySound(12);
						}
						if (Main.mapFullscreen)
						{
							int num7 = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
							Main.mapFullscreenScale *= 1f + (float)num7 * 0.3f;
						}
						else if (!Main.playerInventory)
						{
							int m;
							for (m = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120; m > 9; m -= 10)
							{
							}
							for (; m < 0; m += 10)
							{
							}
							selectedItem -= m;
							if (m != 0)
							{
								Main.PlaySound(12);
							}
							if (changeItem >= 0)
							{
								if (selectedItem != changeItem)
								{
									Main.PlaySound(12);
								}
								selectedItem = changeItem;
								changeItem = -1;
							}
							if (itemAnimation == 0)
							{
								while (selectedItem > 9)
								{
									selectedItem -= 10;
								}
								while (selectedItem < 0)
								{
									selectedItem += 10;
								}
							}
						}
						else
						{
							int num8 = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
							Main.focusRecipe += num8;
							if (Main.focusRecipe > Main.numAvailableRecipes - 1)
							{
								Main.focusRecipe = Main.numAvailableRecipes - 1;
							}
							if (Main.focusRecipe < 0)
							{
								Main.focusRecipe = 0;
							}
						}
					}
				}
				if (selectedItem == 58)
				{
					nonTorch = -1;
				}
				else
				{
					SmartitemLookup();
				}
				if (frozen)
				{
					controlJump = false;
					controlDown = false;
					controlLeft = false;
					controlRight = false;
					controlUp = false;
					controlUseItem = false;
					controlUseTile = false;
					controlThrow = false;
				}
				if (!controlThrow)
				{
					releaseThrow = true;
				}
				else
				{
					releaseThrow = false;
				}
				if (Main.netMode == 1)
				{
					bool flag8 = false;
					if (controlUp != Main.clientPlayer.controlUp)
					{
						flag8 = true;
					}
					if (controlDown != Main.clientPlayer.controlDown)
					{
						flag8 = true;
					}
					if (controlLeft != Main.clientPlayer.controlLeft)
					{
						flag8 = true;
					}
					if (controlRight != Main.clientPlayer.controlRight)
					{
						flag8 = true;
					}
					if (controlJump != Main.clientPlayer.controlJump)
					{
						flag8 = true;
					}
					if (controlUseItem != Main.clientPlayer.controlUseItem)
					{
						flag8 = true;
					}
					if (selectedItem != Main.clientPlayer.selectedItem)
					{
						flag8 = true;
					}
					if (flag8)
					{
						NetMessage.SendData(13, -1, -1, "", Main.myPlayer);
					}
				}
				if (Main.playerInventory)
				{
					AdjTiles();
				}
				if (chest != -1)
				{
					int num9 = (int)(((double)position.X + (double)width * 0.5) / 16.0);
					int num10 = (int)(((double)position.Y + (double)height * 0.5) / 16.0);
					if (num9 < chestX - tileRangeX || num9 > chestX + tileRangeX + 1 || num10 < chestY - tileRangeY || num10 > chestY + tileRangeY + 1)
					{
						if (chest != -1)
						{
							Main.PlaySound(11);
						}
						chest = -1;
					}
					if (!Main.tile[chestX, chestY].active())
					{
						Main.PlaySound(11);
						chest = -1;
					}
				}
				if (velocity.Y <= 0f)
				{
					fallStart2 = (int)(position.Y / 16f);
				}
				if (velocity.Y == 0f)
				{
					int num11 = 25;
					num11 += extraFall;
					int num12 = (int)(position.Y / 16f) - fallStart;
					if (mount.CanFly)
					{
						num12 = 0;
					}
					if (mount.Type == 6 && Minecart.OnTrack(position, width, height))
					{
						num12 = 0;
					}
					mount.FatigueRecovery();
					bool flag9 = false;
					for (int n = 3; n < 8; n++)
					{
						if (armor[n].stack > 0 && armor[n].wingSlot > -1)
						{
							flag9 = true;
						}
					}
					if (((gravDir == 1f && num12 > num11) || (gravDir == -1f && num12 < -num11)) && !noFallDmg && !flag9)
					{
						int num13 = (int)((float)num12 * gravDir - (float)num11) * 10;
						if (mount.Active)
						{
							num13 = (int)((float)num13 * mount.FallDamage);
						}
						immune = false;
						Hurt(num13, 0, false, false, Lang.deathMsg(-1, -1, -1, 0));
					}
					fallStart = (int)(position.Y / 16f);
				}
				if (jump > 0 || rocketDelay > 0 || wet || slowFall || (double)num5 < 0.8 || tongued)
				{
					fallStart = (int)(position.Y / 16f);
				}
			}
			if (mouseInterface)
			{
				delayUseItem = true;
			}
			tileTargetX = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
			tileTargetY = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
			if (gravDir == -1f)
			{
				tileTargetY = (int)((Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16f);
			}
			if (tileTargetX >= Main.maxTilesX - 5)
			{
				tileTargetX = Main.maxTilesX - 5;
			}
			if (tileTargetY >= Main.maxTilesY - 5)
			{
				tileTargetY = Main.maxTilesY - 5;
			}
			if (tileTargetX < 5)
			{
				tileTargetX = 5;
			}
			if (tileTargetY < 5)
			{
				tileTargetY = 5;
			}
			if (Main.tile[tileTargetX - 1, tileTargetY] == null)
			{
				Main.tile[tileTargetX - 1, tileTargetY] = new Tile();
			}
			if (Main.tile[tileTargetX + 1, tileTargetY] == null)
			{
				Main.tile[tileTargetX + 1, tileTargetY] = new Tile();
			}
			if (Main.tile[tileTargetX, tileTargetY] == null)
			{
				Main.tile[tileTargetX, tileTargetY] = new Tile();
			}
			if (!Main.tile[tileTargetX, tileTargetY].active())
			{
				if (Main.tile[tileTargetX - 1, tileTargetY].active() && Main.tile[tileTargetX - 1, tileTargetY].type == 323)
				{
					int frameY = Main.tile[tileTargetX - 1, tileTargetY].frameY;
					if (frameY < -4)
					{
						tileTargetX++;
					}
					if (frameY > 4)
					{
						tileTargetX--;
					}
				}
				else if (Main.tile[tileTargetX + 1, tileTargetY].active() && Main.tile[tileTargetX + 1, tileTargetY].type == 323)
				{
					int frameY2 = Main.tile[tileTargetX + 1, tileTargetY].frameY;
					if (frameY2 < -4)
					{
						tileTargetX++;
					}
					if (frameY2 > 4)
					{
						tileTargetX--;
					}
				}
			}
			SmartCursorLookup();
			UpdateImmunity();
			if (petalTimer > 0)
			{
				petalTimer--;
			}
			if (shadowDodgeTimer > 0)
			{
				shadowDodgeTimer--;
			}
			if (jump > 0 || velocity.Y != 0f)
			{
				slippy = false;
				slippy2 = false;
				powerrun = false;
				sticky = false;
			}
			potionDelayTime = Item.potionDelay;
			if (pStone)
			{
				potionDelayTime -= 900;
			}
			ResetEffects();
			meleeCrit += inventory[selectedItem].crit;
			magicCrit += inventory[selectedItem].crit;
			rangedCrit += inventory[selectedItem].crit;
			if (whoAmi == Main.myPlayer)
			{
				Main.musicBox2 = -1;
				if (Main.waterCandles > 0)
				{
					AddBuff(86, 2, false);
				}
				if (Main.campfire)
				{
					AddBuff(87, 2, false);
				}
				if (Main.heartLantern)
				{
					AddBuff(89, 2, false);
				}
			}
			for (int num14 = 0; num14 < 140; num14++)
			{
				buffImmune[num14] = false;
			}
			UpdateBuffs(i);
			if (accMerman && wet && !lavaWet)
			{
				releaseJump = true;
				wings = 0;
				merman = true;
				accFlipper = true;
				AddBuff(34, 2);
			}
			else
			{
				merman = false;
			}
			accMerman = false;
			if (wolfAcc && !merman && !Main.dayTime && !wereWolf)
			{
				AddBuff(28, 60);
			}
			wolfAcc = false;
			if (whoAmi == Main.myPlayer)
			{
				for (int num15 = 0; num15 < 22; num15++)
				{
					if (buffType[num15] > 0 && buffTime[num15] <= 0)
					{
						DelBuff(num15);
					}
				}
			}
			beetleDefense = false;
			beetleOffense = false;
			doubleJump = false;
			head = armor[0].headSlot;
			body = armor[1].bodySlot;
			legs = armor[2].legSlot;
			handon = -1;
			handoff = -1;
			back = -1;
			front = -1;
			shoe = -1;
			waist = -1;
			shield = -1;
			neck = -1;
			face = -1;
			balloon = -1;
			UpdateEquips(i);
			if (mount.Active)
			{
				autoJump = mount.AutoJump;
			}
			gemCount++;
			if (gemCount >= 10)
			{
				gem = -1;
				gemCount = 0;
				for (int num16 = 0; num16 <= 58; num16++)
				{
					if (inventory[num16].type == 0 || inventory[num16].stack == 0)
					{
						inventory[num16].type = 0;
						inventory[num16].stack = 0;
						inventory[num16].name = "";
						inventory[num16].netID = 0;
					}
					if (inventory[num16].type >= 1522 && inventory[num16].type <= 1527)
					{
						gem = inventory[num16].type - 1522;
					}
				}
			}
			if (head == 11)
			{
				int i2 = (int)(position.X + (float)(width / 2) + (float)(8 * direction)) / 16;
				int j2 = (int)(position.Y + 2f) / 16;
				Lighting.addLight(i2, j2, 0.92f, 0.8f, 0.65f);
			}
			UpdateArmorSets(i);
			if (merman)
			{
				wings = 0;
			}
			if (armorSteath)
			{
				if (itemAnimation > 0)
				{
					stealthTimer = 5;
				}
				if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1 && (double)velocity.Y > -0.1 && (double)velocity.Y < 0.1)
				{
					if (stealthTimer == 0)
					{
						stealth -= 0.015f;
						if ((double)stealth < 0.0)
						{
							stealth = 0f;
						}
					}
				}
				else
				{
					float num17 = Math.Abs(velocity.X) + Math.Abs(velocity.Y);
					stealth += num17 * 0.0075f;
					if (stealth > 1f)
					{
						stealth = 1f;
					}
				}
				rangedDamage += (1f - stealth) * 0.6f;
				rangedCrit += (int)((1f - stealth) * 10f);
				aggro -= (int)((1f - stealth) * 750f);
				if (stealthTimer > 0)
				{
					stealthTimer--;
				}
			}
			else
			{
				stealth = 1f;
			}
			if (manaSick)
			{
				magicDamage *= 1f - manaSickReduction;
			}
			if (inventory[selectedItem].type == 1947)
			{
				meleeSpeed = (1f + meleeSpeed) / 2f;
			}
			if ((double)pickSpeed < 0.3)
			{
				pickSpeed = 0.3f;
			}
			if (meleeSpeed > 3f)
			{
				meleeSpeed = 3f;
			}
			if ((double)moveSpeed > 1.6)
			{
				moveSpeed = 1.6f;
			}
			if (tileSpeed > 3f)
			{
				tileSpeed = 3f;
			}
			tileSpeed = 1f / tileSpeed;
			if (wallSpeed > 3f)
			{
				wallSpeed = 3f;
			}
			wallSpeed = 1f / wallSpeed;
			if (statManaMax2 > 400)
			{
				statManaMax2 = 400;
			}
			if (statDefense < 0)
			{
				statDefense = 0;
			}
			if (slow)
			{
				moveSpeed *= 0.5f;
			}
			if (chilled)
			{
				moveSpeed *= 0.75f;
			}
			meleeSpeed = 1f / meleeSpeed;
			UpdateLifeRegen();
			UpdateManaRegen();
			if (manaRegenCount < 0)
			{
				manaRegenCount = 0;
			}
			if (statMana > statManaMax2)
			{
				statMana = statManaMax2;
			}
			runAcceleration *= moveSpeed;
			maxRunSpeed *= moveSpeed;
			UpdateJumpHeight();
			for (int num18 = 0; num18 < 22; num18++)
			{
				if (buffType[num18] > 0 && buffTime[num18] > 0 && buffImmune[buffType[num18]])
				{
					DelBuff(num18);
				}
			}
			if (brokenArmor)
			{
				statDefense /= 2;
			}
			if (mount.Active && mount.BlockExtraJumps)
			{
				jumpAgain = false;
				jumpAgain2 = false;
				jumpAgain3 = false;
				jumpAgain4 = false;
			}
			else
			{
				if (!doubleJump)
				{
					jumpAgain = false;
				}
				else if (velocity.Y == 0f || sliding)
				{
					jumpAgain = true;
				}
				if (!doubleJump2)
				{
					jumpAgain2 = false;
				}
				else if (velocity.Y == 0f || sliding)
				{
					jumpAgain2 = true;
				}
				if (!doubleJump3)
				{
					jumpAgain3 = false;
				}
				else if (velocity.Y == 0f || sliding)
				{
					jumpAgain3 = true;
				}
				if (!doubleJump4)
				{
					jumpAgain4 = false;
				}
				else if (velocity.Y == 0f || sliding)
				{
					jumpAgain4 = true;
				}
			}
			if (!carpet)
			{
				canCarpet = false;
				carpetFrame = -1;
			}
			else if (velocity.Y == 0f || sliding)
			{
				canCarpet = true;
				carpetTime = 0;
				carpetFrame = -1;
				carpetFrameCounter = 0f;
			}
			if (gravDir == -1f)
			{
				canCarpet = false;
			}
			if (ropeCount > 0)
			{
				ropeCount--;
			}
			if (!pulley && !frozen && !controlJump && gravDir == 1f && ropeCount == 0 && grappling[0] == -1 && !tongued && !mount.Active)
			{
				FindPulley();
			}
			if (pulley)
			{
				if (mount.Active)
				{
					pulley = false;
				}
				sandStorm = false;
				dJumpEffect = false;
				dJumpEffect2 = false;
				dJumpEffect3 = false;
				dJumpEffect4 = false;
				int num19 = (int)(position.X + (float)(width / 2)) / 16;
				int num20 = (int)(position.Y - 8f) / 16;
				bool flag10 = false;
				if (pulleyDir == 0)
				{
					pulleyDir = 1;
				}
				if (pulleyDir == 1)
				{
					if (direction == -1 && controlLeft && (releaseLeft || leftTimer == 0))
					{
						pulleyDir = 2;
						flag10 = true;
					}
					else if ((direction == 1 && controlRight && releaseRight) || rightTimer == 0)
					{
						pulleyDir = 2;
						flag10 = true;
					}
					else
					{
						if (direction == 1 && controlLeft)
						{
							direction = -1;
							flag10 = true;
						}
						if (direction == -1 && controlRight)
						{
							direction = 1;
							flag10 = true;
						}
					}
				}
				else if (pulleyDir == 2)
				{
					if (direction == 1 && controlLeft)
					{
						flag10 = true;
						int num21 = num19 * 16 + 8 - width / 2;
						if (!Collision.SolidCollision(new Vector2(num21, position.Y), width, height))
						{
							pulleyDir = 1;
							direction = -1;
							flag10 = true;
						}
					}
					if (direction == -1 && controlRight)
					{
						flag10 = true;
						int num22 = num19 * 16 + 8 - width / 2;
						if (!Collision.SolidCollision(new Vector2(num22, position.Y), width, height))
						{
							pulleyDir = 1;
							direction = 1;
							flag10 = true;
						}
					}
				}
				bool flag11 = false;
				if (!flag10 && ((controlLeft && (releaseLeft || leftTimer == 0)) || (controlRight && (releaseRight || rightTimer == 0))))
				{
					int num23 = 1;
					if (controlLeft)
					{
						num23 = -1;
					}
					int num24 = num19 + num23;
					if (Main.tile[num24, num20].active() && Main.tileRope[Main.tile[num24, num20].type])
					{
						pulleyDir = 1;
						direction = num23;
						int num25 = num24 * 16 + 8 - width / 2;
						float y = position.Y;
						y = num20 * 16 + 22;
						if ((!Main.tile[num24, num20 - 1].active() || !Main.tileRope[Main.tile[num24, num20 - 1].type]) && (!Main.tile[num24, num20 + 1].active() || !Main.tileRope[Main.tile[num24, num20 + 1].type]))
						{
							y = num20 * 16 + 22;
						}
						if (Collision.SolidCollision(new Vector2(num25, y), width, height))
						{
							pulleyDir = 2;
							direction = -num23;
							num25 = ((direction != 1) ? (num24 * 16 + 8 - width / 2 + -6) : (num24 * 16 + 8 - width / 2 + 6));
						}
						if (i == Main.myPlayer)
						{
							Main.cameraX = Main.cameraX + position.X - (float)num25;
						}
						position.X = num25;
						gfxOffY = position.Y - y;
						position.Y = y;
						flag11 = true;
					}
				}
				if (!flag11 && !flag10 && !controlUp && ((controlLeft && releaseLeft) || (controlRight && releaseRight)))
				{
					pulley = false;
					if (controlLeft && velocity.X == 0f)
					{
						velocity.X = -1f;
					}
					if (controlRight && velocity.X == 0f)
					{
						velocity.X = 1f;
					}
				}
				if (velocity.X != 0f)
				{
					pulley = false;
				}
				if (Main.tile[num19, num20] == null)
				{
					Main.tile[num19, num20] = new Tile();
				}
				if (!Main.tile[num19, num20].active() || !Main.tileRope[Main.tile[num19, num20].type])
				{
					pulley = false;
				}
				if (gravDir != 1f)
				{
					pulley = false;
				}
				if (frozen)
				{
					pulley = false;
				}
				if (!pulley)
				{
					velocity.Y -= gravity;
				}
				if (controlJump)
				{
					pulley = false;
					jump = jumpHeight;
					velocity.Y = 0f - jumpSpeed;
				}
			}
			if (pulley)
			{
				fallStart = (int)position.Y / 16;
				wingFrame = 0;
				if (wings == 4)
				{
					wingFrame = 3;
				}
				int num26 = (int)(position.X + (float)(width / 2)) / 16;
				int num27 = (int)(position.Y - 16f) / 16;
				int num28 = (int)(position.Y - 8f) / 16;
				bool flag12 = true;
				bool flag13 = false;
				if ((Main.tile[num26, num28 - 1].active() && Main.tileRope[Main.tile[num26, num28 - 1].type]) || (Main.tile[num26, num28 + 1].active() && Main.tileRope[Main.tile[num26, num28 + 1].type]))
				{
					flag13 = true;
				}
				if (Main.tile[num26, num27] == null)
				{
					Main.tile[num26, num27] = new Tile();
				}
				if (!Main.tile[num26, num27].active() || !Main.tileRope[Main.tile[num26, num27].type])
				{
					flag12 = false;
					if (velocity.Y < 0f)
					{
						velocity.Y = 0f;
					}
				}
				if (flag13)
				{
					if (controlUp && flag12)
					{
						float x = position.X;
						float y2 = position.Y - Math.Abs(velocity.Y) - 2f;
						if (Collision.SolidCollision(new Vector2(x, y2), width, height))
						{
							x = num26 * 16 + 8 - width / 2 + 6;
							if (!Collision.SolidCollision(new Vector2(x, y2), width, (int)((float)height + Math.Abs(velocity.Y) + 2f)))
							{
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + position.X - x;
								}
								pulleyDir = 2;
								direction = 1;
								position.X = x;
								velocity.X = 0f;
							}
							else
							{
								x = num26 * 16 + 8 - width / 2 + -6;
								if (!Collision.SolidCollision(new Vector2(x, y2), width, (int)((float)height + Math.Abs(velocity.Y) + 2f)))
								{
									if (i == Main.myPlayer)
									{
										Main.cameraX = Main.cameraX + position.X - x;
									}
									pulleyDir = 2;
									direction = -1;
									position.X = x;
									velocity.X = 0f;
								}
							}
						}
						if (velocity.Y > 0f)
						{
							velocity.Y *= 0.7f;
						}
						if (velocity.Y > -3f)
						{
							velocity.Y -= 0.2f;
						}
						else
						{
							velocity.Y -= 0.02f;
						}
						if (velocity.Y < -8f)
						{
							velocity.Y = -8f;
						}
					}
					else if (controlDown)
					{
						float x2 = position.X;
						float y3 = position.Y;
						if (Collision.SolidCollision(new Vector2(x2, y3), width, (int)((float)height + Math.Abs(velocity.Y) + 2f)))
						{
							x2 = num26 * 16 + 8 - width / 2 + 6;
							if (!Collision.SolidCollision(new Vector2(x2, y3), width, (int)((float)height + Math.Abs(velocity.Y) + 2f)))
							{
								if (i == Main.myPlayer)
								{
									Main.cameraX = Main.cameraX + position.X - x2;
								}
								pulleyDir = 2;
								direction = 1;
								position.X = x2;
								velocity.X = 0f;
							}
							else
							{
								x2 = num26 * 16 + 8 - width / 2 + -6;
								if (!Collision.SolidCollision(new Vector2(x2, y3), width, (int)((float)height + Math.Abs(velocity.Y) + 2f)))
								{
									if (i == Main.myPlayer)
									{
										Main.cameraX = Main.cameraX + position.X - x2;
									}
									pulleyDir = 2;
									direction = -1;
									position.X = x2;
									velocity.X = 0f;
								}
							}
						}
						if (velocity.Y < 0f)
						{
							velocity.Y *= 0.7f;
						}
						if (velocity.Y < 3f)
						{
							velocity.Y += 0.2f;
						}
						else
						{
							velocity.Y += 0.1f;
						}
						if (velocity.Y > maxFallSpeed)
						{
							velocity.Y = maxFallSpeed;
						}
					}
					else
					{
						velocity.Y *= 0.7f;
						if ((double)velocity.Y > -0.1 && (double)velocity.Y < 0.1)
						{
							velocity.Y = 0f;
						}
					}
				}
				else if (controlDown)
				{
					ropeCount = 10;
					pulley = false;
					velocity.Y = 1f;
				}
				else
				{
					velocity.Y = 0f;
					position.Y = num27 * 16 + 22;
				}
				float num29 = num26 * 16 + 8 - width / 2;
				if (pulleyDir == 1)
				{
					num29 = num26 * 16 + 8 - width / 2;
				}
				if (pulleyDir == 2)
				{
					num29 = num26 * 16 + 8 - width / 2 + 6 * direction;
				}
				if (i == Main.myPlayer)
				{
					Main.cameraX = Main.cameraX + position.X - num29;
				}
				position.X = num29;
				pulleyFrameCounter += Math.Abs(velocity.Y * 0.75f);
				if (velocity.Y != 0f)
				{
					pulleyFrameCounter += 0.75f;
				}
				if (pulleyFrameCounter > 10f)
				{
					pulleyFrame++;
					pulleyFrameCounter = 0f;
				}
				if (pulleyFrame > 1)
				{
					pulleyFrame = 0;
				}
				canCarpet = true;
				carpetFrame = -1;
				wingTime = wingTimeMax;
				rocketTime = rocketTimeMax;
				rocketDelay = 0;
				rocketFrame = false;
				canRocket = false;
				rocketRelease = false;
			}
			else if (grappling[0] == -1 && !tongued)
			{
				if (wingsLogic == 3 && velocity.Y == 0f)
				{
					accRunSpeed = 8.5f;
				}
				if (wingsLogic == 3 && Main.myPlayer == whoAmi)
				{
					accRunSpeed = 0f;
				}
				if (wingsLogic > 0 && velocity.Y != 0f && !merman)
				{
					if (wingsLogic == 1 || wingsLogic == 2)
					{
						accRunSpeed = 6.25f;
					}
					if (wingsLogic == 4)
					{
						accRunSpeed = 6.5f;
					}
					if (wingsLogic == 5 || wingsLogic == 6 || wingsLogic == 13 || wingsLogic == 15)
					{
						accRunSpeed = 6.75f;
					}
					if (wingsLogic == 7 || wingsLogic == 8)
					{
						accRunSpeed = 7f;
					}
					if (wingsLogic == 9 || wingsLogic == 10 || wingsLogic == 11 || wingsLogic == 20 || wingsLogic == 21 || wingsLogic == 23 || wingsLogic == 24)
					{
						accRunSpeed = 7.5f;
					}
					if (wingsLogic == 22)
					{
						if (controlDown && controlJump && wingTime > 0f)
						{
							accRunSpeed = 10f;
							runAcceleration *= 10f;
						}
						else
						{
							accRunSpeed = 6.25f;
						}
					}
					if (wingsLogic == 26)
					{
						accRunSpeed = 8f;
						runAcceleration *= 2f;
					}
					if (wingsLogic == 12)
					{
						accRunSpeed = 7.75f;
					}
					if (wingsLogic == 16 || wingsLogic == 17 || wingsLogic == 18 || wingsLogic == 19)
					{
						accRunSpeed = 7.9f;
					}
					if (wingsLogic == 3)
					{
						accRunSpeed = 11f;
						runAcceleration *= 3f;
					}
				}
				if (Main.myPlayer == whoAmi && (wings == 3 || wings == 16 || wings == 17 || wings == 18 || wings == 19))
				{
					accRunSpeed = 0f;
					maxRunSpeed *= 0.2f;
					runAcceleration *= 0.2f;
				}
				if (sticky)
				{
					maxRunSpeed *= 0.25f;
					runAcceleration *= 0.25f;
					runSlowdown *= 2f;
					if (velocity.X > maxRunSpeed)
					{
						velocity.X = maxRunSpeed;
					}
					if (velocity.X < 0f - maxRunSpeed)
					{
						velocity.X = 0f - maxRunSpeed;
					}
				}
				else if (powerrun)
				{
					maxRunSpeed *= 3.5f;
					runAcceleration *= 1f;
					runSlowdown *= 2f;
				}
				else if (slippy2)
				{
					runAcceleration *= 0.6f;
					runSlowdown = 0f;
					if (iceSkate)
					{
						runAcceleration *= 3.5f;
						maxRunSpeed *= 1.25f;
					}
				}
				else if (slippy)
				{
					runAcceleration *= 0.7f;
					if (iceSkate)
					{
						runAcceleration *= 3.5f;
						maxRunSpeed *= 1.25f;
					}
					else
					{
						runSlowdown *= 0.1f;
					}
				}
				if (sandStorm)
				{
					runAcceleration *= 1.5f;
					maxRunSpeed *= 2f;
				}
				if (dJumpEffect3 && doubleJump3)
				{
					runAcceleration *= 3f;
					maxRunSpeed *= 1.5f;
				}
				if (dJumpEffect4 && doubleJump4)
				{
					runAcceleration *= 3f;
					maxRunSpeed *= 1.75f;
				}
				if (carpetFrame != -1)
				{
					runAcceleration *= 1.25f;
					maxRunSpeed *= 1.5f;
				}
				if (mount.Active)
				{
					rocketBoots = 0;
					wings = 0;
					wingsLogic = 0;
					maxRunSpeed = mount.RunSpeed;
					accRunSpeed = mount.DashSpeed;
					runAcceleration = mount.Acceleration;
					if (mount.Type == 6 && velocity.Y == 0f)
					{
						if (!Minecart.OnTrack(position, width, height))
						{
							fullRotation = 0f;
							onWrongGround = true;
							runSlowdown = 0.2f;
							if ((controlLeft && releaseLeft) || (controlRight && releaseRight))
							{
								mount.Dismount(this);
							}
						}
						else
						{
							runSlowdown = runAcceleration;
							onWrongGround = false;
						}
					}
				}
				HorizontalMovement();
				if (gravControl)
				{
					if (controlUp && releaseUp)
					{
						if (gravDir == 1f)
						{
							gravDir = -1f;
							fallStart = (int)(position.Y / 16f);
							jump = 0;
							Main.PlaySound(2, (int)position.X, (int)position.Y, 8);
						}
						else
						{
							gravDir = 1f;
							fallStart = (int)(position.Y / 16f);
							jump = 0;
							Main.PlaySound(2, (int)position.X, (int)position.Y, 8);
						}
					}
				}
				else if (gravControl2)
				{
					if (controlUp && releaseUp && velocity.Y == 0f)
					{
						if (gravDir == 1f)
						{
							gravDir = -1f;
							fallStart = (int)(position.Y / 16f);
							jump = 0;
							Main.PlaySound(2, (int)position.X, (int)position.Y, 8);
						}
						else
						{
							gravDir = 1f;
							fallStart = (int)(position.Y / 16f);
							jump = 0;
							Main.PlaySound(2, (int)position.X, (int)position.Y, 8);
						}
					}
				}
				else
				{
					gravDir = 1f;
				}
				if (velocity.Y == 0f && mount.Active && mount.Type == 5 && controlUp && releaseUp)
				{
					velocity.Y = 0f - (mount.Acceleration + gravity + 0.001f);
				}
				if (controlUp)
				{
					releaseUp = false;
				}
				else
				{
					releaseUp = true;
				}
				sandStorm = false;
				JumpMovement();
				if (wingsLogic == 0)
				{
					wingTime = 0f;
				}
				if (wingsLogic == 3)
				{
					wingTime = 1000f;
				}
				if (Main.myPlayer == whoAmi && (wings == 3 || wings == 16 || wings == 17 || wings == 18 || wings == 19))
				{
					wingTime = 0f;
					jump = 0;
				}
				if (rocketBoots == 0)
				{
					rocketTime = 0;
				}
				if (jump == 0)
				{
					dJumpEffect = false;
					dJumpEffect2 = false;
					dJumpEffect3 = false;
					dJumpEffect4 = false;
				}
				DashMovement();
				WallslideMovement();
				CarpetMovement();
				DoubleJumpVisuals();
				if (wings > 0 || mount.Active)
				{
					sandStorm = false;
				}
				if (((gravDir == 1f && velocity.Y > 0f - jumpSpeed) || (gravDir == -1f && velocity.Y < jumpSpeed)) && velocity.Y != 0f)
				{
					canRocket = true;
				}
				bool flag14 = false;
				if (((velocity.Y == 0f || sliding) && releaseJump) || (autoJump && justJumped))
				{
					mount.ResetFlightTime(velocity.X);
					wingTime = wingTimeMax;
				}
				if (wingsLogic > 0 && controlJump && wingTime > 0f && !jumpAgain && jump == 0 && velocity.Y != 0f)
				{
					flag14 = true;
				}
				if (wingsLogic == 22 && controlJump && controlDown && wingTime > 0f)
				{
					flag14 = true;
				}
				if (frozen)
				{
					if (mount.Active)
					{
						mount.Dismount(this);
					}
					velocity.Y += gravity;
					if (velocity.Y > maxFallSpeed)
					{
						velocity.Y = maxFallSpeed;
					}
					sandStorm = false;
					dJumpEffect = false;
					dJumpEffect2 = false;
					dJumpEffect3 = false;
				}
				else
				{
					if (flag14)
					{
						if (wings == 10 && Main.rand.Next(2) == 0)
						{
							int num30 = 4;
							if (direction == 1)
							{
								num30 = -40;
							}
							int num31 = Dust.NewDust(new Vector2(position.X + (float)(width / 2) + (float)num30, position.Y + (float)(height / 2) - 15f), 30, 30, 76, 0f, 0f, 50, default(Color), 0.6f);
							Main.dust[num31].fadeIn = 1.1f;
							Main.dust[num31].noGravity = true;
							Main.dust[num31].noLight = true;
							Main.dust[num31].velocity *= 0.3f;
						}
						if (wings == 9 && Main.rand.Next(2) == 0)
						{
							int num32 = 4;
							if (direction == 1)
							{
								num32 = -40;
							}
							int num33 = Dust.NewDust(new Vector2(position.X + (float)(width / 2) + (float)num32, position.Y + (float)(height / 2) - 15f), 30, 30, 6, 0f, 0f, 200, default(Color), 2f);
							Main.dust[num33].noGravity = true;
							Main.dust[num33].velocity *= 0.3f;
						}
						if (wings == 6 && Main.rand.Next(4) == 0)
						{
							int num34 = 4;
							if (direction == 1)
							{
								num34 = -40;
							}
							int num35 = Dust.NewDust(new Vector2(position.X + (float)(width / 2) + (float)num34, position.Y + (float)(height / 2) - 15f), 30, 30, 55, 0f, 0f, 200);
							Main.dust[num35].velocity *= 0.3f;
						}
						if (wings == 5 && Main.rand.Next(3) == 0)
						{
							int num36 = 6;
							if (direction == 1)
							{
								num36 = -30;
							}
							int num37 = Dust.NewDust(new Vector2(position.X + (float)(width / 2) + (float)num36, position.Y), 18, height, 58, 0f, 0f, 255, default(Color), 1.2f);
							Main.dust[num37].velocity *= 0.3f;
						}
						if (wings == 26)
						{
							int num38 = 6;
							if (direction == 1)
							{
								num38 = -30;
							}
							int num39 = Dust.NewDust(new Vector2(position.X + (float)(width / 2) + (float)num38, position.Y), 18, height, 217, 0f, 0f, 100, default(Color), 1.4f);
							Main.dust[num39].noGravity = true;
							Main.dust[num39].noLight = true;
							Main.dust[num39].velocity /= 4f;
							Main.dust[num39].velocity -= velocity;
							if (Main.rand.Next(2) == 0)
							{
								num38 = -24;
								if (direction == 1)
								{
									num38 = 12;
								}
								float num40 = position.Y;
								if (gravDir == -1f)
								{
									num40 += (float)(height / 2);
								}
								num39 = Dust.NewDust(new Vector2(position.X + (float)(width / 2) + (float)num38, num40), 12, height / 2, 217, 0f, 0f, 100, default(Color), 1.4f);
								Main.dust[num39].noGravity = true;
								Main.dust[num39].noLight = true;
								Main.dust[num39].velocity /= 4f;
								Main.dust[num39].velocity -= velocity;
							}
						}
						WingMovement();
					}
					if (wings == 4)
					{
						if (flag14 || jump > 0)
						{
							rocketDelay2--;
							if (rocketDelay2 <= 0)
							{
								Main.PlaySound(2, (int)position.X, (int)position.Y, 13);
								rocketDelay2 = 60;
							}
							int num41 = 2;
							if (controlUp)
							{
								num41 = 4;
							}
							for (int num42 = 0; num42 < num41; num42++)
							{
								int type = 6;
								if (head == 41)
								{
									int body2 = body;
									int num191 = 24;
								}
								float scale = 1.75f;
								int alpha = 100;
								float x3 = position.X + (float)(width / 2) + 16f;
								if (direction > 0)
								{
									x3 = position.X + (float)(width / 2) - 26f;
								}
								float num43 = position.Y + (float)height - 18f;
								if (num42 == 1 || num42 == 3)
								{
									x3 = position.X + (float)(width / 2) + 8f;
									if (direction > 0)
									{
										x3 = position.X + (float)(width / 2) - 20f;
									}
									num43 += 6f;
								}
								if (num42 > 1)
								{
									num43 += velocity.Y;
								}
								int num44 = Dust.NewDust(new Vector2(x3, num43), 8, 8, type, 0f, 0f, alpha, default(Color), scale);
								Main.dust[num44].velocity.X *= 0.1f;
								Main.dust[num44].velocity.Y = Main.dust[num44].velocity.Y * 1f + 2f * gravDir - velocity.Y * 0.3f;
								Main.dust[num44].noGravity = true;
								if (num41 == 4)
								{
									Main.dust[num44].velocity.Y += 6f;
								}
							}
							wingFrameCounter++;
							if (wingFrameCounter > 4)
							{
								wingFrame++;
								wingFrameCounter = 0;
								if (wingFrame >= 3)
								{
									wingFrame = 0;
								}
							}
						}
						else if (!controlJump || velocity.Y == 0f)
						{
							wingFrame = 3;
						}
					}
					else if (wings == 22)
					{
						if (!controlJump)
						{
							wingFrame = 0;
							wingFrameCounter = 0;
						}
						else if (wingTime > 0f)
						{
							if (controlDown)
							{
								if (velocity.X != 0f)
								{
									wingFrameCounter++;
									int num45 = 2;
									if (wingFrameCounter < num45)
									{
										wingFrame = 1;
									}
									else if (wingFrameCounter < num45 * 2)
									{
										wingFrame = 2;
									}
									else if (wingFrameCounter < num45 * 3)
									{
										wingFrame = 3;
									}
									else if (wingFrameCounter < num45 * 4 - 1)
									{
										wingFrame = 2;
									}
									else
									{
										wingFrame = 2;
										wingFrameCounter = 0;
									}
								}
								else
								{
									wingFrameCounter++;
									int num46 = 6;
									if (wingFrameCounter < num46)
									{
										wingFrame = 4;
									}
									else if (wingFrameCounter < num46 * 2)
									{
										wingFrame = 5;
									}
									else if (wingFrameCounter < num46 * 3 - 1)
									{
										wingFrame = 4;
									}
									else
									{
										wingFrame = 4;
										wingFrameCounter = 0;
									}
								}
							}
							else
							{
								wingFrameCounter++;
								int num47 = 2;
								if (wingFrameCounter < num47)
								{
									wingFrame = 4;
								}
								else if (wingFrameCounter < num47 * 2)
								{
									wingFrame = 5;
								}
								else if (wingFrameCounter < num47 * 3)
								{
									wingFrame = 6;
								}
								else if (wingFrameCounter < num47 * 4 - 1)
								{
									wingFrame = 5;
								}
								else
								{
									wingFrame = 5;
									wingFrameCounter = 0;
								}
							}
						}
						else
						{
							wingFrameCounter++;
							int num48 = 6;
							if (wingFrameCounter < num48)
							{
								wingFrame = 4;
							}
							else if (wingFrameCounter < num48 * 2)
							{
								wingFrame = 5;
							}
							else if (wingFrameCounter < num48 * 3 - 1)
							{
								wingFrame = 4;
							}
							else
							{
								wingFrame = 4;
								wingFrameCounter = 0;
							}
						}
					}
					else if (wings == 12)
					{
						if (flag14 || jump > 0)
						{
							wingFrameCounter++;
							int num49 = 5;
							if (wingFrameCounter < num49)
							{
								wingFrame = 1;
							}
							else if (wingFrameCounter < num49 * 2)
							{
								wingFrame = 2;
							}
							else if (wingFrameCounter < num49 * 3)
							{
								wingFrame = 3;
							}
							else if (wingFrameCounter < num49 * 4 - 1)
							{
								wingFrame = 2;
							}
							else
							{
								wingFrame = 2;
								wingFrameCounter = 0;
							}
						}
						else if (velocity.Y != 0f)
						{
							wingFrame = 2;
						}
						else
						{
							wingFrame = 0;
						}
					}
					else if (wings == 24)
					{
						if (flag14 || jump > 0)
						{
							wingFrameCounter++;
							int num50 = 1;
							if (wingFrameCounter < num50)
							{
								wingFrame = 1;
							}
							else if (wingFrameCounter < num50 * 2)
							{
								wingFrame = 2;
							}
							else if (wingFrameCounter < num50 * 3)
							{
								wingFrame = 3;
							}
							else
							{
								wingFrame = 2;
								if (wingFrameCounter >= num50 * 4 - 1)
								{
									wingFrameCounter = 0;
								}
							}
						}
						else if (velocity.Y != 0f)
						{
							if (controlJump)
							{
								wingFrameCounter++;
								int num51 = 3;
								if (wingFrameCounter < num51)
								{
									wingFrame = 1;
								}
								else if (wingFrameCounter < num51 * 2)
								{
									wingFrame = 2;
								}
								else if (wingFrameCounter < num51 * 3)
								{
									wingFrame = 3;
								}
								else
								{
									wingFrame = 2;
									if (wingFrameCounter >= num51 * 4 - 1)
									{
										wingFrameCounter = 0;
									}
								}
							}
							else if (wingTime == 0f)
							{
								wingFrame = 0;
							}
							else
							{
								wingFrame = 1;
							}
						}
						else
						{
							wingFrame = 0;
						}
					}
					else if (flag14 || jump > 0)
					{
						wingFrameCounter++;
						if (wingFrameCounter > 4)
						{
							wingFrame++;
							wingFrameCounter = 0;
							if (wingFrame >= 4)
							{
								wingFrame = 0;
							}
						}
					}
					else if (velocity.Y != 0f)
					{
						wingFrame = 1;
					}
					else
					{
						wingFrame = 0;
					}
					if (wingsLogic > 0 && rocketBoots > 0 && velocity.Y != 0f)
					{
						wingTime += rocketTime * 6;
						rocketTime = 0;
					}
					if (flag14 && wings != 4 && wings != 22 && wings != 0 && wings != 24)
					{
						if (wingFrame == 3)
						{
							if (!flapSound)
							{
								Main.PlaySound(2, (int)position.X, (int)position.Y, 32);
							}
							flapSound = true;
						}
						else
						{
							flapSound = false;
						}
					}
					if (velocity.Y == 0f || sliding || (autoJump && justJumped))
					{
						rocketTime = rocketTimeMax;
					}
					if ((wingTime == 0f || wingsLogic == 0) && rocketBoots > 0 && controlJump && rocketDelay == 0 && canRocket && rocketRelease && !jumpAgain)
					{
						if (rocketTime > 0)
						{
							rocketTime--;
							rocketDelay = 10;
							if (rocketDelay2 <= 0)
							{
								if (rocketBoots == 1)
								{
									Main.PlaySound(2, (int)position.X, (int)position.Y, 13);
									rocketDelay2 = 30;
								}
								else if (rocketBoots == 2 || rocketBoots == 3)
								{
									Main.PlaySound(2, (int)position.X, (int)position.Y, 24);
									rocketDelay2 = 15;
								}
							}
						}
						else
						{
							canRocket = false;
						}
					}
					if (rocketDelay2 > 0)
					{
						rocketDelay2--;
					}
					if (rocketDelay == 0)
					{
						rocketFrame = false;
					}
					if (rocketDelay > 0)
					{
						int num52 = height;
						if (gravDir == -1f)
						{
							num52 = 4;
						}
						rocketFrame = true;
						for (int num53 = 0; num53 < 2; num53++)
						{
							int type2 = 6;
							float scale2 = 2.5f;
							int alpha2 = 100;
							if (rocketBoots == 2)
							{
								type2 = 16;
								scale2 = 1.5f;
								alpha2 = 20;
							}
							else if (rocketBoots == 3)
							{
								type2 = 76;
								scale2 = 1f;
								alpha2 = 20;
							}
							else if (socialShadow)
							{
								type2 = 27;
								scale2 = 1.5f;
							}
							if (num53 == 0)
							{
								int num54 = Dust.NewDust(new Vector2(position.X - 4f, position.Y + (float)num52 - 10f), 8, 8, type2, 0f, 0f, alpha2, default(Color), scale2);
								if (rocketBoots == 1)
								{
									Main.dust[num54].noGravity = true;
								}
								Main.dust[num54].velocity.X = Main.dust[num54].velocity.X * 1f - 2f - velocity.X * 0.3f;
								Main.dust[num54].velocity.Y = Main.dust[num54].velocity.Y * 1f + 2f * gravDir - velocity.Y * 0.3f;
								if (rocketBoots == 2)
								{
									Main.dust[num54].velocity *= 0.1f;
								}
								if (rocketBoots == 3)
								{
									Main.dust[num54].velocity *= 0.05f;
									Main.dust[num54].velocity.Y += 0.15f;
									Main.dust[num54].noLight = true;
									if (Main.rand.Next(2) == 0)
									{
										Main.dust[num54].noGravity = true;
										Main.dust[num54].scale = 1.75f;
									}
								}
								continue;
							}
							int num55 = Dust.NewDust(new Vector2(position.X + (float)width - 4f, position.Y + (float)num52 - 10f), 8, 8, type2, 0f, 0f, alpha2, default(Color), scale2);
							if (rocketBoots == 1)
							{
								Main.dust[num55].noGravity = true;
							}
							Main.dust[num55].velocity.X = Main.dust[num55].velocity.X * 1f + 2f - velocity.X * 0.3f;
							Main.dust[num55].velocity.Y = Main.dust[num55].velocity.Y * 1f + 2f * gravDir - velocity.Y * 0.3f;
							if (rocketBoots == 2)
							{
								Main.dust[num55].velocity *= 0.1f;
							}
							if (rocketBoots == 3)
							{
								Main.dust[num55].velocity *= 0.05f;
								Main.dust[num55].velocity.Y += 0.15f;
								Main.dust[num55].noLight = true;
								if (Main.rand.Next(2) == 0)
								{
									Main.dust[num55].noGravity = true;
									Main.dust[num55].scale = 1.75f;
								}
							}
						}
						if (rocketDelay == 0)
						{
							releaseJump = true;
						}
						rocketDelay--;
						velocity.Y -= 0.1f * gravDir;
						if (gravDir == 1f)
						{
							if (velocity.Y > 0f)
							{
								velocity.Y -= 0.5f;
							}
							else if ((double)velocity.Y > (double)(0f - jumpSpeed) * 0.5)
							{
								velocity.Y -= 0.1f;
							}
							if (velocity.Y < (0f - jumpSpeed) * 1.5f)
							{
								velocity.Y = (0f - jumpSpeed) * 1.5f;
							}
						}
						else
						{
							if (velocity.Y < 0f)
							{
								velocity.Y += 0.5f;
							}
							else if ((double)velocity.Y < (double)jumpSpeed * 0.5)
							{
								velocity.Y += 0.1f;
							}
							if (velocity.Y > jumpSpeed * 1.5f)
							{
								velocity.Y = jumpSpeed * 1.5f;
							}
						}
					}
					else if (!flag14)
					{
						if (mount.Type == 5)
						{
							mount.Hover(this);
						}
						else if (mount.CanFly && controlJump && jump == 0)
						{
							if (mount.Flight())
							{
								if (controlDown)
								{
									velocity.Y *= 0.9f;
									if (velocity.Y > -1f && (double)velocity.Y < 0.5)
									{
										velocity.Y = 1E-05f;
									}
								}
								else
								{
									if (velocity.Y > 0f)
									{
										velocity.Y -= 0.5f;
									}
									else if ((double)velocity.Y > (double)(0f - jumpSpeed) * 1.5)
									{
										velocity.Y -= 0.1f;
									}
									if (velocity.Y < (0f - jumpSpeed) * 1.5f)
									{
										velocity.Y = (0f - jumpSpeed) * 1.5f;
									}
								}
							}
							else
							{
								velocity.Y += gravity / 3f * gravDir;
								if (gravDir == 1f)
								{
									if (velocity.Y > maxFallSpeed / 3f && !controlDown)
									{
										velocity.Y = maxFallSpeed / 3f;
									}
								}
								else if (velocity.Y < (0f - maxFallSpeed) / 3f && !controlUp)
								{
									velocity.Y = (0f - maxFallSpeed) / 3f;
								}
							}
						}
						else if (slowFall && ((!controlDown && gravDir == 1f) || (!controlDown && gravDir == -1f)))
						{
							if ((controlUp && gravDir == 1f) || (controlUp && gravDir == -1f))
							{
								gravity = gravity / 10f * gravDir;
							}
							else
							{
								gravity = gravity / 3f * gravDir;
							}
							velocity.Y += gravity;
						}
						else if (wingsLogic > 0 && controlJump && velocity.Y > 0f)
						{
							fallStart = (int)(position.Y / 16f);
							if (velocity.Y > 0f)
							{
								if (wings == 10 && Main.rand.Next(3) == 0)
								{
									int num56 = 4;
									if (direction == 1)
									{
										num56 = -40;
									}
									int num57 = Dust.NewDust(new Vector2(position.X + (float)(width / 2) + (float)num56, position.Y + (float)(height / 2) - 15f), 30, 30, 76, 0f, 0f, 50, default(Color), 0.6f);
									Main.dust[num57].fadeIn = 1.1f;
									Main.dust[num57].noGravity = true;
									Main.dust[num57].noLight = true;
									Main.dust[num57].velocity *= 0.3f;
								}
								if (wings == 9 && Main.rand.Next(3) == 0)
								{
									int num58 = 8;
									if (direction == 1)
									{
										num58 = -40;
									}
									int num59 = Dust.NewDust(new Vector2(position.X + (float)(width / 2) + (float)num58, position.Y + (float)(height / 2) - 15f), 30, 30, 6, 0f, 0f, 200, default(Color), 2f);
									Main.dust[num59].noGravity = true;
									Main.dust[num59].velocity *= 0.3f;
								}
								if (wings == 6)
								{
									if (Main.rand.Next(10) == 0)
									{
										int num60 = 4;
										if (direction == 1)
										{
											num60 = -40;
										}
										int num61 = Dust.NewDust(new Vector2(position.X + (float)(width / 2) + (float)num60, position.Y + (float)(height / 2) - 12f), 30, 20, 55, 0f, 0f, 200);
										Main.dust[num61].velocity *= 0.3f;
									}
								}
								else if (wings == 5 && Main.rand.Next(6) == 0)
								{
									int num62 = 6;
									if (direction == 1)
									{
										num62 = -30;
									}
									int num63 = Dust.NewDust(new Vector2(position.X + (float)(width / 2) + (float)num62, position.Y), 18, height, 58, 0f, 0f, 255, default(Color), 1.2f);
									Main.dust[num63].velocity *= 0.3f;
								}
								if (wings == 4)
								{
									rocketDelay2--;
									if (rocketDelay2 <= 0)
									{
										Main.PlaySound(2, (int)position.X, (int)position.Y, 13);
										rocketDelay2 = 60;
									}
									int type3 = 6;
									float scale3 = 1.5f;
									int alpha3 = 100;
									float x4 = position.X + (float)(width / 2) + 16f;
									if (direction > 0)
									{
										x4 = position.X + (float)(width / 2) - 26f;
									}
									float num64 = position.Y + (float)height - 18f;
									if (Main.rand.Next(2) == 1)
									{
										x4 = position.X + (float)(width / 2) + 8f;
										if (direction > 0)
										{
											x4 = position.X + (float)(width / 2) - 20f;
										}
										num64 += 6f;
									}
									int num65 = Dust.NewDust(new Vector2(x4, num64), 8, 8, type3, 0f, 0f, alpha3, default(Color), scale3);
									Main.dust[num65].velocity.X *= 0.3f;
									Main.dust[num65].velocity.Y += 10f;
									Main.dust[num65].noGravity = true;
									wingFrameCounter++;
									if (wingFrameCounter > 4)
									{
										wingFrame++;
										wingFrameCounter = 0;
										if (wingFrame >= 3)
										{
											wingFrame = 0;
										}
									}
								}
								else if (wings != 22)
								{
									if (wings == 26)
									{
										int num66 = 6;
										if (direction == 1)
										{
											num66 = -30;
										}
										int num67 = Dust.NewDust(new Vector2(position.X + (float)(width / 2) + (float)num66, position.Y), 18, height, 217, 0f, 0f, 100, default(Color), 1.4f);
										Main.dust[num67].noGravity = true;
										Main.dust[num67].noLight = true;
										Main.dust[num67].velocity /= 4f;
										Main.dust[num67].velocity -= velocity;
										if (Main.rand.Next(2) == 0)
										{
											num66 = -24;
											if (direction == 1)
											{
												num66 = 12;
											}
											float num68 = position.Y;
											if (gravDir == -1f)
											{
												num68 += (float)(height / 2);
											}
											num67 = Dust.NewDust(new Vector2(position.X + (float)(width / 2) + (float)num66, num68), 12, height / 2, 217, 0f, 0f, 100, default(Color), 1.4f);
											Main.dust[num67].noGravity = true;
											Main.dust[num67].noLight = true;
											Main.dust[num67].velocity /= 4f;
											Main.dust[num67].velocity -= velocity;
										}
										wingFrame = 2;
									}
									else if (wings != 24)
									{
										if (wings == 12)
										{
											wingFrame = 3;
										}
										else
										{
											wingFrame = 2;
										}
									}
								}
							}
							velocity.Y += gravity / 3f * gravDir;
							if (gravDir == 1f)
							{
								if (velocity.Y > maxFallSpeed / 3f && !controlDown)
								{
									velocity.Y = maxFallSpeed / 3f;
								}
							}
							else if (velocity.Y < (0f - maxFallSpeed) / 3f && !controlUp)
							{
								velocity.Y = (0f - maxFallSpeed) / 3f;
							}
						}
						else if (cartRampTime <= 0)
						{
							velocity.Y += gravity * gravDir;
						}
						else
						{
							cartRampTime--;
						}
					}
					if (!mount.Active || mount.Type != 5)
					{
						if (gravDir == 1f)
						{
							if (velocity.Y > maxFallSpeed)
							{
								velocity.Y = maxFallSpeed;
							}
							if (slowFall && velocity.Y > maxFallSpeed / 3f && !controlDown)
							{
								velocity.Y = maxFallSpeed / 3f;
							}
							if (slowFall && velocity.Y > maxFallSpeed / 5f && controlUp)
							{
								velocity.Y = maxFallSpeed / 10f;
							}
						}
						else
						{
							if (velocity.Y < 0f - maxFallSpeed)
							{
								velocity.Y = 0f - maxFallSpeed;
							}
							if (slowFall && velocity.Y < (0f - maxFallSpeed) / 3f && !controlDown)
							{
								velocity.Y = (0f - maxFallSpeed) / 3f;
							}
							if (slowFall && velocity.Y < (0f - maxFallSpeed) / 5f && controlUp)
							{
								velocity.Y = (0f - maxFallSpeed) / 10f;
							}
						}
					}
				}
			}
			if (mount.Active)
			{
				wingFrame = 0;
			}
			if (wingsLogic == 3)
			{
				if (controlUp && controlDown)
				{
					velocity.Y = 0f;
				}
				else if (controlDown && controlJump)
				{
					velocity.Y *= 0.9f;
					if (velocity.Y > -2f && velocity.Y < 1f)
					{
						velocity.Y = 1E-05f;
					}
				}
				else if (controlDown && velocity.Y != 0f)
				{
					velocity.Y += 0.2f;
				}
			}
			if (wingsLogic == 22 && controlDown && controlJump && wingTime > 0f && !merman)
			{
				velocity.Y *= 0.9f;
				if (velocity.Y > -2f && velocity.Y < 1f)
				{
					velocity.Y = 1E-05f;
				}
			}
			for (int num69 = 0; num69 < 400; num69++)
			{
				if (!Main.item[num69].active || Main.item[num69].noGrabDelay != 0 || Main.item[num69].owner != i)
				{
					continue;
				}
				int num70 = defaultItemGrabRange;
				if (manaMagnet && (Main.item[num69].type == 184 || Main.item[num69].type == 1735 || Main.item[num69].type == 1868))
				{
					num70 += Item.manaGrabRange;
				}
				if (lifeMagnet && (Main.item[num69].type == 58 || Main.item[num69].type == 1734 || Main.item[num69].type == 1867))
				{
					num70 += Item.lifeGrabRange;
				}
				if (new Rectangle((int)position.X, (int)position.Y, width, height).Intersects(new Rectangle((int)Main.item[num69].position.X, (int)Main.item[num69].position.Y, Main.item[num69].width, Main.item[num69].height)))
				{
					if (i != Main.myPlayer || (inventory[selectedItem].type == 0 && itemAnimation > 0))
					{
						continue;
					}
					if (Main.item[num69].type == 58 || Main.item[num69].type == 1734 || Main.item[num69].type == 1867)
					{
						Main.PlaySound(7, (int)position.X, (int)position.Y);
						statLife += 20;
						if (Main.myPlayer == whoAmi)
						{
							HealEffect(20);
						}
						if (statLife > statLifeMax2)
						{
							statLife = statLifeMax2;
						}
						Main.item[num69] = new Item();
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", num69);
						}
					}
					else if (Main.item[num69].type == 184 || Main.item[num69].type == 1735 || Main.item[num69].type == 1868)
					{
						Main.PlaySound(7, (int)position.X, (int)position.Y);
						statMana += 100;
						if (Main.myPlayer == whoAmi)
						{
							ManaEffect(100);
						}
						if (statMana > statManaMax2)
						{
							statMana = statManaMax2;
						}
						Main.item[num69] = new Item();
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", num69);
						}
					}
					else
					{
						Main.item[num69] = GetItem(i, Main.item[num69]);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", num69);
						}
					}
				}
				else
				{
					if (!new Rectangle((int)position.X - num70, (int)position.Y - num70, width + num70 * 2, height + num70 * 2).Intersects(new Rectangle((int)Main.item[num69].position.X, (int)Main.item[num69].position.Y, Main.item[num69].width, Main.item[num69].height)) || !ItemSpace(Main.item[num69]))
					{
						continue;
					}
					Main.item[num69].beingGrabbed = true;
					if (manaMagnet && (Main.item[num69].type == 184 || Main.item[num69].type == 1735 || Main.item[num69].type == 1868))
					{
						float num71 = 12f;
						Vector2 vector = new Vector2(Main.item[num69].position.X + (float)(Main.item[num69].width / 2), Main.item[num69].position.Y + (float)(Main.item[num69].height / 2));
						float num72 = center().X - vector.X;
						float num73 = center().Y - vector.Y;
						float num74 = (float)Math.Sqrt(num72 * num72 + num73 * num73);
						num74 = num71 / num74;
						num72 *= num74;
						num73 *= num74;
						int num75 = 5;
						Main.item[num69].velocity.X = (Main.item[num69].velocity.X * (float)(num75 - 1) + num72) / (float)num75;
						Main.item[num69].velocity.Y = (Main.item[num69].velocity.Y * (float)(num75 - 1) + num73) / (float)num75;
						continue;
					}
					if (lifeMagnet && (Main.item[num69].type == 58 || Main.item[num69].type == 1734 || Main.item[num69].type == 1867))
					{
						float num76 = 15f;
						Vector2 vector2 = new Vector2(Main.item[num69].position.X + (float)(Main.item[num69].width / 2), Main.item[num69].position.Y + (float)(Main.item[num69].height / 2));
						float num77 = center().X - vector2.X;
						float num78 = center().Y - vector2.Y;
						float num79 = (float)Math.Sqrt(num77 * num77 + num78 * num78);
						num79 = num76 / num79;
						num77 *= num79;
						num78 *= num79;
						int num80 = 5;
						Main.item[num69].velocity.X = (Main.item[num69].velocity.X * (float)(num80 - 1) + num77) / (float)num80;
						Main.item[num69].velocity.Y = (Main.item[num69].velocity.Y * (float)(num80 - 1) + num78) / (float)num80;
						continue;
					}
					if ((double)position.X + (double)width * 0.5 > (double)Main.item[num69].position.X + (double)Main.item[num69].width * 0.5)
					{
						if (Main.item[num69].velocity.X < itemGrabSpeedMax + velocity.X)
						{
							Main.item[num69].velocity.X += itemGrabSpeed;
						}
						if (Main.item[num69].velocity.X < 0f)
						{
							Main.item[num69].velocity.X += itemGrabSpeed * 0.75f;
						}
					}
					else
					{
						if (Main.item[num69].velocity.X > 0f - itemGrabSpeedMax + velocity.X)
						{
							Main.item[num69].velocity.X -= itemGrabSpeed;
						}
						if (Main.item[num69].velocity.X > 0f)
						{
							Main.item[num69].velocity.X -= itemGrabSpeed * 0.75f;
						}
					}
					if ((double)position.Y + (double)height * 0.5 > (double)Main.item[num69].position.Y + (double)Main.item[num69].height * 0.5)
					{
						if (Main.item[num69].velocity.Y < itemGrabSpeedMax)
						{
							Main.item[num69].velocity.Y += itemGrabSpeed;
						}
						if (Main.item[num69].velocity.Y < 0f)
						{
							Main.item[num69].velocity.Y += itemGrabSpeed * 0.75f;
						}
					}
					else
					{
						if (Main.item[num69].velocity.Y > 0f - itemGrabSpeedMax)
						{
							Main.item[num69].velocity.Y -= itemGrabSpeed;
						}
						if (Main.item[num69].velocity.Y > 0f)
						{
							Main.item[num69].velocity.Y -= itemGrabSpeed * 0.75f;
						}
					}
				}
			}
			if (!Main.mapFullscreen)
			{
				if (position.X / 16f - (float)tileRangeX <= (float)tileTargetX && (position.X + (float)width) / 16f + (float)tileRangeX - 1f >= (float)tileTargetX && position.Y / 16f - (float)tileRangeY <= (float)tileTargetY && (position.Y + (float)height) / 16f + (float)tileRangeY - 2f >= (float)tileTargetY)
				{
					if (Main.tile[tileTargetX, tileTargetY] == null)
					{
						Main.tile[tileTargetX, tileTargetY] = new Tile();
					}
					if (Main.tile[tileTargetX, tileTargetY].active())
					{
						if (Main.tile[tileTargetX, tileTargetY].type == 104)
						{
							noThrow = 2;
							showItemIcon = true;
							switch (Main.tile[tileTargetX, tileTargetY].frameX / 36)
							{
							case 0:
								showItemIcon2 = 359;
								break;
							case 1:
								showItemIcon2 = 2237;
								break;
							case 2:
								showItemIcon2 = 2238;
								break;
							case 3:
								showItemIcon2 = 2239;
								break;
							case 4:
								showItemIcon2 = 2240;
								break;
							case 5:
								showItemIcon2 = 2241;
								break;
							case 6:
								showItemIcon2 = 2560;
								break;
							case 7:
								showItemIcon2 = 2575;
								break;
							case 8:
								showItemIcon2 = 2591;
								break;
							case 9:
								showItemIcon2 = 2592;
								break;
							case 10:
								showItemIcon2 = 2593;
								break;
							case 11:
								showItemIcon2 = 2594;
								break;
							case 12:
								showItemIcon2 = 2595;
								break;
							case 13:
								showItemIcon2 = 2596;
								break;
							case 14:
								showItemIcon2 = 2597;
								break;
							case 15:
								showItemIcon2 = 2598;
								break;
							case 16:
								showItemIcon2 = 2599;
								break;
							case 17:
								showItemIcon2 = 2600;
								break;
							case 18:
								showItemIcon2 = 2601;
								break;
							case 19:
								showItemIcon2 = 2602;
								break;
							case 20:
								showItemIcon2 = 2603;
								break;
							case 21:
								showItemIcon2 = 2604;
								break;
							case 22:
								showItemIcon2 = 2605;
								break;
							case 23:
								showItemIcon2 = 2606;
								break;
							}
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 79)
						{
							noThrow = 2;
							showItemIcon = true;
							int num81 = Main.tile[tileTargetX, tileTargetY].frameY / 36;
							switch (num81)
							{
							case 0:
								showItemIcon2 = 224;
								break;
							case 1:
								showItemIcon2 = 644;
								break;
							case 2:
								showItemIcon2 = 645;
								break;
							case 3:
								showItemIcon2 = 646;
								break;
							case 4:
								showItemIcon2 = 920;
								break;
							case 5:
								showItemIcon2 = 1470;
								break;
							case 6:
								showItemIcon2 = 1471;
								break;
							case 7:
								showItemIcon2 = 1472;
								break;
							case 8:
								showItemIcon2 = 1473;
								break;
							case 9:
								showItemIcon2 = 1719;
								break;
							case 10:
								showItemIcon2 = 1720;
								break;
							case 11:
								showItemIcon2 = 1721;
								break;
							case 12:
								showItemIcon2 = 1722;
								break;
							case 13:
							case 14:
							case 15:
							case 16:
							case 17:
							case 18:
								showItemIcon2 = 2066 + num81 - 13;
								break;
							default:
								if (num81 >= 19 && num81 <= 20)
								{
									showItemIcon2 = 2139 + num81 - 19;
									break;
								}
								switch (num81)
								{
								case 21:
									showItemIcon2 = 2231;
									break;
								case 22:
									showItemIcon2 = 2520;
									break;
								case 23:
									showItemIcon2 = 2538;
									break;
								case 24:
									showItemIcon2 = 2553;
									break;
								case 26:
									showItemIcon2 = 2568;
									break;
								case 27:
									showItemIcon2 = 2669;
									break;
								default:
									showItemIcon2 = 646;
									break;
								}
								break;
							}
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 209)
						{
							noThrow = 2;
							showItemIcon = true;
							if (Main.tile[tileTargetX, tileTargetY].frameX < 72)
							{
								showItemIcon2 = 928;
							}
							else if (Main.tile[tileTargetX, tileTargetY].frameX < 144)
							{
								showItemIcon2 = 1337;
							}
							int num82;
							for (num82 = Main.tile[tileTargetX, tileTargetY].frameX / 18; num82 >= 4; num82 -= 4)
							{
							}
							if (num82 < 2)
							{
								showItemIconR = true;
							}
							else
							{
								showItemIconR = false;
							}
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 216)
						{
							noThrow = 2;
							showItemIcon = true;
							int num83 = Main.tile[tileTargetX, tileTargetY].frameY;
							int num84 = 0;
							while (num83 >= 40)
							{
								num83 -= 40;
								num84++;
							}
							showItemIcon2 = 970 + num84;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 335)
						{
							noThrow = 2;
							showItemIcon = true;
							showItemIcon2 = 2700;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 338)
						{
							noThrow = 2;
							showItemIcon = true;
							showItemIcon2 = 2738;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 219 && (inventory[selectedItem].type == 424 || inventory[selectedItem].type == 1103))
						{
							noThrow = 2;
							showItemIcon = true;
							showItemIcon2 = inventory[selectedItem].type;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 212)
						{
							noThrow = 2;
							showItemIcon = true;
							showItemIcon2 = 949;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 314 && gravDir == 1f)
						{
							showItemIcon = true;
							showItemIcon2 = 2343;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 21)
						{
							Tile tile = Main.tile[tileTargetX, tileTargetY];
							int num85 = tileTargetX;
							int num86 = tileTargetY;
							if (tile.frameX % 36 != 0)
							{
								num85--;
							}
							if (tile.frameY % 36 != 0)
							{
								num86--;
							}
							int num87 = Chest.FindChest(num85, num86);
							showItemIcon2 = -1;
							if (num87 < 0)
							{
								showItemIconText = Lang.chestType[0];
							}
							else
							{
								if (Main.chest[num87].name != "")
								{
									showItemIconText = Main.chest[num87].name;
								}
								else
								{
									showItemIconText = Lang.chestType[tile.frameX / 36];
								}
								if (showItemIconText == Lang.chestType[tile.frameX / 36])
								{
									showItemIcon2 = Chest.typeToIcon[tile.frameX / 36];
									showItemIconText = "";
								}
							}
							noThrow = 2;
							showItemIcon = true;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 4)
						{
							noThrow = 2;
							showItemIcon = true;
							int num88 = Main.tile[tileTargetX, tileTargetY].frameY / 22;
							switch (num88)
							{
							case 0:
								showItemIcon2 = 8;
								break;
							case 8:
								showItemIcon2 = 523;
								break;
							case 9:
								showItemIcon2 = 974;
								break;
							case 10:
								showItemIcon2 = 1245;
								break;
							case 11:
								showItemIcon2 = 1333;
								break;
							case 12:
								showItemIcon2 = 2274;
								break;
							default:
								showItemIcon2 = 426 + num88;
								break;
							}
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 13)
						{
							noThrow = 2;
							showItemIcon = true;
							switch (Main.tile[tileTargetX, tileTargetY].frameX / 18)
							{
							case 1:
								showItemIcon2 = 28;
								break;
							case 2:
								showItemIcon2 = 110;
								break;
							case 3:
								showItemIcon2 = 350;
								break;
							case 4:
								showItemIcon2 = 351;
								break;
							case 5:
								showItemIcon2 = 2234;
								break;
							case 6:
								showItemIcon2 = 2244;
								break;
							case 7:
								showItemIcon2 = 2257;
								break;
							case 8:
								showItemIcon2 = 2258;
								break;
							default:
								showItemIcon2 = 31;
								break;
							}
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 29)
						{
							noThrow = 2;
							showItemIcon = true;
							showItemIcon2 = 87;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 97)
						{
							noThrow = 2;
							showItemIcon = true;
							showItemIcon2 = 346;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 33)
						{
							noThrow = 2;
							showItemIcon = true;
							showItemIcon2 = 105;
							int num89 = Main.tile[tileTargetX, tileTargetY].frameY / 22;
							if (num89 == 1)
							{
								showItemIcon2 = 1405;
							}
							if (num89 == 2)
							{
								showItemIcon2 = 1406;
							}
							if (num89 == 3)
							{
								showItemIcon2 = 1407;
							}
							if (num89 >= 4 && num89 <= 13)
							{
								showItemIcon2 = 2045 + num89 - 4;
							}
							if (num89 >= 14 && num89 <= 16)
							{
								showItemIcon2 = 2153 + num89 - 14;
							}
							if (num89 == 17)
							{
								showItemIcon2 = 2236;
							}
							if (num89 == 18)
							{
								showItemIcon2 = 2523;
							}
							if (num89 == 19)
							{
								showItemIcon2 = 2542;
							}
							if (num89 == 20)
							{
								showItemIcon2 = 2556;
							}
							if (num89 == 21)
							{
								showItemIcon2 = 2571;
							}
							if (num89 == 22)
							{
								showItemIcon2 = 2648;
							}
							if (num89 == 23)
							{
								showItemIcon2 = 2649;
							}
							if (num89 == 24)
							{
								showItemIcon2 = 2650;
							}
							if (num89 == 25)
							{
								showItemIcon2 = 2651;
							}
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 49)
						{
							noThrow = 2;
							showItemIcon = true;
							showItemIcon2 = 148;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 174)
						{
							noThrow = 2;
							showItemIcon = true;
							showItemIcon2 = 713;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 50)
						{
							noThrow = 2;
							if (Main.tile[tileTargetX, tileTargetY].frameX == 90)
							{
								showItemIcon = true;
								showItemIcon2 = 165;
							}
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 139)
						{
							noThrow = 2;
							int num90 = tileTargetX;
							int num91 = tileTargetY;
							int num92 = 0;
							for (int num93 = Main.tile[num90, num91].frameY / 18; num93 >= 2; num93 -= 2)
							{
								num92++;
							}
							showItemIcon = true;
							if (num92 == 28)
							{
								showItemIcon2 = 1963;
							}
							else if (num92 == 29)
							{
								showItemIcon2 = 1964;
							}
							else if (num92 == 30)
							{
								showItemIcon2 = 1965;
							}
							else if (num92 == 31)
							{
								showItemIcon2 = 2742;
							}
							else if (num92 >= 13)
							{
								showItemIcon2 = 1596 + num92 - 13;
							}
							else
							{
								showItemIcon2 = 562 + num92;
							}
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 207)
						{
							noThrow = 2;
							int num94 = tileTargetX;
							int num95 = tileTargetY;
							int num96 = 0;
							for (int num97 = Main.tile[num94, num95].frameX / 18; num97 >= 2; num97 -= 2)
							{
								num96++;
							}
							showItemIcon = true;
							switch (num96)
							{
							case 0:
								showItemIcon2 = 909;
								break;
							case 1:
								showItemIcon2 = 910;
								break;
							case 2:
								showItemIcon2 = 940;
								break;
							case 3:
								showItemIcon2 = 941;
								break;
							case 4:
								showItemIcon2 = 942;
								break;
							case 5:
								showItemIcon2 = 943;
								break;
							case 6:
								showItemIcon2 = 944;
								break;
							case 7:
								showItemIcon2 = 945;
								break;
							}
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 55 || Main.tile[tileTargetX, tileTargetY].type == 85)
						{
							noThrow = 2;
							int num98 = Main.tile[tileTargetX, tileTargetY].frameX / 18;
							int num99 = Main.tile[tileTargetX, tileTargetY].frameY / 18;
							while (num98 > 1)
							{
								num98 -= 2;
							}
							int num100 = tileTargetX - num98;
							int num101 = tileTargetY - num99;
							Main.signBubble = true;
							Main.signX = num100 * 16 + 16;
							Main.signY = num101 * 16;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 237)
						{
							noThrow = 2;
							showItemIcon = true;
							showItemIcon2 = 1293;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 88)
						{
							noThrow = 2;
							showItemIcon = true;
							int num102 = Main.tile[tileTargetX, tileTargetY].frameX / 54;
							switch (num102)
							{
							case 0:
								showItemIcon2 = 334;
								break;
							case 1:
								showItemIcon2 = 647;
								break;
							case 2:
								showItemIcon2 = 648;
								break;
							case 3:
								showItemIcon2 = 649;
								break;
							case 4:
								showItemIcon2 = 918;
								break;
							case 5:
							case 6:
							case 7:
							case 8:
							case 9:
							case 10:
							case 11:
							case 12:
							case 13:
							case 14:
							case 15:
								showItemIcon2 = 2386 + num102 - 5;
								break;
							default:
								switch (num102)
								{
								case 16:
									showItemIcon2 = 2529;
									break;
								case 17:
									showItemIcon2 = 2545;
									break;
								case 18:
									showItemIcon2 = 2562;
									break;
								case 19:
									showItemIcon2 = 2577;
									break;
								case 20:
									showItemIcon2 = 2637;
									break;
								case 21:
									showItemIcon2 = 2638;
									break;
								case 22:
									showItemIcon2 = 2639;
									break;
								case 23:
									showItemIcon2 = 2640;
									break;
								}
								break;
							}
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 10 || Main.tile[tileTargetX, tileTargetY].type == 11)
						{
							noThrow = 2;
							showItemIcon = true;
							int num103 = Main.tile[tileTargetX, tileTargetY].frameY;
							int num104 = 0;
							while (num103 >= 54)
							{
								num103 -= 54;
								num104++;
							}
							switch (num104)
							{
							case 0:
								showItemIcon2 = 25;
								break;
							case 9:
								showItemIcon2 = 837;
								break;
							case 10:
								showItemIcon2 = 912;
								break;
							case 11:
								showItemIcon2 = 1141;
								break;
							case 12:
								showItemIcon2 = 1137;
								break;
							case 13:
								showItemIcon2 = 1138;
								break;
							case 14:
								showItemIcon2 = 1139;
								break;
							case 15:
								showItemIcon2 = 1140;
								break;
							case 16:
								showItemIcon2 = 1411;
								break;
							case 17:
								showItemIcon2 = 1412;
								break;
							case 18:
								showItemIcon2 = 1413;
								break;
							case 19:
								showItemIcon2 = 1458;
								break;
							case 20:
							case 21:
							case 22:
							case 23:
								showItemIcon2 = 1709 + num104 - 20;
								break;
							default:
								switch (num104)
								{
								case 24:
									showItemIcon2 = 1793;
									break;
								case 25:
									showItemIcon2 = 1815;
									break;
								case 26:
									showItemIcon2 = 1924;
									break;
								case 27:
									showItemIcon2 = 2044;
									break;
								case 28:
									showItemIcon2 = 2265;
									break;
								case 29:
									showItemIcon2 = 2528;
									break;
								case 30:
									showItemIcon2 = 2561;
									break;
								case 31:
									showItemIcon2 = 2576;
									break;
								case 4:
								case 5:
								case 6:
								case 7:
								case 8:
									showItemIcon2 = 812 + num104;
									break;
								default:
									showItemIcon2 = 649 + num104;
									break;
								}
								break;
							}
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 125)
						{
							noThrow = 2;
							showItemIcon = true;
							showItemIcon2 = 487;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 287)
						{
							noThrow = 2;
							showItemIcon = true;
							showItemIcon2 = 2177;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 132)
						{
							noThrow = 2;
							showItemIcon = true;
							showItemIcon2 = 513;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 136)
						{
							noThrow = 2;
							showItemIcon = true;
							showItemIcon2 = 538;
						}
						if (Main.tile[tileTargetX, tileTargetY].type == 144)
						{
							noThrow = 2;
							showItemIcon = true;
							showItemIcon2 = 583 + Main.tile[tileTargetX, tileTargetY].frameX / 18;
						}
						if (controlUseTile)
						{
							if (Main.tile[tileTargetX, tileTargetY].type == 212 && launcherWait <= 0)
							{
								int num105 = tileTargetX;
								int num106 = tileTargetY;
								bool flag15 = false;
								for (int num107 = 0; num107 < 58; num107++)
								{
									if (inventory[num107].type == 949 && inventory[num107].stack > 0)
									{
										inventory[num107].stack--;
										if (inventory[num107].stack <= 0)
										{
											inventory[num107].SetDefaults(0);
										}
										flag15 = true;
										break;
									}
								}
								if (flag15)
								{
									launcherWait = 10;
									Main.PlaySound(2, (int)position.X, (int)position.Y, 11);
									int num108 = Main.tile[num105, num106].frameX / 18;
									int num109 = 0;
									while (num108 >= 3)
									{
										num109++;
										num108 -= 3;
									}
									num108 = num105 - num108;
									int num110;
									for (num110 = Main.tile[num105, num106].frameY / 18; num110 >= 3; num110 -= 3)
									{
									}
									num110 = num106 - num110;
									float num111 = 12f + (float)Main.rand.Next(450) * 0.01f;
									float num112 = Main.rand.Next(85, 105);
									float num113 = Main.rand.Next(-35, 11);
									int type4 = 166;
									int damage = 17;
									float knockBack = 3.5f;
									Vector2 vector3 = new Vector2((num108 + 2) * 16 - 8, (num110 + 2) * 16 - 8);
									if (num109 == 0)
									{
										num112 *= -1f;
										vector3.X -= 12f;
									}
									else
									{
										vector3.X += 12f;
									}
									float num114 = num112;
									float num115 = num113;
									float num116 = (float)Math.Sqrt(num114 * num114 + num115 * num115);
									num116 = num111 / num116;
									num114 *= num116;
									num115 *= num116;
									Projectile.NewProjectile(vector3.X, vector3.Y, num114, num115, type4, damage, knockBack, Main.myPlayer);
								}
							}
							if (releaseUseTile)
							{
								if (Main.tile[tileTargetX, tileTargetY].type == 132 || Main.tile[tileTargetX, tileTargetY].type == 136 || Main.tile[tileTargetX, tileTargetY].type == 144)
								{
									Wiring.hitSwitch(tileTargetX, tileTargetY);
									NetMessage.SendData(59, -1, -1, "", tileTargetX, tileTargetY);
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 139)
								{
									Main.PlaySound(28, tileTargetX * 16, tileTargetY * 16, 0);
									WorldGen.SwitchMB(tileTargetX, tileTargetY);
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 207)
								{
									Main.PlaySound(28, tileTargetX * 16, tileTargetY * 16, 0);
									WorldGen.SwitchFountain(tileTargetX, tileTargetY);
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 216)
								{
									WorldGen.LaunchRocket(tileTargetX, tileTargetY);
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 335)
								{
									WorldGen.LaunchRocketSmall(tileTargetX, tileTargetY);
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 338)
								{
									int num117 = tileTargetX;
									int num118 = tileTargetY;
									if (Main.tile[num117, num118].frameY == 18)
									{
										num118--;
									}
									bool flag16 = false;
									for (int num119 = 0; num119 < 1000; num119++)
									{
										if (Main.projectile[num119].active && Main.projectile[num119].aiStyle == 73 && Main.projectile[num119].ai[0] == (float)num117 && Main.projectile[num119].ai[1] == (float)num118)
										{
											flag16 = true;
											break;
										}
									}
									if (!flag16)
									{
										Projectile.NewProjectile(num117 * 16 + 8, num118 * 16 + 2, 0f, 0f, 419 + Main.rand.Next(4), 0, 0f, whoAmi, num117, num118);
									}
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 4 || Main.tile[tileTargetX, tileTargetY].type == 13 || Main.tile[tileTargetX, tileTargetY].type == 33 || Main.tile[tileTargetX, tileTargetY].type == 49 || (Main.tile[tileTargetX, tileTargetY].type == 50 && Main.tile[tileTargetX, tileTargetY].frameX == 90) || Main.tile[tileTargetX, tileTargetY].type == 174)
								{
									WorldGen.KillTile(tileTargetX, tileTargetY);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 0, tileTargetX, tileTargetY);
									}
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 334)
								{
									if (ItemFitsWeaponRack(inventory[selectedItem]))
									{
										PlaceWeapon(tileTargetX, tileTargetY);
									}
									else
									{
										int num120 = tileTargetX;
										int num121 = tileTargetY;
										if (Main.tile[tileTargetX, tileTargetY].frameY == 0)
										{
											num121++;
										}
										if (Main.tile[tileTargetX, tileTargetY].frameY == 36)
										{
											num121--;
										}
										int frameX = Main.tile[tileTargetX, num121].frameX;
										int num122 = Main.tile[tileTargetX, num121].frameX;
										int num123 = 0;
										while (num122 >= 5000)
										{
											num122 -= 5000;
											num123++;
										}
										if (num123 != 0)
										{
											num122 = (num123 - 1) * 18;
										}
										num122 %= 54;
										if (num122 == 18)
										{
											frameX = Main.tile[tileTargetX - 1, num121].frameX;
											num120--;
										}
										if (num122 == 36)
										{
											frameX = Main.tile[tileTargetX - 2, num121].frameX;
											num120 -= 2;
										}
										if (frameX >= 5000)
										{
											WorldGen.KillTile(tileTargetX, num121, true);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, tileTargetX, num121, 1f);
											}
										}
									}
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 125)
								{
									AddBuff(29, 36000);
									Main.PlaySound(2, (int)position.X, (int)position.Y, 4);
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 287)
								{
									AddBuff(93, 36000);
									Main.PlaySound(7, (int)position.X, (int)position.Y);
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 79)
								{
									int num124 = tileTargetX;
									int num125 = tileTargetY;
									num124 += Main.tile[tileTargetX, tileTargetY].frameX / 18 * -1;
									if (Main.tile[tileTargetX, tileTargetY].frameX >= 72)
									{
										num124 += 4;
										num124++;
									}
									else
									{
										num124 += 2;
									}
									int num126 = Main.tile[tileTargetX, tileTargetY].frameY / 18;
									int num127 = 0;
									while (num126 > 1)
									{
										num126 -= 2;
										num127++;
									}
									num125 -= num126;
									num125 += 2;
									if (CheckSpawn(num124, num125))
									{
										ChangeSpawn(num124, num125);
										Main.NewText("Spawn point set!", byte.MaxValue, 240, 20);
									}
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 55 || Main.tile[tileTargetX, tileTargetY].type == 85)
								{
									bool flag17 = true;
									if (sign >= 0)
									{
										int num128 = Sign.ReadSign(tileTargetX, tileTargetY);
										if (num128 == sign)
										{
											sign = -1;
											Main.npcChatText = "";
											Main.editSign = false;
											Main.PlaySound(11);
											flag17 = false;
										}
									}
									if (flag17)
									{
										if (Main.netMode == 0)
										{
											talkNPC = -1;
											Main.npcChatCornerItem = 0;
											Main.playerInventory = false;
											Main.editSign = false;
											Main.PlaySound(10);
											int num129 = (sign = Sign.ReadSign(tileTargetX, tileTargetY));
											Main.npcChatText = Main.sign[num129].text;
										}
										else
										{
											int num130 = Main.tile[tileTargetX, tileTargetY].frameX / 18;
											int num131 = Main.tile[tileTargetX, tileTargetY].frameY / 18;
											while (num130 > 1)
											{
												num130 -= 2;
											}
											int num132 = tileTargetX - num130;
											int num133 = tileTargetY - num131;
											if (Main.tile[num132, num133].type == 55 || Main.tile[num132, num133].type == 85)
											{
												NetMessage.SendData(46, -1, -1, "", num132, num133);
											}
										}
									}
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 104)
								{
									string text2 = "AM";
									double num134 = Main.time;
									if (!Main.dayTime)
									{
										num134 += 54000.0;
									}
									num134 = num134 / 86400.0 * 24.0;
									double num135 = 7.5;
									num134 = num134 - num135 - 12.0;
									if (num134 < 0.0)
									{
										num134 += 24.0;
									}
									if (num134 >= 12.0)
									{
										text2 = "PM";
									}
									int num136 = (int)num134;
									double num137 = num134 - (double)num136;
									num137 = (int)(num137 * 60.0);
									string text3 = string.Concat(num137);
									if (num137 < 10.0)
									{
										text3 = "0" + text3;
									}
									if (num136 > 12)
									{
										num136 -= 12;
									}
									if (num136 == 0)
									{
										num136 = 12;
									}
									string newText = "Time: " + num136 + ":" + text3 + " " + text2;
									Main.NewText(newText, byte.MaxValue, 240, 20);
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 237)
								{
									bool flag18 = false;
									if (!NPC.AnyNPCs(245) && Main.hardMode && NPC.downedPlantBoss)
									{
										for (int num138 = 0; num138 < 58; num138++)
										{
											if (inventory[num138].type == 1293)
											{
												inventory[num138].stack--;
												if (inventory[num138].stack <= 0)
												{
													inventory[num138].SetDefaults(0);
												}
												flag18 = true;
												break;
											}
										}
									}
									if (flag18)
									{
										Main.PlaySound(15, (int)position.X, (int)position.Y, 0);
										if (Main.netMode != 1)
										{
											NPC.SpawnOnPlayer(i, 245);
										}
										else
										{
											NetMessage.SendData(61, -1, -1, "", whoAmi, 245f);
										}
									}
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 10)
								{
									int num139 = tileTargetX;
									int num140 = tileTargetY;
									if (Main.tile[num139, num140].frameY >= 594 && Main.tile[num139, num140].frameY <= 646)
									{
										int num141 = 1141;
										for (int num142 = 0; num142 < 58; num142++)
										{
											if (inventory[num142].type == num141 && inventory[num142].stack > 0)
											{
												inventory[num142].stack--;
												if (inventory[num142].stack <= 0)
												{
													inventory[num142] = new Item();
												}
												WorldGen.UnlockDoor(num139, num140);
												if (Main.netMode == 1)
												{
													NetMessage.SendData(52, -1, -1, "", whoAmi, 2f, num139, num140);
												}
											}
										}
									}
									else
									{
										WorldGen.OpenDoor(tileTargetX, tileTargetY, direction);
										NetMessage.SendData(19, -1, -1, "", 0, tileTargetX, tileTargetY, direction);
									}
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 11 && WorldGen.CloseDoor(tileTargetX, tileTargetY))
								{
									NetMessage.SendData(19, -1, -1, "", 1, tileTargetX, tileTargetY, direction);
								}
								if (Main.tile[tileTargetX, tileTargetY].type == 88)
								{
									Main.dresserX = tileTargetX;
									Main.dresserY = tileTargetY;
									Main.OpenClothesWindow();
								}
								if (Main.tile[tileTargetX, tileTargetY].type == 209)
								{
									WorldGen.SwitchCannon(tileTargetX, tileTargetY);
								}
								else if ((Main.tile[tileTargetX, tileTargetY].type == 21 || Main.tile[tileTargetX, tileTargetY].type == 29 || Main.tile[tileTargetX, tileTargetY].type == 97) && talkNPC == -1)
								{
									Main.mouseRightRelease = false;
									int num143 = 0;
									int num144;
									for (num144 = Main.tile[tileTargetX, tileTargetY].frameX / 18; num144 > 1; num144 -= 2)
									{
									}
									num144 = tileTargetX - num144;
									int num145 = tileTargetY - Main.tile[tileTargetX, tileTargetY].frameY / 18;
									if (Main.tile[tileTargetX, tileTargetY].type == 29)
									{
										num143 = 1;
									}
									else if (Main.tile[tileTargetX, tileTargetY].type == 97)
									{
										num143 = 2;
									}
									if (sign > -1)
									{
										Main.PlaySound(11);
										sign = -1;
										Main.editSign = false;
										Main.npcChatText = string.Empty;
									}
									if (Main.editChest)
									{
										Main.PlaySound(12);
										Main.editChest = false;
										Main.npcChatText = string.Empty;
									}
									if (editedChestName)
									{
										NetMessage.SendData(33, -1, -1, Main.chest[chest].name, chest, 1f);
										editedChestName = false;
									}
									if (Main.netMode == 1 && num143 == 0 && (Main.tile[num144, num145].frameX < 72 || Main.tile[num144, num145].frameX > 106) && (Main.tile[num144, num145].frameX < 144 || Main.tile[num144, num145].frameX > 178) && (Main.tile[num144, num145].frameX < 828 || Main.tile[num144, num145].frameX > 1006) && (Main.tile[num144, num145].frameX < 1296 || Main.tile[num144, num145].frameX > 1330) && (Main.tile[num144, num145].frameX < 1368 || Main.tile[num144, num145].frameX > 1402) && (Main.tile[num144, num145].frameX < 1440 || Main.tile[num144, num145].frameX > 1474))
									{
										if (num144 == chestX && num145 == chestY && chest != -1)
										{
											chest = -1;
											Main.PlaySound(11);
										}
										else
										{
											NetMessage.SendData(31, -1, -1, "", num144, num145);
											Main.stackSplit = 600;
										}
									}
									else
									{
										int num146 = -1;
										switch (num143)
										{
										case 1:
											num146 = -2;
											break;
										case 2:
											num146 = -3;
											break;
										default:
										{
											bool flag19 = false;
											if ((Main.tile[num144, num145].frameX >= 72 && Main.tile[num144, num145].frameX <= 106) || (Main.tile[num144, num145].frameX >= 144 && Main.tile[num144, num145].frameX <= 178) || (Main.tile[num144, num145].frameX >= 828 && Main.tile[num144, num145].frameX <= 1006) || (Main.tile[num144, num145].frameX >= 1296 && Main.tile[num144, num145].frameX <= 1330) || (Main.tile[num144, num145].frameX >= 1368 && Main.tile[num144, num145].frameX <= 1402) || (Main.tile[num144, num145].frameX >= 1440 && Main.tile[num144, num145].frameX <= 1474))
											{
												int num147 = 327;
												if (Main.tile[num144, num145].frameX >= 144 && Main.tile[num144, num145].frameX <= 178)
												{
													num147 = 329;
												}
												if (Main.tile[num144, num145].frameX >= 828 && Main.tile[num144, num145].frameX <= 1006)
												{
													int num148 = Main.tile[num144, num145].frameX / 18;
													int num149 = 0;
													while (num148 >= 2)
													{
														num148 -= 2;
														num149++;
													}
													num149 -= 23;
													num147 = 1533 + num149;
												}
												flag19 = true;
												for (int num150 = 0; num150 < 58; num150++)
												{
													if (inventory[num150].type != num147 || inventory[num150].stack <= 0)
													{
														continue;
													}
													if (num147 != 329)
													{
														inventory[num150].stack--;
														if (inventory[num150].stack <= 0)
														{
															inventory[num150] = new Item();
														}
													}
													Chest.Unlock(num144, num145);
													if (Main.netMode == 1)
													{
														NetMessage.SendData(52, -1, -1, "", whoAmi, 1f, num144, num145);
													}
												}
											}
											if (!flag19)
											{
												num146 = Chest.FindChest(num144, num145);
											}
											break;
										}
										}
										if (num146 != -1)
										{
											Main.stackSplit = 600;
											if (num146 == chest)
											{
												chest = -1;
												Main.PlaySound(11);
											}
											else if (num146 != chest && chest == -1)
											{
												chest = num146;
												Main.playerInventory = true;
												Main.PlaySound(10);
												chestX = num144;
												chestY = num145;
											}
											else
											{
												chest = num146;
												Main.playerInventory = true;
												Main.PlaySound(12);
												chestX = num144;
												chestY = num145;
											}
										}
									}
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 314 && gravDir == 1f)
								{
									bool flag20 = true;
									if (mount.Active)
									{
										if (mount.Type == 6)
										{
											flag20 = false;
										}
										else
										{
											mount.Dismount(this);
										}
									}
									if (flag20)
									{
										Vector2 vector4 = new Vector2((float)Main.mouseX + Main.screenPosition.X, (float)Main.mouseY + Main.screenPosition.Y);
										if (direction > 0)
										{
											minecartLeft = false;
										}
										else
										{
											minecartLeft = true;
										}
										grappling[0] = -1;
										grapCount = 0;
										for (int num151 = 0; num151 < 1000; num151++)
										{
											if (Main.projectile[num151].active && Main.projectile[num151].owner == whoAmi && Main.projectile[num151].aiStyle == 7)
											{
												Main.projectile[num151].Kill();
											}
										}
										Projectile.NewProjectile(vector4.X, vector4.Y, 0f, 0f, 403, 0, 0f, whoAmi);
									}
								}
							}
							releaseUseTile = false;
						}
						else
						{
							releaseUseTile = true;
						}
					}
				}
				else
				{
					if (Main.tile[tileTargetX, tileTargetY] == null)
					{
						Main.tile[tileTargetX, tileTargetY] = new Tile();
					}
					if (Main.tile[tileTargetX, tileTargetY].type == 21)
					{
						Tile tile2 = Main.tile[tileTargetX, tileTargetY];
						int num152 = tileTargetX;
						int num153 = tileTargetY;
						if (tile2.frameX % 36 != 0)
						{
							num152--;
						}
						if (tile2.frameY % 36 != 0)
						{
							num153--;
						}
						int num154 = Chest.FindChest(num152, num153);
						showItemIcon2 = -1;
						if (num154 < 0)
						{
							showItemIconText = Lang.chestType[0];
						}
						else
						{
							if (Main.chest[num154].name != "")
							{
								showItemIconText = Main.chest[num154].name;
							}
							else
							{
								showItemIconText = Lang.chestType[tile2.frameX / 36];
							}
							if (showItemIconText == Lang.chestType[tile2.frameX / 36])
							{
								showItemIcon2 = Chest.typeToIcon[tile2.frameX / 36];
								showItemIconText = "";
							}
						}
						noThrow = 2;
						showItemIcon = true;
						if (showItemIconText == "")
						{
							showItemIcon = false;
							showItemIcon2 = 0;
						}
					}
				}
			}
			if (tongued)
			{
				bool flag21 = false;
				if (Main.wof >= 0)
				{
					float num155 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2);
					num155 += (float)(Main.npc[Main.wof].direction * 200);
					float num156 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2);
					Vector2 vector5 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
					float num157 = num155 - vector5.X;
					float num158 = num156 - vector5.Y;
					float num159 = (float)Math.Sqrt(num157 * num157 + num158 * num158);
					float num160 = 11f;
					float num161 = num159;
					if (num159 > num160)
					{
						num161 = num160 / num159;
					}
					else
					{
						num161 = 1f;
						flag21 = true;
					}
					num157 *= num161;
					num158 *= num161;
					velocity.X = num157;
					velocity.Y = num158;
				}
				else
				{
					flag21 = true;
				}
				if (flag21 && Main.myPlayer == whoAmi)
				{
					for (int num162 = 0; num162 < 22; num162++)
					{
						if (buffType[num162] == 38)
						{
							DelBuff(num162);
						}
					}
				}
			}
			if (Main.myPlayer == whoAmi)
			{
				WOFTongue();
				if (controlHook)
				{
					if (releaseHook)
					{
						QuickGrapple();
					}
					releaseHook = false;
				}
				else
				{
					releaseHook = true;
				}
				if (talkNPC >= 0)
				{
					Rectangle rectangle = new Rectangle((int)(position.X + (float)(width / 2) - (float)(tileRangeX * 16)), (int)(position.Y + (float)(height / 2) - (float)(tileRangeY * 16)), tileRangeX * 16 * 2, tileRangeY * 16 * 2);
					Rectangle value = new Rectangle((int)Main.npc[talkNPC].position.X, (int)Main.npc[talkNPC].position.Y, Main.npc[talkNPC].width, Main.npc[talkNPC].height);
					if (!rectangle.Intersects(value) || chest != -1 || !Main.npc[talkNPC].active)
					{
						if (chest == -1)
						{
							Main.PlaySound(11);
						}
						talkNPC = -1;
						Main.npcChatCornerItem = 0;
						Main.npcChatText = "";
					}
				}
				if (sign >= 0)
				{
					Rectangle rectangle2 = new Rectangle((int)(position.X + (float)(width / 2) - (float)(tileRangeX * 16)), (int)(position.Y + (float)(height / 2) - (float)(tileRangeY * 16)), tileRangeX * 16 * 2, tileRangeY * 16 * 2);
					try
					{
						Rectangle value2 = new Rectangle(Main.sign[sign].x * 16, Main.sign[sign].y * 16, 32, 32);
						if (!rectangle2.Intersects(value2))
						{
							Main.PlaySound(11);
							sign = -1;
							Main.editSign = false;
							Main.npcChatText = "";
						}
					}
					catch
					{
						Main.PlaySound(11);
						sign = -1;
						Main.editSign = false;
						Main.npcChatText = "";
					}
				}
				if (Main.editSign)
				{
					if (sign == -1)
					{
						Main.editSign = false;
					}
					else
					{
						Main.npcChatText = Main.GetInputText(Main.npcChatText);
						if (Main.inputTextEnter)
						{
							byte[] bytes = new byte[1] { 10 };
							Main.npcChatText += Encoding.ASCII.GetString(bytes);
						}
						else if (Main.inputTextEscape)
						{
							Main.PlaySound(12);
							Main.editSign = false;
							Main.blockKey = Keys.Escape;
							Main.npcChatText = Main.sign[sign].text;
						}
					}
				}
				else if (Main.editChest)
				{
					string inputText = Main.GetInputText(Main.npcChatText);
					if (Main.inputTextEnter)
					{
						Main.PlaySound(12);
						Main.editChest = false;
						int num163 = Main.player[Main.myPlayer].chest;
						if (Main.npcChatText == Main.defaultChestName)
						{
							Main.npcChatText = "";
						}
						if (Main.chest[num163].name != Main.npcChatText)
						{
							Main.chest[num163].name = Main.npcChatText;
							if (Main.netMode == 1)
							{
								editedChestName = true;
							}
						}
					}
					else if (Main.inputTextEscape)
					{
						Main.PlaySound(12);
						Main.editChest = false;
						Main.npcChatText = string.Empty;
						Main.blockKey = Keys.Escape;
					}
					else if (inputText.Length <= 20)
					{
						Main.npcChatText = inputText;
					}
				}
				if (mount.Active && mount.Type == 6 && Math.Abs(velocity.X) > 4f)
				{
					Rectangle rectangle3 = new Rectangle((int)position.X, (int)position.Y, width, height);
					for (int num164 = 0; num164 < 200; num164++)
					{
						if (Main.npc[num164].active && !Main.npc[num164].friendly && Main.npc[num164].damage > 0 && Main.npc[num164].immune[i] == 0 && rectangle3.Intersects(new Rectangle((int)Main.npc[num164].position.X, (int)Main.npc[num164].position.Y, Main.npc[num164].width, Main.npc[num164].height)))
						{
							float num165 = meleeCrit;
							if (meleeCrit < rangedCrit)
							{
								num165 = rangedCrit;
							}
							if (rangedCrit < magicCrit)
							{
								num165 = magicCrit;
							}
							bool crit = false;
							if ((float)Main.rand.Next(1, 101) <= num165)
							{
								crit = true;
							}
							float num166 = Math.Abs(velocity.X) / maxRunSpeed;
							int num167 = Main.DamageVar(25f + 55f * num166);
							float num168 = 5f + 25f * num166;
							int num169 = 1;
							if (velocity.X < 0f)
							{
								num169 = -1;
							}
							Main.npc[num164].StrikeNPC(num167, num168, num169, crit);
							if (Main.netMode != 0)
							{
								NetMessage.SendData(28, -1, -1, "", num164, num167, num168, -num169);
							}
							Main.npc[num164].immune[i] = 30;
						}
					}
				}
				if (!immune)
				{
					Rectangle rectangle4 = new Rectangle((int)position.X, (int)position.Y, width, height);
					for (int num170 = 0; num170 < 200; num170++)
					{
						if (!Main.npc[num170].active || Main.npc[num170].friendly || Main.npc[num170].damage <= 0 || !rectangle4.Intersects(new Rectangle((int)Main.npc[num170].position.X, (int)Main.npc[num170].position.Y, Main.npc[num170].width, Main.npc[num170].height)))
						{
							continue;
						}
						int num171 = -1;
						if (Main.npc[num170].position.X + (float)(Main.npc[num170].width / 2) < position.X + (float)(width / 2))
						{
							num171 = 1;
						}
						int num172 = Main.DamageVar(Main.npc[num170].damage);
						if (whoAmi == Main.myPlayer && thorns && !immune && !Main.npc[num170].dontTakeDamage)
						{
							int num173 = num172 / 3;
							int num174 = 10;
							if (turtleThorns)
							{
								num173 = num172;
							}
							Main.npc[num170].StrikeNPC(num173, num174, -num171);
							if (Main.netMode != 0)
							{
								NetMessage.SendData(28, -1, -1, "", num170, num173, num174, -num171);
							}
						}
						if (resistCold && Main.npc[num170].coldDamage)
						{
							num172 = (int)((float)num172 * 0.7f);
						}
						if (!immune)
						{
							StatusPlayer(Main.npc[num170]);
						}
						Hurt(num172, num171, false, false, Lang.deathMsg(-1, num170));
					}
				}
				Vector2 vector6 = Collision.HurtTiles(position, velocity, width, height, fireWalk);
				if (vector6.Y == 20f)
				{
					AddBuff(67, 20);
				}
				else if (vector6.Y == 15f)
				{
					if (suffocateDelay < 5)
					{
						suffocateDelay++;
					}
					else
					{
						AddBuff(68, 1);
					}
				}
				else if (vector6.Y != 0f)
				{
					int damage2 = Main.DamageVar(vector6.Y);
					Hurt(damage2, 0, false, false, Lang.deathMsg(-1, -1, -1, 3));
				}
				else
				{
					suffocateDelay = 0;
				}
			}
			if (controlRight)
			{
				releaseRight = false;
			}
			else
			{
				releaseRight = true;
				rightTimer = 7;
			}
			if (controlLeft)
			{
				releaseLeft = false;
			}
			else
			{
				releaseLeft = true;
				leftTimer = 7;
			}
			if (rightTimer > 0)
			{
				rightTimer--;
			}
			else if (controlRight)
			{
				rightTimer = 7;
			}
			if (leftTimer > 0)
			{
				leftTimer--;
			}
			else if (controlLeft)
			{
				leftTimer = 7;
			}
			GrappleMovement();
			StickyMovement();
			CheckDrowning();
			if (gravDir == -1f)
			{
				waterWalk = false;
				waterWalk2 = false;
			}
			int num175 = height;
			if (waterWalk)
			{
				num175 -= 6;
			}
			bool flag22 = Collision.LavaCollision(position, width, num175);
			if (flag22)
			{
				if (!lavaImmune && Main.myPlayer == i && !immune)
				{
					if (lavaTime > 0)
					{
						lavaTime--;
					}
					else if (lavaRose)
					{
						Hurt(50, 0, false, false, Lang.deathMsg(-1, -1, -1, 2));
						AddBuff(24, 210);
					}
					else
					{
						Hurt(80, 0, false, false, Lang.deathMsg(-1, -1, -1, 2));
						AddBuff(24, 420);
					}
				}
				lavaWet = true;
			}
			else
			{
				lavaWet = false;
				if (lavaTime < lavaMax)
				{
					lavaTime++;
				}
			}
			if (lavaTime > lavaMax)
			{
				lavaTime = lavaMax;
			}
			if (waterWalk2 && !waterWalk)
			{
				num175 -= 6;
			}
			bool flag23 = Collision.WetCollision(position, width, height);
			bool flag24 = Collision.honey;
			if (flag24)
			{
				AddBuff(48, 1800);
				honeyWet = true;
			}
			if (flag23)
			{
				if (onFire && !lavaWet)
				{
					for (int num176 = 0; num176 < 22; num176++)
					{
						if (buffType[num176] == 24)
						{
							DelBuff(num176);
						}
					}
				}
				if (!wet)
				{
					if (wetCount == 0)
					{
						wetCount = 10;
						if (!flag22)
						{
							if (honeyWet)
							{
								for (int num177 = 0; num177 < 20; num177++)
								{
									int num178 = Dust.NewDust(new Vector2(position.X - 6f, position.Y + (float)(height / 2) - 8f), width + 12, 24, 152);
									Main.dust[num178].velocity.Y -= 1f;
									Main.dust[num178].velocity.X *= 2.5f;
									Main.dust[num178].scale = 1.3f;
									Main.dust[num178].alpha = 100;
									Main.dust[num178].noGravity = true;
								}
								Main.PlaySound(19, (int)position.X, (int)position.Y);
							}
							else
							{
								for (int num179 = 0; num179 < 50; num179++)
								{
									int num180 = Dust.NewDust(new Vector2(position.X - 6f, position.Y + (float)(height / 2) - 8f), width + 12, 24, Dust.dustWater());
									Main.dust[num180].velocity.Y -= 3f;
									Main.dust[num180].velocity.X *= 2.5f;
									Main.dust[num180].scale = 0.8f;
									Main.dust[num180].alpha = 100;
									Main.dust[num180].noGravity = true;
								}
								Main.PlaySound(19, (int)position.X, (int)position.Y, 0);
							}
						}
						else
						{
							for (int num181 = 0; num181 < 20; num181++)
							{
								int num182 = Dust.NewDust(new Vector2(position.X - 6f, position.Y + (float)(height / 2) - 8f), width + 12, 24, 35);
								Main.dust[num182].velocity.Y -= 1.5f;
								Main.dust[num182].velocity.X *= 2.5f;
								Main.dust[num182].scale = 1.3f;
								Main.dust[num182].alpha = 100;
								Main.dust[num182].noGravity = true;
							}
							Main.PlaySound(19, (int)position.X, (int)position.Y);
						}
					}
					wet = true;
				}
			}
			else if (wet)
			{
				wet = false;
				if (jump > jumpHeight / 5 && wetSlime == 0)
				{
					jump = jumpHeight / 5;
				}
				if (wetCount == 0)
				{
					wetCount = 10;
					if (!lavaWet)
					{
						if (honeyWet)
						{
							for (int num183 = 0; num183 < 20; num183++)
							{
								int num184 = Dust.NewDust(new Vector2(position.X - 6f, position.Y + (float)(height / 2) - 8f), width + 12, 24, 152);
								Main.dust[num184].velocity.Y -= 1f;
								Main.dust[num184].velocity.X *= 2.5f;
								Main.dust[num184].scale = 1.3f;
								Main.dust[num184].alpha = 100;
								Main.dust[num184].noGravity = true;
							}
							Main.PlaySound(19, (int)position.X, (int)position.Y);
						}
						else
						{
							for (int num185 = 0; num185 < 50; num185++)
							{
								int num186 = Dust.NewDust(new Vector2(position.X - 6f, position.Y + (float)(height / 2)), width + 12, 24, Dust.dustWater());
								Main.dust[num186].velocity.Y -= 4f;
								Main.dust[num186].velocity.X *= 2.5f;
								Main.dust[num186].scale = 0.8f;
								Main.dust[num186].alpha = 100;
								Main.dust[num186].noGravity = true;
							}
							Main.PlaySound(19, (int)position.X, (int)position.Y, 0);
						}
					}
					else
					{
						for (int num187 = 0; num187 < 20; num187++)
						{
							int num188 = Dust.NewDust(new Vector2(position.X - 6f, position.Y + (float)(height / 2) - 8f), width + 12, 24, 35);
							Main.dust[num188].velocity.Y -= 1.5f;
							Main.dust[num188].velocity.X *= 2.5f;
							Main.dust[num188].scale = 1.3f;
							Main.dust[num188].alpha = 100;
							Main.dust[num188].noGravity = true;
						}
						Main.PlaySound(19, (int)position.X, (int)position.Y);
					}
				}
			}
			if (!flag24)
			{
				honeyWet = false;
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
			if (wetSlime > 0)
			{
				wetSlime--;
			}
			if (wet && mount.Active)
			{
				switch (mount.Type)
				{
				case 5:
					if (whoAmi == Main.myPlayer)
					{
						mount.Dismount(this);
					}
					break;
				case 3:
					wetSlime = 30;
					if (velocity.Y > 2f)
					{
						velocity.Y *= 0.9f;
					}
					velocity.Y -= 0.5f;
					if (velocity.Y < -4f)
					{
						velocity.Y = -4f;
					}
					break;
				}
			}
			float num189 = 1f + Math.Abs(velocity.X) / 3f;
			if (gfxOffY > 0f)
			{
				gfxOffY -= num189 * stepSpeed;
				if (gfxOffY < 0f)
				{
					gfxOffY = 0f;
				}
			}
			else if (gfxOffY < 0f)
			{
				gfxOffY += num189 * stepSpeed;
				if (gfxOffY > 0f)
				{
					gfxOffY = 0f;
				}
			}
			if (gfxOffY > 32f)
			{
				gfxOffY = 32f;
			}
			if (gfxOffY < -32f)
			{
				gfxOffY = -32f;
			}
			if (Main.myPlayer == i && !iceSkate)
			{
				CheckIceBreak();
			}
			SlopeDownMovement();
			if (velocity.Y == gravity && (!mount.Active || mount.Type != 6))
			{
				Collision.StepDown(ref position, ref velocity, width, height, ref stepSpeed, ref gfxOffY, (int)gravDir, waterWalk || waterWalk2);
			}
			if (gravDir == -1f)
			{
				if ((carpetFrame != -1 || velocity.Y <= gravity) && !controlUp)
				{
					Collision.StepUp(ref position, ref velocity, width, height, ref stepSpeed, ref gfxOffY, (int)gravDir, controlUp);
				}
			}
			else if ((carpetFrame != -1 || velocity.Y >= gravity) && !controlDown && (!mount.Active || mount.Type != 6))
			{
				Collision.StepUp(ref position, ref velocity, width, height, ref stepSpeed, ref gfxOffY, (int)gravDir, controlUp);
			}
			oldPosition = position;
			bool falling = false;
			if (velocity.Y > gravity)
			{
				falling = true;
			}
			Vector2 vector7 = velocity;
			slideDir = 0;
			bool ignorePlats = false;
			bool fallThrough = controlDown;
			if (gravDir == -1f)
			{
				ignorePlats = true;
				fallThrough = true;
			}
			onTrack = false;
			bool flag25 = false;
			if (mount.Active && mount.Type == 6)
			{
				float num190 = ((ignoreWater || merman) ? 1f : (honeyWet ? 0.25f : ((!wet) ? 1f : 0.5f)));
				velocity *= num190;
				BitsByte bitsByte = Minecart.TrackCollision(ref position, ref velocity, ref lastBoost, width, height, controlDown, controlUp, fallStart2, false);
				if (bitsByte[0])
				{
					onTrack = true;
					gfxOffY = Minecart.TrackRotation(ref fullRotation, position + velocity, width, height, controlDown, controlUp);
					fullRotationOrigin = new Vector2(width / 2, height);
				}
				if (bitsByte[1])
				{
					if (controlLeft || controlRight)
					{
						if (cartFlip)
						{
							cartFlip = false;
						}
						else
						{
							cartFlip = true;
						}
					}
					if (velocity.X > 0f)
					{
						direction = 1;
					}
					else if (velocity.X < 0f)
					{
						direction = -1;
					}
					Main.PlaySound(2, (int)position.X + width / 2, (int)position.Y + height / 2, 56);
				}
				velocity /= num190;
				if (bitsByte[3] && whoAmi == Main.myPlayer)
				{
					flag25 = true;
				}
				if (bitsByte[2])
				{
					cartRampTime = (int)(Math.Abs(velocity.X) / mount.RunSpeed * 20f);
				}
				if (bitsByte[4])
				{
					trackBoost -= 4f;
				}
				if (bitsByte[5])
				{
					trackBoost += 4f;
				}
			}
			if (wingsLogic == 3 && controlUp && controlDown)
			{
				position += velocity;
			}
			else if (tongued)
			{
				position += velocity;
			}
			else if (honeyWet && !ignoreWater)
			{
				HoneyCollision(fallThrough, ignorePlats);
			}
			else if (wet && !merman && !ignoreWater)
			{
				WaterCollision(fallThrough, ignorePlats);
			}
			else
			{
				DryCollision(fallThrough, ignorePlats);
			}
			if (wingsLogic != 3 || !controlUp || !controlDown)
			{
				SlopingCollision();
			}
			if (flag25)
			{
				NetMessage.SendData(13, -1, -1, "", whoAmi);
				Minecart.HitTrackSwitch(new Vector2(position.X, position.Y), width, height);
			}
			if (vector7.X != velocity.X)
			{
				if (vector7.X < 0f)
				{
					slideDir = -1;
				}
				else if (vector7.X > 0f)
				{
					slideDir = 1;
				}
			}
			if (gravDir == 1f && Collision.up)
			{
				velocity.Y = 0.01f;
				if (!merman)
				{
					jump = 0;
				}
			}
			else if (gravDir == -1f && Collision.down)
			{
				velocity.Y = -0.01f;
				if (!merman)
				{
					jump = 0;
				}
			}
			if (velocity.Y == 0f && grappling[0] == -1)
			{
				FloorVisuals(falling);
			}
			if (whoAmi == Main.myPlayer)
			{
				Collision.SwitchTiles(position, width, height, oldPosition, 1);
			}
			BordersMovement();
			numMinions = 0;
			slotsMinions = 0f;
			if (Main.ignoreErrors)
			{
				try
				{
					ItemCheck(i);
				}
				catch
				{
				}
			}
			else
			{
				ItemCheck(i);
			}
			PlayerFrame();
			if (statLife > statLifeMax2)
			{
				statLife = statLifeMax2;
			}
			if (statMana > statManaMax2)
			{
				statMana = statManaMax2;
			}
			grappling[0] = -1;
			grapCount = 0;
		}

		public bool SellItem(int price, int stack)
		{
			if (price <= 0)
			{
				return false;
			}
			Item[] array = new Item[58];
			for (int i = 0; i < 58; i++)
			{
				array[i] = new Item();
				array[i] = inventory[i].Clone();
			}
			int num = price / 5;
			num *= stack;
			if (num < 1)
			{
				num = 1;
			}
			bool flag = false;
			while (num >= 1000000 && !flag)
			{
				int num2 = -1;
				for (int num3 = 53; num3 >= 0; num3--)
				{
					if (num2 == -1 && (inventory[num3].type == 0 || inventory[num3].stack == 0))
					{
						num2 = num3;
					}
					while (inventory[num3].type == 74 && inventory[num3].stack < inventory[num3].maxStack && num >= 1000000)
					{
						inventory[num3].stack++;
						num -= 1000000;
						DoCoins(num3);
						if (inventory[num3].stack == 0 && num2 == -1)
						{
							num2 = num3;
						}
					}
				}
				if (num >= 1000000)
				{
					if (num2 == -1)
					{
						flag = true;
						continue;
					}
					inventory[num2].SetDefaults(74);
					num -= 1000000;
				}
			}
			while (num >= 10000 && !flag)
			{
				int num4 = -1;
				for (int num5 = 53; num5 >= 0; num5--)
				{
					if (num4 == -1 && (inventory[num5].type == 0 || inventory[num5].stack == 0))
					{
						num4 = num5;
					}
					while (inventory[num5].type == 73 && inventory[num5].stack < inventory[num5].maxStack && num >= 10000)
					{
						inventory[num5].stack++;
						num -= 10000;
						DoCoins(num5);
						if (inventory[num5].stack == 0 && num4 == -1)
						{
							num4 = num5;
						}
					}
				}
				if (num >= 10000)
				{
					if (num4 == -1)
					{
						flag = true;
						continue;
					}
					inventory[num4].SetDefaults(73);
					num -= 10000;
				}
			}
			while (num >= 100 && !flag)
			{
				int num6 = -1;
				for (int num7 = 53; num7 >= 0; num7--)
				{
					if (num6 == -1 && (inventory[num7].type == 0 || inventory[num7].stack == 0))
					{
						num6 = num7;
					}
					while (inventory[num7].type == 72 && inventory[num7].stack < inventory[num7].maxStack && num >= 100)
					{
						inventory[num7].stack++;
						num -= 100;
						DoCoins(num7);
						if (inventory[num7].stack == 0 && num6 == -1)
						{
							num6 = num7;
						}
					}
				}
				if (num >= 100)
				{
					if (num6 == -1)
					{
						flag = true;
						continue;
					}
					inventory[num6].SetDefaults(72);
					num -= 100;
				}
			}
			while (num >= 1 && !flag)
			{
				int num8 = -1;
				for (int num9 = 53; num9 >= 0; num9--)
				{
					if (num8 == -1 && (inventory[num9].type == 0 || inventory[num9].stack == 0))
					{
						num8 = num9;
					}
					while (inventory[num9].type == 71 && inventory[num9].stack < inventory[num9].maxStack && num >= 1)
					{
						inventory[num9].stack++;
						num--;
						DoCoins(num9);
						if (inventory[num9].stack == 0 && num8 == -1)
						{
							num8 = num9;
						}
					}
				}
				if (num >= 1)
				{
					if (num8 == -1)
					{
						flag = true;
						continue;
					}
					inventory[num8].SetDefaults(71);
					num--;
				}
			}
			if (flag)
			{
				for (int j = 0; j < 58; j++)
				{
					inventory[j] = array[j].Clone();
				}
				return false;
			}
			return true;
		}

		public bool BuyItem(int price)
		{
			if (price == 0)
			{
				return true;
			}
			long num = 0L;
			int num2 = price;
			Item[] array = new Item[54];
			for (int i = 0; i < 54; i++)
			{
				array[i] = new Item();
				array[i] = inventory[i].Clone();
				if (inventory[i].type == 71)
				{
					num += inventory[i].stack;
				}
				if (inventory[i].type == 72)
				{
					num += inventory[i].stack * 100;
				}
				if (inventory[i].type == 73)
				{
					num += inventory[i].stack * 10000;
				}
				if (inventory[i].type == 74)
				{
					num += inventory[i].stack * 1000000;
				}
			}
			if (num >= price)
			{
				num2 = price;
				while (num2 > 0)
				{
					if (num2 >= 1000000)
					{
						for (int j = 0; j < 54; j++)
						{
							if (inventory[j].type != 74)
							{
								continue;
							}
							while (inventory[j].stack > 0 && num2 >= 1000000)
							{
								num2 -= 1000000;
								inventory[j].stack--;
								if (inventory[j].stack == 0)
								{
									inventory[j].type = 0;
								}
							}
						}
					}
					if (num2 >= 10000)
					{
						for (int k = 0; k < 54; k++)
						{
							if (inventory[k].type != 73)
							{
								continue;
							}
							while (inventory[k].stack > 0 && num2 >= 10000)
							{
								num2 -= 10000;
								inventory[k].stack--;
								if (inventory[k].stack == 0)
								{
									inventory[k].type = 0;
								}
							}
						}
					}
					if (num2 >= 100)
					{
						for (int l = 0; l < 54; l++)
						{
							if (inventory[l].type != 72)
							{
								continue;
							}
							while (inventory[l].stack > 0 && num2 >= 100)
							{
								num2 -= 100;
								inventory[l].stack--;
								if (inventory[l].stack == 0)
								{
									inventory[l].type = 0;
								}
							}
						}
					}
					if (num2 >= 1)
					{
						for (int m = 0; m < 54; m++)
						{
							if (inventory[m].type != 71)
							{
								continue;
							}
							while (inventory[m].stack > 0 && num2 >= 1)
							{
								num2--;
								inventory[m].stack--;
								if (inventory[m].stack == 0)
								{
									inventory[m].type = 0;
								}
							}
						}
					}
					if (num2 <= 0)
					{
						continue;
					}
					int num3 = -1;
					for (int num4 = 53; num4 >= 0; num4--)
					{
						if (inventory[num4].type == 0 || inventory[num4].stack == 0)
						{
							num3 = num4;
							break;
						}
					}
					if (num3 >= 0)
					{
						bool flag = true;
						if (num2 >= 10000)
						{
							for (int n = 0; n < 58; n++)
							{
								if (inventory[n].type == 74 && inventory[n].stack >= 1)
								{
									inventory[n].stack--;
									if (inventory[n].stack == 0)
									{
										inventory[n].type = 0;
									}
									inventory[num3].SetDefaults(73);
									inventory[num3].stack = 100;
									flag = false;
									break;
								}
							}
						}
						else if (num2 >= 100)
						{
							for (int num5 = 0; num5 < 54; num5++)
							{
								if (inventory[num5].type == 73 && inventory[num5].stack >= 1)
								{
									inventory[num5].stack--;
									if (inventory[num5].stack == 0)
									{
										inventory[num5].type = 0;
									}
									inventory[num3].SetDefaults(72);
									inventory[num3].stack = 100;
									flag = false;
									break;
								}
							}
						}
						else if (num2 >= 1)
						{
							for (int num6 = 0; num6 < 54; num6++)
							{
								if (inventory[num6].type == 72 && inventory[num6].stack >= 1)
								{
									inventory[num6].stack--;
									if (inventory[num6].stack == 0)
									{
										inventory[num6].type = 0;
									}
									inventory[num3].SetDefaults(71);
									inventory[num3].stack = 100;
									flag = false;
									break;
								}
							}
						}
						if (!flag)
						{
							continue;
						}
						if (num2 < 10000)
						{
							for (int num7 = 0; num7 < 54; num7++)
							{
								if (inventory[num7].type == 73 && inventory[num7].stack >= 1)
								{
									inventory[num7].stack--;
									if (inventory[num7].stack == 0)
									{
										inventory[num7].type = 0;
									}
									inventory[num3].SetDefaults(72);
									inventory[num3].stack = 100;
									flag = false;
									break;
								}
							}
						}
						if (!flag || num2 >= 1000000)
						{
							continue;
						}
						for (int num8 = 0; num8 < 54; num8++)
						{
							if (inventory[num8].type == 74 && inventory[num8].stack >= 1)
							{
								inventory[num8].stack--;
								if (inventory[num8].stack == 0)
								{
									inventory[num8].type = 0;
								}
								inventory[num3].SetDefaults(73);
								inventory[num3].stack = 100;
								flag = false;
								break;
							}
						}
						continue;
					}
					for (int num9 = 0; num9 < 54; num9++)
					{
						inventory[num9] = array[num9].Clone();
					}
					return false;
				}
				return true;
			}
			return false;
		}

		public void AdjTiles()
		{
			int num = 4;
			int num2 = 3;
			for (int i = 0; i < 340; i++)
			{
				oldAdjTile[i] = adjTile[i];
				adjTile[i] = false;
			}
			oldAdjWater = adjWater;
			adjWater = false;
			oldAdjHoney = adjHoney;
			adjHoney = false;
			oldAdjLava = adjLava;
			adjLava = false;
			int num3 = (int)((position.X + (float)(width / 2)) / 16f);
			int num4 = (int)((position.Y + (float)height) / 16f);
			for (int j = num3 - num; j <= num3 + num; j++)
			{
				for (int k = num4 - num2; k < num4 + num2; k++)
				{
					if (Main.tile[j, k].active())
					{
						adjTile[Main.tile[j, k].type] = true;
						if (Main.tile[j, k].type == 302)
						{
							adjTile[17] = true;
						}
						if (Main.tile[j, k].type == 77)
						{
							adjTile[17] = true;
						}
						if (Main.tile[j, k].type == 133)
						{
							adjTile[17] = true;
							adjTile[77] = true;
						}
						if (Main.tile[j, k].type == 134)
						{
							adjTile[16] = true;
						}
					}
					if (Main.tile[j, k].liquid > 200 && Main.tile[j, k].liquidType() == 0)
					{
						adjWater = true;
					}
					if (Main.tile[j, k].liquid > 200 && Main.tile[j, k].liquidType() == 2)
					{
						adjHoney = true;
					}
					if (Main.tile[j, k].liquid > 200 && Main.tile[j, k].liquidType() == 1)
					{
						adjLava = true;
					}
				}
			}
			if (!Main.playerInventory)
			{
				return;
			}
			bool flag = false;
			for (int l = 0; l < 340; l++)
			{
				if (oldAdjTile[l] != adjTile[l])
				{
					flag = true;
					break;
				}
			}
			if (adjWater != oldAdjWater)
			{
				flag = true;
			}
			if (adjHoney != oldAdjHoney)
			{
				flag = true;
			}
			if (adjLava != oldAdjLava)
			{
				flag = true;
			}
			if (flag)
			{
				Recipe.FindRecipes();
			}
		}

		public void PlayerFrame()
		{
			if (swimTime > 0)
			{
				swimTime--;
				if (!wet)
				{
					swimTime = 0;
				}
			}
			head = armor[0].headSlot;
			body = armor[1].bodySlot;
			legs = armor[2].legSlot;
			for (int i = 3; i < 8; i++)
			{
				if ((shield > 0 && armor[i].frontSlot >= 1 && armor[i].frontSlot <= 4) || (front >= 1 && front <= 4 && armor[i].shieldSlot > 0))
				{
					continue;
				}
				if (armor[i].wingSlot > 0)
				{
					if (hideVisual[i] && (velocity.Y == 0f || mount.Active))
					{
						continue;
					}
					wings = armor[i].wingSlot;
				}
				if (!hideVisual[i])
				{
					if (armor[i].handOnSlot > 0)
					{
						handon = armor[i].handOnSlot;
					}
					if (armor[i].handOffSlot > 0)
					{
						handoff = armor[i].handOffSlot;
					}
					if (armor[i].backSlot > 0)
					{
						back = armor[i].backSlot;
						front = -1;
					}
					if (armor[i].frontSlot > 0)
					{
						front = armor[i].frontSlot;
					}
					if (armor[i].shoeSlot > 0)
					{
						shoe = armor[i].shoeSlot;
					}
					if (armor[i].waistSlot > 0)
					{
						waist = armor[i].waistSlot;
					}
					if (armor[i].shieldSlot > 0)
					{
						shield = armor[i].shieldSlot;
					}
					if (armor[i].neckSlot > 0)
					{
						neck = armor[i].neckSlot;
					}
					if (armor[i].faceSlot > 0)
					{
						face = armor[i].faceSlot;
					}
					if (armor[i].balloonSlot > 0)
					{
						balloon = armor[i].balloonSlot;
					}
				}
			}
			for (int j = 11; j < 16; j++)
			{
				if (armor[j].handOnSlot > 0)
				{
					handon = armor[j].handOnSlot;
				}
				if (armor[j].handOffSlot > 0)
				{
					handoff = armor[j].handOffSlot;
				}
				if (armor[j].backSlot > 0)
				{
					back = armor[j].backSlot;
					front = -1;
				}
				if (armor[j].frontSlot > 0)
				{
					front = armor[j].frontSlot;
				}
				if (armor[j].shoeSlot > 0)
				{
					shoe = armor[j].shoeSlot;
				}
				if (armor[j].waistSlot > 0)
				{
					waist = armor[j].waistSlot;
				}
				if (armor[j].shieldSlot > 0)
				{
					shield = armor[j].shieldSlot;
				}
				if (armor[j].neckSlot > 0)
				{
					neck = armor[j].neckSlot;
				}
				if (armor[j].faceSlot > 0)
				{
					face = armor[j].faceSlot;
				}
				if (armor[j].balloonSlot > 0)
				{
					balloon = armor[j].balloonSlot;
				}
				if (armor[j].wingSlot > 0)
				{
					wings = armor[j].wingSlot;
				}
			}
			if (armor[8].headSlot >= 0)
			{
				head = armor[8].headSlot;
			}
			if (armor[9].bodySlot >= 0)
			{
				body = armor[9].bodySlot;
			}
			if (armor[10].legSlot >= 0)
			{
				legs = armor[10].legSlot;
			}
			wearsRobe = false;
			switch (body)
			{
			case 15:
				legs = 88;
				wearsRobe = true;
				break;
			case 36:
				legs = 89;
				wearsRobe = true;
				break;
			case 42:
				legs = 90;
				wearsRobe = true;
				break;
			case 58:
				legs = 91;
				wearsRobe = true;
				break;
			case 59:
				legs = 92;
				wearsRobe = true;
				break;
			case 60:
				legs = 93;
				wearsRobe = true;
				break;
			case 61:
				legs = 94;
				wearsRobe = true;
				break;
			case 62:
				legs = 95;
				wearsRobe = true;
				break;
			case 63:
				legs = 96;
				wearsRobe = true;
				break;
			case 41:
				legs = 97;
				wearsRobe = true;
				break;
			case 165:
				legs = 99;
				wearsRobe = true;
				break;
			case 166:
				legs = 100;
				wearsRobe = true;
				break;
			case 167:
				if (male)
				{
					legs = 101;
				}
				else
				{
					legs = 102;
				}
				wearsRobe = true;
				break;
			}
			if (Main.myPlayer == whoAmi)
			{
				bool flag = false;
				if (wings == 3 || (wings >= 16 && wings <= 19))
				{
					flag = true;
				}
				if (wingsLogic == 3 || (wingsLogic >= 16 && wingsLogic <= 19))
				{
					flag = true;
				}
				else if (head == 45 || (head >= 106 && head <= 111))
				{
					flag = true;
				}
				else if (body == 26 || (body >= 68 && body <= 74))
				{
					flag = true;
				}
				else if (legs == 25 || (legs >= 57 && legs <= 63))
				{
					flag = true;
				}
				if (flag)
				{
					velocity.X *= 0.9f;
					if (velocity.Y < 0f)
					{
						velocity.Y += 0.2f;
					}
					jump = 0;
					statDefense = -1000;
					AddBuff(23, 2, false);
					AddBuff(80, 2, false);
					AddBuff(67, 2, false);
					AddBuff(32, 2, false);
					AddBuff(31, 2, false);
					AddBuff(33, 2, false);
				}
			}
			if (body == 93)
			{
				shield = 0;
				handoff = 0;
			}
			if (legs == 67)
			{
				shoe = 0;
			}
			if (wereWolf)
			{
				legs = 20;
				body = 21;
				head = 38;
			}
			if (merman)
			{
				head = 39;
				legs = 21;
				body = 22;
				wings = 0;
			}
			socialShadow = false;
			socialGhost = false;
			if (head == 101 && body == 66 && legs == 55)
			{
				socialGhost = true;
			}
			if (head == 156 && body == 66 && legs == 55)
			{
				socialGhost = true;
			}
			if (head == 99 && body == 65 && legs == 54)
			{
				turtleArmor = true;
			}
			if (head == 162 && body == 170 && legs == 105)
			{
				spiderArmor = true;
			}
			if ((head == 75 || head == 7) && body == 7 && legs == 7)
			{
				boneArmor = true;
			}
			if (wings > 0)
			{
				back = -1;
				front = -1;
			}
			if (head > 0 && face != 7)
			{
				face = -1;
			}
			if (frozen || (Main.gamePaused && !Main.gameMenu))
			{
				return;
			}
			if (((body == 68 && legs == 57 && head == 106) || (body == 74 && legs == 63 && head == 106)) && Main.rand.Next(10) == 0)
			{
				int num = Dust.NewDust(new Vector2(position.X - velocity.X * 2f, position.Y - 2f - velocity.Y * 2f), width, height, 43, 0f, 0f, 100, new Color(255, 0, 255), 0.3f);
				Main.dust[num].fadeIn = 0.8f;
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity *= 2f;
			}
			if (head == 5 && body == 5 && legs == 5)
			{
				socialShadow = true;
			}
			if (head == 5 && body == 5 && legs == 5 && Main.rand.Next(10) == 0)
			{
				Dust.NewDust(new Vector2(position.X, position.Y), width, height, 14, 0f, 0f, 200, default(Color), 1.2f);
			}
			if (head == 45 && body == 26 && legs == 25 && Main.rand.Next(12) == 0)
			{
				Dust.NewDust(new Vector2(position.X, position.Y), width, height, 186, 0f, 0f, 160, default(Color), 1.4f);
			}
			if (head == 76 && body == 49 && legs == 45)
			{
				socialShadow = true;
			}
			if (head == 74 && body == 48 && legs == 44)
			{
				socialShadow = true;
			}
			if (head == 74 && body == 48 && legs == 44 && Main.rand.Next(10) == 0)
			{
				Dust.NewDust(new Vector2(position.X, position.Y), width, height, 14, 0f, 0f, 200, default(Color), 1.2f);
			}
			if (head == 57 && body == 37 && legs == 35)
			{
				int maxValue = 10;
				if (Math.Abs(velocity.X) + Math.Abs(velocity.Y) > 1f)
				{
					maxValue = 2;
				}
				if (Main.rand.Next(maxValue) == 0)
				{
					int num2 = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 115, 0f, 0f, 140, default(Color), 0.75f);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].fadeIn = 1.5f;
					Main.dust[num2].velocity *= 0.3f;
					Main.dust[num2].velocity += velocity * 0.2f;
				}
			}
			if (head == 6 && body == 6 && legs == 6 && Math.Abs(velocity.X) + Math.Abs(velocity.Y) > 1f && !rocketFrame)
			{
				for (int k = 0; k < 2; k++)
				{
					int num3 = Dust.NewDust(new Vector2(position.X - velocity.X * 2f, position.Y - 2f - velocity.Y * 2f), width, height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num3].noGravity = true;
					Main.dust[num3].noLight = true;
					Main.dust[num3].velocity.X -= velocity.X * 0.5f;
					Main.dust[num3].velocity.Y -= velocity.Y * 0.5f;
				}
			}
			if (head == 8 && body == 8 && legs == 8 && Math.Abs(velocity.X) + Math.Abs(velocity.Y) > 1f)
			{
				int num4 = Dust.NewDust(new Vector2(position.X - velocity.X * 2f, position.Y - 2f - velocity.Y * 2f), width, height, 40, 0f, 0f, 50, default(Color), 1.4f);
				Main.dust[num4].noGravity = true;
				Main.dust[num4].velocity.X = velocity.X * 0.25f;
				Main.dust[num4].velocity.Y = velocity.Y * 0.25f;
			}
			if (head == 9 && body == 9 && legs == 9 && Math.Abs(velocity.X) + Math.Abs(velocity.Y) > 1f && !rocketFrame)
			{
				for (int l = 0; l < 2; l++)
				{
					int num5 = Dust.NewDust(new Vector2(position.X - velocity.X * 2f, position.Y - 2f - velocity.Y * 2f), width, height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num5].noGravity = true;
					Main.dust[num5].noLight = true;
					Main.dust[num5].velocity.X -= velocity.X * 0.5f;
					Main.dust[num5].velocity.Y -= velocity.Y * 0.5f;
				}
			}
			if (body == 18 && legs == 17 && (head == 32 || head == 33 || head == 34) && Main.rand.Next(10) == 0)
			{
				int num6 = Dust.NewDust(new Vector2(position.X - velocity.X * 2f, position.Y - 2f - velocity.Y * 2f), width, height, 43, 0f, 0f, 100, default(Color), 0.3f);
				Main.dust[num6].fadeIn = 0.8f;
				Main.dust[num6].velocity *= 0f;
			}
			if (body == 24 && legs == 23 && (head == 42 || head == 43 || head == 41) && velocity.X != 0f && velocity.Y != 0f && Main.rand.Next(10) == 0)
			{
				int num7 = Dust.NewDust(new Vector2(position.X - velocity.X * 2f, position.Y - 2f - velocity.Y * 2f), width, height, 43, 0f, 0f, 100, default(Color), 0.3f);
				Main.dust[num7].fadeIn = 0.8f;
				Main.dust[num7].velocity *= 0f;
			}
			if (body == 36 && head == 56 && velocity.X != 0f && velocity.Y == 0f)
			{
				for (int m = 0; m < 2; m++)
				{
					int num8 = Dust.NewDust(new Vector2(position.X, position.Y + (float)((gravDir == 1f) ? (height - 2) : (-4))), width, 6, 106, 0f, 0f, 100, default(Color), 0.1f);
					Main.dust[num8].fadeIn = 1f;
					Main.dust[num8].noGravity = true;
					Main.dust[num8].velocity *= 0.2f;
				}
			}
			if (body == 27 && head == 46 && legs == 26)
			{
				frostArmor = true;
				if (velocity.X != 0f && velocity.Y == 0f && miscCounter % 2 == 0)
				{
					for (int n = 0; n < 2; n++)
					{
						int num9 = ((n != 0) ? Dust.NewDust(new Vector2(position.X + (float)(width / 2), position.Y + (float)height + gfxOffY), width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f) : Dust.NewDust(new Vector2(position.X, position.Y + (float)height + gfxOffY), width / 2, 6, 76, 0f, 0f, 0, default(Color), 1.35f));
						Main.dust[num9].scale *= 1f + (float)Main.rand.Next(20, 40) * 0.01f;
						Main.dust[num9].noGravity = true;
						Main.dust[num9].noLight = true;
						Main.dust[num9].velocity *= 0.001f;
						Main.dust[num9].velocity.Y -= 0.003f;
					}
				}
			}
			bodyFrame.Width = 40;
			bodyFrame.Height = 56;
			legFrame.Width = 40;
			legFrame.Height = 56;
			bodyFrame.X = 0;
			legFrame.X = 0;
			if (itemAnimation > 0 && inventory[selectedItem].useStyle != 10)
			{
				if (inventory[selectedItem].useStyle == 1 || inventory[selectedItem].type == 0)
				{
					if ((double)itemAnimation < (double)itemAnimationMax * 0.333)
					{
						bodyFrame.Y = bodyFrame.Height * 3;
					}
					else if ((double)itemAnimation < (double)itemAnimationMax * 0.666)
					{
						bodyFrame.Y = bodyFrame.Height * 2;
					}
					else
					{
						bodyFrame.Y = bodyFrame.Height;
					}
				}
				else if (inventory[selectedItem].useStyle == 2)
				{
					if ((double)itemAnimation > (double)itemAnimationMax * 0.5)
					{
						bodyFrame.Y = bodyFrame.Height * 3;
					}
					else
					{
						bodyFrame.Y = bodyFrame.Height * 2;
					}
				}
				else if (inventory[selectedItem].useStyle == 3)
				{
					if ((double)itemAnimation > (double)itemAnimationMax * 0.666)
					{
						bodyFrame.Y = bodyFrame.Height * 3;
					}
					else
					{
						bodyFrame.Y = bodyFrame.Height * 3;
					}
				}
				else if (inventory[selectedItem].useStyle == 4)
				{
					bodyFrame.Y = bodyFrame.Height * 2;
				}
				else if (inventory[selectedItem].useStyle == 5)
				{
					if (inventory[selectedItem].type == 281 || inventory[selectedItem].type == 986)
					{
						bodyFrame.Y = bodyFrame.Height * 2;
					}
					else
					{
						float num10 = itemRotation * (float)direction;
						bodyFrame.Y = bodyFrame.Height * 3;
						if ((double)num10 < -0.75)
						{
							bodyFrame.Y = bodyFrame.Height * 2;
							if (gravDir == -1f)
							{
								bodyFrame.Y = bodyFrame.Height * 4;
							}
						}
						if ((double)num10 > 0.6)
						{
							bodyFrame.Y = bodyFrame.Height * 4;
							if (gravDir == -1f)
							{
								bodyFrame.Y = bodyFrame.Height * 2;
							}
						}
					}
				}
			}
			else if (mount.Active)
			{
				bodyFrameCounter = 0.0;
				bodyFrame.Y = bodyFrame.Height * mount.BodyFrame;
			}
			else if (pulley)
			{
				if (pulleyDir == 2)
				{
					bodyFrame.Y = bodyFrame.Height;
				}
				else
				{
					bodyFrame.Y = bodyFrame.Height * 2;
				}
			}
			else if (inventory[selectedItem].holdStyle == 1 && (!wet || !inventory[selectedItem].noWet))
			{
				bodyFrame.Y = bodyFrame.Height * 3;
			}
			else if (inventory[selectedItem].holdStyle == 2 && (!wet || !inventory[selectedItem].noWet))
			{
				bodyFrame.Y = bodyFrame.Height * 2;
			}
			else if (inventory[selectedItem].holdStyle == 3)
			{
				bodyFrame.Y = bodyFrame.Height * 3;
			}
			else if (grappling[0] >= 0)
			{
				sandStorm = false;
				dJumpEffect = false;
				dJumpEffect2 = false;
				dJumpEffect3 = false;
				Vector2 vector = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
				float num11 = 0f;
				float num12 = 0f;
				for (int num13 = 0; num13 < grapCount; num13++)
				{
					num11 += Main.projectile[grappling[num13]].position.X + (float)(Main.projectile[grappling[num13]].width / 2);
					num12 += Main.projectile[grappling[num13]].position.Y + (float)(Main.projectile[grappling[num13]].height / 2);
				}
				num11 /= (float)grapCount;
				num12 /= (float)grapCount;
				num11 -= vector.X;
				num12 -= vector.Y;
				if (num12 < 0f && Math.Abs(num12) > Math.Abs(num11))
				{
					bodyFrame.Y = bodyFrame.Height * 2;
					if (gravDir == -1f)
					{
						bodyFrame.Y = bodyFrame.Height * 4;
					}
				}
				else if (num12 > 0f && Math.Abs(num12) > Math.Abs(num11))
				{
					bodyFrame.Y = bodyFrame.Height * 4;
					if (gravDir == -1f)
					{
						bodyFrame.Y = bodyFrame.Height * 2;
					}
				}
				else
				{
					bodyFrame.Y = bodyFrame.Height * 3;
				}
			}
			else if (swimTime > 0)
			{
				if (swimTime > 20)
				{
					bodyFrame.Y = 0;
				}
				else if (swimTime > 10)
				{
					bodyFrame.Y = bodyFrame.Height * 5;
				}
				else
				{
					bodyFrame.Y = 0;
				}
			}
			else if (velocity.Y != 0f)
			{
				if (sliding)
				{
					bodyFrame.Y = bodyFrame.Height * 3;
				}
				else if (sandStorm || carpetFrame >= 0)
				{
					bodyFrame.Y = bodyFrame.Height * 6;
				}
				else if (wings > 0)
				{
					if (wings == 22)
					{
						bodyFrame.Y = 0;
					}
					else if (velocity.Y > 0f)
					{
						if (controlJump)
						{
							bodyFrame.Y = bodyFrame.Height * 6;
						}
						else
						{
							bodyFrame.Y = bodyFrame.Height * 5;
						}
					}
					else
					{
						bodyFrame.Y = bodyFrame.Height * 6;
					}
				}
				else
				{
					bodyFrame.Y = bodyFrame.Height * 5;
				}
				bodyFrameCounter = 0.0;
			}
			else if (velocity.X != 0f)
			{
				bodyFrameCounter += (double)Math.Abs(velocity.X) * 1.5;
				bodyFrame.Y = legFrame.Y;
			}
			else
			{
				bodyFrameCounter = 0.0;
				bodyFrame.Y = 0;
			}
			if (mount.Active)
			{
				legFrameCounter = 0.0;
				legFrame.Y = legFrame.Height * 6;
				if (velocity.Y != 0f)
				{
					if (mount.FlyTime > 0 && jump == 0 && controlJump && mount.Type != 5)
					{
						if (mount.Type == 0)
						{
							if (direction > 0)
							{
								if (Main.rand.Next(4) == 0)
								{
									int num14 = Dust.NewDust(new Vector2(Center().X - 22f, position.Y + (float)height - 6f), 20, 10, 64, velocity.X * 0.25f, velocity.Y * 0.25f, 255);
									Main.dust[num14].velocity *= 0.1f;
									Main.dust[num14].noLight = true;
								}
								if (Main.rand.Next(4) == 0)
								{
									int num15 = Dust.NewDust(new Vector2(Center().X + 12f, position.Y + (float)height - 6f), 20, 10, 64, velocity.X * 0.25f, velocity.Y * 0.25f, 255);
									Main.dust[num15].velocity *= 0.1f;
									Main.dust[num15].noLight = true;
								}
							}
							else
							{
								if (Main.rand.Next(4) == 0)
								{
									int num16 = Dust.NewDust(new Vector2(Center().X - 32f, position.Y + (float)height - 6f), 20, 10, 64, velocity.X * 0.25f, velocity.Y * 0.25f, 255);
									Main.dust[num16].velocity *= 0.1f;
									Main.dust[num16].noLight = true;
								}
								if (Main.rand.Next(4) == 0)
								{
									int num17 = Dust.NewDust(new Vector2(Center().X + 2f, position.Y + (float)height - 6f), 20, 10, 64, velocity.X * 0.25f, velocity.Y * 0.25f, 255);
									Main.dust[num17].velocity *= 0.1f;
									Main.dust[num17].noLight = true;
								}
							}
						}
						mount.UpdateFrame(3, velocity);
					}
					else if (wet)
					{
						mount.UpdateFrame(4, velocity);
					}
					else
					{
						mount.UpdateFrame(2, velocity);
					}
				}
				else if (velocity.X == 0f)
				{
					mount.UpdateFrame(0, velocity);
				}
				else
				{
					mount.UpdateFrame(1, velocity);
				}
			}
			else if (swimTime > 0)
			{
				legFrameCounter += 2.0;
				while (legFrameCounter > 8.0)
				{
					legFrameCounter -= 8.0;
					legFrame.Y += legFrame.Height;
				}
				if (legFrame.Y < legFrame.Height * 7)
				{
					legFrame.Y = legFrame.Height * 19;
				}
				else if (legFrame.Y > legFrame.Height * 19)
				{
					legFrame.Y = legFrame.Height * 7;
				}
			}
			else if (velocity.Y != 0f || grappling[0] > -1)
			{
				legFrameCounter = 0.0;
				legFrame.Y = legFrame.Height * 5;
				if (wings == 22)
				{
					legFrame.Y = 0;
				}
			}
			else if (velocity.X != 0f)
			{
				if ((slippy || slippy2) && !controlLeft && !controlRight)
				{
					legFrameCounter = 0.0;
					legFrame.Y = 0;
				}
				else
				{
					legFrameCounter += (double)Math.Abs(velocity.X) * 1.3;
					while (legFrameCounter > 8.0)
					{
						legFrameCounter -= 8.0;
						legFrame.Y += legFrame.Height;
					}
					if (legFrame.Y < legFrame.Height * 7)
					{
						legFrame.Y = legFrame.Height * 19;
					}
					else if (legFrame.Y > legFrame.Height * 19)
					{
						legFrame.Y = legFrame.Height * 7;
					}
				}
			}
			else
			{
				legFrameCounter = 0.0;
				legFrame.Y = 0;
			}
			if (carpetFrame >= 0)
			{
				legFrameCounter = 0.0;
				legFrame.Y = 0;
			}
			if (!sandStorm)
			{
				return;
			}
			if (miscCounter % 4 == 0 && itemAnimation == 0)
			{
				ChangeDir(direction * -1);
				if (inventory[selectedItem].holdStyle == 2)
				{
					if (inventory[selectedItem].type == 946)
					{
						itemLocation.X = position.X + (float)width * 0.5f - (float)(16 * direction);
					}
					if (inventory[selectedItem].type == 186)
					{
						itemLocation.X = position.X + (float)width * 0.5f + (float)(6 * direction);
						itemRotation = 0.79f * (float)(-direction);
					}
				}
			}
			legFrameCounter = 0.0;
			legFrame.Y = 0;
		}

		public void Teleport(Vector2 newPos, int Style = 0)
		{
			try
			{
				grappling[0] = -1;
				grapCount = 0;
				for (int i = 0; i < 1000; i++)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == whoAmi && Main.projectile[i].aiStyle == 7)
					{
						Main.projectile[i].Kill();
					}
				}
				Main.TeleportEffect(getRect(), Style);
				position = newPos;
				fallStart = (int)(position.Y / 16f);
				if (whoAmi == Main.myPlayer)
				{
					Main.BlackFadeIn = 255;
					Lighting.BlackOut();
					Main.screenLastPosition = Main.screenPosition;
					Main.screenPosition.X = position.X + (float)(width / 2) - (float)(Main.screenWidth / 2);
					Main.screenPosition.Y = position.Y + (float)(height / 2) - (float)(Main.screenHeight / 2);
					if (Main.mapTime < 5)
					{
						Main.mapTime = 5;
					}
					Main.quickBG = 10;
					Main.maxQ = true;
					Main.renderNow = true;
				}
				Main.TeleportEffect(getRect(), Style);
				teleportTime = 1f;
				teleportStyle = Style;
			}
			catch
			{
			}
		}

		public void Spawn()
		{
			if (whoAmi == Main.myPlayer)
			{
				if (Main.mapTime < 5)
				{
					Main.mapTime = 5;
				}
				Main.quickBG = 10;
				FindSpawn();
				if (!CheckSpawn(SpawnX, SpawnY))
				{
					SpawnX = -1;
					SpawnY = -1;
				}
				Main.maxQ = true;
			}
			if (Main.netMode == 1 && whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(12, -1, -1, "", Main.myPlayer);
				Main.gameMenu = false;
			}
			headPosition = Vector2.Zero;
			bodyPosition = Vector2.Zero;
			legPosition = Vector2.Zero;
			headRotation = 0f;
			bodyRotation = 0f;
			legRotation = 0f;
			lavaTime = lavaMax;
			if (statLife <= 0)
			{
				statLife = 100;
				breath = breathMax;
				if (spawnMax)
				{
					statLife = statLifeMax2;
					statMana = statManaMax2;
				}
			}
			immune = true;
			dead = false;
			immuneTime = 0;
			active = true;
			if (SpawnX >= 0 && SpawnY >= 0)
			{
				position.X = SpawnX * 16 + 8 - width / 2;
				position.Y = SpawnY * 16 - height;
			}
			else
			{
				position.X = Main.spawnTileX * 16 + 8 - width / 2;
				position.Y = Main.spawnTileY * 16 - height;
				for (int i = Main.spawnTileX - 1; i < Main.spawnTileX + 2; i++)
				{
					for (int j = Main.spawnTileY - 3; j < Main.spawnTileY; j++)
					{
						if (Main.tileSolid[Main.tile[i, j].type] && !Main.tileSolidTop[Main.tile[i, j].type])
						{
							WorldGen.KillTile(i, j);
						}
						if (Main.tile[i, j].liquid > 0)
						{
							Main.tile[i, j].lava(false);
							Main.tile[i, j].liquid = 0;
							WorldGen.SquareTileFrame(i, j);
						}
					}
				}
			}
			wet = false;
			wetCount = 0;
			lavaWet = false;
			fallStart = (int)(position.Y / 16f);
			fallStart2 = fallStart;
			velocity.X = 0f;
			velocity.Y = 0f;
			talkNPC = -1;
			Main.npcChatCornerItem = 0;
			if (pvpDeath)
			{
				pvpDeath = false;
				immuneTime = 300;
				statLife = statLifeMax;
			}
			else
			{
				immuneTime = 60;
			}
			if (whoAmi == Main.myPlayer)
			{
				Main.BlackFadeIn = 255;
				Main.renderNow = true;
				if (Main.netMode == 1)
				{
					Netplay.newRecent();
				}
				Main.screenPosition.X = position.X + (float)(width / 2) - (float)(Main.screenWidth / 2);
				Main.screenPosition.Y = position.Y + (float)(height / 2) - (float)(Main.screenHeight / 2);
			}
		}

		public void ShadowDodge()
		{
			immune = true;
			immuneTime = 80;
			if (longInvince)
			{
				immuneTime += 40;
			}
			if (whoAmi != Main.myPlayer)
			{
				return;
			}
			for (int i = 0; i < 22; i++)
			{
				if (buffTime[i] > 0 && buffType[i] == 59)
				{
					DelBuff(i);
				}
			}
			NetMessage.SendData(62, -1, -1, "", whoAmi, 2f);
		}

		public void NinjaDodge()
		{
			immune = true;
			immuneTime = 80;
			if (longInvince)
			{
				immuneTime += 40;
			}
			for (int i = 0; i < 100; i++)
			{
				int num = Dust.NewDust(new Vector2(position.X, position.Y), width, height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num].position.X += Main.rand.Next(-20, 21);
				Main.dust[num].position.Y += Main.rand.Next(-20, 21);
				Main.dust[num].velocity *= 0.4f;
				Main.dust[num].scale *= 1f + (float)Main.rand.Next(40) * 0.01f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num].scale *= 1f + (float)Main.rand.Next(40) * 0.01f;
					Main.dust[num].noGravity = true;
				}
			}
			int num2 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 24f, position.Y + (float)(height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64));
			Main.gore[num2].scale = 1.5f;
			Main.gore[num2].velocity.X = (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity.Y = (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity *= 0.4f;
			num2 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 24f, position.Y + (float)(height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64));
			Main.gore[num2].scale = 1.5f;
			Main.gore[num2].velocity.X = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity.Y = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity *= 0.4f;
			num2 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 24f, position.Y + (float)(height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64));
			Main.gore[num2].scale = 1.5f;
			Main.gore[num2].velocity.X = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity.Y = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity *= 0.4f;
			num2 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 24f, position.Y + (float)(height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64));
			Main.gore[num2].scale = 1.5f;
			Main.gore[num2].velocity.X = 1.5f + (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity.Y = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity *= 0.4f;
			num2 = Gore.NewGore(new Vector2(position.X + (float)(width / 2) - 24f, position.Y + (float)(height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64));
			Main.gore[num2].scale = 1.5f;
			Main.gore[num2].velocity.X = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity.Y = -1.5f - (float)Main.rand.Next(-50, 51) * 0.01f;
			Main.gore[num2].velocity *= 0.4f;
			if (whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(62, -1, -1, "", whoAmi, 1f);
			}
		}

		public double Hurt(int Damage, int hitDirection, bool pvp = false, bool quiet = false, string deathText = " was slain...", bool Crit = false)
		{
			if (!immune)
			{
				if (whoAmi == Main.myPlayer && blackBelt && Main.rand.Next(10) == 0)
				{
					NinjaDodge();
					return 0.0;
				}
				if (whoAmi == Main.myPlayer && shadowDodge)
				{
					ShadowDodge();
					return 0.0;
				}
				if (whoAmi == Main.myPlayer && panic)
				{
					AddBuff(63, 300);
				}
				int num = Damage;
				double num2 = Main.CalculateDamage(num, statDefense);
				if (Crit)
				{
					num *= 2;
				}
				if (num2 >= 1.0)
				{
					num2 = (int)((double)(1f - endurance) * num2);
					if (num2 < 1.0)
					{
						num2 = 1.0;
					}
					if (beetleDefense && beetleOrbs > 0)
					{
						float num3 = 0.15f * (float)beetleOrbs;
						num2 = (int)((double)(1f - num3) * num2);
						beetleOrbs--;
						for (int i = 0; i < 22; i++)
						{
							if (buffType[i] >= 95 && buffType[i] <= 97)
							{
								DelBuff(i);
							}
						}
						if (beetleOrbs > 0)
						{
							AddBuff(95 + beetleOrbs - 1, 5, false);
						}
						beetleCounter = 0f;
						if (num2 < 1.0)
						{
							num2 = 1.0;
						}
					}
					if (magicCuffs)
					{
						int num4 = num;
						statMana += num4;
						if (statMana > statManaMax2)
						{
							statMana = statManaMax2;
						}
						ManaEffect(num4);
					}
					if (paladinBuff)
					{
						int damage = (int)(num2 * 0.25);
						num2 = (int)(num2 * 0.75);
						if (whoAmi != Main.myPlayer && Main.player[Main.myPlayer].paladinGive)
						{
							int myPlayer = Main.myPlayer;
							if (Main.player[myPlayer].team == team && team != 0)
							{
								float num5 = position.X - Main.player[myPlayer].position.X;
								float num6 = position.Y - Main.player[myPlayer].position.Y;
								float num7 = (float)Math.Sqrt(num5 * num5 + num6 * num6);
								if (num7 < 800f)
								{
									Main.player[myPlayer].Hurt(damage, 0, false, false, "");
								}
							}
						}
					}
					if (Main.netMode == 1 && whoAmi == Main.myPlayer && !quiet)
					{
						int number = 0;
						if (Crit)
						{
							number = 1;
						}
						int num8 = 0;
						if (pvp)
						{
							num8 = 1;
						}
						NetMessage.SendData(13, -1, -1, "", whoAmi);
						NetMessage.SendData(16, -1, -1, "", whoAmi);
						NetMessage.SendData(26, -1, -1, "", whoAmi, hitDirection, Damage, num8, number);
					}
					CombatText.NewText(new Rectangle((int)position.X, (int)position.Y, width, height), new Color(255, 80, 90, 255), string.Concat((int)num2), Crit);
					statLife -= (int)num2;
					immune = true;
					if (num2 == 1.0)
					{
						immuneTime = 20;
						if (longInvince)
						{
							immuneTime += 20;
						}
					}
					else
					{
						immuneTime = 40;
						if (longInvince)
						{
							immuneTime += 40;
						}
					}
					lifeRegenTime = 0;
					if (pvp)
					{
						immuneTime = 8;
					}
					if (whoAmi == Main.myPlayer)
					{
						if (starCloak)
						{
							for (int j = 0; j < 3; j++)
							{
								float x = position.X + (float)Main.rand.Next(-400, 400);
								float y = position.Y - (float)Main.rand.Next(500, 800);
								Vector2 vector = new Vector2(x, y);
								float num9 = position.X + (float)(width / 2) - vector.X;
								float num10 = position.Y + (float)(height / 2) - vector.Y;
								num9 += (float)Main.rand.Next(-100, 101);
								int num11 = 23;
								float num12 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
								num12 = (float)num11 / num12;
								num9 *= num12;
								num10 *= num12;
								int num13 = Projectile.NewProjectile(x, y, num9, num10, 92, 30, 5f, whoAmi);
								Main.projectile[num13].ai[1] = position.Y;
							}
						}
						if (bee)
						{
							int num14 = 1;
							if (Main.rand.Next(3) == 0)
							{
								num14++;
							}
							if (Main.rand.Next(3) == 0)
							{
								num14++;
							}
							for (int k = 0; k < num14; k++)
							{
								float speedX = (float)Main.rand.Next(-35, 36) * 0.02f;
								float speedY = (float)Main.rand.Next(-35, 36) * 0.02f;
								Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 181, 7, 0f, Main.myPlayer);
							}
						}
					}
					if (!noKnockback && hitDirection != 0 && (!mount.Active || mount.Type != 6))
					{
						velocity.X = 4.5f * (float)hitDirection;
						velocity.Y = -3.5f;
					}
					if (frostArmor)
					{
						Main.PlaySound(2, (int)position.X, (int)position.Y, 27);
					}
					else if (wereWolf)
					{
						Main.PlaySound(3, (int)position.X, (int)position.Y, 6);
					}
					else if (boneArmor)
					{
						Main.PlaySound(3, (int)position.X, (int)position.Y, 2);
					}
					else if (!male)
					{
						Main.PlaySound(20, (int)position.X, (int)position.Y);
					}
					else
					{
						Main.PlaySound(1, (int)position.X, (int)position.Y);
					}
					if (statLife > 0)
					{
						for (int l = 0; (double)l < num2 / (double)statLifeMax2 * 100.0; l++)
						{
							if (frostArmor)
							{
								Dust.NewDust(position, width, height, 135, 2 * hitDirection, -2f);
							}
							else if (boneArmor)
							{
								Dust.NewDust(position, width, height, 26, 2 * hitDirection, -2f);
							}
							else
							{
								Dust.NewDust(position, width, height, 5, 2 * hitDirection, -2f);
							}
						}
					}
					else
					{
						statLife = 0;
						if (whoAmi == Main.myPlayer)
						{
							KillMe(num2, hitDirection, pvp, deathText);
						}
					}
				}
				if (pvp)
				{
					num2 = Main.CalculateDamage(num, statDefense);
				}
				return num2;
			}
			return 0.0;
		}

		public void KillMeForGood()
		{
			if (File.Exists(Main.playerPathName))
			{
				File.Delete(Main.playerPathName);
			}
			if (File.Exists(Main.playerPathName + ".bak"))
			{
				File.Delete(Main.playerPathName + ".bak");
			}
			if (File.Exists(Main.playerPathName + ".dat"))
			{
				File.Delete(Main.playerPathName + ".dat");
			}
			Main.playerPathName = "";
		}

		public void KillMe(double dmg, int hitDirection, bool pvp = false, string deathText = " was slain...")
		{
			if (dead)
			{
				return;
			}
			if (pvp)
			{
				pvpDeath = true;
			}
			if (difficulty == 0)
			{
				if (Main.netMode != 1)
				{
					float num;
					for (num = (float)Main.rand.Next(-35, 36) * 0.1f; num < 2f && num > -2f; num += (float)Main.rand.Next(-30, 31) * 0.1f)
					{
					}
					int num2 = Main.rand.Next(6);
					num2 = ((num2 != 0) ? (200 + num2) : 43);
					int num3 = Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(height / 2), (float)Main.rand.Next(10, 30) * 0.1f * (float)hitDirection + num, (float)Main.rand.Next(-40, -20) * 0.1f, num2, 0, 0f, Main.myPlayer);
					Main.projectile[num3].miscText = name + deathText;
				}
				if (Main.myPlayer == whoAmi)
				{
					for (int i = 0; i < 59; i++)
					{
						if (inventory[i].stack > 0 && inventory[i].type >= 1522 && inventory[i].type <= 1527)
						{
							int num4 = Item.NewItem((int)position.X, (int)position.Y, width, height, inventory[i].type);
							Main.item[num4].netDefaults(inventory[i].netID);
							Main.item[num4].Prefix(inventory[i].prefix);
							Main.item[num4].stack = inventory[i].stack;
							Main.item[num4].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
							Main.item[num4].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
							Main.item[num4].noGrabDelay = 100;
							if (Main.netMode == 1)
							{
								NetMessage.SendData(21, -1, -1, "", num4);
							}
							inventory[i].SetDefaults(0);
						}
					}
					Main.mapFullscreen = false;
				}
			}
			else
			{
				if (Main.netMode != 1)
				{
					float num5;
					for (num5 = (float)Main.rand.Next(-35, 36) * 0.1f; num5 < 2f && num5 > -2f; num5 += (float)Main.rand.Next(-30, 31) * 0.1f)
					{
					}
					int num6 = Main.rand.Next(6);
					num6 = ((num6 != 0) ? (200 + num6) : 43);
					int num7 = Projectile.NewProjectile(position.X + (float)(width / 2), position.Y + (float)(head / 2), (float)Main.rand.Next(10, 30) * 0.1f * (float)hitDirection + num5, (float)Main.rand.Next(-40, -20) * 0.1f, num6, 0, 0f, Main.myPlayer);
					Main.projectile[num7].miscText = name + deathText;
				}
				if (Main.myPlayer == whoAmi)
				{
					if (Main.myPlayer == whoAmi)
					{
						Main.mapFullscreen = false;
					}
					Main.trashItem.SetDefaults(0);
					if (difficulty == 1)
					{
						DropItems();
					}
					else if (difficulty == 2)
					{
						DropItems();
						KillMeForGood();
					}
				}
			}
			Main.PlaySound(5, (int)position.X, (int)position.Y);
			headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
			bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
			legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
			headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
			bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
			legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
			for (int j = 0; j < 100; j++)
			{
				if (boneArmor)
				{
					Dust.NewDust(position, width, height, 26, 2 * hitDirection, -2f);
				}
				else
				{
					Dust.NewDust(position, width, height, 5, 2 * hitDirection, -2f);
				}
			}
			mount.Dismount(this);
			dead = true;
			respawnTimer = 600;
			bool flag = false;
			if (Main.netMode != 0 && !pvp)
			{
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && (Main.npc[k].boss || Main.npc[k].type == 13 || Main.npc[k].type == 14 || Main.npc[k].type == 15) && Math.Abs(center().X - Main.npc[k].center().X) + Math.Abs(center().Y - Main.npc[k].center().Y) < 4000f)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				respawnTimer += 600;
			}
			immuneAlpha = 0;
			palladiumRegen = false;
			iceBarrier = false;
			crystalLeaf = false;
			if (Main.netMode == 2)
			{
				NetMessage.SendData(25, -1, -1, name + deathText, 255, 225f, 25f, 25f);
			}
			else if (Main.netMode == 0)
			{
				Main.NewText(name + deathText, 225, 25, 25);
			}
			if (Main.netMode == 1 && whoAmi == Main.myPlayer)
			{
				int num8 = 0;
				if (pvp)
				{
					num8 = 1;
				}
				NetMessage.SendData(44, -1, -1, deathText, whoAmi, hitDirection, (int)dmg, num8);
			}
			if (!pvp && whoAmi == Main.myPlayer && difficulty == 0)
			{
				DropCoins();
			}
			if (whoAmi != Main.myPlayer)
			{
				return;
			}
			try
			{
				WorldGen.saveToonWhilePlaying();
			}
			catch
			{
			}
		}

		public bool ItemSpace(Item newItem)
		{
			if (newItem.uniqueStack && HasItem(newItem.type))
			{
				return false;
			}
			if (newItem.type == 58 || newItem.type == 184 || newItem.type == 1734 || newItem.type == 1735 || newItem.type == 1867 || newItem.type == 1868)
			{
				return true;
			}
			int num = 50;
			if (newItem.type == 71 || newItem.type == 72 || newItem.type == 73 || newItem.type == 74)
			{
				num = 54;
			}
			for (int i = 0; i < num; i++)
			{
				if (inventory[i].type == 0)
				{
					return true;
				}
			}
			for (int j = 0; j < num; j++)
			{
				if (inventory[j].type > 0 && inventory[j].stack < inventory[j].maxStack && newItem.IsTheSameAs(inventory[j]))
				{
					return true;
				}
			}
			if (newItem.ammo > 0 && !newItem.notAmmo)
			{
				if (newItem.type != 75 && newItem.type != 169 && newItem.type != 23 && newItem.type != 408 && newItem.type != 370 && newItem.type != 1246)
				{
					for (int k = 54; k < 58; k++)
					{
						if (inventory[k].type == 0)
						{
							return true;
						}
					}
				}
				for (int l = 54; l < 58; l++)
				{
					if (inventory[l].type > 0 && inventory[l].stack < inventory[l].maxStack && newItem.IsTheSameAs(inventory[l]))
					{
						return true;
					}
				}
			}
			return false;
		}

		public void DoCoins(int i)
		{
			if (inventory[i].stack != 100 || (inventory[i].type != 71 && inventory[i].type != 72 && inventory[i].type != 73))
			{
				return;
			}
			inventory[i].SetDefaults(inventory[i].type + 1);
			for (int j = 0; j < 54; j++)
			{
				if (inventory[j].IsTheSameAs(inventory[i]) && j != i && inventory[j].type == inventory[i].type && inventory[j].stack < inventory[j].maxStack)
				{
					inventory[j].stack++;
					inventory[i].SetDefaults(0);
					inventory[i].active = false;
					inventory[i].name = "";
					inventory[i].type = 0;
					inventory[i].stack = 0;
					DoCoins(j);
				}
			}
		}

		public Item FillAmmo(int plr, Item newItem)
		{
			for (int i = 54; i < 58; i++)
			{
				if (inventory[i].type <= 0 || inventory[i].stack >= inventory[i].maxStack || !newItem.IsTheSameAs(inventory[i]))
				{
					continue;
				}
				Main.PlaySound(7, (int)position.X, (int)position.Y);
				if (newItem.stack + inventory[i].stack <= inventory[i].maxStack)
				{
					inventory[i].stack += newItem.stack;
					ItemText.NewText(newItem, newItem.stack);
					DoCoins(i);
					if (plr == Main.myPlayer)
					{
						Recipe.FindRecipes();
					}
					return new Item();
				}
				newItem.stack -= inventory[i].maxStack - inventory[i].stack;
				ItemText.NewText(newItem, inventory[i].maxStack - inventory[i].stack);
				inventory[i].stack = inventory[i].maxStack;
				DoCoins(i);
				if (plr == Main.myPlayer)
				{
					Recipe.FindRecipes();
				}
			}
			if (newItem.type != 169 && newItem.type != 75 && newItem.type != 23 && newItem.type != 408 && newItem.type != 370 && newItem.type != 1246 && !newItem.notAmmo)
			{
				for (int j = 54; j < 58; j++)
				{
					if (inventory[j].type == 0)
					{
						inventory[j] = newItem;
						ItemText.NewText(newItem, newItem.stack);
						DoCoins(j);
						Main.PlaySound(7, (int)position.X, (int)position.Y);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						return new Item();
					}
				}
			}
			return newItem;
		}

		public Item GetItem(int plr, Item newItem, bool longText = false)
		{
			Item item = newItem;
			int num = 50;
			if (newItem.noGrabDelay > 0)
			{
				return item;
			}
			int num2 = 0;
			if (newItem.uniqueStack && HasItem(newItem.type))
			{
				return item;
			}
			if (newItem.type == 71 || newItem.type == 72 || newItem.type == 73 || newItem.type == 74)
			{
				num2 = -4;
				num = 54;
			}
			if (item.ammo > 0 && !item.notAmmo)
			{
				item = FillAmmo(plr, item);
				if (item.type == 0 || item.stack == 0)
				{
					return new Item();
				}
			}
			for (int i = num2; i < 50; i++)
			{
				int num3 = i;
				if (num3 < 0)
				{
					num3 = 54 + i;
				}
				if (inventory[num3].type <= 0 || inventory[num3].stack >= inventory[num3].maxStack || !item.IsTheSameAs(inventory[num3]))
				{
					continue;
				}
				Main.PlaySound(7, (int)position.X, (int)position.Y);
				if (item.stack + inventory[num3].stack <= inventory[num3].maxStack)
				{
					inventory[num3].stack += item.stack;
					ItemText.NewText(newItem, item.stack, false, longText);
					DoCoins(num3);
					if (plr == Main.myPlayer)
					{
						Recipe.FindRecipes();
					}
					return new Item();
				}
				item.stack -= inventory[num3].maxStack - inventory[num3].stack;
				ItemText.NewText(newItem, inventory[num3].maxStack - inventory[num3].stack, false, longText);
				inventory[num3].stack = inventory[num3].maxStack;
				DoCoins(num3);
				if (plr == Main.myPlayer)
				{
					Recipe.FindRecipes();
				}
			}
			if (newItem.type != 71 && newItem.type != 72 && newItem.type != 73 && newItem.type != 74 && newItem.useStyle > 0)
			{
				for (int j = 0; j < 10; j++)
				{
					if (inventory[j].type == 0)
					{
						inventory[j] = item;
						ItemText.NewText(newItem, newItem.stack, false, longText);
						DoCoins(j);
						Main.PlaySound(7, (int)position.X, (int)position.Y);
						if (plr == Main.myPlayer)
						{
							Recipe.FindRecipes();
						}
						return new Item();
					}
				}
			}
			for (int num4 = num - 1; num4 >= 0; num4--)
			{
				if (inventory[num4].type == 0)
				{
					inventory[num4] = item;
					ItemText.NewText(newItem, newItem.stack, false, longText);
					DoCoins(num4);
					Main.PlaySound(7, (int)position.X, (int)position.Y);
					if (plr == Main.myPlayer)
					{
						Recipe.FindRecipes();
					}
					return new Item();
				}
			}
			return item;
		}

		public void PlaceThing()
		{
			if ((inventory[selectedItem].type == 1071 || inventory[selectedItem].type == 1543) && position.X / 16f - (float)tileRangeX - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetX && (position.X + (float)width) / 16f + (float)tileRangeX + (float)inventory[selectedItem].tileBoost - 1f + (float)blockRange >= (float)tileTargetX && position.Y / 16f - (float)tileRangeY - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetY && (position.Y + (float)height) / 16f + (float)tileRangeY + (float)inventory[selectedItem].tileBoost - 2f + (float)blockRange >= (float)tileTargetY)
			{
				int num = tileTargetX;
				int num2 = tileTargetY;
				if (Main.tile[num, num2] != null && Main.tile[num, num2].active())
				{
					showItemIcon = true;
					if (itemTime == 0 && itemAnimation > 0 && controlUseItem)
					{
						int num3 = -1;
						int num4 = -1;
						for (int i = 0; i < 58; i++)
						{
							if (inventory[i].stack > 0 && inventory[i].paint > 0)
							{
								num3 = inventory[i].paint;
								num4 = i;
								break;
							}
						}
						if (num3 > 0 && Main.tile[num, num2].color() != num3 && WorldGen.paintTile(num, num2, (byte)num3, true))
						{
							int num5 = num4;
							inventory[num5].stack--;
							if (inventory[num5].stack <= 0)
							{
								inventory[num5].SetDefaults(0);
							}
							itemTime = inventory[selectedItem].useTime;
						}
					}
				}
			}
			if ((inventory[selectedItem].type == 1072 || inventory[selectedItem].type == 1544) && position.X / 16f - (float)tileRangeX - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetX && (position.X + (float)width) / 16f + (float)tileRangeX + (float)inventory[selectedItem].tileBoost - 1f + (float)blockRange >= (float)tileTargetX && position.Y / 16f - (float)tileRangeY - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetY && (position.Y + (float)height) / 16f + (float)tileRangeY + (float)inventory[selectedItem].tileBoost - 2f + (float)blockRange >= (float)tileTargetY)
			{
				int num6 = tileTargetX;
				int num7 = tileTargetY;
				if (Main.tile[num6, num7] != null && Main.tile[num6, num7].wall > 0)
				{
					showItemIcon = true;
					if (itemTime == 0 && itemAnimation > 0 && controlUseItem)
					{
						int num8 = -1;
						int num9 = -1;
						for (int j = 0; j < 58; j++)
						{
							if (inventory[j].stack > 0 && inventory[j].paint > 0)
							{
								num8 = inventory[j].paint;
								num9 = j;
								break;
							}
						}
						if (num8 > 0 && Main.tile[num6, num7].wallColor() != num8 && WorldGen.paintWall(num6, num7, (byte)num8, true))
						{
							int num10 = num9;
							inventory[num10].stack--;
							if (inventory[num10].stack <= 0)
							{
								inventory[num10].SetDefaults(0);
							}
							itemTime = inventory[selectedItem].useTime;
						}
					}
				}
			}
			if ((inventory[selectedItem].type == 1100 || inventory[selectedItem].type == 1545) && position.X / 16f - (float)tileRangeX - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetX && (position.X + (float)width) / 16f + (float)tileRangeX + (float)inventory[selectedItem].tileBoost - 1f + (float)blockRange >= (float)tileTargetX && position.Y / 16f - (float)tileRangeY - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetY && (position.Y + (float)height) / 16f + (float)tileRangeY + (float)inventory[selectedItem].tileBoost - 2f + (float)blockRange >= (float)tileTargetY)
			{
				int num11 = tileTargetX;
				int num12 = tileTargetY;
				if (Main.tile[num11, num12] != null && ((Main.tile[num11, num12].wallColor() > 0 && Main.tile[num11, num12].wall > 0) || (Main.tile[num11, num12].color() > 0 && Main.tile[num11, num12].active())))
				{
					showItemIcon = true;
					if (itemTime == 0 && itemAnimation > 0 && controlUseItem)
					{
						if (Main.tile[num11, num12].color() > 0 && Main.tile[num11, num12].active() && WorldGen.paintTile(num11, num12, 0, true))
						{
							itemTime = inventory[selectedItem].useTime;
						}
						else if (Main.tile[num11, num12].wallColor() > 0 && Main.tile[num11, num12].wall > 0 && WorldGen.paintWall(num11, num12, 0, true))
						{
							itemTime = inventory[selectedItem].useTime;
						}
					}
				}
			}
			if ((inventory[selectedItem].type == 929 || inventory[selectedItem].type == 1338) && position.X / 16f - (float)tileRangeX - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetX && (position.X + (float)width) / 16f + (float)tileRangeX + (float)inventory[selectedItem].tileBoost - 1f + (float)blockRange >= (float)tileTargetX && position.Y / 16f - (float)tileRangeY - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetY && (position.Y + (float)height) / 16f + (float)tileRangeY + (float)inventory[selectedItem].tileBoost - 2f + (float)blockRange >= (float)tileTargetY)
			{
				int num13 = tileTargetX;
				int num14 = tileTargetY;
				if (Main.tile[num13, num14].active() && Main.tile[num13, num14].type == 209)
				{
					int num15 = 0;
					if (Main.tile[num13, num14].frameX < 72)
					{
						if (inventory[selectedItem].type == 929)
						{
							num15 = 1;
						}
					}
					else if (Main.tile[num13, num14].frameX < 144 && inventory[selectedItem].type == 1338)
					{
						num15 = 2;
					}
					if (num15 > 0)
					{
						showItemIcon = true;
						if (itemTime == 0 && itemAnimation > 0 && controlUseItem)
						{
							int num16 = Main.tile[num13, num14].frameX / 18;
							int num17 = 0;
							int num18 = 0;
							while (num16 >= 4)
							{
								num17++;
								num16 -= 4;
							}
							num16 = num13 - num16;
							int num19;
							for (num19 = Main.tile[num13, num14].frameY / 18; num19 >= 3; num19 -= 3)
							{
								num18++;
							}
							num19 = num14 - num19;
							itemTime = inventory[selectedItem].useTime;
							float num20 = 14f;
							float num21 = 0f;
							float num22 = 0f;
							int type = 162;
							if (num15 == 2)
							{
								type = 281;
							}
							int damage = inventory[selectedItem].damage;
							int num23 = 8;
							if (num18 == 0)
							{
								num21 = 10f;
								num22 = 0f;
							}
							if (num18 == 1)
							{
								num21 = 7.5f;
								num22 = -2.5f;
							}
							if (num18 == 2)
							{
								num21 = 5f;
								num22 = -5f;
							}
							if (num18 == 3)
							{
								num21 = 2.75f;
								num22 = -6f;
							}
							if (num18 == 4)
							{
								num21 = 0f;
								num22 = -10f;
							}
							if (num18 == 5)
							{
								num21 = -2.75f;
								num22 = -6f;
							}
							if (num18 == 6)
							{
								num21 = -5f;
								num22 = -5f;
							}
							if (num18 == 7)
							{
								num21 = -7.5f;
								num22 = -2.5f;
							}
							if (num18 == 8)
							{
								num21 = -10f;
								num22 = 0f;
							}
							Vector2 vector = new Vector2((num16 + 2) * 16, (num19 + 2) * 16);
							float num24 = num21;
							float num25 = num22;
							float num26 = (float)Math.Sqrt(num24 * num24 + num25 * num25);
							num26 = num20 / num26;
							num24 *= num26;
							num25 *= num26;
							Projectile.NewProjectile(vector.X, vector.Y, num24, num25, type, damage, num23, Main.myPlayer);
						}
					}
				}
			}
			if (inventory[selectedItem].type >= 1874 && inventory[selectedItem].type <= 1905 && Main.tile[tileTargetX, tileTargetY].active() && Main.tile[tileTargetX, tileTargetY].type == 171 && position.X / 16f - (float)tileRangeX - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetX && (position.X + (float)width) / 16f + (float)tileRangeX + (float)inventory[selectedItem].tileBoost - 1f + (float)blockRange >= (float)tileTargetX && position.Y / 16f - (float)tileRangeY - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetY && (position.Y + (float)height) / 16f + (float)tileRangeY + (float)inventory[selectedItem].tileBoost - 2f + (float)blockRange >= (float)tileTargetY && itemTime == 0 && itemAnimation > 0 && controlUseItem)
			{
				int type2 = inventory[selectedItem].type;
				if (type2 >= 1874 && type2 <= 1877)
				{
					type2 -= 1873;
					if (WorldGen.checkXmasTreeDrop(tileTargetX, tileTargetY, 0) != type2)
					{
						itemTime = inventory[selectedItem].useTime;
						WorldGen.dropXmasTree(tileTargetX, tileTargetY, 0);
						WorldGen.setXmasTree(tileTargetX, tileTargetY, 0, type2);
						int num27 = tileTargetX;
						int num28 = tileTargetY;
						if (Main.tile[tileTargetX, tileTargetY].frameX < 10)
						{
							num27 -= Main.tile[tileTargetX, tileTargetY].frameX;
							num28 -= Main.tile[tileTargetX, tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num27, num28, 1);
					}
				}
				else if (type2 >= 1878 && type2 <= 1883)
				{
					type2 -= 1877;
					if (WorldGen.checkXmasTreeDrop(tileTargetX, tileTargetY, 1) != type2)
					{
						itemTime = inventory[selectedItem].useTime;
						WorldGen.dropXmasTree(tileTargetX, tileTargetY, 1);
						WorldGen.setXmasTree(tileTargetX, tileTargetY, 1, type2);
						int num29 = tileTargetX;
						int num30 = tileTargetY;
						if (Main.tile[tileTargetX, tileTargetY].frameX < 10)
						{
							num29 -= Main.tile[tileTargetX, tileTargetY].frameX;
							num30 -= Main.tile[tileTargetX, tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num29, num30, 1);
					}
				}
				else if (type2 >= 1884 && type2 <= 1894)
				{
					type2 -= 1883;
					if (WorldGen.checkXmasTreeDrop(tileTargetX, tileTargetY, 2) != type2)
					{
						itemTime = inventory[selectedItem].useTime;
						WorldGen.dropXmasTree(tileTargetX, tileTargetY, 2);
						WorldGen.setXmasTree(tileTargetX, tileTargetY, 2, type2);
						int num31 = tileTargetX;
						int num32 = tileTargetY;
						if (Main.tile[tileTargetX, tileTargetY].frameX < 10)
						{
							num31 -= Main.tile[tileTargetX, tileTargetY].frameX;
							num32 -= Main.tile[tileTargetX, tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num31, num32, 1);
					}
				}
				else if (type2 >= 1895 && type2 <= 1905)
				{
					type2 -= 1894;
					if (WorldGen.checkXmasTreeDrop(tileTargetX, tileTargetY, 3) != type2)
					{
						itemTime = inventory[selectedItem].useTime;
						WorldGen.dropXmasTree(tileTargetX, tileTargetY, 3);
						WorldGen.setXmasTree(tileTargetX, tileTargetY, 3, type2);
						int num33 = tileTargetX;
						int num34 = tileTargetY;
						if (Main.tile[tileTargetX, tileTargetY].frameX < 10)
						{
							num33 -= Main.tile[tileTargetX, tileTargetY].frameX;
							num34 -= Main.tile[tileTargetX, tileTargetY].frameY;
						}
						NetMessage.SendTileSquare(-1, num33, num34, 1);
					}
				}
			}
			if ((inventory[selectedItem].type == 424 || inventory[selectedItem].type == 1103) && Main.tile[tileTargetX, tileTargetY].active() && Main.tile[tileTargetX, tileTargetY].type == 219)
			{
				if (position.X / 16f - (float)tileRangeX - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetX && (position.X + (float)width) / 16f + (float)tileRangeX + (float)inventory[selectedItem].tileBoost - 1f + (float)blockRange >= (float)tileTargetX && position.Y / 16f - (float)tileRangeY - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetY && (position.Y + (float)height) / 16f + (float)tileRangeY + (float)inventory[selectedItem].tileBoost - 2f + (float)blockRange >= (float)tileTargetY && itemTime == 0 && itemAnimation > 0 && controlUseItem)
				{
					itemTime = inventory[selectedItem].useTime;
					if (inventory[selectedItem].stack <= 0)
					{
						inventory[selectedItem].SetDefaults(0);
					}
					if (selectedItem == 48)
					{
						Main.mouseItem = inventory[selectedItem];
					}
					Main.PlaySound(7);
					int num35 = -1;
					int num36 = 1;
					if (Main.rand.Next(2) == 0)
					{
						if (Main.rand.Next(10000) == 0)
						{
							num35 = 74;
							if (Main.rand.Next(12) == 0)
							{
								num36 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(12) == 0)
							{
								num36 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(12) == 0)
							{
								num36 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(12) == 0)
							{
								num36 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(12) == 0)
							{
								num36 += Main.rand.Next(0, 3);
							}
						}
						else if (Main.rand.Next(800) == 0)
						{
							num35 = 73;
							if (Main.rand.Next(6) == 0)
							{
								num36 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(6) == 0)
							{
								num36 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(6) == 0)
							{
								num36 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(6) == 0)
							{
								num36 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(6) == 0)
							{
								num36 += Main.rand.Next(1, 20);
							}
						}
						else if (Main.rand.Next(60) == 0)
						{
							num35 = 72;
							if (Main.rand.Next(4) == 0)
							{
								num36 += Main.rand.Next(5, 26);
							}
							if (Main.rand.Next(4) == 0)
							{
								num36 += Main.rand.Next(5, 26);
							}
							if (Main.rand.Next(4) == 0)
							{
								num36 += Main.rand.Next(5, 26);
							}
							if (Main.rand.Next(4) == 0)
							{
								num36 += Main.rand.Next(5, 25);
							}
						}
						else
						{
							num35 = 71;
							if (Main.rand.Next(3) == 0)
							{
								num36 += Main.rand.Next(10, 26);
							}
							if (Main.rand.Next(3) == 0)
							{
								num36 += Main.rand.Next(10, 26);
							}
							if (Main.rand.Next(3) == 0)
							{
								num36 += Main.rand.Next(10, 26);
							}
							if (Main.rand.Next(3) == 0)
							{
								num36 += Main.rand.Next(10, 25);
							}
						}
					}
					else if (Main.rand.Next(5000) == 0)
					{
						num35 = 1242;
					}
					else if (Main.rand.Next(25) == 0)
					{
						switch (Main.rand.Next(6))
						{
						case 0:
							num35 = 181;
							break;
						case 1:
							num35 = 180;
							break;
						case 2:
							num35 = 177;
							break;
						case 3:
							num35 = 179;
							break;
						case 4:
							num35 = 178;
							break;
						default:
							num35 = 182;
							break;
						}
						if (Main.rand.Next(20) == 0)
						{
							num36 += Main.rand.Next(0, 2);
						}
						if (Main.rand.Next(30) == 0)
						{
							num36 += Main.rand.Next(0, 3);
						}
						if (Main.rand.Next(40) == 0)
						{
							num36 += Main.rand.Next(0, 4);
						}
						if (Main.rand.Next(50) == 0)
						{
							num36 += Main.rand.Next(0, 5);
						}
						if (Main.rand.Next(60) == 0)
						{
							num36 += Main.rand.Next(0, 6);
						}
					}
					else if (Main.rand.Next(50) == 0)
					{
						num35 = 999;
						if (Main.rand.Next(20) == 0)
						{
							num36 += Main.rand.Next(0, 2);
						}
						if (Main.rand.Next(30) == 0)
						{
							num36 += Main.rand.Next(0, 3);
						}
						if (Main.rand.Next(40) == 0)
						{
							num36 += Main.rand.Next(0, 4);
						}
						if (Main.rand.Next(50) == 0)
						{
							num36 += Main.rand.Next(0, 5);
						}
						if (Main.rand.Next(60) == 0)
						{
							num36 += Main.rand.Next(0, 6);
						}
					}
					else if (Main.rand.Next(3) == 0)
					{
						if (Main.rand.Next(5000) == 0)
						{
							num35 = 74;
							if (Main.rand.Next(10) == 0)
							{
								num36 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(10) == 0)
							{
								num36 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(10) == 0)
							{
								num36 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(10) == 0)
							{
								num36 += Main.rand.Next(0, 3);
							}
							if (Main.rand.Next(10) == 0)
							{
								num36 += Main.rand.Next(0, 3);
							}
						}
						else if (Main.rand.Next(400) == 0)
						{
							num35 = 73;
							if (Main.rand.Next(5) == 0)
							{
								num36 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(5) == 0)
							{
								num36 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(5) == 0)
							{
								num36 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(5) == 0)
							{
								num36 += Main.rand.Next(1, 21);
							}
							if (Main.rand.Next(5) == 0)
							{
								num36 += Main.rand.Next(1, 20);
							}
						}
						else if (Main.rand.Next(30) == 0)
						{
							num35 = 72;
							if (Main.rand.Next(3) == 0)
							{
								num36 += Main.rand.Next(5, 26);
							}
							if (Main.rand.Next(3) == 0)
							{
								num36 += Main.rand.Next(5, 26);
							}
							if (Main.rand.Next(3) == 0)
							{
								num36 += Main.rand.Next(5, 26);
							}
							if (Main.rand.Next(3) == 0)
							{
								num36 += Main.rand.Next(5, 25);
							}
						}
						else
						{
							num35 = 71;
							if (Main.rand.Next(2) == 0)
							{
								num36 += Main.rand.Next(10, 26);
							}
							if (Main.rand.Next(2) == 0)
							{
								num36 += Main.rand.Next(10, 26);
							}
							if (Main.rand.Next(2) == 0)
							{
								num36 += Main.rand.Next(10, 26);
							}
							if (Main.rand.Next(2) == 0)
							{
								num36 += Main.rand.Next(10, 25);
							}
						}
					}
					else
					{
						switch (Main.rand.Next(8))
						{
						case 0:
							num35 = 12;
							break;
						case 1:
							num35 = 11;
							break;
						case 2:
							num35 = 14;
							break;
						case 3:
							num35 = 13;
							break;
						case 4:
							num35 = 699;
							break;
						case 5:
							num35 = 700;
							break;
						case 6:
							num35 = 701;
							break;
						default:
							num35 = 702;
							break;
						}
						if (Main.rand.Next(20) == 0)
						{
							num36 += Main.rand.Next(0, 2);
						}
						if (Main.rand.Next(30) == 0)
						{
							num36 += Main.rand.Next(0, 3);
						}
						if (Main.rand.Next(40) == 0)
						{
							num36 += Main.rand.Next(0, 4);
						}
						if (Main.rand.Next(50) == 0)
						{
							num36 += Main.rand.Next(0, 5);
						}
						if (Main.rand.Next(60) == 0)
						{
							num36 += Main.rand.Next(0, 6);
						}
					}
					if (num35 > 0)
					{
						int number = Item.NewItem((int)Main.screenPosition.X + Main.mouseX, (int)Main.screenPosition.Y + Main.mouseY, 1, 1, num35, num36, false, -1);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", number, 1f);
						}
					}
				}
			}
			else if (inventory[selectedItem].createTile >= 0 && position.X / 16f - (float)tileRangeX - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetX && (position.X + (float)width) / 16f + (float)tileRangeX + (float)inventory[selectedItem].tileBoost - 1f + (float)blockRange >= (float)tileTargetX && position.Y / 16f - (float)tileRangeY - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetY && (position.Y + (float)height) / 16f + (float)tileRangeY + (float)inventory[selectedItem].tileBoost - 2f + (float)blockRange >= (float)tileTargetY)
			{
				showItemIcon = true;
				bool flag = false;
				if (Main.tile[tileTargetX, tileTargetY].liquid > 0 && Main.tile[tileTargetX, tileTargetY].lava())
				{
					if (Main.tileSolid[inventory[selectedItem].createTile])
					{
						flag = true;
					}
					else if (Main.tileLavaDeath[inventory[selectedItem].createTile])
					{
						flag = true;
					}
				}
				bool flag2 = true;
				if (inventory[selectedItem].tileWand > 0)
				{
					int tileWand = inventory[selectedItem].tileWand;
					flag2 = false;
					for (int k = 0; k < 58; k++)
					{
						if (tileWand == inventory[k].type && inventory[k].stack > 0)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (Main.tileRope[inventory[selectedItem].createTile] && flag2 && Main.tile[tileTargetX, tileTargetY].active() && Main.tileRope[Main.tile[tileTargetX, tileTargetY].type])
				{
					int num37 = tileTargetY;
					int num38 = tileTargetX;
					int createTile = inventory[selectedItem].createTile;
					while (Main.tile[num38, num37].active() && Main.tile[num38, num37].type == createTile && num37 < Main.maxTilesX - 5)
					{
						num37++;
						if (Main.tile[num38, num37] == null)
						{
							flag2 = false;
							num37 = tileTargetY;
						}
					}
					if (!Main.tile[num38, num37].active())
					{
						tileTargetY = num37;
					}
				}
				if (flag2 && ((!Main.tile[tileTargetX, tileTargetY].active() && !flag) || Main.tileCut[Main.tile[tileTargetX, tileTargetY].type] || inventory[selectedItem].createTile == 199 || inventory[selectedItem].createTile == 23 || inventory[selectedItem].createTile == 2 || inventory[selectedItem].createTile == 109 || inventory[selectedItem].createTile == 60 || inventory[selectedItem].createTile == 70) && itemTime == 0 && itemAnimation > 0 && controlUseItem)
				{
					bool flag3 = false;
					if (inventory[selectedItem].createTile == 23 || inventory[selectedItem].createTile == 2 || inventory[selectedItem].createTile == 109 || inventory[selectedItem].createTile == 199)
					{
						if (Main.tile[tileTargetX, tileTargetY].nactive() && Main.tile[tileTargetX, tileTargetY].type == 0)
						{
							flag3 = true;
						}
					}
					else if (inventory[selectedItem].createTile == 227)
					{
						flag3 = true;
					}
					else if (inventory[selectedItem].createTile == 60 || inventory[selectedItem].createTile == 70)
					{
						if (Main.tile[tileTargetX, tileTargetY].nactive() && Main.tile[tileTargetX, tileTargetY].type == 59)
						{
							flag3 = true;
						}
					}
					else if (inventory[selectedItem].createTile == 4 || inventory[selectedItem].createTile == 136)
					{
						if (Main.tile[tileTargetX, tileTargetY].wall > 0)
						{
							flag3 = true;
						}
						else
						{
							if (!WorldGen.SolidTileNoAttach(tileTargetX, tileTargetY + 1) && !WorldGen.SolidTileNoAttach(tileTargetX - 1, tileTargetY) && !WorldGen.SolidTileNoAttach(tileTargetX + 1, tileTargetY))
							{
								if (!WorldGen.SolidTileNoAttach(tileTargetX, tileTargetY + 1) && (Main.tile[tileTargetX, tileTargetY + 1].halfBrick() || Main.tile[tileTargetX, tileTargetY + 1].slope() != 0))
								{
									if (Main.tile[tileTargetX, tileTargetY + 1].type != 19)
									{
										WorldGen.SlopeTile(tileTargetX, tileTargetY + 1);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 14, tileTargetX, tileTargetY + 1);
										}
									}
								}
								else if (!WorldGen.SolidTileNoAttach(tileTargetX, tileTargetY + 1) && !WorldGen.SolidTileNoAttach(tileTargetX - 1, tileTargetY) && (Main.tile[tileTargetX - 1, tileTargetY].halfBrick() || Main.tile[tileTargetX - 1, tileTargetY].slope() != 0))
								{
									if (Main.tile[tileTargetX, tileTargetY + 1].type != 19)
									{
										WorldGen.SlopeTile(tileTargetX - 1, tileTargetY);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 14, tileTargetX - 1, tileTargetY);
										}
									}
								}
								else if (!WorldGen.SolidTileNoAttach(tileTargetX, tileTargetY + 1) && !WorldGen.SolidTileNoAttach(tileTargetX - 1, tileTargetY) && !WorldGen.SolidTileNoAttach(tileTargetX + 1, tileTargetY) && (Main.tile[tileTargetX + 1, tileTargetY].halfBrick() || Main.tile[tileTargetX + 1, tileTargetY].slope() != 0) && Main.tile[tileTargetX, tileTargetY + 1].type != 19)
								{
									WorldGen.SlopeTile(tileTargetX + 1, tileTargetY);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 14, tileTargetX + 1, tileTargetY);
									}
								}
							}
							int num39 = Main.tile[tileTargetX, tileTargetY + 1].type;
							if (Main.tile[tileTargetX, tileTargetY].halfBrick())
							{
								num39 = -1;
							}
							int num40 = Main.tile[tileTargetX - 1, tileTargetY].type;
							int num41 = Main.tile[tileTargetX + 1, tileTargetY].type;
							int num42 = Main.tile[tileTargetX - 1, tileTargetY - 1].type;
							int num43 = Main.tile[tileTargetX + 1, tileTargetY - 1].type;
							int num44 = Main.tile[tileTargetX - 1, tileTargetY - 1].type;
							int num45 = Main.tile[tileTargetX + 1, tileTargetY + 1].type;
							if (!Main.tile[tileTargetX, tileTargetY + 1].nactive())
							{
								num39 = -1;
							}
							if (!Main.tile[tileTargetX - 1, tileTargetY].nactive())
							{
								num40 = -1;
							}
							if (!Main.tile[tileTargetX + 1, tileTargetY].nactive())
							{
								num41 = -1;
							}
							if (!Main.tile[tileTargetX - 1, tileTargetY - 1].nactive())
							{
								num42 = -1;
							}
							if (!Main.tile[tileTargetX + 1, tileTargetY - 1].nactive())
							{
								num43 = -1;
							}
							if (!Main.tile[tileTargetX - 1, tileTargetY + 1].nactive())
							{
								num44 = -1;
							}
							if (!Main.tile[tileTargetX + 1, tileTargetY + 1].nactive())
							{
								num45 = -1;
							}
							if (num39 >= 0 && Main.tileSolid[num39] && !Main.tileNoAttach[num39])
							{
								flag3 = true;
							}
							else if ((num40 >= 0 && Main.tileSolid[num40] && !Main.tileNoAttach[num40]) || (num40 == 5 && num42 == 5 && num44 == 5) || num40 == 124)
							{
								flag3 = true;
							}
							else if ((num41 >= 0 && Main.tileSolid[num41] && !Main.tileNoAttach[num41]) || (num41 == 5 && num43 == 5 && num45 == 5) || num41 == 124)
							{
								flag3 = true;
							}
						}
					}
					else if (inventory[selectedItem].createTile == 78 || inventory[selectedItem].createTile == 98 || inventory[selectedItem].createTile == 100 || inventory[selectedItem].createTile == 173 || inventory[selectedItem].createTile == 174 || inventory[selectedItem].createTile == 324)
					{
						if (Main.tile[tileTargetX, tileTargetY + 1].nactive() && (Main.tileSolid[Main.tile[tileTargetX, tileTargetY + 1].type] || Main.tileTable[Main.tile[tileTargetX, tileTargetY + 1].type]))
						{
							flag3 = true;
						}
					}
					else if (inventory[selectedItem].createTile == 13 || inventory[selectedItem].createTile == 29 || inventory[selectedItem].createTile == 33 || inventory[selectedItem].createTile == 49 || inventory[selectedItem].createTile == 50 || inventory[selectedItem].createTile == 103)
					{
						if (Main.tile[tileTargetX, tileTargetY + 1].nactive() && Main.tileTable[Main.tile[tileTargetX, tileTargetY + 1].type])
						{
							flag3 = true;
						}
					}
					else if (inventory[selectedItem].createTile == 275 || inventory[selectedItem].createTile == 276 || inventory[selectedItem].createTile == 277)
					{
						flag3 = true;
					}
					else if (inventory[selectedItem].createTile == 51 || inventory[selectedItem].createTile == 330 || inventory[selectedItem].createTile == 331 || inventory[selectedItem].createTile == 332 || inventory[selectedItem].createTile == 333 || inventory[selectedItem].createTile == 336)
					{
						if (Main.tile[tileTargetX + 1, tileTargetY].active() || Main.tile[tileTargetX + 1, tileTargetY].wall > 0 || Main.tile[tileTargetX - 1, tileTargetY].active() || Main.tile[tileTargetX - 1, tileTargetY].wall > 0 || Main.tile[tileTargetX, tileTargetY + 1].active() || Main.tile[tileTargetX, tileTargetY + 1].wall > 0 || Main.tile[tileTargetX, tileTargetY - 1].active() || Main.tile[tileTargetX, tileTargetY - 1].wall > 0)
						{
							flag3 = true;
						}
					}
					else if (inventory[selectedItem].createTile == 314)
					{
						for (int l = tileTargetX - 1; l <= tileTargetX + 1; l++)
						{
							for (int m = tileTargetY - 1; m <= tileTargetY + 1; m++)
							{
								Tile tile = Main.tile[l, m];
								if (tile.active() || tile.wall > 0)
								{
									flag3 = true;
									break;
								}
							}
						}
					}
					else
					{
						Tile tile2 = Main.tile[tileTargetX - 1, tileTargetY];
						Tile tile3 = Main.tile[tileTargetX + 1, tileTargetY];
						Tile tile4 = Main.tile[tileTargetX, tileTargetY - 1];
						Tile tile5 = Main.tile[tileTargetX, tileTargetY + 1];
						if ((tile3.active() && (Main.tileSolid[tile3.type] || Main.tileRope[tile3.type] || tile3.type == 314)) || tile3.wall > 0 || (tile2.active() && (Main.tileSolid[tile2.type] || Main.tileRope[tile2.type] || tile2.type == 314)) || tile2.wall > 0 || (tile5.active() && (Main.tileSolid[tile5.type] || tile5.type == 124 || Main.tileRope[tile5.type] || tile5.type == 314)) || tile5.wall > 0 || (tile4.active() && (Main.tileSolid[tile4.type] || tile4.type == 124 || Main.tileRope[tile4.type] || tile4.type == 314)) || tile4.wall > 0)
						{
							flag3 = true;
						}
					}
					if (Main.tileAlch[inventory[selectedItem].createTile])
					{
						flag3 = true;
					}
					if (Main.tile[tileTargetX, tileTargetY].active() && Main.tileCut[Main.tile[tileTargetX, tileTargetY].type])
					{
						if (Main.tile[tileTargetX, tileTargetY].type != inventory[selectedItem].createTile)
						{
							if (Main.tile[tileTargetX, tileTargetY + 1].type != 78 || ((Main.tile[tileTargetX, tileTargetY].type == 3 || Main.tile[tileTargetX, tileTargetY].type == 73) && Main.tileAlch[inventory[selectedItem].createTile]))
							{
								WorldGen.KillTile(tileTargetX, tileTargetY);
								if (!Main.tile[tileTargetX, tileTargetY].active() && Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 4, tileTargetX, tileTargetY);
								}
							}
							else
							{
								flag3 = false;
							}
						}
						else
						{
							flag3 = false;
						}
					}
					if (!flag3 && inventory[selectedItem].createTile == 19)
					{
						for (int n = tileTargetX - 1; n <= tileTargetX + 1; n++)
						{
							for (int num46 = tileTargetY - 1; num46 <= tileTargetY + 1; num46++)
							{
								if (Main.tile[n, num46].active())
								{
									flag3 = true;
									break;
								}
							}
						}
					}
					if (flag3)
					{
						int num47 = inventory[selectedItem].placeStyle;
						if (inventory[selectedItem].createTile == 36)
						{
							num47 = Main.rand.Next(7);
						}
						if (inventory[selectedItem].createTile == 212 && direction > 0)
						{
							num47 = 1;
						}
						if (inventory[selectedItem].createTile == 141)
						{
							num47 = Main.rand.Next(2);
						}
						if (inventory[selectedItem].createTile == 128 || inventory[selectedItem].createTile == 269 || inventory[selectedItem].createTile == 334)
						{
							num47 = ((direction >= 0) ? 1 : (-1));
						}
						if (inventory[selectedItem].createTile == 241 && inventory[selectedItem].placeStyle == 0)
						{
							num47 = Main.rand.Next(0, 9);
						}
						if (inventory[selectedItem].createTile == 35 && inventory[selectedItem].placeStyle == 0)
						{
							num47 = Main.rand.Next(9);
						}
						if (inventory[selectedItem].createTile == 314 && num47 == 2 && direction == 1)
						{
							num47++;
						}
						int[,] array = new int[11, 11];
						if (autoPaint)
						{
							for (int num48 = 0; num48 < 11; num48++)
							{
								for (int num49 = 0; num49 < 11; num49++)
								{
									int num50 = tileTargetX - 5 + num48;
									int num51 = tileTargetY - 5 + num49;
									if (Main.tile[num50, num51].active())
									{
										array[num48, num49] = Main.tile[num50, num51].type;
									}
									else
									{
										array[num48, num49] = -1;
									}
								}
							}
						}
						bool forced = false;
						if (WorldGen.PlaceTile(tileTargetX, tileTargetY, inventory[selectedItem].createTile, false, forced, whoAmi, num47))
						{
							itemTime = (int)((float)inventory[selectedItem].useTime * tileSpeed);
							if (Main.netMode == 1 && inventory[selectedItem].createTile != 21)
							{
								NetMessage.SendData(17, -1, -1, "", 1, tileTargetX, tileTargetY, inventory[selectedItem].createTile, num47);
							}
							if (inventory[selectedItem].createTile == 15)
							{
								if (direction == 1)
								{
									Main.tile[tileTargetX, tileTargetY].frameX += 18;
									Main.tile[tileTargetX, tileTargetY - 1].frameX += 18;
								}
								if (Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, tileTargetX - 1, tileTargetY - 1, 3);
								}
							}
							else if (inventory[selectedItem].createTile == 137)
							{
								if (direction == 1)
								{
									Main.tile[tileTargetX, tileTargetY].frameX += 18;
								}
								if (Main.netMode == 1)
								{
									NetMessage.SendTileSquare(-1, tileTargetX, tileTargetY, 1);
								}
							}
							else if ((inventory[selectedItem].createTile == 79 || inventory[selectedItem].createTile == 90) && Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, tileTargetX, tileTargetY, 5);
							}
							if (Main.tileSolid[inventory[selectedItem].createTile] && inventory[selectedItem].createTile != 19)
							{
								int num52 = tileTargetX;
								int num53 = tileTargetY + 1;
								if (Main.tile[num52, num53] != null && Main.tile[num52, num53].type != 19 && (Main.tile[num52, num53].topSlope() || Main.tile[num52, num53].halfBrick()))
								{
									WorldGen.SlopeTile(num52, num53);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 14, num52, num53);
									}
								}
								num52 = tileTargetX;
								num53 = tileTargetY - 1;
								if (Main.tile[num52, num53] != null && Main.tile[num52, num53].type != 19 && Main.tile[num52, num53].bottomSlope())
								{
									WorldGen.SlopeTile(num52, num53);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 14, num52, num53);
									}
								}
							}
							if (Main.tileSolid[inventory[selectedItem].createTile])
							{
								for (int num54 = tileTargetX - 1; num54 <= tileTargetX + 1; num54++)
								{
									for (int num55 = tileTargetY - 1; num55 <= tileTargetY + 1; num55++)
									{
										if (!Main.tile[num54, num55].active() || inventory[selectedItem].createTile == Main.tile[num54, num55].type || (Main.tile[num54, num55].type != 2 && Main.tile[num54, num55].type != 23 && Main.tile[num54, num55].type != 60 && Main.tile[num54, num55].type != 70 && Main.tile[num54, num55].type != 109 && Main.tile[num54, num55].type != 199))
										{
											continue;
										}
										bool flag4 = true;
										for (int num56 = num54 - 1; num56 <= num54 + 1; num56++)
										{
											for (int num57 = num55 - 1; num57 <= num55 + 1; num57++)
											{
												if (!WorldGen.SolidTile(num56, num57))
												{
													flag4 = false;
												}
											}
										}
										if (flag4)
										{
											WorldGen.KillTile(num54, num55, true);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 0, num54, num55, 1f);
											}
										}
									}
								}
							}
							if (autoPaint)
							{
								for (int num58 = 0; num58 < 11; num58++)
								{
									for (int num59 = 0; num59 < 11; num59++)
									{
										int num60 = tileTargetX - 5 + num58;
										int num61 = tileTargetY - 5 + num59;
										if ((!Main.tile[num60, num61].active() && array[num58, num59] == -1) || (Main.tile[num60, num61].active() && array[num58, num59] == Main.tile[num60, num61].type))
										{
											continue;
										}
										int num62 = -1;
										int num63 = -1;
										for (int num64 = 0; num64 < 58; num64++)
										{
											if (inventory[num64].stack > 0 && inventory[num64].paint > 0)
											{
												num62 = inventory[num64].paint;
												num63 = num64;
												break;
											}
										}
										if (num62 > 0 && Main.tile[num60, num61].color() != num62 && WorldGen.paintTile(num60, num61, (byte)num62, true))
										{
											int num65 = num63;
											inventory[num65].stack--;
											if (inventory[num65].stack <= 0)
											{
												inventory[num65].SetDefaults(0);
											}
											itemTime = (int)((float)inventory[selectedItem].useTime * tileSpeed);
										}
									}
								}
							}
						}
					}
				}
			}
			if (inventory[selectedItem].createWall < 0 || !(position.X / 16f - (float)tileRangeX - (float)inventory[selectedItem].tileBoost <= (float)tileTargetX) || !((position.X + (float)width) / 16f + (float)tileRangeX + (float)inventory[selectedItem].tileBoost - 1f >= (float)tileTargetX) || !(position.Y / 16f - (float)tileRangeY - (float)inventory[selectedItem].tileBoost <= (float)tileTargetY) || !((position.Y + (float)height) / 16f + (float)tileRangeY + (float)inventory[selectedItem].tileBoost - 2f >= (float)tileTargetY))
			{
				return;
			}
			showItemIcon = true;
			if (itemTime != 0 || itemAnimation <= 0 || !controlUseItem || (!Main.tile[tileTargetX + 1, tileTargetY].active() && Main.tile[tileTargetX + 1, tileTargetY].wall <= 0 && !Main.tile[tileTargetX - 1, tileTargetY].active() && Main.tile[tileTargetX - 1, tileTargetY].wall <= 0 && !Main.tile[tileTargetX, tileTargetY + 1].active() && Main.tile[tileTargetX, tileTargetY + 1].wall <= 0 && !Main.tile[tileTargetX, tileTargetY - 1].active() && Main.tile[tileTargetX, tileTargetY - 1].wall <= 0) || Main.tile[tileTargetX, tileTargetY].wall == inventory[selectedItem].createWall)
			{
				return;
			}
			WorldGen.PlaceWall(tileTargetX, tileTargetY, inventory[selectedItem].createWall);
			if (Main.tile[tileTargetX, tileTargetY].wall != inventory[selectedItem].createWall)
			{
				return;
			}
			itemTime = (int)((float)inventory[selectedItem].useTime * wallSpeed);
			if (Main.netMode == 1)
			{
				NetMessage.SendData(17, -1, -1, "", 3, tileTargetX, tileTargetY, inventory[selectedItem].createWall);
			}
			if (inventory[selectedItem].stack > 1)
			{
				int createWall = inventory[selectedItem].createWall;
				for (int num66 = 0; num66 < 4; num66++)
				{
					int num67 = tileTargetX;
					int num68 = tileTargetY;
					if (num66 == 0)
					{
						num67--;
					}
					if (num66 == 1)
					{
						num67++;
					}
					if (num66 == 2)
					{
						num68--;
					}
					if (num66 == 3)
					{
						num68++;
					}
					if (Main.tile[num67, num68].wall != 0)
					{
						continue;
					}
					int num69 = 0;
					for (int num70 = 0; num70 < 4; num70++)
					{
						int num71 = num67;
						int num72 = num68;
						if (num70 == 0)
						{
							num71--;
						}
						if (num70 == 1)
						{
							num71++;
						}
						if (num70 == 2)
						{
							num72--;
						}
						if (num70 == 3)
						{
							num72++;
						}
						if (Main.tile[num71, num72].wall == createWall)
						{
							num69++;
						}
					}
					if (num69 != 4)
					{
						continue;
					}
					WorldGen.PlaceWall(num67, num68, createWall);
					if (Main.tile[num67, num68].wall != createWall)
					{
						continue;
					}
					inventory[selectedItem].stack--;
					if (inventory[selectedItem].stack == 0)
					{
						inventory[selectedItem].SetDefaults(0);
					}
					if (Main.netMode == 1)
					{
						NetMessage.SendData(17, -1, -1, "", 3, num67, num68, createWall);
					}
					if (!autoPaint)
					{
						continue;
					}
					int num73 = num67;
					int num74 = num68;
					int num75 = -1;
					int num76 = -1;
					for (int num77 = 0; num77 < 58; num77++)
					{
						if (inventory[num77].stack > 0 && inventory[num77].paint > 0)
						{
							num75 = inventory[num77].paint;
							num76 = num77;
							break;
						}
					}
					if (num75 > 0 && Main.tile[num73, num74].wallColor() != num75 && WorldGen.paintWall(num73, num74, (byte)num75, true))
					{
						int num78 = num76;
						inventory[num78].stack--;
						if (inventory[num78].stack <= 0)
						{
							inventory[num78].SetDefaults(0);
						}
						itemTime = (int)((float)inventory[selectedItem].useTime * wallSpeed);
					}
				}
			}
			if (!autoPaint)
			{
				return;
			}
			int num79 = tileTargetX;
			int num80 = tileTargetY;
			int num81 = -1;
			int num82 = -1;
			for (int num83 = 0; num83 < 58; num83++)
			{
				if (inventory[num83].stack > 0 && inventory[num83].paint > 0)
				{
					num81 = inventory[num83].paint;
					num82 = num83;
					break;
				}
			}
			if (num81 > 0 && Main.tile[num79, num80].wallColor() != num81 && WorldGen.paintWall(num79, num80, (byte)num81, true))
			{
				int num84 = num82;
				inventory[num84].stack--;
				if (inventory[num84].stack <= 0)
				{
					inventory[num84].SetDefaults(0);
				}
				itemTime = (int)((float)inventory[selectedItem].useTime * wallSpeed);
			}
		}

		public void ChangeDir(int dir)
		{
			if (!pulley || pulleyDir != 2)
			{
				direction = dir;
			}
			else
			{
				if (pulleyDir == 2 && dir == direction)
				{
					return;
				}
				int num = (int)(position.X + (float)(width / 2)) / 16;
				int num2 = num * 16 + 8 - width / 2;
				if (!Collision.SolidCollision(new Vector2(num2, position.Y), width, height))
				{
					if (whoAmi == Main.myPlayer)
					{
						Main.cameraX = Main.cameraX + position.X - (float)num2;
					}
					pulleyDir = 1;
					position.X = num2;
					direction = dir;
				}
			}
		}

		public Vector2 center()
		{
			return new Vector2(position.X + (float)(width / 2), position.Y + (float)(height / 2));
		}

		public Rectangle getRect()
		{
			return new Rectangle((int)position.X, (int)position.Y, width, height);
		}

		private void pumpkinSword(int i, int dmg, float kb)
		{
			int num = Main.rand.Next(100, 300);
			int num2 = Main.rand.Next(100, 300);
			num = ((Main.rand.Next(2) != 0) ? (num + (Main.maxScreenW / 2 - num)) : (num - (Main.maxScreenW / 2 + num)));
			num2 = ((Main.rand.Next(2) != 0) ? (num2 + (Main.maxScreenH / 2 - num2)) : (num2 - (Main.maxScreenH / 2 + num2)));
			num += (int)position.X;
			num2 += (int)position.Y;
			float num3 = 8f;
			Vector2 vector = new Vector2(num, num2);
			float num4 = Main.npc[i].position.X - vector.X;
			float num5 = Main.npc[i].position.Y - vector.Y;
			float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
			num6 = num3 / num6;
			num4 *= num6;
			num5 *= num6;
			Projectile.NewProjectile(num, num2, num4, num5, 321, dmg, kb, whoAmi, i);
		}

		public void PutItemInInventory(int type, int selItem = -1)
		{
			for (int i = 0; i < 58; i++)
			{
				Item item = inventory[i];
				if (item.stack > 0 && item.type == type && item.stack < item.maxStack)
				{
					item.stack++;
					return;
				}
			}
			if (selItem >= 0 && (inventory[selItem].type == 0 || inventory[selItem].stack <= 0))
			{
				inventory[selItem].SetDefaults(type);
				return;
			}
			Item item2 = new Item();
			item2.SetDefaults(type);
			Item item3 = GetItem(whoAmi, item2);
			if (item3.stack > 0)
			{
				int number = Item.NewItem((int)position.X, (int)position.Y, width, height, type, 1, false, 0, true);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f);
				}
			}
			else
			{
				item2.position.X = center().X - (float)(item2.width / 2);
				item2.position.Y = center().Y - (float)(item2.height / 2);
				item2.active = true;
				ItemText.NewText(item2, 0);
			}
		}

		public bool SummonItemCheck()
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && ((inventory[selectedItem].type == 43 && Main.npc[i].type == 4) || (inventory[selectedItem].type == 70 && Main.npc[i].type == 13) || ((inventory[selectedItem].type == 560) & (Main.npc[i].type == 50)) || (inventory[selectedItem].type == 544 && Main.npc[i].type == 125) || (inventory[selectedItem].type == 544 && Main.npc[i].type == 126) || (inventory[selectedItem].type == 556 && Main.npc[i].type == 134) || (inventory[selectedItem].type == 557 && Main.npc[i].type == 127) || (inventory[selectedItem].type == 1133 && Main.npc[i].type == 222) || (inventory[selectedItem].type == 1331 && Main.npc[i].type == 266)))
				{
					return false;
				}
			}
			return true;
		}

		public int FishingLevel()
		{
			int num = 0;
			int fishingPole = inventory[selectedItem].fishingPole;
			for (int i = 0; i < 58; i++)
			{
				if (inventory[i].stack > 0 && inventory[i].bait > 0)
				{
					if (inventory[i].type == 2673)
					{
						return -1;
					}
					num = inventory[i].bait;
					break;
				}
			}
			if (num == 0 || fishingPole == 0)
			{
				return 0;
			}
			int num2 = num + fishingPole + fishingSkill;
			if (Main.raining)
			{
				num2 = (int)((float)num2 * 1.2f);
			}
			if (Main.dayTime && (Main.time < 5400.0 || Main.time > 48600.0))
			{
				num2 = (int)((float)num2 * 1.3f);
			}
			if (Main.dayTime && Main.time > 16200.0 && Main.time < 37800.0)
			{
				num2 = (int)((float)num2 * 0.8f);
			}
			if (!Main.dayTime && Main.time > 6480.0 && Main.time < 25920.0)
			{
				num2 = (int)((float)num2 * 0.8f);
			}
			if (Main.moonPhase == 0)
			{
				num2 = (int)((float)num2 * 1.1f);
			}
			if (Main.moonPhase == 1 || Main.moonPhase == 7)
			{
				num2 = (int)((float)num2 * 1.05f);
			}
			if (Main.moonPhase == 3 || Main.moonPhase == 5)
			{
				num2 = (int)((float)num2 * 0.95f);
			}
			if (Main.moonPhase == 4)
			{
				num2 = (int)((float)num2 * 0.9f);
			}
			return num2;
		}

		public void ItemCheck(int i)
		{
			if (frozen)
			{
				return;
			}
			bool flag = false;
			float num = 5E-06f;
			int num2 = inventory[selectedItem].damage;
			if (num2 > 0)
			{
				if (inventory[selectedItem].melee)
				{
					num2 = (int)((float)num2 * meleeDamage + num);
				}
				else if (inventory[selectedItem].ranged)
				{
					num2 = (int)((float)num2 * rangedDamage + num);
					if (inventory[selectedItem].useAmmo == 1 || inventory[selectedItem].useAmmo == 323)
					{
						num2 = (int)((float)num2 * arrowDamage + num);
					}
					if (inventory[selectedItem].useAmmo == 14 || inventory[selectedItem].useAmmo == 311)
					{
						num2 = (int)((float)num2 * bulletDamage + num);
					}
					if (inventory[selectedItem].useAmmo == 771 || inventory[selectedItem].useAmmo == 246 || inventory[selectedItem].useAmmo == 312)
					{
						num2 = (int)((float)num2 * rocketDamage + num);
					}
				}
				else if (inventory[selectedItem].magic)
				{
					num2 = (int)((float)num2 * magicDamage + num);
				}
			}
			if (inventory[selectedItem].autoReuse && !noItems)
			{
				releaseUseItem = true;
				if (itemAnimation == 1 && inventory[selectedItem].stack > 0)
				{
					if (inventory[selectedItem].shoot > 0 && whoAmi != Main.myPlayer && controlUseItem && inventory[selectedItem].useStyle == 5)
					{
						itemAnimation = 2;
					}
					else
					{
						itemAnimation = 0;
					}
				}
			}
			if (inventory[selectedItem].fishingPole > 0)
			{
				inventory[selectedItem].holdStyle = 0;
				if (itemTime == 0 && itemAnimation == 0)
				{
					for (int j = 0; j < 1000; j++)
					{
						if (Main.projectile[j].active && Main.projectile[j].owner == whoAmi && Main.projectile[j].bobber)
						{
							inventory[selectedItem].holdStyle = 1;
						}
					}
				}
			}
			if (whoAmi == Main.myPlayer && mount.Active)
			{
				if (inventory[selectedItem].mountType != mount.Type && itemAnimation > 0)
				{
					mount.Dismount(this);
				}
				if (gravDir == -1f)
				{
					mount.Dismount(this);
				}
			}
			if (itemAnimation == 0 && reuseDelay > 0)
			{
				itemAnimation = reuseDelay;
				itemTime = reuseDelay;
				reuseDelay = 0;
			}
			if (controlUseItem && releaseUseItem && (inventory[selectedItem].headSlot > 0 || inventory[selectedItem].bodySlot > 0 || inventory[selectedItem].legSlot > 0))
			{
				if (inventory[selectedItem].useStyle == 0)
				{
					releaseUseItem = false;
				}
				if (position.X / 16f - (float)tileRangeX - (float)inventory[selectedItem].tileBoost <= (float)tileTargetX && (position.X + (float)width) / 16f + (float)tileRangeX + (float)inventory[selectedItem].tileBoost - 1f >= (float)tileTargetX && position.Y / 16f - (float)tileRangeY - (float)inventory[selectedItem].tileBoost <= (float)tileTargetY && (position.Y + (float)height) / 16f + (float)tileRangeY + (float)inventory[selectedItem].tileBoost - 2f >= (float)tileTargetY)
				{
					int num3 = tileTargetX;
					int num4 = tileTargetY;
					if (Main.tile[num3, num4].active() && (Main.tile[num3, num4].type == 128 || Main.tile[num3, num4].type == 269))
					{
						int frameY = Main.tile[num3, num4].frameY;
						int num5 = 0;
						if (inventory[selectedItem].bodySlot >= 0)
						{
							num5 = 1;
						}
						if (inventory[selectedItem].legSlot >= 0)
						{
							num5 = 2;
						}
						frameY /= 18;
						while (num5 > frameY)
						{
							num4++;
							frameY = Main.tile[num3, num4].frameY;
							frameY /= 18;
						}
						while (num5 < frameY)
						{
							num4--;
							frameY = Main.tile[num3, num4].frameY;
							frameY /= 18;
						}
						int num6;
						for (num6 = Main.tile[num3, num4].frameX; num6 >= 100; num6 -= 100)
						{
						}
						if (num6 >= 36)
						{
							num6 -= 36;
						}
						num3 -= num6 / 18;
						int num7 = Main.tile[num3, num4].frameX;
						WorldGen.KillTile(num3, num4, true);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(17, -1, -1, "", 0, num3, num4, 1f);
						}
						while (num7 >= 100)
						{
							num7 -= 100;
						}
						if (frameY == 0 && inventory[selectedItem].headSlot >= 0)
						{
							Main.blockMouse = true;
							Main.tile[num3, num4].frameX = (short)(num7 + inventory[selectedItem].headSlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num3, num4, 1);
							}
							inventory[selectedItem].stack--;
							if (inventory[selectedItem].stack <= 0)
							{
								inventory[selectedItem].SetDefaults(0);
								Main.mouseItem.SetDefaults(0);
							}
							if (selectedItem == 58)
							{
								Main.mouseItem = inventory[selectedItem].Clone();
							}
							releaseUseItem = false;
							mouseInterface = true;
						}
						else if (frameY == 1 && inventory[selectedItem].bodySlot >= 0)
						{
							Main.blockMouse = true;
							Main.tile[num3, num4].frameX = (short)(num7 + inventory[selectedItem].bodySlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num3, num4, 1);
							}
							inventory[selectedItem].stack--;
							if (inventory[selectedItem].stack <= 0)
							{
								inventory[selectedItem].SetDefaults(0);
								Main.mouseItem.SetDefaults(0);
							}
							if (selectedItem == 58)
							{
								Main.mouseItem = inventory[selectedItem].Clone();
							}
							releaseUseItem = false;
							mouseInterface = true;
						}
						else if (frameY == 2 && inventory[selectedItem].legSlot >= 0)
						{
							Main.blockMouse = true;
							Main.tile[num3, num4].frameX = (short)(num7 + inventory[selectedItem].legSlot * 100);
							if (Main.netMode == 1)
							{
								NetMessage.SendTileSquare(-1, num3, num4, 1);
							}
							inventory[selectedItem].stack--;
							if (inventory[selectedItem].stack <= 0)
							{
								inventory[selectedItem].SetDefaults(0);
								Main.mouseItem.SetDefaults(0);
							}
							if (selectedItem == 58)
							{
								Main.mouseItem = inventory[selectedItem].Clone();
							}
							releaseUseItem = false;
							mouseInterface = true;
						}
					}
				}
			}
			if (controlUseItem && itemAnimation == 0 && releaseUseItem && inventory[selectedItem].useStyle > 0)
			{
				bool flag2 = true;
				if (inventory[selectedItem].shoot == 0)
				{
					itemRotation = 0f;
				}
				if (pulley && inventory[selectedItem].fishingPole > 0)
				{
					flag2 = false;
				}
				if (wet && (inventory[selectedItem].shoot == 85 || inventory[selectedItem].shoot == 15 || inventory[selectedItem].shoot == 34))
				{
					flag2 = false;
				}
				if (inventory[selectedItem].makeNPC > 0 && !NPC.CanReleaseNPCs(whoAmi))
				{
					flag2 = false;
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 603 && !Main.cEd)
				{
					flag2 = false;
				}
				if (inventory[selectedItem].type == 1071 || inventory[selectedItem].type == 1072)
				{
					bool flag3 = false;
					for (int k = 0; k < 58; k++)
					{
						if (inventory[k].paint > 0)
						{
							flag3 = true;
							break;
						}
					}
					if (!flag3)
					{
						flag2 = false;
					}
				}
				if (noItems)
				{
					flag2 = false;
				}
				if (inventory[selectedItem].tileWand > 0)
				{
					int tileWand = inventory[selectedItem].tileWand;
					flag2 = false;
					for (int l = 0; l < 58; l++)
					{
						if (tileWand == inventory[l].type && inventory[l].stack > 0)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (inventory[selectedItem].fishingPole > 0)
				{
					for (int m = 0; m < 1000; m++)
					{
						if (!Main.projectile[m].active || Main.projectile[m].owner != whoAmi || !Main.projectile[m].bobber)
						{
							continue;
						}
						flag2 = false;
						if (whoAmi != Main.myPlayer || Main.projectile[m].ai[0] != 0f)
						{
							continue;
						}
						Main.projectile[m].ai[0] = 1f;
						float num8 = -10f;
						if (Main.projectile[m].wet && Main.projectile[m].velocity.Y > num8)
						{
							Main.projectile[m].velocity.Y = num8;
						}
						Main.projectile[m].netUpdate2 = true;
						if (!(Main.projectile[m].ai[1] < 0f) || Main.projectile[m].localAI[1] == 0f)
						{
							continue;
						}
						bool flag4 = false;
						int num9 = 0;
						for (int n = 0; n < 58; n++)
						{
							if (inventory[n].stack <= 0 || inventory[n].bait <= 0)
							{
								continue;
							}
							bool flag5 = false;
							int num10 = inventory[n].bait / 5;
							if (num10 < 1)
							{
								num10 = 1;
							}
							if (accTackleBox)
							{
								num10++;
							}
							if (Main.rand.Next(num10) == 0)
							{
								flag5 = true;
							}
							if (Main.projectile[m].localAI[1] < 0f)
							{
								flag5 = true;
							}
							if (Main.projectile[m].localAI[1] > 0f)
							{
								Item item = new Item();
								item.SetDefaults((int)Main.projectile[m].localAI[1]);
								if (item.rare < 0)
								{
									flag5 = false;
								}
							}
							if (flag5)
							{
								num9 = inventory[n].type;
								inventory[n].stack--;
								if (inventory[n].stack <= 0)
								{
									inventory[n].SetDefaults(0);
								}
							}
							flag4 = true;
							break;
						}
						if (!flag4)
						{
							continue;
						}
						if (num9 == 2673)
						{
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(whoAmi, 370);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", whoAmi, 370f);
							}
							Main.projectile[m].ai[0] = 2f;
						}
						else if (Main.rand.Next(7) == 0 && !accFishingLine)
						{
							Main.projectile[m].ai[0] = 2f;
						}
						else
						{
							Main.projectile[m].ai[1] = Main.projectile[m].localAI[1];
						}
						Main.projectile[m].netUpdate = true;
					}
				}
				if (inventory[selectedItem].shoot == 6 || inventory[selectedItem].shoot == 19 || inventory[selectedItem].shoot == 33 || inventory[selectedItem].shoot == 52 || inventory[selectedItem].shoot == 113 || inventory[selectedItem].shoot == 182 || inventory[selectedItem].shoot == 320 || inventory[selectedItem].shoot == 333 || inventory[selectedItem].shoot == 383)
				{
					for (int num11 = 0; num11 < 1000; num11++)
					{
						if (Main.projectile[num11].active && Main.projectile[num11].owner == Main.myPlayer && Main.projectile[num11].type == inventory[selectedItem].shoot)
						{
							flag2 = false;
						}
					}
				}
				if (inventory[selectedItem].shoot == 106)
				{
					int num12 = 0;
					for (int num13 = 0; num13 < 1000; num13++)
					{
						if (Main.projectile[num13].active && Main.projectile[num13].owner == Main.myPlayer && Main.projectile[num13].type == inventory[selectedItem].shoot)
						{
							num12++;
						}
					}
					if (num12 >= inventory[selectedItem].stack)
					{
						flag2 = false;
					}
				}
				if (inventory[selectedItem].shoot == 272)
				{
					int num14 = 0;
					for (int num15 = 0; num15 < 1000; num15++)
					{
						if (Main.projectile[num15].active && Main.projectile[num15].owner == Main.myPlayer && Main.projectile[num15].type == inventory[selectedItem].shoot)
						{
							num14++;
						}
					}
					if (num14 >= inventory[selectedItem].stack)
					{
						flag2 = false;
					}
				}
				if (inventory[selectedItem].shoot == 13 || inventory[selectedItem].shoot == 32 || (inventory[selectedItem].shoot >= 230 && inventory[selectedItem].shoot <= 235) || inventory[selectedItem].shoot == 315 || inventory[selectedItem].shoot == 331 || inventory[selectedItem].shoot == 372)
				{
					for (int num16 = 0; num16 < 1000; num16++)
					{
						if (Main.projectile[num16].active && Main.projectile[num16].owner == Main.myPlayer && Main.projectile[num16].type == inventory[selectedItem].shoot && Main.projectile[num16].ai[0] != 2f)
						{
							flag2 = false;
						}
					}
				}
				if (inventory[selectedItem].shoot == 332)
				{
					int num17 = 0;
					for (int num18 = 0; num18 < 1000; num18++)
					{
						if (Main.projectile[num18].active && Main.projectile[num18].owner == Main.myPlayer && Main.projectile[num18].type == inventory[selectedItem].shoot && Main.projectile[num18].ai[0] != 2f)
						{
							num17++;
						}
					}
					if (num17 >= 3)
					{
						flag2 = false;
					}
				}
				if (inventory[selectedItem].potion && flag2)
				{
					if (potionDelay <= 0)
					{
						potionDelay = potionDelayTime;
						AddBuff(21, potionDelay);
					}
					else
					{
						flag2 = false;
					}
				}
				if (inventory[selectedItem].mana > 0 && silence)
				{
					flag2 = false;
				}
				if (inventory[selectedItem].mana > 0 && flag2)
				{
					if (inventory[selectedItem].type != 127 || !spaceGun)
					{
						if (statMana >= (int)((float)inventory[selectedItem].mana * manaCost))
						{
							statMana -= (int)((float)inventory[selectedItem].mana * manaCost);
						}
						else if (manaFlower)
						{
							QuickMana();
							if (statMana >= (int)((float)inventory[selectedItem].mana * manaCost))
							{
								statMana -= (int)((float)inventory[selectedItem].mana * manaCost);
							}
							else
							{
								flag2 = false;
							}
						}
						else
						{
							flag2 = false;
						}
					}
					if (whoAmi == Main.myPlayer && inventory[selectedItem].buffType != 0 && flag2)
					{
						AddBuff(inventory[selectedItem].buffType, inventory[selectedItem].buffTime);
					}
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 603 && Main.cEd)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 669)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 115)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 425)
				{
					int num19 = Main.rand.Next(3);
					if (num19 == 0)
					{
						num19 = 27;
					}
					if (num19 == 1)
					{
						num19 = 101;
					}
					if (num19 == 2)
					{
						num19 = 102;
					}
					for (int num20 = 0; num20 < 22; num20++)
					{
						if (buffType[num20] == 27 || buffType[num20] == 101 || buffType[num20] == 102)
						{
							DelBuff(num20);
							num20--;
						}
					}
					AddBuff(num19, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 753)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 994)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1169)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1170)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1171)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1172)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1180)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1181)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1182)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1183)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1242)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1157)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1309)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1311)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1837)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1312)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1798)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1799)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1802)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1810)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1927)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 1959)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 2364)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 2365)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 2420)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 2535)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 2551)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 2584)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 2587)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && inventory[selectedItem].type == 2621)
				{
					AddBuff(inventory[selectedItem].buffType, 3600);
				}
				if (whoAmi == Main.myPlayer && gravDir == 1f && inventory[selectedItem].mountType != -1)
				{
					mount.SetMount(inventory[selectedItem].mountType, this);
				}
				if (inventory[selectedItem].type == 43 && Main.dayTime)
				{
					flag2 = false;
				}
				if (inventory[selectedItem].type == 544 && Main.dayTime)
				{
					flag2 = false;
				}
				if (inventory[selectedItem].type == 556 && Main.dayTime)
				{
					flag2 = false;
				}
				if (inventory[selectedItem].type == 557 && Main.dayTime)
				{
					flag2 = false;
				}
				if (inventory[selectedItem].type == 70 && !zoneEvil)
				{
					flag2 = false;
				}
				if (inventory[selectedItem].type == 1133 && !zoneJungle)
				{
					flag2 = false;
				}
				if (inventory[selectedItem].type == 1844 && (Main.dayTime || Main.pumpkinMoon || Main.snowMoon))
				{
					flag2 = false;
				}
				if (inventory[selectedItem].type == 1958 && (Main.dayTime || Main.pumpkinMoon || Main.snowMoon))
				{
					flag2 = false;
				}
				if (!SummonItemCheck())
				{
					flag2 = false;
				}
				if (inventory[selectedItem].shoot == 17 && flag2 && i == Main.myPlayer)
				{
					int num21 = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
					int num22 = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
					if (gravDir == -1f)
					{
						num22 = (int)(Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16;
					}
					Tile tile = Main.tile[num21, num22];
					if (tile.active() && (tile.type == 0 || tile.type == 2 || tile.type == 23 || tile.type == 109 || tile.type == 199))
					{
						WorldGen.KillTile(num21, num22, false, false, true);
						if (!Main.tile[num21, num22].active())
						{
							if (Main.netMode == 1)
							{
								NetMessage.SendData(17, -1, -1, "", 4, num21, num22);
							}
						}
						else
						{
							flag2 = false;
						}
					}
					else
					{
						flag2 = false;
					}
				}
				if (flag2 && inventory[selectedItem].useAmmo > 0)
				{
					flag2 = false;
					for (int num23 = 0; num23 < 58; num23++)
					{
						if (inventory[num23].ammo == inventory[selectedItem].useAmmo && inventory[num23].stack > 0)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (flag2)
				{
					if (inventory[selectedItem].pick > 0 || inventory[selectedItem].axe > 0 || inventory[selectedItem].hammer > 0)
					{
						toolTime = 1;
					}
					if (grappling[0] > -1)
					{
						pulley = false;
						pulleyDir = 1;
						if (controlRight)
						{
							direction = 1;
						}
						else if (controlLeft)
						{
							direction = -1;
						}
					}
					channel = inventory[selectedItem].channel;
					attackCD = 0;
					if (inventory[selectedItem].melee)
					{
						itemAnimation = (int)((float)inventory[selectedItem].useAnimation * meleeSpeed);
						itemAnimationMax = (int)((float)inventory[selectedItem].useAnimation * meleeSpeed);
					}
					else if (inventory[selectedItem].createTile >= 0)
					{
						itemAnimation = (int)((float)inventory[selectedItem].useAnimation * tileSpeed);
						itemAnimationMax = (int)((float)inventory[selectedItem].useAnimation * tileSpeed);
					}
					else if (inventory[selectedItem].createWall >= 0)
					{
						itemAnimation = (int)((float)inventory[selectedItem].useAnimation * wallSpeed);
						itemAnimationMax = (int)((float)inventory[selectedItem].useAnimation * wallSpeed);
					}
					else
					{
						itemAnimation = inventory[selectedItem].useAnimation;
						itemAnimationMax = inventory[selectedItem].useAnimation;
						reuseDelay = inventory[selectedItem].reuseDelay;
					}
					if (inventory[selectedItem].useSound > 0)
					{
						Main.PlaySound(2, (int)position.X, (int)position.Y, inventory[selectedItem].useSound);
					}
				}
				if (flag2 && whoAmi == Main.myPlayer && (inventory[selectedItem].shoot == 18 || inventory[selectedItem].shoot == 72 || inventory[selectedItem].shoot == 86 || inventory[selectedItem].shoot == 87 || Main.projPet[inventory[selectedItem].shoot]))
				{
					if ((inventory[selectedItem].shoot >= 191 && inventory[selectedItem].shoot <= 194) || inventory[selectedItem].shoot == 266 || inventory[selectedItem].shoot == 317 || inventory[selectedItem].shoot == 373 || inventory[selectedItem].shoot == 375 || inventory[selectedItem].shoot == 387 || inventory[selectedItem].shoot == 390 || inventory[selectedItem].shoot == 393 || inventory[selectedItem].shoot == 407)
					{
						List<int> list = new List<int>();
						float num24 = 0f;
						for (int num25 = 0; num25 < 1000; num25++)
						{
							if (!Main.projectile[num25].active || Main.projectile[num25].owner != i || !Main.projectile[num25].minion)
							{
								continue;
							}
							int num26;
							for (num26 = 0; num26 < list.Count; num26++)
							{
								if (Main.projectile[list[num26]].minionSlots > Main.projectile[num25].minionSlots)
								{
									list.Insert(num26, num25);
									break;
								}
							}
							if (num26 == list.Count)
							{
								list.Add(num25);
							}
							num24 += Main.projectile[num25].minionSlots;
						}
						float num27 = 0f;
						int shoot = inventory[selectedItem].shoot;
						num27 = 1f;
						float num28 = 0f;
						int num29 = 388;
						for (int num30 = 0; num30 < list.Count; num30++)
						{
							if (!(num24 - num28 > (float)maxMinions - num27))
							{
								break;
							}
							int type = Main.projectile[list[num30]].type;
							if (type != num29)
							{
								num28 += Main.projectile[list[num30]].minionSlots;
								if (type == 388 && num29 == 387)
								{
									num29 = 388;
								}
								if (type == 387 && num29 == 388)
								{
									num29 = 387;
								}
								Main.projectile[list[num30]].Kill();
							}
						}
						list.Clear();
					}
					else
					{
						for (int num31 = 0; num31 < 1000; num31++)
						{
							if (Main.projectile[num31].active && Main.projectile[num31].owner == i && Main.projectile[num31].type == inventory[selectedItem].shoot)
							{
								Main.projectile[num31].Kill();
							}
							if (inventory[selectedItem].shoot == 72)
							{
								if (Main.projectile[num31].active && Main.projectile[num31].owner == i && Main.projectile[num31].type == 86)
								{
									Main.projectile[num31].Kill();
								}
								if (Main.projectile[num31].active && Main.projectile[num31].owner == i && Main.projectile[num31].type == 87)
								{
									Main.projectile[num31].Kill();
								}
							}
						}
					}
				}
			}
			if (!controlUseItem)
			{
				bool channel2 = channel;
				channel = false;
			}
			if (itemAnimation > 0)
			{
				if (inventory[selectedItem].melee)
				{
					itemAnimationMax = (int)((float)inventory[selectedItem].useAnimation * meleeSpeed);
				}
				else
				{
					itemAnimationMax = inventory[selectedItem].useAnimation;
				}
				if (inventory[selectedItem].mana > 0 && !flag && (inventory[selectedItem].type != 127 || !spaceGun))
				{
					manaRegenDelay = (int)maxRegenDelay;
				}
				if (Main.dedServ)
				{
					itemHeight = inventory[selectedItem].height;
					itemWidth = inventory[selectedItem].width;
				}
				else
				{
					itemHeight = Main.itemTexture[inventory[selectedItem].type].Height;
					itemWidth = Main.itemTexture[inventory[selectedItem].type].Width;
				}
				itemAnimation--;
				if (!Main.dedServ)
				{
					if (inventory[selectedItem].useStyle == 1)
					{
						if (inventory[selectedItem].type == 1827)
						{
							if ((double)itemAnimation < (double)itemAnimationMax * 0.333)
							{
								float num32 = 10f;
								itemLocation.X = position.X + (float)width * 0.5f + ((float)Main.itemTexture[inventory[selectedItem].type].Width * 0.5f - num32) * (float)direction;
								itemLocation.Y = position.Y + 26f;
							}
							else if ((double)itemAnimation < (double)itemAnimationMax * 0.666)
							{
								float num33 = 8f;
								itemLocation.X = position.X + (float)width * 0.5f + ((float)Main.itemTexture[inventory[selectedItem].type].Width * 0.5f - num33) * (float)direction;
								num33 = 24f;
								itemLocation.Y = position.Y + num33;
							}
							else
							{
								float num34 = 6f;
								itemLocation.X = position.X + (float)width * 0.5f - ((float)Main.itemTexture[inventory[selectedItem].type].Width * 0.5f - num34) * (float)direction;
								num34 = 20f;
								itemLocation.Y = position.Y + num34;
							}
							itemRotation = ((float)itemAnimation / (float)itemAnimationMax - 0.5f) * (float)(-direction) * 3.5f - (float)direction * 0.3f;
						}
						else
						{
							if ((double)itemAnimation < (double)itemAnimationMax * 0.333)
							{
								float num35 = 10f;
								if (Main.itemTexture[inventory[selectedItem].type].Width > 32)
								{
									num35 = 14f;
								}
								if (Main.itemTexture[inventory[selectedItem].type].Width >= 52)
								{
									num35 = 24f;
								}
								if (Main.itemTexture[inventory[selectedItem].type].Width >= 64)
								{
									num35 = 28f;
								}
								if (Main.itemTexture[inventory[selectedItem].type].Width >= 92)
								{
									num35 = 38f;
								}
								if (inventory[selectedItem].type == 2330 || inventory[selectedItem].type == 2320 || inventory[selectedItem].type == 2341)
								{
									num35 += 8f;
								}
								itemLocation.X = position.X + (float)width * 0.5f + ((float)Main.itemTexture[inventory[selectedItem].type].Width * 0.5f - num35) * (float)direction;
								itemLocation.Y = position.Y + 24f;
							}
							else if ((double)itemAnimation < (double)itemAnimationMax * 0.666)
							{
								float num36 = 10f;
								if (Main.itemTexture[inventory[selectedItem].type].Width > 32)
								{
									num36 = 18f;
								}
								if (Main.itemTexture[inventory[selectedItem].type].Width >= 52)
								{
									num36 = 24f;
								}
								if (Main.itemTexture[inventory[selectedItem].type].Width >= 64)
								{
									num36 = 28f;
								}
								if (Main.itemTexture[inventory[selectedItem].type].Width >= 92)
								{
									num36 = 38f;
								}
								if (inventory[selectedItem].type == 2330 || inventory[selectedItem].type == 2320 || inventory[selectedItem].type == 2341)
								{
									num36 += 4f;
								}
								itemLocation.X = position.X + (float)width * 0.5f + ((float)Main.itemTexture[inventory[selectedItem].type].Width * 0.5f - num36) * (float)direction;
								num36 = 10f;
								if (Main.itemTexture[inventory[selectedItem].type].Height > 32)
								{
									num36 = 8f;
								}
								if (Main.itemTexture[inventory[selectedItem].type].Height >= 32)
								{
									num36 = 12f;
								}
								if (Main.itemTexture[inventory[selectedItem].type].Height > 64)
								{
									num36 = 14f;
								}
								if (inventory[selectedItem].type == 2330 || inventory[selectedItem].type == 2320 || inventory[selectedItem].type == 2341)
								{
									num36 += 4f;
								}
								itemLocation.Y = position.Y + num36;
							}
							else
							{
								float num37 = 6f;
								if (Main.itemTexture[inventory[selectedItem].type].Width > 32)
								{
									num37 = 14f;
								}
								if (Main.itemTexture[inventory[selectedItem].type].Width >= 48)
								{
									num37 = 18f;
								}
								if (Main.itemTexture[inventory[selectedItem].type].Width >= 52)
								{
									num37 = 24f;
								}
								if (Main.itemTexture[inventory[selectedItem].type].Width >= 64)
								{
									num37 = 28f;
								}
								if (Main.itemTexture[inventory[selectedItem].type].Width >= 92)
								{
									num37 = 38f;
								}
								if (inventory[selectedItem].type == 2330 || inventory[selectedItem].type == 2320 || inventory[selectedItem].type == 2341)
								{
									num37 += 4f;
								}
								itemLocation.X = position.X + (float)width * 0.5f - ((float)Main.itemTexture[inventory[selectedItem].type].Width * 0.5f - num37) * (float)direction;
								num37 = 10f;
								if (Main.itemTexture[inventory[selectedItem].type].Height > 32)
								{
									num37 = 10f;
								}
								if (Main.itemTexture[inventory[selectedItem].type].Height > 52)
								{
									num37 = 12f;
								}
								if (Main.itemTexture[inventory[selectedItem].type].Height > 64)
								{
									num37 = 14f;
								}
								if (inventory[selectedItem].type == 2330 || inventory[selectedItem].type == 2320 || inventory[selectedItem].type == 2341)
								{
									num37 += 4f;
								}
								itemLocation.Y = position.Y + num37;
							}
							itemRotation = ((float)itemAnimation / (float)itemAnimationMax - 0.5f) * (float)(-direction) * 3.5f - (float)direction * 0.3f;
						}
						if (gravDir == -1f)
						{
							itemRotation = 0f - itemRotation;
							itemLocation.Y = position.Y + (float)height + (position.Y - itemLocation.Y);
						}
					}
					else if (inventory[selectedItem].useStyle == 2)
					{
						itemRotation = (float)itemAnimation / (float)itemAnimationMax * (float)direction * 2f + -1.4f * (float)direction;
						if ((double)itemAnimation < (double)itemAnimationMax * 0.5)
						{
							itemLocation.X = position.X + (float)width * 0.5f + ((float)Main.itemTexture[inventory[selectedItem].type].Width * 0.5f - 9f - itemRotation * 12f * (float)direction) * (float)direction;
							itemLocation.Y = position.Y + 38f + itemRotation * (float)direction * 4f;
						}
						else
						{
							itemLocation.X = position.X + (float)width * 0.5f + ((float)Main.itemTexture[inventory[selectedItem].type].Width * 0.5f - 9f - itemRotation * 16f * (float)direction) * (float)direction;
							itemLocation.Y = position.Y + 38f + itemRotation * (float)direction;
						}
						if (gravDir == -1f)
						{
							itemRotation = 0f - itemRotation;
							itemLocation.Y = position.Y + (float)height + (position.Y - itemLocation.Y);
						}
					}
					else if (inventory[selectedItem].useStyle == 3)
					{
						if ((double)itemAnimation > (double)itemAnimationMax * 0.666)
						{
							itemLocation.X = -1000f;
							itemLocation.Y = -1000f;
							itemRotation = -1.3f * (float)direction;
						}
						else
						{
							itemLocation.X = position.X + (float)width * 0.5f + ((float)Main.itemTexture[inventory[selectedItem].type].Width * 0.5f - 4f) * (float)direction;
							itemLocation.Y = position.Y + 24f;
							float num38 = (float)itemAnimation / (float)itemAnimationMax * (float)Main.itemTexture[inventory[selectedItem].type].Width * (float)direction * inventory[selectedItem].scale * 1.2f - (float)(10 * direction);
							if (num38 > -4f && direction == -1)
							{
								num38 = -8f;
							}
							if (num38 < 4f && direction == 1)
							{
								num38 = 8f;
							}
							itemLocation.X -= num38;
							itemRotation = 0.8f * (float)direction;
						}
						if (gravDir == -1f)
						{
							itemRotation = 0f - itemRotation;
							itemLocation.Y = position.Y + (float)height + (position.Y - itemLocation.Y);
						}
					}
					else if (inventory[selectedItem].useStyle == 4)
					{
						itemRotation = 0f;
						itemLocation.X = position.X + (float)width * 0.5f + ((float)Main.itemTexture[inventory[selectedItem].type].Width * 0.5f - 9f - itemRotation * 14f * (float)direction - 4f) * (float)direction;
						itemLocation.Y = position.Y + (float)Main.itemTexture[inventory[selectedItem].type].Height * 0.5f + 4f;
						if (gravDir == -1f)
						{
							itemRotation = 0f - itemRotation;
							itemLocation.Y = position.Y + (float)height + (position.Y - itemLocation.Y);
						}
					}
					else if (inventory[selectedItem].useStyle == 5)
					{
						itemLocation.X = position.X + (float)width * 0.5f - (float)Main.itemTexture[inventory[selectedItem].type].Width * 0.5f - (float)(direction * 2);
						itemLocation.Y = position.Y + (float)height * 0.5f - (float)Main.itemTexture[inventory[selectedItem].type].Height * 0.5f;
					}
				}
			}
			else if (inventory[selectedItem].holdStyle == 1 && !pulley && !mount.Active)
			{
				if (Main.dedServ)
				{
					itemLocation.X = position.X + (float)width * 0.5f + 20f * (float)direction;
				}
				else if (inventory[selectedItem].type == 930)
				{
					itemLocation.X = position.X + (float)(width / 2) * 0.5f - 12f - (float)(2 * direction);
					float num39 = position.X + (float)(width / 2) + (float)(38 * direction);
					if (direction == 1)
					{
						num39 -= 10f;
					}
					float num40 = position.Y + (float)(height / 2) - 4f * gravDir;
					if (gravDir == -1f)
					{
						num40 -= 8f;
					}
					int num41 = 0;
					for (int num42 = 54; num42 < 58; num42++)
					{
						if (inventory[num42].stack > 0 && inventory[num42].ammo == 931)
						{
							num41 = inventory[num42].type;
							break;
						}
					}
					if (num41 == 0)
					{
						for (int num43 = 0; num43 < 54; num43++)
						{
							if (inventory[num43].stack > 0 && inventory[num43].ammo == 931)
							{
								num41 = inventory[num43].type;
								break;
							}
						}
					}
					switch (num41)
					{
					case 931:
						num41 = 127;
						break;
					case 1614:
						num41 = 187;
						break;
					}
					if (num41 > 0)
					{
						int num44 = Dust.NewDust(new Vector2(num39, num40 + gfxOffY), 6, 6, num41, 0f, 0f, 100, default(Color), 1.6f);
						Main.dust[num44].noGravity = true;
						Main.dust[num44].velocity.Y -= 4f * gravDir;
					}
				}
				else if (inventory[selectedItem].type == 968)
				{
					itemLocation.X = position.X + (float)width * 0.5f + (float)(8 * direction);
					if (whoAmi == Main.myPlayer)
					{
						int num45 = (int)(itemLocation.X + (float)Main.itemTexture[inventory[selectedItem].type].Width * 0.8f * (float)direction) / 16;
						int num46 = (int)(itemLocation.Y + (float)(Main.itemTexture[inventory[selectedItem].type].Height / 2)) / 16;
						if (Main.tile[num45, num46] == null)
						{
							Main.tile[num45, num46] = new Tile();
						}
						if (Main.tile[num45, num46].active() && Main.tile[num45, num46].type == 215)
						{
							miscTimer++;
							if (Main.rand.Next(5) == 0)
							{
								miscTimer++;
							}
							if (miscTimer > 900)
							{
								miscTimer = 0;
								inventory[selectedItem].SetDefaults(969);
								if (selectedItem == 58)
								{
									Main.mouseItem.SetDefaults(969);
								}
								for (int num47 = 0; num47 < 58; num47++)
								{
									if (inventory[num47].type == inventory[selectedItem].type && num47 != selectedItem && inventory[num47].stack < inventory[num47].maxStack)
									{
										Main.PlaySound(7);
										inventory[num47].stack++;
										inventory[selectedItem].SetDefaults(0);
										if (selectedItem == 58)
										{
											Main.mouseItem.SetDefaults(0);
										}
									}
								}
							}
						}
						else
						{
							miscTimer = 0;
						}
					}
				}
				else if (inventory[selectedItem].type == 856)
				{
					itemLocation.X = position.X + (float)width * 0.5f + (float)(4 * direction);
				}
				else if (inventory[selectedItem].fishingPole > 0)
				{
					itemLocation.X = position.X + (float)width * 0.5f + (float)Main.itemTexture[inventory[selectedItem].type].Width * 0.18f * (float)direction;
				}
				else
				{
					itemLocation.X = position.X + (float)width * 0.5f + ((float)Main.itemTexture[inventory[selectedItem].type].Width * 0.5f + 2f) * (float)direction;
					if (inventory[selectedItem].type == 282 || inventory[selectedItem].type == 286)
					{
						itemLocation.X -= direction * 2;
						itemLocation.Y += 4f;
					}
				}
				itemLocation.Y = position.Y + 24f;
				if (inventory[selectedItem].type == 856)
				{
					itemLocation.Y = position.Y + 34f;
				}
				if (inventory[selectedItem].type == 930)
				{
					itemLocation.Y = position.Y + 9f;
				}
				if (inventory[selectedItem].fishingPole > 0)
				{
					itemLocation.Y += 4f;
				}
				itemRotation = 0f;
				if (gravDir == -1f)
				{
					itemRotation = 0f - itemRotation;
					itemLocation.Y = position.Y + (float)height + (position.Y - itemLocation.Y);
					if (inventory[selectedItem].type == 930)
					{
						itemLocation.Y -= 24f;
					}
				}
			}
			else if (inventory[selectedItem].holdStyle == 2 && !pulley && !mount.Active)
			{
				if (inventory[selectedItem].type == 946)
				{
					itemRotation = 0f;
					itemLocation.X = position.X + (float)width * 0.5f - (float)(16 * direction);
					itemLocation.Y = position.Y + 22f;
					fallStart = (int)(position.Y / 16f);
					if (gravDir == -1f)
					{
						itemRotation = 0f - itemRotation;
						itemLocation.Y = position.Y + (float)height + (position.Y - itemLocation.Y);
						if (velocity.Y < -2f)
						{
							velocity.Y = -2f;
						}
					}
					else if (velocity.Y > 2f)
					{
						velocity.Y = 2f;
					}
				}
				else
				{
					itemLocation.X = position.X + (float)width * 0.5f + (float)(6 * direction);
					itemLocation.Y = position.Y + 16f;
					itemRotation = 0.79f * (float)(-direction);
					if (gravDir == -1f)
					{
						itemRotation = 0f - itemRotation;
						itemLocation.Y = position.Y + (float)height + (position.Y - itemLocation.Y);
					}
				}
			}
			else if (inventory[selectedItem].holdStyle == 3 && !pulley && !mount.Active && !Main.dedServ)
			{
				itemLocation.X = position.X + (float)width * 0.5f - (float)Main.itemTexture[inventory[selectedItem].type].Width * 0.5f - (float)(direction * 2);
				itemLocation.Y = position.Y + (float)height * 0.5f - (float)Main.itemTexture[inventory[selectedItem].type].Height * 0.5f;
				itemRotation = 0f;
			}
			if ((((inventory[selectedItem].type == 974 || inventory[selectedItem].type == 8 || inventory[selectedItem].type == 1245 || inventory[selectedItem].type == 2274 || (inventory[selectedItem].type >= 427 && inventory[selectedItem].type <= 433)) && !wet) || inventory[selectedItem].type == 523 || inventory[selectedItem].type == 1333) && !pulley && !mount.Active)
			{
				float num48 = 1f;
				float num49 = 0.95f;
				float num50 = 0.8f;
				int num51 = 0;
				if (inventory[selectedItem].type == 523)
				{
					num51 = 8;
				}
				else if (inventory[selectedItem].type == 974)
				{
					num51 = 9;
				}
				else if (inventory[selectedItem].type == 1245)
				{
					num51 = 10;
				}
				else if (inventory[selectedItem].type == 1333)
				{
					num51 = 11;
				}
				else if (inventory[selectedItem].type == 2274)
				{
					num51 = 12;
				}
				else if (inventory[selectedItem].type >= 427)
				{
					num51 = inventory[selectedItem].type - 426;
				}
				switch (num51)
				{
				case 1:
					num48 = 0f;
					num49 = 0.1f;
					num50 = 1.3f;
					break;
				case 2:
					num48 = 1f;
					num49 = 0.1f;
					num50 = 0.1f;
					break;
				case 3:
					num48 = 0f;
					num49 = 1f;
					num50 = 0.1f;
					break;
				case 4:
					num48 = 0.9f;
					num49 = 0f;
					num50 = 0.9f;
					break;
				case 5:
					num48 = 1.3f;
					num49 = 1.3f;
					num50 = 1.3f;
					break;
				case 6:
					num48 = 0.9f;
					num49 = 0.9f;
					num50 = 0f;
					break;
				case 7:
					num48 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
					num49 = 0.3f;
					num50 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
					break;
				case 8:
					num50 = 0.7f;
					num48 = 0.85f;
					num49 = 1f;
					break;
				case 9:
					num50 = 1f;
					num48 = 0.7f;
					num49 = 0.85f;
					break;
				case 10:
					num50 = 0f;
					num48 = 1f;
					num49 = 0.5f;
					break;
				case 11:
					num50 = 0.8f;
					num48 = 1.25f;
					num49 = 1.25f;
					break;
				case 12:
					num48 *= 0.75f;
					num49 *= 1.3499999f;
					num50 *= 1.5f;
					break;
				}
				int num52 = num51;
				switch (num52)
				{
				case 0:
					num52 = 6;
					break;
				case 8:
					num52 = 75;
					break;
				case 9:
					num52 = 135;
					break;
				case 10:
					num52 = 158;
					break;
				case 11:
					num52 = 169;
					break;
				case 12:
					num52 = 156;
					break;
				default:
					num52 = 58 + num52;
					break;
				}
				int maxValue = 30;
				if (itemAnimation > 0)
				{
					maxValue = 7;
				}
				if (direction == -1)
				{
					if (Main.rand.Next(maxValue) == 0)
					{
						int num53 = Dust.NewDust(new Vector2(itemLocation.X - 16f, itemLocation.Y - 14f * gravDir), 4, 4, num52, 0f, 0f, 100);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num53].noGravity = true;
						}
						Main.dust[num53].velocity *= 0.3f;
						Main.dust[num53].velocity.Y -= 1.5f;
					}
					Lighting.addLight((int)((itemLocation.X - 12f + velocity.X) / 16f), (int)((itemLocation.Y - 14f + velocity.Y) / 16f), num48, num49, num50);
				}
				else
				{
					if (Main.rand.Next(maxValue) == 0)
					{
						int num54 = Dust.NewDust(new Vector2(itemLocation.X + 6f, itemLocation.Y - 14f * gravDir), 4, 4, num52, 0f, 0f, 100);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num54].noGravity = true;
						}
						Main.dust[num54].velocity *= 0.3f;
						Main.dust[num54].velocity.Y -= 1.5f;
					}
					Lighting.addLight((int)((itemLocation.X + 12f + velocity.X) / 16f), (int)((itemLocation.Y - 14f + velocity.Y) / 16f), num48, num49, num50);
				}
			}
			if ((inventory[selectedItem].type == 105 || inventory[selectedItem].type == 713) && !wet && !pulley)
			{
				int maxValue2 = 20;
				if (itemAnimation > 0)
				{
					maxValue2 = 7;
				}
				if (direction == -1)
				{
					if (Main.rand.Next(maxValue2) == 0)
					{
						int num55 = Dust.NewDust(new Vector2(itemLocation.X - 12f, itemLocation.Y - 20f * gravDir), 4, 4, 6, 0f, 0f, 100);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num55].noGravity = true;
						}
						Main.dust[num55].velocity *= 0.3f;
						Main.dust[num55].velocity.Y -= 1.5f;
					}
					Lighting.addLight((int)((itemLocation.X - 16f + velocity.X) / 16f), (int)((itemLocation.Y - 14f) / 16f), 1f, 0.95f, 0.8f);
				}
				else
				{
					if (Main.rand.Next(maxValue2) == 0)
					{
						int num56 = Dust.NewDust(new Vector2(itemLocation.X + 4f, itemLocation.Y - 20f * gravDir), 4, 4, 6, 0f, 0f, 100);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num56].noGravity = true;
						}
						Main.dust[num56].velocity *= 0.3f;
						Main.dust[num56].velocity.Y -= 1.5f;
					}
					Lighting.addLight((int)((itemLocation.X + 6f + velocity.X) / 16f), (int)((itemLocation.Y - 14f) / 16f), 1f, 0.95f, 0.8f);
				}
			}
			else if (inventory[selectedItem].type == 148 && !wet)
			{
				int maxValue3 = 10;
				if (itemAnimation > 0)
				{
					maxValue3 = 7;
				}
				if (direction == -1)
				{
					if (Main.rand.Next(maxValue3) == 0)
					{
						int num57 = Dust.NewDust(new Vector2(itemLocation.X - 12f, itemLocation.Y - 20f * gravDir), 4, 4, 172, 0f, 0f, 100);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num57].noGravity = true;
						}
						Main.dust[num57].velocity *= 0.3f;
						Main.dust[num57].velocity.Y -= 1.5f;
					}
					Lighting.addLight((int)((itemLocation.X - 16f + velocity.X) / 16f), (int)((itemLocation.Y - 14f) / 16f), 0f, 0.5f, 1f);
				}
				else
				{
					if (Main.rand.Next(maxValue3) == 0)
					{
						int num58 = Dust.NewDust(new Vector2(itemLocation.X + 4f, itemLocation.Y - 20f * gravDir), 4, 4, 172, 0f, 0f, 100);
						if (Main.rand.Next(3) != 0)
						{
							Main.dust[num58].noGravity = true;
						}
						Main.dust[num58].velocity *= 0.3f;
						Main.dust[num58].velocity.Y -= 1.5f;
					}
					Lighting.addLight((int)((itemLocation.X + 6f + velocity.X) / 16f), (int)((itemLocation.Y - 14f) / 16f), 0f, 0.5f, 1f);
				}
			}
			if (inventory[selectedItem].type == 282 && !pulley)
			{
				if (direction == -1)
				{
					Lighting.addLight((int)((itemLocation.X - 16f + velocity.X) / 16f), (int)((itemLocation.Y - 14f) / 16f), 0.7f, 1f, 0.8f);
				}
				else
				{
					Lighting.addLight((int)((itemLocation.X + 6f + velocity.X) / 16f), (int)((itemLocation.Y - 14f) / 16f), 0.7f, 1f, 0.8f);
				}
			}
			if (inventory[selectedItem].type == 286 && !pulley)
			{
				if (direction == -1)
				{
					Lighting.addLight((int)((itemLocation.X - 16f + velocity.X) / 16f), (int)((itemLocation.Y - 14f) / 16f), 0.7f, 0.8f, 1f);
				}
				else
				{
					Lighting.addLight((int)((itemLocation.X + 6f + velocity.X) / 16f), (int)((itemLocation.Y - 14f) / 16f), 0.7f, 0.8f, 1f);
				}
			}
			if (controlUseItem)
			{
				releaseUseItem = false;
			}
			else
			{
				releaseUseItem = true;
			}
			if (itemTime > 0)
			{
				itemTime--;
				if (itemTime == 0 && whoAmi == Main.myPlayer)
				{
					int type2 = inventory[selectedItem].type;
					if (type2 == 65 || type2 == 676 || type2 == 723 || type2 == 724 || type2 == 989 || type2 == 1226 || type2 == 1227)
					{
						Main.PlaySound(25);
						for (int num59 = 0; num59 < 5; num59++)
						{
							int num60 = Dust.NewDust(position, width, height, 45, 0f, 0f, 255, default(Color), (float)Main.rand.Next(20, 26) * 0.1f);
							Main.dust[num60].noLight = true;
							Main.dust[num60].noGravity = true;
							Main.dust[num60].velocity *= 0.5f;
						}
					}
				}
			}
			if (i == Main.myPlayer)
			{
				bool flag6 = true;
				int type3 = inventory[selectedItem].type;
				if ((type3 == 65 || type3 == 676 || type3 == 723 || type3 == 724 || type3 == 757 || type3 == 674 || type3 == 675 || type3 == 989 || type3 == 1226 || type3 == 1227) && itemAnimation != itemAnimationMax - 1)
				{
					flag6 = false;
				}
				if (inventory[selectedItem].shoot > 0 && itemAnimation > 0 && itemTime == 0 && flag6)
				{
					int num61 = inventory[selectedItem].shoot;
					float num62 = inventory[selectedItem].shootSpeed;
					if (inventory[selectedItem].melee && num61 != 25 && num61 != 26 && num61 != 35)
					{
						num62 /= meleeSpeed;
					}
					bool flag7 = false;
					int num63 = num2;
					float num64 = inventory[selectedItem].knockBack;
					if (num61 == 13 || num61 == 32 || num61 == 315 || (num61 >= 230 && num61 <= 235) || num61 == 331)
					{
						grappling[0] = -1;
						grapCount = 0;
						for (int num65 = 0; num65 < 1000; num65++)
						{
							if (Main.projectile[num65].active && Main.projectile[num65].owner == i)
							{
								if (Main.projectile[num65].type == 13)
								{
									Main.projectile[num65].Kill();
								}
								if (Main.projectile[num65].type == 331)
								{
									Main.projectile[num65].Kill();
								}
								if (Main.projectile[num65].type == 315)
								{
									Main.projectile[num65].Kill();
								}
								if (Main.projectile[num65].type >= 230 && Main.projectile[num65].type <= 235)
								{
									Main.projectile[num65].Kill();
								}
							}
						}
					}
					if (inventory[selectedItem].useAmmo > 0)
					{
						Item item2 = new Item();
						bool flag8 = false;
						for (int num66 = 54; num66 < 58; num66++)
						{
							if (inventory[num66].ammo == inventory[selectedItem].useAmmo && inventory[num66].stack > 0)
							{
								item2 = inventory[num66];
								flag7 = true;
								flag8 = true;
								break;
							}
						}
						if (!flag8)
						{
							for (int num67 = 0; num67 < 54; num67++)
							{
								if (inventory[num67].ammo == inventory[selectedItem].useAmmo && inventory[num67].stack > 0)
								{
									item2 = inventory[num67];
									flag7 = true;
									break;
								}
							}
						}
						if (flag7)
						{
							if (inventory[selectedItem].type == 1946)
							{
								num61 = 338 + item2.type - 771;
							}
							else if (inventory[selectedItem].useAmmo == 771)
							{
								num61 += item2.shoot;
							}
							else if (inventory[selectedItem].useAmmo == 780)
							{
								num61 += item2.shoot;
							}
							else if (item2.shoot > 0)
							{
								num61 = item2.shoot;
							}
							if (num61 == 42)
							{
								if (item2.type == 370)
								{
									num61 = 65;
									num63 += 5;
								}
								else if (item2.type == 408)
								{
									num61 = 68;
									num63 += 5;
								}
								else if (item2.type == 1246)
								{
									num61 = 354;
									num63 += 5;
								}
							}
							if (magicQuiver && (inventory[selectedItem].useAmmo == 1 || inventory[selectedItem].useAmmo == 323))
							{
								num64 = (int)((double)num64 * 1.1);
								num62 *= 1.1f;
							}
							num62 += item2.shootSpeed;
							if (item2.ranged)
							{
								if (item2.damage > 0)
								{
									num63 += (int)((float)item2.damage * rangedDamage);
								}
							}
							else
							{
								num63 += item2.damage;
							}
							if (inventory[selectedItem].useAmmo == 1 && archery)
							{
								if (num62 < 20f)
								{
									num62 *= 1.2f;
									if (num62 > 20f)
									{
										num62 = 20f;
									}
								}
								num63 = (int)((double)(float)num63 * 1.2);
							}
							num64 += item2.knockBack;
							bool flag9 = false;
							if (magicQuiver && inventory[selectedItem].useAmmo == 1 && Main.rand.Next(5) == 0)
							{
								flag9 = true;
							}
							if (ammoBox && Main.rand.Next(5) == 0)
							{
								flag9 = true;
							}
							if (ammoPotion && Main.rand.Next(5) == 0)
							{
								flag9 = true;
							}
							if (inventory[selectedItem].type == 1782 && Main.rand.Next(3) == 0)
							{
								flag9 = true;
							}
							if (inventory[selectedItem].type == 98 && Main.rand.Next(3) == 0)
							{
								flag9 = true;
							}
							if (inventory[selectedItem].type == 2270 && Main.rand.Next(2) == 0)
							{
								flag9 = true;
							}
							if (inventory[selectedItem].type == 533 && Main.rand.Next(2) == 0)
							{
								flag9 = true;
							}
							if (inventory[selectedItem].type == 1929 && Main.rand.Next(2) == 0)
							{
								flag9 = true;
							}
							if (inventory[selectedItem].type == 1553 && Main.rand.Next(2) == 0)
							{
								flag9 = true;
							}
							if (inventory[selectedItem].type == 434 && itemAnimation < inventory[selectedItem].useAnimation - 2)
							{
								flag9 = true;
							}
							if (ammoCost80 && Main.rand.Next(5) == 0)
							{
								flag9 = true;
							}
							if (ammoCost75 && Main.rand.Next(4) == 0)
							{
								flag9 = true;
							}
							if (num61 == 85 && itemAnimation < itemAnimationMax - 6)
							{
								flag9 = true;
							}
							if ((num61 == 145 || num61 == 146 || num61 == 147 || num61 == 148 || num61 == 149) && itemAnimation < itemAnimationMax - 5)
							{
								flag9 = true;
							}
							if (!flag9)
							{
								item2.stack--;
								if (item2.stack <= 0)
								{
									item2.active = false;
									item2.name = "";
									item2.type = 0;
								}
							}
						}
					}
					else
					{
						flag7 = true;
					}
					if (inventory[selectedItem].type == 71)
					{
						flag7 = false;
					}
					if (inventory[selectedItem].type == 72)
					{
						flag7 = false;
					}
					if (inventory[selectedItem].type == 73)
					{
						flag7 = false;
					}
					if (inventory[selectedItem].type == 74)
					{
						flag7 = false;
					}
					if (inventory[selectedItem].type == 1254 && num61 == 14)
					{
						num61 = 242;
					}
					if (inventory[selectedItem].type == 1255 && num61 == 14)
					{
						num61 = 242;
					}
					if (inventory[selectedItem].type == 1265 && num61 == 14)
					{
						num61 = 242;
					}
					if (num61 == 73)
					{
						for (int num68 = 0; num68 < 1000; num68++)
						{
							if (Main.projectile[num68].active && Main.projectile[num68].owner == i)
							{
								if (Main.projectile[num68].type == 73)
								{
									num61 = 74;
								}
								if (num61 == 74 && Main.projectile[num68].type == 74)
								{
									flag7 = false;
								}
							}
						}
					}
					if (flag7)
					{
						if (inventory[selectedItem].summon)
						{
							num64 += minionKB;
							num63 = (int)((float)num63 * minionDamage);
						}
						if (num61 == 228)
						{
							num64 = 0f;
						}
						if (inventory[selectedItem].melee && kbGlove)
						{
							num64 *= 2f;
						}
						if (kbBuff)
						{
							num64 *= 1.5f;
						}
						if (inventory[selectedItem].ranged && armorSteath)
						{
							num64 *= 1f + (1f - stealth) * 0.5f;
						}
						if (num61 == 1 && inventory[selectedItem].type == 120)
						{
							num61 = 2;
						}
						if (inventory[selectedItem].type == 682)
						{
							num61 = 117;
						}
						if (inventory[selectedItem].type == 725)
						{
							num61 = 120;
						}
						if (inventory[selectedItem].type == 2223)
						{
							num61 = 357;
						}
						itemTime = inventory[selectedItem].useTime;
						if ((float)Main.mouseX + Main.screenPosition.X > position.X + (float)width * 0.5f)
						{
							ChangeDir(1);
						}
						else
						{
							ChangeDir(-1);
						}
						Vector2 vector = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
						switch (num61)
						{
						case 9:
							vector = new Vector2(position.X + (float)width * 0.5f + (float)(Main.rand.Next(201) * -direction) + ((float)Main.mouseX + Main.screenPosition.X - position.X), position.Y + (float)height * 0.5f - 600f);
							num64 = 0f;
							num63 *= 2;
							break;
						case 51:
							vector.Y -= 6f * gravDir;
							break;
						}
						float num69 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
						float num70 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
						if (gravDir == -1f)
						{
							num70 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
						}
						float num71 = (float)Math.Sqrt(num69 * num69 + num70 * num70);
						float num72 = num71;
						num71 = num62 / num71;
						if (inventory[selectedItem].type == 1929 || inventory[selectedItem].type == 2270)
						{
							num69 += (float)Main.rand.Next(-50, 51) * 0.03f / num71;
							num70 += (float)Main.rand.Next(-50, 51) * 0.03f / num71;
						}
						num69 *= num71;
						num70 *= num71;
						if (inventory[selectedItem].type == 757)
						{
							num63 = (int)((float)num63 * 1.25f);
						}
						if (num61 == 250)
						{
							for (int num73 = 0; num73 < 1000; num73++)
							{
								if (Main.projectile[num73].active && Main.projectile[num73].owner == whoAmi && (Main.projectile[num73].type == 250 || Main.projectile[num73].type == 251))
								{
									Main.projectile[num73].Kill();
								}
							}
						}
						if (num61 == 12)
						{
							vector.X += num69 * 3f;
							vector.Y += num70 * 3f;
						}
						if (inventory[selectedItem].useStyle == 5)
						{
							itemRotation = (float)Math.Atan2(num70 * (float)direction, num69 * (float)direction);
							NetMessage.SendData(13, -1, -1, "", whoAmi);
							NetMessage.SendData(41, -1, -1, "", whoAmi);
						}
						if (num61 == 17)
						{
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
							if (gravDir == -1f)
							{
								vector.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;
							}
						}
						if (num61 == 76)
						{
							num61 += Main.rand.Next(3);
							num72 /= (float)(Main.screenHeight / 2);
							if (num72 > 1f)
							{
								num72 = 1f;
							}
							float num74 = num69 + (float)Main.rand.Next(-40, 41) * 0.01f;
							float num75 = num70 + (float)Main.rand.Next(-40, 41) * 0.01f;
							num74 *= num72 + 0.25f;
							num75 *= num72 + 0.25f;
							int num76 = Projectile.NewProjectile(vector.X, vector.Y, num74, num75, num61, num63, num64, i);
							Main.projectile[num76].ai[1] = 1f;
							num72 = num72 * 2f - 1f;
							if (num72 < -1f)
							{
								num72 = -1f;
							}
							if (num72 > 1f)
							{
								num72 = 1f;
							}
							Main.projectile[num76].ai[0] = num72;
							NetMessage.SendData(27, -1, -1, "", num76);
						}
						else if (inventory[selectedItem].type == 98 || inventory[selectedItem].type == 533)
						{
							float speedX = num69 + (float)Main.rand.Next(-40, 41) * 0.01f;
							float speedY = num70 + (float)Main.rand.Next(-40, 41) * 0.01f;
							Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, num61, num63, num64, i);
						}
						else if (inventory[selectedItem].type == 2270)
						{
							float num77 = num69 + (float)Main.rand.Next(-40, 41) * 0.05f;
							float num78 = num70 + (float)Main.rand.Next(-40, 41) * 0.05f;
							if (Main.rand.Next(3) == 0)
							{
								num77 *= 1f + (float)Main.rand.Next(-30, 31) * 0.02f;
								num78 *= 1f + (float)Main.rand.Next(-30, 31) * 0.02f;
							}
							Projectile.NewProjectile(vector.X, vector.Y, num77, num78, num61, num63, num64, i);
						}
						else if (inventory[selectedItem].type == 1930)
						{
							int num79 = 2 + Main.rand.Next(3);
							for (int num80 = 0; num80 < num79; num80++)
							{
								float num81 = num69;
								float num82 = num70;
								float num83 = 0.025f * (float)num80;
								num81 += (float)Main.rand.Next(-35, 36) * num83;
								num82 += (float)Main.rand.Next(-35, 36) * num83;
								num71 = (float)Math.Sqrt(num81 * num81 + num82 * num82);
								num71 = num62 / num71;
								num81 *= num71;
								num82 *= num71;
								float x = vector.X + num69 * (float)(num79 - num80) * 1.75f;
								float y = vector.Y + num70 * (float)(num79 - num80) * 1.75f;
								Projectile.NewProjectile(x, y, num81, num82, num61, num63, num64, i, Main.rand.Next(0, 10 * (num80 + 1)));
							}
						}
						else if (inventory[selectedItem].type == 1931)
						{
							int num84 = 2;
							for (int num85 = 0; num85 < num84; num85++)
							{
								vector = new Vector2(position.X + (float)width * 0.5f + (float)(Main.rand.Next(201) * -direction) + ((float)Main.mouseX + Main.screenPosition.X - position.X), position.Y + (float)height * 0.5f - 600f);
								vector.X = (vector.X + center().X) / 2f + (float)Main.rand.Next(-200, 201);
								vector.Y -= 100 * num85;
								num69 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
								num70 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
								if (num70 < 0f)
								{
									num70 *= -1f;
								}
								if (num70 < 20f)
								{
									num70 = 20f;
								}
								num71 = (float)Math.Sqrt(num69 * num69 + num70 * num70);
								num71 = num62 / num71;
								num69 *= num71;
								num70 *= num71;
								float speedX2 = num69 + (float)Main.rand.Next(-40, 41) * 0.02f;
								float speedY2 = num70 + (float)Main.rand.Next(-40, 41) * 0.02f;
								Projectile.NewProjectile(vector.X, vector.Y, speedX2, speedY2, num61, num63, num64, i, 0f, Main.rand.Next(5));
							}
						}
						else if (inventory[selectedItem].type == 2624)
						{
							float num86 = (float)Math.PI / 10f;
							int num87 = 5;
							Vector2 spinningpoint = new Vector2(num69, num70);
							spinningpoint.Normalize();
							spinningpoint *= 40f;
							for (int num88 = 0; num88 < num87; num88++)
							{
								float num89 = (float)num88 - ((float)num87 - 1f) / 2f;
								Vector2 vector2 = spinningpoint.Rotate(num86 * num89);
								int num90 = Projectile.NewProjectile(vector.X + vector2.X, vector.Y + vector2.Y, num69, num70, num61, num63, num64, i);
								Main.projectile[num90].noDropItem = true;
							}
						}
						else if (inventory[selectedItem].type == 1929)
						{
							float speedX3 = num69 + (float)Main.rand.Next(-40, 41) * 0.03f;
							float speedY3 = num70 + (float)Main.rand.Next(-40, 41) * 0.03f;
							Projectile.NewProjectile(vector.X, vector.Y, speedX3, speedY3, num61, num63, num64, i);
						}
						else if (inventory[selectedItem].type == 1553)
						{
							float speedX4 = num69 + (float)Main.rand.Next(-40, 41) * 0.005f;
							float speedY4 = num70 + (float)Main.rand.Next(-40, 41) * 0.005f;
							Projectile.NewProjectile(vector.X, vector.Y, speedX4, speedY4, num61, num63, num64, i);
						}
						else if (inventory[selectedItem].type == 518)
						{
							float num91 = num69;
							float num92 = num70;
							num91 += (float)Main.rand.Next(-40, 41) * 0.04f;
							num92 += (float)Main.rand.Next(-40, 41) * 0.04f;
							Projectile.NewProjectile(vector.X, vector.Y, num91, num92, num61, num63, num64, i);
						}
						else if (inventory[selectedItem].type == 1265)
						{
							float num93 = num69;
							float num94 = num70;
							num93 += (float)Main.rand.Next(-30, 31) * 0.03f;
							num94 += (float)Main.rand.Next(-30, 31) * 0.03f;
							Projectile.NewProjectile(vector.X, vector.Y, num93, num94, num61, num63, num64, i);
						}
						else if (inventory[selectedItem].type == 534)
						{
							for (int num95 = 0; num95 < 4; num95++)
							{
								float num96 = num69;
								float num97 = num70;
								num96 += (float)Main.rand.Next(-40, 41) * 0.05f;
								num97 += (float)Main.rand.Next(-40, 41) * 0.05f;
								Projectile.NewProjectile(vector.X, vector.Y, num96, num97, num61, num63, num64, i);
							}
						}
						else if (inventory[selectedItem].type == 2188)
						{
							int num98 = 4;
							if (Main.rand.Next(3) == 0)
							{
								num98++;
							}
							if (Main.rand.Next(4) == 0)
							{
								num98++;
							}
							if (Main.rand.Next(5) == 0)
							{
								num98++;
							}
							for (int num99 = 0; num99 < num98; num99++)
							{
								float num100 = num69;
								float num101 = num70;
								float num102 = 0.05f * (float)num99;
								num100 += (float)Main.rand.Next(-35, 36) * num102;
								num101 += (float)Main.rand.Next(-35, 36) * num102;
								num71 = (float)Math.Sqrt(num100 * num100 + num101 * num101);
								num71 = num62 / num71;
								num100 *= num71;
								num101 *= num71;
								float x2 = vector.X;
								float y2 = vector.Y;
								Projectile.NewProjectile(x2, y2, num100, num101, num61, num63, num64, i);
							}
						}
						else if (inventory[selectedItem].type == 1308)
						{
							int num103 = 3;
							if (Main.rand.Next(3) == 0)
							{
								num103++;
							}
							for (int num104 = 0; num104 < num103; num104++)
							{
								float num105 = num69;
								float num106 = num70;
								float num107 = 0.05f * (float)num104;
								num105 += (float)Main.rand.Next(-35, 36) * num107;
								num106 += (float)Main.rand.Next(-35, 36) * num107;
								num71 = (float)Math.Sqrt(num105 * num105 + num106 * num106);
								num71 = num62 / num71;
								num105 *= num71;
								num106 *= num71;
								float x3 = vector.X;
								float y3 = vector.Y;
								Projectile.NewProjectile(x3, y3, num105, num106, num61, num63, num64, i);
							}
						}
						else if (inventory[selectedItem].type == 1258)
						{
							float num108 = num69;
							float num109 = num70;
							num108 += (float)Main.rand.Next(-40, 41) * 0.01f;
							num109 += (float)Main.rand.Next(-40, 41) * 0.01f;
							vector.X += (float)Main.rand.Next(-40, 41) * 0.05f;
							vector.Y += (float)Main.rand.Next(-45, 36) * 0.05f;
							Projectile.NewProjectile(vector.X, vector.Y, num108, num109, num61, num63, num64, i);
						}
						else if (inventory[selectedItem].type == 964)
						{
							for (int num110 = 0; num110 < 3; num110++)
							{
								float num111 = num69;
								float num112 = num70;
								num111 += (float)Main.rand.Next(-35, 36) * 0.04f;
								num112 += (float)Main.rand.Next(-35, 36) * 0.04f;
								Projectile.NewProjectile(vector.X, vector.Y, num111, num112, num61, num63, num64, i);
							}
						}
						else if (inventory[selectedItem].type == 1569)
						{
							int num113 = 4;
							if (Main.rand.Next(2) == 0)
							{
								num113++;
							}
							if (Main.rand.Next(4) == 0)
							{
								num113++;
							}
							if (Main.rand.Next(8) == 0)
							{
								num113++;
							}
							if (Main.rand.Next(16) == 0)
							{
								num113++;
							}
							for (int num114 = 0; num114 < num113; num114++)
							{
								float num115 = num69;
								float num116 = num70;
								float num117 = 0.05f * (float)num114;
								num115 += (float)Main.rand.Next(-35, 36) * num117;
								num116 += (float)Main.rand.Next(-35, 36) * num117;
								num71 = (float)Math.Sqrt(num115 * num115 + num116 * num116);
								num71 = num62 / num71;
								num115 *= num71;
								num116 *= num71;
								float x4 = vector.X;
								float y4 = vector.Y;
								Projectile.NewProjectile(x4, y4, num115, num116, num61, num63, num64, i);
							}
						}
						else if (inventory[selectedItem].type == 1572 || inventory[selectedItem].type == 2366)
						{
							int num118 = 308;
							if (inventory[selectedItem].type == 2366)
							{
								num118 = 377;
							}
							for (int num119 = 0; num119 < 1000; num119++)
							{
								if (Main.projectile[num119].owner == whoAmi && Main.projectile[num119].type == num118)
								{
									Main.projectile[num119].Kill();
								}
							}
							int num120 = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
							int num121 = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
							if (gravDir == -1f)
							{
								num121 = (int)(Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16;
							}
							for (; num121 < Main.maxTilesY - 10 && Main.tile[num120, num121] != null && !WorldGen.SolidTile(num120, num121) && Main.tile[num120 - 1, num121] != null && !WorldGen.SolidTile(num120 - 1, num121) && Main.tile[num120 + 1, num121] != null && !WorldGen.SolidTile(num120 + 1, num121); num121++)
							{
							}
							num121--;
							Projectile.NewProjectile((float)Main.mouseX + Main.screenPosition.X, num121 * 16 - 24, 0f, 15f, num61, num63, num64, i);
						}
						else if (inventory[selectedItem].type == 1244 || inventory[selectedItem].type == 1256)
						{
							int num122 = Projectile.NewProjectile(vector.X, vector.Y, num69, num70, num61, num63, num64, i);
							Main.projectile[num122].ai[0] = (float)Main.mouseX + Main.screenPosition.X;
							Main.projectile[num122].ai[1] = (float)Main.mouseY + Main.screenPosition.Y;
						}
						else if (inventory[selectedItem].type == 1229)
						{
							int num123 = Main.rand.Next(2, 4);
							if (Main.rand.Next(5) == 0)
							{
								num123++;
							}
							for (int num124 = 0; num124 < num123; num124++)
							{
								float num125 = num69;
								float num126 = num70;
								if (num124 > 0)
								{
									num125 += (float)Main.rand.Next(-35, 36) * 0.04f;
									num126 += (float)Main.rand.Next(-35, 36) * 0.04f;
								}
								if (num124 > 1)
								{
									num125 += (float)Main.rand.Next(-35, 36) * 0.04f;
									num126 += (float)Main.rand.Next(-35, 36) * 0.04f;
								}
								if (num124 > 2)
								{
									num125 += (float)Main.rand.Next(-35, 36) * 0.04f;
									num126 += (float)Main.rand.Next(-35, 36) * 0.04f;
								}
								int num127 = Projectile.NewProjectile(vector.X, vector.Y, num125, num126, num61, num63, num64, i);
								Main.projectile[num127].noDropItem = true;
							}
						}
						else if (inventory[selectedItem].type == 1121 || inventory[selectedItem].type == 1155)
						{
							int num128 = 1;
							if (inventory[selectedItem].type == 1121)
							{
								num128 = Main.rand.Next(1, 4);
								if (Main.rand.Next(6) == 0)
								{
									num128++;
								}
								if (Main.rand.Next(6) == 0)
								{
									num128++;
								}
							}
							else
							{
								num128 = Main.rand.Next(2, 5);
								if (Main.rand.Next(5) == 0)
								{
									num128++;
								}
								if (Main.rand.Next(5) == 0)
								{
									num128++;
								}
							}
							for (int num129 = 0; num129 < num128; num129++)
							{
								float num130 = num69;
								float num131 = num70;
								num130 += (float)Main.rand.Next(-35, 36) * 0.02f;
								num131 += (float)Main.rand.Next(-35, 36) * 0.02f;
								Projectile.NewProjectile(vector.X, vector.Y, num130, num131, num61, num63, num64, i);
							}
						}
						else if (inventory[selectedItem].type == 1801)
						{
							int num132 = Main.rand.Next(1, 4);
							for (int num133 = 0; num133 < num132; num133++)
							{
								float num134 = num69;
								float num135 = num70;
								num134 += (float)Main.rand.Next(-35, 36) * 0.05f;
								num135 += (float)Main.rand.Next(-35, 36) * 0.05f;
								Projectile.NewProjectile(vector.X, vector.Y, num134, num135, num61, num63, num64, i);
							}
						}
						else if (inventory[selectedItem].type == 679)
						{
							for (int num136 = 0; num136 < 6; num136++)
							{
								float num137 = num69;
								float num138 = num70;
								num137 += (float)Main.rand.Next(-40, 41) * 0.05f;
								num138 += (float)Main.rand.Next(-40, 41) * 0.05f;
								Projectile.NewProjectile(vector.X, vector.Y, num137, num138, num61, num63, num64, i);
							}
						}
						else if (inventory[selectedItem].type == 2623)
						{
							for (int num139 = 0; num139 < 3; num139++)
							{
								float num140 = num69;
								float num141 = num70;
								num140 += (float)Main.rand.Next(-40, 41) * 0.1f;
								num141 += (float)Main.rand.Next(-40, 41) * 0.1f;
								Projectile.NewProjectile(vector.X, vector.Y, num140, num141, num61, num63, num64, i);
							}
						}
						else if (inventory[selectedItem].type == 434)
						{
							float num142 = num69;
							float num143 = num70;
							if (itemAnimation < 5)
							{
								num142 += (float)Main.rand.Next(-40, 41) * 0.01f;
								num143 += (float)Main.rand.Next(-40, 41) * 0.01f;
								num142 *= 1.1f;
								num143 *= 1.1f;
							}
							else if (itemAnimation < 10)
							{
								num142 += (float)Main.rand.Next(-20, 21) * 0.01f;
								num143 += (float)Main.rand.Next(-20, 21) * 0.01f;
								num142 *= 1.05f;
								num143 *= 1.05f;
							}
							Projectile.NewProjectile(vector.X, vector.Y, num142, num143, num61, num63, num64, i);
						}
						else if (inventory[selectedItem].type == 1157)
						{
							num61 = Main.rand.Next(191, 195);
							num69 = 0f;
							num70 = 0f;
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
							int num144 = Projectile.NewProjectile(vector.X, vector.Y, num69, num70, num61, num63, num64, i);
							Main.projectile[num144].localAI[0] = 30f;
						}
						else if (inventory[selectedItem].type == 1802)
						{
							num69 = 0f;
							num70 = 0f;
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(vector.X, vector.Y, num69, num70, num61, num63, num64, i);
						}
						else if (inventory[selectedItem].type == 2364 || inventory[selectedItem].type == 2365)
						{
							num69 = 0f;
							num70 = 0f;
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(vector.X, vector.Y, num69, num70, num61, num63, num64, i);
						}
						else if (inventory[selectedItem].type == 2535)
						{
							num69 = 0f;
							num70 = 0f;
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Vector2 spinningpoint2 = new Vector2(num69, num70);
							spinningpoint2 = spinningpoint2.Rotate(1.5707963705062866);
							Projectile.NewProjectile(vector.X + spinningpoint2.X, vector.Y + spinningpoint2.Y, spinningpoint2.X, spinningpoint2.Y, num61, num63, num64, i);
							spinningpoint2 = spinningpoint2.Rotate(-3.1415927410125732);
							Projectile.NewProjectile(vector.X + spinningpoint2.X, vector.Y + spinningpoint2.Y, spinningpoint2.X, spinningpoint2.Y, num61 + 1, num63, num64, i);
						}
						else if (inventory[selectedItem].type == 2551)
						{
							num69 = 0f;
							num70 = 0f;
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(vector.X, vector.Y, num69, num70, num61 + Main.rand.Next(3), num63, num64, i);
						}
						else if (inventory[selectedItem].type == 2584)
						{
							num69 = 0f;
							num70 = 0f;
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(vector.X, vector.Y, num69, num70, num61 + Main.rand.Next(3), num63, num64, i);
						}
						else if (inventory[selectedItem].type == 2621)
						{
							num69 = 0f;
							num70 = 0f;
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(vector.X, vector.Y, num69, num70, num61, num63, num64, i);
						}
						else if (inventory[selectedItem].type == 1309)
						{
							num69 = 0f;
							num70 = 0f;
							vector.X = (float)Main.mouseX + Main.screenPosition.X;
							vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
							Projectile.NewProjectile(vector.X, vector.Y, num69, num70, num61, num63, num64, i);
						}
						else if (inventory[selectedItem].shoot > 0 && (Main.projPet[inventory[selectedItem].shoot] || inventory[selectedItem].shoot == 72 || inventory[selectedItem].shoot == 18) && !inventory[selectedItem].summon)
						{
							for (int num145 = 0; num145 < 1000; num145++)
							{
								if (!Main.projectile[num145].active || Main.projectile[num145].owner != whoAmi)
								{
									continue;
								}
								if (inventory[selectedItem].shoot == 72)
								{
									if (Main.projectile[num145].type == 72 || Main.projectile[num145].type == 86 || Main.projectile[num145].type == 87)
									{
										Main.projectile[num145].Kill();
									}
								}
								else if (inventory[selectedItem].shoot == Main.projectile[num145].type)
								{
									Main.projectile[num145].Kill();
								}
							}
							Projectile.NewProjectile(vector.X, vector.Y, num69, num70, num61, num63, num64, i);
						}
						else
						{
							int num146 = Projectile.NewProjectile(vector.X, vector.Y, num69, num70, num61, num63, num64, i);
							if (inventory[selectedItem].type == 726)
							{
								Main.projectile[num146].magic = true;
							}
							if (inventory[selectedItem].type == 724 || inventory[selectedItem].type == 676)
							{
								Main.projectile[num146].melee = true;
							}
							if (num61 == 80)
							{
								Main.projectile[num146].ai[0] = tileTargetX;
								Main.projectile[num146].ai[1] = tileTargetY;
							}
						}
					}
					else if (inventory[selectedItem].useStyle == 5)
					{
						itemRotation = 0f;
						NetMessage.SendData(41, -1, -1, "", whoAmi);
					}
				}
				if (whoAmi == Main.myPlayer && (inventory[selectedItem].type == 509 || inventory[selectedItem].type == 510 || inventory[selectedItem].type == 849 || inventory[selectedItem].type == 850 || inventory[selectedItem].type == 851) && position.X / 16f - (float)tileRangeX - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetX && (position.X + (float)width) / 16f + (float)tileRangeX + (float)inventory[selectedItem].tileBoost - 1f + (float)blockRange >= (float)tileTargetX && position.Y / 16f - (float)tileRangeY - (float)inventory[selectedItem].tileBoost - (float)blockRange <= (float)tileTargetY && (position.Y + (float)height) / 16f + (float)tileRangeY + (float)inventory[selectedItem].tileBoost - 2f + (float)blockRange >= (float)tileTargetY)
				{
					showItemIcon = true;
					if (itemAnimation > 0 && itemTime == 0 && controlUseItem)
					{
						int i2 = tileTargetX;
						int j2 = tileTargetY;
						if (inventory[selectedItem].type == 509)
						{
							int num147 = -1;
							for (int num148 = 0; num148 < 58; num148++)
							{
								if (inventory[num148].stack > 0 && inventory[num148].type == 530)
								{
									num147 = num148;
									break;
								}
							}
							if (num147 >= 0 && WorldGen.PlaceWire(i2, j2))
							{
								inventory[num147].stack--;
								if (inventory[num147].stack <= 0)
								{
									inventory[num147].SetDefaults(0);
								}
								itemTime = inventory[selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 5, tileTargetX, tileTargetY);
							}
						}
						else if (inventory[selectedItem].type == 850)
						{
							int num149 = -1;
							for (int num150 = 0; num150 < 58; num150++)
							{
								if (inventory[num150].stack > 0 && inventory[num150].type == 530)
								{
									num149 = num150;
									break;
								}
							}
							if (num149 >= 0 && WorldGen.PlaceWire2(i2, j2))
							{
								inventory[num149].stack--;
								if (inventory[num149].stack <= 0)
								{
									inventory[num149].SetDefaults(0);
								}
								itemTime = inventory[selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 10, tileTargetX, tileTargetY);
							}
						}
						if (inventory[selectedItem].type == 851)
						{
							int num151 = -1;
							for (int num152 = 0; num152 < 58; num152++)
							{
								if (inventory[num152].stack > 0 && inventory[num152].type == 530)
								{
									num151 = num152;
									break;
								}
							}
							if (num151 >= 0 && WorldGen.PlaceWire3(i2, j2))
							{
								inventory[num151].stack--;
								if (inventory[num151].stack <= 0)
								{
									inventory[num151].SetDefaults(0);
								}
								itemTime = inventory[selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 12, tileTargetX, tileTargetY);
							}
						}
						else if (inventory[selectedItem].type == 510)
						{
							if (WorldGen.KillActuator(i2, j2))
							{
								itemTime = inventory[selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 9, tileTargetX, tileTargetY);
							}
							else if (WorldGen.KillWire3(i2, j2))
							{
								itemTime = inventory[selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 13, tileTargetX, tileTargetY);
							}
							else if (WorldGen.KillWire2(i2, j2))
							{
								itemTime = inventory[selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 11, tileTargetX, tileTargetY);
							}
							else if (WorldGen.KillWire(i2, j2))
							{
								itemTime = inventory[selectedItem].useTime;
								NetMessage.SendData(17, -1, -1, "", 6, tileTargetX, tileTargetY);
							}
						}
						else if (inventory[selectedItem].type == 849 && inventory[selectedItem].stack > 0 && WorldGen.PlaceActuator(i2, j2))
						{
							itemTime = inventory[selectedItem].useTime;
							NetMessage.SendData(17, -1, -1, "", 8, tileTargetX, tileTargetY);
							inventory[selectedItem].stack--;
							if (inventory[selectedItem].stack <= 0)
							{
								inventory[selectedItem].SetDefaults(0);
							}
						}
					}
				}
				if (itemAnimation > 0 && itemTime == 0 && (inventory[selectedItem].type == 507 || inventory[selectedItem].type == 508))
				{
					itemTime = inventory[selectedItem].useTime;
					Vector2 vector3 = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
					float num153 = (float)Main.mouseX + Main.screenPosition.X - vector3.X;
					float num154 = (float)Main.mouseY + Main.screenPosition.Y - vector3.Y;
					float num155 = (float)Math.Sqrt(num153 * num153 + num154 * num154);
					num155 /= (float)(Main.screenHeight / 2);
					if (num155 > 1f)
					{
						num155 = 1f;
					}
					num155 = num155 * 2f - 1f;
					if (num155 < -1f)
					{
						num155 = -1f;
					}
					if (num155 > 1f)
					{
						num155 = 1f;
					}
					Main.harpNote = num155;
					int style = 26;
					if (inventory[selectedItem].type == 507)
					{
						style = 35;
					}
					Main.PlaySound(2, (int)position.X, (int)position.Y, style);
					NetMessage.SendData(58, -1, -1, "", whoAmi, num155);
				}
				if (((inventory[selectedItem].type >= 205 && inventory[selectedItem].type <= 207) || inventory[selectedItem].type == 1128) && position.X / 16f - (float)tileRangeX - (float)inventory[selectedItem].tileBoost <= (float)tileTargetX && (position.X + (float)width) / 16f + (float)tileRangeX + (float)inventory[selectedItem].tileBoost - 1f >= (float)tileTargetX && position.Y / 16f - (float)tileRangeY - (float)inventory[selectedItem].tileBoost <= (float)tileTargetY && (position.Y + (float)height) / 16f + (float)tileRangeY + (float)inventory[selectedItem].tileBoost - 2f >= (float)tileTargetY)
				{
					showItemIcon = true;
					if (itemTime == 0 && itemAnimation > 0 && controlUseItem)
					{
						if (inventory[selectedItem].type == 205)
						{
							int num156 = Main.tile[tileTargetX, tileTargetY].liquidType();
							int num157 = 0;
							for (int num158 = tileTargetX - 1; num158 <= tileTargetX + 1; num158++)
							{
								for (int num159 = tileTargetY - 1; num159 <= tileTargetY + 1; num159++)
								{
									if (Main.tile[num158, num159].liquidType() == num156)
									{
										num157 += Main.tile[num158, num159].liquid;
									}
								}
							}
							if (Main.tile[tileTargetX, tileTargetY].liquid > 0 && num157 > 100)
							{
								int liquidType = Main.tile[tileTargetX, tileTargetY].liquidType();
								if (!Main.tile[tileTargetX, tileTargetY].lava())
								{
									if (Main.tile[tileTargetX, tileTargetY].honey())
									{
										inventory[selectedItem].stack--;
										PutItemInInventory(1128, selectedItem);
									}
									else
									{
										inventory[selectedItem].stack--;
										PutItemInInventory(206, selectedItem);
									}
								}
								else
								{
									inventory[selectedItem].stack--;
									PutItemInInventory(207, selectedItem);
								}
								Main.PlaySound(19, (int)position.X, (int)position.Y);
								itemTime = inventory[selectedItem].useTime;
								int num160 = Main.tile[tileTargetX, tileTargetY].liquid;
								Main.tile[tileTargetX, tileTargetY].liquid = 0;
								Main.tile[tileTargetX, tileTargetY].lava(false);
								Main.tile[tileTargetX, tileTargetY].honey(false);
								WorldGen.SquareTileFrame(tileTargetX, tileTargetY, false);
								if (Main.netMode == 1)
								{
									NetMessage.sendWater(tileTargetX, tileTargetY);
								}
								else
								{
									Liquid.AddWater(tileTargetX, tileTargetY);
								}
								for (int num161 = tileTargetX - 1; num161 <= tileTargetX + 1; num161++)
								{
									for (int num162 = tileTargetY - 1; num162 <= tileTargetY + 1; num162++)
									{
										if (num160 < 256 && Main.tile[num161, num162].liquidType() == num156)
										{
											int num163 = Main.tile[num161, num162].liquid;
											if (num163 + num160 > 255)
											{
												num163 = 255 - num160;
											}
											num160 += num163;
											Main.tile[num161, num162].liquid -= (byte)num163;
											Main.tile[num161, num162].liquidType(liquidType);
											if (Main.tile[num161, num162].liquid == 0)
											{
												Main.tile[num161, num162].lava(false);
												Main.tile[num161, num162].honey(false);
											}
											WorldGen.SquareTileFrame(num161, num162, false);
											if (Main.netMode == 1)
											{
												NetMessage.sendWater(num161, num162);
											}
											else
											{
												Liquid.AddWater(num161, num162);
											}
										}
									}
								}
							}
						}
						else if (Main.tile[tileTargetX, tileTargetY].liquid < 200 && (!Main.tile[tileTargetX, tileTargetY].nactive() || !Main.tileSolid[Main.tile[tileTargetX, tileTargetY].type] || Main.tileSolidTop[Main.tile[tileTargetX, tileTargetY].type]))
						{
							if (inventory[selectedItem].type == 207)
							{
								if (Main.tile[tileTargetX, tileTargetY].liquid == 0 || Main.tile[tileTargetX, tileTargetY].liquidType() == 1)
								{
									Main.PlaySound(19, (int)position.X, (int)position.Y);
									Main.tile[tileTargetX, tileTargetY].liquidType(1);
									Main.tile[tileTargetX, tileTargetY].liquid = byte.MaxValue;
									WorldGen.SquareTileFrame(tileTargetX, tileTargetY);
									inventory[selectedItem].stack--;
									PutItemInInventory(205, selectedItem);
									itemTime = inventory[selectedItem].useTime;
									if (Main.netMode == 1)
									{
										NetMessage.sendWater(tileTargetX, tileTargetY);
									}
								}
							}
							else if (inventory[selectedItem].type == 206)
							{
								if (Main.tile[tileTargetX, tileTargetY].liquid == 0 || Main.tile[tileTargetX, tileTargetY].liquidType() == 0)
								{
									Main.PlaySound(19, (int)position.X, (int)position.Y);
									Main.tile[tileTargetX, tileTargetY].liquidType(0);
									Main.tile[tileTargetX, tileTargetY].liquid = byte.MaxValue;
									WorldGen.SquareTileFrame(tileTargetX, tileTargetY);
									inventory[selectedItem].stack--;
									PutItemInInventory(205, selectedItem);
									itemTime = inventory[selectedItem].useTime;
									if (Main.netMode == 1)
									{
										NetMessage.sendWater(tileTargetX, tileTargetY);
									}
								}
							}
							else if (inventory[selectedItem].type == 1128 && (Main.tile[tileTargetX, tileTargetY].liquid == 0 || Main.tile[tileTargetX, tileTargetY].liquidType() == 2))
							{
								Main.PlaySound(19, (int)position.X, (int)position.Y);
								Main.tile[tileTargetX, tileTargetY].liquidType(2);
								Main.tile[tileTargetX, tileTargetY].liquid = byte.MaxValue;
								WorldGen.SquareTileFrame(tileTargetX, tileTargetY);
								inventory[selectedItem].stack--;
								PutItemInInventory(205, selectedItem);
								itemTime = inventory[selectedItem].useTime;
								if (Main.netMode == 1)
								{
									NetMessage.sendWater(tileTargetX, tileTargetY);
								}
							}
						}
					}
				}
				if (!channel)
				{
					toolTime = itemTime;
				}
				else
				{
					toolTime--;
					if (toolTime < 0)
					{
						if (inventory[selectedItem].pick > 0)
						{
							toolTime = inventory[selectedItem].useTime;
						}
						else
						{
							toolTime = (int)((float)inventory[selectedItem].useTime * pickSpeed);
						}
					}
				}
				if ((inventory[selectedItem].pick > 0 || inventory[selectedItem].axe > 0 || inventory[selectedItem].hammer > 0) && position.X / 16f - (float)tileRangeX - (float)inventory[selectedItem].tileBoost <= (float)tileTargetX && (position.X + (float)width) / 16f + (float)tileRangeX + (float)inventory[selectedItem].tileBoost - 1f >= (float)tileTargetX && position.Y / 16f - (float)tileRangeY - (float)inventory[selectedItem].tileBoost <= (float)tileTargetY && (position.Y + (float)height) / 16f + (float)tileRangeY + (float)inventory[selectedItem].tileBoost - 2f >= (float)tileTargetY)
				{
					int num164 = -1;
					int num165 = 0;
					bool flag10 = true;
					showItemIcon = true;
					if (toolTime == 0 && itemAnimation > 0 && controlUseItem && (!Main.tile[tileTargetX, tileTargetY].active() || (!Main.tileHammer[Main.tile[tileTargetX, tileTargetY].type] && !Main.tileSolid[Main.tile[tileTargetX, tileTargetY].type] && Main.tile[tileTargetX, tileTargetY].type != 314)))
					{
						poundRelease = false;
					}
					if (Main.tile[tileTargetX, tileTargetY].active())
					{
						if ((inventory[selectedItem].pick > 0 && !Main.tileAxe[Main.tile[tileTargetX, tileTargetY].type] && !Main.tileHammer[Main.tile[tileTargetX, tileTargetY].type]) || (inventory[selectedItem].axe > 0 && Main.tileAxe[Main.tile[tileTargetX, tileTargetY].type]) || (inventory[selectedItem].hammer > 0 && Main.tileHammer[Main.tile[tileTargetX, tileTargetY].type]))
						{
							flag10 = false;
						}
						if (toolTime == 0 && itemAnimation > 0 && controlUseItem)
						{
							num164 = hitTile.HitObject(tileTargetX, tileTargetY, 1);
							if (Main.tileNoFail[Main.tile[tileTargetX, tileTargetY].type])
							{
								num165 = 100;
							}
							if (Main.tileHammer[Main.tile[tileTargetX, tileTargetY].type])
							{
								flag10 = false;
								if (inventory[selectedItem].hammer > 0)
								{
									num165 += inventory[selectedItem].hammer;
									if (Main.tile[tileTargetX, tileTargetY].type == 26 && (inventory[selectedItem].hammer < 80 || !Main.hardMode))
									{
										num165 = 0;
										Hurt(statLife / 2, -direction, false, false, Lang.deathMsg(-1, -1, -1, 4));
									}
									if (hitTile.AddDamage(num164, num165) >= 100)
									{
										hitTile.Clear(num164);
										WorldGen.KillTile(tileTargetX, tileTargetY);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, tileTargetX, tileTargetY);
										}
									}
									else
									{
										WorldGen.KillTile(tileTargetX, tileTargetY, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, tileTargetX, tileTargetY, 1f);
										}
									}
									if (num165 != 0)
									{
										hitTile.Prune();
									}
									itemTime = inventory[selectedItem].useTime;
								}
							}
							else if (Main.tileAxe[Main.tile[tileTargetX, tileTargetY].type])
							{
								num165 = ((Main.tile[tileTargetX, tileTargetY].type != 80) ? (num165 + inventory[selectedItem].axe) : (num165 + inventory[selectedItem].axe * 3));
								if (inventory[selectedItem].axe > 0)
								{
									if (hitTile.AddDamage(num164, num165) >= 100)
									{
										hitTile.Clear(num164);
										WorldGen.KillTile(tileTargetX, tileTargetY);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, tileTargetX, tileTargetY);
										}
									}
									else
									{
										WorldGen.KillTile(tileTargetX, tileTargetY, true);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, tileTargetX, tileTargetY, 1f);
										}
									}
									if (num165 != 0)
									{
										hitTile.Prune();
									}
									itemTime = inventory[selectedItem].useTime;
								}
							}
							else if (inventory[selectedItem].pick > 0)
							{
								num165 = ((!Main.tileDungeon[Main.tile[tileTargetX, tileTargetY].type] && Main.tile[tileTargetX, tileTargetY].type != 25 && Main.tile[tileTargetX, tileTargetY].type != 58 && Main.tile[tileTargetX, tileTargetY].type != 117 && Main.tile[tileTargetX, tileTargetY].type != 203) ? ((Main.tile[tileTargetX, tileTargetY].type != 48 && Main.tile[tileTargetX, tileTargetY].type != 232) ? ((Main.tile[tileTargetX, tileTargetY].type == 226) ? (num165 + inventory[selectedItem].pick / 4) : ((Main.tile[tileTargetX, tileTargetY].type != 107 && Main.tile[tileTargetX, tileTargetY].type != 221) ? ((Main.tile[tileTargetX, tileTargetY].type != 108 && Main.tile[tileTargetX, tileTargetY].type != 222) ? ((Main.tile[tileTargetX, tileTargetY].type == 111 || Main.tile[tileTargetX, tileTargetY].type == 223) ? (num165 + inventory[selectedItem].pick / 4) : ((Main.tile[tileTargetX, tileTargetY].type != 211) ? (num165 + inventory[selectedItem].pick) : (num165 + inventory[selectedItem].pick / 5))) : (num165 + inventory[selectedItem].pick / 3)) : (num165 + inventory[selectedItem].pick / 2))) : (num165 + inventory[selectedItem].pick / 4)) : (num165 + inventory[selectedItem].pick / 2));
								if (Main.tile[tileTargetX, tileTargetY].type == 211 && inventory[selectedItem].pick < 200)
								{
									num165 = 0;
								}
								if ((Main.tile[tileTargetX, tileTargetY].type == 25 || Main.tile[tileTargetX, tileTargetY].type == 203) && inventory[selectedItem].pick < 65)
								{
									num165 = 0;
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 117 && inventory[selectedItem].pick < 65)
								{
									num165 = 0;
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 37 && inventory[selectedItem].pick < 50)
								{
									num165 = 0;
								}
								else if ((Main.tile[tileTargetX, tileTargetY].type == 22 || Main.tile[tileTargetX, tileTargetY].type == 204) && (double)tileTargetY > Main.worldSurface && inventory[selectedItem].pick < 55)
								{
									num165 = 0;
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 56 && inventory[selectedItem].pick < 65)
								{
									num165 = 0;
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 58 && inventory[selectedItem].pick < 65)
								{
									num165 = 0;
								}
								else if ((Main.tile[tileTargetX, tileTargetY].type == 226 || Main.tile[tileTargetX, tileTargetY].type == 237) && inventory[selectedItem].pick < 210)
								{
									num165 = 0;
								}
								else if (Main.tileDungeon[Main.tile[tileTargetX, tileTargetY].type] && inventory[selectedItem].pick < 65)
								{
									if ((double)tileTargetX < (double)Main.maxTilesX * 0.35 || (double)tileTargetX > (double)Main.maxTilesX * 0.65)
									{
										num165 = 0;
									}
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 107 && inventory[selectedItem].pick < 100)
								{
									num165 = 0;
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 108 && inventory[selectedItem].pick < 110)
								{
									num165 = 0;
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 111 && inventory[selectedItem].pick < 150)
								{
									num165 = 0;
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 221 && inventory[selectedItem].pick < 100)
								{
									num165 = 0;
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 222 && inventory[selectedItem].pick < 110)
								{
									num165 = 0;
								}
								else if (Main.tile[tileTargetX, tileTargetY].type == 223 && inventory[selectedItem].pick < 150)
								{
									num165 = 0;
								}
								if (Main.tile[tileTargetX, tileTargetY].type == 147 || Main.tile[tileTargetX, tileTargetY].type == 0 || Main.tile[tileTargetX, tileTargetY].type == 40 || Main.tile[tileTargetX, tileTargetY].type == 53 || Main.tile[tileTargetX, tileTargetY].type == 57 || Main.tile[tileTargetX, tileTargetY].type == 59 || Main.tile[tileTargetX, tileTargetY].type == 123 || Main.tile[tileTargetX, tileTargetY].type == 224)
								{
									num165 += inventory[selectedItem].pick;
								}
								if (Main.tile[tileTargetX, tileTargetY].type == 165 || Main.tileRope[Main.tile[tileTargetX, tileTargetY].type] || Main.tile[tileTargetX, tileTargetY].type == 199 || Main.tileMoss[Main.tile[tileTargetX, tileTargetY].type])
								{
									num165 = 100;
								}
								if (hitTile.AddDamage(num164, num165, false) >= 100 && (Main.tile[tileTargetX, tileTargetY].type == 2 || Main.tile[tileTargetX, tileTargetY].type == 23 || Main.tile[tileTargetX, tileTargetY].type == 60 || Main.tile[tileTargetX, tileTargetY].type == 70 || Main.tile[tileTargetX, tileTargetY].type == 109 || Main.tile[tileTargetX, tileTargetY].type == 71 || Main.tile[tileTargetX, tileTargetY].type == 199 || Main.tileMoss[Main.tile[tileTargetX, tileTargetY].type]))
								{
									num165 = 0;
								}
								if (Main.tile[tileTargetX, tileTargetY].type == 128 || Main.tile[tileTargetX, tileTargetY].type == 269)
								{
									if (Main.tile[tileTargetX, tileTargetY].frameX == 18 || Main.tile[tileTargetX, tileTargetY].frameX == 54)
									{
										tileTargetX--;
										hitTile.UpdatePosition(num164, tileTargetX, tileTargetY);
									}
									if (Main.tile[tileTargetX, tileTargetY].frameX >= 100)
									{
										num165 = 0;
										Main.blockMouse = true;
									}
								}
								if (Main.tile[tileTargetX, tileTargetY].type == 334)
								{
									if (Main.tile[tileTargetX, tileTargetY].frameY == 0)
									{
										tileTargetY++;
										hitTile.UpdatePosition(num164, tileTargetX, tileTargetY);
									}
									if (Main.tile[tileTargetX, tileTargetY].frameY == 36)
									{
										tileTargetY--;
										hitTile.UpdatePosition(num164, tileTargetX, tileTargetY);
									}
									int frameX = Main.tile[tileTargetX, tileTargetY].frameX;
									bool flag11 = frameX >= 5000;
									bool flag12 = false;
									if (!flag11)
									{
										int num166 = frameX / 18;
										num166 %= 3;
										tileTargetX -= num166;
										if (Main.tile[tileTargetX, tileTargetY].frameX >= 5000)
										{
											flag11 = true;
										}
									}
									if (flag11)
									{
										frameX = Main.tile[tileTargetX, tileTargetY].frameX;
										int num167 = 0;
										while (frameX >= 5000)
										{
											frameX -= 5000;
											num167++;
										}
										if (num167 != 0)
										{
											flag12 = true;
										}
									}
									if (flag12)
									{
										num165 = 0;
										Main.blockMouse = true;
									}
								}
								if (hitTile.AddDamage(num164, num165) >= 100)
								{
									hitTile.Clear(num164);
									if (Main.netMode == 1 && Main.tile[tileTargetX, tileTargetY].type == 21)
									{
										WorldGen.KillTile(tileTargetX, tileTargetY, true);
										NetMessage.SendData(17, -1, -1, "", 0, tileTargetX, tileTargetY, 1f);
										NetMessage.SendData(34, -1, -1, "", 1, tileTargetX, tileTargetY);
									}
									else
									{
										int num168 = tileTargetY;
										WorldGen.KillTile(tileTargetX, num168);
										if (Main.netMode == 1)
										{
											NetMessage.SendData(17, -1, -1, "", 0, tileTargetX, num168);
										}
									}
								}
								else
								{
									WorldGen.KillTile(tileTargetX, tileTargetY, true);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 0, tileTargetX, tileTargetY, 1f);
									}
								}
								if (num165 != 0)
								{
									hitTile.Prune();
								}
								itemTime = (int)((float)inventory[selectedItem].useTime * pickSpeed);
							}
							if (inventory[selectedItem].hammer > 0 && Main.tile[tileTargetX, tileTargetY].active() && ((Main.tileSolid[Main.tile[tileTargetX, tileTargetY].type] && Main.tile[tileTargetX, tileTargetY].type != 10) || Main.tile[tileTargetX, tileTargetY].type == 314) && poundRelease)
							{
								flag10 = false;
								itemTime = inventory[selectedItem].useTime;
								num165 += (int)((double)inventory[selectedItem].hammer * 1.25);
								num165 = 100;
								if (Main.tile[tileTargetX, tileTargetY - 1].active() && Main.tile[tileTargetX, tileTargetY - 1].type == 10)
								{
									num165 = 0;
								}
								if (Main.tile[tileTargetX, tileTargetY + 1].active() && Main.tile[tileTargetX, tileTargetY + 1].type == 10)
								{
									num165 = 0;
								}
								if (hitTile.AddDamage(num164, num165) >= 100)
								{
									hitTile.Clear(num164);
									if (poundRelease)
									{
										int num169 = tileTargetX;
										int num170 = tileTargetY;
										if (Main.tile[num169, num170].type == 19)
										{
											if (Main.tile[num169, num170].halfBrick())
											{
												WorldGen.PoundTile(num169, num170);
												if (Main.netMode == 1)
												{
													NetMessage.SendData(17, -1, -1, "", 7, tileTargetX, tileTargetY, 1f);
												}
											}
											else
											{
												int num171 = 1;
												int slope = 2;
												if (Main.tile[num169 + 1, num170 - 1].type == 19 || Main.tile[num169 - 1, num170 + 1].type == 19 || (WorldGen.SolidTile(num169 + 1, num170) && !WorldGen.SolidTile(num169 - 1, num170)))
												{
													num171 = 2;
													slope = 1;
												}
												if (Main.tile[num169, num170].slope() == 0)
												{
													WorldGen.SlopeTile(num169, num170, num171);
													int num172 = Main.tile[num169, num170].slope();
													if (Main.netMode == 1)
													{
														NetMessage.SendData(17, -1, -1, "", 14, tileTargetX, tileTargetY, num172);
													}
												}
												else if (Main.tile[num169, num170].slope() == num171)
												{
													WorldGen.SlopeTile(num169, num170, slope);
													int num173 = Main.tile[num169, num170].slope();
													if (Main.netMode == 1)
													{
														NetMessage.SendData(17, -1, -1, "", 14, tileTargetX, tileTargetY, num173);
													}
												}
												else
												{
													WorldGen.SlopeTile(num169, num170);
													int num174 = Main.tile[num169, num170].slope();
													if (Main.netMode == 1)
													{
														NetMessage.SendData(17, -1, -1, "", 14, tileTargetX, tileTargetY, num174);
													}
													WorldGen.PoundTile(num169, num170);
													if (Main.netMode == 1)
													{
														NetMessage.SendData(17, -1, -1, "", 7, tileTargetX, tileTargetY, 1f);
													}
												}
											}
										}
										else if (Main.tile[num169, num170].type == 314)
										{
											if (Minecart.FrameTrack(num169, num170, true) && Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 15, tileTargetX, tileTargetY, 1f);
											}
										}
										else if ((Main.tile[num169, num170].halfBrick() || Main.tile[num169, num170].slope() != 0) && !Main.tileSolidTop[Main.tile[tileTargetX, tileTargetY].type])
										{
											int num175 = 1;
											int num176 = 1;
											int num177 = 2;
											if ((WorldGen.SolidTile(num169 + 1, num170) || Main.tile[num169 + 1, num170].slope() == 1 || Main.tile[num169 + 1, num170].slope() == 3) && !WorldGen.SolidTile(num169 - 1, num170))
											{
												num176 = 2;
												num177 = 1;
											}
											if (WorldGen.SolidTile(num169, num170 - 1) && !WorldGen.SolidTile(num169, num170 + 1))
											{
												num175 = -1;
											}
											if (num175 == 1)
											{
												if (Main.tile[num169, num170].slope() == 0)
												{
													WorldGen.SlopeTile(num169, num170, num176);
												}
												else if (Main.tile[num169, num170].slope() == num176)
												{
													WorldGen.SlopeTile(num169, num170, num177);
												}
												else if (Main.tile[num169, num170].slope() == num177)
												{
													WorldGen.SlopeTile(num169, num170, num176 + 2);
												}
												else if (Main.tile[num169, num170].slope() == num176 + 2)
												{
													WorldGen.SlopeTile(num169, num170, num177 + 2);
												}
												else
												{
													WorldGen.SlopeTile(num169, num170);
												}
											}
											else if (Main.tile[num169, num170].slope() == 0)
											{
												WorldGen.SlopeTile(num169, num170, num176 + 2);
											}
											else if (Main.tile[num169, num170].slope() == num176 + 2)
											{
												WorldGen.SlopeTile(num169, num170, num177 + 2);
											}
											else if (Main.tile[num169, num170].slope() == num177 + 2)
											{
												WorldGen.SlopeTile(num169, num170, num176);
											}
											else if (Main.tile[num169, num170].slope() == num176)
											{
												WorldGen.SlopeTile(num169, num170, num177);
											}
											else
											{
												WorldGen.SlopeTile(num169, num170);
											}
											int num178 = Main.tile[num169, num170].slope();
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 14, tileTargetX, tileTargetY, num178);
											}
										}
										else
										{
											WorldGen.PoundTile(num169, num170);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(17, -1, -1, "", 7, tileTargetX, tileTargetY, 1f);
											}
										}
										poundRelease = false;
									}
								}
								else
								{
									WorldGen.KillTile(tileTargetX, tileTargetY, true, true);
									Main.PlaySound(0, tileTargetX * 16, tileTargetY * 16);
								}
							}
							else
							{
								poundRelease = false;
							}
						}
					}
					if (releaseUseItem)
					{
						poundRelease = true;
					}
					int num179 = tileTargetX;
					int num180 = tileTargetY;
					bool flag13 = true;
					if (Main.tile[num179, num180].wall > 0)
					{
						if (!Main.wallHouse[Main.tile[num179, num180].wall])
						{
							for (int num181 = num179 - 1; num181 < num179 + 2; num181++)
							{
								for (int num182 = num180 - 1; num182 < num180 + 2; num182++)
								{
									if (Main.tile[num181, num182].wall != Main.tile[num179, num180].wall)
									{
										flag13 = false;
										break;
									}
								}
							}
						}
						else
						{
							flag13 = false;
						}
					}
					if (flag13 && !Main.tile[num179, num180].active())
					{
						int num183 = -1;
						if ((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f) < Math.Round(((float)Main.mouseX + Main.screenPosition.X) / 16f))
						{
							num183 = 0;
						}
						int num184 = -1;
						if ((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f) < Math.Round(((float)Main.mouseY + Main.screenPosition.Y) / 16f))
						{
							num184 = 0;
						}
						for (int num185 = tileTargetX + num183; num185 <= tileTargetX + num183 + 1; num185++)
						{
							for (int num186 = tileTargetY + num184; num186 <= tileTargetY + num184 + 1; num186++)
							{
								if (!flag13)
								{
									continue;
								}
								num179 = num185;
								num180 = num186;
								if (Main.tile[num179, num180].wall <= 0)
								{
									continue;
								}
								if (!Main.wallHouse[Main.tile[num179, num180].wall])
								{
									for (int num187 = num179 - 1; num187 < num179 + 2; num187++)
									{
										for (int num188 = num180 - 1; num188 < num180 + 2; num188++)
										{
											if (Main.tile[num187, num188].wall != Main.tile[num179, num180].wall)
											{
												flag13 = false;
												break;
											}
										}
									}
								}
								else
								{
									flag13 = false;
								}
							}
						}
					}
					if (flag10 && Main.tile[num179, num180].wall > 0 && (!Main.tile[num179, num180].active() || num179 != tileTargetX || num180 != tileTargetY || (!Main.tileHammer[Main.tile[num179, num180].type] && !poundRelease)) && toolTime == 0 && itemAnimation > 0 && controlUseItem && inventory[selectedItem].hammer > 0)
					{
						bool flag14 = true;
						if (!Main.wallHouse[Main.tile[num179, num180].wall])
						{
							flag14 = false;
							for (int num189 = num179 - 1; num189 < num179 + 2; num189++)
							{
								for (int num190 = num180 - 1; num190 < num180 + 2; num190++)
								{
									if (Main.tile[num189, num190].wall == 0 || Main.wallHouse[Main.tile[num189, num190].wall])
									{
										flag14 = true;
										break;
									}
								}
							}
						}
						if (flag14)
						{
							num164 = hitTile.HitObject(num179, num180, 2);
							num165 += (int)((float)inventory[selectedItem].hammer * 1.5f);
							if (hitTile.AddDamage(num164, num165) >= 100)
							{
								hitTile.Clear(num164);
								WorldGen.KillWall(num179, num180);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 2, num179, num180);
								}
							}
							else
							{
								WorldGen.KillWall(num179, num180, true);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(17, -1, -1, "", 2, num179, num180, 1f);
								}
							}
							if (num165 != 0)
							{
								hitTile.Prune();
							}
							itemTime = inventory[selectedItem].useTime / 2;
						}
					}
				}
				if (Main.myPlayer == whoAmi && inventory[selectedItem].type == 1326 && itemAnimation > 0 && itemTime == 0)
				{
					itemTime = inventory[selectedItem].useTime;
					Vector2 newPos = default(Vector2);
					newPos.X = (float)Main.mouseX + Main.screenPosition.X;
					if (gravDir == 1f)
					{
						newPos.Y = (float)Main.mouseY + Main.screenPosition.Y - (float)height;
					}
					else
					{
						newPos.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;
					}
					newPos.X -= width / 2;
					if (newPos.X > 50f && newPos.X < (float)(Main.maxTilesX * 16 - 50) && newPos.Y > 50f && newPos.Y < (float)(Main.maxTilesY * 16 - 50))
					{
						int num191 = (int)(newPos.X / 16f);
						int num192 = (int)(newPos.Y / 16f);
						if ((Main.tile[num191, num192].wall != 87 || !((double)num192 > Main.worldSurface) || NPC.downedPlantBoss) && !Collision.SolidCollision(newPos, width, height))
						{
							Teleport(newPos, 1);
							NetMessage.SendData(65, -1, -1, "", 0, whoAmi, newPos.X, newPos.Y, 1);
							if (chaosState)
							{
								statLife -= statLifeMax2 / 6;
								if (Lang.lang <= 1)
								{
									string deathText = " didn't materialize";
									if (Main.rand.Next(2) == 0)
									{
										deathText = ((!male) ? "'s legs appeared where her head should be" : "'s legs appeared where his head should be");
									}
									if (statLife <= 0)
									{
										KillMe(1.0, 0, false, deathText);
									}
								}
								else if (statLife <= 0)
								{
									KillMe(1.0, 0, false, "");
								}
								lifeRegenCount = 0;
								lifeRegenTime = 0;
							}
							AddBuff(88, 480);
						}
					}
				}
				if (inventory[selectedItem].type == 29 && itemAnimation > 0 && statLifeMax < 400 && itemTime == 0)
				{
					itemTime = inventory[selectedItem].useTime;
					statLifeMax += 20;
					statLifeMax2 += 20;
					statLife += 20;
					if (Main.myPlayer == whoAmi)
					{
						HealEffect(20);
					}
				}
				if (inventory[selectedItem].type == 1291 && itemAnimation > 0 && statLifeMax >= 400 && statLifeMax < 500 && itemTime == 0)
				{
					itemTime = inventory[selectedItem].useTime;
					statLifeMax += 5;
					statLifeMax2 += 5;
					statLife += 5;
					if (Main.myPlayer == whoAmi)
					{
						HealEffect(5);
					}
				}
				if (inventory[selectedItem].type == 109 && itemAnimation > 0 && statManaMax < 200 && itemTime == 0)
				{
					itemTime = inventory[selectedItem].useTime;
					statManaMax += 20;
					statManaMax2 += 20;
					statMana += 20;
					if (Main.myPlayer == whoAmi)
					{
						ManaEffect(20);
					}
				}
				PlaceThing();
			}
			if (((inventory[selectedItem].damage >= 0 && inventory[selectedItem].type > 0 && !inventory[selectedItem].noMelee) || inventory[selectedItem].type == 1450 || inventory[selectedItem].type == 1991) && itemAnimation > 0)
			{
				bool flag15 = false;
				Rectangle rectangle = new Rectangle((int)itemLocation.X, (int)itemLocation.Y, 32, 32);
				if (!Main.dedServ)
				{
					rectangle = new Rectangle((int)itemLocation.X, (int)itemLocation.Y, Main.itemTexture[inventory[selectedItem].type].Width, Main.itemTexture[inventory[selectedItem].type].Height);
				}
				rectangle.Width = (int)((float)rectangle.Width * inventory[selectedItem].scale);
				rectangle.Height = (int)((float)rectangle.Height * inventory[selectedItem].scale);
				if (direction == -1)
				{
					rectangle.X -= rectangle.Width;
				}
				if (gravDir == 1f)
				{
					rectangle.Y -= rectangle.Height;
				}
				if (inventory[selectedItem].useStyle == 1)
				{
					if ((double)itemAnimation < (double)itemAnimationMax * 0.333)
					{
						if (direction == -1)
						{
							rectangle.X -= (int)((double)rectangle.Width * 1.4 - (double)rectangle.Width);
						}
						rectangle.Width = (int)((double)rectangle.Width * 1.4);
						rectangle.Y += (int)((double)rectangle.Height * 0.5 * (double)gravDir);
						rectangle.Height = (int)((double)rectangle.Height * 1.1);
					}
					else if (!((double)itemAnimation < (double)itemAnimationMax * 0.666))
					{
						if (direction == 1)
						{
							rectangle.X -= (int)((double)rectangle.Width * 1.2);
						}
						rectangle.Width *= 2;
						rectangle.Y -= (int)(((double)rectangle.Height * 1.4 - (double)rectangle.Height) * (double)gravDir);
						rectangle.Height = (int)((double)rectangle.Height * 1.4);
					}
				}
				else if (inventory[selectedItem].useStyle == 3)
				{
					if ((double)itemAnimation > (double)itemAnimationMax * 0.666)
					{
						flag15 = true;
					}
					else
					{
						if (direction == -1)
						{
							rectangle.X -= (int)((double)rectangle.Width * 1.4 - (double)rectangle.Width);
						}
						rectangle.Width = (int)((double)rectangle.Width * 1.4);
						rectangle.Y += (int)((double)rectangle.Height * 0.6);
						rectangle.Height = (int)((double)rectangle.Height * 0.6);
					}
				}
				float gravDir2 = gravDir;
				float num257 = -1f;
				if (inventory[selectedItem].type == 1450 && Main.rand.Next(3) == 0)
				{
					int num193 = -1;
					float x5 = rectangle.X + Main.rand.Next(rectangle.Width);
					float y5 = rectangle.Y + Main.rand.Next(rectangle.Height);
					if (Main.rand.Next(500) == 0)
					{
						num193 = Gore.NewGore(new Vector2(x5, y5), default(Vector2), 415, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(250) == 0)
					{
						num193 = Gore.NewGore(new Vector2(x5, y5), default(Vector2), 414, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(80) == 0)
					{
						num193 = Gore.NewGore(new Vector2(x5, y5), default(Vector2), 413, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(10) == 0)
					{
						num193 = Gore.NewGore(new Vector2(x5, y5), default(Vector2), 412, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					else if (Main.rand.Next(3) == 0)
					{
						num193 = Gore.NewGore(new Vector2(x5, y5), default(Vector2), 411, (float)Main.rand.Next(51, 101) * 0.01f);
					}
					if (num193 >= 0)
					{
						Main.gore[num193].velocity.X += direction * 2;
						Main.gore[num193].velocity.Y *= 0.3f;
					}
				}
				if (!flag15)
				{
					if (inventory[selectedItem].type == 989 && Main.rand.Next(5) == 0)
					{
						int type4;
						switch (Main.rand.Next(3))
						{
						case 0:
							type4 = 15;
							break;
						case 1:
							type4 = 57;
							break;
						default:
							type4 = 58;
							break;
						}
						int num194 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, type4, direction * 2, 0f, 150, default(Color), 1.3f);
						Main.dust[num194].velocity *= 0.2f;
					}
					if ((inventory[selectedItem].type == 44 || inventory[selectedItem].type == 45 || inventory[selectedItem].type == 46 || inventory[selectedItem].type == 103 || inventory[selectedItem].type == 104) && Main.rand.Next(15) == 0)
					{
						Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 14, direction * 2, 0f, 150, default(Color), 1.3f);
					}
					if (inventory[selectedItem].type == 273 || inventory[selectedItem].type == 675)
					{
						if (Main.rand.Next(5) == 0)
						{
							Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 14, direction * 2, 0f, 150, default(Color), 1.4f);
						}
						int num195 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 27, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 1.2f);
						Main.dust[num195].noGravity = true;
						Main.dust[num195].velocity.X /= 2f;
						Main.dust[num195].velocity.Y /= 2f;
					}
					if (inventory[selectedItem].type == 723 && Main.rand.Next(2) == 0)
					{
						int num196 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 64, 0f, 0f, 150, default(Color), 1.2f);
						Main.dust[num196].noGravity = true;
					}
					if (inventory[selectedItem].type == 65)
					{
						if (Main.rand.Next(5) == 0)
						{
							Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 58, 0f, 0f, 150, default(Color), 1.2f);
						}
						if (Main.rand.Next(10) == 0)
						{
							Gore.NewGore(new Vector2(rectangle.X, rectangle.Y), default(Vector2), Main.rand.Next(16, 18));
						}
					}
					if (inventory[selectedItem].type == 190 || inventory[selectedItem].type == 213)
					{
						int num197 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 40, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 0, default(Color), 1.2f);
						Main.dust[num197].noGravity = true;
					}
					if (inventory[selectedItem].type == 121)
					{
						for (int num198 = 0; num198 < 2; num198++)
						{
							int num199 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 6, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 2.5f);
							Main.dust[num199].noGravity = true;
							Main.dust[num199].velocity.X *= 2f;
							Main.dust[num199].velocity.Y *= 2f;
						}
					}
					if (inventory[selectedItem].type == 122 || inventory[selectedItem].type == 217)
					{
						int num200 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 6, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 1.9f);
						Main.dust[num200].noGravity = true;
					}
					if (inventory[selectedItem].type == 155)
					{
						int num201 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 172, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 0.9f);
						Main.dust[num201].noGravity = true;
						Main.dust[num201].velocity *= 0.1f;
					}
					if (inventory[selectedItem].type == 676 && Main.rand.Next(3) == 0)
					{
						int num202 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 67, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 90, default(Color), 1.5f);
						Main.dust[num202].noGravity = true;
						Main.dust[num202].velocity *= 0.2f;
					}
					if (inventory[selectedItem].type == 724 && Main.rand.Next(5) == 0)
					{
						int num203 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 67, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 90, default(Color), 1.5f);
						Main.dust[num203].noGravity = true;
						Main.dust[num203].velocity *= 0.2f;
					}
					if (inventory[selectedItem].type >= 795 && inventory[selectedItem].type <= 802 && Main.rand.Next(3) == 0)
					{
						int num204 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 115, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 140, default(Color), 1.5f);
						Main.dust[num204].noGravity = true;
						Main.dust[num204].velocity *= 0.25f;
					}
					if (inventory[selectedItem].type == 367 || inventory[selectedItem].type == 368 || inventory[selectedItem].type == 674)
					{
						int num205 = 0;
						if (Main.rand.Next(3) == 0)
						{
							num205 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 57, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 1.1f);
							Main.dust[num205].noGravity = true;
							Main.dust[num205].velocity.X /= 2f;
							Main.dust[num205].velocity.Y /= 2f;
							Main.dust[num205].velocity.X += direction * 2;
						}
						if (Main.rand.Next(4) == 0)
						{
							num205 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 43, 0f, 0f, 254, default(Color), 0.3f);
							Main.dust[num205].velocity *= 0f;
						}
					}
					if (inventory[selectedItem].type >= 198 && inventory[selectedItem].type <= 203)
					{
						float num206 = 0.5f;
						float num207 = 0.5f;
						float num208 = 0.5f;
						if (inventory[selectedItem].type == 198)
						{
							num206 *= 0.1f;
							num207 *= 0.5f;
							num208 *= 1.2f;
						}
						else if (inventory[selectedItem].type == 199)
						{
							num206 *= 1f;
							num207 *= 0.2f;
							num208 *= 0.1f;
						}
						else if (inventory[selectedItem].type == 200)
						{
							num206 *= 0.1f;
							num207 *= 1f;
							num208 *= 0.2f;
						}
						else if (inventory[selectedItem].type == 201)
						{
							num206 *= 0.8f;
							num207 *= 0.1f;
							num208 *= 1f;
						}
						else if (inventory[selectedItem].type == 202)
						{
							num206 *= 0.8f;
							num207 *= 0.9f;
							num208 *= 1f;
						}
						else if (inventory[selectedItem].type == 203)
						{
							num206 *= 0.9f;
							num207 *= 0.9f;
							num208 *= 0.1f;
						}
						Lighting.addLight((int)((itemLocation.X + 6f + velocity.X) / 16f), (int)((itemLocation.Y - 14f) / 16f), num206, num207, num208);
					}
					if (frostBurn && inventory[selectedItem].melee && !inventory[selectedItem].noMelee && !inventory[selectedItem].noUseGraphic && Main.rand.Next(2) == 0)
					{
						int num209 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 135, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 2.5f);
						Main.dust[num209].noGravity = true;
						Main.dust[num209].velocity *= 0.7f;
						Main.dust[num209].velocity.Y -= 0.5f;
					}
					if (inventory[selectedItem].melee && !inventory[selectedItem].noMelee && !inventory[selectedItem].noUseGraphic && meleeEnchant > 0)
					{
						if (meleeEnchant == 1)
						{
							if (Main.rand.Next(3) == 0)
							{
								int num210 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 171, 0f, 0f, 100);
								Main.dust[num210].noGravity = true;
								Main.dust[num210].fadeIn = 1.5f;
								Main.dust[num210].velocity *= 0.25f;
							}
						}
						else if (meleeEnchant == 2)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num211 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 75, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 2.5f);
								Main.dust[num211].noGravity = true;
								Main.dust[num211].velocity *= 0.7f;
								Main.dust[num211].velocity.Y -= 0.5f;
							}
						}
						else if (meleeEnchant == 3)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num212 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 6, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 2.5f);
								Main.dust[num212].noGravity = true;
								Main.dust[num212].velocity *= 0.7f;
								Main.dust[num212].velocity.Y -= 0.5f;
							}
						}
						else if (meleeEnchant == 4)
						{
							int num213 = 0;
							if (Main.rand.Next(2) == 0)
							{
								num213 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 57, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 1.1f);
								Main.dust[num213].noGravity = true;
								Main.dust[num213].velocity.X /= 2f;
								Main.dust[num213].velocity.Y /= 2f;
							}
						}
						else if (meleeEnchant == 5)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num214 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 169, 0f, 0f, 100);
								Main.dust[num214].velocity.X += direction;
								Main.dust[num214].velocity.Y += 0.2f;
								Main.dust[num214].noGravity = true;
							}
						}
						else if (meleeEnchant == 6)
						{
							if (Main.rand.Next(2) == 0)
							{
								int num215 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 135, 0f, 0f, 100);
								Main.dust[num215].velocity.X += direction;
								Main.dust[num215].velocity.Y += 0.2f;
								Main.dust[num215].noGravity = true;
							}
						}
						else if (meleeEnchant == 7)
						{
							if (Main.rand.Next(20) == 0)
							{
								int type5 = Main.rand.Next(139, 143);
								int num216 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, type5, velocity.X, velocity.Y, 0, default(Color), 1.2f);
								Main.dust[num216].velocity.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.dust[num216].velocity.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.dust[num216].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
								Main.dust[num216].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
								Main.dust[num216].scale *= 1f + (float)Main.rand.Next(-30, 31) * 0.01f;
							}
							if (Main.rand.Next(40) == 0)
							{
								int type6 = Main.rand.Next(276, 283);
								int num217 = Gore.NewGore(new Vector2(rectangle.X, rectangle.Y), velocity, type6);
								Main.gore[num217].velocity.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.gore[num217].velocity.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
								Main.gore[num217].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
								Main.gore[num217].velocity.X += (float)Main.rand.Next(-50, 51) * 0.05f;
								Main.gore[num217].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.05f;
							}
						}
						else if (meleeEnchant == 8 && Main.rand.Next(4) == 0)
						{
							int num218 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 46, 0f, 0f, 100);
							Main.dust[num218].noGravity = true;
							Main.dust[num218].fadeIn = 1.5f;
							Main.dust[num218].velocity *= 0.25f;
						}
					}
					if (magmaStone && inventory[selectedItem].melee && !inventory[selectedItem].noMelee && !inventory[selectedItem].noUseGraphic && Main.rand.Next(3) != 0)
					{
						int num219 = Dust.NewDust(new Vector2(rectangle.X, rectangle.Y), rectangle.Width, rectangle.Height, 6, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 2.5f);
						Main.dust[num219].noGravity = true;
						Main.dust[num219].velocity.X *= 2f;
						Main.dust[num219].velocity.Y *= 2f;
					}
					if (Main.myPlayer == i && inventory[selectedItem].type == 1991)
					{
						for (int num220 = 0; num220 < 200; num220++)
						{
							if (Main.npc[num220].active && Main.npc[num220].catchItem > 0)
							{
								Rectangle value = new Rectangle((int)Main.npc[num220].position.X, (int)Main.npc[num220].position.Y, Main.npc[num220].width, Main.npc[num220].height);
								if (rectangle.Intersects(value) && (Main.npc[num220].noTileCollide || Collision.CanHit(position, width, height, Main.npc[num220].position, Main.npc[num220].width, Main.npc[num220].height)))
								{
									NPC.CatchNPC(num220, i);
								}
							}
						}
					}
					else if (Main.myPlayer == i && inventory[selectedItem].damage > 0)
					{
						int num221 = (int)((float)inventory[selectedItem].damage * meleeDamage);
						float knockBack = inventory[selectedItem].knockBack;
						float num222 = 1f;
						if (kbGlove)
						{
							num222 += 1f;
						}
						if (kbBuff)
						{
							num222 += 0.5f;
						}
						knockBack *= num222;
						int num223 = rectangle.X / 16;
						int num224 = (rectangle.X + rectangle.Width) / 16 + 1;
						int num225 = rectangle.Y / 16;
						int num226 = (rectangle.Y + rectangle.Height) / 16 + 1;
						for (int num227 = num223; num227 < num224; num227++)
						{
							for (int num228 = num225; num228 < num226; num228++)
							{
								if (Main.tile[num227, num228] == null || !Main.tileCut[Main.tile[num227, num228].type] || Main.tile[num227, num228 + 1] == null || Main.tile[num227, num228 + 1].type == 78)
								{
									continue;
								}
								if (inventory[selectedItem].type == 1786)
								{
									int type7 = Main.tile[num227, num228].type;
									WorldGen.KillTile(num227, num228);
									if (!Main.tile[num227, num228].active())
									{
										int num229 = 0;
										if (type7 == 3 || type7 == 24 || type7 == 61 || type7 == 110 || type7 == 201)
										{
											num229 = Main.rand.Next(1, 3);
										}
										if (type7 == 73 || type7 == 74 || type7 == 113)
										{
											num229 = Main.rand.Next(2, 5);
										}
										if (num229 > 0)
										{
											int number = Item.NewItem(num227 * 16, num228 * 16, 16, 16, 1727, num229);
											if (Main.netMode == 1)
											{
												NetMessage.SendData(21, -1, -1, "", number, 1f);
											}
										}
									}
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 0, num227, num228);
									}
								}
								else
								{
									WorldGen.KillTile(num227, num228);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(17, -1, -1, "", 0, num227, num228);
									}
								}
							}
						}
						for (int num230 = 0; num230 < 200; num230++)
						{
							if (!Main.npc[num230].active || Main.npc[num230].immune[i] != 0 || attackCD != 0 || Main.npc[num230].dontTakeDamage || (Main.npc[num230].friendly && (Main.npc[num230].type != 22 || !killGuide) && (Main.npc[num230].type != 54 || !killClothier)))
							{
								continue;
							}
							Rectangle value2 = new Rectangle((int)Main.npc[num230].position.X, (int)Main.npc[num230].position.Y, Main.npc[num230].width, Main.npc[num230].height);
							if (!rectangle.Intersects(value2) || (!Main.npc[num230].noTileCollide && !Collision.CanHit(position, width, height, Main.npc[num230].position, Main.npc[num230].width, Main.npc[num230].height)))
							{
								continue;
							}
							bool flag16 = false;
							if (Main.rand.Next(1, 101) <= meleeCrit)
							{
								flag16 = true;
							}
							int num231 = Main.DamageVar(num221);
							StatusNPC(inventory[selectedItem].type, num230);
							onHit(Main.npc[num230].center().X, Main.npc[num230].center().Y);
							int num232 = (int)Main.npc[num230].StrikeNPC(num231, knockBack, direction, flag16);
							if (beetleOffense)
							{
								beetleCounter += num232;
								beetleCountdown = 0;
							}
							if (inventory[selectedItem].type == 1826)
							{
								pumpkinSword(num230, (int)((double)num221 * 1.5), knockBack);
							}
							if (meleeEnchant == 7)
							{
								Projectile.NewProjectile(Main.npc[num230].center().X, Main.npc[num230].center().Y, Main.npc[num230].velocity.X, Main.npc[num230].velocity.Y, 289, 0, 0f, whoAmi);
							}
							if (inventory[selectedItem].type == 1123)
							{
								int num233 = Main.rand.Next(1, 4);
								for (int num234 = 0; num234 < num233; num234++)
								{
									float num235 = (float)(direction * 2) + (float)Main.rand.Next(-35, 36) * 0.02f;
									float num236 = (float)Main.rand.Next(-35, 36) * 0.02f;
									num235 *= 0.2f;
									num236 *= 0.2f;
									Projectile.NewProjectile(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2, num235, num236, 181, num231 / 3, 0f, i);
								}
							}
							if (Main.npc[num230].value > 0f && coins && Main.rand.Next(5) == 0)
							{
								int type8 = 71;
								if (Main.rand.Next(10) == 0)
								{
									type8 = 72;
								}
								if (Main.rand.Next(100) == 0)
								{
									type8 = 73;
								}
								int num237 = Item.NewItem((int)Main.npc[num230].position.X, (int)Main.npc[num230].position.Y, Main.npc[num230].width, Main.npc[num230].height, type8);
								Main.item[num237].stack = Main.rand.Next(1, 11);
								Main.item[num237].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
								Main.item[num237].velocity.X = (float)Main.rand.Next(10, 31) * 0.2f * (float)direction;
								if (Main.netMode == 1)
								{
									NetMessage.SendData(21, -1, -1, "", num237);
								}
							}
							if (Main.netMode != 0)
							{
								if (flag16)
								{
									NetMessage.SendData(28, -1, -1, "", num230, num231, knockBack, direction, 1);
								}
								else
								{
									NetMessage.SendData(28, -1, -1, "", num230, num231, knockBack, direction);
								}
							}
							Main.npc[num230].immune[i] = itemAnimation;
							attackCD = (int)((double)itemAnimationMax * 0.33);
						}
						if (hostile)
						{
							for (int num238 = 0; num238 < 255; num238++)
							{
								if (num238 == i || !Main.player[num238].active || !Main.player[num238].hostile || Main.player[num238].immune || Main.player[num238].dead || (Main.player[i].team != 0 && Main.player[i].team == Main.player[num238].team))
								{
									continue;
								}
								Rectangle value3 = new Rectangle((int)Main.player[num238].position.X, (int)Main.player[num238].position.Y, Main.player[num238].width, Main.player[num238].height);
								if (!rectangle.Intersects(value3) || !Collision.CanHit(position, width, height, Main.player[num238].position, Main.player[num238].width, Main.player[num238].height))
								{
									continue;
								}
								bool flag17 = false;
								if (Main.rand.Next(1, 101) <= 10)
								{
									flag17 = true;
								}
								int num239 = Main.DamageVar(num221);
								StatusPvP(inventory[selectedItem].type, num238);
								onHit(Main.player[num238].center().X, Main.player[num238].center().Y);
								Main.player[num238].Hurt(num239, direction, true, false, "", flag17);
								if (meleeEnchant == 7)
								{
									Projectile.NewProjectile(Main.player[num238].center().X, Main.player[num238].center().Y, Main.player[num238].velocity.X, Main.player[num238].velocity.Y, 289, 0, 0f, whoAmi);
								}
								if (inventory[selectedItem].type == 1123)
								{
									int num240 = Main.rand.Next(1, 4);
									for (int num241 = 0; num241 < num240; num241++)
									{
										float num242 = (float)(direction * 2) + (float)Main.rand.Next(-35, 36) * 0.02f;
										float num243 = (float)Main.rand.Next(-35, 36) * 0.02f;
										num242 *= 0.2f;
										num243 *= 0.2f;
										Projectile.NewProjectile(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2, num242, num243, 181, num239 / 3, 0f, i);
									}
								}
								if (Main.netMode != 0)
								{
									if (flag17)
									{
										NetMessage.SendData(26, -1, -1, Lang.deathMsg(whoAmi), num238, direction, num239, 1f, 1);
									}
									else
									{
										NetMessage.SendData(26, -1, -1, Lang.deathMsg(whoAmi), num238, direction, num239, 1f);
									}
								}
								attackCD = (int)((double)itemAnimationMax * 0.33);
							}
						}
						if (inventory[selectedItem].type == 787 && (itemAnimation == (int)((double)itemAnimationMax * 0.1) || itemAnimation == (int)((double)itemAnimationMax * 0.3) || itemAnimation == (int)((double)itemAnimationMax * 0.5) || itemAnimation == (int)((double)itemAnimationMax * 0.7) || itemAnimation == (int)((double)itemAnimationMax * 0.9)))
						{
							float num244 = 0f;
							float num245 = 0f;
							float num246 = 0f;
							float num247 = 0f;
							if (itemAnimation == (int)((double)itemAnimationMax * 0.9))
							{
								num244 = -7f;
							}
							if (itemAnimation == (int)((double)itemAnimationMax * 0.7))
							{
								num244 = -6f;
								num245 = 2f;
							}
							if (itemAnimation == (int)((double)itemAnimationMax * 0.5))
							{
								num244 = -4f;
								num245 = 4f;
							}
							if (itemAnimation == (int)((double)itemAnimationMax * 0.3))
							{
								num244 = -2f;
								num245 = 6f;
							}
							if (itemAnimation == (int)((double)itemAnimationMax * 0.1))
							{
								num245 = 7f;
							}
							if (itemAnimation == (int)((double)itemAnimationMax * 0.7))
							{
								num247 = 26f;
							}
							if (itemAnimation == (int)((double)itemAnimationMax * 0.3))
							{
								num247 -= 4f;
								num246 -= 20f;
							}
							if (itemAnimation == (int)((double)itemAnimationMax * 0.1))
							{
								num246 += 6f;
							}
							if (direction == -1)
							{
								if (itemAnimation == (int)((double)itemAnimationMax * 0.9))
								{
									num247 -= 8f;
								}
								if (itemAnimation == (int)((double)itemAnimationMax * 0.7))
								{
									num247 -= 6f;
								}
							}
							num244 *= 1.5f;
							num245 *= 1.5f;
							num247 *= (float)direction;
							num246 *= gravDir;
							Projectile.NewProjectile((float)(rectangle.X + rectangle.Width / 2) + num247, (float)(rectangle.Y + rectangle.Height / 2) + num246, (float)direction * num245, num244 * gravDir, 131, num221 / 2, 0f, i);
						}
					}
				}
			}
			if (itemTime == 0 && itemAnimation > 0)
			{
				if (inventory[selectedItem].hairDye >= 0)
				{
					itemTime = inventory[selectedItem].useTime;
					if (whoAmi == Main.myPlayer)
					{
						hairDye = (byte)inventory[selectedItem].hairDye;
						NetMessage.SendData(4, -1, -1, Main.player[whoAmi].name, whoAmi);
					}
				}
				if (inventory[selectedItem].healLife > 0)
				{
					statLife += inventory[selectedItem].healLife;
					itemTime = inventory[selectedItem].useTime;
					if (Main.myPlayer == whoAmi)
					{
						HealEffect(inventory[selectedItem].healLife);
					}
				}
				if (inventory[selectedItem].healMana > 0)
				{
					statMana += inventory[selectedItem].healMana;
					itemTime = inventory[selectedItem].useTime;
					if (Main.myPlayer == whoAmi)
					{
						AddBuff(94, manaSickTime);
						ManaEffect(inventory[selectedItem].healMana);
					}
				}
				if (inventory[selectedItem].buffType > 0)
				{
					if (whoAmi == Main.myPlayer && inventory[selectedItem].buffType != 90)
					{
						AddBuff(inventory[selectedItem].buffType, inventory[selectedItem].buffTime);
					}
					itemTime = inventory[selectedItem].useTime;
				}
				if (inventory[selectedItem].type == 678)
				{
					itemTime = inventory[selectedItem].useTime;
					if (whoAmi == Main.myPlayer)
					{
						AddBuff(20, 216000);
						AddBuff(22, 216000);
						AddBuff(23, 216000);
						AddBuff(24, 216000);
						AddBuff(30, 216000);
						AddBuff(31, 216000);
						AddBuff(32, 216000);
						AddBuff(33, 216000);
						AddBuff(35, 216000);
						AddBuff(36, 216000);
						AddBuff(68, 216000);
					}
				}
			}
			if (whoAmi == Main.myPlayer)
			{
				if (itemTime == 0 && itemAnimation > 0 && inventory[selectedItem].type == 361 && Main.CanStartInvasion(1, true))
				{
					itemTime = inventory[selectedItem].useTime;
					Main.PlaySound(15, (int)position.X, (int)position.Y, 0);
					if (Main.netMode != 1)
					{
						if (Main.invasionType == 0)
						{
							Main.invasionDelay = 0;
							Main.StartInvasion();
						}
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", whoAmi, -1f);
					}
				}
				if (itemTime == 0 && itemAnimation > 0 && inventory[selectedItem].type == 602 && Main.CanStartInvasion(2, true))
				{
					itemTime = inventory[selectedItem].useTime;
					Main.PlaySound(15, (int)position.X, (int)position.Y, 0);
					if (Main.netMode != 1)
					{
						if (Main.invasionType == 0)
						{
							Main.invasionDelay = 0;
							Main.StartInvasion(2);
						}
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", whoAmi, -2f);
					}
				}
				if (itemTime == 0 && itemAnimation > 0 && inventory[selectedItem].type == 1315 && Main.CanStartInvasion(3, true))
				{
					itemTime = inventory[selectedItem].useTime;
					Main.PlaySound(15, (int)position.X, (int)position.Y, 0);
					if (Main.netMode != 1)
					{
						if (Main.invasionType == 0)
						{
							Main.invasionDelay = 0;
							Main.StartInvasion(3);
						}
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", whoAmi, -3f);
					}
				}
				if (itemTime == 0 && itemAnimation > 0 && inventory[selectedItem].type == 1844 && !Main.dayTime && !Main.pumpkinMoon && !Main.snowMoon)
				{
					itemTime = inventory[selectedItem].useTime;
					Main.PlaySound(15, (int)position.X, (int)position.Y, 0);
					if (Main.netMode != 1)
					{
						Main.NewText(Lang.misc[31], 50, byte.MaxValue, 130);
						Main.startPumpkinMoon();
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", whoAmi, -4f);
					}
				}
				if (itemTime == 0 && itemAnimation > 0 && inventory[selectedItem].type == 1958 && !Main.dayTime && !Main.pumpkinMoon && !Main.snowMoon)
				{
					itemTime = inventory[selectedItem].useTime;
					Main.PlaySound(15, (int)position.X, (int)position.Y, 0);
					if (Main.netMode != 1)
					{
						Main.NewText(Lang.misc[34], 50, byte.MaxValue, 130);
						Main.startSnowMoon();
					}
					else
					{
						NetMessage.SendData(61, -1, -1, "", whoAmi, -5f);
					}
				}
				if (itemTime == 0 && itemAnimation > 0 && inventory[selectedItem].makeNPC > 0 && controlUseItem && position.X / 16f - (float)tileRangeX - (float)inventory[selectedItem].tileBoost <= (float)tileTargetX && (position.X + (float)width) / 16f + (float)tileRangeX + (float)inventory[selectedItem].tileBoost - 1f >= (float)tileTargetX && position.Y / 16f - (float)tileRangeY - (float)inventory[selectedItem].tileBoost <= (float)tileTargetY && (position.Y + (float)height) / 16f + (float)tileRangeY + (float)inventory[selectedItem].tileBoost - 2f >= (float)tileTargetY)
				{
					itemTime = inventory[selectedItem].useTime;
					int x6 = Main.mouseX + (int)Main.screenPosition.X;
					int y6 = Main.mouseY + (int)Main.screenPosition.Y;
					NPC.ReleaseNPC(x6, y6, inventory[selectedItem].makeNPC, inventory[selectedItem].placeStyle, whoAmi);
				}
				if (itemTime == 0 && itemAnimation > 0 && (inventory[selectedItem].type == 43 || inventory[selectedItem].type == 70 || inventory[selectedItem].type == 544 || inventory[selectedItem].type == 556 || inventory[selectedItem].type == 557 || inventory[selectedItem].type == 560 || inventory[selectedItem].type == 1133 || inventory[selectedItem].type == 1331) && SummonItemCheck())
				{
					if (inventory[selectedItem].type == 560)
					{
						itemTime = inventory[selectedItem].useTime;
						Main.PlaySound(15, (int)position.X, (int)position.Y, 0);
						if (Main.netMode != 1)
						{
							NPC.SpawnOnPlayer(i, 50);
						}
						else
						{
							NetMessage.SendData(61, -1, -1, "", whoAmi, 50f);
						}
					}
					else if (inventory[selectedItem].type == 43)
					{
						if (!Main.dayTime)
						{
							itemTime = inventory[selectedItem].useTime;
							Main.PlaySound(15, (int)position.X, (int)position.Y, 0);
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(i, 4);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", whoAmi, 4f);
							}
						}
					}
					else if (inventory[selectedItem].type == 70)
					{
						if (zoneEvil)
						{
							itemTime = inventory[selectedItem].useTime;
							Main.PlaySound(15, (int)position.X, (int)position.Y, 0);
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(i, 13);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", whoAmi, 13f);
							}
						}
					}
					else if (inventory[selectedItem].type == 544)
					{
						if (!Main.dayTime)
						{
							itemTime = inventory[selectedItem].useTime;
							Main.PlaySound(15, (int)position.X, (int)position.Y, 0);
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(i, 125);
								NPC.SpawnOnPlayer(i, 126);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", whoAmi, 125f);
								NetMessage.SendData(61, -1, -1, "", whoAmi, 126f);
							}
						}
					}
					else if (inventory[selectedItem].type == 556)
					{
						if (!Main.dayTime)
						{
							itemTime = inventory[selectedItem].useTime;
							Main.PlaySound(15, (int)position.X, (int)position.Y, 0);
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(i, 134);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", whoAmi, 134f);
							}
						}
					}
					else if (inventory[selectedItem].type == 557)
					{
						if (!Main.dayTime)
						{
							itemTime = inventory[selectedItem].useTime;
							Main.PlaySound(15, (int)position.X, (int)position.Y, 0);
							if (Main.netMode != 1)
							{
								NPC.SpawnOnPlayer(i, 127);
							}
							else
							{
								NetMessage.SendData(61, -1, -1, "", whoAmi, 127f);
							}
						}
					}
					else if (inventory[selectedItem].type == 1133)
					{
						itemTime = inventory[selectedItem].useTime;
						Main.PlaySound(15, (int)position.X, (int)position.Y, 0);
						if (Main.netMode != 1)
						{
							NPC.SpawnOnPlayer(i, 222);
						}
						else
						{
							NetMessage.SendData(61, -1, -1, "", whoAmi, 222f);
						}
					}
					else if (inventory[selectedItem].type == 1331 && zoneBlood)
					{
						itemTime = inventory[selectedItem].useTime;
						Main.PlaySound(15, (int)position.X, (int)position.Y, 0);
						if (Main.netMode != 1)
						{
							NPC.SpawnOnPlayer(i, 266);
						}
						else
						{
							NetMessage.SendData(61, -1, -1, "", whoAmi, 266f);
						}
					}
				}
			}
			if (inventory[selectedItem].type == 50 && itemAnimation > 0)
			{
				if (Main.rand.Next(2) == 0)
				{
					Dust.NewDust(position, width, height, 15, 0f, 0f, 150, default(Color), 1.1f);
				}
				if (itemTime == 0)
				{
					itemTime = inventory[selectedItem].useTime;
				}
				else if (itemTime == inventory[selectedItem].useTime / 2)
				{
					for (int num248 = 0; num248 < 70; num248++)
					{
						Dust.NewDust(position, width, height, 15, velocity.X * 0.5f, velocity.Y * 0.5f, 150, default(Color), 1.5f);
					}
					grappling[0] = -1;
					grapCount = 0;
					for (int num249 = 0; num249 < 1000; num249++)
					{
						if (Main.projectile[num249].active && Main.projectile[num249].owner == i && Main.projectile[num249].aiStyle == 7)
						{
							Main.projectile[num249].Kill();
						}
					}
					Spawn();
					for (int num250 = 0; num250 < 70; num250++)
					{
						Dust.NewDust(position, width, height, 15, 0f, 0f, 150, default(Color), 1.5f);
					}
				}
			}
			if (inventory[selectedItem].type == 2350 && itemAnimation > 0)
			{
				if (itemTime == 0)
				{
					itemTime = inventory[selectedItem].useTime;
				}
				else if (itemTime == 2)
				{
					for (int num251 = 0; num251 < 70; num251++)
					{
						Main.dust[Dust.NewDust(position, width, height, 15, velocity.X * 0.2f, velocity.Y * 0.2f, 150, Color.Cyan, 1.2f)].velocity *= 0.5f;
					}
					grappling[0] = -1;
					grapCount = 0;
					for (int num252 = 0; num252 < 1000; num252++)
					{
						if (Main.projectile[num252].active && Main.projectile[num252].owner == i && Main.projectile[num252].aiStyle == 7)
						{
							Main.projectile[num252].Kill();
						}
					}
					bool flag18 = immune;
					int num253 = immuneTime;
					Spawn();
					immune = flag18;
					immuneTime = num253;
					for (int num254 = 0; num254 < 70; num254++)
					{
						Main.dust[Dust.NewDust(position, width, height, 15, 0f, 0f, 150, Color.Cyan, 1.2f)].velocity *= 0.5f;
					}
					if (inventory[selectedItem].stack > 0)
					{
						inventory[selectedItem].stack--;
					}
				}
			}
			if (inventory[selectedItem].type == 2351 && itemAnimation > 0)
			{
				if (itemTime == 0)
				{
					itemTime = inventory[selectedItem].useTime;
				}
				else if (itemTime == 2)
				{
					if (Main.netMode == 0)
					{
						TeleportationPotion();
					}
					else if (Main.netMode == 1 && whoAmi == Main.myPlayer)
					{
						NetMessage.SendData(73);
					}
					if (inventory[selectedItem].stack > 0)
					{
						inventory[selectedItem].stack--;
					}
				}
			}
			if (i != Main.myPlayer)
			{
				return;
			}
			if (itemTime == (int)((float)inventory[selectedItem].useTime * tileSpeed) && inventory[selectedItem].tileWand > 0)
			{
				int tileWand2 = inventory[selectedItem].tileWand;
				for (int num255 = 0; num255 < 58; num255++)
				{
					if (tileWand2 == inventory[num255].type && inventory[num255].stack > 0)
					{
						inventory[num255].stack--;
						if (inventory[num255].stack <= 0)
						{
							inventory[num255] = new Item();
						}
						break;
					}
				}
			}
			int num256 = ((inventory[selectedItem].createTile >= 0) ? ((int)((float)inventory[selectedItem].useTime * tileSpeed)) : ((inventory[selectedItem].createWall <= 0) ? inventory[selectedItem].useTime : ((int)((float)inventory[selectedItem].useTime * wallSpeed))));
			if (itemTime == num256 && inventory[selectedItem].consumable)
			{
				bool flag19 = true;
				if (inventory[selectedItem].type == 2350 || inventory[selectedItem].type == 2351)
				{
					flag19 = false;
				}
				if (inventory[selectedItem].ranged)
				{
					if (ammoCost80 && Main.rand.Next(5) == 0)
					{
						flag19 = false;
					}
					if (ammoCost75 && Main.rand.Next(4) == 0)
					{
						flag19 = false;
					}
				}
				if (inventory[selectedItem].type >= 71 && inventory[selectedItem].type <= 74)
				{
					flag19 = true;
				}
				if (flag19)
				{
					if (inventory[selectedItem].stack > 0)
					{
						inventory[selectedItem].stack--;
					}
					if (inventory[selectedItem].stack <= 0)
					{
						itemTime = itemAnimation;
					}
				}
			}
			if (inventory[selectedItem].stack <= 0 && itemAnimation == 0)
			{
				inventory[selectedItem] = new Item();
			}
			if (selectedItem == 58 && itemAnimation != 0)
			{
				Main.mouseItem = inventory[selectedItem].Clone();
			}
		}

		public bool ItemFitsWeaponRack(Item i)
		{
			bool flag = false;
			if (i.fishingPole > 0)
			{
				flag = true;
			}
			int netID = i.netID;
			if (netID == 905 || netID == 1326)
			{
				flag = true;
			}
			if ((i.damage > 0 || flag) && i.useStyle > 0)
			{
				return i.stack > 0;
			}
			return false;
		}

		public void PlaceWeapon(int x, int y)
		{
			if (Main.tile[x, y].active() && Main.tile[x, y].type == 334)
			{
				int frameY = Main.tile[x, y].frameY;
				int num = 1;
				frameY /= 18;
				while (num > frameY)
				{
					y++;
					frameY = Main.tile[x, y].frameY;
					frameY /= 18;
				}
				while (num < frameY)
				{
					y--;
					frameY = Main.tile[x, y].frameY;
					frameY /= 18;
				}
				int num2 = Main.tile[x, y].frameX;
				int num3 = 0;
				while (num2 >= 5000)
				{
					num2 -= 5000;
					num3++;
				}
				if (num3 != 0)
				{
					num2 = (num3 - 1) * 18;
				}
				bool flag = false;
				if (num2 >= 54)
				{
					num2 -= 54;
					flag = true;
				}
				x -= num2 / 18;
				int num4 = Main.tile[x, y].frameX;
				WorldGen.KillTile(x, y, true);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(17, -1, -1, "", 0, x, y, 1f);
				}
				if (Main.netMode == 1)
				{
					NetMessage.SendData(17, -1, -1, "", 0, x + 1, y, 1f);
				}
				while (num4 >= 5000)
				{
					num4 -= 5000;
				}
				Main.blockMouse = true;
				int num5 = 5000;
				int num6 = 10000;
				if (flag)
				{
					num5 = 20000;
					num6 = 25000;
				}
				Main.tile[x, y].frameX = (short)(inventory[selectedItem].netID + num5 + 100);
				Main.tile[x + 1, y].frameX = (short)(inventory[selectedItem].prefix + num6);
				if (Main.netMode == 1)
				{
					NetMessage.SendTileSquare(-1, x, y, 1);
				}
				if (Main.netMode == 1)
				{
					NetMessage.SendTileSquare(-1, x + 1, y, 1);
				}
				inventory[selectedItem].stack--;
				if (inventory[selectedItem].stack <= 0)
				{
					inventory[selectedItem].SetDefaults(0);
					Main.mouseItem.SetDefaults(0);
				}
				if (selectedItem == 58)
				{
					Main.mouseItem = inventory[selectedItem].Clone();
				}
				releaseUseItem = false;
				mouseInterface = true;
			}
		}

		public Color GetImmuneAlpha(Color newColor, float alphaReduction)
		{
			float num = (float)(255 - immuneAlpha) / 255f;
			if (alphaReduction > 0f)
			{
				num *= 1f - alphaReduction;
			}
			if (immuneAlpha > 125)
			{
				return Color.Transparent;
			}
			return Color.Multiply(newColor, num);
		}

		public Color GetImmuneAlphaPure(Color newColor, float alphaReduction)
		{
			float num = (float)(255 - immuneAlpha) / 255f;
			if (alphaReduction > 0f)
			{
				num *= 1f - alphaReduction;
			}
			return Color.Multiply(newColor, num);
		}

		public Color GetDeathAlpha(Color newColor)
		{
			int r = newColor.R + (int)((double)immuneAlpha * 0.9);
			int g = newColor.G + (int)((double)immuneAlpha * 0.5);
			int b = newColor.B + (int)((double)immuneAlpha * 0.5);
			int num = newColor.A + (int)((double)immuneAlpha * 0.4);
			if (num < 0)
			{
				num = 0;
			}
			if (num > 255)
			{
				num = 255;
			}
			return new Color(r, g, b, num);
		}

		public void DropCoins()
		{
			for (int i = 0; i < 59; i++)
			{
				if (inventory[i].type >= 71 && inventory[i].type <= 74)
				{
					int num = Item.NewItem((int)position.X, (int)position.Y, width, height, inventory[i].type);
					int num2 = inventory[i].stack / 2;
					num2 = inventory[i].stack - num2;
					inventory[i].stack -= num2;
					if (inventory[i].stack <= 0)
					{
						inventory[i] = new Item();
					}
					Main.item[num].stack = num2;
					Main.item[num].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
					Main.item[num].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
					Main.item[num].noGrabDelay = 100;
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", num);
					}
					if (i == 58)
					{
						Main.mouseItem = inventory[i].Clone();
					}
				}
			}
		}

		public void DropItems()
		{
			for (int i = 0; i < 59; i++)
			{
				if (inventory[i].stack > 0 && inventory[i].name != "Copper Pickaxe" && inventory[i].name != "Copper Axe" && inventory[i].name != "Copper Shortsword")
				{
					int num = Item.NewItem((int)position.X, (int)position.Y, width, height, inventory[i].type);
					Main.item[num].netDefaults(inventory[i].netID);
					Main.item[num].Prefix(inventory[i].prefix);
					Main.item[num].stack = inventory[i].stack;
					Main.item[num].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
					Main.item[num].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
					Main.item[num].noGrabDelay = 100;
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", num);
					}
				}
				inventory[i] = new Item();
				if (i < 16)
				{
					if (armor[i].stack > 0)
					{
						int num2 = Item.NewItem((int)position.X, (int)position.Y, width, height, armor[i].type);
						Main.item[num2].netDefaults(armor[i].netID);
						Main.item[num2].Prefix(armor[i].prefix);
						Main.item[num2].stack = armor[i].stack;
						Main.item[num2].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						Main.item[num2].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num2].noGrabDelay = 100;
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, "", num2);
						}
					}
					armor[i] = new Item();
				}
				if (i >= 8)
				{
					continue;
				}
				if (dye[i].stack > 0)
				{
					int num3 = Item.NewItem((int)position.X, (int)position.Y, width, height, dye[i].type);
					Main.item[num3].netDefaults(dye[i].netID);
					Main.item[num3].Prefix(dye[i].prefix);
					Main.item[num3].stack = dye[i].stack;
					Main.item[num3].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
					Main.item[num3].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
					Main.item[num3].noGrabDelay = 100;
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", num3);
					}
				}
				dye[i] = new Item();
			}
			inventory[0].SetDefaults("Copper Shortsword");
			inventory[0].Prefix(-1);
			inventory[1].SetDefaults("Copper Pickaxe");
			inventory[1].Prefix(-1);
			inventory[2].SetDefaults("Copper Axe");
			inventory[2].Prefix(-1);
			Main.mouseItem = new Item();
		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public object clientClone()
		{
			Player player = new Player();
			player.zoneEvil = zoneEvil;
			player.zoneMeteor = zoneMeteor;
			player.zoneDungeon = zoneDungeon;
			player.zoneJungle = zoneJungle;
			player.zoneHoly = zoneHoly;
			player.zoneSnow = zoneSnow;
			player.zoneBlood = zoneBlood;
			player.zoneCandle = zoneCandle;
			player.direction = direction;
			player.selectedItem = selectedItem;
			player.controlUp = controlUp;
			player.controlDown = controlDown;
			player.controlLeft = controlLeft;
			player.controlRight = controlRight;
			player.controlJump = controlJump;
			player.controlUseItem = controlUseItem;
			player.statLife = statLife;
			player.statLifeMax = statLifeMax;
			player.statMana = statMana;
			player.statManaMax = statManaMax;
			player.position.X = position.X;
			player.chest = chest;
			player.talkNPC = talkNPC;
			player.hideVisual = hideVisual;
			for (int i = 0; i < 59; i++)
			{
				player.inventory[i] = inventory[i].Clone();
				if (i < 16)
				{
					player.armor[i] = armor[i].Clone();
				}
				if (i < 8)
				{
					player.dye[i] = dye[i].Clone();
				}
			}
			for (int j = 0; j < 22; j++)
			{
				player.buffType[j] = buffType[j];
				player.buffTime[j] = buffTime[j];
			}
			return player;
		}

		private static void EncryptFile(string inputFile, string outputFile)
		{
			string s = "h3y_gUyZ";
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			byte[] bytes = unicodeEncoding.GetBytes(s);
			FileStream fileStream = new FileStream(outputFile, FileMode.Create);
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
			FileStream fileStream2 = new FileStream(inputFile, FileMode.Open);
			int num;
			while ((num = fileStream2.ReadByte()) != -1)
			{
				cryptoStream.WriteByte((byte)num);
			}
			fileStream2.Close();
			cryptoStream.Close();
			fileStream.Close();
		}

		private static bool DecryptFile(string inputFile, string outputFile)
		{
			string s = "h3y_gUyZ";
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			byte[] bytes = unicodeEncoding.GetBytes(s);
			FileStream fileStream = new FileStream(inputFile, FileMode.Open);
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
			FileStream fileStream2 = new FileStream(outputFile, FileMode.Create);
			try
			{
				int num;
				while ((num = cryptoStream.ReadByte()) != -1)
				{
					fileStream2.WriteByte((byte)num);
				}
				fileStream2.Close();
				cryptoStream.Close();
				fileStream.Close();
			}
			catch
			{
				fileStream2.Close();
				fileStream.Close();
				File.Delete(outputFile);
				return true;
			}
			return false;
		}

		public static bool CheckSpawn(int x, int y)
		{
			if (x < 10 || x > Main.maxTilesX - 10 || y < 10 || y > Main.maxTilesX - 10)
			{
				return false;
			}
			if (Main.tile[x, y - 1] == null)
			{
				return false;
			}
			if (!Main.tile[x, y - 1].active() || Main.tile[x, y - 1].type != 79)
			{
				return false;
			}
			for (int i = x - 1; i <= x + 1; i++)
			{
				for (int j = y - 3; j < y; j++)
				{
					if (Main.tile[i, j] == null)
					{
						return false;
					}
					if (Main.tile[i, j].nactive() && Main.tileSolid[Main.tile[i, j].type] && !Main.tileSolidTop[Main.tile[i, j].type])
					{
						Main.NewText("There is not enough space", byte.MaxValue, 240, 20);
						return false;
					}
				}
			}
			if (!WorldGen.StartRoomCheck(x, y - 1))
			{
				return false;
			}
			return true;
		}

		public void FindSpawn()
		{
			for (int i = 0; i < 200; i++)
			{
				if (spN[i] == null)
				{
					SpawnX = -1;
					SpawnY = -1;
					break;
				}
				if (spN[i] == Main.worldName && spI[i] == Main.worldID)
				{
					SpawnX = spX[i];
					SpawnY = spY[i];
					break;
				}
			}
		}

		public void ChangeSpawn(int x, int y)
		{
			for (int i = 0; i < 200 && spN[i] != null; i++)
			{
				if (spN[i] == Main.worldName && spI[i] == Main.worldID)
				{
					for (int num = i; num > 0; num--)
					{
						spN[num] = spN[num - 1];
						spI[num] = spI[num - 1];
						spX[num] = spX[num - 1];
						spY[num] = spY[num - 1];
					}
					spN[0] = Main.worldName;
					spI[0] = Main.worldID;
					spX[0] = x;
					spY[0] = y;
					return;
				}
			}
			for (int num2 = 199; num2 > 0; num2--)
			{
				if (spN[num2 - 1] != null)
				{
					spN[num2] = spN[num2 - 1];
					spI[num2] = spI[num2 - 1];
					spX[num2] = spX[num2 - 1];
					spY[num2] = spY[num2 - 1];
				}
			}
			spN[0] = Main.worldName;
			spI[0] = Main.worldID;
			spX[0] = x;
			spY[0] = y;
		}

		public static void SavePlayer(Player newPlayer, string playerPath, bool skipMapSave = false, bool fileAlreadyDecrypted = false)
		{
			if (!skipMapSave)
			{
				try
				{
					if (Main.mapEnabled)
					{
						Map.saveMap();
					}
				}
				catch
				{
				}
				try
				{
					Directory.CreateDirectory(Main.PlayerPath);
				}
				catch
				{
				}
			}
			if (Main.ServerSideCharacter || playerPath == null || playerPath == "")
			{
				return;
			}
			string destFileName = playerPath + ".bak";
			if (File.Exists(playerPath))
			{
				File.Copy(playerPath, destFileName, true);
			}
			string text = playerPath + ".dat";
			using (FileStream output = new FileStream(text, FileMode.Create))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(output))
				{
					binaryWriter.Write(Main.curRelease);
					binaryWriter.Write(newPlayer.name);
					binaryWriter.Write(newPlayer.difficulty);
					binaryWriter.Write(newPlayer.hair);
					binaryWriter.Write(newPlayer.hairDye);
					binaryWriter.Write(newPlayer.hideVisual);
					binaryWriter.Write(newPlayer.male);
					binaryWriter.Write(newPlayer.statLife);
					binaryWriter.Write(newPlayer.statLifeMax);
					binaryWriter.Write(newPlayer.statMana);
					binaryWriter.Write(newPlayer.statManaMax);
					binaryWriter.Write(newPlayer.hairColor.R);
					binaryWriter.Write(newPlayer.hairColor.G);
					binaryWriter.Write(newPlayer.hairColor.B);
					binaryWriter.Write(newPlayer.skinColor.R);
					binaryWriter.Write(newPlayer.skinColor.G);
					binaryWriter.Write(newPlayer.skinColor.B);
					binaryWriter.Write(newPlayer.eyeColor.R);
					binaryWriter.Write(newPlayer.eyeColor.G);
					binaryWriter.Write(newPlayer.eyeColor.B);
					binaryWriter.Write(newPlayer.shirtColor.R);
					binaryWriter.Write(newPlayer.shirtColor.G);
					binaryWriter.Write(newPlayer.shirtColor.B);
					binaryWriter.Write(newPlayer.underShirtColor.R);
					binaryWriter.Write(newPlayer.underShirtColor.G);
					binaryWriter.Write(newPlayer.underShirtColor.B);
					binaryWriter.Write(newPlayer.pantsColor.R);
					binaryWriter.Write(newPlayer.pantsColor.G);
					binaryWriter.Write(newPlayer.pantsColor.B);
					binaryWriter.Write(newPlayer.shoeColor.R);
					binaryWriter.Write(newPlayer.shoeColor.G);
					binaryWriter.Write(newPlayer.shoeColor.B);
					for (int i = 0; i < 16; i++)
					{
						if (newPlayer.armor[i].name == null)
						{
							newPlayer.armor[i].name = "";
						}
						binaryWriter.Write(newPlayer.armor[i].netID);
						binaryWriter.Write(newPlayer.armor[i].prefix);
					}
					for (int j = 0; j < 8; j++)
					{
						binaryWriter.Write(newPlayer.dye[j].netID);
						binaryWriter.Write(newPlayer.dye[j].prefix);
					}
					for (int k = 0; k < 58; k++)
					{
						if (newPlayer.inventory[k].name == null)
						{
							newPlayer.inventory[k].name = "";
						}
						binaryWriter.Write(newPlayer.inventory[k].netID);
						binaryWriter.Write(newPlayer.inventory[k].stack);
						binaryWriter.Write(newPlayer.inventory[k].prefix);
					}
					for (int l = 0; l < Chest.maxItems; l++)
					{
						if (newPlayer.bank.item[l].name == null)
						{
							newPlayer.bank.item[l].name = "";
						}
						binaryWriter.Write(newPlayer.bank.item[l].netID);
						binaryWriter.Write(newPlayer.bank.item[l].stack);
						binaryWriter.Write(newPlayer.bank.item[l].prefix);
					}
					for (int m = 0; m < Chest.maxItems; m++)
					{
						if (newPlayer.bank2.item[m].name == null)
						{
							newPlayer.bank2.item[m].name = "";
						}
						binaryWriter.Write(newPlayer.bank2.item[m].netID);
						binaryWriter.Write(newPlayer.bank2.item[m].stack);
						binaryWriter.Write(newPlayer.bank2.item[m].prefix);
					}
					for (int n = 0; n < 22; n++)
					{
						if (Main.buffNoSave[newPlayer.buffType[n]])
						{
							binaryWriter.Write(0);
							binaryWriter.Write(0);
						}
						else
						{
							binaryWriter.Write(newPlayer.buffType[n]);
							binaryWriter.Write(newPlayer.buffTime[n]);
						}
					}
					for (int num = 0; num < 200; num++)
					{
						if (newPlayer.spN[num] == null)
						{
							binaryWriter.Write(-1);
							break;
						}
						binaryWriter.Write(newPlayer.spX[num]);
						binaryWriter.Write(newPlayer.spY[num]);
						binaryWriter.Write(newPlayer.spI[num]);
						binaryWriter.Write(newPlayer.spN[num]);
					}
					binaryWriter.Write(newPlayer.hbLocked);
					binaryWriter.Write(newPlayer.anglerQuestsFinished);
					binaryWriter.Close();
				}
			}
			EncryptFile(text, playerPath);
			File.Delete(text);
		}

		public static Player LoadPlayer(string playerPath, bool decryptedCopy = false)
		{
			if (Main.rand == null)
			{
				Main.rand = new Random((int)DateTime.Now.Ticks);
			}
			Player player = new Player();
			try
			{
				string text = playerPath + ".dat";
				if (!decryptedCopy && DecryptFile(playerPath, text))
				{
					using (FileStream fileStream = new FileStream(playerPath, FileMode.Open))
					{
						while (fileStream.Position < fileStream.Length && fileStream.ReadByte() == 0)
						{
						}
						if (fileStream.Position == fileStream.Length)
						{
							player.loadStatus = 3;
						}
						else
						{
							player.loadStatus = 4;
						}
						string[] array = playerPath.Split(Path.DirectorySeparatorChar);
						player.name = array[array.Length - 1].Split('.')[0];
						return player;
					}
				}
				using (FileStream input = new FileStream(text, FileMode.Open))
				{
					using (BinaryReader binaryReader = new BinaryReader(input))
					{
						int num = binaryReader.ReadInt32();
						if (num > Main.curRelease)
						{
							player.loadStatus = 1;
							player.name = binaryReader.ReadString();
							return player;
						}
						player.name = binaryReader.ReadString();
						if (num >= 10)
						{
							if (num >= 17)
							{
								player.difficulty = binaryReader.ReadByte();
							}
							else if (binaryReader.ReadBoolean())
							{
								player.difficulty = 2;
							}
						}
						player.hair = binaryReader.ReadInt32();
						if (num >= 82)
						{
							player.hairDye = binaryReader.ReadByte();
						}
						if (num >= 83)
						{
							player.hideVisual = binaryReader.ReadByte();
						}
						if (num <= 17)
						{
							if (player.hair == 5 || player.hair == 6 || player.hair == 9 || player.hair == 11)
							{
								player.male = false;
							}
							else
							{
								player.male = true;
							}
						}
						else
						{
							player.male = binaryReader.ReadBoolean();
						}
						player.statLife = binaryReader.ReadInt32();
						player.statLifeMax = binaryReader.ReadInt32();
						if (player.statLifeMax > 500)
						{
							player.statLifeMax = 500;
						}
						player.statMana = binaryReader.ReadInt32();
						player.statManaMax = binaryReader.ReadInt32();
						if (player.statManaMax > 200)
						{
							player.statManaMax = 200;
						}
						if (player.statMana > 400)
						{
							player.statMana = 400;
						}
						player.hairColor.R = binaryReader.ReadByte();
						player.hairColor.G = binaryReader.ReadByte();
						player.hairColor.B = binaryReader.ReadByte();
						player.skinColor.R = binaryReader.ReadByte();
						player.skinColor.G = binaryReader.ReadByte();
						player.skinColor.B = binaryReader.ReadByte();
						player.eyeColor.R = binaryReader.ReadByte();
						player.eyeColor.G = binaryReader.ReadByte();
						player.eyeColor.B = binaryReader.ReadByte();
						player.shirtColor.R = binaryReader.ReadByte();
						player.shirtColor.G = binaryReader.ReadByte();
						player.shirtColor.B = binaryReader.ReadByte();
						player.underShirtColor.R = binaryReader.ReadByte();
						player.underShirtColor.G = binaryReader.ReadByte();
						player.underShirtColor.B = binaryReader.ReadByte();
						player.pantsColor.R = binaryReader.ReadByte();
						player.pantsColor.G = binaryReader.ReadByte();
						player.pantsColor.B = binaryReader.ReadByte();
						player.shoeColor.R = binaryReader.ReadByte();
						player.shoeColor.G = binaryReader.ReadByte();
						player.shoeColor.B = binaryReader.ReadByte();
						Main.player[Main.myPlayer].shirtColor = player.shirtColor;
						Main.player[Main.myPlayer].pantsColor = player.pantsColor;
						Main.player[Main.myPlayer].hairColor = player.hairColor;
						if (num >= 38)
						{
							int num2 = 11;
							if (num >= 81)
							{
								num2 = 16;
							}
							for (int i = 0; i < num2; i++)
							{
								player.armor[i].netDefaults(binaryReader.ReadInt32());
								player.armor[i].Prefix(binaryReader.ReadByte());
							}
							if (num >= 47)
							{
								int num3 = 3;
								if (num >= 81)
								{
									num3 = 8;
								}
								for (int j = 0; j < num3; j++)
								{
									player.dye[j].netDefaults(binaryReader.ReadInt32());
									player.dye[j].Prefix(binaryReader.ReadByte());
								}
							}
							if (num >= 58)
							{
								for (int k = 0; k < 58; k++)
								{
									int num4 = binaryReader.ReadInt32();
									if (num4 >= 2749)
									{
										player.inventory[k].netDefaults(0);
										continue;
									}
									player.inventory[k].netDefaults(num4);
									player.inventory[k].stack = binaryReader.ReadInt32();
									player.inventory[k].Prefix(binaryReader.ReadByte());
								}
							}
							else
							{
								for (int l = 0; l < 48; l++)
								{
									int num5 = binaryReader.ReadInt32();
									if (num5 >= 2749)
									{
										player.inventory[l].netDefaults(0);
										continue;
									}
									player.inventory[l].netDefaults(num5);
									player.inventory[l].stack = binaryReader.ReadInt32();
									player.inventory[l].Prefix(binaryReader.ReadByte());
								}
							}
							if (num >= 58)
							{
								for (int m = 0; m < 40; m++)
								{
									player.bank.item[m].netDefaults(binaryReader.ReadInt32());
									player.bank.item[m].stack = binaryReader.ReadInt32();
									player.bank.item[m].Prefix(binaryReader.ReadByte());
								}
								for (int n = 0; n < 40; n++)
								{
									player.bank2.item[n].netDefaults(binaryReader.ReadInt32());
									player.bank2.item[n].stack = binaryReader.ReadInt32();
									player.bank2.item[n].Prefix(binaryReader.ReadByte());
								}
							}
							else
							{
								for (int num6 = 0; num6 < 20; num6++)
								{
									player.bank.item[num6].netDefaults(binaryReader.ReadInt32());
									player.bank.item[num6].stack = binaryReader.ReadInt32();
									player.bank.item[num6].Prefix(binaryReader.ReadByte());
								}
								for (int num7 = 0; num7 < 20; num7++)
								{
									player.bank2.item[num7].netDefaults(binaryReader.ReadInt32());
									player.bank2.item[num7].stack = binaryReader.ReadInt32();
									player.bank2.item[num7].Prefix(binaryReader.ReadByte());
								}
							}
						}
						else
						{
							for (int num8 = 0; num8 < 8; num8++)
							{
								player.armor[num8].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
								if (num >= 36)
								{
									player.armor[num8].Prefix(binaryReader.ReadByte());
								}
							}
							if (num >= 6)
							{
								for (int num9 = 8; num9 < 11; num9++)
								{
									player.armor[num9].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
									if (num >= 36)
									{
										player.armor[num9].Prefix(binaryReader.ReadByte());
									}
								}
							}
							for (int num10 = 0; num10 < 44; num10++)
							{
								player.inventory[num10].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
								player.inventory[num10].stack = binaryReader.ReadInt32();
								if (num >= 36)
								{
									player.inventory[num10].Prefix(binaryReader.ReadByte());
								}
							}
							if (num >= 15)
							{
								for (int num11 = 44; num11 < 48; num11++)
								{
									player.inventory[num11].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
									player.inventory[num11].stack = binaryReader.ReadInt32();
									if (num >= 36)
									{
										player.inventory[num11].Prefix(binaryReader.ReadByte());
									}
								}
							}
							for (int num12 = 0; num12 < 20; num12++)
							{
								player.bank.item[num12].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
								player.bank.item[num12].stack = binaryReader.ReadInt32();
								if (num >= 36)
								{
									player.bank.item[num12].Prefix(binaryReader.ReadByte());
								}
							}
							if (num >= 20)
							{
								for (int num13 = 0; num13 < 20; num13++)
								{
									player.bank2.item[num13].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
									player.bank2.item[num13].stack = binaryReader.ReadInt32();
									if (num >= 36)
									{
										player.bank2.item[num13].Prefix(binaryReader.ReadByte());
									}
								}
							}
						}
						if (num < 58)
						{
							for (int num14 = 40; num14 < 48; num14++)
							{
								player.inventory[num14 + 10] = player.inventory[num14].Clone();
								player.inventory[num14].SetDefaults(0);
							}
						}
						if (num >= 11)
						{
							int num15 = 22;
							if (num < 74)
							{
								num15 = 10;
							}
							for (int num16 = 0; num16 < num15; num16++)
							{
								player.buffType[num16] = binaryReader.ReadInt32();
								player.buffTime[num16] = binaryReader.ReadInt32();
								if (player.buffType[num16] == 0)
								{
									num16--;
									num15--;
								}
							}
						}
						for (int num17 = 0; num17 < 200; num17++)
						{
							int num18 = binaryReader.ReadInt32();
							if (num18 == -1)
							{
								break;
							}
							player.spX[num17] = num18;
							player.spY[num17] = binaryReader.ReadInt32();
							player.spI[num17] = binaryReader.ReadInt32();
							player.spN[num17] = binaryReader.ReadString();
						}
						if (num >= 16)
						{
							player.hbLocked = binaryReader.ReadBoolean();
						}
						if (num >= 98)
						{
							player.anglerQuestsFinished = binaryReader.ReadInt32();
						}
						for (int num19 = 3; num19 < 8; num19++)
						{
							int type = player.armor[num19].type;
							if (type == 908)
							{
								player.lavaMax += 420;
							}
							if (type == 906)
							{
								player.lavaMax += 420;
							}
							if (player.wingsLogic == 0 && player.armor[num19].wingSlot >= 0)
							{
								player.wingsLogic = player.armor[num19].wingSlot;
							}
							if (type == 158 || type == 396 || type == 1250 || type == 1251 || type == 1252)
							{
								player.noFallDmg = true;
							}
							player.lavaTime = player.lavaMax;
						}
						binaryReader.Close();
					}
				}
				player.PlayerFrame();
				if (decryptedCopy)
				{
					EncryptFile(text, playerPath);
					File.Delete(text);
				}
				else
				{
					File.Delete(text);
				}
				player.loadStatus = 0;
				return player;
			}
			catch
			{
			}
			Player player2 = new Player();
			player2.loadStatus = 2;
			if (player.name != "")
			{
				player2.name = player.name;
			}
			else
			{
				string[] array2 = playerPath.Split(Path.DirectorySeparatorChar);
				player.name = array2[array2.Length - 1].Split('.')[0];
			}
			return player2;
		}

		public Color GetHairColor(bool lighting = true)
		{
			Color color = hairColor;
			if (hairDye == 1)
			{
				color.R = (byte)((float)statLife / (float)statLifeMax2 * 235f + 20f);
				color.B = 20;
				color.G = 20;
			}
			else if (hairDye == 2)
			{
				color.R = (byte)((1f - (float)statMana / (float)statManaMax2) * 200f + 50f);
				color.B = byte.MaxValue;
				color.G = (byte)((1f - (float)statMana / (float)statManaMax2) * 180f + 75f);
			}
			else if (hairDye == 3)
			{
				float num = (float)(Main.worldSurface * 0.45) * 16f;
				float num2 = (float)(Main.worldSurface + Main.rockLayer) * 8f;
				float num3 = (float)(Main.rockLayer + (double)Main.maxTilesY) * 8f;
				float num4 = (float)(Main.maxTilesY - 150) * 16f;
				if (center().Y < num)
				{
					float num5 = center().Y / num;
					float num6 = 1f - num5;
					color.R = (byte)(116f * num6 + 28f * num5);
					color.G = (byte)(160f * num6 + 216f * num5);
					color.B = (byte)(249f * num6 + 94f * num5);
				}
				else if (center().Y < num2)
				{
					float num7 = num;
					float num8 = (center().Y - num7) / (num2 - num7);
					float num9 = 1f - num8;
					color.R = (byte)(28f * num9 + 151f * num8);
					color.G = (byte)(216f * num9 + 107f * num8);
					color.B = (byte)(94f * num9 + 75f * num8);
				}
				else if (center().Y < num3)
				{
					float num10 = num2;
					float num11 = (center().Y - num10) / (num3 - num10);
					float num12 = 1f - num11;
					color.R = (byte)(151f * num12 + 128f * num11);
					color.G = (byte)(107f * num12 + 128f * num11);
					color.B = (byte)(75f * num12 + 128f * num11);
				}
				else if (center().Y < num4)
				{
					float num13 = num3;
					float num14 = (center().Y - num13) / (num4 - num13);
					float num15 = 1f - num14;
					color.R = (byte)(128f * num15 + 255f * num14);
					color.G = (byte)(128f * num15 + 50f * num14);
					color.B = (byte)(128f * num15 + 15f * num14);
				}
				else
				{
					color.R = byte.MaxValue;
					color.G = 50;
					color.B = 10;
				}
			}
			else if (hairDye == 4)
			{
				int num16 = 0;
				for (int i = 0; i < 54; i++)
				{
					if (inventory[i].type == 71)
					{
						num16 += inventory[i].stack;
					}
					if (inventory[i].type == 72)
					{
						num16 += inventory[i].stack * 100;
					}
					if (inventory[i].type == 73)
					{
						num16 += inventory[i].stack * 10000;
					}
					if (inventory[i].type == 74)
					{
						num16 += inventory[i].stack * 1000000;
					}
				}
				float num17 = Item.buyPrice(0, 5);
				float num18 = Item.buyPrice(0, 50);
				float num19 = Item.buyPrice(2);
				Color color2 = new Color(226, 118, 76);
				Color color3 = new Color(174, 194, 196);
				Color color4 = new Color(204, 181, 72);
				Color color5 = new Color(161, 172, 173);
				if ((float)num16 < num17)
				{
					float num20 = (float)num16 / num17;
					float num21 = 1f - num20;
					color.R = (byte)((float)(int)color2.R * num21 + (float)(int)color3.R * num20);
					color.G = (byte)((float)(int)color2.G * num21 + (float)(int)color3.G * num20);
					color.B = (byte)((float)(int)color2.B * num21 + (float)(int)color3.B * num20);
				}
				else if ((float)num16 < num18)
				{
					float num22 = num17;
					float num23 = ((float)num16 - num22) / (num18 - num22);
					float num24 = 1f - num23;
					color.R = (byte)((float)(int)color3.R * num24 + (float)(int)color4.R * num23);
					color.G = (byte)((float)(int)color3.G * num24 + (float)(int)color4.G * num23);
					color.B = (byte)((float)(int)color3.B * num24 + (float)(int)color4.B * num23);
				}
				else if ((float)num16 < num19)
				{
					float num25 = num18;
					float num26 = ((float)num16 - num25) / (num19 - num25);
					float num27 = 1f - num26;
					color.R = (byte)((float)(int)color4.R * num27 + (float)(int)color5.R * num26);
					color.G = (byte)((float)(int)color4.G * num27 + (float)(int)color5.G * num26);
					color.B = (byte)((float)(int)color4.B * num27 + (float)(int)color5.B * num26);
				}
				else
				{
					color = color5;
				}
			}
			else if (hairDye == 5)
			{
				Color color6 = new Color(1, 142, 255);
				Color color7 = new Color(255, 255, 0);
				Color color8 = new Color(211, 45, 127);
				Color color9 = new Color(67, 44, 118);
				if (Main.dayTime)
				{
					if (Main.time < 27000.0)
					{
						float num28 = (float)(Main.time / 27000.0);
						float num29 = 1f - num28;
						color.R = (byte)((float)(int)color6.R * num29 + (float)(int)color7.R * num28);
						color.G = (byte)((float)(int)color6.G * num29 + (float)(int)color7.G * num28);
						color.B = (byte)((float)(int)color6.B * num29 + (float)(int)color7.B * num28);
					}
					else
					{
						float num30 = 27000f;
						float num31 = (float)((Main.time - (double)num30) / (54000.0 - (double)num30));
						float num32 = 1f - num31;
						color.R = (byte)((float)(int)color7.R * num32 + (float)(int)color8.R * num31);
						color.G = (byte)((float)(int)color7.G * num32 + (float)(int)color8.G * num31);
						color.B = (byte)((float)(int)color7.B * num32 + (float)(int)color8.B * num31);
					}
				}
				else if (Main.time < 16200.0)
				{
					float num33 = (float)(Main.time / 16200.0);
					float num34 = 1f - num33;
					color.R = (byte)((float)(int)color8.R * num34 + (float)(int)color9.R * num33);
					color.G = (byte)((float)(int)color8.G * num34 + (float)(int)color9.G * num33);
					color.B = (byte)((float)(int)color8.B * num34 + (float)(int)color9.B * num33);
				}
				else
				{
					float num35 = 16200f;
					float num36 = (float)((Main.time - (double)num35) / (32400.0 - (double)num35));
					float num37 = 1f - num36;
					color.R = (byte)((float)(int)color9.R * num37 + (float)(int)color6.R * num36);
					color.G = (byte)((float)(int)color9.G * num37 + (float)(int)color6.G * num36);
					color.B = (byte)((float)(int)color9.B * num37 + (float)(int)color6.B * num36);
				}
			}
			else if (hairDye == 6)
			{
				if (team == 1)
				{
					color = new Color(255, 0, 0);
				}
				else if (team == 2)
				{
					color = new Color(0, 255, 0);
				}
				else if (team == 3)
				{
					color = new Color(0, 0, 255);
				}
				else if (team == 4)
				{
					color = new Color(255, 255, 0);
				}
			}
			else if (hairDye == 7)
			{
				Color color10 = default(Color);
				color10 = ((Main.waterStyle == 2) ? new Color(124, 118, 242) : ((Main.waterStyle == 3) ? new Color(143, 215, 29) : ((Main.waterStyle == 4) ? new Color(78, 193, 227) : ((Main.waterStyle == 5) ? new Color(189, 231, 255) : ((Main.waterStyle == 6) ? new Color(230, 219, 100) : ((Main.waterStyle == 7) ? new Color(151, 107, 75) : ((Main.waterStyle == 8) ? new Color(128, 128, 128) : ((Main.waterStyle == 9) ? new Color(200, 0, 0) : ((Main.waterStyle != 10) ? new Color(28, 216, 94) : new Color(208, 80, 80))))))))));
				if (hairDyeColor.A == 0)
				{
					hairDyeColor = color10;
				}
				if (hairDyeColor.R > color10.R)
				{
					hairDyeColor.R--;
				}
				if (hairDyeColor.R < color10.R)
				{
					hairDyeColor.R++;
				}
				if (hairDyeColor.G > color10.G)
				{
					hairDyeColor.G--;
				}
				if (hairDyeColor.G < color10.G)
				{
					hairDyeColor.G++;
				}
				if (hairDyeColor.B > color10.B)
				{
					hairDyeColor.B--;
				}
				if (hairDyeColor.B < color10.B)
				{
					hairDyeColor.B++;
				}
				color = hairDyeColor;
			}
			else if (hairDye == 8)
			{
				color = new Color(244, 22, 175);
				if (!Main.gameMenu && !Main.gamePaused)
				{
					if (Main.rand.Next(45) == 0)
					{
						int type = Main.rand.Next(139, 143);
						int num38 = Dust.NewDust(position, width, 8, type, 0f, 0f, 0, default(Color), 1.2f);
						Main.dust[num38].velocity.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.dust[num38].velocity.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.dust[num38].velocity.X += (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.dust[num38].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.dust[num38].velocity.Y -= 1f;
						Main.dust[num38].scale *= 0.7f + (float)Main.rand.Next(-30, 31) * 0.01f;
						Main.dust[num38].velocity += velocity * 0.2f;
					}
					if (Main.rand.Next(225) == 0)
					{
						int type2 = Main.rand.Next(276, 283);
						int num39 = Gore.NewGore(new Vector2(position.X + (float)Main.rand.Next(width), position.Y + (float)Main.rand.Next(8)), velocity, type2);
						Main.gore[num39].velocity.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.gore[num39].velocity.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.gore[num39].scale *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
						Main.gore[num39].velocity.X += (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.gore[num39].velocity.Y += (float)Main.rand.Next(-50, 51) * 0.01f;
						Main.gore[num39].velocity.Y -= 1f;
						Main.gore[num39].velocity += velocity * 0.2f;
					}
				}
			}
			else if (hairDye == 9)
			{
				color = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
			}
			else if (hairDye == 10)
			{
				float num40 = Math.Abs(velocity.X) + Math.Abs(velocity.Y);
				float num41 = 10f;
				if (num40 > num41)
				{
					num40 = num41;
				}
				float num42 = num40 / num41;
				float num43 = 1f - num42;
				color.R = (byte)(75f * num42 + (float)(int)hairColor.R * num43);
				color.G = (byte)(255f * num42 + (float)(int)hairColor.G * num43);
				color.B = (byte)(200f * num42 + (float)(int)hairColor.B * num43);
			}
			if (lighting)
			{
				color = Lighting.GetColor((int)((double)position.X + (double)width * 0.5) / 16, (int)(((double)position.Y + (double)height * 0.25) / 16.0), color);
			}
			return color;
		}

		public bool HasItem(int type)
		{
			for (int i = 0; i < 58; i++)
			{
				if (type == inventory[i].type && inventory[i].stack > 0)
				{
					return true;
				}
			}
			return false;
		}

		public int FindItem(int netid)
		{
			for (int i = 0; i < 58; i++)
			{
				if (netid == inventory[i].netID && inventory[i].stack > 0)
				{
					return i;
				}
			}
			return -1;
		}

		public void QuickGrapple()
		{
			if (mount.Active)
			{
				mount.Dismount(this);
			}
			if (noItems)
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < 58; i++)
			{
				if (inventory[i].shoot == 13 || inventory[i].shoot == 32 || inventory[i].shoot == 73 || inventory[i].shoot == 165 || (inventory[i].shoot >= 230 && inventory[i].shoot <= 235) || inventory[i].shoot == 256 || inventory[i].shoot == 315 || inventory[i].shoot == 322 || inventory[i].shoot == 331 || inventory[i].shoot == 332 || inventory[i].shoot == 372 || inventory[i].shoot == 396)
				{
					num = i;
					break;
				}
			}
			if (num < 0)
			{
				return;
			}
			if (inventory[num].shoot == 73)
			{
				int num2 = 0;
				if (num >= 0)
				{
					for (int j = 0; j < 1000; j++)
					{
						if (Main.projectile[j].active && Main.projectile[j].owner == Main.myPlayer && (Main.projectile[j].type == 73 || Main.projectile[j].type == 74))
						{
							num2++;
						}
					}
				}
				if (num2 > 1)
				{
					num = -1;
				}
			}
			else if (inventory[num].shoot == 165)
			{
				int num3 = 0;
				if (num >= 0)
				{
					for (int k = 0; k < 1000; k++)
					{
						if (Main.projectile[k].active && Main.projectile[k].owner == Main.myPlayer && Main.projectile[k].type == 165)
						{
							num3++;
						}
					}
				}
				if (num3 > 8)
				{
					num = -1;
				}
			}
			else if (num >= 0)
			{
				for (int l = 0; l < 1000; l++)
				{
					if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == inventory[num].shoot && Main.projectile[l].ai[0] != 2f)
					{
						num = -1;
						break;
					}
				}
			}
			if (num < 0)
			{
				return;
			}
			Main.PlaySound(2, (int)position.X, (int)position.Y, inventory[num].useSound);
			if (Main.netMode == 1 && whoAmi == Main.myPlayer)
			{
				NetMessage.SendData(51, -1, -1, "", whoAmi, 2f);
			}
			int num4 = inventory[num].shoot;
			float shootSpeed = inventory[num].shootSpeed;
			int damage = inventory[num].damage;
			float knockBack = inventory[num].knockBack;
			if (num4 == 13 || num4 == 32 || num4 == 315 || (num4 >= 230 && num4 <= 235) || num4 == 331)
			{
				grappling[0] = -1;
				grapCount = 0;
				for (int m = 0; m < 1000; m++)
				{
					if (Main.projectile[m].active && Main.projectile[m].owner == whoAmi)
					{
						if (Main.projectile[m].type == 13)
						{
							Main.projectile[m].Kill();
						}
						if (Main.projectile[m].type == 331)
						{
							Main.projectile[m].Kill();
						}
						if (Main.projectile[m].type == 315)
						{
							Main.projectile[m].Kill();
						}
						if (Main.projectile[m].type >= 230 && Main.projectile[m].type <= 235)
						{
							Main.projectile[m].Kill();
						}
					}
				}
			}
			if (num4 == 256)
			{
				int num5 = 0;
				int num6 = -1;
				int num7 = 100000;
				for (int n = 0; n < 1000; n++)
				{
					if (Main.projectile[n].active && Main.projectile[n].owner == whoAmi && Main.projectile[n].type == 256)
					{
						num5++;
						if (Main.projectile[n].timeLeft < num7)
						{
							num6 = n;
							num7 = Main.projectile[n].timeLeft;
						}
					}
				}
				if (num5 > 1)
				{
					Main.projectile[num6].Kill();
				}
			}
			if (num4 == 73)
			{
				for (int num8 = 0; num8 < 1000; num8++)
				{
					if (Main.projectile[num8].active && Main.projectile[num8].owner == whoAmi && Main.projectile[num8].type == 73)
					{
						num4 = 74;
					}
				}
			}
			Vector2 vector = new Vector2(position.X + (float)width * 0.5f, position.Y + (float)height * 0.5f);
			float num9 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
			float num10 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
			if (gravDir == -1f)
			{
				num10 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
			}
			float num11 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
			num11 = shootSpeed / num11;
			num9 *= num11;
			num10 *= num11;
			Projectile.NewProjectile(vector.X, vector.Y, num9, num10, num4, damage, knockBack, whoAmi);
		}

		public Player()
		{
			name = string.Empty;
			for (int i = 0; i < 59; i++)
			{
				if (i < 16)
				{
					armor[i] = new Item();
					armor[i].name = "";
				}
				inventory[i] = new Item();
				inventory[i].name = "";
			}
			for (int j = 0; j < Chest.maxItems; j++)
			{
				bank.item[j] = new Item();
				bank.item[j].name = "";
				bank2.item[j] = new Item();
				bank2.item[j].name = "";
			}
			for (int k = 0; k < 8; k++)
			{
				dye[k] = new Item();
			}
			grappling[0] = -1;
			inventory[0].SetDefaults("Copper Shortsword");
			inventory[1].SetDefaults("Copper Pickaxe");
			inventory[2].SetDefaults("Copper Axe");
			statManaMax = 20;
			if (Main.cEd)
			{
				inventory[3].SetDefaults(603);
			}
			for (int l = 0; l < 340; l++)
			{
				adjTile[l] = false;
				oldAdjTile[l] = false;
			}
			hitTile = new HitTile();
			mount = new Mount();
		}

		public void TeleportationPotion()
		{
			bool flag = false;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = width;
			Vector2 vector = new Vector2(num2, num3) * 16f + new Vector2(-num4 / 2 + 8, -height);
			while (!flag && num < 1000)
			{
				num++;
				num2 = 100 + Main.rand.Next(Main.maxTilesX - 200);
				num3 = 100 + Main.rand.Next(Main.maxTilesY - 200);
				vector = new Vector2(num2, num3) * 16f + new Vector2(-num4 / 2 + 8, -height);
				if (Collision.SolidCollision(vector, num4, height))
				{
					continue;
				}
				if (Main.tile[num2, num3] == null)
				{
					Main.tile[num2, num3] = new Tile();
				}
				if ((Main.tile[num2, num3].wall == 87 && (double)num3 > Main.worldSurface && !NPC.downedPlantBoss) || (Main.wallDungeon[Main.tile[num2, num3].wall] && (double)num3 > Main.worldSurface && !NPC.downedBoss3))
				{
					continue;
				}
				int num5 = 0;
				while (num5 < 100)
				{
					if (Main.tile[num2, num3 + num5] == null)
					{
						Main.tile[num2, num3 + num5] = new Tile();
					}
					Tile tile = Main.tile[num2, num3 + num5];
					vector = new Vector2(num2, num3 + num5) * 16f + new Vector2(-num4 / 2 + 8, -height);
					Vector4 vector2 = Collision.SlopeCollision(vector, velocity, num4, height, gravDir);
					if (!Collision.SolidCollision(vector, num4, height))
					{
						num5++;
						continue;
					}
					if (tile.active() && !tile.inActive() && Main.tileSolid[tile.type])
					{
						break;
					}
					num5++;
				}
				if (Collision.LavaCollision(vector, num4, height) || Collision.HurtTiles(vector, velocity, num4, height).Y > 0f)
				{
					continue;
				}
				Vector4 vector3 = Collision.SlopeCollision(vector, velocity, num4, height, gravDir);
				if (!Collision.SolidCollision(vector, num4, height) || num5 >= 99)
				{
					continue;
				}
				Vector2 vector4 = Vector2.UnitX * 16f;
				if (Collision.TileCollision(vector - vector4, vector4, width, height, false, false, (int)gravDir) != vector4)
				{
					continue;
				}
				vector4 = -Vector2.UnitX * 16f;
				if (Collision.TileCollision(vector - vector4, vector4, width, height, false, false, (int)gravDir) != vector4)
				{
					continue;
				}
				vector4 = Vector2.UnitY * 16f;
				if (!(Collision.TileCollision(vector - vector4, vector4, width, height, false, false, (int)gravDir) != vector4))
				{
					vector4 = -Vector2.UnitY * 16f;
					if (!(Collision.TileCollision(vector - vector4, vector4, width, height, false, false, (int)gravDir) != vector4))
					{
						flag = true;
						num3 += num5;
						break;
					}
				}
			}
			if (flag)
			{
				Vector2 newPos = vector;
				Teleport(newPos, 2);
				velocity = Vector2.Zero;
				if (Main.netMode == 2)
				{
					ServerSock.CheckSection(whoAmi, position);
					NetMessage.SendData(65, -1, -1, "", 0, whoAmi, newPos.X, newPos.Y, 3);
				}
			}
		}

		public void GetAnglerReward()
		{
			Item item = new Item();
			item.type = 0;
			float num = 1f;
			if (anglerQuestsFinished <= 50)
			{
				num -= (float)anglerQuestsFinished * 0.01f;
			}
			else if (anglerQuestsFinished <= 100)
			{
				num = 0.5f - (float)(anglerQuestsFinished - 50) * 0.005f;
			}
			else if (anglerQuestsFinished <= 150)
			{
				num = 0.25f - (float)(anglerQuestsFinished - 100) * 0.002f;
			}
			if (anglerQuestsFinished == 10)
			{
				item.SetDefaults(2428);
			}
			else if (anglerQuestsFinished == 20)
			{
				item.SetDefaults(2367);
			}
			else if (anglerQuestsFinished == 30)
			{
				item.SetDefaults(2368);
			}
			else if (anglerQuestsFinished == 40)
			{
				item.SetDefaults(2369);
			}
			else if (anglerQuestsFinished == 50)
			{
				item.SetDefaults(2294);
			}
			else if (anglerQuestsFinished > 75 && Main.rand.Next((int)(250f * num)) == 0)
			{
				item.SetDefaults(2294);
			}
			else if (Main.hardMode && anglerQuestsFinished > 25 && Main.rand.Next((int)(150f * num)) == 0)
			{
				item.SetDefaults(2422);
			}
			else if (Main.hardMode && anglerQuestsFinished > 10 && Main.rand.Next((int)(100f * num)) == 0)
			{
				item.SetDefaults(2494);
			}
			else if (Main.rand.Next((int)(75f * num)) == 0)
			{
				item.SetDefaults(2360);
			}
			else if (Main.rand.Next((int)(50f * num)) == 0)
			{
				item.SetDefaults(2373);
			}
			else if (Main.rand.Next((int)(50f * num)) == 0)
			{
				item.SetDefaults(2374);
			}
			else if (Main.rand.Next((int)(50f * num)) == 0)
			{
				item.SetDefaults(2375);
			}
			else if (Main.rand.Next((int)(50f * num)) == 0)
			{
				item.SetDefaults(2417);
			}
			else if (Main.rand.Next((int)(50f * num)) == 0)
			{
				item.SetDefaults(2498);
			}
			else
			{
				switch (Main.rand.Next(27))
				{
				case 0:
					item.SetDefaults(2442);
					break;
				case 1:
					item.SetDefaults(2443);
					break;
				case 2:
					item.SetDefaults(2444);
					break;
				case 3:
					item.SetDefaults(2445);
					break;
				case 4:
					item.SetDefaults(2497);
					break;
				case 5:
					item.SetDefaults(2495);
					break;
				case 6:
					item.SetDefaults(2446);
					break;
				case 7:
					item.SetDefaults(2447);
					break;
				case 8:
					item.SetDefaults(2448);
					break;
				case 9:
					item.SetDefaults(2449);
					break;
				case 10:
					item.SetDefaults(2490);
					break;
				case 11:
					item.SetDefaults(2435);
					item.stack = Main.rand.Next(50, 151);
					break;
				case 12:
					item.SetDefaults(2496);
					break;
				case 13:
				case 14:
					item.SetDefaults(2354);
					item.stack = Main.rand.Next(2, 6);
					break;
				case 15:
				case 16:
					item.SetDefaults(2355);
					item.stack = Main.rand.Next(2, 6);
					break;
				case 17:
				case 18:
					item.SetDefaults(2356);
					item.stack = Main.rand.Next(2, 6);
					break;
				default:
				{
					int num2 = (anglerQuestsFinished + 50) / 2;
					num2 = (int)((float)(num2 * Main.rand.Next(50, 201)) * 0.01f);
					if (num2 > 100)
					{
						num2 /= 100;
						if (num2 > 10)
						{
							num2 = 10;
						}
						if (num2 < 1)
						{
							num2 = 1;
						}
						item.SetDefaults(73);
						item.stack = num2;
					}
					else
					{
						if (num2 > 99)
						{
							num2 = 99;
						}
						if (num2 < 1)
						{
							num2 = 1;
						}
						item.SetDefaults(72);
						item.stack = num2;
					}
					break;
				}
				}
			}
			item.position = center();
			Item item2 = GetItem(whoAmi, item, true);
			if (item2.stack > 0)
			{
				int number = Item.NewItem((int)position.X, (int)position.Y, width, height, item2.type, item2.stack, false, 0, true);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number, 1f);
				}
			}
			if (item.type == 2417)
			{
				Item item3 = new Item();
				Item item4 = new Item();
				item3.SetDefaults(2418);
				item3.position = center();
				item2 = GetItem(whoAmi, item3, true);
				if (item2.stack > 0)
				{
					int number2 = Item.NewItem((int)position.X, (int)position.Y, width, height, item2.type, item2.stack, false, 0, true);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number2, 1f);
					}
				}
				item4.SetDefaults(2419);
				item4.position = center();
				item2 = GetItem(whoAmi, item4, true);
				if (item2.stack > 0)
				{
					int number3 = Item.NewItem((int)position.X, (int)position.Y, width, height, item2.type, item2.stack, false, 0, true);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number3, 1f);
					}
				}
			}
			else if (item.type == 2498)
			{
				Item item5 = new Item();
				Item item6 = new Item();
				item5.SetDefaults(2499);
				item5.position = center();
				item2 = GetItem(whoAmi, item5, true);
				if (item2.stack > 0)
				{
					int number4 = Item.NewItem((int)position.X, (int)position.Y, width, height, item2.type, item2.stack, false, 0, true);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number4, 1f);
					}
				}
				item6.SetDefaults(2500);
				item6.position = center();
				item2 = GetItem(whoAmi, item6, true);
				if (item2.stack > 0)
				{
					int number5 = Item.NewItem((int)position.X, (int)position.Y, width, height, item2.type, item2.stack, false, 0, true);
					if (Main.netMode == 1)
					{
						NetMessage.SendData(21, -1, -1, "", number5, 1f);
					}
				}
			}
			if (Main.rand.Next((int)(100f * num)) > 50)
			{
				return;
			}
			Item item7 = new Item();
			if (Main.rand.Next((int)(15f * num)) == 0)
			{
				item7.SetDefaults(2676);
			}
			else if (Main.rand.Next((int)(5f * num)) == 0)
			{
				item7.SetDefaults(2675);
			}
			else
			{
				item7.SetDefaults(2674);
			}
			if (Main.rand.Next(25) <= anglerQuestsFinished)
			{
				item7.stack++;
			}
			if (Main.rand.Next(50) <= anglerQuestsFinished)
			{
				item7.stack++;
			}
			if (Main.rand.Next(100) <= anglerQuestsFinished)
			{
				item7.stack++;
			}
			if (Main.rand.Next(150) <= anglerQuestsFinished)
			{
				item7.stack++;
			}
			if (Main.rand.Next(200) <= anglerQuestsFinished)
			{
				item7.stack++;
			}
			if (Main.rand.Next(250) <= anglerQuestsFinished)
			{
				item7.stack++;
			}
			item7.position = center();
			item2 = GetItem(whoAmi, item7, true);
			if (item2.stack > 0)
			{
				int number6 = Item.NewItem((int)position.X, (int)position.Y, width, height, item2.type, item2.stack, false, 0, true);
				if (Main.netMode == 1)
				{
					NetMessage.SendData(21, -1, -1, "", number6, 1f);
				}
			}
		}
	}
}
