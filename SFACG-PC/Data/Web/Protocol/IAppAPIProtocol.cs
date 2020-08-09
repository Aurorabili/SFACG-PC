using Refit;
using SFACGPC.Data.Web.Request;
using SFACGPC.Data.Web.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SFACGPC.Data.Web.Protocol {
    [Headers("Authorization: Basic")]
    public interface IAppAPIProtocol {
        [Get("/specialpush")]
        Task<SpecialPushResponse> GetSpecialPushResponse();

        [Get("/novels/0/sysTags?filter=push")]
        Task<SysTagsResponse> GetSysTagsResponse();

        [Get("/novels?size=8&filter=hotpush&expand=sysTags%2Cdiscount%2CdiscountExpireDate")]
        Task<NovelHotPushResponse> GetNovelHotPushResponse();

        [Get("/novels?size=8&filter=newpush&expand=sysTags%2Cdiscount%2CdiscountExpireDate")]
        Task<NovelNewPushResponse> GetNovelNewPushResponse();

        [Get("/novels/{novelid}")]
        Task<NovelInfoResponse> GetNovelInfoResponse(GetNovelInfo getNovelInfo);

        [Get("/novels/{novelid}/dirs?expand=originNeedFireMoney")]
        Task<NovelDirResponse> GetNovelDirResponse([AliasAs("novelid")]string NovelID);

        [Get("/Chaps/{chapid}?expand=content%2CneedFireMoney%2CoriginNeedFireMoney%2Ctsukkomi%2Cchatlines&autoOrder=false")]
        Task<ChapDetailResponse> GetChapDetailResponse([AliasAs("chapid")]string ChapID);

        [Get("/user?expand=vipInfo%2CwelfareCoin%2CisRealNameAuth%2CchangeNickNameInfo%2CwelfareMoney%2CredpacketCode%2CuseWelfaresys%2CusedRedpacketCode")]
        Task<UserInfoResponse> GetUserInfoResponse();

        [Get("/user/tickets?page=0&size=24&isexpired=not")]
        Task<UserTicketResponse> GetUserTicketResponse();

        [Get("/user/money")]
        Task<UserMoneyResponse> GetUserMoneyResponse();
    }
}
