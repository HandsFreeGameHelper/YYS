using ScreenCaptureApp.Main.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ScreenCaptureApp.Utils;

public static class Contains
{
  public static string NONE = "无";
  public static string EMPTY = string.Empty;
  public static string DEFAULT = "default";
  public static string LOGGINGSERVICE = @"http://localhost:5176/api/OnPostUpLoad";
  public static readonly int RegionWidth = 1152;
  public static readonly int RegionHeight = 679;

  public static List<string> ChallengeTypeList = new();
  public static List<string> ChallengeSelectionList = new();
  public static List<string> AfterChallengeSelectionList = new();

  static Contains()
  {
    Init();
  }

  #region CommenConfig

  public static class ChallengeType
  {
    public static readonly string EMPTY = string.Empty;
    public static readonly string NORMAL = "普通副本";
    public static readonly string ACTIVITIES = "活动爬塔";
    public static readonly string TUPO = "突破";
  }

  public static class ChallengeSelection
  {
    public static readonly string EMPTY = string.Empty;
    public static readonly string GEREN = "突破_个人";
    public static readonly string YINYANGLIAO = "突破_阴阳寮";
    [SetStaticValueIgnore]
    public static readonly string JUEXING = "觉醒";
    public static readonly string JUEXING_ANY = "普通副本_觉醒副本任意层";
    [SetStaticValueIgnore]
    public static readonly string YULIN = "御灵";
    public static readonly string YULIN_ANY = "普通副本_御灵任意层";
    [SetStaticValueIgnore]
    public static readonly string BAQI= "八岐大蛇";
    public static readonly string BAQI_1_10 = "普通副本_八岐大蛇1-10层";
    public static readonly string BAQI_11 = "普通副本_八岐大蛇11层";
    public static readonly string BAQI_12 = "普通副本_八岐大蛇12层";
    [SetStaticValueIgnore]
    public static readonly string BEIMIHU = "卑弥呼";
    public static readonly string BEIMIHU_1 = "普通副本_卑弥呼1层";
    public static readonly string BEIMIHU_2 = "普通副本_卑弥呼2层";
    public static readonly string BEIMIHU_3 = "普通副本_卑弥呼3层";
    [SetStaticValueIgnore]
    public static readonly string YEYUANHUO= "业原火";
    public static readonly string YEYUANHUO_TAN = "普通副本_业原火贪";
    public static readonly string YEYUANHUO_CHEN = "普通副本_业原火嗔";
    public static readonly string YEYUANHUO_CHI = "普通副本_业原火痴";
    [SetStaticValueIgnore]
    public static readonly string YONGSHENG = "永生之海";
    public static readonly string YONGSHENG_1 = "普通副本_永生之海1层";
    public static readonly string YONGSHENG_2 = "普通副本_永生之海2层";
    public static readonly string YONGSHENG_3_4 = "普通副本_永生之海3-4层";
    [SetStaticValueIgnore]
    public static readonly string GOLDENNIGHTTIRP = "黄金夜航-藏金阁楼";
    public static readonly string GOLDENNIGHTTIRP_1 = "活动爬塔_黄金夜航-藏金阁楼-活动室";
    public static readonly string GOLDENNIGHTTIRP_2 = "活动爬塔_黄金夜航-藏金阁楼-战术厅";
    public static readonly string GOLDENNIGHTTIRP_3 = "活动爬塔_黄金夜航-藏金阁楼-船员室";
    public static readonly string GOLDENNIGHTTIRP_4 = "活动爬塔_黄金夜航-藏金阁楼-黄金阁";
  }

  public static class ImagesConfig
  {
    public static readonly string YUHUN = "任意御魂副本通用";
    public static readonly string JUEXING = "任意觉醒副本通用";
    public static readonly string YULIN = "任意御灵副本通用";
    public static readonly string START = "开始画面";
    public static readonly string END = "结算画面";
    public static readonly string FAILED = "失败";
    public static readonly string VECTORY = "失败";

    public static readonly int StartSizeWidth = 60;
    public static readonly int StartSizeHeight = 25;
    public static readonly int StartSizeMarginLeft = 990;
    public static readonly int StartSizeMarginTop = 534;
    public static readonly double StartSizeWidthRate = StartSizeWidth * 1.0 / RegionWidth;
    public static readonly double StartSizeHeightRate = StartSizeHeight * 1.0 / RegionHeight;
    public static readonly double StartSizeMarginLeftRate = StartSizeMarginLeft * 1.0 / RegionWidth;
    public static readonly double StartSizeMarginTopRate = StartSizeMarginTop * 1.0 / RegionHeight;

    public static readonly int TeamStartSizeWidth = 48;
    public static readonly int TeamStartSizeHeight = 30;
    public static readonly int TeamStartSizeMarginLeft = 1058;
    public static readonly int TeamStartSizeMarginTop = 552;
    public static readonly double TeamStartSizeWidthRate = TeamStartSizeWidth * 1.0 / RegionWidth;
    public static readonly double TeamStartSizeHeightRate = TeamStartSizeHeight * 1.0 / RegionHeight;
    public static readonly double TeamStartSizeMarginLeftRate = TeamStartSizeMarginLeft * 1.0 / RegionWidth;
    public static readonly double TeamStartSizeMarginTopRate = TeamStartSizeMarginTop * 1.0 / RegionHeight;

    public static readonly int EndSizeWidth = 80;
    public static readonly int EndSizeHeight = 80;
    public static readonly int EndSizeMarginLeft = 568;
    public static readonly int EndSizeMarginTop = 474;
    public static readonly double EndSizeWidthRate = EndSizeWidth * 1.0 / RegionWidth;
    public static readonly double EndSizeHeightRate = EndSizeHeight * 1.0 / RegionHeight;
    public static readonly double EndSizeMarginLeftRate = EndSizeMarginLeft * 1.0 / RegionWidth;
    public static readonly double EndSizeMarginTopRate = EndSizeMarginTop * 1.0 / RegionHeight;
    public static readonly int EndClickSizeWidth = 190;
    public static readonly int EndClickSizeHeight = 150;
    public static readonly int EndClickSizeMarginLeft = 830;
    public static readonly int EndClickSizeMarginTop = 481;
    public static readonly double EndClickSizeWidthRate = EndClickSizeWidth * 1.0 / RegionWidth;
    public static readonly double EndClickSizeHeightRate = EndClickSizeHeight * 1.0 / RegionHeight;
    public static readonly double EndClickSizeMarginLeftRate = EndClickSizeMarginLeft * 1.0 / RegionWidth;
    public static readonly double EndClickSizeMarginTopRate = EndClickSizeMarginTop * 1.0 / RegionHeight;
    public static readonly int FAILEDSizeWidth = 60;
    public static readonly int FAILEDSizeHeight = 60;
    public static readonly int FAILEDSizeMarginLeft = 360;
    public static readonly int FAILEDSizeMarginTop = 130;
    public static readonly double FAILEDSizeWidthRate = FAILEDSizeWidth * 1.0 / RegionWidth;
    public static readonly double FAILEDSizeHeightRate = FAILEDSizeHeight * 1.0 / RegionHeight;
    public static readonly double FAILEDSizeMarginLeftRate = FAILEDSizeMarginLeft * 1.0 / RegionWidth;
    public static readonly double FAILEDSizeMarginTopRate = FAILEDSizeMarginTop * 1.0 / RegionHeight;
    public static readonly int VictorySizeWidth = 60;
    public static readonly int VictorySizeHeight = 60;
    public static readonly int VictorySizeMarginLeft = 360;
    public static readonly int VictorySizeMarginTop = 130;
    public static readonly double VictorySizeWidthRate = VictorySizeWidth * 1.0 / RegionWidth;
    public static readonly double VictorySizeHeightRate = VictorySizeHeight * 1.0 / RegionHeight;
    public static readonly double VictorySizeMarginLeftRate = VictorySizeMarginLeft * 1.0 / RegionWidth;
    public static readonly double VictorySizeMarginTopRate = VictorySizeMarginTop * 1.0 / RegionHeight;
  }

  public static class EventImagePath
  {
    public static readonly string TuPo_YinYangLiaoUnSelectedPath = $@"./Resource/TuPo/tupo_yinyangliao_unselected.png";
    public static readonly string TuPo_YinYangLiaoSelectedPath = $@"./Resource/TuPo/tupo_yinyangliao_selected.png";
    public static readonly string TuPo_GeRenUnSelectedPath = $@"./Resource/TuPo/tupo_geren_unselected.png";
    public static readonly string TuPo_GeRenSelectedPath = $@"./Resource/TuPo/tupo_geren_selected.png";
    public static readonly string TuPo_UnTuPo = @"./Resource/TuPo/tupo_untupo.png";
    public static readonly string TuPo_Attack = @"./Resource/TuPo/tupo_attack.png";
    public static readonly string End = $@"./Resource/End/end.png";
    public static readonly string Failed = $@"./Resource/End/failed.png";
    public static readonly string Victory = $@"./Resource/End/victory.png";
    public static readonly string NoChance = @"./Resource/TuPo/tupo_nochance.png";

    public static class GoldenNightTripImagePath
    {
      public static readonly string HuodongshiPath = $@"./Resource/Active/240110/GoldenNightTrip/huodongshi_unselected.png";
      public static readonly string ZhanshutingPath = $@"./Resource/Active/240110/GoldenNightTrip/zhanshuting_unselected.png";
      public static readonly string ChuanyuanshiPath = $@"./Resource/Active/240110/GoldenNightTrip/chuanyuanshi_unselected.png";
      public static readonly string HuangjingePath = $@"./Resource/Active/240110/GoldenNightTrip/huangjinge_unselected.png";
      public static readonly string ChallengePath = $@"./Resource/Active/240110/GoldenNightTrip/challenge.png";
    }
  }
  #endregion

  #region Other

  public static class EnergyValue
  {
    public static readonly string SIX = "6";
    public static readonly string NINE = "9";
    public static readonly string TWELVE = "12";
    public static readonly string EIGHTEEN = "18";
    public static readonly string TWENTYFOUR = "24";
    public static readonly string THIRTY = "30";
    public static readonly string TAN = "tan";
    public static readonly string CHEN = "chen";
    public static readonly string CHI = "chi";
    public static readonly string YULIN = "yulin";
    public static readonly string JUEXINGG = "juexing";
    public static readonly string YUHUN = "yuhun";
  }

  public static class TuPo
  {
    public static readonly string TUPO = "突破";
    public static readonly string GEREN = "个人";
    public static readonly string GEREN_SELECTED = "个人-选中";
    public static readonly string GEREN_UNSELECTED = "个人-未选中";
    public static readonly string GEREN_SELECTED_TYPE = "geren_selected";
    public static readonly string GEREN_UNSELECTED_TYPE = "geren_unselected";
    public static readonly string YINYANGLIAO = "阴阳寮";
    public static readonly string YINYANGLIAO_SELECTED = "阴阳寮-选中";
    public static readonly string YINYANGLIAO_UNSELECTED = "阴阳寮-未选中";
    public static readonly string YINYANGLIAO_SELECTED_TYPE = "yinyangliao_selected";
    public static readonly string YINYANGLIAO_UNSELECTED_TYPE = "yinyangliao_unselected";
    public static readonly string UNTUPO = "未挑战";
    public static readonly string UNTUPO_TYPE = "untupo";
    public static readonly string TUPOED = "已突破";
    public static readonly string TUPOED_TYPE = "tupoed";
    public static readonly string TUPOFAILED = "突破失败";
    public static readonly string TUPOFAILED_TYPE = "tupofailed";
    public static readonly string ATTACK = "进攻";
    public static readonly string ATTACK_TYPE = "attack";
    public static readonly string REFRESH = "刷新";
    public static readonly string REFRESH_TYPE = "refresh";
    public static readonly string NOCHANCE = "没次数";
    public static readonly string NOCHANCE_TYPE = "nochance";
    public static readonly int TuPoPanelSizeWidth = 26;
    public static readonly int TuPoPanelSizeHeight = 26;
    public static readonly int TuPoPanelMarginLeft_YinYangLiao1 = 635;
    public static readonly int TuPoPanelMarginLeft_YinYangLiao2 = 635 + 300;
    public static readonly int TuPoPanelMarginLeft_GeRen1 = 372;
    public static readonly int TuPoPanelMarginLeft_GeRen2 = 372 + 295;
    public static readonly int TuPoPanelMarginLeft_GeRen3 = 372 + 295 * 2;
    public static readonly int TuPoPanelMarginTop_YinYangLiao = 118;
    public static readonly int TuPoPanelMarginTop_GeRen = 126;
    public static readonly double TuPoPanelSizeWidthRate = TuPoPanelSizeWidth * 1.0 / RegionWidth;
    public static readonly double TuPoPanelSizeHeightRate = TuPoPanelSizeHeight * 1.0 / RegionHeight;
    public static readonly double TuPoPanelMarginLeftYinYangLiao1Rate = TuPoPanelMarginLeft_YinYangLiao1 * 1.0 / RegionWidth;
    public static readonly double TuPoPanelMarginLeftYinYangLiao2Rate = TuPoPanelMarginLeft_YinYangLiao2 * 1.0 / RegionWidth;
    public static readonly double TuPoPanelMarginLeftGeRen1Rate = TuPoPanelMarginLeft_GeRen1 * 1.0 / RegionWidth;
    public static readonly double TuPoPanelMarginLeftGeRen2Rate = TuPoPanelMarginLeft_GeRen2 * 1.0 / RegionWidth;
    public static readonly double TuPoPanelMarginLeftGeRen3Rate = TuPoPanelMarginLeft_GeRen3 * 1.0 / RegionWidth;
    public static readonly double TuPoPanelMarginTopYinYangLiaoRate = TuPoPanelMarginTop_YinYangLiao * 1.0 / RegionHeight;
    public static readonly double TuPoPanelMarginTopGeRenRate = TuPoPanelMarginTop_GeRen * 1.0 / RegionHeight;
    public static readonly int TuPoSectionSizeWidth = 54;
    public static readonly int TuPoSectionSizeHeight = 94;
    public static readonly int TuPoGeRenMarginTop = 208;
    public static readonly int TuPoYinYangLiaoMarginTop = 318;
    public static readonly int TuPoSectionMarginLeft = 1065;
    public static readonly double TuPoSectionSizeWidthRate = TuPoSectionSizeWidth * 1.0 / RegionWidth;
    public static readonly double TuPoSectionSizeHeightRate = TuPoSectionSizeHeight * 1.0 / RegionHeight;
    public static readonly double TuPoGeRenMarginTopRate = TuPoGeRenMarginTop * 1.0 / RegionHeight;
    public static readonly double TuPoYinYangLiaoMarginTopRate = TuPoYinYangLiaoMarginTop * 1.0 / RegionHeight;
    public static readonly double TuPoSectionMarginLeftRate = TuPoSectionMarginLeft * 1.0 / RegionWidth;
    public static readonly int AttackSizeWidth = 116;
    public static readonly int AttackSizeHeight = 52;
    public static readonly int AttackMarginLeft_YinYangLiao1 = 526;
    public static readonly int AttackMarginLeft_YinYangLiao2 = 526 + 300;
    public static readonly int AttackMarginLeft_GeRen1 = 282;
    public static readonly int AttackMarginLeft_GeRen2 = 282 + 295;
    public static readonly int AttackMarginLeft_GeRen3 = 282 + 295 * 2;
    public static readonly int AttackMarginTop_YinYangLiao = 309;
    public static readonly int AttackMarginTop_GeRen = 315;
    public static readonly double AttackSizeWidthRate = AttackSizeWidth * 1.0 / RegionWidth;
    public static readonly double AttackSizeHeightRate = AttackSizeHeight * 1.0 / RegionHeight;
    public static readonly double AttackMarginLeftYinYangLiaoRate1 = AttackMarginLeft_YinYangLiao1 * 1.0 / RegionWidth;
    public static readonly double AttackMarginLeftYinYangLiaoRate2 = AttackMarginLeft_YinYangLiao2 * 1.0 / RegionWidth;
    public static readonly double AttackMarginLeftGeRenRate1 = AttackMarginLeft_GeRen1 * 1.0 / RegionWidth;
    public static readonly double AttackMarginLeftGeRenRate2 = AttackMarginLeft_GeRen2 * 1.0 / RegionWidth;
    public static readonly double AttackMarginLeftGeRenRate3 = AttackMarginLeft_GeRen3 * 1.0 / RegionWidth;
    public static readonly double AttackMarginTopYinYangLiaoRate = AttackMarginTop_YinYangLiao * 1.0 / RegionHeight;
    public static readonly double AttackMarginTopGeRenRate = AttackMarginTop_GeRen * 1.0 / RegionHeight;
    public static readonly int RefreshSizeWidth = 158;
    public static readonly int RefreshSizeHeight = 54;
    public static readonly int RefreshMarginLeft = 852;
    public static readonly int RefreshMarginTop = 504;
    public static readonly double RefreshSizeWidthRate = RefreshSizeWidth * 1.0 / RegionWidth;
    public static readonly double RefreshSizeHeightRate = RefreshSizeHeight * 1.0 / RegionHeight;
    public static readonly double RefreshMarginLeftRate = RefreshMarginLeft * 1.0 / RegionWidth;
    public static readonly double RefreshMarginTopRate = RefreshMarginTop * 1.0 / RegionHeight;
    public static readonly int YinYangLiaoEndY = 480;
    public static readonly int ResetMarginLeft = 521;
    public static readonly int ResetMarginTop = 214;
    public static readonly double YinYangLiaoEndYRate = YinYangLiaoEndY * 1.0 / RegionHeight;
    public static readonly double ResetMarginLeftRate = ResetMarginLeft * 1.0 / RegionWidth;
    public static readonly double ResetMarginTopRate = ResetMarginTop * 1.0 / RegionHeight;
    public static readonly int NoChanceSizeWidth = 50;
    public static readonly int NoChanceSizeHeight = 26;
    public static readonly int NoChanceMarginLeft = 237;
    public static readonly int NoChanceMarginTop = 500;
    public static readonly double NoChanceSizeWidthRate = NoChanceSizeWidth * 1.0 / RegionWidth;
    public static readonly double NoChanceSizeHeightRate = NoChanceSizeHeight * 1.0 / RegionHeight;
    public static readonly double NoChanceMarginLeftRate = NoChanceMarginLeft * 1.0 / RegionWidth;
    public static readonly double NoChanceMarginTopRate = NoChanceMarginTop * 1.0 / RegionHeight;
  }

  public static class GoldenNightTrip
  {
    public static readonly string HUODONGSHI = "活动室";
    public static readonly string HUODONGSHI_TYPE = "huodongshi";
    public static readonly string ZHANSHUTING = "战术厅";
    public static readonly string ZHANSHUTINGI_TYPE = "zhanshuting";
    public static readonly string CHUANYUANSHI = "船员室";
    public static readonly string CHUANYUANSHII_TYPE = "chuanyuanshi";
    public static readonly string HUANGJINGE = "黄金阁";
    public static readonly string HUANGJINGEI_TYPE = "huangjinge";
    public static readonly string CHALLENGE = "挑战";
    public static readonly string CHALLENGEI_TYPE = "challenge";
    public static readonly int SelectionSizeWidth = 172;
    public static readonly int SelectionSizeHeight = 40;
    public static readonly int SelectionMarginLeft = 64;
    public static readonly int HuoDongShiMarginTop = 112;
    public static readonly int ZhanShuTingMarginTop = HuoDongShiMarginTop + (SelectionSizeHeight + 50) * 1;
    public static readonly int ChuanYuanShiMarginTop = HuoDongShiMarginTop + (SelectionSizeHeight + 50) * 2;
    public static readonly int HuangJinGeMarginTop = HuoDongShiMarginTop + (SelectionSizeHeight + 50) * 3;
    public static readonly double SelectionSizeWidthRate = SelectionSizeWidth * 1.0 / RegionWidth;
    public static readonly double SelectionSizeHeightRate = SelectionSizeHeight * 1.0 / RegionHeight;
    public static readonly double SelectionMarginLefttRate = SelectionMarginLeft * 1.0 / RegionWidth;
    public static readonly double HuoDongShiMarginTopRate = HuoDongShiMarginTop * 1.0 / RegionHeight;
    public static readonly double ZhanShuTingMarginTopRate = ZhanShuTingMarginTop * 1.0 / RegionHeight;
    public static readonly double ChuanYuanShiMarginTopRate = ChuanYuanShiMarginTop * 1.0 / RegionHeight;
    public static readonly double HuangJinGeMarginTopRate = HuangJinGeMarginTop * 1.0 / RegionHeight;
    public static readonly int ChallengeSizeWidth = 68;
    public static readonly int ChallengeSizeHeight = 38;
    public static readonly int ChallengeMarginLeft = 1010;
    public static readonly int ChallengeMarginTop = 518;
    public static readonly double ChallengeSizeWidthRate = ChallengeSizeWidth * 1.0 / RegionWidth;
    public static readonly double ChallengeSizeHeightRate = ChallengeSizeHeight * 1.0 / RegionHeight;
    public static readonly double ChallengeMarginLeftRate = ChallengeMarginLeft * 1.0 / RegionWidth;
    public static readonly double ChallengeMarginTopRate = ChallengeMarginTop * 1.0 / RegionHeight;
  }

  #endregion

  private static void Init()
  {
    ChallengeTypeList = ChallengeTypeList.SetStaticValues(typeof(ChallengeType));
    ChallengeSelectionList = ChallengeSelectionList.SetStaticValues(typeof(ChallengeSelection));
    AfterChallengeSelectionList = ChallengeSelectionList;
  }
}
