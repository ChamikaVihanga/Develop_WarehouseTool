﻿using Bunit;
using Workspace.Client.Pages;

namespace Workspace.Tests.workspace.vsag.ch
{
    public class CounterTest
    {

        [Fact]
        public void CounterShouldIncrementWhenClicked()
        {
            // Arrange: render the Counter.razor component
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();

            // Act: find and click the <button> element to increment
            // the counter in the <p> element
            cut.Find("button").Click();

            // Assert: first find the <p> element, then verify its content
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 1</p>");
        }
    }
}
