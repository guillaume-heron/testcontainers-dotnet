using Xunit;

namespace TestContainers.IntegrationTests.Configuration;

[CollectionDefinition(nameof(IntegrationTestCollectionDefinition))]
public sealed class IntegrationTestCollectionDefinition : ICollectionFixture<IntegrationTestWebAppFactory>;