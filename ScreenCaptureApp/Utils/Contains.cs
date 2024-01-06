namespace ScreenCaptureApp.Utils;

public static class Contains
{
  public static string NONE = "无";
  public static string EMPTY = string.Empty;
  public static readonly int RegionWidth = 1152;
  public static readonly int RegionHeight = 679;
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
    public static readonly string JUEXING = "juexing";
    public static readonly string YUHUN = "yuhun";
  }

  public static class ChallengeType
  {
    public static readonly string NOMAL = "普通副本";
    public static readonly string ACTIVITIES = "活动副本";
    public static readonly string TUPO = "突破";
  }

  public static class ChallengeSelection
  {
    public static readonly string JUEXIN_ANY = "觉醒副本任意层";
    public static readonly string YULIN_ANY = "御灵任意层";
    public static readonly string BAQI_1_10 = "八岐大蛇1-10层";
    public static readonly string BAQI_11 = "八岐大蛇11层";
    public static readonly string BAQI_12 = "八岐大蛇12层";
    public static readonly string BEIMIHU_1 = "卑弥呼1层";
    public static readonly string BEIMIHU_2 = "卑弥呼2层";
    public static readonly string BEIMIHU_3 = "卑弥呼3层";
    public static readonly string YEYUANHUO_TAN = "业原火贪";
    public static readonly string YEYUANHUO_CHEN = "业原火嗔";
    public static readonly string YEYUANHUO_CHI = "业原火痴";
    public static readonly string YONGSHEN_1 = "永生之海1层";
    public static readonly string YONGSHEN_2 = "永生之海2层";
    public static readonly string YONGSHEN_3_4 = "永生之海3-4层";
    public static readonly string GEREN = "个人";
    public static readonly string YINYANGLIAO = "阴阳寮";
  }

  public static class ImagesConfig
  {
    public static readonly string YUHUN = "任意御魂副本通用";
    public static readonly string JUEXIN = "任意觉醒副本通用";
    public static readonly string YULIN = "任意御灵副本通用";
    public static readonly string START = "开始画面";
    public static readonly string END = "结算画面";
    public static readonly string SHIBAI = "失败";

    public static readonly int RegionStartX = 498 * 2;
    public static readonly int RegionStartXTeam = 523 * 2;
    public static readonly int RegionStartY = 259 * 2;
    public static readonly int RegionStartYTeam = 270 * 2;
    public static readonly double StartXRate = RegionStartX * 1.0 / RegionWidth;
    public static readonly double StartXRateTeam = RegionStartXTeam * 1.0 / RegionWidth;
    public static readonly double StartYRate = RegionStartY * 1.0 / RegionHeight;
    public static readonly double StartYRateTeam = RegionStartYTeam * 1.0 / RegionHeight;
    public static readonly int RegionStartXSize = 30 * 2;
    public static readonly int RegionStartXSizeTeam = 25 * 2;
    public static readonly int RegionStartYSize = 22 * 2;
    public static readonly double StartXSizeRate = RegionStartXSize * 1.0 / RegionWidth;
    public static readonly double StartXSizeRateTeam = RegionStartXSizeTeam * 1.0 / RegionWidth ;
    public static readonly double StartYSizeRate = RegionStartYSize * 1.0 / RegionHeight ;
    public static readonly double StartPointXLeftRate = 154 / 1152.0;
    public static readonly double StartPointXLeftTeamRate = 104 / 1152.0;
    public static readonly double StartPointXRightRate = 82 / 1152.0;
    public static readonly double StartPointXRightTeamRate = 15 / 1152.0;
    public static readonly double StartPointYTopRate = 105 / 679.0;
    public static readonly double StartPointYTopTeamRate = 118 / 679.0;
    public static readonly double StartPointYBottomRate = 30 / 679.0;
    public static readonly double StartPointYBottomTeamRate = 20 / 679.0;
    public static readonly int RegionEndX = 236 * 2;
    public static readonly int RegionEndY = 200 * 2;
    public static readonly double EndXRate = RegionEndX * 1.0 / RegionWidth;
    public static readonly double EndYRate = RegionEndY * 1.0 / RegionHeight;
    public static readonly int RegionEndXSize = 70 * 2;
    public static readonly int RegionEndYSize = 40 * 2;
    public static readonly double EndXSizeRate = RegionEndXSize * 1.0 / RegionWidth;
    public static readonly double EndYSizeRate = RegionEndYSize * 1.0 / RegionHeight;
    public static readonly double EndPointXLeftRate = 374 / 1152.0;
    public static readonly double EndPointXRightRate = 11 / 1152.0;
    public static readonly double EndPointYTopRate = 324 / 679.0;
    public static readonly double EndPointYBottomRate = 11 / 679.0;
    public static readonly int SHIBAISizeWidth = 60;
    public static readonly int SHIBAISizeHeight = 60;
    public static readonly int SHIBAISizeMarginLeft = 360;
    public static readonly int SHIBAISizeMarginTop = 130;
    public static readonly double SHIBAISizeWidthRate = SHIBAISizeWidth * 1.0 / RegionWidth;
    public static readonly double SHIBAISizeHeightRate = SHIBAISizeHeight * 1.0 / RegionHeight;
    public static readonly double SHIBAISizeMarginLeftRate = SHIBAISizeMarginLeft * 1.0 / RegionWidth;
    public static readonly double SHIBAISizeMarginTopRate = SHIBAISizeMarginTop * 1.0 / RegionHeight;

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
    public static readonly string YINYANGLIAO_UNSELECTED= "阴阳寮-未选中";
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
    public static readonly int TuPoPanelSizeWidth = 36;
    public static readonly int TuPoPanelSizeHeight = 36;
    public static readonly int TuPoPanelMarginLeft_YinYangLiao1 = 625;
    public static readonly int TuPoPanelMarginLeft_YinYangLiao2 = 625 + 300;
    public static readonly int TuPoPanelMarginLeft_GeRen1 = 362;
    public static readonly int TuPoPanelMarginLeft_GeRen2 = 362 + 295;
    public static readonly int TuPoPanelMarginLeft_GeRen3 = 362 + 295 * 2;
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
  }
}
