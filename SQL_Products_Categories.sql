SELECT [p].[Name], [c].[Name]
FROM [Products] AS [p]
LEFT JOIN [Categories] as [c]
    ON [p].[Id] = [c].[Id]