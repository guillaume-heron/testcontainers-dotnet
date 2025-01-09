using Xunit;

namespace TestContainers.IntegrationTests;

[CollectionDefinition(nameof(IntegrationTestCollectionDefinition))]
public sealed class IntegrationTestCollectionDefinition : ICollectionFixture<IntegrationTestWebAppFactory>;