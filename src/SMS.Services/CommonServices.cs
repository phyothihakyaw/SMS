using System.Collections.Generic;

namespace SMS.Services
{
    public abstract class CommonServices<T>
    {
        public abstract List<T> GetAll();

        public abstract T GetById(int id);

        public abstract void Create(T viewModel, string userId);

        public abstract void Update(T viewModel, string userId);

        public abstract void Delete(int id);

        public string GenerateViewBagTitle(int id)
        {
            return id == 0 ? "Create New Township" : "Edit existing township";
        }
    }
}
