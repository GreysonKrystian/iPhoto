﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using iPhoto.Commands;
using iPhoto.Commands.SearchPage;
using iPhoto.DataBase;
using iPhoto.UtilityClasses;
using iPhoto.ViewModels.SearchPage;
using iPhoto.Views.SearchPage;

namespace iPhoto.ViewModels
{
    public class SearchViewModel : ViewModelBase, IPhotoSearchVM
    {
        public ICommand SearchCommand { get; }
        public ICommand ExtendSearchMenuCommand { get; }
        public ICommand ExtendPhotoDetailsCommand { get; }
        public ICommand AddPhotoCommand { get; }
        public ICommand ClearSearchParamsCommand { get; }

        public ObservableCollection<PhotoSearchResultViewModel> PhotoSearchResultsCollection { get; set; }
        public ObservableCollection<string> AlbumList
        {
            get
            {
                return DatabaseHandler.GetAlbumList(true);
            }
        }
        public DatabaseHandler DatabaseHandler { get; } //MG 15.04 added db handler class
        public SearchEngine SearchEngine { get; } //MG 27.04 Added
        public PhotoDetailsViewModel PhotoDetails { get; }  //MG 26.04 Added photo details

        public BitmapImage ExtendMenuImage { get; } = DataHandler.LoadBitmapImage(DataHandler.GetSideMenuIconsDirectoryPath() + "ExtendMenu.png", 144);
        public BitmapImage SearchImage { get; } = DataHandler.LoadBitmapImage(DataHandler.GetSideMenuIconsDirectoryPath() + "Search.png", 144);
        public BitmapImage PhotoDetailsImage { get; } = DataHandler.LoadBitmapImage(DataHandler.GetSideMenuIconsDirectoryPath() + "PhotoDetails.png", 144);
        public BitmapImage AddPhotoImage { get; } = DataHandler.LoadBitmapImage(DataHandler.GetSideMenuIconsDirectoryPath() + "AddPhoto.png", 144);

        public SearchViewModel(DatabaseHandler database, PhotoDetailsWindowView photoDetailsWindow)
        {
            PhotoSearchResultsCollection = new ObservableCollection<PhotoSearchResultViewModel>();
            DatabaseHandler = database;


            ExtendSearchMenuCommand = new ExtendSearchMenuCommand();
            ExtendPhotoDetailsCommand = new ExtendPhotoDetailsCommand(photoDetailsWindow);
            AddPhotoCommand = new AddPhotoCommand(DatabaseHandler);
            ClearSearchParamsCommand = new ClearSearchParamsCommand(false);

            PhotoDetails = new PhotoDetailsViewModel(photoDetailsWindow, ExtendPhotoDetailsCommand as ExtendPhotoDetailsCommand);
            photoDetailsWindow.DataContext = PhotoDetails;

            SearchEngine = new SearchEngine(DatabaseHandler, this);
            SearchCommand = new SearchCommand(SearchEngine);
        }
    }
}
