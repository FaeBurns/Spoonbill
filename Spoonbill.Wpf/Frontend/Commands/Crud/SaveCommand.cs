﻿using System.Windows;
using Spoonbill.Wpf.Frontend.ViewModels.Crud;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.Commands.Crud;

public class SaveCommand : SimpleCommand
{
    private readonly object m_model;
    private readonly ICrudTemplate m_template;
    private readonly CrudHostViewModel m_hostViewModel;
    private readonly IntrospectMode m_mode;

    public SaveCommand(object model, ICrudTemplate template, CrudHostViewModel hostViewModel, IntrospectMode mode)
    {
        m_model = model;
        m_template = template;
        m_hostViewModel = hostViewModel;
        m_mode = mode;
    }

    public override void Execute(object? parameter)
    {
        IResult result = m_template.Save(m_model, m_mode);

        if (result is Ok)
        {
            // if result is good then notify user and return to the list view
            MessageBox.Show("Operation Successful!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            m_hostViewModel.SelectedItem = null;
        }
        else if (result is IMessageResult messageResult)
        {
            MessageBox.Show($"Error: {messageResult.Message}", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}