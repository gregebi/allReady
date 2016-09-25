﻿using AllReady.Areas.Admin.Features.Skills;
using System.Threading.Tasks;
using AllReady.UnitTest.Features.Campaigns;
using Xunit;

namespace AllReady.UnitTest.Areas.Admin.Features.Skills
{
    public class SkillEditQueryHandlerAsyncTests : InMemoryContextTest
    {
        [Fact]
        public async Task CorrectSkillReturnedWhenIdInMessage()
        {
            var handler = new SkillEditQueryHandler(Context);
            var result = await handler.Handle(new SkillEditQuery { Id = 4 });

            Assert.NotNull(result);
            Assert.Equal("Skill 4", result.Name);
        }

        [Fact]
        public async Task NullReturnedWhenSkillIdDoesNotExists()
        {
            var handler = new SkillEditQueryHandler(Context);
            var result = await handler.Handle(new SkillEditQuery { Id = 100 });

            Assert.Null(result);
        }

        [Fact]
        public async Task NullReturnedWhenSkillIdNotInMessage()
        {
            var handler = new SkillEditQueryHandler(Context);
            var result = await handler.Handle(new SkillEditQuery());

            Assert.Null(result);
        }

        protected override void LoadTestData()
        {
            SkillsHandlerTestHelper.LoadSkillsHandlerTestData(Context);
        }
    }
}