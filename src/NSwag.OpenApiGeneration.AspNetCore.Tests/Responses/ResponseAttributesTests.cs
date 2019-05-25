﻿using System.Linq;
using System.Threading.Tasks;
using NSwag.OpenApiGeneration.AspNetCore.Tests.Web.Controllers;
using Xunit;

namespace NSwag.OpenApiGeneration.AspNetCore.Tests.Responses
{
    public class ResponseAttributesTests : AspNetCoreTestsBase
    {
        [Fact]
        public async Task When_operation_has_SwaggerResponseAttribute_with_description_it_is_in_the_spec()
        {
            // Arrange
            var settings = new AspNetCoreOpenApiDocumentGeneratorSettings();

            // Act
            var document = await GenerateDocumentAsync(settings, typeof(ResponsesController));
            var json = document.ToJson();

            // Assert
            var operation = document.Operations.First().Operation;

            Assert.Equal("Foo.", operation.ActualResponses.First().Value.Description);
        }
    }
}