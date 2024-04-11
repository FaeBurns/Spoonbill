using System.Reflection;

namespace Spoonbill.Tests;

public static class TestSetup
{
    private static string SearchParentForSolutionDirectory(string startingPath)
    {
        // if there is nothing left to search then return nothing
        if (startingPath == "")
            return String.Empty;

        string? dirName = Path.GetDirectoryName(startingPath);
        if (dirName == null)
            return String.Empty;

        foreach (string file in Directory.GetFiles(dirName))
        {
            if (Path.GetExtension(file) == ".sln")
            {
                return dirName;
            }
        }

        DirectoryInfo? parentDir = Directory.GetParent(dirName);
        if (parentDir == null)
            return String.Empty;
        
        return SearchParentForSolutionDirectory(parentDir.FullName);
    }

    private static string SolutionDirectory { get; } = SearchParentForSolutionDirectory(Assembly.GetExecutingAssembly().Location);
    
    public static string ConnectionString { get; private set; } = $"Data Source={Path.Combine(SolutionDirectory, "db\\test_db.sqlite")};";
}