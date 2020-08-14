using Refit;

namespace SFACGPC.Data.Web.Request {
    public class GetNovelInfo {
        [AliasAs("novelid")]
        public string NovelID { set; get; }

        [AliasAs("expand=chapterCount,bigBgBanner,bigNovelCover,typeName,intro,fav,ticket,pointCount,tags,sysTags,signlevel,discount,discountExpireDate,totalNeedFireMoney,originTotalNeedFireMoney,latestchapter,latestcommentdate,essaytag,auditCover")]
        public string Expand { set; get; } = "chapterCount,bigBgBanner,bigNovelCover,typeName,intro,fav,ticket,pointCount,tags,sysTags,signlevel,discount,discountExpireDate,totalNeedFireMoney,originTotalNeedFireMoney,latestchapter,latestcommentdate,essaytag,auditCover";
    }
}
