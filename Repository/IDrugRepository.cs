using Pharmacy_Management1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy_Management1.Repository
{
    public interface IDrugRepository
    {
        DrugDetail Create(DrugDetail drugDetail);
        Task<IEnumerable<DrugDetail>> GetAll();

        DrugDetail GetDrugName(string drugName);
        DrugDetail GetDrug(int id);
        void DeleteDrug(int id);
        void UpdateDrug(DrugDetail drugDetail);
    }
}