

namespace SalesOnline.Application.Core
{
    public interface IBaseService<TDtoAdd, TDtoUpdate, TDtoRemove>
    {
        ServiceResult GetAll();
        ServiceResult GetById(int id);
        ServiceResult Save(TDtoAdd dtoAdd);
        ServiceResult Update(TDtoUpdate dtoUpdate);
        ServiceResult Remove(TDtoRemove dtoRemove);

    }
}
