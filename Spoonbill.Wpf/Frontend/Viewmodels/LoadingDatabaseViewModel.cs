using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data;

namespace Spoonbill.Wpf.Frontend.ViewModels;

public class LoadingDatabaseViewModel : ViewModel
{
    private readonly SpoonbillContext m_dbContext;
    private readonly IProgress<bool> m_finishedProgress;

    public LoadingDatabaseViewModel(SpoonbillContext dbContext, MainWindowViewModel mainWindowViewModel)
    {
        m_dbContext = dbContext;
        m_finishedProgress = mainWindowViewModel.DatabaseConnectionIndicator;

        BeginTryLoad();
    }

    public ProgressViewModel<string> LoadingMessage { get; } = new ProgressViewModel<string>();

    public void BeginTryLoad()
    {
        LoadingMessage.Report("Loading...");
        Thread thread = new Thread(Load_Internal)
        {
            Name = "Database Lifetime check",
            IsBackground = true, // thread is non-essential
        };
        thread.Start();
    }

    private void Load_Internal()
    {
        LoadingMessage.Report("Polling database...");
        try
        {
            DbConnection dbConnection = m_dbContext.Database.GetDbConnection();
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
                dbConnection.Close();
            }

            // report final message and give user time to read it before reporting success
            LoadingMessage.Report("Connected Successfully!");
            Thread.Sleep(1);
            m_finishedProgress.Report(true);
        }
        catch (Exception e)
        {
            LoadingMessage.Report($"Error: {e.Message}");
        }
    }
}