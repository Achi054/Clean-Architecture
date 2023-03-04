using FluentAssertions;

using NetArchTest.Rules;

namespace Clean.Architecture.Design.Tests
{
    public class DependencyTests
    {
        private const string DomainNamespace = "Clean.Architecture.Domain";
        private const string ApplicationNamespace = "Clean.Architecture.Application";
        private const string InfrastructureNamespace = "Clean.Architecture.Infrastructure";
        private const string PresentationNamespace = "Clean.Architecture.Presentation";
        private const string WebNamespace = "Clean.Architecture.Web";

        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(Domain.TestClass).Assembly;

            var projectReferencable = new[]
            {
                ApplicationNamespace,
                InfrastructureNamespace,
                PresentationNamespace,
                WebNamespace,
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(projectReferencable)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Application_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(Application.TestClass).Assembly;

            var projectReferencable = new[]
            {
                InfrastructureNamespace,
                PresentationNamespace,
                WebNamespace,
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(projectReferencable)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(Infrastructure.TestClass).Assembly;

            var projectReferencable = new[]
            {
                PresentationNamespace,
                WebNamespace,
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(projectReferencable)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(Presentation.TestClass).Assembly;

            var projectReferencable = new[]
            {
                WebNamespace,
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(projectReferencable)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Web_Should_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(Web.Controllers.WeatherForecastController).Assembly;

            var projectReferencable = new[]
            {
                ApplicationNamespace,
                InfrastructureNamespace,
                PresentationNamespace,
                DomainNamespace,
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .Should()
                .HaveDependencyOnAll(projectReferencable)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }
    }
}