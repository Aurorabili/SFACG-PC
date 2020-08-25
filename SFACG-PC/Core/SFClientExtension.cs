using SFACGPC.Data.ViewModel;
using SFACGPC.Data.Web.Delegation;
using SFACGPC.Data.Web.Response;
using SFACGPC.Objects.Generic;
using SFACGPC.Objects.Primitive;
using SFACGPC.Objects.Primitive;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SFACGPC.Data.Web.Response.PublicBookInfo;

namespace SFACGPC.Core {
    public static class SFClientExtension {
        public static async Task<int> NovelViewData(this SFClient _, int NovelID) {
            var result = await HttpClientFactory.AppApiService().GetUserViewDataResponse();
            foreach (var item in result.data) {
                if (item.novelId == NovelID) {
                    return item.chapterId;
                }
            }
            return -1;
        }

        public static async Task<List<BookItem>> SearchNovels(this SFClient _, string keyword) {
            var result = await HttpClientFactory.AppApiService().SearchNovel(keyword);
            var list = new List<BookItem>();
            if (result is { } res) {
                list.AddRange(res.data.novels.Select(book => new BookItem() {
                    CoverUrl = book.novelCover,
                    Title = book.novelName,
                    Tags = book.expand.sysTags.ToTags(),
                    NovelID = book.novelId,
                    AuthorName = book.authorName,
                    charCount = book.charCount.ToString(),
                    IsSerialize = (!book.isFinish) ? "Visiable" : "Collapsed",
                    IsSign = (book.signStatus == "签约") ? "Visiable" : "Collapsed",
                    IsChatNovel = false,
                }));
            }
            return list;
        }
        public static async Task<List<BookItem>> SearchChatNovels(this SFClient _, string keyword) {
            var result = await HttpClientFactory.AppApiService().SearchChatNovel(keyword);
            var list = new List<BookItem>();
            if (result is { } res) {
                list.AddRange(res.data.novels.Select(book => new BookItem() {
                    CoverUrl = book.novelCover,
                    Title = book.novelName,
                    Tags = book.expand.sysTags.ToTags(),
                    NovelID = book.novelId,
                    AuthorName = book.authorName,
                    charCount = book.charCount.ToString(),
                    IsSerialize = (!book.isFinish) ? "Visiable" : "Collapsed",
                    IsSign = (book.signStatus == "签约") ? "Visiable" : "Collapsed",
                    IsChatNovel = true
                }));
            }
            return list;
        }

        public static async Task PutUserView(this SFClient _, int NovelID, int ChapID) {
            await HttpClientFactory.AppApiService().PutUserNovelView(NovelID.ToString(), new Data.Web.Request.UserNovelViews() {
                chapterId = ChapID,
                triggerCardPieceDrop = true
            });
        }
        public static async Task<ChapItem> GetChapContent(this SFClient _, int ChapID) {
            var result = await HttpClientFactory.AppApiService().GetChapDetailResponse(ChapID.ToString());
            return new ChapItem() {
                ChapID = result.data.chapId,
                NovelID = result.data.novelId,
                VolumeID = result.data.volumeId,
                Content = result.data.expand.content,
                Title = result.data.title
            };
        }
        public static async Task<List<ChatLineItem>> GetChapChatline(this SFClient _, int ChapID) {
            var result = await HttpClientFactory.AppApiService().GetChapDetailResponse(ChapID.ToString());
            var list = new List<ChatLineItem>();

            if (result is { } res) {
                list.AddRange(res.data.expand.chatLines.Select(p => new ChatLineItem() {
                    Avatar = p.avatar,
                    CharId = p.charId,
                    CharName = p.charName,
                    Content = p.content.FormatUnalbeShowChar(),
                    Image = p.image,
                    ChatType = (p.charType == 0&&!p.avatar.IsNullOrEmpty()) ? "Left" : (!p.avatar.IsNullOrEmpty() ? "Right" : "Center"),
                    IsShowChip = (p.avatar.IsNullOrEmpty()) ? "Collapsed" : "Visiable"
                }));
            }
            return list;
        }

        public static async Task<List<Volumelist>> GetBookDir(this SFClient _, int NovelID) {
            var result = await HttpClientFactory.AppApiService().GetNovelDirResponse(NovelID.ToString());
            var list = new List<Volumelist>();

            if (result is { } res) {
                list.AddRange(res.data.volumeList.Select(p => new Volumelist {
                    Chapterlist = p.chapterList.ToChapterItem(),
                    Sno = p.sno,
                    Title = p.title,
                    VolumeId = p.volumeId
                }));
            }
            return list;
        }

        public static async Task<BookInfo> GetBookInfo(this SFClient _, string NovelID) {
            var result = await HttpClientFactory.AppApiService().GetNovelInfoResponse(NovelID);
            return new BookInfo() {
                AuthorName = result.data.authorName,
                ImgUrl = result.data.novelCover,
                AuthorUrl = await GetAuthorAvatar(_, result.data.authorId),
                Intro = result.data.expand.intro,
                IsNeedVIP = result.data.signStatus.ToLower().IndexOf("vip") >= 0,
                LatestString = result.data.expand.latestChapter.addTime.ToString() + "    " + result.data.expand.latestChapter.title,
                MarkCount = result.data.markCount.ToString(),
                Point = (int)(result.data.point / 2),
                TicketCount = result.data.expand.ticket.ToString(),
                Title = result.data.novelName,
                TypeString = result.data.expand.typeName + "/" + ((!result.data.isFinish) ? "连载中" : "已完结"),
                Like = result.data.expand.fav
            };
        }
        public static async Task<string> GetAuthorAvatar(this SFClient _, int AuthorID) {
            var result = await HttpClientFactory.AppApiService().GetAuthorInfo(AuthorID.ToString());
            return result.data.avatar;
        }
        public static async Task<List<SpecialPushItem>> GetComicsSpecialPush(this SFClient _) {
            var result = await HttpClientFactory.AppApiService().GetComicsSpecialPushResponse();
            var list = new List<SpecialPushItem>();
            if (result is { } res) {
                list.AddRange(res.data.comicPush.Select(book => new SpecialPushItem() {
                    ImgUrl = book.imgUrl,
                    Link = book.link,
                    Type = book.type
                }));
            }
            return list;
        }

        public static async Task<List<SpecialPushItem>> GetChatNovelSpecialPush(this SFClient _) {
            var result = await HttpClientFactory.AppApiService().GetSpecialPushResponse();
            var list = new List<SpecialPushItem>();
            if (result is { } res) {
                list.AddRange(res.data.chatNovelPush.Select(book => new SpecialPushItem() {
                    ImgUrl = book.imgUrl,
                    Link = book.link,
                    Type = book.type
                }));
            }
            return list;
        }

        public static async Task<List<SpecialPushItem>> GetSpecialPush(this SFClient _) {
            var result = await HttpClientFactory.AppApiService().GetSpecialPushResponse();
            var list = new List<SpecialPushItem>();
            if (result is { } res) {
                list.AddRange(res.data.homePush.Select(book => new SpecialPushItem() {
                    ImgUrl = book.imgUrl,
                    Link = book.link,
                    Type = book.type
                }));
            }
            return list;
        }

        public static async Task<List<HotPushItem>> GetNovelHotPush(this SFClient _) {
            var result = await HttpClientFactory.AppApiService().GetNovelHotPushResponse();
            var list = new List<HotPushItem>();
            if (result is { } res) {
                list.AddRange(res.data.Select(book => new HotPushItem() {
                    CoverUrl = book.novelCover,
                    Title = book.novelName,
                    Tags = book.expand.sysTags.ToTags(),
                    NovelID = book.novelId,
                    AuthorName = book.authorName,
                    charCount = book.charCount.ToString(),
                    IsSerialize = (!book.isFinish) ? "Visiable" : "Collapsed",
                    IsSign = (book.signStatus == "签约") ? "Visiable" : "Collapsed",
                    IsChatNovel = false
                }));
            }
            return list;
        }
        public static async Task<List<HotPushItem>> GetComicsHotPush(this SFClient _) {
            var result = await HttpClientFactory.AppApiService().GetComicsHotPushResponse();
            var list = new List<HotPushItem>();
            if (result is { } res) {
                list.AddRange(res.data.Select(book => new HotPushItem() {
                    CoverUrl = book.comicCover,
                    Title = book.comicName,
                    NovelID = book.comicId,
                    AuthorName = book.comicName,
                    IsSerialize = (!book.isFinished)? "Visiable" : "Collapsed",
                    IsSign = "Collapsed"
                }));
            }
            return list;
        }
        public static async Task<List<HotPushItem>> GetChatNovelHotPush(this SFClient _) {
            var result = await HttpClientFactory.AppApiService().GetChatNovelPushResponse();
            var list = new List<HotPushItem>();
            if (result is { } res) {
                list.AddRange(res.data.Select(book => new HotPushItem() {
                    CoverUrl = book.novelCover,
                    Title = book.novelName,
                    Tags = book.expand.sysTags.ToTags(),
                    NovelID = book.novelId,
                    AuthorName = book.authorName,
                    charCount = book.charCount.ToString(),
                    IsSerialize = (!book.isFinish) ? "Visiable" : "Collapsed",
                    IsSign = (book.signStatus == "签约") ? "Visiable" : "Collapsed",
                    IsChatNovel = true,
                }));
            }
            return list;
        }

        public static List<tag> ToTags<T>(this T[] systags) where T : Systag {
            var tags = new List<tag>();
            if (systags.IsNullOrEmpty()) return tags;
            tags.AddRange(systags.Select(tagitem => new tag() {
                tagName = tagitem.tagName,
                sysTagId = tagitem.sysTagId
            }));
            return tags;
        }

        public static List<ChapterItem> ToChapterItem<T>(this T[] chapterlist) where T : NovelDirResponse.Chapterlist {
            var result = new List<ChapterItem>();
            result.AddRange(chapterlist.Select(p => new ChapterItem() {
                ChapId = p.chapId,
                CharCount = p.charCount,
                IsVip = p.isVip,
                NeedFireMoney = p.needFireMoney,
                NovelId = p.novelId,
                Title = p.title,
                UpdateTime = p.updateTime,
                VolumeId = p.volumeId
            }));
            return result;
        }
    }
}
