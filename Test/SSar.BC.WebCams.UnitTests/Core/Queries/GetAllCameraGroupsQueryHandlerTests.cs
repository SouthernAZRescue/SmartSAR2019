using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FakeItEasy;
using Shouldly;
using SSar.BC.WebCams.Core.Interfaces;
using SSar.BC.WebCams.Core.Queries.GetAllCameraGroups;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.UnitTests.Core.Queries
{
    public class GetAllCameraGroupsQueryHandlerTests
    {
        [Fact]
        public async Task Returns_CameraGroup_list_from_catalog()
        {
            var populatedCameraGroupList = new List<CameraGroup>(
                new CameraGroup[1]);

            var webCamCatalog = A.Fake<IWebCamCatalog>();
            A.CallTo(() => webCamCatalog.CameraGroups)
                .Returns(populatedCameraGroupList);

            var sut = new GetAllCameraGroupsQuery
                .GetAllCameraGroupsQueryHandler(webCamCatalog);

            var result = await sut.Handle(
                new GetAllCameraGroupsQuery(), new CancellationToken());

            result.ShouldBe(populatedCameraGroupList);
        }

        [Fact]
        public async Task Returns_non_null_list_even_if_CameraGroups_is_null()
        {
            var webCamCatalog = A.Fake<IWebCamCatalog>();
            A.CallTo(() => webCamCatalog.CameraGroups)
                .Returns(null);

            var sut = new GetAllCameraGroupsQuery.GetAllCameraGroupsQueryHandler(webCamCatalog);

            var result = await sut.Handle(
                new GetAllCameraGroupsQuery(), new CancellationToken());

            result.ShouldNotBeNull();
        }

        [Fact]
        public void Null_WebCamCatalog_triggers_argument_null_exception()
        {
            Should.Throw<ArgumentNullException>(
                () => new GetAllCameraGroupsQuery
                    .GetAllCameraGroupsQueryHandler(null));
        }
    }
}
