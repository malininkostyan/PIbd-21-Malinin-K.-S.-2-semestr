using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    public interface IExecutorService
    {
        List<ExecutorViewModel> ListGet();
        ExecutorViewModel ElementGet(int id);
        void AddElement(ExecutorBindingModel model);
        void UpdateElement(ExecutorBindingModel model);
        void DeleteElement(int id);
        ExecutorViewModel GetFreeWorker();
    }
}
