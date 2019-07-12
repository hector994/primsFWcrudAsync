using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BatPrismTutorials.Model;
using BatPrismTutorials.Services;


namespace BatPrismTutorials.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //public MainPageViewModel(INavigationService navigationService)
        //    : base(navigationService)
        //{
        //    Title = "Main Page";
        //}



        private IBatFamilyService BatItemService { get; }

        private IEnumerable<BatFamily> BatFamilyAll;
        public IEnumerable<BatFamily> BatFamilyAlls
        {
            get { return this.BatFamilyAll; }
            set { this.SetProperty(ref this.BatFamilyAll, value); }
        }

        private BatFamily SelectedBatFamily_BF; 
        public BatFamily SelectedBatFamily 
        {
            get { return this.SelectedBatFamily_BF; }
            set
            {
                this.SetProperty(ref this.SelectedBatFamily_BF, value);
                if (SelectedBatFamily_BF !=null)
                {
                    this.InputText = this.SelectedBatFamily_BF.Nombre;
                }
            }
        }


        private string inputText;
        public string InputText
        {
            get { return this.inputText; }
            set { this.SetProperty(ref this.inputText, value); }
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand<BatFamily> UpdateCommand { get; }
        public DelegateCommand<BatFamily> DeleteCommand { get; }

        public MainPageViewModel(INavigationService navigationService, IBatFamilyService batFamilyServiceParam) : base(navigationService)
        {
            this.BatItemService = batFamilyServiceParam;

            SelectedBatFamily_BF = new BatFamily();

            GetBatFamilies();

            this.AddCommand = new DelegateCommand
                (this.AddTodoItem, () => !string.IsNullOrEmpty(this.InputText)).ObservesProperty(() => this.InputText);

            this.DeleteCommand = new DelegateCommand<BatFamily>(this.DeleteTodoItem);
            //this.UpdateCommand = new DelegateCommand(this.UpdateTodoItem);//, () => !string.IsNullOrEmpty(this.InputText));//.ObservesProperty(() => this.InputText);
            this.UpdateCommand = new DelegateCommand<BatFamily>(this.UpdateTodoItem);


        }

        private async void GetBatFamilies()
        {
            this.BatFamilyAlls = await this.BatItemService.GetAllAsync();
        }

        //private void DeleteTodoItem(BatFamily BatParent)
        //{
        //    this.BatItemService.Delete(BatParent.Id);
        //    this.BatFamilyAlls = this.BatItemService.GetFamilies();
        //}

        private async void DeleteTodoItem(BatFamily BatParent)
        {
            await this.BatItemService.DaleteAsync(BatParent);
            this.BatFamilyAlls = await this.BatItemService.GetAllAsync();
        }
        //private void UpdateTodoItem()//(BatFamily BatParent)
        //{
        //    this.SelectedBatFamily.Nombre = InputText;
        //    this.BatItemService.Update(SelectedBatFamily);
        //    this.InputText = "";
        //    this.BatFamilyAlls = this.BatItemService.GetFamilies();

        //    //string sabana = InputText;
        //    //this.SelectedBatFamily.Nombre = sabana;//?? "hector";
        //    //if (sabana != null)
        //    //{
        //    //    this.BatItemService.Update(SelectedBatFamily);
        //    //    this.InputText = "";
        //    //    this.BatFamilyAlls = this.BatItemService.GetFamilies();
        //    //}
        //    //else
        //    //{
        //    //    InputText = "error";
        //    //}
        //    //this.BatItemService.Update(SelectedBatFamily);
        //    //this.InputText = "";
        //    //this.BatFamilyAlls = this.BatItemService.GetFamilies();
        //}

        private async void UpdateTodoItem(BatFamily BatParent)
        {
            BatParent.Nombre = this.inputText;
            this.InputText = "";
            await this.BatItemService.UpdateAsync(BatParent);

            this.BatFamilyAlls = await this.BatItemService.GetAllAsync();

        }
        //private void AddTodoItem()
        //{
        //    this.BatItemService.Insert(new BatFamily { Nombre = this.InputText });
        //    this.InputText = "";
        //    this.BatFamilyAlls = this.BatItemService.GetFamilies();
        //}

        private async void AddTodoItem()
        {
            await this.BatItemService.InsertAsync(new BatFamily { Nombre = this.InputText });
            this.InputText = "";
            this.BatFamilyAlls = await this.BatItemService.GetAllAsync();
        }

        public async void OnNavigatedFrom(NavigationParameters parameters)
        {
            ///se edito
            ///
            this.BatFamilyAlls = await this.BatItemService.GetAllAsync();
        }

        //public void OnNavigatedTo(NavigationParameters parameters)
        //{
        //    this.BatFamilyAlls = this.BatItemService.GetFamilies();
           
        //}
        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            this.BatFamilyAlls =await this.BatItemService.GetAllAsync();
        }
    }
}
