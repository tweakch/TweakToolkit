using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweakToolkit.EntityFramework;
using TweakToolkit.MVVM.Gateway;
using TweakToolkit.MVVM.Model;
using TweakToolkit.MVVM.Service;

namespace TweakToolkit.MVVM.Test.Service
{
    public class CycleModelService : IGatewayService
    {
        private readonly IGateway _gateway;

        public CycleModelService(IGateway gateway)
        {
            _gateway = gateway;
            AutoMapper.Mapper.CreateMap<Cycle, CycleModel>();
        }

        public event ReadModelsCompletedHandler ReadCompleted;

        public object Create()
        {
            var source = _gateway.Create<Cycle>();
            return AutoMapper.Mapper.Map<CycleModel>(source);
        }

        public void OnReadCompleted(ReadModelsCompletedArgs args)
        {
            ReadModelsCompletedHandler handler = ReadCompleted;
            if (handler != null) handler(this, args);
        }

        public void Read()
        {
            Task<IEnumerable<Cycle>>.Factory.StartNew(_gateway.Read<Cycle>)
                .ContinueWith(task =>
                                  {
                                      Cycle[] source = task.Result.ToArray();
                                      var cycleModels = AutoMapper.Mapper.Map<Cycle[], IEnumerable<CycleModel>>(source);
                                      var serviceReadCompletedEventArgs = new ReadModelsCompletedArgs(cycleModels);
                                      OnReadCompleted(serviceReadCompletedEventArgs);
                                  });
        }

        public void Update(object model)
        {
            var cycleModel = model as CycleModel;
            if (cycleModel == null) return;
            _gateway.Update<Cycle>(c => c.Id == cycleModel.Id, cycle => UpdateCycle(ref cycle, cycleModel));
        }

        private void UpdateCycle(ref Cycle cycle, CycleModel cycleModel)
        {
            if (cycle != null)
            {
                AutoMapper.Mapper.Map(cycleModel, cycle);
            }
        }
    }
}