namespace ScreenCaptureApp.Utils;

public static class Contains
{
  public static string NONE = "无";
  public static string EMPTY = string.Empty;
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
  }

  public static class ImagesConfig
  {
    public static readonly string YUHUN = "任意御魂副本通用";
    public static readonly string JUEXIN = "任意觉醒副本通用";
    public static readonly string YULIN = "任意御灵副本通用";
    public static readonly string START = "开始画面";
    public static readonly string END = "结算画面";
    public static readonly int RegionWidth = 1152;
    public static readonly int RegionHeight = 679;
    public static readonly int RegionStartX = 498;
    public static readonly int RegionStartXTeam = 523;
    public static readonly int RegionStartY = 259;
    public static readonly int RegionStartYTeam = 270;
    public static readonly double StartXRate = RegionStartX * 1.0 / RegionWidth * 2;
    public static readonly double StartXRateTeam = RegionStartXTeam * 1.0 / RegionWidth * 2;
    public static readonly double StartYRate = RegionStartY * 1.0 / RegionHeight * 2;
    public static readonly double StartYRateTeam = RegionStartYTeam * 1.0 / RegionHeight * 2;
    public static readonly int RegionStartXSize = 30;
    public static readonly int RegionStartXSizeTeam = 25;
    public static readonly int RegionStartYSize = 22;
    public static readonly double StartXSizeRate = RegionStartXSize * 1.0 / RegionWidth * 2;
    public static readonly double StartXSizeRateTeam = RegionStartXSizeTeam * 1.0 / RegionWidth * 2;
    public static readonly double StartYSizeRate = RegionStartYSize * 1.0 / RegionHeight * 2;
    public static readonly double StartPointXLeftRate = 154 / 1152.0;
    public static readonly double StartPointXLeftTeamRate = 104 / 1152.0;
    public static readonly double StartPointXRightRate = 82 / 1152.0;
    public static readonly double StartPointXRightTeamRate = 15 / 1152.0;
    public static readonly double StartPointYTopRate = 105 / 679.0;
    public static readonly double StartPointYTopTeamRate = 118 / 679.0;
    public static readonly double StartPointYBottomRate = 30 / 679.0;
    public static readonly double StartPointYBottomTeamRate = 20 / 679.0;
    public static readonly int RegionEndX = 236;
    public static readonly int RegionEndY = 200;
    public static readonly double EndXRate = RegionEndX * 1.0 / RegionWidth * 2;
    public static readonly double EndYRate = RegionEndY * 1.0 / RegionHeight * 2;
    public static readonly int RegionEndXSize = 70;
    public static readonly int RegionEndYSize = 40;
    public static readonly double EndXSizeRate = RegionEndXSize * 1.0 / RegionWidth * 2;
    public static readonly double EndYSizeRate = RegionEndYSize * 1.0 / RegionHeight * 2;
    public static readonly double EndPointXLeftRate = 374 / 1152.0;
    public static readonly double EndPointXRightRate = 11 / 1152.0;
    public static readonly double EndPointYTopRate = 324 / 679.0;
    public static readonly double EndPointYBottomRate = 11 / 679.0;
  }
}
