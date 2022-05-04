﻿using System.Windows.Input;
using System.Windows.Media.Imaging;
using iPhoto.Commands.AlbumPage;
using iPhoto.Commands.SearchPage;
using iPhoto.UtilityClasses;
using iPhoto.Views.AlbumPage;
using iPhoto.DataBase;

namespace iPhoto.ViewModels.AlbumsPage
{
    public class AddPhotoToAlbumPopupViewModel : ViewModelBase
    {
        public ICommand DiscardCommand { get; }
        public ICommand CommitWithGivenAlbumCommand { get; }
        public Album CurrentAlbum { get; }
        public AddPhotoToAlbumPopupView ParentView { get; set; }
        public BitmapImage Image { get; set; }
        public PhotoAdder PhotoAdder { get; set; }
        public AddPhotoToAlbumPopupViewModel(Album currentAlbum, AlbumContentViewModel albumVm)
        {
            DiscardCommand = new DiscardCommand();
            CommitWithGivenAlbumCommand = new CommitWithGivenAlbumCommand(albumVm);
            CurrentAlbum = currentAlbum;

        }
    }
}

