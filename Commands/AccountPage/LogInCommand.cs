﻿using iPhoto.ViewModels.AccountPage;

namespace iPhoto.Commands.AccountPage
{
    public class LogInCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as LogInViewModel;

            var username = viewModel.UsernameText;
            var password = viewModel.SecurePassword;

            viewModel.AccountViewModel.CurrentViewModel = viewModel.AccountViewModel.LoggedInViewModel;

            //Process.Start(new ProcessStartInfo
            //{
            //    FileName = "http://weiti.pl",
            //    UseShellExecute = true
            //});
        }
    }
}
