using System;
using System.Runtime.CompilerServices;
using UnityEngine;
public class BattleGlobal
{
	//
	// Static Fields
	//
	public static readonly int ShowTimeModelLayer = 16;

	public static readonly int ShowTimeCameraLayer = 65536;

	public static readonly int DefaultModelLayer = 9;

	public static readonly float FighterDeadDurTime = 0.5f;

	public static readonly float TalkBoxShowTime = 60f;

	public static readonly int RoundMaxNumber = 30;

	public static readonly int PhaseLeaveIndex = 3;

	public static readonly float SwipFighterTime = 0.25f;

	public static readonly float AnimationFadeTime = 0.1f;

	public static readonly float PlayerMoveSpeed = 10f;

	private static float TimeScale = 1f;

	private static float innerBaseTimeScale = 1f;

	public static readonly float PauseTimeScale = 0.001f;

	private static float ShowTime_TimeScale = 1f;

	public static Func<float, float> speedScaleFunc = (float arg) => BattleGlobal.ScaleSpeed (arg);

	public static readonly float AutoCountDownTime = 5f;

	public static readonly float FighterHPChangeDelayTime = 0f;

	public static readonly float DefaultMoveSpeed = 4.5f;

	private static float exterBaseTimeScale = 1f;

	public static readonly float DefaultMoveSpeedOfOutBattleScale = 1.5f;

	public static readonly int PhaseMaxNumber = 10;

	public static readonly string DropEffectPrefab = "BattlePrefabs/Diaoluo_Tx";

	public static readonly string DropPrefab = "BattlePrefabs/diaoluo_xiangzi";

	public static readonly string EnergyEffectPrefab = "juese_nuqi_tx";

	public static readonly string StandAnimName = "stand_normal";

	public static readonly string FightStandAnimName = "stand";

	public static readonly string BossTeamPosName = "BattlePrefabs/TeamPos_1";

	public static readonly string DefaultTeamPosName = "BattlePrefabs/TeamPos_0";

	public static readonly string MonsterPosSceneObjName = "BattleGroup/monsterPos_";

	public static readonly string MaterialFSMPrefab = "BattlePrefabs/MaterialFSMInfo";

	public static readonly string AnimFsmPrefab = "BattlePrefabs/AnimFSMInfo";

	public static readonly Vector3 FighterBoxColliderSize = new Vector3 (1f, 1f, 1f);

	public static readonly string NoShaderChangeTag = "NoShaderChange";

	public static readonly Vector3 FighterBoxColliderCenter = new Vector3 (0f, 0.5f, 0f);

	public static readonly int FighterNumberMax = 100;

	public static readonly int FighterNumberOneSide = 6;

	public static readonly string MoveAnimName = "move";

	public static readonly string BornAnim = "chuchang";

	public static readonly string RestAnimName = "rest";

	public static readonly string ReviveAnimName = "revive";

	public static readonly string DeadAnimName = "dead";

	

	public static float GetShowTimeScale ()
	{
		return BattleGlobal.ShowTime_TimeScale;
	}

	public static float GetTimeScale ()
	{
		return BattleGlobal.TimeScale;
	}

	public static Func<float, float> GetTimeScaleFunc (bool isShowTimeEnable)
	{
		if (isShowTimeEnable)
		{
			return (float arg) => BattleGlobal.ScaleTime_ShowTime (arg);
		}
		return (float arg) => BattleGlobal.ScaleTime (arg);
	}

	public static int MonsterFromGlobalToLocalPos (int pos)
	{
		return pos - BattleGlobal.FighterNumberMax;
	}

	public static float ScaleSpeed (float speed)
	{
		return speed * BattleGlobal.TimeScale;
	}

	public static float ScaleSpeed_ShowTime (float speed)
	{
		return BattleGlobal.ScaleSpeed (speed * BattleGlobal.ShowTime_TimeScale);
	}

	public static float ScaleTime (float time)
	{
		return time / BattleGlobal.TimeScale;
	}

	public static float ScaleTime_ShowTime (float time)
	{
		return BattleGlobal.ScaleTime (time / BattleGlobal.ShowTime_TimeScale);
	}

	public static void SetInnerTimeScale (float scale)
	{
		BattleGlobal.innerBaseTimeScale = scale;
		BattleGlobal.TimeScale = BattleGlobal.exterBaseTimeScale * BattleGlobal.innerBaseTimeScale;
	}

	public static void SetShowTimeScale (float scale)
	{
		BattleGlobal.ShowTime_TimeScale = scale;
	}

	public static void SetTimeScale (float scale)
	{
		BattleGlobal.exterBaseTimeScale = scale;
		BattleGlobal.TimeScale = BattleGlobal.exterBaseTimeScale * BattleGlobal.innerBaseTimeScale;
	}
}
