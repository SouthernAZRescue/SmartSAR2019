using System;
using System.Collections.Generic;
using System.Text;
using Shouldly;
using SSar.BC.WebCams.Core.Queries.GetAllCamerasForGroup;
using Xunit;

namespace SSar.BC.WebCams.UnitTests.Core.Queries
{
    public class GetAllCamerasForGroupQueryTests
    {
        [Fact]
        public void Constructor_sets_properties()
        {
            var groupId = 7;

            var sut = new GetAllCamerasForGroupQuery(groupId);

            sut.GroupId.ShouldBe(groupId);
        }
    }
}
