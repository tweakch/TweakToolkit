using System;
using System.Collections.ObjectModel;
using TweakToolkit.MVVM.Model;
using TweakToolkit.MVVM.Service;

namespace TweakToolkit.MVVM.Test.Model
{
    public partial class CycleModelCollection : ObservableCollection<CycleModel>
    {
        private readonly ItemRepository<CycleModel> repository;
        private readonly IServiceProvider provider;

        private IGatewayService service;

        public CycleModelCollection(IServiceProvider provider)
        {
            this.provider = provider;
            repository = new ItemRepository<CycleModel>();
            Service.ReadCompleted += Service_ReadCompleted;
            Read();
        }

        public bool IsConsistent { get; set; }

        public IGatewayService Service
        {
            get { return service ?? (service = GetService()); }
        }

        public void Service_ReadCompleted(object sender, ReadModelsCompletedArgs args)
        {
            foreach (var cycleModel in args.GetItems<CycleModel>())
            {
                Add(cycleModel);
            }
            Reading = false;
        }

        public void Save()
        {
            repository.ValidateItems(new CycleModelValidator());
            UpdateValidItems();
            repository.ClearValidItems();
        }

        private void UpdateValidItems()
        {
            foreach (var cycleModel in repository.ValidItems)
            {
                service.Update(cycleModel);
            }
        }

        protected override void ClearItems()
        {
            base.ClearItems();
        }

        protected override void InsertItem(int index, CycleModel item)
        {
            item.PropertyChanged += (sender, args) => StageItem(sender as CycleModel);
            base.InsertItem(index, item);
        }

        private void StageItem(CycleModel cycleModel)
        {
            repository.StageItem(cycleModel);
        }

        protected override void MoveItem(int oldIndex, int newIndex)
        {
            base.MoveItem(oldIndex, newIndex);
        }

        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }

        protected override void SetItem(int index, CycleModel item)
        {
            base.SetItem(index, item);
        }

        private IGatewayService GetService()
        {
            return provider.GetService(typeof(CycleModel)) as IGatewayService;
        }

        private void Read()
        {
            Reading = true;
            Service.Read();
        }

        public bool Reading { get; set; }
    }
}