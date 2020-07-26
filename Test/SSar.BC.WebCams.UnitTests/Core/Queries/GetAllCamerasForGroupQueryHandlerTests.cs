using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using Shouldly;
using SSar.BC.WebCams.Core.Interfaces;
using SSar.BC.WebCams.Core.Queries.GetAllCamerasForGroup;
using SSar.BC.WebCams.Core.Services;
using SSar.BC.WebCams.Core.ValueTypes;
using Xunit;

namespace SSar.BC.WebCams.UnitTests.Core.Queries
{
    public class GetAllCamerasForGroupQueryHandlerTests
    {
        [Fact]
        public async Task Returns_camera_list_for_group_from_the_catalog()
        {
            var cameraList = new List<Camera>();
            var wrongCameraList = new List<Camera>();
            
            var camCatalog = A.Fake<IWebCamCatalog>();
            A.CallTo(() => camCatalog.CameraGroups[5].Cameras).Returns(cameraList);

            var query = new GetAllCamerasForGroupQuery(5);

            var sut = new GetAllCamerasForGroupQuery.GetAllCamerasForGroupQueryHandler(camCatalog);

            var result = await sut.Handle(query, new CancellationToken());

            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(cameraList),
                () => result.ShouldNotBe(wrongCameraList));
        }

        public void Returns_empty_list_if_no_cameras()
        {

        }

        public void Returns_empty_list_if_null_cameras()
        {

        }

        public void Throws_argument_null_exception_for_null_catalog()
        {

        }

        // TODO: Implement this exception
        public void Throws_InvalidCameraGroupId_if_no_such_camera_group()
        {

        }
    }
}
